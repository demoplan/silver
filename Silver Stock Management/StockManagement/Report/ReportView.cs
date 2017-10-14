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

namespace StockManagement.Report
{
    public partial class ReportView : Form
    {
        public ReportView()
        {
            InitializeComponent();
            setFullScreen();
            setMainPanelPosition();
            loadFormIntoPanel();
            loadFormInvoiceIntoPanel();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            dbUtils.disConnect();
            Close();
        }

        private void loadFormIntoPanel()
        {
            StockSummary stockSummaryForm = new StockSummary();
            stockSummaryForm.TopLevel = false;
            stockSummaryForm.AutoScroll = true;
            this.pnlStockDetail.Controls.Add(stockSummaryForm);
            stockSummaryForm.Show();
        }

        private void loadFormInvoiceIntoPanel()
        {
            InvoicePrinting invoicePrintingForm = new InvoicePrinting();
            invoicePrintingForm.TopLevel = false;
            invoicePrintingForm.AutoScroll = true;
            this.pnlInvoiceDetail.Controls.Add(invoicePrintingForm);
            invoicePrintingForm.Show();
        }

        private void pnlMasterEntry_MouseClick(object sender, MouseEventArgs e)
        {
            DailyStock dailyStock = new DailyStock();
            dailyStock.ShowDialog();
        }

        private void setFullScreen()
        {
            int x = Screen.PrimaryScreen.Bounds.Width;
            int y = Screen.PrimaryScreen.Bounds.Height;
            GlobalVar.windowsHeight = y;
            GlobalVar.windowsWidth = x;
            Size = new Size(x, y);
            btnClose.Location = new Point(x - btnClose.Size.Width - 5, 5);
        }

        private void setMainPanelPosition()
        {
            int mX = (Width - pnlContainer.Width) / 2;
            int mY = (Height - pnlContainer.Height) / 2;
            pnlContainer.Location = new Point(mX, mY);
        }

        private void pnlMasterEntry_MouseHover(object sender, EventArgs e)
        {
            pnlMasterEntry.Cursor = Cursors.Hand;
        }

        private void pnlEmptyTag_Click(object sender, EventArgs e)
        {
            EmptyTag form = new EmptyTag();
            form.ShowDialog();
        }

        private void pnlEmptyTag_MouseHover(object sender, EventArgs e)
        {
            pnlEmptyTag.Cursor = Cursors.Hand;
        }

        private void pnlStockDetail_MouseClick(object sender, MouseEventArgs e)
        {
            StockSummary form = new StockSummary();
            form.ShowDialog();
        }
    }
}
