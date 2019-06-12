namespace Lience_Plates_Recognition.UI
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblImagePath = new System.Windows.Forms.Label();
            this.lblORCPatch = new System.Windows.Forms.Label();
            this.cmdImage = new System.Windows.Forms.Button();
            this.cmdORC = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmdLoad = new System.Windows.Forms.Button();
            this.picSource = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cmdTest = new System.Windows.Forms.Button();
            this.cmdStop = new System.Windows.Forms.Button();
            this.cmdAnalyse = new System.Windows.Forms.Button();
            this.prgMain = new System.Windows.Forms.ProgressBar();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.lstResult = new System.Windows.Forms.ListBox();
            this.tmAnalyse = new System.Windows.Forms.Timer(this.components);
            this.txtPicPath = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSource)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblImagePath);
            this.groupBox1.Controls.Add(this.lblORCPatch);
            this.groupBox1.Controls.Add(this.cmdImage);
            this.groupBox1.Controls.Add(this.cmdORC);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(718, 103);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Library Setting";
            // 
            // lblImagePath
            // 
            this.lblImagePath.AutoSize = true;
            this.lblImagePath.Location = new System.Drawing.Point(111, 67);
            this.lblImagePath.Name = "lblImagePath";
            this.lblImagePath.Size = new System.Drawing.Size(0, 13);
            this.lblImagePath.TabIndex = 5;
            // 
            // lblORCPatch
            // 
            this.lblORCPatch.AutoSize = true;
            this.lblORCPatch.Location = new System.Drawing.Point(111, 31);
            this.lblORCPatch.Name = "lblORCPatch";
            this.lblORCPatch.Size = new System.Drawing.Size(0, 13);
            this.lblORCPatch.TabIndex = 4;
            // 
            // cmdImage
            // 
            this.cmdImage.Location = new System.Drawing.Point(622, 67);
            this.cmdImage.Name = "cmdImage";
            this.cmdImage.Size = new System.Drawing.Size(75, 23);
            this.cmdImage.TabIndex = 3;
            this.cmdImage.Text = "Select";
            this.cmdImage.UseVisualStyleBackColor = true;
            this.cmdImage.Click += new System.EventHandler(this.cmdImage_Click);
            // 
            // cmdORC
            // 
            this.cmdORC.Location = new System.Drawing.Point(622, 26);
            this.cmdORC.Name = "cmdORC";
            this.cmdORC.Size = new System.Drawing.Size(75, 23);
            this.cmdORC.TabIndex = 2;
            this.cmdORC.Text = "Select";
            this.cmdORC.UseVisualStyleBackColor = true;
            this.cmdORC.Click += new System.EventHandler(this.cmdORC_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "ImageMagick";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tesseract-OCR:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtPicPath);
            this.groupBox2.Controls.Add(this.cmdLoad);
            this.groupBox2.Controls.Add(this.picSource);
            this.groupBox2.Location = new System.Drawing.Point(12, 121);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(477, 332);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Picture";
            // 
            // cmdLoad
            // 
            this.cmdLoad.Location = new System.Drawing.Point(385, 294);
            this.cmdLoad.Name = "cmdLoad";
            this.cmdLoad.Size = new System.Drawing.Size(86, 23);
            this.cmdLoad.TabIndex = 1;
            this.cmdLoad.Text = "&Load Picture";
            this.cmdLoad.UseVisualStyleBackColor = true;
            this.cmdLoad.Click += new System.EventHandler(this.cmdLoad_Click);
            // 
            // picSource
            // 
            this.picSource.Location = new System.Drawing.Point(6, 19);
            this.picSource.Name = "picSource";
            this.picSource.Size = new System.Drawing.Size(465, 269);
            this.picSource.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picSource.TabIndex = 0;
            this.picSource.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cmdTest);
            this.groupBox3.Controls.Add(this.cmdStop);
            this.groupBox3.Controls.Add(this.cmdAnalyse);
            this.groupBox3.Controls.Add(this.prgMain);
            this.groupBox3.Controls.Add(this.txtResult);
            this.groupBox3.Controls.Add(this.lstResult);
            this.groupBox3.Location = new System.Drawing.Point(495, 121);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(235, 332);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Process";
            // 
            // cmdTest
            // 
            this.cmdTest.Location = new System.Drawing.Point(118, 294);
            this.cmdTest.Name = "cmdTest";
            this.cmdTest.Size = new System.Drawing.Size(105, 23);
            this.cmdTest.TabIndex = 5;
            this.cmdTest.Text = "For test";
            this.cmdTest.UseVisualStyleBackColor = true;
            this.cmdTest.Click += new System.EventHandler(this.cmdTest_Click);
            // 
            // cmdStop
            // 
            this.cmdStop.Location = new System.Drawing.Point(118, 294);
            this.cmdStop.Name = "cmdStop";
            this.cmdStop.Size = new System.Drawing.Size(105, 22);
            this.cmdStop.TabIndex = 4;
            this.cmdStop.Text = "Stop &Analyse";
            this.cmdStop.UseVisualStyleBackColor = true;
            this.cmdStop.Visible = false;
            this.cmdStop.Click += new System.EventHandler(this.cmdStop_Click);
            // 
            // cmdAnalyse
            // 
            this.cmdAnalyse.Location = new System.Drawing.Point(7, 294);
            this.cmdAnalyse.Name = "cmdAnalyse";
            this.cmdAnalyse.Size = new System.Drawing.Size(105, 22);
            this.cmdAnalyse.TabIndex = 3;
            this.cmdAnalyse.Text = "&Start Analyse";
            this.cmdAnalyse.UseVisualStyleBackColor = true;
            this.cmdAnalyse.Click += new System.EventHandler(this.cmdAnalyse_Click);
            // 
            // prgMain
            // 
            this.prgMain.Location = new System.Drawing.Point(7, 212);
            this.prgMain.Name = "prgMain";
            this.prgMain.Size = new System.Drawing.Size(222, 21);
            this.prgMain.TabIndex = 2;
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(7, 239);
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(222, 20);
            this.txtResult.TabIndex = 1;
            // 
            // lstResult
            // 
            this.lstResult.Enabled = false;
            this.lstResult.FormattingEnabled = true;
            this.lstResult.Location = new System.Drawing.Point(7, 20);
            this.lstResult.Name = "lstResult";
            this.lstResult.Size = new System.Drawing.Size(222, 186);
            this.lstResult.TabIndex = 0;
            // 
            // tmAnalyse
            // 
            this.tmAnalyse.Interval = 3000;
            this.tmAnalyse.Tick += new System.EventHandler(this.tmAnalyse_Tick);
            // 
            // txtPicPath
            // 
            this.txtPicPath.AutoSize = true;
            this.txtPicPath.Location = new System.Drawing.Point(6, 299);
            this.txtPicPath.Name = "txtPicPath";
            this.txtPicPath.Size = new System.Drawing.Size(0, 13);
            this.txtPicPath.TabIndex = 2;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 462);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lience Plates Recognition";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSource)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button cmdImage;
        private System.Windows.Forms.Button cmdORC;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox picSource;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ProgressBar prgMain;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.ListBox lstResult;
        private System.Windows.Forms.Label lblImagePath;
        private System.Windows.Forms.Label lblORCPatch;
        private System.Windows.Forms.Button cmdAnalyse;
        private System.Windows.Forms.Timer tmAnalyse;
        private System.Windows.Forms.Button cmdStop;
        private System.Windows.Forms.Button cmdTest;
        private System.Windows.Forms.Button cmdLoad;
        private System.Windows.Forms.Label txtPicPath;
    }
}