using System;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace NVStreamer1080 {
    public partial class ProcessEdit : Form {
        public ProcessEdit(AutoAction item) {
            Item = item;
            InitializeComponent();
            RefreshProcs_Click(null, null);
        }

        AutoAction Item = null;

        private void BtnConfirm_Click(object sender, EventArgs e) {
            Close();
        }

        private void ProcName_TextChanged(object sender, EventArgs e) {
            Item.Process=ProcName.Text;
        }

        private void RefreshProcs_Click(object sender, EventArgs e) {
            Processes.Items.Clear();
            Processes.Items.AddRange(Process.GetProcesses().Select(a => a.ProcessName).ToArray());
        }

        private void Processes_DoubleClick(object sender, EventArgs e) {
            if (Processes.SelectedItem!=null) {
                ProcName.Text = (string)Processes.SelectedItem;
                Item.Process = ProcName.Text;
            }
        }

        private void ProcessEdit_Load(object sender, EventArgs e) {
            ProcName.Text=Item.Process;
        }

    }
}
