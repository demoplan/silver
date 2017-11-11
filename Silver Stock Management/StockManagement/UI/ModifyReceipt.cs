using StockManagement.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace StockManagement.UI
{
    public partial class ModifyReceipt : Form
    {
        DAL.Model.SilverEntities entities;

        public ModifyReceipt()
        {
            InitializeComponent();
            Reset();
        }

        private void chkDatewise_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDatewise.Checked)
            {
                dtFromDate.Enabled = true;
                dtToDate.Enabled = true;
                chkProductwise.Checked = false;
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
                txtCustName.Enabled = true;
                chkDatewise.Checked = false;
            }
            else
            {
                txtNetWtFrom.Enabled = false;
                txtNetWtTo.Enabled = false;
                txtCustName.Enabled = false;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {            
            using (entities = new DAL.Model.SilverEntities())
            {
                if (chkDatewise.Checked)
                {
                    var receipts = (from rcpt in entities.Receipts where (rcpt.VDate.Value >= dtFromDate.Value && rcpt.VDate.Value <= dtToDate.Value) orderby rcpt.VNo select rcpt);
                    dgModify.DataSource = receipts.ToList();
                }
                else if (chkProductwise.Checked)
                {
                    decimal dFrom = decimal.Parse(txtNetWtFrom.Text);
                    decimal dTo = decimal.Parse(txtNetWtTo.Text);
                   var receipts = (from rcpt in entities.Receipts
                                   .Where(x=>x.LCode.Contains(txtCustName.Text.Trim()) || 
                                   (x.NetWt >= dFrom && x.NetWt <=dTo )) orderby rcpt.VNo descending select rcpt);
                    dgModify.DataSource = receipts.ToList();
                }
                else
                {
                   var receipts = (from rcpt in entities.Receipts orderby rcpt.VNo descending select rcpt).Take(10);
                    dgModify.DataSource = receipts.ToList();
                }
                
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
                Receipt objReceipt = new Receipt(Convert.ToInt32(dgvr.Cells["VNo"].Value), true);

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
                var receipts = (from rcpt in entities.Receipts orderby rcpt.VNo descending select rcpt).Take(10);
                dgModify.DataSource = receipts.ToList();
            }            
        }
    }
}
