
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.InfoReturnParams = new System.Windows.Forms.Label();
            this.InfoTargetParams = new System.Windows.Forms.Label();
            this.InfoState = new System.Windows.Forms.Label();
            this.InfoMode = new System.Windows.Forms.Label();
            this.Log = new System.Windows.Forms.ListBox();
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
            // DWidth
            // 
            this.DWidth.Location = new System.Drawing.Point(18, 140);
            this.DWidth.Name = "DWidth";
            this.DWidth.Size = new System.Drawing.Size(100, 26);
            this.DWidth.TabIndex = 2;
            // 
            // DHeight
            // 
            this.DHeight.Location = new System.Drawing.Point(124, 140);
            this.DHeight.Name = "DHeight";
            this.DHeight.Size = new System.Drawing.Size(100, 26);
            this.DHeight.TabIndex = 3;

            // 
            // DRefresh
            // 
            this.DRefresh.Location = new System.Drawing.Point(230, 140);
            this.DRefresh.Name = "DRefresh";
            this.DRefresh.Size = new System.Drawing.Size(100, 26);
            this.DRefresh.TabIndex = 4;
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 188);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Information";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 208);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Mode:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 228);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "State:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 248);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 20);
            this.label6.TabIndex = 9;
            this.label6.Text = "Target Params:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 268);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 20);
            this.label7.TabIndex = 10;
            this.label7.Text = "Return Params:";
            // 
            // InfoReturnParams
            // 
            this.InfoReturnParams.AutoSize = true;
            this.InfoReturnParams.Location = new System.Drawing.Point(168, 268);
            this.InfoReturnParams.Name = "InfoReturnParams";
            this.InfoReturnParams.Size = new System.Drawing.Size(14, 20);
            this.InfoReturnParams.TabIndex = 14;
            this.InfoReturnParams.Text = "-";
            // 
            // InfoTargetParams
            // 
            this.InfoTargetParams.AutoSize = true;
            this.InfoTargetParams.Location = new System.Drawing.Point(168, 248);
            this.InfoTargetParams.Name = "InfoTargetParams";
            this.InfoTargetParams.Size = new System.Drawing.Size(14, 20);
            this.InfoTargetParams.TabIndex = 13;
            this.InfoTargetParams.Text = "-";
            // 
            // InfoState
            // 
            this.InfoState.AutoSize = true;
            this.InfoState.Location = new System.Drawing.Point(168, 228);
            this.InfoState.Name = "InfoState";
            this.InfoState.Size = new System.Drawing.Size(110, 20);
            this.InfoState.TabIndex = 12;
            this.InfoState.Text = "Stream ended";
            // 
            // InfoMode
            // 
            this.InfoMode.AutoSize = true;
            this.InfoMode.Location = new System.Drawing.Point(168, 208);
            this.InfoMode.Name = "InfoMode";
            this.InfoMode.Size = new System.Drawing.Size(14, 20);
            this.InfoMode.TabIndex = 11;
            this.InfoMode.Text = "-";
            // 
            // Log
            // 
            this.Log.FormattingEnabled = true;
            this.Log.ItemHeight = 20;
            this.Log.Location = new System.Drawing.Point(18, 313);
            this.Log.Name = "Log";
            this.Log.Size = new System.Drawing.Size(312, 264);
            this.Log.TabIndex = 15;
            // 
            // NVStreamerMainUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 594);
            this.Controls.Add(this.Log);
            this.Controls.Add(this.InfoReturnParams);
            this.Controls.Add(this.InfoTargetParams);
            this.Controls.Add(this.InfoState);
            this.Controls.Add(this.InfoMode);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label InfoReturnParams;
        private System.Windows.Forms.Label InfoTargetParams;
        private System.Windows.Forms.Label InfoState;
        private System.Windows.Forms.Label InfoMode;
        private System.Windows.Forms.ListBox Log;
    }
}

