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
    public partial class FirstArticleInspection : WinFormsUI.Docking.DockContent
    {
        Cs.InterfaceCheck interfaceCheck = new Cs.InterfaceCheck();
        public FirstArticleInspection()
        {
            InitializeComponent();
        }

        private void FirstArticleInspection_Load(object sender, EventArgs e)
        {
            this.Width = 1800;
            line.Width = Convert.ToInt32(this.Width);
        }

        private void GetFirstArticle_Click(object sender, EventArgs e)
        {
            label19.Text = "_";
            label20.Text = "_";
            Dictionary<string, object> loadFirstCheckItem = new Dictionary<string, object>();
            loadFirstCheckItem.Add("IP", Cs.GlobalVariable.IPv4);
            loadFirstCheckItem.Add("SHOP_ORDER", Cs.GlobalVariable.workOrder);
            Dictionary<string, object> returnMes = interfaceCheck.loadFirstCheckItem(loadFirstCheckItem);
            if (returnMes["STATUS"].ToString() == "false")
            {
                label19.Text = "_NG";
                label20.Text = "_" + returnMes["MESSAGE"].ToString();
                return;
            }
            label19.Text = "_OK";
            string[] label = new string[] { "检查项目:", "实测数据:"};
            if (returnMes.Count < 14)
            {
                AddLabel(10, 95, label[0]);
                AddPortraitLine(405, 85);
                AddLabel(410, 95, label[1]);
                AddPortraitLine(523, 85);
                AddTransverseLine(5, 119);
                label5.Width = 518;
            }
            else
            {
                AddLabel(10, 95, label[0]);
                AddPortraitLine(405, 85);
                AddLabel(410, 95, label[1]);
                AddPortraitLine(523, 85);
                AddLabel(530, 95, label[0]);
                AddPortraitLine(925, 85);
                AddLabel(930, 95, label[1]);
                AddPortraitLine(1043, 85);
                AddTransverseLine(5, 119);
                AddTransverseLine(525, 119);
                label5.Width = 1036;
            }
            label4.Height = 35;
            int cells = 0, rows = 0, x = 0, nameCount = 0;
            string scope = string.Empty;
            foreach (KeyValuePair<string, object> item in returnMes)
            {
                if (cells > 13)
                {
                    cells = 0;
                    x = 520;
                }
                if (item.Key != "STATUS")
                {
                    Dictionary<string, object> loadFirstCheckResualtFoot = (Dictionary<string, object>)item.Value;
                    AddLabel(10 + x, 130 + cells * 35, loadFirstCheckResualtFoot["ITEM_NAME"].ToString());
                    AddPortraitLine(5 + x + (rows + 1) * 400, 120 + cells * 35);
                    rows++;
                    AddText(410 + x, 130 + cells * 35, item.Key);
                    AddPortraitLine(123 + x + rows * 400, 120 + cells * 35);
                    rows = 0;
                    cells++; nameCount++;
                    AddTransverseLine(5 + x, 119 + cells * 35);
                    label4.Height = 35 * (nameCount - cells + 1);
                }
            }
        }

        private void AddLabel(int X, int Y, string strTwo)
        {
            Label label = new Label();
            label.Size = new Size(400, 13);
            this.Controls.Add(label);
            label.BringToFront();
            label.Location = new Point(X, Y);
            label.AutoSize = true;
            label.Text = strTwo;
        }
        private void AddTransverseLine(int X, int Y)
        {
            Label label = new Label();
            label.Size = new Size(555, 1);
            this.Controls.Add(label);
            label.BringToFront();
            label.Location = new Point(X, Y);
            label.BackColor = Color.Silver;
        }
        private void AddPortraitLine(int X, int Y)
        {
            Label label = new Label();
            label.Size = new Size(1, 35);
            this.Controls.Add(label);
            label.BringToFront();
            label.Location = new Point(X, Y);
            label.BackColor = Color.Silver;
        }
        private void AddText(int X, int Y, string name)
        {
            TextBox text = new TextBox();
            text.Size = new Size(100, 13);
            this.Controls.Add(text);
            text.BringToFront();
            text.Location = new Point(X, Y);
            text.Name = name;
        }
        private void SentToMesFirstArticle_Click(object sender, EventArgs e)
        {
            label19.Text = "_";
            label20.Text = "_";
            string textValueKey = string.Empty;
            Dictionary<string, object> textValue = new Dictionary<string, object>();
            foreach (Control control in this.Controls)
            {
                if (control is TextBox && control.Name.Contains("P"))
                {
                    textValue.Add(control.Name , control.Text.ToUpper());
                }
            }
            Dictionary<string, object> firstArticel = new Dictionary<string, object>();
            firstArticel.Add("SEQ", Cs.GlobalVariable.firstCheckCount .ToString());
            firstArticel.Add("PROCESS_CODE", Cs.GlobalVariable.procedureNo);
            firstArticel.Add("STATION_CODE", Cs.GlobalVariable.workStationNo);
            firstArticel.Add("IP", Cs.GlobalVariable.IPv4);
            firstArticel.Add("CHANNEL", 1);
            firstArticel.Add("SHOP_ORDER", Cs.GlobalVariable.workOrder);
            firstArticel.Add("CLASS_NO", Cs.GlobalVariable.classes);
            firstArticel.Add("INPUT_USER", Cs.GlobalVariable.userName);
            firstArticel.Add("PRD_USER", QRD.Text);
            firstArticel.Add("QA_USER", QA.Text);
            firstArticel.Add("MARK", MARK.Text);
            firstArticel.Add("DC_TIME", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            firstArticel.Add("P", textValue);
            try
            {
                Dictionary<string, object> returnMes = interfaceCheck.firstCheck(firstArticel);
                if (returnMes["STATUS"].ToString() == "false")
                {
                    Cs.GlobalVariable.firstCheckCount++;
                    label19.Text = "_NG";
                    label20.Text = "_" + returnMes["MESSAGE"].ToString();
                    MessageBox.Show(returnMes["MESSAGE"].ToString() + ",请修正参数后重新校验!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Cs.GlobalVariable.firstCheckCount++;
                    label19.Text = "_OK";
                    MessageBox.Show("首件首检参数已校验，参数已发送至MES系统!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information );
                }
            }
            catch (Exception)
            {
                MessageBox.Show("无法连接远程服务器,请检查网络连接或与管理员联系!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
