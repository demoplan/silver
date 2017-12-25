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
using StockManagement.Utils;
using System.IO;
using StockManagement.DAL.Model;

namespace StockManagement.UI
{
    public partial class CustomerOrder : Form
    {
        static DAL.Model.SilverEntities entities;
        private int orderNo = 0;
        private bool modify = false;
        private bool formLoaded = false;
        public CustomerOrder(int oNo=0,bool edit=false)
        {
            this.orderNo = oNo;
            this.modify = edit;
            InitializeComponent();
            populateCustomerDetail();
            ResetForm();
            formLoaded = true;
            //ResetForm();
            txtOrderNo.Text = getMaxOrdernumber().ToString();
        }

        private void populateCustomerDetail()
        {
             using (entities = new DAL.Model.SilverEntities())
                {
                    List<CustomerM> custSource = (from cust in entities.CustomerMs orderby cust.CustName select cust).ToList();
                   // var metalSource = (from metal in entities.MetalMs orderby metal.MetalDesc).ToList();
                // custSource   
                    DataTable datatable = MiscUtils.ToDataTable<CustomerM>(custSource);

                    
                    var metalSource=entities.MetalMs.OrderBy((x)=>x.MetalDesc).ToList();
                    cmbMetal.DataSource = metalSource;
                    cmbMetal.DisplayMember = "MetalDesc"; 
                    cmbMetal.ValueMember = "ID";

                    var itemSource = entities.ProductMs.OrderBy((x) => x.PName).ToList();
                    cmbProductCode.DataSource = itemSource;
                    cmbProductCode.DisplayMember = "Pname";
                    cmbProductCode.ValueMember = "ItemCode";
                    //txtOrderNo.Text = getMaxOrdernumber().ToString();
                    LoadComboBox(datatable);


                    var gridData = (
                          from ordDetail in entities.OrderDetails
                          where ordDetail.orderNo == orderNo
                          select ordDetail).ToList();
                    var bindingListSP = new BindingList<OrderDetail>(gridData);
                    var sourceSP = new BindingSource(bindingListSP, null);
                    dgvOrder.DataSource = null;
                    dgvOrder.DataSource = sourceSP;

                    dgvOrder.Columns["TID"].Visible = false;
                    dgvOrder.Columns["Lcode"].Visible = false;
                    dgvOrder.Columns["KID"].Visible = false;
                    dgvOrder.Columns["artisanReqDate"].Visible = false;
                    dgvOrder.Columns["orderPlacedDate"].Visible = false;
                    dgvOrder.Columns["orderRecdDate"].Visible = false;
                    dgvOrder.Columns["JobNo"].Visible = false;
                    dgvOrder.Columns["orderType"].Visible = false;
                    dgvOrder.Columns["orderNo"].Visible = false;
                    dgvOrder.Columns["orderDate"].Visible = false;
                    dgvOrder.Columns["PCode"].HeaderText = "Item Name";
                    dgvOrder.Columns["Qty"].HeaderText = "Quantity";
                    dgvOrder.Columns["Weight"].HeaderText = "Weight";
                    dgvOrder.Columns["TotalWeight"].HeaderText = "Total Weight";
             }
        }

        private int getMaxOrdernumber()
        {
            using (var localentities = new DAL.Model.SilverEntities())
            {
                var maxOrder = localentities.OrderDetails.Max(p => (int?)p.orderNo);

                if (maxOrder == null)
                {
                    return 1;
                }
                else
                {
                    return (maxOrder.Value + 1);
                }
            }
        }

