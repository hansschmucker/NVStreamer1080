namespace NVStreamer1080 {
    partial class CaptureWindow {
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
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(59, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1137, 164);
            this.label1.TabIndex = 0;
            this.label1.Text = "Actions Pending.\r\nMove mouse or press key to abort.";
            // 
            // CaptureWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1335, 583);
            this.Controls.Add(this.label1);
            this.MinimizeBox = false;
            this.Name = "CaptureWindow";
            this.Text = "Awaiting input";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CaptureWindow_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CaptureWindow_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CaptureWindow_MouseMove);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CaptureWindow_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
    }
}