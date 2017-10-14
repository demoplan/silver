using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockManagement.UC
{
    public partial class uscDealerMaster : UserControl
    {
        DAL.Model.SilverEntities entities;
        private int selectedID = 0;

        public uscDealerMaster()
        {
            InitializeComponent();
            this.dataGrid.ReadOnly = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.ToString(), "Error");
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.btnModify.Text.ToLower().Trim() == "modify")
                {
                    this.ModifyCancel("cancel");
                }
                else
                {
                    this.ModifyCancel("modify");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.ToString(), "Error");
            }
        }

        private void btnDeleteC_Click(object sender, EventArgs e)
        {
            try
            {
                using (entities = new DAL.Model.SilverEntities())
                {
                    if (!string.IsNullOrEmpty(txtCustCode.Text) && !string.IsNullOrEmpty(txtCustName.Text))
                    {
                        var custExist = entities.CustomerMs.FirstOrDefault(cust => cust.Code == txtCustCode.Text.Trim());
                        if (custExist != null)
                        {
                            entities.Entry(custExist).State = System.Data.Entity.EntityState.Deleted;
                            entities.SaveChanges();
                            MessageBox.Show("Data Deleted Successfully.", "Product");
                            this.LoadGridData();
                            this.ModifyCancel("modify");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.ToString(), "Error");
            }
        }

        private void Save()
        {
            using (entities = new DAL.Model.SilverEntities())
            {
                if (!string.IsNullOrEmpty(txtCustCode.Text) && !string.IsNullOrEmpty(txtCustName.Text))
                {
                    var custExist = entities.CustomerMs.FirstOrDefault(cust => cust.Code == txtCustCode.Text.Trim());
                    if (custExist != null)
                    {
                        entities.Entry(custExist).State = System.Data.Entity.EntityState.Modified;
                        custExist.Code = txtCustCode.Text.Trim();
                        custExist.CustName = txtCustName.Text.Trim();
                        custExist.Phone = txtPhone.Text.Trim();
                        custExist.Email = txtEmail.Text.Trim();
                        custExist.PAN = txtPAN.Text.Trim();
                        custExist.CustAddress = txtAddress.Text.Trim();
                    }
                    else
                    {
                        DAL.Model.CustomerM obj = new DAL.Model.CustomerM();
                        obj.Code = txtCustCode.Text.Trim();
                        obj.CustName = txtCustName.Text.Trim();
                        obj.Phone = txtPhone.Text.Trim();
                        obj.Email = txtEmail.Text.Trim();
                        obj.PAN = txtPAN.Text.Trim();
                        obj.CustAddress = txtAddress.Text.Trim();
                        obj.CustType = "D";
                        entities.CustomerMs.Add(obj);
                    }
                    entities.SaveChanges();
                    this.LoadGridData();
                    this.ModifyCancel("modify");
                    MessageBox.Show("Data Saved Successfully.", "Product");
                }
            }
        }

        private void LoadGridData()
        {
            using (entities = new DAL.Model.SilverEntities())
            {
                var datasource = from row in entities.CustomerMs where row.CustType.Equals("D") select row;
                dataGrid.DataSource = datasource.ToList();                
                dataGrid.Columns["ID"].Visible = false;
                dataGrid.Columns["CustType"].Visible = false;
                dataGrid.Columns["Code"].HeaderText = "Code";
                dataGrid.Columns["CustName"].HeaderText = "Customer Name";
                dataGrid.Columns["Phone"].HeaderText = "Phone";
                dataGrid.Columns["Email"].HeaderText = "Email";
                dataGrid.Columns["PAN"].HeaderText = "PAN";
                dataGrid.Columns["CustAddress"].HeaderText = "Address";                
            }
        }

        private void dataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.btnModify.Text.ToLower().Trim() == "cancel")
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow dgvr = dataGrid.Rows[e.RowIndex];                    
                    this.selectedID = Convert.ToInt32(dgvr.Cells["ID"].Value);
                    txtCustCode.Text = Convert.ToString(dgvr.Cells["Code"].Value);
                    txtCustName.Text = Convert.ToString(dgvr.Cells["CustName"].Value);
                    txtPhone.Text = Convert.ToString(dgvr.Cells["Phone"].Value);
                    txtEmail.Text = Convert.ToString(dgvr.Cells["Email"].Value);
                    txtPAN.Text = Convert.ToString(dgvr.Cells["PAN"].Value);
                    txtAddress.Text = Convert.ToString(dgvr.Cells["CustAddress"].Value);
                }
            }
        }

        private void uscProductMaster_Load(object sender, EventArgs e)
        {
            this.LoadGridData();
        }

        private void ModifyCancel(string pModCan)
        {
            if (pModCan == "cancel")
            {
                this.btnModify.Text = "Cancel";
                this.btnDeleteC.Visible = true;
            }
            else if (pModCan == "modify")
            {
                this.btnModify.Text = "Modify";
                this.btnDeleteC.Visible = false;
            }
            txtCustCode.Text = "";
            txtCustName.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtPAN.Text = "";
            txtAddress.Text = "";
            this.selectedID = 0;
        }
    }
}