        public void loadDataByOrderNo(int orderNo)
        {
            using (entities = new DAL.Model.SilverEntities())
            {

                var gridData = (
                        from ordDetail in entities.OrderDetails
                        where ordDetail.orderNo == orderNo
                        select ordDetail).ToList();
                var bindingListSP = new BindingList<OrderDetail>(gridData);
                var sourceSP = new BindingSource(bindingListSP, null);
                dgvOrder.DataSource = null;
                dgvOrder.DataSource = sourceSP;

                dgvOrder.Columns["TID"].Visible = false;
                dgvOrder.Columns["Lcode"].Visible = false;
                dgvOrder.Columns["KID"].Visible = false;
                dgvOrder.Columns["artisanReqDate"].Visible = false;
                dgvOrder.Columns["orderPlacedDate"].Visible = false;
                dgvOrder.Columns["orderRecdDate"].Visible = false;
                dgvOrder.Columns["JobNo"].Visible = false;
                dgvOrder.Columns["orderType"].Visible = false;
                dgvOrder.Columns["orderNo"].Visible = false;
                dgvOrder.Columns["orderDate"].Visible = false;
                dgvOrder.Columns["PCode"].HeaderText = "Item Name";
                dgvOrder.Columns["Qty"].HeaderText = "Quantity";
                dgvOrder.Columns["Weight"].HeaderText = "Weight";
                dgvOrder.Columns["TotalWeight"].HeaderText = "Total Weight";


                var orderDetail = (from ordDetail in entities.CustomerOrderInfoes
                                   where ordDetail.orderNo == orderNo
                                   select ordDetail).ToList();
                if (orderDetail != null)
                {
                    CustomerOrderInfo orderInfo = orderDetail[0];
                    String custCode = orderInfo.lcode;
                    var customerInfo = (from custInfo in entities.CustomerMs where custInfo.Code.Equals(custCode) select custInfo).ToList();
                    txtMetalRate.Text = orderInfo.metalRate.ToString();
                    dtDate.Value = orderInfo.orderDate.Value;
                    dtDeliveryDate.Value = orderInfo.orderDeliveryDate.Value;
                    txtRemark.Text = orderInfo.remark;
                    myColumnComboBox.ValueMember = customerInfo[0].Code;
                    DataTable table=(DataTable)myColumnComboBox.Data;
                    DataRow[] foundRows = table.Select("Code = '" + customerInfo[0].Code +"'");
                    if (foundRows.Length > 0)
                    {
                        int SelectedIndex = table.Rows.IndexOf(foundRows[0]);
                        myColumnComboBox.SelectedIndex = SelectedIndex;
                    }
                    calculateTotalWeight();
                }
            }
        }
        private void ResetForm()
        {
            try
            {
                this.dgvOrder.ReadOnly = true;
                dtDate.Value = DateTime.Now;
                dtDeliveryDate.Value = DateTime.Now.AddDays(5);
               
                ResetInputControls();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.ToString(), "Error");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();      
        }

       
     

        private void calculateTotalWeight()
        {
            double total = 0;
            for (int i = 0; i < dgvOrder.Rows.Count; i++)
            {
                total+=double.Parse(dgvOrder.Rows[i].Cells[13].Value.ToString());
            }
            txtTotalGsWt.Text = total.ToString("#.000");
        }

        private void dgvSP_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            BindingSource bslistSP = (BindingSource)dgvOrder.DataSource;
            BindingList<ReceiptModel> listSP = (BindingList<ReceiptModel>)bslistSP.DataSource;
            decimal totalGsWt = 0, totalNetWt = 0, totalRate = 0;
            foreach (ReceiptModel model in listSP)
            {
                totalGsWt = totalGsWt + Convert.ToDecimal(model.GrossWt);
                totalNetWt = totalNetWt + Convert.ToDecimal(model.NetWt);
                totalRate = totalRate + Convert.ToDecimal(model.TotalRate);
            }
            txtTotalGsWt.Text = Convert.ToString(totalGsWt);
        }

        private void txtNetWt_TextChanged(object sender, EventArgs e)
        {
            decimal dNetWt = 0, dMakingRate = 0,dTotalRate=0;
            if(!String.IsNullOrEmpty(txtNetWt.Text))
            {
                dNetWt = Convert.ToDecimal(txtNetWt.Text.Trim());
            }
            if (!String.IsNullOrEmpty(txtTotalWeight.Text))
            {
                dMakingRate = Convert.ToDecimal(txtTotalWeight.Text.Trim());
            }
            dTotalRate = dNetWt * dMakingRate;
            txtMetalRate.Text = dTotalRate.ToString();
        }

