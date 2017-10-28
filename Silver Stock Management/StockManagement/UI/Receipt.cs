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
    public partial class Receipt : Form
    {
        DAL.Model.SilverEntities entities;
        private int voucherNo = 0;
        private bool modify = false;

        public Receipt(int vNo=0,bool edit=false)
        {
            this.voucherNo = vNo;
            this.modify = edit;
            InitializeComponent();
            ResetForm();
        }

        private void ResetForm()
        {
            try
            {
                this.dgvSP.ReadOnly = true;
                dtDate.Value = DateTime.Now;
                ResetInputControls();
                using (entities = new DAL.Model.SilverEntities())
                {
                    var custSource = (from cust in entities.CustomerMs select new { Name = cust.CustName, ID = cust.Code }).ToList();
                    var prodSource = (from prod in entities.ProductMs select new { Name=prod.PName,ID=prod.ItemCode}).ToList();
                    var metalSource = (from metal in entities.MetalMs select new { Name = metal.MetalDesc, ID = metal.ID }).ToList();
                    var receiptData = (from receipt in entities.Receipts where receipt.VNo == voucherNo select receipt).FirstOrDefault();
                    if (receiptData !=null)
                    {
                        dtDate.Value = receiptData.VDate.Value;
                        cmbCustType.SelectedValue = receiptData.CustType;
                        cmbCustomer.SelectedValue = receiptData.LCode;
                        txtTotalGsWt.Text = Convert.ToString(receiptData.GrossWt);
                        txtTotalNetWt.Text = Convert.ToString(receiptData.NetWt);
                        txtTotalMakingRate.Text = Convert.ToString(receiptData.MakingTotal);
                        txtRemark.Text = receiptData.Remarks;
                    }
                        var gridData = (
                                from rcpt in entities.Receipts
                                join
                                detail in entities.StockInfoes
                                on rcpt.ID equals detail.RefVNo
                                where rcpt.VNo == voucherNo
                                select new ReceiptModel
                                {
                                    TID = detail.TID,
                                    SeqNo = detail.SeqNo,
                                    TDate = detail.TDate,
                                    PCode = detail.PCode,
                                    BarCode = detail.BarCode,
                                    MetalType = detail.MetalType,
                                    InType = detail.InType,
                                    RefVNo = detail.RefVNo,
                                    JobNo = detail.JobNo,
                                    OrderNo = detail.OrderNo,
                                    Pcs = detail.Pcs,
                                    GrossWt = detail.GrossWt,
                                    NetWt = detail.NetWt,
                                    MakingRate = detail.MakingRate,
                                    TotalRate = detail.TotalRate,
                                    SellingRate = detail.SellingRate,
                                    Photo = detail.Photo//,
                                    //ProdImage = null
                                }
                                ).
                                Union
                                (
                                from rcpt in entities.Receipts
                                join
                                detail in entities.InOuts
                                on rcpt.ID equals detail.RefVNo
                                where rcpt.VNo == voucherNo
                                select new ReceiptModel
                                {
                                    TID = detail.TID,
                                    SeqNo = detail.SeqNo,
                                    TDate = detail.TDate,
                                    PCode = detail.PCode,
                                    BarCode = "",
                                    MetalType = detail.MetalType,
                                    InType = detail.TType,
                                    RefVNo = detail.RefVNo,
                                    JobNo = detail.JobNo,
                                    OrderNo = detail.OrderNo,
                                    Pcs = detail.Pcs,
                                    GrossWt = detail.GrossWt,
                                    NetWt = detail.NetWt,
                                    MakingRate = detail.MakingRate,
                                    TotalRate = detail.TotalRate,
                                    SellingRate = detail.SellingRate,
                                    Photo = ""//,
                                    //ProdImage = null
                                }
                                ).ToList<ReceiptModel>();
                                  
                    foreach(ReceiptModel rm in gridData)
                    {
                        rm.ProdImage = File.Exists(rm.Photo) ? Image.FromFile(rm.Photo) : null;
                    }

                    Dictionary<string, string> dicCustType = new Dictionary<string, string>();
                    dicCustType.Add("A", "Artisan");
                    dicCustType.Add("C", "Customer");
                    dicCustType.Add("D", "Dealer");
                    cmbCustType.DisplayMember = "Value";               
                    cmbCustType.DataSource = dicCustType.ToList();

                    //Bind Metal Combobox
                    cmbMetal.DataSource = metalSource;
                    cmbMetal.DisplayMember = "Name";
                    cmbMetal.ValueMember = "ID";

                    //Bind Customer Combobox
                    //cmbCustomer.DataSource = custSource;
                    //cmbCustomer.DisplayMember = "Name";
                    //cmbCustomer.ValueMember = "ID";


                    //Bind Product Combobox SP
                    cmbProductCode.DataSource = prodSource;
                    cmbProductCode.DisplayMember = "Name";
                    cmbProductCode.ValueMember = "ID";

                    this.txtVoucherNo.Text = voucherNo>0? voucherNo.ToString():"";
                    
                    var bindingListSP = new BindingList<ReceiptModel>(gridData);
                    var sourceSP = new BindingSource(bindingListSP, null);
                    dgvSP.DataSource = sourceSP;
                    dgvSP.Columns["TID"].Visible = false;
                    dgvSP.Columns["RefVNo"].Visible = false;
                    dgvSP.Columns["OutDate"].Visible = false;
                    dgvSP.Columns["OutBillNo"].Visible = false;
                    dgvSP.Columns["OutType"].Visible = false;

                    dgvSP.Columns["SeqNo"].HeaderText = "Seq No";
                    dgvSP.Columns["TDate"].HeaderText = "Date";
                    dgvSP.Columns["PCode"].HeaderText = "Item Name";
                    dgvSP.Columns["BarCode"].HeaderText = "Bar Code";
                    dgvSP.Columns["MetalType"].HeaderText = "Metal";
                    dgvSP.Columns["InType"].HeaderText = "Type";
                    
                    dgvSP.Columns["JobNo"].HeaderText = "Job No";
                    dgvSP.Columns["OrderNo"].HeaderText = "Order No";
                    dgvSP.Columns["Pcs"].HeaderText = "Quantity";
                    dgvSP.Columns["GrossWt"].HeaderText = "Gross Weight";
                    dgvSP.Columns["NetWt"].HeaderText = "Net Weight";
                    dgvSP.Columns["MakingRate"].HeaderText = "Making Rate";
                    dgvSP.Columns["TotalRate"].HeaderText = "Total Rate";
                    dgvSP.Columns["SellingRate"].HeaderText = "Selling Rate";
                    dgvSP.Columns["Photo"].HeaderText = "Photo";
                    
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
        
        private void pbSPAdd_Click(object sender, EventArgs e)
        {
            BindingSource bslistSP = (BindingSource)dgvSP.DataSource;
            BindingList<ReceiptModel> listSP = (BindingList<ReceiptModel>)bslistSP.DataSource;
            ReceiptModel model = new ReceiptModel();
            model.SeqNo = listSP.Count + 1;
            model.TDate = dtDate.Value;
            model.PCode = Convert.ToString(cmbProductCode.SelectedValue);
            model.BarCode = txtBarCode.Text.Trim();
            model.MetalType = Convert.ToString(cmbMetal.SelectedValue);
            model.InType = "IN";
            model.RefVNo = 0;
            model.JobNo = Convert.ToInt32(cmbJobeCode.SelectedValue);
            model.OrderNo = Convert.ToInt32(cmbOrderNo.SelectedValue);
            model.Pcs = Convert.ToDecimal(txtPCs.Text.Trim());
            model.GrossWt = Convert.ToDecimal(txtGsWt.Text.Trim());
            model.NetWt = Convert.ToDecimal(txtNetWt.Text.Trim());
            model.MakingRate = Convert.ToDecimal(txtMakingRate.Text.Trim());
            model.TotalRate = Convert.ToDecimal(txtTotalRate.Text.Trim());
            model.SellingRate = Convert.ToDecimal(txtSellingRate.Text.Trim());
            model.Photo = pbPhoto.ImageLocation;
            model.ProdImage = pbPhoto.Image;
            listSP.Add(model);

            var bindingList = new BindingList<ReceiptModel>(listSP);
            var source = new BindingSource(bindingList, null);
            dgvSP.DataSource = source;
            ResetInputControls();        
        }

        private void dgvSP_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            BindingSource bslistSP = (BindingSource)dgvSP.DataSource;
            BindingList<ReceiptModel> listSP = (BindingList<ReceiptModel>)bslistSP.DataSource;
            decimal totalGsWt = 0, totalNetWt = 0, totalRate = 0;
            foreach (ReceiptModel model in listSP)
            {
                totalGsWt = totalGsWt + Convert.ToDecimal(model.GrossWt);
                totalNetWt = totalNetWt + Convert.ToDecimal(model.NetWt);
                totalRate = totalRate + Convert.ToDecimal(model.TotalRate);
            }
            txtTotalGsWt.Text = Convert.ToString(totalGsWt);
            txtTotalNetWt.Text = Convert.ToString(totalNetWt);
            txtTotalMakingRate.Text = Convert.ToString(totalRate);
        }

        private void pbSPAddImage_Click(object sender, EventArgs e)
        {
            string filename;
            OpenFileDialog objOpenFD = new OpenFileDialog();
            objOpenFD.Title = "Please select image for product.";
            objOpenFD.Multiselect = false;
            objOpenFD.Filter = "Image Files|*.jpg;*.jpeg;*.png;"; //"JPEG files| *.jpg | PNG files | *.png | GIF Files | *.gif | TIFF Files | *.tif | BMP Files | *.bmp";
            if(objOpenFD.ShowDialog() == DialogResult.OK)
            {
                filename = objOpenFD.FileName;
                //Image img = Image.FromFile(filename);
                //pbPhoto.Image = img;
                pbPhoto.ImageLocation = filename;
            }
        }

        private void cmbCustType_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (entities = new DAL.Model.SilverEntities())
            {
                var custSource = (from cust in entities.CustomerMs
                                  where cust.CustType.Equals(((KeyValuePair<string,string>) cmbCustType.SelectedValue).Key)
                                  select new { Name = cust.CustName, ID = cust.Code }).ToList();

                //Bind Customer Combobox
                cmbCustomer.DataSource = custSource;
                cmbCustomer.DisplayMember = "Name";
                cmbCustomer.ValueMember = "ID";
                if (custSource.Count == 0)
                    cmbCustomer.Text = "";                
            }

        }

        private void txtNetWt_TextChanged(object sender, EventArgs e)
        {
            decimal dNetWt = 0, dMakingRate = 0,dTotalRate=0;
            if(!String.IsNullOrEmpty(txtNetWt.Text))
            {
                dNetWt = Convert.ToDecimal(txtNetWt.Text.Trim());
            }
            if (!String.IsNullOrEmpty(txtMakingRate.Text))
            {
                dMakingRate = Convert.ToDecimal(txtMakingRate.Text.Trim());
            }
            dTotalRate = dNetWt * dMakingRate;
            txtTotalRate.Text = dTotalRate.ToString();
        }

        private void txtMakingRate_TextChanged(object sender, EventArgs e)
        {
            decimal dNetWt = 0, dMakingRate = 0, dTotalRate = 0;
            if (!String.IsNullOrEmpty(txtNetWt.Text))
            {
                dNetWt = Convert.ToDecimal(txtNetWt.Text.Trim());
            }
            if (!String.IsNullOrEmpty(txtMakingRate.Text))
            {
                dMakingRate = Convert.ToDecimal(txtMakingRate.Text.Trim());
            }
            dTotalRate = dNetWt * dMakingRate;
            txtTotalRate.Text = dTotalRate.ToString();
        }

        private void Save()
        {
            BindingSource bslistSP = (BindingSource)dgvSP.DataSource;
            BindingList<ReceiptModel> listSP = (BindingList<ReceiptModel>)bslistSP.DataSource;

            using (entities = new SilverEntities())
            {
                //Adding in Receipt
                int voucherNo = entities.Receipts.Max(x => x.VNo).GetValueOrDefault() + 1;
                DAL.Model.Receipt objRec = new DAL.Model.Receipt();
                objRec.VNo = voucherNo;
                objRec.VDate = dtDate.Value;
                objRec.CustType = ((KeyValuePair<string, string>)cmbCustType.SelectedValue).Key;
                objRec.LCode = Convert.ToString(cmbCustomer.SelectedValue);
                objRec.GrossWt = Convert.ToDecimal(txtTotalGsWt.Text.Trim());
                objRec.NetWt = Convert.ToDecimal(txtTotalNetWt.Text.Trim());
                objRec.MakingTotal = Convert.ToDecimal(txtTotalMakingRate.Text.Trim());
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
                    DataGridViewRow dgvr = dgvSP.Rows[e.RowIndex];                    
                    this.cmbJobeCode.SelectedValue = Convert.ToString(dgvr.Cells["JobNo"].Value);
                    this.cmbMetal.SelectedValue = Convert.ToString(dgvr.Cells["MetalType"].Value);
                    this.cmbOrderNo.SelectedText = Convert.ToString(dgvr.Cells["OrderNo"].Value);
                    this.cmbProductCode.SelectedText = Convert.ToString(dgvr.Cells["PCode"].Value); 
                    this.txtPCs.Text = Convert.ToString(dgvr.Cells["PCs"].Value);
                    this.txtGsWt.Text = Convert.ToString(dgvr.Cells["GrossWt"].Value);
                    this.txtNetWt.Text = Convert.ToString(dgvr.Cells["NetWt"].Value);
                    this.txtMakingRate.Text = Convert.ToString(dgvr.Cells["MakingRate"].Value);
                    this.txtSellingRate.Text = Convert.ToString(dgvr.Cells["SellingRate"].Value);
                    this.txtBarCode.Text = Convert.ToString(dgvr.Cells["BarCode"].Value);
                    this.pbPhoto.Image = (Image)dgvr.Cells["ProdImage"].Value;
                }
            }
        }

        private void ResetInputControls()
        {
            this.cmbJobeCode.SelectedText = "";
            this.cmbOrderNo.SelectedText = "";
            this.cmbProductCode.SelectedText = "";
            this.txtPCs.Text = "";
            this.txtGsWt.Text = "";
            this.txtNetWt.Text = "";
            this.txtMakingRate.Text = "";
            this.txtSellingRate.Text = "";
            this.txtBarCode.Text = "";
            this.pbPhoto.Image = null;
        }
    }
}
