using DGVPrinterHelper;
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
    public partial class DailyStock : Form
    {
        public DailyStock()
        {
            InitializeComponent();
            setFullScreen();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void setFullScreen()
        {
            int x = Screen.PrimaryScreen.Bounds.Width;
            int y = Screen.PrimaryScreen.Bounds.Height;
            Size = new Size(x, y);
            btnClose.Location = new Point(x - btnClose.Size.Width - 5, 5);
            dtDate.Value = DateTime.Today;
            panel1.Location = new Point(x - panel1.Width - 2,50);
        }

        private DataTable getItemDataTable()
        {
            DataTable itemTable = new DataTable();
            itemTable.Columns.Add("Date", Type.GetType("System.String"));
            itemTable.Columns.Add("Item", Type.GetType("System.String"));
            itemTable.Columns.Add("Tag", Type.GetType("System.String"));
            itemTable.Columns.Add("Metal", Type.GetType("System.String"));
            itemTable.Columns.Add("Pcs", Type.GetType("System.String"));
            itemTable.Columns.Add("G.Wt.", Type.GetType("System.String"));
            itemTable.Columns.Add("N.Wt.", Type.GetType("System.String"));
            return itemTable;
        }

        private void populateItemDetail(string itemName, string date)
        {
            string sqlQry = "SELECT tDate, Pcode as Item, Tno as TagNo, MetalType, Pcs, GW,NW FROM TRANS WHERE PCODE = '" + itemName + "' AND (OUTDATE IS NULL OR OUTDATE >= #" + date + "#) AND TDATE <= #" + date + "#";
            OleDbDataReader reader = dbUtils.fetch(sqlQry);
            int columnCount = reader.FieldCount;
           /* dgItemDetail.Columns.Clear();
            for (int i = 0; i < columnCount; i++)
            {
                dgItemDetail.Columns.Add(reader.GetName(i).ToString(), reader.GetName(i).ToString());
            }*/
            dgItemDetail.Rows.Clear();
            string[] rowData = new string[columnCount];
            while (reader.Read())
            {
                for (int k = 0; k < columnCount; k++)
                {
                    if (reader.GetFieldType(k).ToString() == "System.Int16")
                    {
                        rowData[k] = reader.GetInt16(k).ToString();
                    }

                    if (reader.GetFieldType(k).ToString() == "System.Int32")
                    {
                        rowData[k] = reader.GetInt32(k).ToString();
                    }

                    if (reader.GetFieldType(k).ToString() == "System.Int64")
                    {
                        rowData[k] = reader.GetInt64(k).ToString();
                    }

                    if (reader.GetFieldType(k).ToString() == "System.String")
                    {
                        rowData[k] = reader.GetString(k);
                    }

                    if (reader.GetFieldType(k).ToString() == "System.Double")
                    {
                        rowData[k] = dbUtils.Decimal3digit(reader.GetDouble(k).ToString());
                    }
                    if (reader.GetFieldType(k).ToString() == "System.DateTime")
                    {
                        rowData[k] = reader.GetDateTime(k).ToShortDateString();
                    }
                }

                dgItemDetail.Rows.Add(rowData);
            }
            reader.Close();
            reader = null;
        }

        private void populateMetalByType()
        {
            double openingStockNetWeight = 0;
            double stockINNetWeight = 0;
            double stockOUTNetWeight = 0;
            double closingStockNetWeight = 0;
            int sl = 0;
            string date = String.Format("{0:yyyy/MM/dd}", dtDate.Value);
            string sqlStr = "SELECT GDESC FROM METALM ORDER BY GDESC";
            OleDbDataReader reader = dbUtils.fetch(sqlStr);
            dgMetalType.Rows.Clear();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    openingStockNetWeight = getMetalOpeningStockNetWeight(reader.GetString(0), date);
                    stockINNetWeight = getMetalStockInDetailNetWeight(reader.GetString(0), date);
                    stockOUTNetWeight = getMetalStockOctDetailNetWeight(reader.GetString(0), date);
                    closingStockNetWeight = openingStockNetWeight + stockINNetWeight - stockOUTNetWeight;

                    if (openingStockNetWeight > 0 || stockINNetWeight > 0 || stockOUTNetWeight > 0 || closingStockNetWeight > 0)
                    {
                        sl++;
                        string[] row = new string[] { sl.ToString(), reader.GetString(0), dbUtils.Decimal3digit(openingStockNetWeight.ToString()) , dbUtils.Decimal3digit(stockINNetWeight.ToString()), dbUtils.Decimal3digit(stockOUTNetWeight.ToString()), dbUtils.Decimal3digit(closingStockNetWeight.ToString()) };
                        dgMetalType.Rows.Add(row);
                    }
                }
            }
            reader.Close();
            reader = null;
        }

        private void populateStockByDate()
        {
            int sl = 0;
            double openingStock = 0;
            double stockIN = 0;
            double stockOUT = 0;
            double closingStock = 0;

            double openingStockNetWeight = 0;
            double stockINNetWeight = 0;
            double stockOUTNetWeight = 0;
            double closingStockNetWeight = 0;

            string date = String.Format("{0:yyyy/MM/dd}", dtDate.Value);
            string sqlQry = "SELECT PNAME FROM PRODUCTM ORDER BY PNAME";
            OleDbDataReader reader = dbUtils.fetch(sqlQry);
            dgReport.Rows.Clear();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    openingStock = getOpeningStock(reader.GetString(0), date);
                    stockIN = getStockInDetail(reader.GetString(0), date);
                    stockOUT = getStockOctDetail(reader.GetString(0), date);
                    closingStock = openingStock + stockIN - stockOUT;

                    openingStockNetWeight = getOpeningStockNetWeight(reader.GetString(0), date);
                    stockINNetWeight = getStockInDetailNetWeight(reader.GetString(0), date);
                    stockOUTNetWeight = getStockOctDetailNetWeight(reader.GetString(0), date);
                    closingStockNetWeight = openingStockNetWeight + stockINNetWeight - stockOUTNetWeight;

                    if (openingStock > 0 || stockIN > 0 || stockOUT > 0 || closingStock > 0)
                    {
                        sl++;
                        int openingPad = openingStock.ToString().Trim().Length;
                        int stockInPad = stockIN.ToString().Trim().Length;
                        int stockOutPad = stockOUT.ToString().Trim().Length;
                        int closingStockPad = closingStock.ToString().Trim().Length;

                        string[] row = new string[] { sl.ToString(), reader.GetString(0), openingStock.ToString().PadRight(8-openingPad) + dbUtils.Decimal3digit(openingStockNetWeight.ToString()), stockIN.ToString().PadRight(8-stockInPad,' ') + dbUtils.Decimal3digit(stockINNetWeight.ToString()), stockOUT.ToString().PadRight(8-stockInPad) + dbUtils.Decimal3digit(stockOUTNetWeight.ToString()), closingStock.ToString().PadRight(8-closingStockPad) + dbUtils.Decimal3digit(closingStockNetWeight.ToString()) };
                        dgReport.Rows.Add(row);
                    }
                }
            }
            reader.Close();
        }

        private double getOpeningStock(string productCode, string date)
        {
            double op = 0;
            double cls = 0;
            if (productCode == "Necklace")
            {
                //MessageBox.Show("Necklace Set");
            }
            string sqlQry = "SELECT SUM(PCS) FROM TRANS WHERE PCODE = '"+productCode+"' AND TDATE < #"+date+"#";
            op = dbUtils.FetchDouble(sqlQry);

            sqlQry = "SELECT SUM(PCS) FROM TRANS WHERE PCODE = '" + productCode + "' AND TDATE < #"+date+"# AND OUTDATE < #" + date + "# AND OUTDATE IS NOT NULL";
            cls = dbUtils.FetchDouble(sqlQry);
            return op-cls;
        }

        private double getOpeningStockNetWeight(string productCode, string date)
        {
            double op = 0;
            double cls = 0;

            string sqlQry = "SELECT SUM(NW) FROM TRANS WHERE PCODE = '" + productCode + "' AND TDATE < #" + date + "#";
            op = dbUtils.FetchDouble(sqlQry);

            sqlQry = "SELECT SUM(NW) FROM TRANS WHERE PCODE = '" + productCode + "' AND TDATE < #" + date + "# AND OUTDATE < #" + date + "# AND OUTDATE IS NOT NULL";
            cls = dbUtils.FetchDouble(sqlQry);
            return op - cls;
        }

        private double getMetalOpeningStockNetWeight(string metalCode, string date)
        {
            double op = 0;
            double cls = 0;

            string sqlQry = "SELECT SUM(NW) FROM TRANS WHERE METALTYPE = '" + metalCode + "' AND TDATE < #" + date + "#";
            op = dbUtils.FetchDouble(sqlQry);

            sqlQry = "SELECT SUM(NW) FROM TRANS WHERE METALTYPE = '" + metalCode + "' AND TDATE < #" + date + "# AND OUTDATE < #" + date + "# AND OUTDATE IS NOT NULL";
            cls = dbUtils.FetchDouble(sqlQry);
            return op - cls;
        }

        private double getStockInDetail(string productCode, string date)
        {
            string sqlQry = "SELECT SUM(PCS) FROM TRANS WHERE PCODE = '" + productCode + "' AND TDATE = #" + date + "#";
            double result = dbUtils.FetchDouble(sqlQry);
            return result;
        }

        private double getStockInDetailNetWeight(string productCode, string date)
        {
            string sqlQry = "SELECT SUM(NW) FROM TRANS WHERE PCODE = '" + productCode + "' AND TDATE = #" + date + "#";
            double result = dbUtils.FetchDouble(sqlQry);
            return result;
        }

        private double getMetalStockInDetailNetWeight(string metalCode, string date)
        {
            string sqlQry = "SELECT SUM(NW) FROM TRANS WHERE METALTYPE = '" + metalCode + "' AND TDATE = #" + date + "#";
            double result = dbUtils.FetchDouble(sqlQry);
            return result;
        }

        private double getStockOctDetail(string productCode, string date)
        {
            string sqlQry = "SELECT SUM(PCS) FROM TRANS WHERE PCODE = '" + productCode + "' AND OUTDATE = #" + date + "#";
            double result = dbUtils.FetchDouble(sqlQry);
            return result;
        }

        private double getStockOctDetailNetWeight(string productCode, string date)
        {
            string sqlQry = "SELECT SUM(NW) FROM TRANS WHERE PCODE = '" + productCode + "' AND OUTDATE = #" + date + "#";
            double result = dbUtils.FetchDouble(sqlQry);
            return result;
        }

        private double getMetalStockOctDetailNetWeight(string metalCode, string date)
        {
            string sqlQry = "SELECT SUM(NW) FROM TRANS WHERE METALTYPE = '" + metalCode + "' AND OUTDATE = #" + date + "#";
            double result = dbUtils.FetchDouble(sqlQry);
            return result;
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            populateStockByDate();
            populateMetalByType();
        }

        private void dgReport_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string date = String.Format("{0:yyyy/MM/dd}", dtDate.Value);
            string itemCode = dgReport.Rows[e.RowIndex].Cells[1].Value.ToString();
            populateItemDetail(itemCode, date);
        }

        private void pbPrint_Click(object sender, EventArgs e)
        {
            dbUtils.Animate(panel1, dbUtils.Effect.Slide, 150, 90);
        }

        private void printDoc(string title,DataGridView dataGrid)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = title;
            printer.SubTitle = "Report as on " + DateTime.Today.ToShortDateString();
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit |
            StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.ColumnWidth = DGVPrinter.ColumnWidthSetting.Porportional;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "";
            printer.FooterSpacing = 15;
            printer.PrintDataGridView(dataGrid);
        }

        private void pbCancel_Click(object sender, EventArgs e)
        {
            dbUtils.Animate(panel1, dbUtils.Effect.Slide, 150, 90);
        }

        private void pbPrintSelected_Click(object sender, EventArgs e)
        {
            if (rbStock.Checked)
            {
                printDoc(rbStock.Text, dgReport);
            }
            else if (rbItem.Checked)
            {
                printDoc(rbItem.Text, dgItemDetail);
            }
            else if (rbMetal.Checked)
            {
                printDoc(rbMetal.Text, dgMetalType);
            }
            else
            {
                MessageBox.Show("Please select a valid option");
                return;
            }
            dbUtils.Animate(panel1, dbUtils.Effect.Slide, 150, 90);
        }
    }
}
