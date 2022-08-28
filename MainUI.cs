using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace NVStreamer1080 {
    public partial class NVStreamerMainUI : Form {
        public NVStreamerMainUI() {
            InitializeComponent();
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct DispSet {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 106)]
            byte[] padding0;
            public int width, height, dummy, frequency;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            byte[] padding1;
        };



        [DllImport("user32.dll")]
        public static extern int EnumDisplaySettings(string a, int b, ref DispSet c);
        [DllImport("user32.dll")]
        public static extern int ChangeDisplaySettings(ref DispSet a, int b);


        private int initialWidth;
        private int initialHeight;
        private int initialRefresh;

        private void InitRegistry() {
            if (Registry.CurrentUser.OpenSubKey("SOFTWARE\\TapperWare\\NVStreamer1080", true) == null)
                Registry.CurrentUser.CreateSubKey("SOFTWARE\\TapperWare\\NVStreamer1080", true);
        }

        private bool UseSecondScreen {
            get {
                return ((string)Registry.CurrentUser.OpenSubKey("SOFTWARE\\TapperWare\\NVStreamer1080", true).GetValue("UseSecondScreen", "0")) == "1";
            }
            set {
                Registry.CurrentUser.OpenSubKey("SOFTWARE\\TapperWare\\NVStreamer1080", true).SetValue("UseSecondScreen", value ? "1" : "0", RegistryValueKind.String);

                InfoMode.Text = value ? "Switch screen" : "Change resolution";
            }
        }

        private int DesiredWidth {
            get {
                return ((int)Registry.CurrentUser.OpenSubKey("SOFTWARE\\TapperWare\\NVStreamer1080", true).GetValue("Width", 1920));
            }
            set {
                if (DWidth.Text != value.ToString())
                    DWidth.Text = value.ToString();

                Registry.CurrentUser.OpenSubKey("SOFTWARE\\TapperWare\\NVStreamer1080", true).SetValue("Width", value, RegistryValueKind.DWord);

                InfoTargetParams.Text = value + "x" + DesiredHeight + "/" + DesiredRefresh;
            }
        }

        private int DesiredHeight {
            get {
                var v = ((int)Registry.CurrentUser.OpenSubKey("SOFTWARE\\TapperWare\\NVStreamer1080", true).GetValue("Height", 1080));
                return v;
            }
            set {
                if (DHeight.Text != value.ToString())
                    DHeight.Text = value.ToString();

                Registry.CurrentUser.OpenSubKey("SOFTWARE\\TapperWare\\NVStreamer1080", true).SetValue("Height", value, RegistryValueKind.DWord);

                InfoTargetParams.Text = DesiredWidth + "x" + value + "/" + DesiredRefresh;
            }
        }

        private int DesiredRefresh {
            get {
                return ((int)Registry.CurrentUser.OpenSubKey("SOFTWARE\\TapperWare\\NVStreamer1080", true).GetValue("Refresh", 60));
            }
            set {
                if (DRefresh.Text != value.ToString())
                    DRefresh.Text = value.ToString();
                Registry.CurrentUser.OpenSubKey("SOFTWARE\\TapperWare\\NVStreamer1080", true).SetValue("Refresh", value, RegistryValueKind.DWord);

                InfoTargetParams.Text = DesiredWidth + "x" + DesiredHeight + "/" + value;
            }
        }

        private JavaScriptSerializer JSON = new JavaScriptSerializer() {
            MaxJsonLength = int.MaxValue
        };

        private AutoAction[] StartActions {
            get {
                return JSON.Deserialize<ArrayList>((string)Registry.CurrentUser.OpenSubKey("SOFTWARE\\TapperWare\\NVStreamer1080", true).GetValue("OnStart", "[]")).OfType<object>().Select(a=>new AutoAction((Dictionary<string,object>)a)).ToArray();
            }
            set {
                Registry.CurrentUser.OpenSubKey("SOFTWARE\\TapperWare\\NVStreamer1080", true).SetValue("OnStart", JSON.Serialize(value.Select(a=>a.ToDictionary())), RegistryValueKind.String);
            }
        }

        private AutoAction[] EndActions {
            get {
                return JSON.Deserialize<ArrayList>((string)Registry.CurrentUser.OpenSubKey("SOFTWARE\\TapperWare\\NVStreamer1080", true).GetValue("OnEnd", "[]")).OfType<object>().Select(a => new AutoAction((Dictionary<string, object>)a)).ToArray();
            }
            set {
                Registry.CurrentUser.OpenSubKey("SOFTWARE\\TapperWare\\NVStreamer1080", true).SetValue("OnEnd", JSON.Serialize(value.Select(a => a.ToDictionary())), RegistryValueKind.String);
            }
        }

        private bool RestoreAccelerationPrecision {
            get {
                return ((string)Registry.CurrentUser.OpenSubKey("SOFTWARE\\TapperWare\\NVStreamer1080", true).GetValue("RestoreAccelerationPrecision", "0"))=="1";
            }
            set {
                if (CbAccelRestore.Checked != value)
                    CbAccelRestore.Checked = value;
                Registry.CurrentUser.OpenSubKey("SOFTWARE\\TapperWare\\NVStreamer1080", true).SetValue("RestoreAccelerationPrecision", value?"1":"0", RegistryValueKind.String);
            }
        }

        NotifyIcon trayNotifyIcon;
        private void NVStreamerMainUI_Load(object sender, EventArgs e) {
            InitRegistry();
            Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true).SetValue("NVStreamer1080", Application.ExecutablePath);

            var disp = new DispSet();
            if (EnumDisplaySettings(null, -1, ref disp) == 0) {
                Application.Exit();
                return;
            }


            ListOnConnect.Items.AddRange(StartActions);
            ListOnDisconnect.Items.AddRange(EndActions);
            initialWidth = disp.width;
            initialHeight = disp.height;
            initialRefresh = disp.frequency;
            InfoReturnParams.Text = initialWidth + "x" + initialHeight + "/" + initialRefresh;


            var trayContextMenu = new ContextMenu();
            trayNotifyIcon = new NotifyIcon();
            IntPtr tryIconPtr = Resource1.TrayIcon.Handle;
            Icon trayIcon = Icon.FromHandle(tryIconPtr);

            trayContextMenu.MenuItems.Add("Show UI", OnShow);
            trayContextMenu.MenuItems.Add("Exit", OnExit);

            DWidth.Text = DesiredWidth.ToString();
            DHeight.Text = DesiredHeight.ToString();
            DRefresh.Text = DesiredRefresh.ToString();
            CbAccelRestore.Checked = RestoreAccelerationPrecision;

            this.DWidth.TextChanged += new System.EventHandler(this.SaveSettings);
            this.DHeight.TextChanged += new System.EventHandler(this.SaveSettings);
            this.DRefresh.TextChanged += new System.EventHandler(this.SaveSettings);
            this.CbAccelRestore.CheckedChanged += new System.EventHandler(this.SaveSettings);

            DesiredWidth = DesiredWidth;
            DesiredHeight = DesiredHeight;
            DesiredRefresh = DesiredRefresh;

            UseSecondScreen = useSecondScreenCB.Checked = UseSecondScreen;

            trayNotifyIcon.Icon = trayIcon;
            trayNotifyIcon.Text = "NV Streamer 1080";
            trayNotifyIcon.Click += OnShow;

            trayNotifyIcon.ContextMenu = trayContextMenu;
            trayNotifyIcon.Visible = true;
            CheckTimer.Enabled = true;

        }



        private bool allowClose = false;

        protected override void Dispose(bool isDisposing) {
            if (!allowClose) {
                ShowInTaskbar = false;
                Visible = false;
                return;
            }

            if ((components != null)) {
                components.Dispose();
            }

            if (isDisposing) {
                trayNotifyIcon.Dispose();
            }

            if (StreamingIsActive) {
                SetResolution(initialWidth, initialHeight, initialRefresh);
                StreamingIsActive = false;
            }

            base.Dispose(isDisposing);

        }

        private void OnExit(object sender, EventArgs e) {
            allowClose = true;
            Application.Exit();
        }

        private void OnShow(object sender, EventArgs e) {
            ShowInTaskbar = true;
            Visible = true;
            BringToFront();
            CenterToScreen();
        }

        private bool StreamingIsActive = false;

        private void SetResolution(int w, int h, int r) {

            var disp = new DispSet();
            if (EnumDisplaySettings(null, -1, ref disp) == 0)
                return;

            disp.width = w;
            disp.height = h;
            disp.frequency = r;
            ChangeDisplaySettings(ref disp, 1);

        }

        public Form CaptureOverlay = null;

        public List<AutoActionSchedule> ActionsScheduled = new List<AutoActionSchedule>();
        private void CheckTimer_Tick(object sender, EventArgs e) {
            var Switch = Path.Combine(Environment.SystemDirectory, "DisplaySwitch.exe");
            var nvStreamers = Process.GetProcesses().Where(a => a.ProcessName.ToLower() == "nvstreamer").ToList();
            var nvRunning = nvStreamers.Any();
            var nvPids = nvStreamers.Select(a => a.Id);
            var now = DateTime.Now;

            ActionsScheduled = ActionsScheduled.Where((a) => {
                if (a.ScheduledDate < now) {
                    try {
                        a.ScheduledAction.Execute();
                    } catch (Exception ex) {
                        DoLog(ex.ToString());
                    }
                    return false;
                } else {
                    return true;
                }
            }).ToList();

            var anyAbortable = ActionsScheduled.Where(a => a.ScheduledAction.AbortOnInput).Any();
            if (CaptureOverlay==null && anyAbortable) {
                CaptureOverlay = new CaptureWindow(this);
                CaptureOverlay.Show(this);
            }else if(CaptureOverlay!=null && !anyAbortable) {
                CaptureOverlay.Close();
                CaptureOverlay = null;
            }

            if (nvRunning && !StreamingIsActive) {
                DoLog("Stream start detected");
                InfoState.Text = "Stream active";
                DWidth.Enabled = false;
                DHeight.Enabled = false;
                DRefresh.Enabled = false;
                useSecondScreenCB.Enabled = false;
                ActionsScheduled.AddRange(ListOnConnect.Items.OfType<AutoAction>().Select(a => new AutoActionSchedule() { ScheduledAction = a, ScheduledDate = now.AddSeconds(a.Delay) }));
                
                if (UseSecondScreen) {
                    DoLog("Switching to external screen");
                    Process.Start(Switch, "/external");
                    label1.Text = "NVStreamer active: External";
                } else {
                    DoLog($"Setting target resolution {DesiredWidth}x{DesiredHeight}@{DesiredRefresh}");
                    SetResolution(DesiredWidth, DesiredHeight, DesiredRefresh);
                    label1.Text = $"NVStreamer active: {DesiredWidth}x{DesiredHeight}@{DesiredRefresh}";
                }
                StreamingIsActive = true;
            } else if (!nvRunning && StreamingIsActive) {
                DoLog("Stream end detected");
                InfoState.Text = "Stream ended";
                DWidth.Enabled = true;
                DHeight.Enabled = true;
                DRefresh.Enabled = true;
                useSecondScreenCB.Enabled = true;
                ActionsScheduled.AddRange(ListOnDisconnect.Items.OfType<AutoAction>().Select(a => new AutoActionSchedule() { ScheduledAction = a, ScheduledDate = now.AddSeconds(a.Delay) }));
                if (UseSecondScreen) {
                    DoLog("Switching to internal screen");
                    Process.Start(Switch, "/internal");
                } else {
                    DoLog($"Restoring resolution {initialWidth}x{initialHeight}@{initialRefresh}");
                    SetResolution(initialWidth, initialHeight, initialRefresh);
                }
                StreamingIsActive = false;
                label1.Text = "NVStreamer not active";
                useSecondScreenCB.Enabled = true;
            }
        }

        private void HideTimer_Tick(object sender, EventArgs e) {
            HideTimer.Enabled = false;

            if (!Environment.GetCommandLineArgs().Where(a => a == "/NoAutoHide").Any()) {
                ShowInTaskbar = false;
                Visible = false;
            }
        }


        private void SaveSettings(object sender, EventArgs e) {
            DesiredWidth = int.TryParse(DWidth.Text, out int w) ? w : 1920;
            DesiredHeight = int.TryParse(DHeight.Text, out int h) ? h : 1080;
            DesiredRefresh = int.TryParse(DRefresh.Text, out int r) ? r : 60;
            UseSecondScreen = useSecondScreenCB.Checked;
            RestoreAccelerationPrecision = CbAccelRestore.Checked;
        }

        private void DoLog(string message) {
            Log.Items.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " " + message);
        }


        private void BtnConnectAdd_Click(object sender, EventArgs e) {
            var action = new AutoAction();
            ListOnConnect.Items.Add(action);
            new ActionEdit(action).ShowDialog(this);
            ListOnConnect.Items[ListOnConnect.Items.IndexOf(action)] = action;
            StartActions = ListOnConnect.Items.OfType<AutoAction>().ToArray();
        }

        private void BtnDisconnectadd_Click(object sender, EventArgs e) {
            var action = new AutoAction();
            ListOnDisconnect.Items.Add(action);
            new ActionEdit(action).ShowDialog(this);
            ListOnDisconnect.Items[ListOnDisconnect.Items.IndexOf(action)] = action;
            EndActions = ListOnDisconnect.Items.OfType<AutoAction>().ToArray();
        }

        private void BtnConnectEdit_Click(object sender, EventArgs e) {
            var action = (AutoAction)ListOnConnect.SelectedItem;
            new ActionEdit(action).ShowDialog(this);
            ListOnConnect.Items[ListOnConnect.Items.IndexOf(action)] = action;
            StartActions = ListOnConnect.Items.OfType<AutoAction>().ToArray();
        }

        private void BtnConnectDel_Click(object sender, EventArgs e) {
            ListOnConnect.Items.Remove(ListOnConnect.SelectedItem);
            StartActions = ListOnConnect.Items.OfType<AutoAction>().ToArray();
        }

        private void BtnDisconnectDel_Click(object sender, EventArgs e) {
            ListOnDisconnect.Items.Remove(ListOnDisconnect.SelectedItem);
            EndActions = ListOnDisconnect.Items.OfType<AutoAction>().ToArray();
        }

        private void BtnDisconnectEdit_Click(object sender, EventArgs e) {
            var action = (AutoAction)ListOnDisconnect.SelectedItem;
            new ActionEdit(action).ShowDialog(this);
            ListOnDisconnect.Items[ListOnDisconnect.Items.IndexOf(action)] = action;
            EndActions = ListOnDisconnect.Items.OfType<AutoAction>().ToArray();
        }
    }
}