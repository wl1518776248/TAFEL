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
    public partial class LocalFileClosed : WinFormsUI.Docking.DockContent
    {
        public LocalFileClosed()
        {
            InitializeComponent();
        }

        private void LocalFileClosed_Load(object sender, EventArgs e)
        {
            this.Width = 1800;
            line.Width = Convert.ToInt32(this.Width);            
        }

        private void GetFirstArticle_Click(object sender, EventArgs e)
        {
        }
    }
}
