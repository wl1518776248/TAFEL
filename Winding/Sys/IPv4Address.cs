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
    public partial class IPv4Address : WinFormsUI.Docking.DockContent
    {
        Cs.Setting setting = new Cs.Setting();
        Cs.FileReadSave fileReadSave = new Cs.FileReadSave();
        public IPv4Address()
        {
            InitializeComponent();
            this.Width = 1800;
            line.Width = Convert.ToInt32(this.Width);
            setting.MenuBar();
        }

        private void IPv4Address_Load(object sender, EventArgs e)
        {
            equipmentIPv4.Text = fileReadSave.GetValue("Setting", setting.Value(001), setting.Value(103));
            PLCIPv4.Text = fileReadSave.GetValue("Setting", setting.Value(001), setting.Value(104));
        }

        private void Save_Click(object sender, EventArgs e)
        {
            Cs.GlobalVariable.IPv4= this.equipmentIPv4.Text;
            fileReadSave.AddOrUpateValue("System", "Setting", setting.Value(001), setting.Value(103), this.equipmentIPv4.Text.ToUpper());
            fileReadSave.AddOrUpateValue("System", "Setting", setting.Value(001), setting.Value(104), this.PLCIPv4.Text.ToUpper());
            MessageBox.Show("配置已保存至本地!下次启动将自动加载！", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void settingEnable_Tick(object sender, EventArgs e)
        {
            if (Cs.GlobalVariable.settingEnable)
            {
                equipmentIPv4.Enabled = true;
                PLCIPv4.Enabled = true;
                Save.Enabled = true;
            }
            else
            {
                equipmentIPv4.Enabled = false;
                PLCIPv4.Enabled = false;
                Save.Enabled = false;
            }
        }
    }
}
