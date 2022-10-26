
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
            this.CbAccelRestore = new System.Windows.Forms.CheckBox();
            this.ListOnConnect = new System.Windows.Forms.ListBox();
            this.ListOnDisconnect = new System.Windows.Forms.ListBox();
            this.BtnConnectAdd = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.BtnConnectDel = new System.Windows.Forms.Button();
            this.BtnConnectEdit = new System.Windows.Forms.Button();
            this.BtnDisconnectEdit = new System.Windows.Forms.Button();
            this.BtnDisconnectDel = new System.Windows.Forms.Button();
            this.BtnDisconnectadd = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.SRefresh = new System.Windows.Forms.TextBox();
            this.SHeight = new System.Windows.Forms.TextBox();
            this.SWidth = new System.Windows.Forms.TextBox();
            this.cbOverrideReturnRes = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // CheckTimer
            // 
            this.CheckTimer.Interval = 500;
            this.CheckTimer.Tick += new System.EventHandler(this.OnTick);
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
            this.HideTimer.Tick += new System.EventHandler(this.SilentLaunchAutoHide);
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
            this.useSecondScreenCB.CheckedChanged += new System.EventHandler(this.SaveSettings);
            // 
            // DWidth
            // 
            this.DWidth.Location = new System.Drawing.Point(18, 114);
            this.DWidth.Name = "DWidth";
            this.DWidth.Size = new System.Drawing.Size(100, 26);
            this.DWidth.TabIndex = 2;
            // 
            // DHeight
            // 
            this.DHeight.Location = new System.Drawing.Point(124, 114);
            this.DHeight.Name = "DHeight";
            this.DHeight.Size = new System.Drawing.Size(100, 26);
            this.DHeight.TabIndex = 3;
            // 
            // DRefresh
            // 
            this.DRefresh.Location = new System.Drawing.Point(230, 114);
            this.DRefresh.Name = "DRefresh";
            this.DRefresh.Size = new System.Drawing.Size(100, 26);
            this.DRefresh.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(253, 40);
            this.label2.TabIndex = 5;
            this.label2.Text = "Desired Width/Height/Refresh\r\n                 (only if switch is disabled)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 245);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Information";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 265);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Mode:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 285);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "State:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 305);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 20);
            this.label6.TabIndex = 9;
            this.label6.Text = "Target Params:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 325);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 20);
            this.label7.TabIndex = 10;
            this.label7.Text = "Startup Res:";
            // 
            // InfoReturnParams
            // 
            this.InfoReturnParams.AutoSize = true;
            this.InfoReturnParams.Location = new System.Drawing.Point(168, 325);
            this.InfoReturnParams.Name = "InfoReturnParams";
            this.InfoReturnParams.Size = new System.Drawing.Size(14, 20);
            this.InfoReturnParams.TabIndex = 14;
            this.InfoReturnParams.Text = "-";
            // 
            // InfoTargetParams
            // 
            this.InfoTargetParams.AutoSize = true;
            this.InfoTargetParams.Location = new System.Drawing.Point(168, 305);
            this.InfoTargetParams.Name = "InfoTargetParams";
            this.InfoTargetParams.Size = new System.Drawing.Size(14, 20);
            this.InfoTargetParams.TabIndex = 13;
            this.InfoTargetParams.Text = "-";
            // 
            // InfoState
            // 
            this.InfoState.AutoSize = true;
            this.InfoState.Location = new System.Drawing.Point(168, 285);
            this.InfoState.Name = "InfoState";
            this.InfoState.Size = new System.Drawing.Size(110, 20);
            this.InfoState.TabIndex = 12;
            this.InfoState.Text = "Stream ended";
            // 
            // InfoMode
            // 
            this.InfoMode.AutoSize = true;
            this.InfoMode.Location = new System.Drawing.Point(168, 265);
            this.InfoMode.Name = "InfoMode";
            this.InfoMode.Size = new System.Drawing.Size(14, 20);
            this.InfoMode.TabIndex = 11;
            this.InfoMode.Text = "-";
            // 
            // Log
            // 
            this.Log.FormattingEnabled = true;
            this.Log.ItemHeight = 20;
            this.Log.Location = new System.Drawing.Point(18, 366);
            this.Log.Name = "Log";
            this.Log.Size = new System.Drawing.Size(686, 204);
            this.Log.TabIndex = 15;
            // 
            // CbAccelRestore
            // 
            this.CbAccelRestore.AutoSize = true;
            this.CbAccelRestore.Location = new System.Drawing.Point(381, 28);
            this.CbAccelRestore.Name = "CbAccelRestore";
            this.CbAccelRestore.Size = new System.Drawing.Size(234, 44);
            this.CbAccelRestore.TabIndex = 23;
            this.CbAccelRestore.Text = "Restore mouse acceleration\r\nprecision after stream end";
            this.CbAccelRestore.UseVisualStyleBackColor = true;
            this.CbAccelRestore.Visible = false;
            this.CbAccelRestore.CheckedChanged += new System.EventHandler(this.SaveSettings);
            // 
            // ListOnConnect
            // 
            this.ListOnConnect.FormattingEnabled = true;
            this.ListOnConnect.ItemHeight = 20;
            this.ListOnConnect.Location = new System.Drawing.Point(379, 98);
            this.ListOnConnect.Name = "ListOnConnect";
            this.ListOnConnect.Size = new System.Drawing.Size(234, 104);
            this.ListOnConnect.TabIndex = 25;
            // 
            // ListOnDisconnect
            // 
            this.ListOnDisconnect.FormattingEnabled = true;
            this.ListOnDisconnect.ItemHeight = 20;
            this.ListOnDisconnect.Location = new System.Drawing.Point(379, 235);
            this.ListOnDisconnect.Name = "ListOnDisconnect";
            this.ListOnDisconnect.Size = new System.Drawing.Size(234, 104);
            this.ListOnDisconnect.TabIndex = 26;
            // 
            // BtnConnectAdd
            // 
            this.BtnConnectAdd.Location = new System.Drawing.Point(619, 98);
            this.BtnConnectAdd.Name = "BtnConnectAdd";
            this.BtnConnectAdd.Size = new System.Drawing.Size(85, 29);
            this.BtnConnectAdd.TabIndex = 27;
            this.BtnConnectAdd.Text = "Add";
            this.BtnConnectAdd.UseVisualStyleBackColor = true;
            this.BtnConnectAdd.Click += new System.EventHandler(this.ConnectItemAdd);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(377, 75);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(140, 20);
            this.label9.TabIndex = 28;
            this.label9.Text = "Action on Connect";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(378, 212);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(160, 20);
            this.label10.TabIndex = 29;
            this.label10.Text = "Action on Disconnect";
            // 
            // BtnConnectDel
            // 
            this.BtnConnectDel.Location = new System.Drawing.Point(619, 133);
            this.BtnConnectDel.Name = "BtnConnectDel";
            this.BtnConnectDel.Size = new System.Drawing.Size(85, 29);
            this.BtnConnectDel.TabIndex = 30;
            this.BtnConnectDel.Text = "Remove";
            this.BtnConnectDel.UseVisualStyleBackColor = true;
            this.BtnConnectDel.Click += new System.EventHandler(this.ConnectItemDel);
            // 
            // BtnConnectEdit
            // 
            this.BtnConnectEdit.Location = new System.Drawing.Point(619, 168);
            this.BtnConnectEdit.Name = "BtnConnectEdit";
            this.BtnConnectEdit.Size = new System.Drawing.Size(85, 29);
            this.BtnConnectEdit.TabIndex = 31;
            this.BtnConnectEdit.Text = "Edit";
            this.BtnConnectEdit.UseVisualStyleBackColor = true;
            this.BtnConnectEdit.Click += new System.EventHandler(this.ConnectItemEdit);
            // 
            // BtnDisconnectEdit
            // 
            this.BtnDisconnectEdit.Location = new System.Drawing.Point(619, 305);
            this.BtnDisconnectEdit.Name = "BtnDisconnectEdit";
            this.BtnDisconnectEdit.Size = new System.Drawing.Size(85, 29);
            this.BtnDisconnectEdit.TabIndex = 34;
            this.BtnDisconnectEdit.Text = "Edit";
            this.BtnDisconnectEdit.UseVisualStyleBackColor = true;
            this.BtnDisconnectEdit.Click += new System.EventHandler(this.DisconnectItemEdit);
            // 
            // BtnDisconnectDel
            // 
            this.BtnDisconnectDel.Location = new System.Drawing.Point(619, 270);
            this.BtnDisconnectDel.Name = "BtnDisconnectDel";
            this.BtnDisconnectDel.Size = new System.Drawing.Size(85, 29);
            this.BtnDisconnectDel.TabIndex = 33;
            this.BtnDisconnectDel.Text = "Remove";
            this.BtnDisconnectDel.UseVisualStyleBackColor = true;
            this.BtnDisconnectDel.Click += new System.EventHandler(this.DisconnectItemDel);
            // 
            // BtnDisconnectadd
            // 
            this.BtnDisconnectadd.Location = new System.Drawing.Point(619, 235);
            this.BtnDisconnectadd.Name = "BtnDisconnectadd";
            this.BtnDisconnectadd.Size = new System.Drawing.Size(85, 29);
            this.BtnDisconnectadd.TabIndex = 32;
            this.BtnDisconnectadd.Text = "Add";
            this.BtnDisconnectadd.UseVisualStyleBackColor = true;
            this.BtnDisconnectadd.Click += new System.EventHandler(this.DisconnectItemAdd);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 192);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(253, 20);
            this.label8.TabIndex = 38;
            this.label8.Text = "                 (only if switch is disabled)";
            // 
            // SRefresh
            // 
            this.SRefresh.Location = new System.Drawing.Point(230, 215);
            this.SRefresh.Name = "SRefresh";
            this.SRefresh.Size = new System.Drawing.Size(100, 26);
            this.SRefresh.TabIndex = 37;
            // 
            // SHeight
            // 
            this.SHeight.Location = new System.Drawing.Point(124, 215);
            this.SHeight.Name = "SHeight";
            this.SHeight.Size = new System.Drawing.Size(100, 26);
            this.SHeight.TabIndex = 36;
            // 
            // SWidth
            // 
            this.SWidth.Location = new System.Drawing.Point(18, 215);
            this.SWidth.Name = "SWidth";
            this.SWidth.Size = new System.Drawing.Size(100, 26);
            this.SWidth.TabIndex = 35;
            // 
            // cbOverrideReturnRes
            // 
            this.cbOverrideReturnRes.AutoSize = true;
            this.cbOverrideReturnRes.Location = new System.Drawing.Point(18, 168);
            this.cbOverrideReturnRes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbOverrideReturnRes.Name = "cbOverrideReturnRes";
            this.cbOverrideReturnRes.Size = new System.Drawing.Size(280, 24);
            this.cbOverrideReturnRes.TabIndex = 39;
            this.cbOverrideReturnRes.Text = "Override detected return resolution";
            this.cbOverrideReturnRes.UseVisualStyleBackColor = true;
            this.cbOverrideReturnRes.CheckedChanged += new System.EventHandler(this.OnOverrideReturnChange);
            // 
            // NVStreamerMainUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 594);
            this.Controls.Add(this.cbOverrideReturnRes);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.SRefresh);
            this.Controls.Add(this.SHeight);
            this.Controls.Add(this.SWidth);
            this.Controls.Add(this.BtnDisconnectEdit);
            this.Controls.Add(this.BtnDisconnectDel);
            this.Controls.Add(this.BtnDisconnectadd);
            this.Controls.Add(this.BtnConnectEdit);
            this.Controls.Add(this.BtnConnectDel);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.BtnConnectAdd);
            this.Controls.Add(this.ListOnDisconnect);
            this.Controls.Add(this.ListOnConnect);
            this.Controls.Add(this.CbAccelRestore);
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
        private System.Windows.Forms.CheckBox CbAccelRestore;
        private System.Windows.Forms.ListBox ListOnConnect;
        private System.Windows.Forms.ListBox ListOnDisconnect;
        private System.Windows.Forms.Button BtnConnectAdd;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button BtnConnectDel;
        private System.Windows.Forms.Button BtnConnectEdit;
        private System.Windows.Forms.Button BtnDisconnectEdit;
        private System.Windows.Forms.Button BtnDisconnectDel;
        private System.Windows.Forms.Button BtnDisconnectadd;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox SRefresh;
        private System.Windows.Forms.TextBox SHeight;
        private System.Windows.Forms.TextBox SWidth;
        private System.Windows.Forms.CheckBox cbOverrideReturnRes;
    }
}

