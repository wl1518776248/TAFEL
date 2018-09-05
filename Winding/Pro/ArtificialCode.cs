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
    public partial class ArtificialCode : WinFormsUI.Docking.DockContent
    {
        public ArtificialCode()
        {
            InitializeComponent();
        }

        private void ArtificialCode_Load(object sender, EventArgs e)
        {
            this.Width = 1800;
            line.Width = Convert.ToInt32(this.Width);
        }

        private void Save_Click(object sender, EventArgs e)
        {

            if (Cs.GlobalVariable.mesInTen)
            {
                Cs.GlobalVariable.codeStr = CodeStr.Text.Trim();
                if (Cs.GlobalVariable.codeStr.Substring(0, 1) == Cs.GlobalVariable.equipmentType && (Cs.GlobalVariable.codeStr.Length == Convert.ToInt32(Cs.GlobalVariable.codeLengthOne) || Cs.GlobalVariable.codeStr.Length == Convert.ToInt32(Cs.GlobalVariable.codeLengthTwo) || Cs.GlobalVariable.codeStr.Length == Convert.ToInt32(Cs.GlobalVariable.codeLengthThree)))
                {
                    Cs.GlobalVariable.scanState = true;
                    MessageBox.Show("已成功手动扫码!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CodeStr.Text = string.Empty;
                }
                else
                {
                    MessageBox.Show("当前条码不符合条码规则,请检查后重新执行该操作!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
            }
            else
            {
                MessageBox.Show("当前设备无需处理的电芯,请检查后重新执行该操作!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
