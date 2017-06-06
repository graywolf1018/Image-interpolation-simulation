namespace ImageInterpolationSimulation
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.picOriginal = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnLoadOrigianl = new System.Windows.Forms.Button();
            this.btnCFA = new System.Windows.Forms.Button();
            this.btnBilinear = new System.Windows.Forms.Button();
            this.picCFA = new System.Windows.Forms.PictureBox();
            this.picBilinear = new System.Windows.Forms.PictureBox();
            this.lblPSNR_BI = new System.Windows.Forms.Label();
            this.lblPSNR_CFA = new System.Windows.Forms.Label();
            this.picEPBI = new System.Windows.Forms.PictureBox();
            this.btnEPBI = new System.Windows.Forms.Button();
            this.lblPSNR_EPBI = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picOriginal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCFA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBilinear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEPBI)).BeginInit();
            this.SuspendLayout();
            // 
            // picOriginal
            // 
            this.picOriginal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picOriginal.Location = new System.Drawing.Point(12, 12);
            this.picOriginal.Name = "picOriginal";
            this.picOriginal.Size = new System.Drawing.Size(200, 200);
            this.picOriginal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picOriginal.TabIndex = 0;
            this.picOriginal.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnLoadOrigianl
            // 
            this.btnLoadOrigianl.Location = new System.Drawing.Point(12, 218);
            this.btnLoadOrigianl.Name = "btnLoadOrigianl";
            this.btnLoadOrigianl.Size = new System.Drawing.Size(200, 23);
            this.btnLoadOrigianl.TabIndex = 1;
            this.btnLoadOrigianl.Text = "Load Image";
            this.btnLoadOrigianl.UseVisualStyleBackColor = true;
            this.btnLoadOrigianl.Click += new System.EventHandler(this.btnLoadOrigianl_Click);
            // 
            // btnCFA
            // 
            this.btnCFA.Location = new System.Drawing.Point(218, 218);
            this.btnCFA.Name = "btnCFA";
            this.btnCFA.Size = new System.Drawing.Size(200, 23);
            this.btnCFA.TabIndex = 2;
            this.btnCFA.Text = "CFA Filter";
            this.btnCFA.UseVisualStyleBackColor = true;
            this.btnCFA.Click += new System.EventHandler(this.btnCFA_Click);
            // 
            // btnBilinear
            // 
            this.btnBilinear.Location = new System.Drawing.Point(424, 218);
            this.btnBilinear.Name = "btnBilinear";
            this.btnBilinear.Size = new System.Drawing.Size(200, 23);
            this.btnBilinear.TabIndex = 3;
            this.btnBilinear.Text = "Bilinear Interpolation";
            this.btnBilinear.UseVisualStyleBackColor = true;
            this.btnBilinear.Click += new System.EventHandler(this.btnBilinear_Click);
            // 
            // picCFA
            // 
            this.picCFA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picCFA.Location = new System.Drawing.Point(218, 12);
            this.picCFA.Name = "picCFA";
            this.picCFA.Size = new System.Drawing.Size(200, 200);
            this.picCFA.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picCFA.TabIndex = 4;
            this.picCFA.TabStop = false;
            // 
            // picBilinear
            // 
            this.picBilinear.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picBilinear.Location = new System.Drawing.Point(424, 12);
            this.picBilinear.Name = "picBilinear";
            this.picBilinear.Size = new System.Drawing.Size(200, 200);
            this.picBilinear.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBilinear.TabIndex = 5;
            this.picBilinear.TabStop = false;
            // 
            // lblPSNR_BI
            // 
            this.lblPSNR_BI.Location = new System.Drawing.Point(422, 244);
            this.lblPSNR_BI.Name = "lblPSNR_BI";
            this.lblPSNR_BI.Size = new System.Drawing.Size(202, 23);
            this.lblPSNR_BI.TabIndex = 6;
            this.lblPSNR_BI.Text = "Bilinear PSNR";
            this.lblPSNR_BI.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPSNR_CFA
            // 
            this.lblPSNR_CFA.Location = new System.Drawing.Point(216, 244);
            this.lblPSNR_CFA.Name = "lblPSNR_CFA";
            this.lblPSNR_CFA.Size = new System.Drawing.Size(202, 23);
            this.lblPSNR_CFA.TabIndex = 6;
            this.lblPSNR_CFA.Text = "CFA PSNR";
            this.lblPSNR_CFA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picEPBI
            // 
            this.picEPBI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picEPBI.Location = new System.Drawing.Point(630, 12);
            this.picEPBI.Name = "picEPBI";
            this.picEPBI.Size = new System.Drawing.Size(200, 200);
            this.picEPBI.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picEPBI.TabIndex = 5;
            this.picEPBI.TabStop = false;
            // 
            // btnEPBI
            // 
            this.btnEPBI.Location = new System.Drawing.Point(631, 218);
            this.btnEPBI.Name = "btnEPBI";
            this.btnEPBI.Size = new System.Drawing.Size(200, 23);
            this.btnEPBI.TabIndex = 3;
            this.btnEPBI.Text = "EP-Bilinear Interpolation";
            this.btnEPBI.UseVisualStyleBackColor = true;
            this.btnEPBI.Click += new System.EventHandler(this.btnEPBI_Click);
            // 
            // lblPSNR_EPBI
            // 
            this.lblPSNR_EPBI.Location = new System.Drawing.Point(628, 244);
            this.lblPSNR_EPBI.Name = "lblPSNR_EPBI";
            this.lblPSNR_EPBI.Size = new System.Drawing.Size(202, 23);
            this.lblPSNR_EPBI.TabIndex = 6;
            this.lblPSNR_EPBI.Text = "EP-Bilinear PSNR";
            this.lblPSNR_EPBI.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 273);
            this.Controls.Add(this.lblPSNR_CFA);
            this.Controls.Add(this.lblPSNR_EPBI);
            this.Controls.Add(this.lblPSNR_BI);
            this.Controls.Add(this.picEPBI);
            this.Controls.Add(this.picBilinear);
            this.Controls.Add(this.picCFA);
            this.Controls.Add(this.btnEPBI);
            this.Controls.Add(this.btnBilinear);
            this.Controls.Add(this.btnCFA);
            this.Controls.Add(this.btnLoadOrigianl);
            this.Controls.Add(this.picOriginal);
            this.Name = "Form1";
            this.Text = "Image Interpolation Simulation @ NCTU Communaction Lab";
            ((System.ComponentModel.ISupportInitialize)(this.picOriginal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCFA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBilinear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEPBI)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picOriginal;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnLoadOrigianl;
        private System.Windows.Forms.Button btnCFA;
        private System.Windows.Forms.Button btnBilinear;
        private System.Windows.Forms.PictureBox picCFA;
        private System.Windows.Forms.PictureBox picBilinear;
        private System.Windows.Forms.Label lblPSNR_BI;
        private System.Windows.Forms.Label lblPSNR_CFA;
        private System.Windows.Forms.PictureBox picEPBI;
        private System.Windows.Forms.Button btnEPBI;
        private System.Windows.Forms.Label lblPSNR_EPBI;
    }
}

