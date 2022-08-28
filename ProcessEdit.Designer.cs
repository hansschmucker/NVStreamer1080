namespace NVStreamer1080 {
    partial class ProcessEdit {
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
            this.ProcName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnConfirm = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Processes = new System.Windows.Forms.ListBox();
            this.RefreshProcs = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ProcName
            // 
            this.ProcName.Location = new System.Drawing.Point(12, 32);
            this.ProcName.Name = "ProcName";
            this.ProcName.Size = new System.Drawing.Size(391, 26);
            this.ProcName.TabIndex = 0;
            this.ProcName.TextChanged += new System.EventHandler(this.ProcName_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Process Name";
            // 
            // BtnConfirm
            // 
            this.BtnConfirm.Location = new System.Drawing.Point(314, 188);
            this.BtnConfirm.Name = "BtnConfirm";
            this.BtnConfirm.Size = new System.Drawing.Size(89, 29);
            this.BtnConfirm.TabIndex = 3;
            this.BtnConfirm.Text = "OK";
            this.BtnConfirm.UseVisualStyleBackColor = true;
            this.BtnConfirm.Click += new System.EventHandler(this.BtnConfirm_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(420, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(324, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Current Processes (double click to set name)";
            // 
            // Processes
            // 
            this.Processes.FormattingEnabled = true;
            this.Processes.ItemHeight = 20;
            this.Processes.Location = new System.Drawing.Point(424, 48);
            this.Processes.Name = "Processes";
            this.Processes.Size = new System.Drawing.Size(446, 124);
            this.Processes.TabIndex = 5;
            this.Processes.DoubleClick += new System.EventHandler(this.Processes_DoubleClick);
            // 
            // RefreshProcs
            // 
            this.RefreshProcs.Location = new System.Drawing.Point(779, 13);
            this.RefreshProcs.Name = "RefreshProcs";
            this.RefreshProcs.Size = new System.Drawing.Size(91, 29);
            this.RefreshProcs.TabIndex = 6;
            this.RefreshProcs.Text = "Refresh";
            this.RefreshProcs.UseVisualStyleBackColor = true;
            this.RefreshProcs.Click += new System.EventHandler(this.RefreshProcs_Click);
            // 
            // ProcessEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 229);
            this.Controls.Add(this.RefreshProcs);
            this.Controls.Add(this.Processes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BtnConfirm);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ProcName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ProcessEdit";
            this.Text = "Process";
            this.Load += new System.EventHandler(this.ProcessEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ProcName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnConfirm;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox Processes;
        private System.Windows.Forms.Button RefreshProcs;
    }
}