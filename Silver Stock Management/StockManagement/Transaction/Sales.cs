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
using System.IO;
using StockManagement.Report;
using StockManagement.Report.CrystalReport;

namespace StockManagement.Transaction
{
    public partial class Sales : Form
    {
        private bool cmbTagFlag = false;
        private int totalPcs = 0;
        private double totalNetWt = 0.00;
        private double totalDiamondWt = 0.00;
        private double totalStoneWt = 0.00;
        private Image defaultNoImage = null;
        private List<SalesLineItemDetail> saleGridLineItem = new List<SalesLineItemDetail>();
        public DateTime selectedDate;
        private int formLoadBillNo = 0;
        private string customerName;
        private string customerAddress;

        public Sales()
        {
            InitializeComponent();
            dbUtils.connection();
            fillProductDesc();
            setDefaultNoImage();
            dtDate.Value = DateTime.Today;
            this.ActiveControl = cmbProductDesc;
            getVatRate();
            setSalesBillNo();
            object cmboCustome = cmbCustomer;
            fillCustomerDetail(ref  cmboCustome);
        }

        private void setSalesBillNo()
        {
            String str = "SELECT MAX(VNO) FROM SALES";
            int value = dbUtils.FetchInteger(str);
            if (value == -1)
            {
                txtBillNo.Text = (1).ToString();
                formLoadBillNo = 1;
            }
            else
            {
                txtBillNo.Text = (value + 1).ToString();
                formLoadBillNo = (value + 1);
            }
        }

        private void getVatRate()
        {
            String str = "SELECT KVALUE FROM SETTING WHERE KEY = 'VATRATE'";
            string value = dbUtils.FetchString(str);
            if (value.Length > 0)
            {
                lblVatRate.Text = value;
            }
        }   

        private void fillProductDesc()
        {
            String str = "SELECT ID, PNAME FROM PRODUCTM ORDER BY PNAME";
            DataTable prodTable = new DataTable();
            dbUtils.setComboProperty(ref cmbProductDesc, str, ref prodTable);
        }

        private void fillCustomerDetail(ref object sender)
        {
            if (cmbProductDesc.Text.Length > 0)
            {
                cmbTagFlag = true;
                ComboBox reference = (ComboBox)sender;
                string str = "";
               // string tagList = findSelectedtagNoByProductDesc(cmbProductDesc.Text);
                str = "SELECT ID,CNAME FROM CUSTOMERM ORDER BY CNAME";

                DataTable tagTable = new DataTable();
                
                tagTable = dbUtils.fill_ComboData(str);
                DataRow dataRow = tagTable.NewRow();
                dataRow[0] = -1;
                dataRow[1] = "<Select Customer>";
                tagTable.Rows.InsertAt(dataRow, 0);
                reference.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                reference.AutoCompleteSource = AutoCompleteSource.ListItems;
                reference.DisplayMember = "DESCRIPTION";
                reference.ValueMember = "ID";
                reference.DataSource = tagTable;
                cmbTagFlag = false;
            }
            else
            {
                // return null;
            }
        }

        private void fillTagNo(ref object sender)
        {
            if (cmbProductDesc.Text.Length > 0)
            {
                cmbTagFlag = true;
                ComboBox reference = (ComboBox)sender;
                string str = "";
               string tagList = findSelectedtagNoByProductDesc(cmbProductDesc.Text);
                
                if (tagList.Length > 0)
                {
                    str = "SELECT TID AS ID,TNO AS DESCRIPTION FROM TRANS WHERE PCODE = '" + cmbProductDesc.Text + "' AND OUTBILLNO IS NULL AND TNO NOT IN (" + tagList + ") ORDER BY TNO";
                }
                else
                {
                    str = "SELECT TID AS ID ,TNO AS DESCRIPTION FROM TRANS WHERE PCODE = '" + cmbProductDesc.Text + "' AND OUTBILLNO IS NULL ORDER BY TNO";
                }
                
                DataTable tagTable = new DataTable();
                tagTable = dbUtils.fill_ComboData(str);

                reference.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                reference.AutoCompleteSource = AutoCompleteSource.ListItems;
                reference.DisplayMember = "DESCRIPTION";
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
            if (cmbProductDesc.Text.Length > 0 && cmbTagNo.Text.Length > 0)
            {
                string sqlQry = "SELECT * FROM TRANS WHERE PCODE = '" + cmbProductDesc.Text + "' AND TNO =" + cmbTagNo.Text + " AND OUTBILLNO IS NULL";
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
 
                }
            }
        }

