using CrystalDecisions.CrystalReports.Engine;
using StockManagement.Report.CrystalReport;
using StockManagement.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockManagement.Report
{
    public partial class StockSummary : Form
    {
        DataTable subItemTable;
       

        public StockSummary()
        {
            InitializeComponent();
            dtDate.Value = DateTime.Today;
            getProductList();
            subItemTable = getSubItemTable();
        }

        private void btnShowReport_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.AppStarting;
            DataSet ds;
            subItemTable.Rows.Clear();
            if (cmbItem.Text.Equals("All"))
            {
                ds = getStockData();
            }
            else
            {
                ds = getSingleProductDetail();
            }
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

        private DataSet getSingleProductDetail()
        {
            DataTable stockTable = getStockTable();
            DataSet ds = new DataSet();
            ds.Tables.Add(stockTable);
            getItemDetail(cmbItem.Text, String.Format("{0:yyyy/MM/dd}", dtDate.Value), stockTable);
            return ds;
        }

        private void getProductList()
        {
            string qry = "SELECT PNAME AS DESCRIPTION FROM PRODUCTM ORDER BY PNAME";
            cmbItem.Items.Clear();
            OleDbDataReader reader = dbUtils.fetch(qry);
            if (reader.HasRows)
            {
                cmbItem.Items.Add("All");
                while (reader.Read())
                {
                    cmbItem.Items.Add(reader.GetString(0));
                }
            }
            cmbItem.SelectedIndex = 0;
        }

        private DataTable getStockTable()
        {
            DataTable stockTable = new DataTable();
            stockTable.Columns.Add("Picture", Type.GetType("System.String"));
            stockTable.Columns.Add("ItemDesc", Type.GetType("System.String"));
            stockTable.Columns.Add("GrossWeight", Type.GetType("System.Double"));
            stockTable.Columns.Add("DiamondDetail", Type.GetType("System.String"));
            stockTable.Columns.Add("StoneDetail", Type.GetType("System.String"));
            stockTable.Columns.Add("NetWeight", Type.GetType("System.Double"));
            stockTable.Columns.Add("TagNo", Type.GetType("System.String"));
            stockTable.Columns.Add("TID", Type.GetType("System.Int32"));
            return stockTable;
        }

        private DataTable getSubItemTable()
        {
            DataTable subItemTable = new DataTable();
            subItemTable.Columns.Add("SubItemDesc", Type.GetType("System.String"));
            subItemTable.Columns.Add("SubItemGrossWt", Type.GetType("System.Double"));
            subItemTable.Columns.Add("SubItemDiamondDetail", Type.GetType("System.String"));
            subItemTable.Columns.Add("SubItemStoneDetail", Type.GetType("System.String"));
            subItemTable.Columns.Add("SubItemNetWeight", Type.GetType("System.Double"));
            subItemTable.Columns.Add("SubItemTid", Type.GetType("System.Int32"));
            return subItemTable;
        }



        private DataSet getStockData()
        {
            string sqlQry = "SELECT PNAME FROM PRODUCTM ORDER BY PNAME";
            OleDbDataReader reader = dbUtils.fetch(sqlQry);
            string itemDesc = string.Empty;
            DataSet ds = new DataSet();
            DataTable stockTable = getStockTable();
            ds.Tables.Add(stockTable);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    itemDesc = reader.GetString(0);
                    getItemDetail(reader.GetString(0), String.Format("{0:yyyy/MM/dd}", dtDate.Value),stockTable);
                }
            }
            return ds;
        }

        private void showPhotoReport(DataSet ds)
        {
            CrystalReportViewer reportViewer = new CrystalReportViewer();
            StockSummaryReportWithPicture stockSummaryReport = new StockSummaryReportWithPicture();
            stockSummaryReport.SetDataSource(ds.Tables[0]);
            CrystalDecisions.CrystalReports.Engine.TextObject txtReportDate = (CrystalDecisions.CrystalReports.Engine.TextObject)stockSummaryReport.Section1.ReportObjects["txtReportDate"];
            txtReportDate.Text = txtReportDate.Text + dtDate.Value.ToShortDateString();
            reportViewer.crystalReportViewer1.ReportSource = stockSummaryReport;
            reportViewer.crystalReportViewer1.Refresh();
            reportViewer.Visible = true;
        }

        private void showReport(DataSet ds)
        {
            CrystalReportViewer reportViewer = new CrystalReportViewer();
            StockSummaryReport stockSummaryReport = new StockSummaryReport();
            stockSummaryReport.SetDataSource(ds.Tables[0]);
            stockSummaryReport.Subreports[0].SetDataSource(subItemTable);
            CrystalDecisions.CrystalReports.Engine.TextObject txtReportDate = (CrystalDecisions.CrystalReports.Engine.TextObject)stockSummaryReport.Section1.ReportObjects["txtReportDate"];
            txtReportDate.Text = txtReportDate.Text + dtDate.Value.ToShortDateString();
            reportViewer.crystalReportViewer1.ReportSource = stockSummaryReport;
            reportViewer.crystalReportViewer1.Refresh();
            reportViewer.Visible = true;
        }

        private void getItemDetail(string itemName,string date,DataTable stockTable)
        {
            string sqlQry = "SELECT *  FROM TRANS WHERE PCODE = '" + itemName + "' AND (OUTDATE IS NULL OR OUTDATE > #" + date + "#) ORDER BY PCODE,TNO";
            OleDbDataReader reader = dbUtils.fetch(sqlQry);
            List<string> stoneWeight = null;
            string path =string.Empty;
            DataRow row; 
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    row = stockTable.NewRow();
                    if (!reader["Photo"].Equals(DBNull.Value) && reader.GetString(8).Length > 0)
                    {
                        path = Application.StartupPath + "//Data//Images//" + reader.GetString(8); //photo
                        row[0] = path;
                    }else
                    {
                        row[0] = string.Empty;
                    }
                    row[1] = itemName;
                    row[2] = reader.GetDouble(6);
                    stoneWeight = getStoneDetail(reader.GetInt32(0));
                    row[3] = stoneWeight[0];
                    row[4] = stoneWeight[1];
                    row[5] = reader.GetDouble(7);
                    row[6] = reader.GetInt32(3);
                    row[7] = reader.GetInt32(0);
                    stockTable.Rows.Add(row);
                    //MessageBox.Show(reader.GetDataTypeName(11).ToString());
                    if (chkComposite.Checked && !reader["SubItem"].Equals(DBNull.Value) && reader.GetByte(11) == 1)
                    {
                        getSubItemDetail(reader.GetInt32(0).ToString(), subItemTable);
                    }
                }
            }
        }

        private void getSubItemDetail(string Tid,DataTable subItemTable)
        {
            string sqlQry = "SELECT *  FROM SUBITEMTRANS WHERE TID = " + Tid + " ORDER BY IDESC";
            OleDbDataReader reader = dbUtils.fetch(sqlQry);
            List<string> subStoneWeight = null;
            string path = string.Empty;
            DataRow row;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    row = subItemTable.NewRow();
                    row[0] = reader.GetString(2);
                    row[1] = reader.GetDouble(4);
                    subStoneWeight = getSubItemStoneDetail(reader.GetInt32(0));
                    row[2] = subStoneWeight[0];
                    row[3] = subStoneWeight[1];
                    row[4] = reader.GetDouble(5);
                    row[5] = reader.GetInt32(1);
                    subItemTable.Rows.Add(row);
                }
            }
        }

        private List<string> getStoneDetail(Int32 TID)
        {
            StringBuilder diamondDetail = new StringBuilder();
            StringBuilder stoneDetail = new StringBuilder();
            List<string> resultList = new List<string>();
            string sqlQry = "SELECT * FROM STONEDATA WHERE PID = " + TID;
            OleDbDataReader stoneReader = dbUtils.fetch(sqlQry);
            if (stoneReader.HasRows)
            {
                while (stoneReader.Read())
                {
                    if (stoneReader.GetString(3).Equals("D"))
                    {
                        if (diamondDetail.Length > 0)
                        {
                            diamondDetail.Append(", ");
                        }
                        diamondDetail.Append(stoneReader.GetString(2) + ":" + dbUtils.Decimal2digit(stoneReader.GetDouble(4).ToString()));
                    }
                    else
                    {
                        if (stoneDetail.Length > 0)
                        {
                            stoneDetail.Append(", ");
                        }
                        stoneDetail.Append(stoneReader.GetString(2) + ":" + dbUtils.Decimal2digit(stoneReader.GetDouble(4).ToString()));
                    }
                }
            }
            resultList.Add(diamondDetail.ToString());
            resultList.Add(stoneDetail.ToString());
            return resultList;
        }


        private List<string> getSubItemStoneDetail(Int32 SubId)
        {
            StringBuilder diamondDetail = new StringBuilder();
            StringBuilder stoneDetail = new StringBuilder();
            List<string> resultList = new List<string>();
            string sqlQry = "SELECT * FROM SUBSTONEDATA WHERE SUBID = " + SubId;
            OleDbDataReader stoneReader = dbUtils.fetch(sqlQry);
            if (stoneReader.HasRows)
            {
                while (stoneReader.Read())
                {
                    if (stoneReader.GetString(3).Equals("D"))
                    {
                        if (diamondDetail.Length > 0)
                        {
                            diamondDetail.Append(", ");
                        }
                        diamondDetail.Append(stoneReader.GetString(2) + ":" + dbUtils.Decimal2digit(stoneReader.GetDouble(4).ToString()));
                    }
                    else
                    {
                        if (stoneDetail.Length > 0)
                        {
                            stoneDetail.Append(", ");
                        }
                        stoneDetail.Append(stoneReader.GetString(2) + ":" + dbUtils.Decimal2digit(stoneReader.GetDouble(4).ToString()));
                    }
                }
            }
            resultList.Add(diamondDetail.ToString());
            resultList.Add(stoneDetail.ToString());
            return resultList;
        }

    }
}
