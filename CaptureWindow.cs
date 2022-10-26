
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace NVStreamer1080 {
    public partial class CaptureWindow : Form {
        public CaptureWindow(NVStreamerMainUI mainUI) {
            MainUI = mainUI;
            InitializeComponent();
        }

        readonly NVStreamerMainUI MainUI;
        private void CaptureWindow_KeyDown(object sender, KeyEventArgs e) {
            InputDetected();
        }


        int MouseX = -1;
        int MouseY = -1;
        private void CaptureWindow_MouseMove(object sender, MouseEventArgs e) {
            if (MouseX < 0) {
                MouseX = e.X; MouseY = e.Y; 
                return;
            }
            if(Math.Abs(MouseX-e.X)>64 || Math.Abs(MouseY - e.Y) > 64)
                InputDetected();
        }

        private void InputDetected() {
            // Skip first second to avoid random events
            if (DateTime.Now<InitTime.AddSeconds(1))
                return;

            MainUI.ActionsScheduled= MainUI.ActionsScheduled.Where(a=>!a.ScheduledAction.AbortOnInput).ToList();
            MainUI.CaptureOverlay = null;
            Close();
        }

        public DateTime InitTime = DateTime.Now;
        private void CaptureWindow_Load(object sender, System.EventArgs e) {
        }
    }
}
