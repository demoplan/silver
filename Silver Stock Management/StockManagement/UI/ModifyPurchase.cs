using StockManagement.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace StockManagement.UI
{
    public partial class ModifyPurchase : Form
    {
        DAL.Model.SilverEntities entities;

        public ModifyPurchase()
        {
            InitializeComponent();
            Reset();
        }
                
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {            
            using (entities = new DAL.Model.SilverEntities())
            {
                decimal dFrom = 0, dTo = 0;
                decimal.TryParse(txtNetWtFrom.Text,out dFrom);
                decimal.TryParse(txtNetWtTo.Text,out dTo);
                var purchases = (from purchase in entities.Purchases
                                   .Where(x => (x.VDate.Value >= dtFromDate.Value && x.VDate.Value <= dtToDate.Value) || x.LCode.Contains(txtCustName.Text.Trim()) ||
                                   (x.NetWt >= dFrom && x.NetWt <= dTo))
                                orderby purchase.VNo descending
                                select purchase);
                dgModify.DataSource = purchases.ToList();
            }

            dgModify.Columns["ID"].Visible = false;
            //dgvSP.Columns["SeqNo"].HeaderText = "Seq No";
            //dgvSP.Columns["TDate"].HeaderText = "Date";
            //dgvSP.Columns["PCode"].HeaderText = "Item Name";
            //dgvSP.Columns["BarCode"].HeaderText = "Bar Code";
            //dgvSP.Columns["MetalType"].HeaderText = "Metal";
            //dgvSP.Columns["InType"].HeaderText = "Type";
        }

        private void dgModify_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow dgvr = dgModify.Rows[e.RowIndex];
                PurchaseNew objReceipt = new PurchaseNew(Convert.ToInt32(dgvr.Cells["VNo"].Value), true);

                this.Dispose();
                objReceipt.ShowDialog();                
            }
            

        }

        private void txtNetWtFrom_KeyPress(object sender, KeyPressEventArgs e)
        {
            dbUtils.onlyDecimal(sender, ref e);
        }

        private void txtNetWtTo_KeyPress(object sender, KeyPressEventArgs e)
        {
            dbUtils.onlyDecimal(sender, ref e);
        }

        private void Reset()
        {
            dtToDate.Value = DateTime.Today;
            dtFromDate.Value = DateTime.Today.AddDays(-10);
            using (entities = new DAL.Model.SilverEntities())
            {
                var purchases = (from purchase in entities.Purchases orderby purchase.VNo descending select purchase).Take(10);
                dgModify.DataSource = purchases.ToList();
            }            
        }

        private void dtToDate_ValueChanged(object sender, EventArgs e)
        {
            if (dtToDate.Value < dtFromDate.Value)
                dtToDate.Value = dtFromDate.Value;
        }

        private void dtFromDate_ValueChanged(object sender, EventArgs e)
        {
            if (dtFromDate.Value > dtToDate.Value)
                dtFromDate.Value = dtToDate.Value;
        }
    }
}
