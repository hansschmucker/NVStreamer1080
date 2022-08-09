using Microsoft.Win32;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
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
        private bool UseSecondScreen {
            get {
                if (Registry.CurrentUser.OpenSubKey("SOFTWARE\\TapperWare\\NVStreamer1080", true) == null)
                    Registry.CurrentUser.CreateSubKey("SOFTWARE\\TapperWare\\NVStreamer1080", true);
                return ((string)Registry.CurrentUser.OpenSubKey("SOFTWARE\\TapperWare\\NVStreamer1080", true).GetValue("UseSecondScreen", "0")) == "1";
            }
            set {
                if (Registry.CurrentUser.OpenSubKey("SOFTWARE\\TapperWare\\NVStreamer1080", true) == null)
                    Registry.CurrentUser.CreateSubKey("SOFTWARE\\TapperWare\\NVStreamer1080", true);
                Registry.CurrentUser.OpenSubKey("SOFTWARE\\TapperWare\\NVStreamer1080", true).SetValue("UseSecondScreen", value ? "1" : "0", RegistryValueKind.String);

                InfoMode.Text = value ? "Switch screen" : "Change resolution";
            }
        }

        private int DesiredWidth {
            get {
                if (Registry.CurrentUser.OpenSubKey("SOFTWARE\\TapperWare\\NVStreamer1080", true) == null)
                    Registry.CurrentUser.CreateSubKey("SOFTWARE\\TapperWare\\NVStreamer1080", true);
                return ((int)Registry.CurrentUser.OpenSubKey("SOFTWARE\\TapperWare\\NVStreamer1080", true).GetValue("Width", 1920));
            }
            set {
                if (DWidth.Text != value.ToString())
                    DWidth.Text = value.ToString();
                if (Registry.CurrentUser.OpenSubKey("SOFTWARE\\TapperWare\\NVStreamer1080", true) == null)
                    Registry.CurrentUser.CreateSubKey("SOFTWARE\\TapperWare\\NVStreamer1080", true);
                Registry.CurrentUser.OpenSubKey("SOFTWARE\\TapperWare\\NVStreamer1080", true).SetValue("Width", value, RegistryValueKind.DWord);

                InfoTargetParams.Text = value + "x" + DesiredHeight + "/" + DesiredRefresh;
            }
        }

        private int DesiredHeight {
            get {
                if (Registry.CurrentUser.OpenSubKey("SOFTWARE\\TapperWare\\NVStreamer1080", true) == null)
                    Registry.CurrentUser.CreateSubKey("SOFTWARE\\TapperWare\\NVStreamer1080", true);
                var v = ((int)Registry.CurrentUser.OpenSubKey("SOFTWARE\\TapperWare\\NVStreamer1080", true).GetValue("Height", 1080));
                return v;
            }
            set {
                if (DHeight.Text != value.ToString())
                    DHeight.Text = value.ToString();
                if (Registry.CurrentUser.OpenSubKey("SOFTWARE\\TapperWare\\NVStreamer1080", true) == null)
                    Registry.CurrentUser.CreateSubKey("SOFTWARE\\TapperWare\\NVStreamer1080", true);
                Registry.CurrentUser.OpenSubKey("SOFTWARE\\TapperWare\\NVStreamer1080", true).SetValue("Height", value, RegistryValueKind.DWord);

                InfoTargetParams.Text = DesiredWidth + "x" + value + "/" + DesiredRefresh;
            }
        }

        private int DesiredRefresh {
            get {
                if (Registry.CurrentUser.OpenSubKey("SOFTWARE\\TapperWare\\NVStreamer1080", true) == null)
                    Registry.CurrentUser.CreateSubKey("SOFTWARE\\TapperWare\\NVStreamer1080", true);
                return ((int)Registry.CurrentUser.OpenSubKey("SOFTWARE\\TapperWare\\NVStreamer1080", true).GetValue("Refresh", 60));
            }
            set {
                if (DRefresh.Text != value.ToString())
                    DRefresh.Text = value.ToString();
                if (Registry.CurrentUser.OpenSubKey("SOFTWARE\\TapperWare\\NVStreamer1080", true) == null)
                    Registry.CurrentUser.CreateSubKey("SOFTWARE\\TapperWare\\NVStreamer1080", true);
                Registry.CurrentUser.OpenSubKey("SOFTWARE\\TapperWare\\NVStreamer1080", true).SetValue("Refresh", value, RegistryValueKind.DWord);

                InfoTargetParams.Text = DesiredWidth + "x" + DesiredHeight + "/" + value;
            }
        }

        NotifyIcon trayNotifyIcon;
        private void NVStreamerMainUI_Load(object sender, EventArgs e) {
            Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true).SetValue("NVStreamer1080", Application.ExecutablePath);

            var disp = new DispSet();
            if (EnumDisplaySettings(null, -1, ref disp) == 0) {
                Application.Exit();
                return;
            }

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
            this.DWidth.TextChanged += new System.EventHandler(this.Width_TextChanged);
            this.DHeight.TextChanged += new System.EventHandler(this.Width_TextChanged);
            this.DRefresh.TextChanged += new System.EventHandler(this.Width_TextChanged);

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

            if (nv1080Set) {
                SetResolution(initialWidth, initialHeight, initialRefresh);
                nv1080Set = false;
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

        private bool nv1080Set = false;

        private void SetResolution(int w, int h, int r) {

            var disp = new DispSet();
            if (EnumDisplaySettings(null, -1, ref disp) == 0)
                return;

            disp.width = w;
            disp.height = h;
            disp.frequency = r;
            ChangeDisplaySettings(ref disp, 1);

        }

        private void CheckTimer_Tick(object sender, EventArgs e) {
            var Switch = Path.Combine(Environment.SystemDirectory, "DisplaySwitch.exe");
            var nvRunning = Process.GetProcesses().Where(a => a.ProcessName.ToLower() == "nvstreamer").Count() > 0;
            if (nvRunning && !nv1080Set) {
                DoLog("Stream start detected");
                InfoState.Text = "Stream active";
                DWidth.Enabled = false;
                DHeight.Enabled = false;
                DRefresh.Enabled = false;
                useSecondScreenCB.Enabled = false;
                if (UseSecondScreen) {
                    DoLog("Switching to external screen");
                    Process.Start(Switch, "/external");
                    label1.Text = "NVStreamer active: External";
                } else {
                    DoLog($"Setting target resolution {DesiredWidth}x{DesiredHeight}@{DesiredRefresh}");
                    SetResolution(DesiredWidth, DesiredHeight, DesiredRefresh);
                    label1.Text = $"NVStreamer active: {DesiredWidth}x{DesiredHeight}@{DesiredRefresh}";
                }
                nv1080Set = true;
            } else if (!nvRunning && nv1080Set) {
                DoLog("Stream end detected");
                InfoState.Text = "Stream ended";
                DWidth.Enabled = true;
                DHeight.Enabled = true;
                DRefresh.Enabled = true;
                useSecondScreenCB.Enabled = true;
                if (UseSecondScreen) {
                    DoLog("Switching to internal screen");
                    Process.Start(Switch, "/internal");
                } else {
                    DoLog($"Restoring resolution {initialWidth}x{initialHeight}@{initialRefresh}");
                    SetResolution(initialWidth, initialHeight, initialRefresh);
                }
                nv1080Set = false;
                label1.Text = "NVStreamer not active";
                useSecondScreenCB.Enabled = true;
            }
        }

        private void HideTimer_Tick(object sender, EventArgs e) {
            ShowInTaskbar = false;
            Visible = false;
            HideTimer.Enabled = false;

        }

        private void OnSecondScreenCheckboxChange(object sender, EventArgs e) {
            if(UseSecondScreen != useSecondScreenCB.Checked)
                UseSecondScreen = useSecondScreenCB.Checked;
        }

        private void Width_TextChanged(object sender, EventArgs e) {
            DesiredWidth = int.TryParse(DWidth.Text, out int w) ? w : 1920;
            DesiredHeight = int.TryParse(DHeight.Text, out int h) ? h : 1080;
            DesiredRefresh = int.TryParse(DRefresh.Text, out int r) ? r : 60;
        }

        private void DoLog(string message) {
            Log.Items.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " " + message);
        }
    }
}