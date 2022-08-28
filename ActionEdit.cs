using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NVStreamer1080 {
    public partial class ActionEdit : Form {
        public ActionEdit(AutoAction item) {
            Item = item;
            Process = new ProcessEdit(item);
            App = new ApplicationEdit(item);
            InitializeComponent();

        }

        readonly AutoAction Item;
        public ProcessEdit Process;
        public ApplicationEdit App;
        private void OnLoad(object sender, EventArgs e) {
            CbAbortOnInput.Checked = Item.AbortOnInput;
            NumDelay.Value =Item.Delay;
            TextDetails.Text = Item.ToString();

            RadioClose.Checked = Item.TargetAction == AutoAction.ActionType.Close;
            RadioKill.Checked = Item.TargetAction == AutoAction.ActionType.Kill;
            RadioLaunch.Checked = Item.TargetAction == AutoAction.ActionType.Open;
            //RadioExit.Checked = Item.TargetAction == AutoAction.ActionType.Exit;
            RadioSleep.Checked = Item.TargetAction == AutoAction.ActionType.Standby;
            RadioHibernate.Checked = Item.TargetAction == AutoAction.ActionType.Hibernate;
        }

        private void OnConfigure(object sender, EventArgs e) {
            if (RadioLaunch.Checked) {
                App.ShowDialog(this);
            } else if (RadioClose.Checked) {
                Process.ShowDialog(this);
            } else if (RadioKill.Checked) {
                Process.ShowDialog(this);
            } else {
                MessageBox.Show("Can't edit.", "Info");
            }
            OnLoad(null, null);
        }

        private void OnOk(object sender, EventArgs e) {
            Close();
        }

        private void CbAbortOnInput_CheckedChanged(object sender, EventArgs e) {
            Item.AbortOnInput=CbAbortOnInput.Checked;
            TextDetails.Text = Item.ToString();
        }

        private void NumDelay_ValueChanged(object sender, EventArgs e) {
            Item.Delay = (int)NumDelay.Value;
            TextDetails.Text = Item.ToString();
        }

        private void ActionTypeChanged(object sender, EventArgs e) {
            Item.TargetAction=RadioClose.Checked?AutoAction.ActionType.Close:
                RadioKill.Checked?AutoAction.ActionType.Kill:
                RadioHibernate.Checked ? AutoAction.ActionType.Hibernate :
                RadioSleep.Checked ? AutoAction.ActionType.Standby :
                AutoAction.ActionType.Open;
            TextDetails.Text = Item.ToString();
        }
    }
}
