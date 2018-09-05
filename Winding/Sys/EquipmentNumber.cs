using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Winding.Cs;
using WinFormsUI.Docking;
namespace Winding.Sys
{
    public partial class EquipmentNumber : WinFormsUI.Docking.DockContent
    {
        Cs.Setting setting = new Cs.Setting();
        Cs.FileReadSave fileReadSave = new Cs.FileReadSave();
        public EquipmentNumber()
        {
            InitializeComponent();
            this.Width = 1800;
            line.Width = Convert.ToInt32(this.Width);
            setting.MenuBar();
        }

        private void EquipmentNumber_Load(object sender, EventArgs e)
        {
            equipmentEncoding.Text = fileReadSave.GetValue ("Setting", setting.Value(001), setting.Value(101));
            equipmentName.Text = fileReadSave.GetValue("Setting", setting.Value(001), setting.Value(102));
            equipmentType.Text = Cs.GlobalVariable.equipmentType;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            Cs.GlobalVariable.equipmentType = this.equipmentType.Text;
            fileReadSave.AddOrUpateValue("System", "Setting", setting.Value(001), setting.Value(101), this.equipmentEncoding.Text.ToUpper());
            fileReadSave.AddOrUpateValue("System", "Setting", setting.Value(001), setting.Value(102), this.equipmentName.Text.ToUpper());
            fileReadSave.AddOrUpateValue("System", "Setting", setting.Value(001), setting.Value(109), this.equipmentType.Text.ToUpper());
            MessageBox.Show("配置已保存至本地!下次启动将自动加载！", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void settingEnable_Tick(object sender, EventArgs e)
        {
            if (Cs.GlobalVariable.settingEnable )
            {
                equipmentEncoding.Enabled = true;
                equipmentName.Enabled = true;
                equipmentType.Enabled = true;
                Save.Enabled = true;
            }
            else
            {
                equipmentEncoding.Enabled = false;
                equipmentName.Enabled = false;
                equipmentType.Enabled = false;
                Save.Enabled = false;
            }
        }
    }
}