        private void btnStockOut_Click(object sender, EventArgs e)
        {
            addDataToGrid();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int saleBillNo = 0;

                if (validate())
                {
                    saleBillNo = int.Parse(txtBillNo.Text);
                    if (btnSave.Text == "&Save")
                    {
                        SaveData(null, null);
                    }
                    else
                    {
                        updateData();
                    }
                    setSalesBillNo();
                }
                if (btn.Name == "btnSaveAndPrint")
                {
                    printInvoice(saleBillNo);
                }
        }

        private void printInvoice(int svno)
        {
            InvoicePrinting invoicePrinting = new InvoicePrinting();
            DataSet ds = new DataSet();
            invoicePrinting.prepareDataSetForInvoiceReport(ds,svno);
            CrystalDecisions.CrystalReports.Engine.ReportClass report = getCrystalReport();
            report.SetDataSource(ds);
            CrystalDecisions.CrystalReports.Engine.TextObject txtInvoiceType;
            txtInvoiceType = (CrystalDecisions.CrystalReports.Engine.TextObject)report.ReportDefinition.ReportObjects["txtInvoiceType"];
            txtInvoiceType.Text = "Original";
            report.PrintToPrinter(1, false, 0, 0);
            txtInvoiceType.Text = "Duplicate";
            report.PrintToPrinter(1, false, 0, 0);
        }

        private CrystalDecisions.CrystalReports.Engine.ReportClass getCrystalReport()
        {
            CrystalDecisions.CrystalReports.Engine.ReportClass reportObject = null;
            if (chkPhotoInvoice.Checked)
            {
                reportObject = new InvoiceWithPicture();    
            }
            else
            {
                reportObject = new InvoiceWithoutPicture();    
            }
            customerName = "Manish Madhopuria";
            customerAddress = "46,M.A.K.Azad Road, Howrah -711101";

            CrystalDecisions.CrystalReports.Engine.TextObject txtObject;
            txtObject = (CrystalDecisions.CrystalReports.Engine.TextObject)reportObject.ReportDefinition.ReportObjects["txtName"];
            txtObject.Text = customerName;
            txtObject =(CrystalDecisions.CrystalReports.Engine.TextObject)reportObject.ReportDefinition.ReportObjects["txtAddress"];
            txtObject.Text = customerAddress;

           // reportObject.SetParameterValue("txtName", customerName);
          //  reportObject.SetParameterValue("txtAddress", customerAddress);
           // CrystalDecisions.CrystalReports.Engine.TextObject txtCustomerName = (CrystalDecisions.CrystalReports.Engine.TextObject)reportObject.Section1.ReportObjects["txtName"];
            //    CrystalDecisions.CrystalReports.Engine.TextObject txtCustomerAddress = (CrystalDecisions.CrystalReports.Engine.TextObject)reportObject.Section1.ReportObjects["txtAddress"];
           //     txtCustomerName.Text = customerName;
          //      txtCustomerAddress.Text = customerAddress;
            
           // CrystalDecisions.CrystalReports.Engine.TextObject txtInvoiceType = (CrystalDecisions.CrystalReports.Engine.TextObject)reportObject.Section1.ReportObjects["txtInvoiceType"];

            return reportObject;
        }

        private void updateData()
        {
            OleDbConnection connection = null;
            OleDbTransaction transaction = null;
            try
            {
                connection = dbUtils.getConnection();
                transaction = connection.BeginTransaction();
                DeleteData(int.Parse(txtBillNo.Text), transaction, connection);
                SaveData(transaction, connection);
                resetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                transaction.Rollback();
            }
            finally
            {
                connection.Close();
            }

            
        }

        private void DeleteData(int svno, OleDbTransaction trans,OleDbConnection connection)
        {
            string salesDelQry = "DELETE FROM SALES WHERE VNO = " + svno;
            string salesBillDetailDelQry = "DELETE FROM SALESBILLDETAIL WHERE SVNO = " + svno;
            string updateTransQry = "UPDATE TRANS SET OUTBILLNO = NULL, OUTDATE = NULL WHERE OUTBILLNO = " + svno;
            dbUtils.saveToDB2(salesDelQry, trans, connection);
            dbUtils.saveToDB2(salesBillDetailDelQry, trans, connection);
            dbUtils.saveToDB2(updateTransQry, trans, connection);
        }

