
namespace NVStreamer1080
{
    partial class NVStreamerMainUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;



        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.CheckTimer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.HideTimer = new System.Windows.Forms.Timer(this.components);
            this.useSecondScreenCB = new System.Windows.Forms.CheckBox();
            this.DWidth = new System.Windows.Forms.TextBox();
            this.DHeight = new System.Windows.Forms.TextBox();
            this.DRefresh = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CheckTimer
            // 
            this.CheckTimer.Interval = 500;
            this.CheckTimer.Tick += new System.EventHandler(this.CheckTimer_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "NVStreamer not active";
            // 
            // HideTimer
            // 
            this.HideTimer.Enabled = true;
            this.HideTimer.Interval = 3000;
            this.HideTimer.Tick += new System.EventHandler(this.HideTimer_Tick);
            // 
            // useSecondScreenCB
            // 
            this.useSecondScreenCB.AutoSize = true;
            this.useSecondScreenCB.Location = new System.Drawing.Point(18, 38);
            this.useSecondScreenCB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.useSecondScreenCB.Name = "useSecondScreenCB";
            this.useSecondScreenCB.Size = new System.Drawing.Size(321, 24);
            this.useSecondScreenCB.TabIndex = 1;
            this.useSecondScreenCB.Text = "Switch to second screen while streaming";
            this.useSecondScreenCB.UseVisualStyleBackColor = true;
            this.useSecondScreenCB.CheckedChanged += new System.EventHandler(this.OnSecondScreenCheckboxChange);
            // 
            // Width
            // 
            this.DWidth.Location = new System.Drawing.Point(18, 140);
            this.DWidth.Name = "Width";
            this.DWidth.Size = new System.Drawing.Size(100, 26);
            this.DWidth.TabIndex = 2;
            this.DWidth.TextChanged += new System.EventHandler(this.Width_TextChanged);
            // 
            // Height
            // 
            this.DHeight.Location = new System.Drawing.Point(124, 140);
            this.DHeight.Name = "Height";
            this.DHeight.Size = new System.Drawing.Size(100, 26);
            this.DHeight.TabIndex = 3;
            this.DHeight.TextChanged += new System.EventHandler(this.Width_TextChanged);
            // 
            // Refresh
            // 
            this.DRefresh.Location = new System.Drawing.Point(230, 140);
            this.DRefresh.Name = "Refresh";
            this.DRefresh.Size = new System.Drawing.Size(100, 26);
            this.DRefresh.TabIndex = 4;
            this.DRefresh.TextChanged += new System.EventHandler(this.Width_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(253, 40);
            this.label2.TabIndex = 5;
            this.label2.Text = "Desired Width/Height/Refresh\r\n                 (only if switch is disabled)";
            // 
            // NVStreamerMainUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 178);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DRefresh);
            this.Controls.Add(this.DHeight);
            this.Controls.Add(this.DWidth);
            this.Controls.Add(this.useSecondScreenCB);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "NVStreamerMainUI";
            this.Text = "NVStreamer Res Utility";
            this.Load += new System.EventHandler(this.NVStreamerMainUI_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer CheckTimer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer HideTimer;
        private System.Windows.Forms.CheckBox useSecondScreenCB;
        private System.Windows.Forms.TextBox DWidth;
        private System.Windows.Forms.TextBox DHeight;
        private System.Windows.Forms.TextBox DRefresh;
        private System.Windows.Forms.Label label2;
    }
}

