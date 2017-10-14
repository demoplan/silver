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
    public partial class ModifyStockOut : Form
    {
        private Sales callingForm;
        public int callingStatus;
        private Dictionary<int, string> customerDictonary = new Dictionary<int, string>();

        public ModifyStockOut(Sales saleForm)
        {
            InitializeComponent();
            dtToDate.Value = DateTime.Today;
            dtFromDate.Value = DateTime.Today.AddDays(-10);
            populateCustomerDictionary();
            callingStatus = 1;
            callingForm = saleForm;
        }

        public ModifyStockOut(StockOUT stockOUT)
        {
            InitializeComponent();
            dtToDate.Value = DateTime.Today;
            dtFromDate.Value = DateTime.Today.AddDays(-10);
            //callingForm = stockOUT;
        }

        private void populateCustomerDictionary()
        {
            string sqlQry = "SELECT ID,CNAME FROM CUSTOMERM";
            OleDbDataReader reader = dbUtils.fetch(sqlQry);
            customerDictonary.Clear();

            if(reader.HasRows)
            {
                while(reader.Read())
                {
                    customerDictonary.Add(reader.GetInt32(0), reader.GetString(1));
                }
            }
            reader.Close();
        }

        private void formSqlQry()
        {
            StringBuilder basicQry = new StringBuilder("SELECT * FROM SALES WHERE TOTALAMT IS NOT NULL ");

            if (chkDatewise.Checked)
            {
                basicQry.Append(" AND VDATE BETWEEN #" + String.Format("{0:yyyy/MM/dd}", dtFromDate.Value) + "# AND #" + String.Format("{0:yyyy/MM/dd}", dtToDate.Value) + "#");
            }

            if (chkSalesBillWise.Checked)
            {
                if (cmbCustomer.SelectedIndex > 0)
                    basicQry.Append(" AND CID = '" + cmbCustomer.SelectedValue + "'");

                if (txtBillAmtFrom.Text.Length > 0 && txtBillAmtTo.Text.Length > 0)
                {
                    basicQry.Append(" AND TOTALAMT BETWEEN " + txtBillAmtFrom.Text + " AND " + txtBillAmtTo.Text);
                }

                if (txtBillNo.Text.Length > 0)
                {
                    basicQry.Append(" AND VNO = " + txtBillNo.Text);
                }
            }

            fill_DataGrid(basicQry.ToString());
            //dgModify.DataSource = resultTable;
        }

        private void fillCustomerCode()
        {
            String str = "SELECT DISTINCT ID,CNAME FROM CUSTOMERM ORDER BY CNAME";
            DataTable prodTable = new DataTable();
            dbUtils.setComboProperty(ref cmbCustomer, str, ref prodTable);
            DataRow dataRow = prodTable.NewRow();
            dataRow[0] = -1;
            dataRow[1] = "<Select Customer>";
            prodTable.Rows.InsertAt(dataRow, 0);
            cmbCustomer.SelectedIndex = 0;
        }



        private void fill_DataGrid(string sqlQry)
        {
            DataTable resultTable = new DataTable();
            OleDbDataReader oleDbDataReader = dbUtils.fetch(sqlQry);
            //DataTable salesTable = new DataTable();
            //salesTable.Load(oleDbDataReader);
            //dgModify.DataSource = salesTable;
            //return;
            dgModify.Rows.Clear();
            if (oleDbDataReader.HasRows)
            {
                while (oleDbDataReader.Read())
                {
                    int rowIndex = dgModify.Rows.Add();
                    DataGridViewRow row = dgModify.Rows[rowIndex];
                    row.Cells[0].Value = oleDbDataReader.GetInt32(0);                           //id
                    row.Cells[1].Value = oleDbDataReader.GetDateTime(1).ToShortDateString();    //date
                    row.Cells[2].Value = oleDbDataReader.GetInt32(2);                           //sales invoice no
                    row.Cells[3].Value = customerDictonary[oleDbDataReader.GetInt32(3)];        //customer name
                    row.Cells[4].Value = dbUtils.Decimal2digit(oleDbDataReader.GetDouble(4).ToString());         //Gross Amt
                    row.Cells[5].Value = dbUtils.Decimal2digit(oleDbDataReader.GetDouble(5).ToString());         //Vat rate
                    row.Cells[6].Value = dbUtils.Decimal2digit(oleDbDataReader.GetDouble(6).ToString());         //Vat amt
                    row.Cells[7].Value = dbUtils.Decimal2digit(oleDbDataReader.GetDouble(7).ToString());         //round off
                    row.Cells[8].Value = dbUtils.Decimal2digit(oleDbDataReader.GetDouble(8).ToString());         //total amt
                    row.Cells[9].Value = oleDbDataReader.GetString(9);                                           //pancard
                    row.Cells[10].Value = oleDbDataReader.GetInt32(3);                                           //CID
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
            if (chkSalesBillWise.Checked)
            {
                txtBillAmtFrom.Enabled = true;
                txtBillAmtTo.Enabled = true;
                cmbCustomer.Enabled = true;
                txtBillNo.Enabled = true;
                if (cmbCustomer.Items.Count == 0)
                {
                    fillCustomerCode();
                }
            }
            else
            {
                txtBillAmtFrom.Enabled = false;
                txtBillAmtTo.Enabled = false;
                cmbCustomer.Enabled = false;
                txtBillNo.Enabled = false;
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
            dgModify.AutoResizeColumns();
        }

        private void pbSearch_Click(object sender, EventArgs e)
        {
            formSqlQry();
        }

        private SaleBillInfo getSalesBillDetail(int rowIndex)
        {
            SaleBillInfo saleBillInfo = new SaleBillInfo();

            saleBillInfo.Id = int.Parse(dgModify.Rows[rowIndex].Cells[0].Value.ToString());
            saleBillInfo.VDate = DateTime.Parse(dgModify.Rows[rowIndex].Cells[1].Value.ToString());
            saleBillInfo.Vno = int.Parse(dgModify.Rows[rowIndex].Cells[2].Value.ToString());
            saleBillInfo.Cid = int.Parse(dgModify.Rows[rowIndex].Cells[10].Value.ToString());
            saleBillInfo.GrossAmt = double.Parse(dgModify.Rows[rowIndex].Cells[4].Value.ToString());
            saleBillInfo.VatRate = double.Parse(dgModify.Rows[rowIndex].Cells[5].Value.ToString());
            saleBillInfo.VatAmt = double.Parse(dgModify.Rows[rowIndex].Cells[6].Value.ToString());
            saleBillInfo.RoundOff = double.Parse(dgModify.Rows[rowIndex].Cells[7].Value.ToString());
            saleBillInfo.TotalAmt = double.Parse(dgModify.Rows[rowIndex].Cells[8].Value.ToString());
            saleBillInfo.Pancard = dgModify.Rows[rowIndex].Cells[9].Value.ToString();
            return saleBillInfo;
        }

        private void dgModify_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (callingStatus == 1)
            {
                SaleBillInfo saleBillInfo = getSalesBillDetail(e.RowIndex);
                callingForm.loadSalesDataToModify(saleBillInfo);
            }
            else
            {
                //callingForm.loadDataToModifyC(dgModify.Rows[e.RowIndex].Cells[7].Value.ToString());
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

        private void dgModify_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 8)
                return;
            if (MessageBox.Show("Are you sure want to cancel stock out ?", "Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                bool IsTagStillAvailable = checkUniqueTag(dgModify.Rows[e.RowIndex].Cells[2].Value.ToString(), int.Parse(dgModify.Rows[e.RowIndex].Cells[3].Value.ToString()));
                if (IsTagStillAvailable)
                {
                    CancelStockOut(dgModify.Rows[e.RowIndex].Cells[7].Value.ToString());
                    formSqlQry();
                }
                else
                {
                    MessageBox.Show("New item are added against this Tag. You are requested to change the tag no of newly added item then try again.");
                }
            }
        }

        private void CancelStockOut(string tid)
        {
            string sqlQry = "UPDATE TRANS SET OUTDATE=NULL WHERE TID="+ tid;
            dbUtils.saveToDB(sqlQry);
        }

        private bool checkUniqueTag(string pcode, int tagNo)
        {
            string sqlQry = "SELECT TNO FROM TRANS WHERE PCODE ='" + pcode + "'  AND OUTDATE is NULL AND TNO = " + tagNo;
            int result = dbUtils.FetchInteger(sqlQry);
            if (result == -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
