using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Winding.Sys
{
    public partial class PortManage : WinFormsUI.Docking.DockContent
    {
        Cs.Setting setting = new Cs.Setting();
        Cs.FileReadSave fileReadSave = new Cs.FileReadSave();
        public PortManage()
        {
            InitializeComponent();
            this.Width = 1800;
            line.Width = Convert.ToInt32(this.Width);
            setting.MenuBar();
        }

        private void PortManage_Load(object sender, EventArgs e)
        {
            MesPort.Text = fileReadSave.GetValue("Setting", setting.Value(001), setting.Value(105));
        }

        private void Save_Click(object sender, EventArgs e)
        {
            fileReadSave.AddOrUpateValue("System", "Setting", setting.Value(001), setting.Value(105), this.MesPort.Text);
            MessageBox.Show("配置已保存至本地!下次启动将自动加载！", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void settingEnable_Tick(object sender, EventArgs e)
        {
            if (Cs.GlobalVariable.settingEnable)
            {
                MesPort.Enabled = true;
                Save.Enabled = true;
            }
            else
            {
                MesPort.Enabled = false;
                Save.Enabled = false;
            }
        }
    }
}
