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
           // ResetForm();
            populateCustomerDetail();
            formLoaded = true;
            ResetForm();
        }

        private void populateCustomerDetail()
        {
             using (entities = new DAL.Model.SilverEntities())
                {
                    var custSource = (from cust in entities.CustomerMs orderby cust.CustName select new { Name = cust.CustName, ID = cust.Code,  Address = cust.CustAddress, Email = cust.Email, Mobile = cust.Phone}).ToList();
                   // var metalSource = (from metal in entities.MetalMs orderby metal.MetalDesc).ToList();

                    cmbCustomer.DataSource = custSource;
                    cmbCustomer.DisplayMember = "Name";
                    cmbCustomer.ValueMember = "ID";
                    
                    var metalSource=entities.MetalMs.OrderBy((x)=>x.MetalDesc).ToList();
                    cmbMetal.DataSource = metalSource;
                    cmbMetal.DisplayMember = "MetalDesc"; 
                    cmbMetal.ValueMember = "ID";

                    var itemSource = entities.ProductMs.OrderBy((x) => x.PName).ToList();
                    cmbProductCode.DataSource = itemSource;
                    cmbProductCode.DisplayMember = "Pname";
                    cmbProductCode.ValueMember = "ItemCode";
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
                using (entities = new DAL.Model.SilverEntities())
                {

                    var gridData = (
                            from ordDetail in entities.OrderDetails
                            where ordDetail.orderNo == orderNo
                            select ordDetail).ToList();
                    var bindingListSP = new BindingList<OrderDetail>(gridData);
                    var sourceSP = new BindingSource(bindingListSP, null);
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
                   
                    dgvOrder.Columns["PCode"].HeaderText = "Item Name";
                    dgvOrder.Columns["Qty"].HeaderText = "Quantity";
                    dgvOrder.Columns["Weight"].HeaderText = "Weight";
                    dgvOrder.Columns["TotalWeight"].HeaderText = "Total Weight";
                }
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();  
        }
        
     

        private void calculateTotalWeight()
        {
            double total = 0;
            for (int i = 0; i < dgvOrder.Rows.Count; i++)
            {
                total+=double.Parse(dgvOrder.Rows[i].Cells[12].Value.ToString());
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
            BindingList<ReceiptModel> listSP = (BindingList<ReceiptModel>)bslistSP.DataSource;

            using (entities = new SilverEntities())
            {
                //Adding in Receipt
                int voucherNo = entities.Receipts.Max(x => x.VNo).GetValueOrDefault() + 1;
                DAL.Model.Receipt objRec = new DAL.Model.Receipt();
                objRec.VNo = voucherNo;
                objRec.VDate = dtDate.Value;
                objRec.LCode = Convert.ToString(cmbCustomer.SelectedValue);
                objRec.GrossWt = Convert.ToDecimal(txtTotalGsWt.Text.Trim());
                objRec.Remarks = txtRemark.Text.Trim();
                entities.Receipts.Add(objRec);

                foreach (ReceiptModel rcModel in listSP)
                {
                    if (String.IsNullOrEmpty(rcModel.BarCode))
                    {
                        //Add in InOut
                        InOut model = new InOut();
                        model.SeqNo = rcModel.SeqNo;
                        model.TDate = rcModel.TDate;
                        model.PCode = rcModel.PCode;
                        model.MetalType = rcModel.MetalType;
                        model.TType = rcModel.InType;
                        model.RefVNo = voucherNo;
                        model.JobNo = rcModel.JobNo;
                        model.OrderNo = rcModel.OrderNo;
                        model.Pcs = rcModel.Pcs;
                        model.GrossWt = rcModel.GrossWt;
                        model.NetWt = rcModel.NetWt;
                        model.MakingRate = rcModel.MakingRate;
                        model.TotalRate = rcModel.TotalRate;
                        model.SellingRate = rcModel.SellingRate;
                        entities.InOuts.Add(model);
                    }
                    else
                    {
                        //Add in StockInfo
                        StockInfo model = new StockInfo();
                        model.SeqNo = rcModel.SeqNo;
                        model.TDate = rcModel.TDate;
                        model.PCode = rcModel.PCode;
                        model.BarCode = rcModel.BarCode;
                        model.MetalType = rcModel.MetalType;
                        model.InType = rcModel.InType;
                        model.RefVNo = voucherNo;
                        model.JobNo = rcModel.JobNo;
                        model.OrderNo = rcModel.OrderNo;
                        model.Pcs = rcModel.Pcs;
                        model.GrossWt = rcModel.GrossWt;
                        model.NetWt = rcModel.NetWt;
                        model.MakingRate = rcModel.MakingRate;
                        model.TotalRate = rcModel.TotalRate;
                        model.SellingRate = rcModel.SellingRate;
                        model.Photo = rcModel.Photo;
                        entities.StockInfoes.Add(model);
                    }
                }
                entities.SaveChanges();
            }
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

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCustomer.SelectedIndex > -1 && formLoaded)
            {
                entities = new DAL.Model.SilverEntities();
                var result = (from cust in entities.CustomerMs where cust.Code == cmbCustomer.SelectedValue.ToString() select new { Name = cust.CustName, ID = cust.Code, Address = cust.CustAddress, Email = cust.Email, Mobile = cust.Phone }).FirstOrDefault();

                txtAddress.Text = result.Address;
                txtMobile.Text = result.Mobile;
                txtEmail.Text = result.Email;
            }

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

        private void pbSPAdd_Click_1(object sender, EventArgs e)
        {
            BindingSource bslistSP = (BindingSource)dgvOrder.DataSource;
            BindingList<OrderDetail> listSP = (BindingList<OrderDetail>)bslistSP.DataSource;
            OrderDetail model = new OrderDetail();
            model.LCode = cmbCustomer.SelectedValue.ToString();
            model.orderNo =Int32.Parse(txtOrderNo.Text);
            model.PCode = cmbProductCode.SelectedValue.ToString();
            model.qty =Int32.Parse(txtQty.Text);
            model.weight = Decimal.Parse(txtNetWt.Text);
            model.totalweight = model.qty * model.weight;
            model.orderType = "C";
            listSP.Add(model);
            calculateTotalWeight();
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
                ResetInputControls();
                cmbProductCode.Select();
            }
        }
    }
}
