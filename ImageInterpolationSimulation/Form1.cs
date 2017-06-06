using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ImageInterpolationSimulation
{
    public partial class Form1 : Form
    {
        private int[, ,] GetImgData(Bitmap myBitmap)
        {
            int[, ,] ImgData = new int[myBitmap.Width, myBitmap.Height, 3];
            BitmapData byteArray = myBitmap.LockBits(new Rectangle(0, 0, myBitmap.Width, myBitmap.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            int ByteOfSkip = byteArray.Stride - byteArray.Width * 3;
            unsafe
            {
                byte* imgPtr = (byte*)(byteArray.Scan0);
                for (int y = 0; y < byteArray.Height; y++)
                {
                    for (int x = 0; x < byteArray.Width; x++)
                    {
                        ImgData[x, y, 2] = (int)*(imgPtr);
                        ImgData[x, y, 1] = (int)*(imgPtr + 1);
                        ImgData[x, y, 0] = (int)*(imgPtr + 2);
                        imgPtr += 3;
                    }
                    imgPtr += ByteOfSkip;
                }
            }

            myBitmap.UnlockBits(byteArray);
            return ImgData;
        }
        public static Bitmap CreateBitmap(int[, ,] ImgData)
        {
            int Width = ImgData.GetLength(0);
            int Height = ImgData.GetLength(1);
            Bitmap myBitmap = new Bitmap(Width, Height, PixelFormat.Format24bppRgb);

            BitmapData byteArray = myBitmap.LockBits(new Rectangle(0, 0, Width, Height),
                                           ImageLockMode.WriteOnly,
                                           PixelFormat.Format24bppRgb);
            //Padding bytes的長度
            int ByteOfSkip = byteArray.Stride - myBitmap.Width * 3;
            unsafe
            {
                byte* imgPtr = (byte*)byteArray.Scan0;
                for (int y = 0; y < Height; y++)
                {
                    for (int x = 0; x < Width; x++)
                    {
                        *imgPtr = (byte)ImgData[x, y, 2];       //B

                        *(imgPtr + 1) = (byte)ImgData[x, y, 1];   //G 

                        *(imgPtr + 2) = (byte)ImgData[x, y, 0];   //R  
                        imgPtr += 3;
                    }
                    imgPtr += ByteOfSkip; // 跳過Padding bytes
                }
            }
            myBitmap.UnlockBits(byteArray);
            return myBitmap;
        }
        Bitmap originalBitmap = null;
        Bitmap CFABitmap = null;
        public Form1()
        {
            InitializeComponent();

        }
        private double PSNR(int[, ,] ImgData1, int[, ,] ImgData2, double IgnorePix = 15) {
            double Width = ImgData1.GetLength(0);
            double Height = ImgData2.GetLength(1);
            double MSE = 0;
            for (int y = (int)IgnorePix ; y < Height - (int)IgnorePix ; y++) {
                for (int x = (int)IgnorePix ; x < Width - (int)IgnorePix ; x++) {
                    double e_R = Math.Pow(Convert.ToDouble(ImgData1[x, y, 0]) - Convert.ToDouble(ImgData2[x, y, 0]), 2);
                    double e_G = Math.Pow(Convert.ToDouble(ImgData1[x, y, 1]) - Convert.ToDouble(ImgData2[x, y, 1]), 2);
                    double e_B = Math.Pow(Convert.ToDouble(ImgData1[x, y, 2]) - Convert.ToDouble(ImgData2[x, y, 2]), 2);
                    double pixMSE = (e_R + e_G + e_B) / 3.0;
                    MSE += pixMSE;
                }
            }
            MSE = MSE / (Width - IgnorePix * 2) / (Height - IgnorePix * 2);
            return 10.0 * Math.Log10(255.0 * 255.0 / MSE);
            //return MSE;
        }
        private int Mid(int p1, int p2, int p3, int p4) {
            double w = Convert.ToDouble(p1);
            double x = Convert.ToDouble(p2);
            double y = Convert.ToDouble(p3);
            double z = Convert.ToDouble(p4);
            double total = w + x + y + z;
            double minVal = Math.Min(w, Math.Min(x, Math.Min(y, z)));
            double maxVal = Math.Max(w, Math.Max(x, Math.Max(y, z)));
            return (int)((total - maxVal - minVal) / 2.0);
        }
        private void btnLoadOrigianl_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)   ////由對話框選取圖檔
            {
                originalBitmap = new Bitmap(openFileDialog1.FileName);
                picOriginal.Image = originalBitmap;
            }
        }
        private void btnCFA_Click(object sender, EventArgs e)
        {
            int[, ,] ImgData = GetImgData(originalBitmap);
            CFAProcess(ImgData);
            CFABitmap = CreateBitmap(ImgData);
            picCFA.Image = CFABitmap;

            int[, ,] OriginalData = GetImgData(originalBitmap);
            lblPSNR_CFA.Text = Convert.ToString(PSNR(OriginalData, ImgData));
        }
        private void CFAProcess(int[, ,] ImgData)
        {
            int Width = ImgData.GetLength(0);
            int Height = ImgData.GetLength(1);

            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    if ((x % 2 == 0) && (y % 2 == 0))
                    {
                        ImgData[x, y, 0] = 0;
                        ImgData[x, y, 2] = 0;
                    }
                    else if ((x % 2 == 1) && (y % 2 == 0))
                    {
                        ImgData[x, y, 1] = 0;
                        ImgData[x, y, 2] = 0;
                    }
                    else if ((x % 2 == 0) && (y % 2 == 1))
                    {
                        ImgData[x, y, 0] = 0;
                        ImgData[x, y, 1] = 0;
                    }
                    else if ((x % 2 == 1) && (y % 2 == 1))
                    {
                        ImgData[x, y, 0] = 0;
                        ImgData[x, y, 2] = 0;
                    }
                }
            }
        }
        private void btnBilinear_Click(object sender, EventArgs e)
        {
            int[, ,] ImgData = GetImgData(CFABitmap);
            BIProcess(ImgData);
            Bitmap processedBitmap = CreateBitmap(ImgData);
            picBilinear.Image = processedBitmap;

            int[, ,] OriginalData = GetImgData(originalBitmap);
            lblPSNR_BI.Text = Convert.ToString(PSNR(OriginalData, ImgData));
        }
        private void BIProcess(int[, ,] ImgData)
        {
            int Width = ImgData.GetLength(0);
            int Height = ImgData.GetLength(1);

            for (int y = 1; y < Height - 1; y++)
            {
                for (int x = 1; x < Width - 1; x++)
                {
                    if ((x % 2 == 0) && (y % 2 == 0))
                    {
                        ImgData[x, y, 0] = (ImgData[x + 1, y, 0] + ImgData[x - 1, y, 0]) / 2;
                        ImgData[x, y, 2] = (ImgData[x, y + 1, 2] + ImgData[x, y - 1, 2]) / 2;
                    }
                    else if ((x % 2 == 1) && (y % 2 == 0))
                    {
                        ImgData[x, y, 1] = (ImgData[x + 1, y, 1] + ImgData[x - 1, y, 1] + ImgData[x, y + 1, 1] + ImgData[x, y - 1, 1]) / 4;
                        ImgData[x, y, 2] = (ImgData[x + 1, y + 1, 2] + ImgData[x - 1, y - 1, 2] + ImgData[x - 1, y + 1, 2] + ImgData[x + 1, y - 1, 2]) / 4;
                    }
                    else if ((x % 2 == 0) && (y % 2 == 1))
                    {
                        ImgData[x, y, 0] = (ImgData[x + 1, y, 0] + ImgData[x - 1, y, 0] + ImgData[x, y + 1, 0] + ImgData[x, y - 1, 0]) / 4;
                        ImgData[x, y, 1] = (ImgData[x + 1, y + 1, 1] + ImgData[x - 1, y - 1, 1] + ImgData[x - 1, y + 1, 1] + ImgData[x + 1, y - 1, 1]) / 4;
                    }
                    else if ((x % 2 == 1) && (y % 2 == 1))
                    {
                        ImgData[x, y, 0] = (ImgData[x, y + 1, 0] + ImgData[x, y - 1, 0]) / 2;
                        ImgData[x, y, 2] = (ImgData[x + 1, y, 2] + ImgData[x - 1, y, 2]) / 2;
                    }
                }
            }
        }
        private void btnEPBI_Click(object sender, EventArgs e) {
            int[, ,] ImgData = GetImgData(CFABitmap);
            EPBIProcess(ImgData);
            Bitmap processedBitmap = CreateBitmap(ImgData);
            picEPBI.Image = processedBitmap;

            int[, ,] OriginalData = GetImgData(originalBitmap);
            lblPSNR_EPBI.Text = Convert.ToString(PSNR(OriginalData, ImgData));
        }
        private void EPBIProcess(int[, ,] ImgData) {
            int Width = ImgData.GetLength(0);
            int Height = ImgData.GetLength(1);
            for (int y = 1 ; y < Height - 1 ; y++) {
                for (int x = 1 ; x < Width - 1 ; x++) {
                    if ((x % 2 == 0) && (y % 2 == 0)) {
                        ImgData[x, y, 0] = (ImgData[x + 1, y, 0] + ImgData[x - 1, y, 0]) / 2;
                        ImgData[x, y, 2] = (ImgData[x, y + 1, 2] + ImgData[x, y - 1, 2]) / 2;
                    }
                    else if ((x % 2 == 1) && (y % 2 == 0)) {
                        ImgData[x, y, 1] = Mid(ImgData[x + 1, y, 1], ImgData[x - 1, y, 1], ImgData[x, y + 1, 1], ImgData[x, y - 1, 1]);
                        ImgData[x, y, 2] = Mid(ImgData[x + 1, y + 1, 2], ImgData[x - 1, y - 1, 2], ImgData[x - 1, y + 1, 2], ImgData[x + 1, y - 1, 2]);
                    }
                    else if ((x % 2 == 0) && (y % 2 == 1)) {
                        ImgData[x, y, 0] = Mid(ImgData[x + 1, y, 0], ImgData[x - 1, y, 0], ImgData[x, y + 1, 0], ImgData[x, y - 1, 0]);
                        ImgData[x, y, 1] = Mid(ImgData[x + 1, y + 1, 1], ImgData[x - 1, y - 1, 1], ImgData[x - 1, y + 1, 1], ImgData[x + 1, y - 1, 1]);
                    }
                    else if ((x % 2 == 1) && (y % 2 == 1)) {
                        ImgData[x, y, 0] = (ImgData[x, y + 1, 0] + ImgData[x, y - 1, 0]) / 2;
                        ImgData[x, y, 2] = (ImgData[x + 1, y, 2] + ImgData[x - 1, y, 2]) / 2;
                    }
                }
            }
        }


    }
}
