
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
            this.InSunshinePath = new System.Windows.Forms.TextBox();
            this.BtnSunshineBrowse = new System.Windows.Forms.Button();
            this.SunshineInfo = new System.Windows.Forms.Label();
            this.BrowseSunshinePath = new System.Windows.Forms.OpenFileDialog();
            this.monitorSelectionList = new System.Windows.Forms.ListBox();
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
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "NVStreamer not active";
            // 
            // HideTimer
            // 
            this.HideTimer.Enabled = true;
            this.HideTimer.Interval = 3000;
            this.HideTimer.Tick += new System.EventHandler(this.SilentLaunchAutoHide);
            // 
            // DWidth
            // 
            this.DWidth.Location = new System.Drawing.Point(15, 154);
            this.DWidth.Margin = new System.Windows.Forms.Padding(2);
            this.DWidth.Name = "DWidth";
            this.DWidth.Size = new System.Drawing.Size(68, 20);
            this.DWidth.TabIndex = 2;
            // 
            // DHeight
            // 
            this.DHeight.Location = new System.Drawing.Point(86, 154);
            this.DHeight.Margin = new System.Windows.Forms.Padding(2);
            this.DHeight.Name = "DHeight";
            this.DHeight.Size = new System.Drawing.Size(68, 20);
            this.DHeight.TabIndex = 3;
            // 
            // DRefresh
            // 
            this.DRefresh.Location = new System.Drawing.Point(156, 154);
            this.DRefresh.Margin = new System.Windows.Forms.Padding(2);
            this.DRefresh.Name = "DRefresh";
            this.DRefresh.Size = new System.Drawing.Size(68, 20);
            this.DRefresh.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 125);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 26);
            this.label2.TabIndex = 5;
            this.label2.Text = "Desired Width/Height/Refresh\r\n                 (only if switch is disabled)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 231);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Information";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 244);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Mode:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 257);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "State:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 270);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Target Params:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 283);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Startup Res:";
            // 
            // InfoReturnParams
            // 
            this.InfoReturnParams.AutoSize = true;
            this.InfoReturnParams.Location = new System.Drawing.Point(121, 283);
            this.InfoReturnParams.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.InfoReturnParams.Name = "InfoReturnParams";
            this.InfoReturnParams.Size = new System.Drawing.Size(10, 13);
            this.InfoReturnParams.TabIndex = 14;
            this.InfoReturnParams.Text = "-";
            // 
            // InfoTargetParams
            // 
            this.InfoTargetParams.AutoSize = true;
            this.InfoTargetParams.Location = new System.Drawing.Point(121, 270);
            this.InfoTargetParams.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.InfoTargetParams.Name = "InfoTargetParams";
            this.InfoTargetParams.Size = new System.Drawing.Size(10, 13);
            this.InfoTargetParams.TabIndex = 13;
            this.InfoTargetParams.Text = "-";
            // 
            // InfoState
            // 
            this.InfoState.AutoSize = true;
            this.InfoState.Location = new System.Drawing.Point(121, 257);
            this.InfoState.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.InfoState.Name = "InfoState";
            this.InfoState.Size = new System.Drawing.Size(73, 13);
            this.InfoState.TabIndex = 12;
            this.InfoState.Text = "Stream ended";
            // 
            // InfoMode
            // 
            this.InfoMode.AutoSize = true;
            this.InfoMode.Location = new System.Drawing.Point(121, 244);
            this.InfoMode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.InfoMode.Name = "InfoMode";
            this.InfoMode.Size = new System.Drawing.Size(10, 13);
            this.InfoMode.TabIndex = 11;
            this.InfoMode.Text = "-";
            // 
            // Log
            // 
            this.Log.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Log.FormattingEnabled = true;
            this.Log.Location = new System.Drawing.Point(12, 350);
            this.Log.Margin = new System.Windows.Forms.Padding(2);
            this.Log.Name = "Log";
            this.Log.Size = new System.Drawing.Size(468, 147);
            this.Log.TabIndex = 15;
            // 
            // CbAccelRestore
            // 
            this.CbAccelRestore.AutoSize = true;
            this.CbAccelRestore.Location = new System.Drawing.Point(254, 18);
            this.CbAccelRestore.Margin = new System.Windows.Forms.Padding(2);
            this.CbAccelRestore.Name = "CbAccelRestore";
            this.CbAccelRestore.Size = new System.Drawing.Size(158, 30);
            this.CbAccelRestore.TabIndex = 23;
            this.CbAccelRestore.Text = "Restore mouse acceleration\r\nprecision after stream end";
            this.CbAccelRestore.UseVisualStyleBackColor = true;
            this.CbAccelRestore.Visible = false;
            this.CbAccelRestore.CheckedChanged += new System.EventHandler(this.SaveSettings);
            // 
            // ListOnConnect
            // 
            this.ListOnConnect.FormattingEnabled = true;
            this.ListOnConnect.Location = new System.Drawing.Point(253, 64);
            this.ListOnConnect.Margin = new System.Windows.Forms.Padding(2);
            this.ListOnConnect.Name = "ListOnConnect";
            this.ListOnConnect.Size = new System.Drawing.Size(157, 69);
            this.ListOnConnect.TabIndex = 25;
            // 
            // ListOnDisconnect
            // 
            this.ListOnDisconnect.FormattingEnabled = true;
            this.ListOnDisconnect.Location = new System.Drawing.Point(253, 153);
            this.ListOnDisconnect.Margin = new System.Windows.Forms.Padding(2);
            this.ListOnDisconnect.Name = "ListOnDisconnect";
            this.ListOnDisconnect.Size = new System.Drawing.Size(157, 69);
            this.ListOnDisconnect.TabIndex = 26;
            // 
            // BtnConnectAdd
            // 
            this.BtnConnectAdd.Location = new System.Drawing.Point(413, 64);
            this.BtnConnectAdd.Margin = new System.Windows.Forms.Padding(2);
            this.BtnConnectAdd.Name = "BtnConnectAdd";
            this.BtnConnectAdd.Size = new System.Drawing.Size(57, 19);
            this.BtnConnectAdd.TabIndex = 27;
            this.BtnConnectAdd.Text = "Add";
            this.BtnConnectAdd.UseVisualStyleBackColor = true;
            this.BtnConnectAdd.Click += new System.EventHandler(this.ConnectItemAdd);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(251, 49);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(95, 13);
            this.label9.TabIndex = 28;
            this.label9.Text = "Action on Connect";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(252, 138);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(109, 13);
            this.label10.TabIndex = 29;
            this.label10.Text = "Action on Disconnect";
            // 
            // BtnConnectDel
            // 
            this.BtnConnectDel.Location = new System.Drawing.Point(413, 86);
            this.BtnConnectDel.Margin = new System.Windows.Forms.Padding(2);
            this.BtnConnectDel.Name = "BtnConnectDel";
            this.BtnConnectDel.Size = new System.Drawing.Size(57, 19);
            this.BtnConnectDel.TabIndex = 30;
            this.BtnConnectDel.Text = "Remove";
            this.BtnConnectDel.UseVisualStyleBackColor = true;
            this.BtnConnectDel.Click += new System.EventHandler(this.ConnectItemDel);
            // 
            // BtnConnectEdit
            // 
            this.BtnConnectEdit.Location = new System.Drawing.Point(413, 109);
            this.BtnConnectEdit.Margin = new System.Windows.Forms.Padding(2);
            this.BtnConnectEdit.Name = "BtnConnectEdit";
            this.BtnConnectEdit.Size = new System.Drawing.Size(57, 19);
            this.BtnConnectEdit.TabIndex = 31;
            this.BtnConnectEdit.Text = "Edit";
            this.BtnConnectEdit.UseVisualStyleBackColor = true;
            this.BtnConnectEdit.Click += new System.EventHandler(this.ConnectItemEdit);
            // 
            // BtnDisconnectEdit
            // 
            this.BtnDisconnectEdit.Location = new System.Drawing.Point(413, 198);
            this.BtnDisconnectEdit.Margin = new System.Windows.Forms.Padding(2);
            this.BtnDisconnectEdit.Name = "BtnDisconnectEdit";
            this.BtnDisconnectEdit.Size = new System.Drawing.Size(57, 19);
            this.BtnDisconnectEdit.TabIndex = 34;
            this.BtnDisconnectEdit.Text = "Edit";
            this.BtnDisconnectEdit.UseVisualStyleBackColor = true;
            this.BtnDisconnectEdit.Click += new System.EventHandler(this.DisconnectItemEdit);
            // 
            // BtnDisconnectDel
            // 
            this.BtnDisconnectDel.Location = new System.Drawing.Point(413, 176);
            this.BtnDisconnectDel.Margin = new System.Windows.Forms.Padding(2);
            this.BtnDisconnectDel.Name = "BtnDisconnectDel";
            this.BtnDisconnectDel.Size = new System.Drawing.Size(57, 19);
            this.BtnDisconnectDel.TabIndex = 33;
            this.BtnDisconnectDel.Text = "Remove";
            this.BtnDisconnectDel.UseVisualStyleBackColor = true;
            this.BtnDisconnectDel.Click += new System.EventHandler(this.DisconnectItemDel);
            // 
            // BtnDisconnectadd
            // 
            this.BtnDisconnectadd.Location = new System.Drawing.Point(413, 153);
            this.BtnDisconnectadd.Margin = new System.Windows.Forms.Padding(2);
            this.BtnDisconnectadd.Name = "BtnDisconnectadd";
            this.BtnDisconnectadd.Size = new System.Drawing.Size(57, 19);
            this.BtnDisconnectadd.TabIndex = 32;
            this.BtnDisconnectadd.Text = "Add";
            this.BtnDisconnectadd.UseVisualStyleBackColor = true;
            this.BtnDisconnectadd.Click += new System.EventHandler(this.DisconnectItemAdd);
            // 
            // InSunshinePath
            // 
            this.InSunshinePath.Location = new System.Drawing.Point(12, 316);
            this.InSunshinePath.Name = "InSunshinePath";
            this.InSunshinePath.Size = new System.Drawing.Size(377, 20);
            this.InSunshinePath.TabIndex = 40;
            this.InSunshinePath.Visible = false;
            this.InSunshinePath.TextChanged += new System.EventHandler(this.OnInpSunshineChange);
            // 
            // BtnSunshineBrowse
            // 
            this.BtnSunshineBrowse.Location = new System.Drawing.Point(395, 314);
            this.BtnSunshineBrowse.Name = "BtnSunshineBrowse";
            this.BtnSunshineBrowse.Size = new System.Drawing.Size(75, 23);
            this.BtnSunshineBrowse.TabIndex = 41;
            this.BtnSunshineBrowse.Text = "Browse";
            this.BtnSunshineBrowse.UseVisualStyleBackColor = true;
            this.BtnSunshineBrowse.Visible = false;
            this.BtnSunshineBrowse.Click += new System.EventHandler(this.OnSunshinePathClick);
            // 
            // SunshineInfo
            // 
            this.SunshineInfo.AutoSize = true;
            this.SunshineInfo.Location = new System.Drawing.Point(13, 296);
            this.SunshineInfo.Name = "SunshineInfo";
            this.SunshineInfo.Size = new System.Drawing.Size(172, 13);
            this.SunshineInfo.TabIndex = 42;
            this.SunshineInfo.Text = "Run as admin for Sunshine support";
            // 
            // BrowseSunshinePath
            // 
            this.BrowseSunshinePath.FileName = "sunshine.exe";
            // 
            // monitorSelectionList
            // 
            this.monitorSelectionList.FormattingEnabled = true;
            this.monitorSelectionList.Location = new System.Drawing.Point(15, 26);
            this.monitorSelectionList.Name = "monitorSelectionList";
            this.monitorSelectionList.Size = new System.Drawing.Size(209, 69);
            this.monitorSelectionList.TabIndex = 43;
            this.monitorSelectionList.SelectedIndexChanged += new System.EventHandler(this.SaveSettings);
            // 
            // NVStreamerMainUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 504);
            this.Controls.Add(this.monitorSelectionList);
            this.Controls.Add(this.SunshineInfo);
            this.Controls.Add(this.BtnSunshineBrowse);
            this.Controls.Add(this.InSunshinePath);
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
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
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
        private System.Windows.Forms.TextBox InSunshinePath;
        private System.Windows.Forms.Button BtnSunshineBrowse;
        private System.Windows.Forms.Label SunshineInfo;
        private System.Windows.Forms.OpenFileDialog BrowseSunshinePath;
        private System.Windows.Forms.ListBox monitorSelectionList;
    }
}

