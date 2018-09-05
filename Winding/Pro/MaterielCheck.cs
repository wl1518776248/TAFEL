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

namespace Winding.Pro
{
    public partial class MaterielCheck : WinFormsUI.Docking.DockContent
    {
        Cs.VariableChangedEven variableChangedEven = new VariableChangedEven();
        Cs.InterfaceCheck variableChangedCheck = new Cs.InterfaceCheck();
        Cs.InterfaceCheck loadMaterial = new Cs.InterfaceCheck();
        Cs.Setting setting = new Cs.Setting();
        Cs.FileReadSave fileReadSave = new Cs.FileReadSave();
        public MaterielCheck()
        {
            InitializeComponent();
        }

        private void MaterielCheck_Load(object sender, EventArgs e)
        {
            setting.MenuBar();
            Cs.GlobalVariable.workOrder = fileReadSave.GetValue("Material", setting.Value(001), setting.Value(201));
            for (int i = 0; i < 5; i++)
            {
                Cs.GlobalVariable.materielBatch[meterieCheck.Rows.Count] = fileReadSave.GetValue("Material", setting.Value(001), setting.Value(i * 5 + 202));
                Cs.GlobalVariable.materielCheckQuantity[meterieCheck.Rows.Count] = fileReadSave.GetValue("Material", setting.Value(001), setting.Value(i * 5 + 203));
                if (fileReadSave.GetValue("Setting", setting.Value(001), setting.Value(i * 5 + 201)) != string.Empty)
                {
                    meterieCheck.Rows.Add();
                    meterieCheck.Rows[meterieCheck.Rows.Count - 1].Cells[0].Value = "物料下料";
                    meterieCheck.Rows[meterieCheck.Rows.Count - 1].Cells[1].Value = fileReadSave.GetValue("Material", setting.Value(001), setting.Value(i * 5 + 201));
                    meterieCheck.Rows[meterieCheck.Rows.Count - 1].Cells[2].Value = fileReadSave.GetValue("Material", setting.Value(001), setting.Value(i * 5 + 202));
                    meterieCheck.Rows[meterieCheck.Rows.Count - 1].Cells[3].Value = fileReadSave.GetValue("Material", setting.Value(001), setting.Value(i * 5 + 203));
                    meterieCheck.Rows[meterieCheck.Rows.Count - 1].Cells[4].Value = fileReadSave.GetValue("Material", setting.Value(001), setting.Value(i * 5 + 204));
                    meterieCheck.Rows[meterieCheck.Rows.Count - 1].Cells[5].Value = fileReadSave.GetValue("Material", setting.Value(001), setting.Value(i * 5 + 205));
                }
            }
        }

