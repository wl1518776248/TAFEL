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
    public partial class MaterialConsumption : WinFormsUI.Docking.DockContent
    {
        Cs.Setting setting = new Cs.Setting();
        Cs.FileReadSave fileReadSave = new Cs.FileReadSave();
        public MaterialConsumption()
        {
            InitializeComponent();
        }

        private void MaterialConsumption_Load(object sender, EventArgs e)
        {
            setting.MenuBar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("a1", 1.1); dic.Add("a2", 1.2); dic.Add("a3", 1.3); dic.Add("a4", 1.4);

            fileReadSave.UpateValue(setting.Value(002),dic);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

            textBox1.Text = Cs.GlobalVariable.stateResult;
        }
    }
}
