using DGVPrinterHelper;
using StockManagement.Utils;
using System;
using System.Collections;
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
    public partial class EmptyTag : Form
    {
        bool bFirstPage = false; //Used to check whether we are printing first page
        bool bNewPage = false;// Used to check whether we are printing a new page
        int iCellHeight = 0; //Used to get/set the datagridview cell height
        int iTotalWidth = 0; //
        int iRow = 0;//Used as counter
        int iHeaderHeight = 0; //Used for the header height
        ArrayList arrColumnLefts = new ArrayList();//Used to save left coordinates of columns
        ArrayList arrColumnWidths = new ArrayList();//Used to save column widths
        private string _ReportHeader="";
        StringFormat strFormat; //Used to format the grid rows.

        public EmptyTag()
        {
            InitializeComponent();
            setFullScreen();
            populateStockByDate();
        }


        private void setFullScreen()
        {
            int x = Screen.PrimaryScreen.Bounds.Width;
            int y = Screen.PrimaryScreen.Bounds.Height;
            Size = new Size(x, y);
            btnClose.Location = new Point(x - btnClose.Size.Width - 5, 5);
        }

        private void populateStockByDate()
        {
            int sl = 0;
            string missingTagNumber = string.Empty;
            List<int> usedTagList = new List<int>();
            string sqlQry = "SELECT PNAME FROM PRODUCTM ORDER BY PNAME";
            OleDbDataReader reader = dbUtils.fetch(sqlQry);
            dgReport.Rows.Clear();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    
                    usedTagList = getUsedTagNumber(reader.GetString(0));
                    missingTagNumber = getMissingTagNumber(usedTagList, reader.GetString(0));
                    //if (openingStock > 0 || stockIN > 0 || stockOUT > 0 || closingStock > 0)
                    {
                        sl++;
                        string[] row = new string[] { sl.ToString(), reader.GetString(0), missingTagNumber };
                        dgReport.Rows.Add(row);
                    }
                }
            }
        }

        private List<int> getUsedTagNumber(string productCode)
        {
            string sqlQry = "SELECT TNO FROM TRANS WHERE OUTDATE IS NULL AND PCODE = '" + productCode + "' ORDER BY TNO";
            List<int> resultList = new List<int>();
            OleDbDataReader reader = dbUtils.fetch(sqlQry);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    resultList.Add(reader.GetInt32(0));
                }
            }
            return resultList;
        }

        private string getMissingTagNumber(List<int> usedTagList,string productCode)
        {
            StringBuilder result = new StringBuilder();
            int maxNumber = 0;
            string sqlQry = "SELECT MAX(TNO) FROM TRANS WHERE PCODE ='" + productCode + "'";
            maxNumber = int.Parse(dbUtils.FetchInteger(sqlQry).ToString());
            if (usedTagList.Count > 0)
            {
                //maxNumber = usedTagList[usedTagList.Count - 1];
                for (int i = 1; i <= maxNumber+1; i++)
                {
                    if (!usedTagList.Contains(i))
                    {
                        if (result.Length > 0)
                        {
                            result.Append(", ");
                        }
                        result.Append(i);
                    }
                }
            }
            //if(result.Length > 0)
            //MessageBox.Show(result.ToString());
            return result.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pbPrint_Click(object sender, EventArgs e)
        {
            //printDocument1.Print();
            /*PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument1;
            printDialog.UseEXDialog = true;
            _ReportHeader = "Empty Tag Number";
            //Get the document
            if (DialogResult.OK == printDialog.ShowDialog())
            {
                printDocument1.DocumentName = "Test Page Print";
                printDocument1.Print();
            }*/
            printDoc();
        }

        private void printDoc()
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "Blank Tag Summary";
            printer.SubTitle = "Report as on " + DateTime.Today.ToShortDateString();
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit |
            StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.ColumnWidth = DGVPrinter.ColumnWidthSetting.Porportional;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "";
            printer.FooterSpacing = 15;
            printer.PrintDataGridView(dgReport);
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //try
            //{
            //Set the left margin
            int iLeftMargin = e.MarginBounds.Left;
            //Set the top margin
            int iTopMargin = e.MarginBounds.Top;
            //Whether more pages have to print or not
            bool bMorePagesToPrint = false;
            int iTmpWidth = 0;

            //For the first page to print set the cell width and header height
            if (bFirstPage)
            {
                foreach (DataGridViewColumn GridCol in dgReport.Columns)
                {
                    iTmpWidth = (int)(Math.Floor((double)((double)GridCol.Width /
                        (double)iTotalWidth * (double)iTotalWidth *
                        ((double)e.MarginBounds.Width / (double)iTotalWidth))));

                    iHeaderHeight = (int)(e.Graphics.MeasureString(GridCol.HeaderText,
                        GridCol.InheritedStyle.Font, iTmpWidth).Height) + 11;

                    // Save width and height of headers
                    arrColumnLefts.Add(iLeftMargin);
                    arrColumnWidths.Add(iTmpWidth);
                    iLeftMargin += iTmpWidth;
                }
            }
            //Loop till all the grid rows not get printed
            while (iRow <= dgReport.Rows.Count - 1)
            {
                DataGridViewRow GridRow = dgReport.Rows[iRow];
                //Set the cell height
                iCellHeight = GridRow.Height + 5;
                int iCount = 0;
                //Check whether the current page settings allows more rows to print
                if (iTopMargin + iCellHeight >= e.MarginBounds.Height + e.MarginBounds.Top)
                {
                    bNewPage = true;
                    bFirstPage = false;
                    bMorePagesToPrint = true;
                    break;
                }
                else
                {

                    if (bNewPage)
                    {
                        //Draw Header
                        e.Graphics.DrawString(_ReportHeader,
                            new Font(dgReport.Font, FontStyle.Bold),
                            Brushes.Black, e.MarginBounds.Left,
                            e.MarginBounds.Top - e.Graphics.MeasureString(_ReportHeader,
                            new Font(dgReport.Font, FontStyle.Bold),
                            e.MarginBounds.Width).Height - 13);

                        String strDate = "";
                        //Draw Date
                        e.Graphics.DrawString(strDate,
                            new Font(dgReport.Font, FontStyle.Bold), Brushes.Black,
                            e.MarginBounds.Left +
                            (e.MarginBounds.Width - e.Graphics.MeasureString(strDate,
                            new Font(dgReport.Font, FontStyle.Bold),
                            e.MarginBounds.Width).Width),
                            e.MarginBounds.Top - e.Graphics.MeasureString(_ReportHeader,
                            new Font(new Font(dgReport.Font, FontStyle.Bold),
                            FontStyle.Bold), e.MarginBounds.Width).Height - 13);

                        //Draw Columns                 
                        iTopMargin = e.MarginBounds.Top;
                        DataGridViewColumn[] _GridCol = new DataGridViewColumn[dgReport.Columns.Count];
                        int colcount = 0;
                        //Convert ltr to rtl
                        foreach (DataGridViewColumn GridCol in dgReport.Columns)
                        {
                            _GridCol[colcount++] = GridCol;
                        }
                        for (int i = (_GridCol.Count() - 1); i >= 0; i--)
                        {
                            e.Graphics.FillRectangle(new SolidBrush(Color.LightGray),
                                new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                (int)arrColumnWidths[iCount], iHeaderHeight));

                            e.Graphics.DrawRectangle(Pens.Black,
                                new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                (int)arrColumnWidths[iCount], iHeaderHeight));

                            e.Graphics.DrawString(_GridCol[i].HeaderText,
                                _GridCol[i].InheritedStyle.Font,
                                new SolidBrush(_GridCol[i].InheritedStyle.ForeColor),
                                new RectangleF((int)arrColumnLefts[iCount], iTopMargin,
                                (int)arrColumnWidths[iCount], iHeaderHeight), strFormat);
                            iCount++;
                        }
                        bNewPage = false;
                        iTopMargin += iHeaderHeight;
                    }
                    iCount = 0;
                    DataGridViewCell[] _GridCell = new DataGridViewCell[GridRow.Cells.Count];
                    int cellcount = 0;
                    //Convert ltr to rtl
                    foreach (DataGridViewCell Cel in GridRow.Cells)
                    {
                        _GridCell[cellcount++] = Cel;
                    }
                    //Draw Columns Contents                
                    for (int i = (_GridCell.Count() - 1); i >= 0; i--)
                    {
                        if (_GridCell[i].Value != null)
                        {
                            e.Graphics.DrawString(_GridCell[i].FormattedValue.ToString(),
                                _GridCell[i].InheritedStyle.Font,
                                new SolidBrush(_GridCell[i].InheritedStyle.ForeColor),
                                new RectangleF((int)arrColumnLefts[iCount],
                                (float)iTopMargin,
                                (int)arrColumnWidths[iCount], (float)iCellHeight),
                                strFormat);
                        }
                        //Drawing Cells Borders 
                        e.Graphics.DrawRectangle(Pens.Black,
                            new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                            (int)arrColumnWidths[iCount], iCellHeight));
                        iCount++;
                    }
                }
                iRow++;
                iTopMargin += iCellHeight;
            }
            //If more lines exist, print another page.
            if (bMorePagesToPrint)
                e.HasMorePages = true;
            else
                e.HasMorePages = false;
        }

        private void _printDocument_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                strFormat = new StringFormat();
                strFormat.Alignment = StringAlignment.Near;
                strFormat.LineAlignment = StringAlignment.Center;
                strFormat.Trimming = StringTrimming.EllipsisCharacter;

                arrColumnLefts.Clear();
                arrColumnWidths.Clear();
                iCellHeight = 0;
                iRow = 0;
                bFirstPage = true;
                bNewPage = true;

                // Calculating Total Widths
                iTotalWidth = 0;
                foreach (DataGridViewColumn dgvGridCol in dgReport.Columns)
                {
                    iTotalWidth += dgvGridCol.Width;
                }
                iTotalWidth += 50;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