        private void SaveData(OleDbTransaction transaction, OleDbConnection connection)
        {
            OleDbCommand command = new OleDbCommand();
            OleDbTransaction trans = null;

            if (connection == null)
            {
                command.Connection = dbUtils.getConnection();
            }
            else
            {
                command.Connection = connection;
            }

            if (transaction == null)
            {
                trans = command.Connection.BeginTransaction();
            }
            else
            {
                trans = transaction;
            }


            customerName = cmbCustomer.Text;
            customerAddress = txtAddress.Text;

            SalesLineItemDetail salesLineItemDetail;
            string updateQry;
            try
            {
                String sqlQry = "INSERT INTO SALES(VDATE,VNO,CID,GROSSAMT,VATRATE,VATAMT,ROUNDOFF,TOTALAMT,PANCARD) VALUES (@VDATE,@VNO,@CID,@GROSSAMT,@VATRATE,@VATAMT,@ROUNDOFF,@TOTALAMT,@PANCARD)";
                string pancard = "";
                if (txtPancard.Text.Length == 10)
                {
                    pancard = txtPancard.Text;
                }
                command.CommandText = sqlQry;
                command.Transaction = trans;
                command.Parameters.Add("@VDATE", OleDbType.Date, 10).Value = String.Format("{0:yyyy/MM/dd}", dtDate.Value);
                command.Parameters.Add("@VNO", OleDbType.Integer, 10).Value = int.Parse(txtBillNo.Text);
                command.Parameters.Add("@CID", OleDbType.Integer, 10).Value = cmbCustomer.SelectedValue;
                command.Parameters.Add("@GROSSAMT", OleDbType.Double, 20).Value = double.Parse(txtSubTotal.Text);
                command.Parameters.Add("@VATRATE", OleDbType.Double, 20).Value = double.Parse(lblVatRate.Text);
                command.Parameters.Add("@VATAMT", OleDbType.Double, 20).Value =  double.Parse(txtVatAmt.Text);
                command.Parameters.Add("@ROUNDOFF", OleDbType.Double, 20).Value = double.Parse(txtRoundOff.Text);
                command.Parameters.Add("@TOTALAMT", OleDbType.Double, 20).Value = double.Parse(txtGrandTotal.Text);
                command.Parameters.Add("@PANCARD", OleDbType.VarChar, 10).Value = pancard;
                command.ExecuteNonQuery();

                sqlQry = "INSERT INTO SALESBILLDETAIL(TID,SVNO,METALRATE,METALAMT,MAKINGON,MAKINGRATE,MAKINGAMT,OTHERCHGON,OTHERCHGRATE,OTHERCHGAMT) VALUES (@TID,@SVNO,@METALRATE,@METALAMT,@MAKINGON,@MAKINGRATE,@MAKINGAMT,@OTHERCHGON,@OTHERCHGRATE,@OTHERCHGAMT)";
                command.CommandText = sqlQry;
                
                for (int i = 0; i < saleGridLineItem.Count; i++)
                {
                    salesLineItemDetail = saleGridLineItem[i];
                    command.Parameters.Clear();
                    command.CommandText = sqlQry;
                    command.Parameters.Add("@TID", OleDbType.Integer, 10).Value = salesLineItemDetail.Tid;
                    command.Parameters.Add("@SVNO", OleDbType.Integer, 10).Value = int.Parse(txtBillNo.Text);
                    command.Parameters.Add("@METALRATE", OleDbType.Double, 10).Value = salesLineItemDetail.MetalRate;
                    command.Parameters.Add("@METALAMT", OleDbType.Double, 20).Value = salesLineItemDetail.MetalValue;

                    if(salesLineItemDetail.MakingAmt > 0)
                    {
                        command.Parameters.Add("@MAKINGON", OleDbType.VarChar, 10).Value = salesLineItemDetail.MakingOn;
                        command.Parameters.Add("@MAKINGRATE", OleDbType.Double, 20).Value = salesLineItemDetail.MakingRate;
                        command.Parameters.Add("@MAKINGAMT", OleDbType.Double, 20).Value = salesLineItemDetail.MakingAmt;
                    }
                    else
                    {
                        command.Parameters.Add("@MAKINGON", OleDbType.VarChar, 10).Value = "";
                        command.Parameters.Add("@MAKINGRATE", OleDbType.Double, 20).Value = 0;
                        command.Parameters.Add("@MAKINGAMT", OleDbType.Double, 20).Value = 0;
                    }

                    if(salesLineItemDetail.OtheChgAmt > 0)
                    {
                        command.Parameters.Add("@OTHERCHGON", OleDbType.VarChar, 10).Value = salesLineItemDetail.OtheChgOn;
                        command.Parameters.Add("@OTHERCHGRATE", OleDbType.Double, 20).Value = salesLineItemDetail.OtheChgRate;
                        command.Parameters.Add("@OTHERCHGAMT", OleDbType.Double, 20).Value = salesLineItemDetail.OtheChgAmt;
                    }
                    else
                    {
                        command.Parameters.Add("@OTHERCHGON", OleDbType.VarChar, 10).Value = "";
                        command.Parameters.Add("@OTHERCHGRATE", OleDbType.Double, 20).Value = 0;
                        command.Parameters.Add("@OTHERCHGAMT", OleDbType.Double, 20).Value = 0;
                    }
                    command.ExecuteNonQuery();


                    updateQry = "UPDATE TRANS SET OUTBILLNO = " + txtBillNo.Text + ", OUTDATE =#" + String.Format("{0:yyyy/MM/dd}", dtDate.Value) + "# WHERE TID = " + salesLineItemDetail.Tid;
                    command.CommandText = updateQry;
                    command.Parameters.Clear();
                    command.ExecuteNonQuery();
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
                command.Connection.Close();
            }
        }

        
        private void clearControl()
        {
            totalDiamondWt = 0.00;
            totalNetWt = 0.00;
            totalPcs = 0;
            totalStoneWt = 0.00;
            cmbTagNo.Text = "";
            dgStockOut.Rows.Clear();
            saleGridLineItem.Clear();
            txtSubTotal.Text = "";
            txtVatAmt.Text = "";
            txtRoundOff.Text = "";
            txtGrandTotal.Text = "";
            lblInWord.Text = "";
            txtPancard.Text = "PANCARD";
            txtAddress.Text = "";
            cmbCustomer.SelectedIndex = 0;
           // updateSubTotal();
        }

        private void updateSubTotal()
        {
            double amount=0;
            double vat = 0;
            double total = 0;
            double netAmt = 0;
            foreach (DataGridViewRow item in dgStockOut.Rows)
            {
                amount += double.Parse(item.Cells[13].Value.ToString());
            }
            txtSubTotal.Text = dbUtils.Decimal2digit(amount.ToString());
            vat = Math.Round((amount * double.Parse(lblVatRate.Text) / 100),0);
            total = amount + vat;
            netAmt = Math.Round(total);
            txtVatAmt.Text = dbUtils.Decimal2digit(vat.ToString());
            txtRoundOff.Text = dbUtils.Decimal2digit((netAmt - total).ToString());
            txtGrandTotal.Text = dbUtils.Decimal2digit(netAmt.ToString());
            lblInWord.Text = dbUtils.NumbersToWords(int.Parse(netAmt.ToString()));
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            dbUtils.disConnect();
            Close();
        }

        private void dgStockOut_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 15)
            {
                DialogResult answer = MessageBox.Show("Are you sure want to remove ?", "Question",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (e.RowIndex > -1 && answer == DialogResult.Yes)
                {
                    dgStockOut.Rows.RemoveAt(e.RowIndex);
                    saleGridLineItem.RemoveAt(e.RowIndex);
                    updateSubTotal();
                }
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (btnModify.Text == "&Modify")
            {
                ModifyStockOut modifyStockOutForm = new ModifyStockOut(this);
                modifyStockOutForm.ShowDialog();
            }
            else
            {
                resetForm();
            }
        }

        private void resetForm()
        {
            clearControl();
            changeButtonName(btnModify, "&Modify");
            changeButtonName(btnSave, "&Save");
            txtBillNo.Text = formLoadBillNo.ToString();
            btnDelete.Visible = false;
        }


        private void btnChooseDetail_Click(object sender, EventArgs e)
        {
            if (cmbTagNo.SelectedIndex > -1 && cmbTagNo.Text != "" && cmbProductDesc.SelectedIndex > -1 && cmbProductDesc.Text != "")
            {
                string key = cmbProductDesc.Text + ":" + cmbTagNo.Text;

                ItemInfo itemInfo = new ItemInfo();
                itemInfo.ItemCode = cmbProductDesc.Text;
                itemInfo.TagNo = int.Parse(cmbTagNo.Text);
                itemInfo.Pcs = int.Parse(cmbTagNo.SelectedValue.ToString());
                itemInfo.SaleDate = dtDate.Value;
                SaleItemInfo saleItemInfo = new SaleItemInfo(itemInfo,this);
                saleItemInfo.ShowDialog();
                cmbProductDesc.Select();
            }
            else
            {
                MessageBox.Show("Select proper Tag No", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbTagNo.Select();
            }
           
        }

        private string findSelectedtagNoByProductDesc(string productDesc)
        {
            StringBuilder resultString = new StringBuilder();
            foreach (DataGridViewRow item in dgStockOut.Rows)
            {
                if (item.Cells[2].Value.ToString() == productDesc)
                {
                    if (resultString.Length != 0)
                    {
                        resultString.Append(",");
                    }
                    resultString.Append(item.Cells[3].Value.ToString());
                }
            }
            return resultString.ToString();
        }

        private void setDefaultNoImage()
        {
            string noImagePath = Application.StartupPath + "\\Data\\Images\\No_image.jpg";
            FileStream filestream = null;
            if (File.Exists(noImagePath))
            {
                filestream = new FileStream(noImagePath, FileMode.Open, FileAccess.Read);
                Image photo = Image.FromStream(filestream);
                defaultNoImage = photo.GetThumbnailImage(100, 100, null, new IntPtr());
            }
            if(filestream != null)
            filestream.Close();
        }

        public void UpdateSalesGrid(SalesLineItemDetail saleLineItemDetail)
        {
            int rowIndex = dgStockOut.CurrentRow.Index;
            DataGridViewRow row = dgStockOut.Rows[rowIndex];

            row.Cells[4].Value = dbUtils.Decimal2digit(saleLineItemDetail.NetWeight.ToString());
            row.Cells[5].Value = saleLineItemDetail.MetalType;
            row.Cells[6].Value = dbUtils.Decimal2digit(saleLineItemDetail.MetalRate.ToString());
            if (saleLineItemDetail.DiamondWeight > 0)
            {
                row.Cells[7].Value = dbUtils.Decimal2digit(saleLineItemDetail.DiamondWeight.ToString());
            }

            if (saleLineItemDetail.DiamondValue > 0)
            {
                row.Cells[8].Value = dbUtils.Decimal2digit(saleLineItemDetail.DiamondValue.ToString());
            }

            if (saleLineItemDetail.StoneWeight > 0)
            {
                row.Cells[9].Value = dbUtils.Decimal2digit(saleLineItemDetail.StoneWeight.ToString());
            }

            if (saleLineItemDetail.StoneValue > 0)
            {
                row.Cells[10].Value = dbUtils.Decimal2digit(saleLineItemDetail.StoneValue.ToString());
            }

            row.Cells[11].Value = saleLineItemDetail.Pcs;

            if (saleLineItemDetail.MakingAmt > 0 && saleLineItemDetail.OtheChgAmt > 0)
            {
                string charges = dbUtils.Decimal2digit(saleLineItemDetail.MakingAmt.ToString()) + Environment.NewLine + dbUtils.Decimal2digit(saleLineItemDetail.OtheChgAmt.ToString());
                row.Cells[12].Value = charges;
            }
            else
            {
                row.Cells[12].Value = dbUtils.Decimal2digit(saleLineItemDetail.MakingAmt.ToString());
            }

            row.Cells[13].Value = dbUtils.Decimal2digit(saleLineItemDetail.TotalAmt.ToString());
            row.Cells[14].Value = saleLineItemDetail.Tid;
            dgStockOut.AutoResizeColumns();
            cmbTagNo.Text = "";
            saleGridLineItem[rowIndex]=saleLineItemDetail;
            updateSubTotal();
        }

        public void addToSalesGrid(SalesLineItemDetail saleLineItemDetail)
        {
            string basicPath = Application.StartupPath + "\\Data\\Images\\";
            

            int rowIndex = dgStockOut.Rows.Add();
            DataGridViewRow row = dgStockOut.Rows[rowIndex];
            row.Cells[0].Value = rowIndex + 1; //Serial No
            string imagePath = basicPath + saleLineItemDetail.Tid + ".jpg"; 
            if (File.Exists(imagePath))
            { 
                FileStream fs = null;
                 fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read);
                Image photo = Image.FromStream(fs);
                Image photoThumbnail = photo.GetThumbnailImage(100, 100, null, new IntPtr());
                row.Cells[1].Value = photoThumbnail;
                fs.Close();
            }
            else
            {
                row.Cells[1].Value = defaultNoImage; //Photo
            }
            row.Cells[2].Value = saleLineItemDetail.ItemDesc;
            row.Cells[3].Value = saleLineItemDetail.TagNo;
            row.Cells[4].Value = dbUtils.Decimal2digit(saleLineItemDetail.NetWeight.ToString());
            row.Cells[5].Value = saleLineItemDetail.MetalType;
            row.Cells[6].Value = dbUtils.Decimal2digit(saleLineItemDetail.MetalRate.ToString());
            if (saleLineItemDetail.DiamondWeight > 0)
            {
                row.Cells[7].Value = dbUtils.Decimal2digit(saleLineItemDetail.DiamondWeight.ToString());
            }

            if (saleLineItemDetail.DiamondValue > 0)
            {
                row.Cells[8].Value = dbUtils.Decimal2digit(saleLineItemDetail.DiamondValue.ToString());
            }

            if (saleLineItemDetail.StoneWeight > 0)
            {
                row.Cells[9].Value = dbUtils.Decimal2digit(saleLineItemDetail.StoneWeight.ToString());
            }
            
            if (saleLineItemDetail.StoneValue > 0)
            {
                row.Cells[10].Value = dbUtils.Decimal2digit(saleLineItemDetail.StoneValue.ToString());
            }

            row.Cells[11].Value = saleLineItemDetail.Pcs;

            if (saleLineItemDetail.MakingAmt > 0 && saleLineItemDetail.OtheChgAmt > 0)
            {
                string charges = dbUtils.Decimal2digit(saleLineItemDetail.MakingAmt.ToString()) + Environment.NewLine + dbUtils.Decimal2digit(saleLineItemDetail.OtheChgAmt.ToString());
                row.Cells[12].Value = charges;
            }
            else
            {
                row.Cells[12].Value = dbUtils.Decimal2digit(saleLineItemDetail.MakingAmt.ToString());
            }
            
            row.Cells[13].Value = dbUtils.Decimal2digit(saleLineItemDetail.TotalAmt.ToString());
            row.Cells[14].Value = saleLineItemDetail.Tid;
            dgStockOut.AutoResizeColumns();
            cmbTagNo.Text = "";
            saleGridLineItem.Add(saleLineItemDetail);
            dgStockOut.FirstDisplayedScrollingRowIndex = dgStockOut.RowCount - 1;
            updateSubTotal();   
        }

        public void loadSalesDataToModify(SaleBillInfo saleBillInfo)
        {
            saleGridLineItem.Clear();
            dgStockOut.Rows.Clear();
            dtDate.Value = saleBillInfo.VDate;
            txtBillNo.Text = saleBillInfo.Vno.ToString();
            cmbCustomer.SelectedValue = saleBillInfo.Cid;
            setCustomerAddress(cmbCustomer.SelectedValue.ToString());
            lblVatRate.Text = saleBillInfo.VatRate.ToString();
            if (saleBillInfo.Pancard.Length == 10)
            {
                txtPancard.Text = saleBillInfo.Pancard;
            }

            loadExistingSaleBillLineItem(saleBillInfo.Vno);
            txtSubTotal.Text = dbUtils.Decimal2digit(saleBillInfo.GrossAmt.ToString());
            txtVatAmt.Text = dbUtils.Decimal2digit(saleBillInfo.VatAmt.ToString());
            txtRoundOff.Text = dbUtils.Decimal2digit(saleBillInfo.RoundOff.ToString());
            txtGrandTotal.Text = dbUtils.Decimal2digit(saleBillInfo.TotalAmt.ToString());
            changeButtonName(btnSave, "&Update");
            changeButtonName(btnModify, "&Cancel");
            btnDelete.Visible = true;
        }

        private void changeButtonName(Button btn, string name)
        {
            btn.Text = name;
        }

        private void loadExistingSaleBillLineItem(int svno)
        {
            string sqlQry = "SELECT * FROM TRANS WHERE OUTBILLNO = " + svno;
            saleGridLineItem.Clear();
            SalesLineItemDetail lineItem;
            OleDbDataReader reader = dbUtils.fetch(sqlQry);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    lineItem = new SalesLineItemDetail();
                    lineItem.Tid = reader.GetInt32(0);
                    lineItem.ItemDesc = reader.GetString(2);
                    lineItem.MetalType = reader.GetString(4);
                    lineItem.TagNo = reader.GetInt32(3);
                    lineItem.Pcs = reader.GetInt16(5);
                    lineItem.GrossWeight = reader.GetDouble(6);
                    lineItem.NetWeight = reader.GetDouble(7);
                    Dictionary<string, List<double>> diamondStoneDetail = getDiamondandStoneDetail(lineItem.Tid);

                    if(diamondStoneDetail.ContainsKey("D"))
                    {
                        List<double> diamondList = diamondStoneDetail["D"];
                        lineItem.DiamondWeight = diamondList[0];
                        lineItem.DiamondValue = diamondList[1];
                    }

                    if (diamondStoneDetail.ContainsKey("S"))
                    {
                        List<double> stoneList = diamondStoneDetail["S"];
                        lineItem.StoneWeight = stoneList[0];
                        lineItem.StoneValue = stoneList[1];
                    }
                    
                    setMakingAndOtherCharges(int.Parse(txtBillNo.Text), lineItem.Tid, lineItem);
                    //saleGridLineItem.Add(lineItem);
                    addToSalesGrid(lineItem);
                }
            }
            reader.Close();
        }

