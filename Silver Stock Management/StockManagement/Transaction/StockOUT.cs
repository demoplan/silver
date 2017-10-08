using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StockManagement.Utils;
using System.Data.OleDb;
using StockManagement.Properties;
using System.Text.RegularExpressions;

namespace StockManagement.Transaction
{
    public partial class StockOUT : Form
    {
        private bool cmbTagFlag = false;
        private int totalPcs = 0;
        private double totalNetWt = 0.00;
        private double totalDiamondWt = 0.00;
        private double totalStoneWt = 0.00;
        private Dictionary<String, String> stockOutList = new Dictionary<string, string>();
        public StockOUT()
        {
            InitializeComponent();
            dbUtils.connection();
            fillProductDesc();
            setDataGridWidth();
            dtDate.Value = DateTime.Today;
            this.ActiveControl = cmbProductDesc;
        }

        private void fillProductDesc()
        {
            String str = "SELECT ID, PNAME FROM PRODUCTM ORDER BY PNAME";
            DataTable prodTable = new DataTable();
            dbUtils.setComboProperty(ref cmbProductDesc, str, ref prodTable);
        }

        private void fillTagNo(ref object sender)
        {
            if (cmbProductDesc.Text.Length > 0)
            {
                cmbTagFlag = true;
                ComboBox reference = (ComboBox)sender;
                String str = "SELECT TNO,MetalType FROM TRANS WHERE PCODE = '" + cmbProductDesc.Text + "' AND OUTDATE IS NULL ORDER BY TNO";
                DataTable tagTable = new DataTable();
                tagTable = dbUtils.fill_ComboData(str);

                reference.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                reference.AutoCompleteSource = AutoCompleteSource.ListItems;
                reference.DisplayMember = "ID";
                reference.ValueMember = "ID";
                reference.DataSource = tagTable;
                cmbTagFlag = false;
            }
            else
            {
               // return null;
            }
        }

        private void cmbTagNo_Enter(object sender, EventArgs e)
        {
            cmbTagNo.DataSource = null;
            if(cmbTagFlag == false)
            fillTagNo(ref sender);
        }

        private void cmbTagNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            dbUtils.onlyDecimal(sender, ref e);
        }

