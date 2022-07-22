using Microsoft.Win32;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace NVStreamer1080
{
    public partial class NVStreamerMainUI : Form
    {
        public NVStreamerMainUI()
        {
            InitializeComponent();
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct DispSet
        {
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
        private bool useSecondScreen = false;
        private int desiredWidth;
        private int desiredHeight;
        private int desiredRefresh;
        NotifyIcon trayNotifyIcon;
        private void NVStreamerMainUI_Load(object sender, EventArgs e)
        {
            Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true).SetValue("NVStreamer1080", Application.ExecutablePath);

            var disp = new DispSet();
            if (EnumDisplaySettings(null, -1, ref disp) == 0)
            {
                Application.Exit();
                return;
            }

            initialWidth = disp.width;
            initialHeight = disp.height;
            initialRefresh = disp.frequency;

            
            var trayContextMenu = new ContextMenu();
            trayNotifyIcon = new NotifyIcon();
            IntPtr tryIconPtr = Resource1.TrayIcon.Handle;
            Icon trayIcon = Icon.FromHandle(tryIconPtr);

            trayContextMenu.MenuItems.Add("Show UI", OnShow);
            trayContextMenu.MenuItems.Add("Exit", OnExit);
            if (Registry.CurrentUser.OpenSubKey("SOFTWARE\\TapperWare\\NVStreamer1080", true) == null)
                Registry.CurrentUser.CreateSubKey("SOFTWARE\\TapperWare\\NVStreamer1080", true);
            useSecondScreen=((string)Registry.CurrentUser.OpenSubKey("SOFTWARE\\TapperWare\\NVStreamer1080", true).GetValue("UseSecondScreen","0"))=="1";
            desiredWidth = ((int)Registry.CurrentUser.OpenSubKey("SOFTWARE\\TapperWare\\NVStreamer1080", true).GetValue("Width", 1920));
            desiredHeight = ((int)Registry.CurrentUser.OpenSubKey("SOFTWARE\\TapperWare\\NVStreamer1080", true).GetValue("Height", 1080));
            desiredRefresh = ((int)Registry.CurrentUser.OpenSubKey("SOFTWARE\\TapperWare\\NVStreamer1080", true).GetValue("Refresh", 60));
            DWidth.Text = desiredHeight.ToString();
            DHeight.Text = desiredWidth.ToString();
            DRefresh.Text = desiredRefresh.ToString();

            if (useSecondScreen)
                useSecondScreenCB.Checked = true;

            trayNotifyIcon.Icon = trayIcon;
            trayNotifyIcon.Text = "NV Streamer 1080";
            trayNotifyIcon.Click += OnShow;

            trayNotifyIcon.ContextMenu = trayContextMenu;
            trayNotifyIcon.Visible = true;
            CheckTimer.Enabled = true;

        }

        private bool allowClose = false;

        protected override void Dispose(bool isDisposing)
        {
            if (!allowClose)
            {
                ShowInTaskbar = false;
                Visible = false;
                return;
            }

            if ((components != null))
            {
                components.Dispose();
            }

            if (isDisposing)
            {
                trayNotifyIcon.Dispose();
            }

            if (nv1080Set)
            {
                SetResolution(initialWidth, initialHeight, initialRefresh);
                nv1080Set = false;
            }

            base.Dispose(isDisposing);

        }

            private void OnExit(object sender, EventArgs e)
        {
            allowClose = true;
            Application.Exit();
        }

        private void OnShow(object sender, EventArgs e)
        {
            ShowInTaskbar = true;
            Visible = true;
            BringToFront();
            CenterToScreen();
        }

        private bool nv1080Set = false;

        private void SetResolution(int w,int h, int r)
        {

            var disp = new DispSet();
            if (EnumDisplaySettings(null, -1, ref disp) == 0)
                return;

            disp.width = w;
            disp.height = h;
            disp.frequency = r;
            ChangeDisplaySettings(ref disp, 1);

        }

        private void CheckTimer_Tick(object sender, EventArgs e)
        {
            var Switch = Path.Combine(Environment.SystemDirectory, "DisplaySwitch.exe");
            var nvRunning = Process.GetProcesses().Where(a => a.ProcessName.ToLower() == "nvstreamer").Count() > 0;
            if(nvRunning && !nv1080Set)
            {
                if (useSecondScreen)
                {
                    
                    Process.Start(Switch, "/external");
                    label1.Text = "NVStreamer active: External";
                }
                else
                {
                    SetResolution(desiredWidth, desiredHeight, desiredRefresh);
                    label1.Text = $"NVStreamer active: {desiredWidth}x{desiredHeight}@{desiredRefresh}";
                }
                nv1080Set = true;
                useSecondScreenCB.Enabled = false;
            }
            else if(!nvRunning && nv1080Set)
            {
                if (useSecondScreen)
                {
                    Process.Start(Switch, "/internal");
                }
                else
                {
                    SetResolution(initialWidth, initialHeight, initialRefresh);
                }
                nv1080Set = false;
                label1.Text = "NVStreamer not active";
                useSecondScreenCB.Enabled = true;
            }
        }

        private void HideTimer_Tick(object sender, EventArgs e)
        {
            ShowInTaskbar = false;
            Visible = false;
            HideTimer.Enabled = false;

        }

        private void OnSecondScreenCheckboxChange(object sender, EventArgs e)
        {
            Registry.CurrentUser.OpenSubKey("SOFTWARE\\TapperWare\\NVStreamer1080", true).SetValue("UseSecondScreen", useSecondScreenCB.Checked ? "1" : "0", RegistryValueKind.String);
            useSecondScreen = useSecondScreenCB.Checked;

        }

        private void Width_TextChanged(object sender, EventArgs e) {
            if (!int.TryParse(DWidth.Text, out desiredWidth))
                DWidth.Text = (desiredWidth = 1920).ToString();

            Registry.CurrentUser.OpenSubKey("SOFTWARE\\TapperWare\\NVStreamer1080", true).SetValue("Width", desiredWidth,  RegistryValueKind.DWord);

            if (!int.TryParse(DHeight.Text, out desiredHeight))
                DHeight.Text = (desiredHeight = 1080).ToString();

            Registry.CurrentUser.OpenSubKey("SOFTWARE\\TapperWare\\NVStreamer1080", true).SetValue("Height", desiredHeight, RegistryValueKind.DWord);

            if (!int.TryParse(DRefresh.Text, out desiredRefresh))
                DRefresh.Text = (desiredRefresh = 60).ToString();

            Registry.CurrentUser.OpenSubKey("SOFTWARE\\TapperWare\\NVStreamer1080", true).SetValue("Refresh", desiredRefresh, RegistryValueKind.DWord);
        }
    }
}