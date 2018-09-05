using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Winding.Equ
{
    public partial class PointInspection : WinFormsUI.Docking.DockContent
    {
        Cs.InterfaceCheck interfaceCheck = new Cs.InterfaceCheck();
        public PointInspection()
        {
            InitializeComponent();
        }

        private void PointInspection_Load(object sender, EventArgs e)
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
            Dictionary<string, object> returnMes = interfaceCheck.loadSpotCheckItem(loadFirstCheckItem);
            if (returnMes["STATUS"].ToString() == "false")
            {
                label19.Text = "_NG";
                label20.Text = "_" + returnMes["MESSAGE"].ToString();
                return;
            }
            label19.Text = "_OK";
            string[] label = new string[] { "日点检与保养项目:", "项目状态:" };
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
            int cells = 0, x = 0, rows = 0, nameCount = 0;
            foreach (KeyValuePair<string, object> item in returnMes)
            {
                if (cells > 13)
                {
                    cells = 0;
                    x = 520;
                }
                if (item.Key != "STATUS")
                {
                    Dictionary<string, object> spotCheck = (Dictionary<string, object>)item.Value;
                    AddLabel(10 + x, 130 + cells * 35, spotCheck["ITEM_NAME"].ToString());
                    AddPortraitLine(5 + x + (rows + 1) * 400, 120 + cells * 35);
                    rows++;
                    AddCombox(410 + x, 130 + cells * 35, item.Key);
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
            label.Size = new Size(518, 1);
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

        private void AddCombox(int X, int Y, string name)
        {
            ComboBox comboBox = new ComboBox();
            comboBox.Size = new Size(100, 1);
            this.Controls.Add(comboBox);
            comboBox.BringToFront();
            comboBox.Location = new Point(X, Y);
            comboBox.Items.Add("正常");
            comboBox.Items.Add("异常");
            comboBox.Items.Add("待机");
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox.Name = name;
        }
        private void SentToMesFirstArticle_Click(object sender, EventArgs e)
        {
            label19.Text = "_";
            label20.Text = "_";
            string textValueKey = string.Empty;
            Dictionary<string, object> comboValue = new Dictionary<string, object>();
            foreach (Control control in this.Controls)
            {
                if (control is ComboBox && control.Name.Contains("P"))
                {
                    comboValue.Add(control.Name, control.Text.ToUpper());
                }
            }
            Dictionary<string, object> spotCheck = new Dictionary<string, object>();
            spotCheck.Add("SEQ", Cs.GlobalVariable.firstCheckCount.ToString());
            spotCheck.Add("PROCESS_CODE", Cs.GlobalVariable.procedureNo);
            spotCheck.Add("STATION_CODE", Cs.GlobalVariable.workStationNo);
            spotCheck.Add("IP", Cs.GlobalVariable.IPv4);
            spotCheck.Add("SHOP_ORDER", Cs.GlobalVariable.workOrder);
            spotCheck.Add("CLASS_NO", Cs.GlobalVariable.classes);
            spotCheck.Add("INPUT_USER", Cs.GlobalVariable.userName);
            spotCheck.Add("PRD_USER", QRD.Text);
            spotCheck.Add("MARK", MARK.Text);
            spotCheck.Add("DC_TIME", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            spotCheck.Add("P", comboValue);
            try
            {
                Dictionary<string, object> returnMes = interfaceCheck.spotCheck(spotCheck);
                if (returnMes["STATUS"].ToString() == "false")
                {
                    Cs.GlobalVariable.spotCheckCount++;
                    label19.Text = "_NG";
                    label20.Text = "_" + returnMes["MESSAGE"].ToString();
                    MessageBox.Show(returnMes["MESSAGE"].ToString() + ",请修正参数后重新校验!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Cs.GlobalVariable.spotCheckCount++;
                    label19.Text = "_OK";
                    MessageBox.Show("首件首检参数已校验，参数已发送至MES系统!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("无法连接远程服务器,请检查网络连接或与管理员联系!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