        private void txtMakingRate_TextChanged(object sender, EventArgs e)
        {
            decimal dNetWt = 0, dMakingRate = 0, dTotalRate = 0;
            if (!String.IsNullOrEmpty(txtNetWt.Text))
            {
                dNetWt = Convert.ToDecimal(txtNetWt.Text.Trim());
            }
            if (!String.IsNullOrEmpty(txtTotalWeight.Text))
            {
                dMakingRate = Convert.ToDecimal(txtTotalWeight.Text.Trim());
            }
            dTotalRate = dNetWt * dMakingRate;
            txtMetalRate.Text = dTotalRate.ToString();
        }

        private void Save()
        {
            BindingSource bslistSP = (BindingSource)dgvOrder.DataSource;
            BindingList<OrderDetail> listSP = (BindingList<OrderDetail>)bslistSP.DataSource;
            int orderNo = getMaxOrdernumber();
            using (entities = new SilverEntities())
            {
                //Adding in Receipt
                
                DAL.Model.CustomerOrderInfo objOrder = new DAL.Model.CustomerOrderInfo();
                int totalQty = 0;
                foreach (OrderDetail lineItemModel in listSP)
                {
                    lineItemModel.orderNo = orderNo;
                    entities.OrderDetails.Add(lineItemModel);
                    totalQty += Int32.Parse(lineItemModel.qty.ToString());
                }

                objOrder.orderNo = getMaxOrdernumber();
                objOrder.orderDate = dtDate.Value;
                objOrder.orderDeliveryDate = dtDeliveryDate.Value;
                objOrder.lcode = Convert.ToString(myColumnComboBox.ValueMember);
                objOrder.orderTotalQty = totalQty;
                objOrder.metalType = Convert.ToString(cmbMetal.SelectedValue);
                objOrder.metalRate = Decimal.Parse(txtMetalRate.Text);
                objOrder.remark = txtRemark.Text.Trim();
                entities.CustomerOrderInfoes.Add(objOrder);

              
                entities.SaveChanges();
            }
            ResetForm();
            ResetAfterSave();
            
        }