        private void setMakingAndOtherCharges(int svno, int tid, SalesLineItemDetail lineItem)
        {
            double diamondValue = 0;
            double stoneValue = 0;
            string sqlQry = "SELECT * FROM SALESBILLDETAIL WHERE TID = " + tid + " AND SVNO = " + svno;
            OleDbDataReader reader = dbUtils.fetch(sqlQry);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    lineItem.MetalRate = reader.GetDouble(3);
                    lineItem.MetalValue = reader.GetDouble(4);
                    lineItem.MakingOn = reader.GetString(5);
                    lineItem.MakingRate = reader.GetDouble(6);
                    lineItem.MakingAmt = reader.GetDouble(7);
                    lineItem.OtheChgOn = reader.GetString(8);
                    lineItem.OtheChgRate = reader.GetDouble(9);
                    lineItem.OtheChgAmt = reader.GetDouble(10);

                    if (lineItem.DiamondValue > 0)
                        diamondValue = lineItem.DiamondValue;
                    if (lineItem.StoneValue > 0)
                        stoneValue = lineItem.StoneValue;
                    lineItem.TotalAmt = reader.GetDouble(4) + reader.GetDouble(7) + reader.GetDouble(10) + diamondValue + stoneValue;
                }
            }
            reader.Close();
        }

        private Dictionary<string, List<double>> getDiamondandStoneDetail(int tid)
        {
            string sqlQry = "SELECT STYPE,SUM(SWT),SUM(SAMT) FROM STONEDATA WHERE PID = " + tid + " GROUP BY STYPE ";
            List<double> stoneList = new List<double>();

            Dictionary<string, List<double>> resultList = new Dictionary<string, List<double>>();

            OleDbDataReader reader = dbUtils.fetch(sqlQry);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    stoneList = new List<double>();
                    double weight = reader.GetDouble(1);
                    double value = reader.GetDouble(2);
                    stoneList.Add(weight);
                    stoneList.Add(value);
                    if (reader.GetString(0) == "D")
                    {
                        resultList.Add("D", stoneList);
                    }
                    else
                    {
                        resultList.Add("S", stoneList);
                    }
                }
            }
            reader.Close();
            return resultList;
        }

        private void txtGrandTotal_TextChanged(object sender, EventArgs e)
        {
            int amount;
            int.TryParse(txtGrandTotal.Text, out amount);
            if (amount > 0)
            {
                lblInWord.Text = dbUtils.NumbersToWords(amount);
            }
            else
            {
                lblInWord.Text = "";
            }
        }


        private void setCustomerAddress(string customerId)
        {
            string sqlQry = "SElECT * FROM CUSTOMERM WHERE ID = " + int.Parse(customerId);
            OleDbDataReader reader = dbUtils.fetch(sqlQry);
            StringBuilder sb = new StringBuilder();
            if (reader.HasRows)
            {
                reader.Read();
                if (!reader["ADDRESS"].Equals(DBNull.Value))
                {
                    sb.Append(reader.GetString(2));
                }

                if (!reader["PHONE"].Equals(DBNull.Value))
                {
                    sb.Append(Environment.NewLine);
                    sb.Append("Phone : " + reader.GetString(3));
                }
                txtAddress.Text = sb.ToString();
            }
            reader.Close();
        }

        private void txtPancard_Enter(object sender, EventArgs e)
        {
            if (txtPancard.Text == "PANCARD")
            {
                txtPancard.Text = "";
            }
        }

        private void txtPancard_Leave(object sender, EventArgs e)
        {
            if (txtPancard.Text.Length == 0)
            {
                txtPancard.Text = "PANCARD";
                txtPancard.ForeColor = Color.Silver;
            }
            else if (txtPancard.Text.Length == 10)
            {
                txtPancard.Text.ToUpper();
                txtPancard.ForeColor = Color.Black;
            }
            else
            {
                txtPancard.Text.ToUpper();
                txtPancard.ForeColor = Color.Red;
            }
        }

        private bool validate()
        {
            bool flag = true;
            if (cmbCustomer.SelectedIndex <= 0)
            {
                MessageBox.Show("Select proper customer .", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cmbCustomer.Select();
                flag = false;
            }

            if (dgStockOut.Rows.Count == 0)
            {
                MessageBox.Show("Nothing to save .", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cmbProductDesc.Select();
                flag = false;
            }

            string sqlQry = "SELECT KVALUE FROM SETTING WHERE KEY = 'PANREQUIRED'";
            string panAmtStr = dbUtils.FetchString(sqlQry);
            double panAmount = 0;
            double grandTotal = 0;
            double.TryParse(txtGrandTotal.Text,out grandTotal);
            double.TryParse(panAmtStr, out panAmount);

            if (grandTotal >=  panAmount )
            {
                if (txtPancard.Text.Length != 10)
                {
                    MessageBox.Show("Pancard is mandatory for this transaction. Enter valid pancard no.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtPancard.Select();
                    flag = false;
                }
            }

            return flag;
        }

        private void txtRoundOff_Leave(object sender, EventArgs e)
        {
            double grandTotal = 0;
            double vat = 0;
            double roundOff = 0;
            double.TryParse(txtSubTotal.Text, out grandTotal);
            double.TryParse(txtVatAmt.Text, out vat);
            double.TryParse(txtRoundOff.Text, out roundOff);

            if (txtRoundOff.Text.Length > 0)
            {
                txtGrandTotal.Text = dbUtils.Decimal2digit((grandTotal + vat + roundOff).ToString());
                lblInWord.Text = dbUtils.NumbersToWords(int.Parse((grandTotal + vat + roundOff).ToString()));
            }
        }

        private void txtAddress_Enter(object sender, EventArgs e)
        {
            setCustomerAddress(cmbCustomer.SelectedValue.ToString());
        }

        private void dgStockOut_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
                DialogResult answer = MessageBox.Show("Are you sure want to modify ?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (answer == DialogResult.Yes)
                {
                    SalesLineItemDetail saleLineItemDetail = saleGridLineItem[e.RowIndex];
                    SaleItemInfo saleItemInfo = new SaleItemInfo(saleLineItemDetail, this);
                    saleItemInfo.ShowDialog();
                  
                }
        }

        private void dtDate_ValueChanged(object sender, EventArgs e)
        {
            selectedDate = dtDate.Value;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            OleDbConnection connection = dbUtils.dbcon;
            OleDbTransaction trans=null;
            try
            {
                DialogResult result = MessageBox.Show("Are you sure want to delete invoice no " + txtBillNo.Text + " ? ", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (DialogResult.Yes == result)
                {
                    connection = dbUtils.dbcon;
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    trans = connection.BeginTransaction();
                    DeleteData(int.Parse(txtBillNo.Text), trans, connection);
                    trans.Commit();
                    resetForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
               if(trans != null)
                trans.Rollback();
            }
            
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            chkPhotoInvoice.BackColor =Color.Gainsboro;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            chkPhotoInvoice.BackColor = Color.CadetBlue;
        }

        private void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCustomer.SelectedIndex > -1)
            {
                setCustomerAddress(cmbCustomer.SelectedValue.ToString());
            }
        }
    }
}
