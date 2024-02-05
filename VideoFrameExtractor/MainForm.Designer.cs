namespace VideoFrameExtractor
{
    partial class MainForm
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
            this.tbVideoPath = new System.Windows.Forms.TextBox();
            this.btnOpenVideo = new System.Windows.Forms.Button();
            this.lblVFP = new System.Windows.Forms.Label();
            this.lblCFP = new System.Windows.Forms.Label();
            this.btnSearchCategory = new System.Windows.Forms.Button();
            this.tbCategoryFilePath = new System.Windows.Forms.TextBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.fbdFramesCtegory = new System.Windows.Forms.FolderBrowserDialog();
            this.cbDelete = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // tbVideoPath
            // 
            this.tbVideoPath.Location = new System.Drawing.Point(79, 12);
            this.tbVideoPath.Name = "tbVideoPath";
            this.tbVideoPath.Size = new System.Drawing.Size(362, 20);
            this.tbVideoPath.TabIndex = 0;
            // 
            // btnOpenVideo
            // 
            this.btnOpenVideo.Location = new System.Drawing.Point(447, 12);
            this.btnOpenVideo.Name = "btnOpenVideo";
            this.btnOpenVideo.Size = new System.Drawing.Size(29, 23);
            this.btnOpenVideo.TabIndex = 1;
            this.btnOpenVideo.Text = "...";
            this.btnOpenVideo.UseVisualStyleBackColor = true;
            this.btnOpenVideo.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // lblVFP
            // 
            this.lblVFP.AutoSize = true;
            this.lblVFP.Location = new System.Drawing.Point(12, 15);
            this.lblVFP.Name = "lblVFP";
            this.lblVFP.Size = new System.Drawing.Size(61, 13);
            this.lblVFP.TabIndex = 2;
            this.lblVFP.Text = "Video path:";
            // 
            // lblCFP
            // 
            this.lblCFP.AutoSize = true;
            this.lblCFP.Location = new System.Drawing.Point(12, 41);
            this.lblCFP.Name = "lblCFP";
            this.lblCFP.Size = new System.Drawing.Size(88, 13);
            this.lblCFP.TabIndex = 5;
            this.lblCFP.Text = "Frames category:";
            // 
            // btnSearchCategory
            // 
            this.btnSearchCategory.Location = new System.Drawing.Point(447, 38);
            this.btnSearchCategory.Name = "btnSearchCategory";
            this.btnSearchCategory.Size = new System.Drawing.Size(29, 23);
            this.btnSearchCategory.TabIndex = 4;
            this.btnSearchCategory.Text = "...";
            this.btnSearchCategory.UseVisualStyleBackColor = true;
            this.btnSearchCategory.Click += new System.EventHandler(this.btnSearchCategory_Click);
            // 
            // tbCategoryFilePath
            // 
            this.tbCategoryFilePath.Location = new System.Drawing.Point(106, 38);
            this.tbCategoryFilePath.Name = "tbCategoryFilePath";
            this.tbCategoryFilePath.Size = new System.Drawing.Size(335, 20);
            this.tbCategoryFilePath.TabIndex = 3;
            // 
            // btnExport
            // 
            this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnExport.Location = new System.Drawing.Point(12, 87);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(461, 32);
            this.btnExport.TabIndex = 6;
            this.btnExport.Text = "Export!";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExtractFrames_Click);
            // 
            // cbDelete
            // 
            this.cbDelete.AutoSize = true;
            this.cbDelete.Location = new System.Drawing.Point(15, 64);
            this.cbDelete.Name = "cbDelete";
            this.cbDelete.Size = new System.Drawing.Size(119, 17);
            this.cbDelete.TabIndex = 7;
            this.cbDelete.Text = "Delete same frames";
            this.cbDelete.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 126);
            this.Controls.Add(this.cbDelete);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.lblCFP);
            this.Controls.Add(this.btnSearchCategory);
            this.Controls.Add(this.tbCategoryFilePath);
            this.Controls.Add(this.lblVFP);
            this.Controls.Add(this.btnOpenVideo);
            this.Controls.Add(this.tbVideoPath);
            this.Name = "MainForm";
            this.Text = "Video Frame Extractor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbVideoPath;
        private System.Windows.Forms.Button btnOpenVideo;
        private System.Windows.Forms.Label lblVFP;
        private System.Windows.Forms.Label lblCFP;
        private System.Windows.Forms.Button btnSearchCategory;
        private System.Windows.Forms.TextBox tbCategoryFilePath;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.FolderBrowserDialog fbdFramesCtegory;
        private System.Windows.Forms.CheckBox cbDelete;
    }
}

