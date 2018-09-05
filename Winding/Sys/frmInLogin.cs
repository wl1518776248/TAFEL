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
    public partial class frmInLogin : WinFormsUI.Docking.DockContent
    {
        Cs.Setting setting = new Cs.Setting();
        Cs.FileReadSave fileReadSave = new Cs.FileReadSave();
        Cs.MD5Encrypt MD5encrypt = new Cs.MD5Encrypt();
        public frmInLogin()
        {
            InitializeComponent();
        }

        private void frmInLogin_Load(object sender, EventArgs e)
        {
            setting.MenuBar();
        }

        private void userLogin_Click(object sender, EventArgs e)
        {
            if (userName.Text == "Admin" && MD5encrypt.GetMD5Encrypt(password.Text) == fileReadSave.GetValue("Setting", setting.Value(001), setting.Value(501)))
            {
                Cs.GlobalVariable.settingEnable = true;
                this.Hide();
            }
            else
            {
                MessageBox.Show("用户名或密码错误,请重新输入或与管理员联系!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Cs.GlobalVariable.settingEnable = false;
            this.Hide();
        }
    }
}
