using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Winding.Sys
{
    public partial class SingleNetwork : WinFormsUI.Docking.DockContent
    {
        Cs.FileReadSave fileReadSave = new Cs.FileReadSave();
        Cs.Setting setting = new Cs.Setting();
        public SingleNetwork()
        {
            InitializeComponent();
            this.Width = 1800;
            line.Width = Convert.ToInt32(this.Width);
            setting.MenuBar();
        }

        private void SingleNetwork_Load(object sender, EventArgs e)
        {            
            txtSetProcessName.Text = fileReadSave.GetValue("Setting", setting.Value(001), setting.Value(110));
        }

        private void Save_Click(object sender, EventArgs e)
        {
            Cs.GlobalVariable.processName = this.txtSetProcessName.Text;
            fileReadSave.AddOrUpateValue("System", "Setting", setting.Value(001), setting.Value(110), this.txtSetProcessName.Text);
            MessageBox.Show("配置已保存至本地!下次启动将自动加载！", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void GetProcessName_Click(object sender, EventArgs e)
        {
            Process[] pro = Process.GetProcesses();
            for (int i = 0; i < pro.Length; i++)
            {
                if (pro[i].ProcessName.ToString() == "EXCEL")
                {
                    txtGetProcessName.Text = pro[i].MainWindowTitle;
                }
            }
        }

        private void settingEnable_Tick(object sender, EventArgs e)
        {
            if (Cs.GlobalVariable.settingEnable)
            {
                txtGetProcessName.Enabled = true;
                txtSetProcessName.Enabled = true;
                Save.Enabled = true;
                GetProcessName.Enabled = true;
            }
            else
            {
                txtGetProcessName.Enabled = false;
                txtSetProcessName.Enabled = false;
                Save.Enabled = false;
                GetProcessName.Enabled = false;
            }
        }
    }
}