        private void addDataToGrid()
        {
            if (stockOutList.ContainsKey(cmbProductDesc.Text + ":" + cmbTagNo.Text))
            {
                MessageBox.Show("This item is already been out.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (cmbProductDesc.Text.Length > 0 && cmbTagNo.Text.Length > 0)
            {
                string sqlQry = "SELECT * FROM TRANS WHERE PCODE = '" + cmbProductDesc.Text + "' AND TNO =" + cmbTagNo.Text + " AND OUTDATE IS NULL";
                OleDbDataReader oleDbDataReader = dbUtils.fetch(sqlQry);
                if (oleDbDataReader.HasRows)
                {

                    string filePath ;
                    oleDbDataReader.Read();
                    if (!oleDbDataReader["Photo"].Equals(DBNull.Value) && oleDbDataReader.GetString(8).Length > 0)
                    {
                        filePath = Application.StartupPath + "//Data//Images//" + oleDbDataReader.GetString(8);
                    }
                    else
                    {
                        filePath = "";
                    }
                    string productName = oleDbDataReader["Pcode"].ToString();
                    string tagNo = oleDbDataReader["Tno"].ToString();
                    int rowIndex = dgStockOut.Rows.Add();
                    DataGridViewRow row = dgStockOut.Rows[rowIndex];

                    if (filePath.Length > 0)
                    {
                        Image photo = Image.FromFile(filePath);
                        Image photoThumbnail =photo.GetThumbnailImage(100,100,null,new IntPtr());
                        row.Cells[0].Value = photoThumbnail;
                    }
                    else
                    {
                        row.Cells[0].Value = null;
                    }
                    row.Height = 100;
                    row.Cells[1].Value = productName;
                    row.Cells[2].Value = tagNo;
                    stockOutList.Add(productName + ":" + tagNo, productName + ":" + tagNo);
                    String metailDetail = String.Format("{0,-34}", "Metal Type") + oleDbDataReader.GetString(4) + Environment.NewLine + String.Format("{0,-40}", "PCS") + oleDbDataReader.GetInt16(5) + Environment.NewLine + String.Format("{0,-28}", "Gross Weight (grm)") + string.Format("{0:0,0.000}",oleDbDataReader.GetDouble(6)) + System.Environment.NewLine + String.Format("{0,-28}", "New Weight (grm)") + string.Format("{0:0,0.000}",oleDbDataReader.GetDouble(7));
                    totalPcs += oleDbDataReader.GetInt16(5);
                    totalNetWt += oleDbDataReader.GetDouble(7);
                    
                    row.Cells[3].Value = metailDetail;

                    //Retriving Diamond & Stone Details
                    StringBuilder diamondString = new StringBuilder();
                    StringBuilder stoneString = new StringBuilder();
                    string qry = "SELECT * FROM STONEDATA WHERE PID = " + oleDbDataReader.GetInt32(0);
                    OleDbDataReader reader = dbUtils.fetch(qry);
                    
                    if(reader.HasRows)
                    while (reader.Read())
                    {
                        if (reader.GetString(3).Equals("D"))
                        {
                            int space = 20 - reader.GetString(2).Trim().Length;
                            diamondString.Append(string.Format("{0,-" + space + "}", reader.GetString(2)) + string.Format("{0:0,0.00}", reader.GetDouble(4)) + Environment.NewLine);
                            totalDiamondWt += reader.GetDouble(4);
                        }
                        else 
                        {
                            int space = 30 - reader.GetString(2).Trim().Length;
                            stoneString.Append(string.Format("{0,-" + space + "}", reader.GetString(2)) + string.Format("{0:0,0.00}", reader.GetDouble(4)) + Environment.NewLine);
                            totalStoneWt += reader.GetDouble(4);
                        }
                    }
                    reader.Close();
                    row.Cells[4].Value = diamondString.ToString();
                    row.Cells[5].Value = stoneString;
                    row.Cells[6].Value = oleDbDataReader.GetInt32(0);
                    row.Cells[7].Value = "X";
 
                    //Display Update
                    updateSubTotal();
                }
            }
        }

        private void updateSubTotal()
        {
            txtTotalPcs.Text = totalPcs.ToString();
            txtNetWt.Text = string.Format("{0:0.000}", totalNetWt);
            txtDiamondWt.Text = string.Format("{0:0.00}", totalDiamondWt);
            txtStoneWt.Text = string.Format("{0:0.00}", totalStoneWt);
        }
        private void setDataGridWidth()
        {
            if (dgStockOut.ColumnCount > 6)
            {
                dgStockOut.Columns[1].Width = 100;
                dgStockOut.Columns[2].Width = 50;
                dgStockOut.Columns[3].Width = 260;
                dgStockOut.Columns[4].Width = 150;
                dgStockOut.Columns[5].Width = 200;
                dgStockOut.Columns[6].Width = 1;
            }
        }
        private void btnStockOut_Click(object sender, EventArgs e)
        {
            addDataToGrid();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void SaveData()
        {
            OleDbCommand oleDbCommand = new OleDbCommand();
            oleDbCommand.Connection=dbUtils.getConnection();
            OleDbTransaction trans = oleDbCommand.Connection.BeginTransaction();
            try
            {
               
                String sqlQry = "";

                foreach (DataGridViewRow row in dgStockOut.Rows)
                {
                    sqlQry = "UPDATE TRANS SET OUTDATE = #" + String.Format("{0:yyyy/MM/dd}", dtDate.Value) + "# WHERE TID = " + row.Cells[6].Value;
                    oleDbCommand.CommandText = sqlQry;
                    oleDbCommand.Transaction = trans;
                    oleDbCommand.ExecuteNonQuery();
                }
                trans.Commit();
                clearControl();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                MessageBox.Show(ex.Message);
                LoggingManager.WriteToLog(0, "Error : SaveData() : " + ex.Message);
            }
            finally 
            {
                oleDbCommand.Connection.Close();

            }
        }

        private void clearControl()
        {
            totalDiamondWt = 0.00;
            totalNetWt = 0.00;
            totalPcs = 0;
            totalStoneWt = 0.00;
            stockOutList.Clear();
            cmbTagNo.Text = "";
            dgStockOut.Rows.Clear();
            updateSubTotal();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            dbUtils.disConnect();
            Close();
        }

        private void dgStockOut_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 7)
                return;

            string[] metailDetail = dgStockOut.Rows[e.RowIndex].Cells[3].Value.ToString().Split('\n');
            if(metailDetail.Length == 4)
            {
                string pcs = metailDetail[1];
                string netWt = metailDetail[3];
                Match match = Regex.Match(pcs, @"\d+");
                Match matchNetWt = Regex.Match(netWt, @"\d+\.\d+");
                totalPcs -= int.Parse(match.Value);
                totalNetWt -= double.Parse(matchNetWt.Value);
            }

            string[] diamondDetail = dgStockOut.Rows[e.RowIndex].Cells[4].Value.ToString().Split('\n');
            foreach (string item in diamondDetail)
            {
                    Match match = Regex.Match(item, @"\d+\.\d+");
                    if (match.Success)
                    {
                        string matchValue = match.Value;
                        double diamondWt = double.Parse(matchValue);
                        totalDiamondWt -= diamondWt;
                    }
            }

            string[] stoneDetail = dgStockOut.Rows[e.RowIndex].Cells[5].Value.ToString().Split('\n');
            foreach (string item in stoneDetail)
            {
                Match match = Regex.Match(item, @"\d+\.\d+");
                if (match.Success)
                {
                    string matchValue = match.Value;
                    double stoneWt = double.Parse(matchValue);
                    totalStoneWt -= stoneWt;
                }
            }
            stockOutList.Remove(dgStockOut.Rows[e.RowIndex].Cells[1].Value.ToString() + ":" + dgStockOut.Rows[e.RowIndex].Cells[2].Value.ToString());
            dgStockOut.Rows.RemoveAt(e.RowIndex);
            updateSubTotal();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            //ModifyStockOut modifyStockOutForm = new ModifyStockOut();
            //modifyStockOutForm.ShowDialog();
        }
    }
}
