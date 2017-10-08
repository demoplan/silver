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
    public partial class uscProductMaster : UserControl
    {
        DAL.Model.SilverEntities entities;
        private int selectedID = 0;

        public uscProductMaster()
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
            catch(Exception ex)
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
                    if (!string.IsNullOrEmpty(txtItemCode.Text) && !string.IsNullOrEmpty(txtProdName.Text))
                    {
                        var prodExist = entities.ProductMs.FirstOrDefault(prod => prod.ItemCode == txtItemCode.Text.Trim());
                        if (prodExist != null)
                        {
                            entities.Entry(prodExist).State = System.Data.Entity.EntityState.Deleted;
                            prodExist.ItemCode = txtItemCode.Text.Trim();
                            prodExist.PName = txtProdName.Text.Trim();

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
                if (!string.IsNullOrEmpty(txtItemCode.Text) && !string.IsNullOrEmpty(txtProdName.Text))
                {                    
                    var prodExist = entities.ProductMs.FirstOrDefault(prod => prod.ItemCode == txtItemCode.Text.Trim());
                    if (prodExist != null)
                    {
                        entities.Entry(prodExist).State = System.Data.Entity.EntityState.Modified;
                        prodExist.ItemCode = txtItemCode.Text.Trim();
                        prodExist.PName = txtProdName.Text.Trim();                        
                    }
                    else
                    {
                        DAL.Model.ProductM obj = new DAL.Model.ProductM();                        
                        obj.ItemCode = txtItemCode.Text.Trim();
                        obj.PName = txtProdName.Text.Trim();                        
                        entities.ProductMs.Add(obj);
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
                var datasource = from row in entities.ProductMs select row;
                dataGrid.DataSource = datasource.ToList();
                dataGrid.Columns["ID"].Visible = false;
                dataGrid.Columns["ItemCode"].HeaderText = "Product Code";
                dataGrid.Columns["PName"].HeaderText = "Product Name";
                //if (datasource.ToList().Count > 0)
                //{
                //    var stone = datasource.ToList().FirstOrDefault();
                //    this.selectedID = stone.ID;
                //    this.txtItemCode.Text = stone.ItemCode;
                //    this.txtProdName.Text = stone.PName;
                //}
            }            
        }

        private void dataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.btnModify.Text.ToLower().Trim() == "cancel")
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow dgvr = dataGrid.Rows[e.RowIndex];
                    txtItemCode.Text = Convert.ToString(dgvr.Cells[1].Value);
                    txtProdName.Text = Convert.ToString(dgvr.Cells[2].Value);
                    this.selectedID = Convert.ToInt32(dgvr.Cells[0].Value);
                }
            }
        }

        private void uscProductMaster_Load(object sender, EventArgs e)
        {
            this.LoadGridData();
        }

        private void ModifyCancel(string pModCan)
        {
            if(pModCan == "cancel")
            {
                this.btnModify.Text = "Cancel";                
                this.btnDeleteC.Visible = true;
            }
            else if(pModCan== "modify")
            {
                this.btnModify.Text = "Modify";                
                this.btnDeleteC.Visible = false;                
            }
            this.txtItemCode.Text = "";
            this.txtProdName.Text = "";
        }
    }
}
