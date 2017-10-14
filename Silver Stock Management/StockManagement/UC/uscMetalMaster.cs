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
    public partial class uscMetalMaster : UserControl
    {
        DAL.Model.SilverEntities entities;
        private int selectedID = 0;

        public uscMetalMaster()
        {
            InitializeComponent();
            this.dataGrid.ReadOnly = false;
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
                    if (!string.IsNullOrEmpty(txtMetalDesc.Text))
                    {
                        var metalExist = entities.MetalMs.FirstOrDefault(metal => metal.MetalDesc == txtMetalDesc.Text.Trim());
                        if (metalExist != null)
                        {
                            entities.Entry(metalExist).State = System.Data.Entity.EntityState.Deleted;
                            metalExist.MetalDesc = txtMetalDesc.Text.Trim();                          

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
                if (!string.IsNullOrEmpty(txtMetalDesc.Text))
                {
                    var metalExist = entities.MetalMs.FirstOrDefault(metal => metal.MetalDesc == txtMetalDesc.Text.Trim());
                    if (metalExist != null)
                    {
                        entities.Entry(metalExist).State = System.Data.Entity.EntityState.Modified;
                        metalExist.MetalDesc = txtMetalDesc.Text.Trim();                        
                    }
                    else
                    {
                        DAL.Model.MetalM obj = new DAL.Model.MetalM();
                        obj.MetalDesc = txtMetalDesc.Text.Trim();                        
                        entities.MetalMs.Add(obj);
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
                var datasource = from row in entities.MetalMs select row;
                dataGrid.DataSource = datasource.ToList();
                dataGrid.Columns["ID"].Visible = false;
                dataGrid.Columns["MetalDesc"].HeaderText = "Description";                
            }
        }

        private void dataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.btnModify.Text.ToLower().Trim() == "cancel")
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow dgvr = dataGrid.Rows[e.RowIndex];
                    txtMetalDesc.Text = Convert.ToString(dgvr.Cells[1].Value);                    
                    this.selectedID = Convert.ToInt32(dgvr.Cells[0].Value);
                }
            }
        }

        private void uscMetalMaster_Load(object sender, EventArgs e)
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
            this.txtMetalDesc.Text = "";            
        }
    }
}