        private void check_Click(object sender, EventArgs e)
        {
            if (meterieCheck.Rows.Count > 4)
            {
                MessageBox.Show("系统检测上料代码过多，请先执行下料操作！", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Dictionary<string, object> materielData = new Dictionary<string, object>();
            materielData.Add("IP", Cs.GlobalVariable.IPv4);
            materielData.Add("SHOP_ORDER", workOrder.Text);
            Dictionary<string, object> batch = new Dictionary<string, object>();
            batch.Add("BATCH_NO", materielBatch.Text);
            batch.Add("LOAD_QTY", quantity.Text);
            materielData.Add("BATCH", batch);
            Dictionary<string, object> proSate = loadMaterial.LoadMaterial(materielData);
            if (proSate["STATUS"].ToString() == "false")
            {
                meterialCheckResult.Text = "_" + Cs.GlobalVariable.state.NG;
                meterialCheckMessage.Text = "_" + proSate["MESSAGE"].ToString();
                MessageBox.Show("物料上料校验状态:" + proSate["STATUS"].ToString() + " _失败原因:" + proSate["MESSAGE"].ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (proSate["STATUS"].ToString() == "true")
            {
                meterieCheck.Rows.Add();
                meterieCheck.Rows[meterieCheck.Rows.Count - 1].Cells[0].Value = "物料下料";
                meterieCheck.Rows[meterieCheck.Rows.Count - 1].Cells[1].Value = workOrder.Text;
                meterieCheck.Rows[meterieCheck.Rows.Count - 1].Cells[2].Value = materielBatch.Text;
                meterieCheck.Rows[meterieCheck.Rows.Count - 1].Cells[3].Value = quantity.Text;
                meterieCheck.Rows[meterieCheck.Rows.Count - 1].Cells[4].Value = Cs.GlobalVariable.userName;
                meterieCheck.Rows[meterieCheck.Rows.Count - 1].Cells[5].Value = DateTime.Now.ToString("MM-dd HH:mm:ss");
                ClearValue();
                Cs.GlobalVariable.workOrder = workOrder.Text;
                Cs.GlobalVariable.materielBatch[meterieCheck.Rows.Count - 1] = materielBatch.Text;
                Cs.GlobalVariable.materielCheckQuantity[meterieCheck.Rows.Count - 1] = materielBatch.Text;
                for (int i = 0; i < meterieCheck.Rows.Count; i++)
                {
                    fileReadSave.AddOrUpateValue("System", "Setting", setting.Value(001), setting.Value(i * 5 + 201), meterieCheck.Rows[i].Cells[1].Value.ToString());
                    fileReadSave.AddOrUpateValue("System", "Setting", setting.Value(001), setting.Value(i * 5 + 202), meterieCheck.Rows[i].Cells[2].Value.ToString());
                    fileReadSave.AddOrUpateValue("System", "Setting", setting.Value(001), setting.Value(i * 5 + 203), meterieCheck.Rows[i].Cells[3].Value.ToString());
                    fileReadSave.AddOrUpateValue("System", "Setting", setting.Value(001), setting.Value(i * 5 + 204), meterieCheck.Rows[i].Cells[4].Value.ToString());
                    fileReadSave.AddOrUpateValue("System", "Setting", setting.Value(001), setting.Value(i * 5 + 205), meterieCheck.Rows[i].Cells[5].Value.ToString());
                }
                meterialCheckResult.Text = "_" + Cs.GlobalVariable.state.OK;
                meterialCheckMessage.Text = "_";
            }
        }

        private void meterieCheck_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewColumn column = meterieCheck.Columns[e.ColumnIndex];
                if (column is DataGridViewButtonColumn)
                {
                    if (MessageBox.Show("确定要对批次号:" + meterieCheck.Rows[meterieCheck.CurrentRow.Index].Cells[2].Value + " 进行下料操作么?", "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        Dictionary<string, object> materielData = new Dictionary<string, object>();
                        materielData.Add("IP", Cs.GlobalVariable.IPv4);
                        materielData.Add("SHOP_ORDER", meterieCheck.Rows[meterieCheck.CurrentRow.Index].Cells[1].Value);
                        Dictionary<string, object> materielDataBatch = new Dictionary<string, object>();
                        materielDataBatch.Add("BATCH_NO", meterieCheck.Rows[meterieCheck.CurrentRow.Index].Cells[2].Value);
                        materielData.Add("BATCH", materielDataBatch);
                        try
                        {
                            Dictionary<string, object> proSate = loadMaterial.UnLoadMaterial(materielData);
                            if (proSate["STATUS"].ToString() == "false")
                            {
                                MessageBox.Show("物料下料校验状态:" + proSate["STATUS"].ToString() + " _失败原因:" + proSate["MESSAGE"].ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else if (proSate["STATUS"].ToString() == "True")
                            {

                                MessageBox.Show("物料下料校验状态:" + proSate["STATUS"].ToString(), "Imformation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            ClearValue();
                            for (int i = 0; i < meterieCheck.Rows.Count; i++)
                            {
                                Cs.GlobalVariable.materielBatch[meterieCheck.Rows.Count - 1] = meterieCheck.Rows[i].Cells[2].Value.ToString();
                                Cs.GlobalVariable.materielCheckQuantity[meterieCheck.Rows.Count - 1] = meterieCheck.Rows[i].Cells[3].Value.ToString();
                                fileReadSave.AddOrUpateValue("System", "Setting", setting.Value(001), setting.Value(i * 5 + 201), meterieCheck.Rows[i].Cells[1].Value.ToString());
                                fileReadSave.AddOrUpateValue("System", "Setting", setting.Value(001), setting.Value(i * 5 + 202), meterieCheck.Rows[i].Cells[2].Value.ToString());
                                fileReadSave.AddOrUpateValue("System", "Setting", setting.Value(001), setting.Value(i * 5 + 203), meterieCheck.Rows[i].Cells[3].Value.ToString());
                                fileReadSave.AddOrUpateValue("System", "Setting", setting.Value(001), setting.Value(i * 5 + 204), meterieCheck.Rows[i].Cells[4].Value.ToString());
                                fileReadSave.AddOrUpateValue("System", "Setting", setting.Value(001), setting.Value(i * 5 + 205), meterieCheck.Rows[i].Cells[5].Value.ToString());
                            }
                            meterieCheck.Rows.RemoveAt(meterieCheck.CurrentRow.Index);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("无法连接远程服务器,请检查网络连接或与管理员联系!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void ClearValue()
        {
            for (int i = 0; i < 5; i++)
            {
                Cs.GlobalVariable.materielBatch[i] = string.Empty;
                Cs.GlobalVariable.materielCheckQuantity[i] = string.Empty;
                fileReadSave.AddOrUpateValue("System", "Setting", setting.Value(001), setting.Value(i * 5 + 201), string.Empty);
                fileReadSave.AddOrUpateValue("System", "Setting", setting.Value(001), setting.Value(i * 5 + 202), string.Empty);
                fileReadSave.AddOrUpateValue("System", "Setting", setting.Value(001), setting.Value(i * 5 + 203), string.Empty);
                fileReadSave.AddOrUpateValue("System", "Setting", setting.Value(001), setting.Value(i * 5 + 204), string.Empty);
                fileReadSave.AddOrUpateValue("System", "Setting", setting.Value(001), setting.Value(i * 5 + 205), string.Empty);
            }
        }
    }
}
