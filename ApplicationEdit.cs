using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NVStreamer1080 {
    public partial class ApplicationEdit : Form {
        public ApplicationEdit(AutoAction item) {
            Item = item;
            InitializeComponent();
        }

        readonly AutoAction Item;
        private void OnBrowse(object sender, EventArgs e) {
            var result=BrowseExe.ShowDialog(this);
            if(result == DialogResult.OK) {
                AppPath.Text = BrowseExe.FileName;
                AppDir.Text = Path.GetDirectoryName(BrowseExe.FileName);
                Item.Process=AppPath.Text;
                Item.WorkingDirectory = AppDir.Text;
            }
                
        }

        private void BtnConfirm_Click(object sender, EventArgs e) {
            Close();
        }

        private void ApplicationEdit_Load(object sender, EventArgs e) {
            AppPath.Text=Item.Process;
            AppDir.Text=Item.WorkingDirectory;
        }

        private void AppPath_TextChanged(object sender, EventArgs e) {
            Item.Process=AppPath.Text;
            Item.WorkingDirectory=AppDir.Text;
        }
    }
}
