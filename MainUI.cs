using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.ServiceProcess;
using System.Text.RegularExpressions;
using System.Threading;
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
            readonly byte[] padding0;
            public int width, height, dummy, frequency;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            readonly byte[] padding1;
        };



        [DllImport("user32.dll")]
        public static extern int EnumDisplaySettings(string a, int b, ref DispSet c);
        [DllImport("user32.dll")]
        public static extern int ChangeDisplaySettings(ref DispSet a, int b);

        [Flags]
        public enum SPIF {
            None = 0x00,
            SPIF_UPDATEINIFILE = 0x01,
            SPIF_SENDCHANGE = 0x02,
            SPIF_SENDWININICHANGE = 0x02
        }

        [DllImport("user32.dll", EntryPoint = "SystemParametersInfo", SetLastError = true)]
        public static extern bool SystemParametersInfoGet(uint action, uint param, IntPtr vparam, SPIF fWinIni);
        public const UInt32 SPI_GETMOUSE = 0x0003;
        [DllImport("user32.dll", EntryPoint = "SystemParametersInfo", SetLastError = true)]
        public static extern bool SystemParametersInfoSet(uint action, uint param, IntPtr vparam, SPIF fWinIni);
        public const UInt32 SPI_SETMOUSE = 0x0004;

        public bool IsPointerEnhanced() {
            int[] mouseParams = new int[3];
            SystemParametersInfoGet(SPI_GETMOUSE, 0, GCHandle.Alloc(mouseParams, GCHandleType.Pinned).AddrOfPinnedObject(), 0);
            return mouseParams[0] == 1;
        }

        public void SetPointerEnhanced(bool v) {
            int[] mouseParams = new int[3];
            SystemParametersInfoGet(SPI_GETMOUSE, 0, GCHandle.Alloc(mouseParams, GCHandleType.Pinned).AddrOfPinnedObject(), 0);
            mouseParams[2] = v ? 1 : 0;
            SystemParametersInfoSet(SPI_SETMOUSE, 0, GCHandle.Alloc(mouseParams, GCHandleType.Pinned).AddrOfPinnedObject(), SPIF.SPIF_SENDCHANGE);
        }




        private int detectedWidth;
        private int detectedHeight;
        private int detectedRefresh;
        private bool initialMousePrecise;

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

        private string SunshinePath {
            get {
                return ((string)Registry.CurrentUser.OpenSubKey("SOFTWARE\\TapperWare\\NVStreamer1080", true).GetValue("SunshinePath", ""));
            }
            set {
                if (InSunshinePath.Text == value)
                    return;
                Registry.CurrentUser.OpenSubKey("SOFTWARE\\TapperWare\\NVStreamer1080", true).SetValue("SunshinePath", value, RegistryValueKind.String);
                InSunshinePath.Text = value;
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









        private bool OverrideReturnResolution {
            get {
                var v = ((string)Registry.CurrentUser.OpenSubKey("SOFTWARE\\TapperWare\\NVStreamer1080", true).GetValue("OverrideReturnResolution", "0")) == "1";
                return v;
            }
            set {
                if (cbOverrideReturnRes.Checked != value)
                    cbOverrideReturnRes.Checked = value;

                Registry.CurrentUser.OpenSubKey("SOFTWARE\\TapperWare\\NVStreamer1080", true).SetValue("OverrideReturnResolution", value ? "1" : "0", RegistryValueKind.String);
            }
        }

        private int ReturnWidth {
            get {
                if (OverrideReturnResolution) {
                    var v = ((int)Registry.CurrentUser.OpenSubKey("SOFTWARE\\TapperWare\\NVStreamer1080", true).GetValue("ReturnWidth", 1920));
                    return v;
                } else {
                    return detectedWidth;
                }
            }
            set {
                if (SWidth.Text != value.ToString())
                    SWidth.Text = value.ToString();

                Registry.CurrentUser.OpenSubKey("SOFTWARE\\TapperWare\\NVStreamer1080", true).SetValue("ReturnWidth", value, RegistryValueKind.DWord);
            }
        }

        private int ReturnHeight {
            get {
                if (OverrideReturnResolution) {
                    var v = ((int)Registry.CurrentUser.OpenSubKey("SOFTWARE\\TapperWare\\NVStreamer1080", true).GetValue("ReturnHeight", 1080));
                    return v;
                } else {
                    return detectedHeight;
                }
            }
            set {
                if (SHeight.Text != value.ToString())
                    SHeight.Text = value.ToString();

                Registry.CurrentUser.OpenSubKey("SOFTWARE\\TapperWare\\NVStreamer1080", true).SetValue("ReturnHeight", value, RegistryValueKind.DWord);
            }
        }

        private int ReturnRefresh {
            get {
                if (OverrideReturnResolution) {
                    var v = ((int)Registry.CurrentUser.OpenSubKey("SOFTWARE\\TapperWare\\NVStreamer1080", true).GetValue("ReturnRefresh", 60));
                    return v;
                } else {
                    return detectedRefresh;
                }
            }
            set {
                if (SRefresh.Text != value.ToString())
                    SRefresh.Text = value.ToString();
                Registry.CurrentUser.OpenSubKey("SOFTWARE\\TapperWare\\NVStreamer1080", true).SetValue("ReturnRefresh", value, RegistryValueKind.DWord);

            }
        }

        private readonly JavaScriptSerializer JSON = new JavaScriptSerializer() {
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
        public bool isElevated = false;
        private void NVStreamerMainUI_Load(object sender, EventArgs e) {
            using (WindowsIdentity identity = WindowsIdentity.GetCurrent()) {
                WindowsPrincipal principal = new WindowsPrincipal(identity);
                isElevated = principal.IsInRole(WindowsBuiltInRole.Administrator);
                if (isElevated) {
                    CbAccelRestore.Visible = true;
                    BtnSunshineBrowse.Visible = true;
                    InSunshinePath.Visible = true;
                    SunshineInfo.Text = "Path to Sunshine (leave empty for NVidia GameStream)";
                }
            }

            InitRegistry();
            Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true).SetValue("NVStreamer1080", Application.ExecutablePath);

            var disp = new DispSet();
            if (EnumDisplaySettings(null, -1, ref disp) == 0) {
                Application.Exit();
                return;
            }


            ListOnConnect.Items.AddRange(StartActions);
            ListOnDisconnect.Items.AddRange(EndActions);
            detectedWidth = disp.width;
            detectedHeight = disp.height;
            detectedRefresh = disp.frequency;
            initialMousePrecise = IsPointerEnhanced();
            InfoReturnParams.Text = detectedWidth + "x" + detectedHeight + "/" + detectedRefresh;


            var trayContextMenu = new ContextMenu();
            trayNotifyIcon = new NotifyIcon();
            IntPtr tryIconPtr = Resource1.TrayIcon.Handle;
            Icon trayIcon = Icon.FromHandle(tryIconPtr);

            trayContextMenu.MenuItems.Add("Show UI", OnShow);
            trayContextMenu.MenuItems.Add("Exit", OnExit);

            DWidth.Text = DesiredWidth.ToString();
            DHeight.Text = DesiredHeight.ToString();
            DRefresh.Text = DesiredRefresh.ToString();
            ReturnWidth = ReturnWidth;
            ReturnHeight = ReturnHeight;
            ReturnRefresh = ReturnRefresh;
            SWidth.Text = ReturnWidth.ToString();
            SHeight.Text = ReturnHeight.ToString();
            SRefresh.Text = ReturnRefresh.ToString();
            InSunshinePath.Text = SunshinePath;

            CbAccelRestore.Checked = RestoreAccelerationPrecision;
            cbOverrideReturnRes.Checked = OverrideReturnResolution;
            OnOverrideReturnChange(null, null);

            this.DWidth.TextChanged += new System.EventHandler(this.SaveSettings);
            this.DHeight.TextChanged += new System.EventHandler(this.SaveSettings);
            this.DRefresh.TextChanged += new System.EventHandler(this.SaveSettings);
            this.CbAccelRestore.CheckedChanged += new System.EventHandler(this.SaveSettings);
            this.SWidth.TextChanged += new System.EventHandler(this.SaveSettings);
            this.SHeight.TextChanged += new System.EventHandler(this.SaveSettings);
            this.SRefresh.TextChanged += new System.EventHandler(this.SaveSettings);



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

            if ((components != null))
                components.Dispose();

            if (isDisposing)
                trayNotifyIcon.Dispose();

            if (StreamingIsActive) {
                SetResolution(ReturnWidth, ReturnHeight, ReturnRefresh);
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

        public bool SunshineIsClientConnected = false;
        private void OnTick(object sender, EventArgs e) {
            var Switch = Path.Combine(Environment.SystemDirectory, "DisplaySwitch.exe");
            var nvStreamers = Process.GetProcesses().Where(a => a.ProcessName.ToLower() == "nvstreamer").ToList();
            var nvRunning = nvStreamers.Any() || SunshineIsClientConnected;
            var nvPids = nvStreamers.Select(a => a.Id);
            var now = DateTime.Now;

            ActionsScheduled = ActionsScheduled.Where((a) => {
                if (a.ScheduledDate < now) {
                    try {
                        DoLog(a.ScheduledAction.Execute());
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
                    DoLog($"Restoring resolution {ReturnWidth}x{ReturnHeight}@{ReturnRefresh}");
                    SetResolution(ReturnWidth, ReturnHeight, ReturnRefresh);
                }
                StreamingIsActive = false;
                if (RestoreAccelerationPrecision)
                    SetPointerEnhanced(initialMousePrecise);
                label1.Text = "NVStreamer not active";
                useSecondScreenCB.Enabled = true;
            }
        }

        private void SilentLaunchAutoHide(object sender, EventArgs e) {
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
            ReturnWidth = int.TryParse(SWidth.Text, out int rw) ? rw : 1920;
            ReturnHeight = int.TryParse(SHeight.Text, out int rh) ? rh : 1080;
            ReturnRefresh = int.TryParse(SRefresh.Text, out int rr) ? rr : 60;
            UseSecondScreen = useSecondScreenCB.Checked;
            RestoreAccelerationPrecision = CbAccelRestore.Checked;
            SunshinePath = InSunshinePath.Text;
        }

        private void DoLog(string message) {
            Invoke(new Action(() => {
                Log.Items.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " " + message);
            }));
        }


        private void ConnectItemAdd(object sender, EventArgs e) {
            var action = new AutoAction();
            ListOnConnect.Items.Add(action);
            new ActionEdit(action).ShowDialog(this);
            ListOnConnect.Items[ListOnConnect.Items.IndexOf(action)] = action;
            StartActions = ListOnConnect.Items.OfType<AutoAction>().ToArray();
        }

        private void DisconnectItemAdd(object sender, EventArgs e) {
            var action = new AutoAction();
            ListOnDisconnect.Items.Add(action);
            new ActionEdit(action).ShowDialog(this);
            ListOnDisconnect.Items[ListOnDisconnect.Items.IndexOf(action)] = action;
            EndActions = ListOnDisconnect.Items.OfType<AutoAction>().ToArray();
        }

        private void ConnectItemEdit(object sender, EventArgs e) {
            var action = (AutoAction)ListOnConnect.SelectedItem;
            new ActionEdit(action).ShowDialog(this);
            ListOnConnect.Items[ListOnConnect.Items.IndexOf(action)] = action;
            StartActions = ListOnConnect.Items.OfType<AutoAction>().ToArray();
        }

        private void ConnectItemDel(object sender, EventArgs e) {
            ListOnConnect.Items.Remove(ListOnConnect.SelectedItem);
            StartActions = ListOnConnect.Items.OfType<AutoAction>().ToArray();
        }

        private void DisconnectItemDel(object sender, EventArgs e) {
            ListOnDisconnect.Items.Remove(ListOnDisconnect.SelectedItem);
            EndActions = ListOnDisconnect.Items.OfType<AutoAction>().ToArray();
        }

        private void DisconnectItemEdit(object sender, EventArgs e) {
            var action = (AutoAction)ListOnDisconnect.SelectedItem;
            new ActionEdit(action).ShowDialog(this);
            ListOnDisconnect.Items[ListOnDisconnect.Items.IndexOf(action)] = action;
            EndActions = ListOnDisconnect.Items.OfType<AutoAction>().ToArray();
        }

        private void OnOverrideReturnChange(object sender, EventArgs e) {
            if (cbOverrideReturnRes.Checked) {
                SWidth.Enabled = true;
                SHeight.Enabled = true;
                SRefresh.Enabled = true;
            } else {
                SWidth.Enabled = false;
                SHeight.Enabled = false;
                SRefresh.Enabled = false;
            }
            OverrideReturnResolution = cbOverrideReturnRes.Checked;
        }


        private void SunshineInit() {


            // Stop sunshinesvc if running
            try {
                ServiceController service = new ServiceController("sunshinesvc");
                if (service.Status == ServiceControllerStatus.Running) {
                    service.Stop();
                    DoLog("SunshineService stopped");
                }
                
                do {
                    // wait 1s+ for it to wind down
                    Thread.Sleep(1000);
                } while (service.Status != ServiceControllerStatus.Stopped);

            } catch (Exception) {
                //Non fatal because service a non-existant service is as good as a stopped one
            }



            // kill any remaining sunshines
            foreach (var proc in Process.GetProcesses().Where(a => a.ProcessName == "sunshine")) {
                try {
                    proc.Kill();
                    DoLog("Sunshine stopped");
                } catch (Exception) {
                    DoLog("Could not stop existing Sunshine process. Make sure you run this as admin.");
                }
            }


            // if no path return
            if (String.IsNullOrWhiteSpace(SunshinePath))
                return;

            if (!isElevated) {
                DoLog("Run as admin for Sunshine support.");
            } else {
                // wait 1s
                Thread.Sleep(1000);

                // spin up internal sunshine
                var newProc = new ProcessStartInfo(SunshinePath) { CreateNoWindow = true, UseShellExecute = false, WorkingDirectory = Path.GetDirectoryName(SunshinePath) };
                newProc.RedirectStandardOutput = true;
                newProc.RedirectStandardError = true;
                var newProcInst = Process.Start(newProc);
                newProcInst.OutputDataReceived += OnSunshineStdout;
                newProcInst.ErrorDataReceived += OnSunshineStdout;
                newProcInst.BeginOutputReadLine();
                newProcInst.BeginErrorReadLine();
                DoLog("Sunshine started");
            }
        }

        Regex RxSunshineDetectState = new Regex("(CLIENT CONNECTED|CLIENT DISCONNECTED)", RegexOptions.Compiled);
        private void OnSunshineStdout(object sender, DataReceivedEventArgs e) {
            if (String.IsNullOrEmpty(e.Data))
                return;

            var states=RxSunshineDetectState.Matches(e.Data);
            for (var i = 0; i < states.Count; i++) {
                SunshineIsClientConnected = states[i].Value == "CLIENT CONNECTED";
                DoLog("Sunshine is " +(SunshineIsClientConnected?"active":"inactive") );
            }
        }

        private void OnSunshinePathClick(object sender, EventArgs e) {
            var ok = BrowseSunshinePath.ShowDialog(this);
            if (ok == DialogResult.OK)
                SunshinePath = BrowseSunshinePath.FileName;
            else
                SunshinePath = "";
        }

        private void OnInpSunshineChange(object sender, EventArgs e) {
            SunshinePath=InSunshinePath.Text;
            SunshineInit();
        }
    }
}