        private void dgvSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (modify)//this.btnModify.Text.ToLower().Trim() == "cancel")
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow dgvr = dgvOrder.Rows[e.RowIndex];                    
                    this.cmbMetal.SelectedValue = Convert.ToString(dgvr.Cells["MetalType"].Value);
                    this.cmbProductCode.SelectedText = Convert.ToString(dgvr.Cells["PCode"].Value); 
                    this.txtQty.Text = Convert.ToString(dgvr.Cells["PCs"].Value);
                    this.txtNetWt.Text = Convert.ToString(dgvr.Cells["NetWt"].Value);
                    this.txtTotalWeight.Text = Convert.ToString(dgvr.Cells["MakingRate"].Value);
                }
            }
        }

        private void ResetInputControls()
        {
            this.cmbProductCode.SelectedText = "";
            this.txtQty.Text = "";
            this.txtNetWt.Text = "";
            this.txtTotalWeight.Text = "";
          
        }

        private void ResetAfterSave()
        {
            txtOrderNo.Text = getMaxOrdernumber().ToString();
            txtRemark.Text = "";
            txtMetalRate.Text = "";
            txtTotalGsWt.Text = "";
            this.dgvOrder.Rows.Clear();
            myColumnComboBox.Select();
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            Close();
        }

      

        private void cmbProductCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13 && cmbProductCode.SelectedIndex != -1)
            {
                txtQty.Select();
            }
        }

        private void txtPCs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13 && txtQty.Text.Length > 0)
            {
                txtNetWt.Select();
            }
            if (e.KeyValue == 13 && txtQty.Text.Length == 0)
            {
                txtQty.Text = "1";
                txtNetWt.Select();
            }
        }

        private bool validateEntry()
        {
            if (txtOrderNo.Text.Length == 0)
            {
                MessageBox.Show("Order no is not valid.");
                return false;
            }
            if (txtQty.Text == String.Empty || txtNetWt.Text == String.Empty)
            {
                MessageBox.Show("Please enter proper value.");
                return false;
            }
            return true;
        }
        private void pbSPAdd_Click_1(object sender, EventArgs e)
        {
            if (validateEntry())
            {
                BindingSource bslistSP = (BindingSource)dgvOrder.DataSource;
                BindingList<OrderDetail> listSP = (BindingList<OrderDetail>)bslistSP.DataSource;
                OrderDetail model = new OrderDetail();
                model.orderDate = dtDate.Value;
                model.LCode = myColumnComboBox.ValueMember.ToString();
                model.orderNo = Int32.Parse(txtOrderNo.Text);
                model.PCode = cmbProductCode.SelectedValue.ToString();
                model.qty = Int32.Parse(txtQty.Text);
                model.weight = Decimal.Parse(txtNetWt.Text);
                model.totalweight = model.qty * model.weight;
                model.orderType = "C";
                listSP.Add(model);
                calculateTotalWeight();
                ResetInputControls();
            }
        }

        private void txtNetWt_TextChanged_1(object sender, EventArgs e)
        {
            Decimal netWt;
            if (Decimal.TryParse(txtNetWt.Text,out netWt))
            {
                txtTotalWeight.Text =(Int32.Parse(txtQty.Text) * netWt).ToString("#.000");
            }
        }

        private void txtNetWt_KeyPress(object sender, KeyPressEventArgs e)
        {
            dbUtils.onlyDecimal(sender,ref e);
            if (e.KeyChar == 13 && txtNetWt.Text.Length>0)
            {
                pbSPAdd_Click_1(null, null);
                cmbProductCode.Select();
            }
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            Save();
        }

        private void changeButtonName(Button btn, string name)
        {
            btn.Text = name;
        }


        private void btnModify_Click(object sender, EventArgs e)
        {
            if (btnModify.Text.Equals("Modify"))
            {
                ModifyCustomerOrder modifyForm = new ModifyCustomerOrder(this);
                
                modifyForm.Location = new Point(8, 45);
                modifyForm.ShowDialog();
                changeButtonName(btnModify, "Cancel");
            }
            else
            {
                changeButtonName(btnModify, "Modify");
                changeButtonName(btnSave, "Save");
                ResetAfterSave();
                ResetForm();
                btnDelete.Visible = false;
            }
        }

        private void LoadComboBox(DataTable myDataTable)
        {
            

            //Now set the Data of the ColumnComboBox
            myColumnComboBox.Data = myDataTable;
            myColumnComboBox.ValueMember = "CODE";
            myColumnComboBox.DisplayMember = "CustName";
            //Set which row will be displayed in the text box
            //If you set this to a column that isn't displayed then the suggesting functionality won't work.
            myColumnComboBox.ViewColumn = 2;
            //Set a few columns to not be shown
            myColumnComboBox.Columns[0].Display = false;
            //myColumnComboBox.Columns[1].Display = false;
            myColumnComboBox.Columns[3].Display = false;
            myColumnComboBox.Columns[7].Display = false;
        }

        private void myColumnComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            //You can get data from the selected row out of the ColumnComboBox like this:
            if (myColumnComboBox.SelectedIndex > -1)//If there is no selected index the indexer will return null
            {
                txtEmail.Text = myColumnComboBox["email"].ToString();
                txtMobile.Text = myColumnComboBox["Phone"].ToString();
                txtAddress.Text = myColumnComboBox["CustAddress"].ToString();
                txtPanNo.Text = myColumnComboBox["PAN"].ToString();
                myColumnComboBox.Text = myColumnComboBox["CustName"].ToString();
                myColumnComboBox.ValueMember = myColumnComboBox["Code"].ToString();
            }
        }

      

    }
}
