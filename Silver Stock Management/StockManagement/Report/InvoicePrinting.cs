using CrystalDecisions.CrystalReports.Engine;
using StockManagement.Report.CrystalReport;
using StockManagement.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockManagement.Report
{
    
    public partial class InvoicePrinting : Form
    {
        int customerId;

        public InvoicePrinting()
        {
            InitializeComponent();
            getInvoiceList();
        }

        private bool validate()
        {
            if (cmbInvoice.Text.Length == 0 || cmbInvoice.SelectedIndex == -1)
            {
                MessageBox.Show("Select a valid invoice.");
                return false;
            }
            return true;
        }

        public void prepareDataSetForInvoiceReport(DataSet ds,int svno)
        {
            getSalesData(svno, ds);
            getSalesLineItem(svno, ds);
        }

        private void btnShowReport_Click(object sender, EventArgs e)
        {
            if (validate())
            {
                this.Cursor = Cursors.AppStarting;
                DataSet ds = new DataSet();
                prepareDataSetForInvoiceReport(ds, int.Parse(cmbInvoice.Text));
                //ds.WriteXml("d:\\temp.xml");
                if (chkPicture.Checked)
                {
                    showPhotoReport(ds);
                }
                else
                {
                    showReport(ds);
                }
                this.Cursor = Cursors.Default;
            }
        }

        private void getInvoiceList()
        {
            string qry = "SELECT VNO AS DESCRIPTION FROM SALES ORDER BY VNO";
            cmbInvoice.Items.Clear();
            OleDbDataReader reader = dbUtils.fetch(qry);
            if (reader.HasRows)
            {
                //  cmbItem.Items.Add("All");
                while (reader.Read())
                {
                    cmbInvoice.Items.Add(reader.GetInt32(0));
                }
            }
            reader.Close();
            cmbInvoice.SelectedIndex = 0;
        }

        private DataTable getSalesTable()
        {
            DataTable salesTable = new DataTable();
            salesTable.Columns.Add("VDATE", Type.GetType("System.DateTime"));
            salesTable.Columns.Add("VNO", Type.GetType("System.Int32"));
            salesTable.Columns.Add("SubTotal", Type.GetType("System.Double"));
            salesTable.Columns.Add("VatRate", Type.GetType("System.Double"));
            salesTable.Columns.Add("VatAmt", Type.GetType("System.Double"));
            salesTable.Columns.Add("RoundOff", Type.GetType("System.Double"));
            salesTable.Columns.Add("GrandTotal", Type.GetType("System.Double"));
            salesTable.Columns.Add("PanCard", Type.GetType("System.String"));
            return salesTable;
        }

        private DataTable getSalesLineItemTable()
        {
            DataTable salesLineItem = new DataTable();
            salesLineItem.Columns.Add("SN", Type.GetType("System.Int32"));
            salesLineItem.Columns.Add("SVNO", Type.GetType("System.Int32"));
            salesLineItem.Columns.Add("Design", Type.GetType("System.String"));
            salesLineItem.Columns.Add("ItemDesc", Type.GetType("System.String"));
            salesLineItem.Columns.Add("MetalWeight", Type.GetType("System.Double"));
            salesLineItem.Columns.Add("Purity", Type.GetType("System.String"));
            salesLineItem.Columns.Add("Rate", Type.GetType("System.Double"));
            salesLineItem.Columns.Add("DiaWt", Type.GetType("System.Double"));
            salesLineItem.Columns.Add("DiaVal", Type.GetType("System.Double"));
            salesLineItem.Columns.Add("StWt", Type.GetType("System.Double"));
            salesLineItem.Columns.Add("StVal", Type.GetType("System.Double"));
            salesLineItem.Columns.Add("Unit", Type.GetType("System.Int32"));
            salesLineItem.Columns.Add("MakingChg", Type.GetType("System.String"));
            salesLineItem.Columns.Add("Amount", Type.GetType("System.Double"));
            return salesLineItem;
        }



        private void getSalesData(int svno,DataSet ds)
        {
            string sqlQry = "SELECT * FROM SALES WHERE VNO = "+ svno;
            OleDbDataReader reader = dbUtils.fetch(sqlQry);
            string itemDesc = string.Empty;
            DataTable salesTable = getSalesTable();
            salesTable.TableName = "SaleTable";
            ds.Tables.Add(salesTable);
            DataRow row;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    row = salesTable.NewRow();
                    row[0] = reader.GetDateTime(1);
                    row[1] = reader.GetInt32(2);
                    row[2] = reader.GetDouble(4);
                    row[3] = reader.GetDouble(5);
                    row[4] = reader.GetDouble(6);
                    row[5] = reader.GetDouble(7);
                    row[6] = reader.GetDouble(8);
                    row[7] = reader.GetString(9);
                    customerId = reader.GetInt32(3);
                    salesTable.Rows.Add(row);
                }
            }
            reader.Close();
            //return ds;
        }

        private List<string> getCustomerDetailByID()
        {
            List<string> customerList = new List<string>();
            string sqlQry = "SELECT * FROM CUSTOMERM WHERE ID = "+ customerId;
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
                customerList.Add(reader.GetString(1));
                customerList.Add(sb.ToString());
            }
            reader.Close();
            return customerList;
        }
        private void showPhotoReport(DataSet ds)
        {
            CrystalReportViewer reportViewer = new CrystalReportViewer();
            InvoiceWithPicture invoiceWithPictureReport = new InvoiceWithPicture();
            invoiceWithPictureReport.SetDataSource(ds);
            //invoiceWithPictureReport.SetDataSource(ds.Tables[1]);
            //invoiceWithPictureReport.SetDataSource(ds.Tables[0]);
            List<string> customerList = getCustomerDetailByID();
            if (customerList.Count > 0)
            {
                CrystalDecisions.CrystalReports.Engine.TextObject txtCustomerName = (CrystalDecisions.CrystalReports.Engine.TextObject)invoiceWithPictureReport.Section1.ReportObjects["txtName"];
                CrystalDecisions.CrystalReports.Engine.TextObject txtCustomerAddress = (CrystalDecisions.CrystalReports.Engine.TextObject)invoiceWithPictureReport.Section1.ReportObjects["txtAddress"];
                txtCustomerName.Text = customerList[0];
                txtCustomerAddress.Text = customerList[1];
            }
            CrystalDecisions.CrystalReports.Engine.TextObject txtInvoiceType = (CrystalDecisions.CrystalReports.Engine.TextObject)invoiceWithPictureReport.Section1.ReportObjects["txtInvoiceType"];
            if (rdoOriginal.Checked)
                txtInvoiceType.Text = rdoOriginal.Text;
            else
                txtInvoiceType.Text = rdoDuplicate.Text;
            reportViewer.crystalReportViewer1.ReportSource = invoiceWithPictureReport;
            reportViewer.crystalReportViewer1.Refresh();
            reportViewer.Visible = true;
        }

        private void showReport(DataSet ds)
        {
            CrystalReportViewer reportViewer = new CrystalReportViewer();
            InvoiceWithoutPicture invoiceWithoutPictureReport = new InvoiceWithoutPicture();
            invoiceWithoutPictureReport.SetDataSource(ds);
            //invoiceWithPictureReport.SetDataSource(ds.Tables[1]);
            //invoiceWithPictureReport.SetDataSource(ds.Tables[0]);
            List<string> customerList = getCustomerDetailByID();
            if (customerList.Count > 0)
            {
                CrystalDecisions.CrystalReports.Engine.TextObject txtCustomerName = (CrystalDecisions.CrystalReports.Engine.TextObject)invoiceWithoutPictureReport.Section1.ReportObjects["txtName"];
                CrystalDecisions.CrystalReports.Engine.TextObject txtCustomerAddress = (CrystalDecisions.CrystalReports.Engine.TextObject)invoiceWithoutPictureReport.Section1.ReportObjects["txtAddress"];
                txtCustomerName.Text = customerList[0];
                txtCustomerAddress.Text = customerList[1];
            }
            CrystalDecisions.CrystalReports.Engine.TextObject txtInvoiceType = (CrystalDecisions.CrystalReports.Engine.TextObject)invoiceWithoutPictureReport.Section1.ReportObjects["txtInvoiceType"];
            if (rdoOriginal.Checked)
                txtInvoiceType.Text = rdoOriginal.Text;
            else
                txtInvoiceType.Text = rdoDuplicate.Text;

            reportViewer.crystalReportViewer1.ReportSource = invoiceWithoutPictureReport;
            reportViewer.crystalReportViewer1.Refresh();
            reportViewer.Visible = true;
        }

        private TripleValue getDataFromTransTable(int tid)
        {
            TripleValue resultObject = new TripleValue();
            string sqlStr = "SELECT NW,METALTYPE,PCS,PCODE FROM TRANS WHERE TID = " + tid;
            OleDbDataReader reader = dbUtils.fetch(sqlStr);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                   resultObject.weight = reader.GetDouble(0);
                   resultObject.purity= reader.GetString(1);
                   resultObject.pcs= reader.GetInt16(2);
                   resultObject.itemDesc = reader.GetString(3);
                }
            }
            reader.Close();
            return resultObject;
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

        private void  getSalesLineItem(int svno,DataSet ds)
        {
            DataTable lineItem = getSalesLineItemTable();
            lineItem.TableName = "SaleLineItemTable";
            ds.Tables.Add(lineItem);

            string sqlQry = "SELECT * FROM SALESBILLDETAIL WHERE SVNO = " + svno;
            OleDbDataReader reader = dbUtils.fetch(sqlQry);
            string path =string.Empty;
            DataRow row; 
            int i=0;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    row = lineItem.NewRow();
                    path = Application.StartupPath + "//Data//Images//" + reader.GetInt32(1) + ".jpg"; //photo
                    if (File.Exists(path))
                    {
                        row[2] = path;
                    }
                    else
                    {
                        row[2] = Application.StartupPath + "//Data//Images//blankImage.jpg"; //photo
                    }

                    row[0] = ++i;
                    row[1] = reader.GetInt32(2);
                    TripleValue valueObject = getDataFromTransTable(reader.GetInt32(1));
                    row[3] = valueObject.itemDesc;
                    row[4] = valueObject.weight;
                    row[5] = valueObject.purity;
                    row[6] = reader.GetDouble(3);

                    Dictionary<string, List<double>> diamondStoneDetail = getDiamondandStoneDetail(reader.GetInt32(1));

                    if (diamondStoneDetail.ContainsKey("D"))
                    {
                        List<double> diamondList = diamondStoneDetail["D"];
                        row[7] = diamondList[0];
                        row[8] = diamondList[1];
                    }
                    else
                    {
                        row[7] = 0;
                        row[8] = 0;
                    }

                    if (diamondStoneDetail.ContainsKey("S"))
                    {
                        List<double> stoneList = diamondStoneDetail["S"];
                        row[9] = stoneList[0];
                        row[10] = stoneList[1];
                    }
                    else
                    {
                        row[9] = 0;
                        row[10] = 0;
                    }


                    row[11] = valueObject.pcs;

                    if (reader.GetDouble(10) > 0)
                    {
                        row[12] = reader.GetDouble(7).ToString() + Environment.NewLine + reader.GetDouble(10).ToString() ;
                    }
                    else
                    {
                        row[12] = reader.GetDouble(7);
                    }

                    row[13] = double.Parse(row[7].ToString()) + double.Parse(row[9].ToString()) + reader.GetDouble(7) + reader.GetDouble(10) + reader.GetDouble(4) ;
                    lineItem.Rows.Add(row);
                }
            }
            reader.Close();
        }

       

       


       

    }

    class TripleValue
    {
        public double weight;
        public string purity;
        public int pcs;
        public string itemDesc;
    }

}
