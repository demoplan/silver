using DevComponents.DotNetBar;
using StockManagement.Master;
using StockManagement.Report;
using StockManagement.Transaction;
using StockManagement.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockManagement
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            setFullScreen();
            setMainPanelPosition();
            LoggingManager.settingLogLevel = 4;
        }
        private void setFullScreen()
        {
            int x = Screen.PrimaryScreen.Bounds.Width;
            int y = Screen.PrimaryScreen.Bounds.Height;
            GlobalVar.windowsHeight = y;
            GlobalVar.windowsWidth = x;
            //Location = new Point(0, 0);
            Size = new Size(x, y);
            btnClose.Location = new Point(x-btnClose.Size.Width-5,5);
            btnMinimize.Location = new Point(btnClose.Location.X - btnClose.Size.Width - 5, 5);
        }
        private void TransactionEntry(object sender, EventArgs e)
        {
            Purchase purchaseForm = new Purchase();
            purchaseForm.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState=FormWindowState.Minimized;
        }
        //method to set the position of the main panel that holds the controls to center of the form.
        private void setMainPanelPosition()
        {
            int mX = (Width - pnlContainer.Width) / 2;
            int mY = (Height - pnlContainer.Height) / 2;
            pnlContainer.Location = new Point(mX, mY);
        }

        private void stockIN_Click(object sender, EventArgs e)
        {
            StockManagement.Transaction.StockIN stockINForm = new StockManagement.Transaction.StockIN();
            stockINForm.ShowDialog();
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            StockManagement.Transaction.StockIN stockINForm = new StockManagement.Transaction.StockIN();
            stockINForm.ShowDialog();
        }

        private void panel1_MouseHover(object sender, EventArgs e)
        {
            panel1.Cursor = Cursors.Hand;
        }

      

        private void stockOut_Click(object sender, EventArgs e)
        {
            StockManagement.Transaction.StockOUT stockOut = new StockManagement.Transaction.StockOUT();
            stockOut.ShowDialog();
        }

        private void panelStockOut_MouseHover(object sender, EventArgs e)
        {
            panelGoldRate.Cursor = Cursors.Hand;
        }

        private void pnlMasterEntry_Click(object sender, EventArgs e)
        {
            //StockManagement.Transaction.Master masterForm = new StockManagement.Transaction.Master();
            StockManagement.UC.MasterNew masterForm = new UC.MasterNew();
            masterForm.ShowDialog();
        }

        private void pnlMasterEntry_MouseHover(object sender, EventArgs e)
        {
            pnlMasterEntry.Cursor = Cursors.Hand;
        }

        private void panelReport_MouseClick(object sender, MouseEventArgs e)
        {
            ReportView reportView = new ReportView();
            reportView.ShowDialog();
        }

        private void panelReport_MouseHover(object sender, EventArgs e)
        {
            panelReport.Cursor = Cursors.Hand;
        }

        private void panelImport_Click(object sender, EventArgs e)
        {
            Import importForm = new Import();
            importForm.ShowDialog();
        }

        private void panelImport_MouseHover(object sender, EventArgs e)
        {
            panelImport.Cursor = Cursors.Hand;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Import importForm = new Import();
            importForm.ShowDialog();
        }

        private void panelCalculator_Click(object sender, EventArgs e)
        {
            StockManagement.UI.Receipt objReceipt = new UI.Receipt();
            objReceipt.ShowDialog();
        }

        private void panelNotepad_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("notepad");
        }

        private void panelCalculator_MouseHover(object sender, EventArgs e)
        {
            panelCalculator.Cursor = Cursors.Hand;
        }

        private void panelNotepad_MouseHover(object sender, EventArgs e)
        {
            panelNotepad.Cursor = Cursors.Hand;
        }

        private void panelGoldRate_Click(object sender, EventArgs e)
        {
            
            pnlContainer.Visible = false;
            GoldRateMaster goldRateMasterForm = new GoldRateMaster();
            goldRateMasterForm.ShowDialog();
            pnlContainer.Visible = true;
            //goldRateMasterForm.Show();
        }
    }
}
