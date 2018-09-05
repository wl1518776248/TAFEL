using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Winding.Pro
{
    public partial class CodeProtected : WinFormsUI.Docking.DockContent
    {
        Cs.Setting setting = new Cs.Setting();
        Cs.FileReadSave fileReadSave = new Cs.FileReadSave();
        public CodeProtected()
        {
            InitializeComponent();
        }

        private void CodeProtected_Load(object sender, EventArgs e)
        {
            this.Width = 1800;
            line.Width = Convert.ToInt32(this.Width);
            setting.MenuBar();
            codeLengthOne.Text = Cs.GlobalVariable.codeLengthOne;
            codeLengthTwo.Text = Cs.GlobalVariable.codeLengthTwo;
            codeLengthThree.Text = Cs.GlobalVariable.codeLengthThree;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            Cs.GlobalVariable.codeLengthOne = this.codeLengthOne.Text;
            Cs.GlobalVariable.codeLengthTwo = this.codeLengthTwo.Text;
            Cs.GlobalVariable.codeLengthThree = this.codeLengthThree.Text;
            fileReadSave.AddOrUpateValue("System", "Setting", setting.Value(001), setting.Value(401), this.codeLengthOne.Text);
            fileReadSave.AddOrUpateValue("System", "Setting", setting.Value(001), setting.Value(402), this.codeLengthTwo.Text);
            fileReadSave.AddOrUpateValue("System", "Setting", setting.Value(001), setting.Value(403), this.codeLengthThree.Text);
            MessageBox.Show("配置已保存至本地!下次启动将自动加载！", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void settingEnable_Tick(object sender, EventArgs e)
        {
            if (Cs.GlobalVariable.settingEnable)
            {
                codeLengthOne.Enabled = true;
                codeLengthTwo.Enabled = true;
                codeLengthThree.Enabled = true;
                Save.Enabled = true;
            }
            else
            {
                codeLengthOne.Enabled = false;
                codeLengthTwo.Enabled = false;
                codeLengthThree.Enabled = false;
                Save.Enabled = false;
            }
        }
    }
}
