namespace NVStreamer1080 {
    partial class ApplicationEdit {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.AppPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BrowseExe = new System.Windows.Forms.OpenFileDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.AppDir = new System.Windows.Forms.TextBox();
            this.AppBrowse = new System.Windows.Forms.Button();
            this.BtnConfirm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AppPath
            // 
            this.AppPath.Location = new System.Drawing.Point(167, 9);
            this.AppPath.Name = "AppPath";
            this.AppPath.Size = new System.Drawing.Size(420, 26);
            this.AppPath.TabIndex = 0;
            this.AppPath.TextChanged += new System.EventHandler(this.AppPath_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Path";
            // 
            // BrowseExe
            // 
            this.BrowseExe.FileName = "*.exe";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Working Directory";
            // 
            // AppDir
            // 
            this.AppDir.Location = new System.Drawing.Point(167, 53);
            this.AppDir.Name = "AppDir";
            this.AppDir.Size = new System.Drawing.Size(502, 26);
            this.AppDir.TabIndex = 3;
            this.AppDir.TextChanged += new System.EventHandler(this.AppPath_TextChanged);
            // 
            // AppBrowse
            // 
            this.AppBrowse.Location = new System.Drawing.Point(593, 9);
            this.AppBrowse.Name = "AppBrowse";
            this.AppBrowse.Size = new System.Drawing.Size(75, 26);
            this.AppBrowse.TabIndex = 4;
            this.AppBrowse.Text = "Browse";
            this.AppBrowse.UseVisualStyleBackColor = true;
            this.AppBrowse.Click += new System.EventHandler(this.OnBrowse);
            // 
            // BtnConfirm
            // 
            this.BtnConfirm.Location = new System.Drawing.Point(579, 103);
            this.BtnConfirm.Name = "BtnConfirm";
            this.BtnConfirm.Size = new System.Drawing.Size(89, 29);
            this.BtnConfirm.TabIndex = 5;
            this.BtnConfirm.Text = "OK";
            this.BtnConfirm.UseVisualStyleBackColor = true;
            this.BtnConfirm.Click += new System.EventHandler(this.BtnConfirm_Click);
            // 
            // ApplicationEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 150);
            this.Controls.Add(this.BtnConfirm);
            this.Controls.Add(this.AppBrowse);
            this.Controls.Add(this.AppDir);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AppPath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ApplicationEdit";
            this.Text = "Application";
            this.Load += new System.EventHandler(this.ApplicationEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox AppPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog BrowseExe;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox AppDir;
        private System.Windows.Forms.Button AppBrowse;
        private System.Windows.Forms.Button BtnConfirm;
    }
}