using StockManagement.DAL.Model;
using StockManagement.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace StockManagement.UI
{
    public partial class ModifyCustomerOrder : Form
    {
        DAL.Model.SilverEntities entities;
        CustomerOrder callingForm;

        public ModifyCustomerOrder()
        {
            InitializeComponent();
            Reset();
        }

        public ModifyCustomerOrder(CustomerOrder callingForm)
        {
            InitializeComponent();
            Reset();
            this.callingForm = callingForm;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {            
            using (entities = new DAL.Model.SilverEntities())
            {

                var orderQry = (from co in entities.CustomerOrderInfoes select co);

                if (dtFromDate.Value != null)
                {
                    orderQry = orderQry.Where(co => co.orderDate.Value >= dtFromDate.Value); 
                }

                if (dtToDate.Value != null)
                {
                    orderQry = orderQry.Where(co => co.orderDate.Value <= dtToDate.Value); 
                }

                if (cmbCustomer.SelectedIndex >=0)
                {
                    orderQry = orderQry.Where(co => co.lcode.Equals(cmbCustomer.ValueMember.ToString()));
                }
                

                dgModify.DataSource = orderQry.ToList();
                
            }           
            
      
        }

        private void dgModify_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow dgvr = dgModify.Rows[e.RowIndex];
                callingForm.loadDataByOrderNo(Convert.ToInt32(dgvr.Cells[1].Value));
                this.Dispose();
                
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
                var orderInfo = (from co in entities.CustomerOrderInfoes orderby co.orderNo descending select co).Take(10);
                dgModify.DataSource = orderInfo.ToList();
                dgModify.Columns[5].Visible = false;
                dgModify.Columns[6].Visible = false;
                dgModify.Columns[7].Visible = false;
                dgModify.Columns[8].Visible = false;
        

                List<CustomerM> custSource = (from cust in entities.CustomerMs orderby cust.CustName select cust).ToList();
                DataTable datatable = MiscUtils.ToDataTable<CustomerM>(custSource);
                LoadComboBox(datatable);
            }
        }

        private void LoadComboBox(DataTable myDataTable)
        {
          
            cmbCustomer.Data = myDataTable;
           
            //If you set this to a column that isn't displayed then the suggesting functionality won't work.
            cmbCustomer.ViewColumn = 2;
            //Set a few columns to not be shown
            cmbCustomer.Columns[0].Display = false;
            cmbCustomer.Columns[1].Display = false;
            cmbCustomer.Columns[3].Display = false;
            cmbCustomer.Columns[7].Display = false;
        }

        private void myColumnComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            //You can get data from the selected row out of the ColumnComboBox like this:
            if (cmbCustomer.SelectedIndex > -1)//If there is no selected index the indexer will return null
            {
                cmbCustomer.ValueMember = cmbCustomer["Code"].ToString();
            }
            else
            {
                cmbCustomer.ValueMember = "";
            }
        }

       
    }
}
