using StockManagement.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Globalization;
using System.IO;

namespace StockManagement.Transaction
{
    public partial class ModifyStockIn : Form
    {
        public string preCondition;
        private StockIN callingForm;
        public int callingStatus;
        public ModifyStockIn()
        {
            InitializeComponent();
            dtToDate.Value = DateTime.Today;
            dtFromDate.Value = DateTime.Today.AddDays(-10);

        }

        public ModifyStockIn(StockIN stockIN)
        {
            InitializeComponent();
            dtToDate.Value = DateTime.Today;
            dtFromDate.Value = DateTime.Today.AddDays(-10);
            callingForm = stockIN;
        }

        private void formSqlQry()
        {
            //preCondition = " OUTDATE IS NULL";
            StringBuilder basicQry =new StringBuilder( "SELECT * FROM TRANS WHERE " + preCondition);

            if (chkDatewise.Checked)
            {
                basicQry.Append(" AND TDATE BETWEEN #" + String.Format("{0:yyyy/MM/dd}", dtFromDate.Value) + "# AND #" + String.Format("{0:yyyy/MM/dd}", dtToDate.Value) + "#");
            }

            if (chkProductwise.Checked)
            {
                if(cmbProductCode.Text.Length > 0)
                basicQry.Append(" AND PCODE = '" + cmbProductCode.Text + "'");

                if (txtNetWtFrom.Text.Length > 0 && txtNetWtTo.Text.Length > 0)
                {
                     basicQry.Append(" AND NW BETWEEN " + txtNetWtFrom.Text + " AND " + txtNetWtTo.Text);
                }

                if (txtTagNo.Text.Length > 0)
                {
                    basicQry.Append(" AND TNO = " + txtTagNo.Text);
                }


            }

            fill_DataGrid(basicQry.ToString());
            //dgModify.DataSource = resultTable;
        }

        private void fillItemCode()
        {
            String str = "SELECT DISTINCT ID,PNAME FROM PRODUCTM ORDER BY PNAME";
            DataTable prodTable = new DataTable();
            dbUtils.setComboProperty(ref cmbProductCode, str, ref prodTable);
        }
        private void fill_DataGrid(string sqlQry)
        {
            DataTable resultTable = new DataTable();
            OleDbDataReader oleDbDataReader = dbUtils.fetch(sqlQry);
            dgModify.Rows.Clear();
            if (oleDbDataReader.HasRows)
            {
                while (oleDbDataReader.Read())
                {
                    string filePath;
                    if (!oleDbDataReader["Photo"].Equals(DBNull.Value) && oleDbDataReader.GetString(8).Length > 0)
                    {
                        filePath = Application.StartupPath + "//Data//Images//" + oleDbDataReader.GetString(8);
                    }
                    else
                    {
                        filePath = Application.StartupPath + "//Data//Images//No_image.jpg";
                    }
                    string productName = oleDbDataReader["Pcode"].ToString();
                    string tagNo = oleDbDataReader["Tno"].ToString();
                    int rowIndex = dgModify.Rows.Add();
                    DataGridViewRow row = dgModify.Rows[rowIndex];
                    FileStream fs = null;
                    if (filePath.Length > 0 && System.IO.File.Exists(filePath))
                    {
                        fs = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite);
                        Image photo = Image.FromStream(fs);
                        Image photoThumbnail = photo.GetThumbnailImage(100, 100, null, new IntPtr());
                        row.Cells[0].Value = photoThumbnail;
                        fs.Close();
                    }
                    else
                    {
                        row.Cells[0].Value = null;
                    }
                    row.Height = 100;

                    row.Cells[1].Value = String.Format("{0:dd/MM/yyyy}", oleDbDataReader.GetDateTime(1));// DateTime.ParseExact(oleDbDataReader.GetDateTime(1).ToString(), "dd/MM/yyyy", new CultureInfo("en-IN"));
                    row.Cells[2].Value = productName;
                    row.Cells[3].Value = tagNo;
                    String metailDetail = String.Format("{0,-34}", "Metal Type") + oleDbDataReader.GetString(4) + Environment.NewLine + String.Format("{0,-40}", "PCS") + oleDbDataReader.GetInt16(5) + Environment.NewLine + String.Format("{0,-28}", "Gross Weight (grm)") + string.Format("{0:0,0.000}", oleDbDataReader.GetDouble(6)) + System.Environment.NewLine + String.Format("{0,-28}", "New Weight (grm)") + string.Format("{0:0,0.000}", oleDbDataReader.GetDouble(7));
                    row.Cells[4].Value = metailDetail;
                    
                    //Retriving Diamond & Stone Details
                    StringBuilder diamondString = new StringBuilder();
                    StringBuilder stoneString = new StringBuilder();
                    string qry = "SELECT * FROM STONEDATA WHERE PID = " + oleDbDataReader.GetInt32(0);
                    OleDbDataReader reader = dbUtils.fetch(qry);

                    if (reader.HasRows)
                        while (reader.Read())
                        {
                            if (reader.GetString(3).Equals("D"))
                            {
                                int space = 20 - reader.GetString(2).Trim().Length;
                                diamondString.Append(string.Format("{0,-" + space + "}", reader.GetString(2)) + string.Format("{0:0,0.00}", reader.GetDouble(4)) + Environment.NewLine);
                            }
                            else
                            {
                                int space = 30 - reader.GetString(2).Trim().Length;
                                stoneString.Append(string.Format("{0,-" + space + "}", reader.GetString(2)) + string.Format("{0:0,0.00}", reader.GetDouble(4)) + Environment.NewLine);
                            }
                        }
                    reader.Close();
                    row.Cells[5].Value = diamondString.ToString();
                    row.Cells[6].Value = stoneString;
                    row.Cells[7].Value = oleDbDataReader.GetInt32(0);
                }
            }
        }
        private void chkDatewise_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDatewise.Checked)
            {
                dtFromDate.Enabled = true;
                dtToDate.Enabled = true;
            }
            else 
            {
                dtFromDate.Enabled = false;
                dtToDate.Enabled = false;
            }
        }

        private void chkProductwise_CheckedChanged(object sender, EventArgs e)
        {
            if (chkProductwise.Checked)
            {
                txtNetWtFrom.Enabled = true;
                txtNetWtTo.Enabled = true;
                cmbProductCode.Enabled = true;
                txtTagNo.Enabled = true;

                if (cmbProductCode.Items.Count == 0)
                {
                    fillItemCode();
                }
            }
            else
            {
                txtNetWtFrom.Enabled = false;
                txtNetWtTo.Enabled = false;
                cmbProductCode.Enabled = false;
                txtTagNo.Enabled = false;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            dbUtils.disConnect();
            Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            formSqlQry();
            ActiveControl = dgModify;
        }

        private void pbSearch_Click(object sender, EventArgs e)
        {
            formSqlQry();
        }

        private void dgModify_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (callingStatus == 1)
            {
                callingForm.loadDataToModify(dgModify.Rows[e.RowIndex].Cells[7].Value.ToString());
            }
            else
            {
                callingForm.loadDataToModifyC(dgModify.Rows[e.RowIndex].Cells[7].Value.ToString());
            }
           dbUtils.disConnect();
           Close();
        }

        private void txtNetWtFrom_KeyPress(object sender, KeyPressEventArgs e)
        {
            dbUtils.onlyDecimal(sender, ref e);
        }

        private void txtNetWtTo_KeyPress(object sender, KeyPressEventArgs e)
        {
            dbUtils.onlyDecimal(sender, ref e);
        }

    }
}
