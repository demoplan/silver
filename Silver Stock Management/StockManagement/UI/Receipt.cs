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
        private int seqNo = 0;
        public Receipt(int vNo = 0, bool edit = false)
        {
            this.voucherNo = vNo;
            this.modify = edit;
            InitializeComponent();
            entities = new SilverEntities();
            ResetForm();
            if (this.modify)
            {
                this.btnModify.Text = "Cancel";
                this.btnDelete.Visible = true;
            }
        }

        private void ResetForm()
        {
            try
            {
                this.dgvSP.ReadOnly = true;
                dtDate.Value = DateTime.Now;
                ResetInputControls();
                //using (entities = new DAL.Model.SilverEntities())
                //{
                var custSource = (from cust in entities.CustomerMs select new { Name = cust.CustName, ID = cust.Code }).ToList();
                var prodSource = (from prod in entities.ProductMs select new { Name = prod.PName, ID = prod.ItemCode }).ToList();
                var metalSource = (from metal in entities.MetalMs select new { Name = metal.MetalDesc, ID = metal.ID }).ToList();
                var receiptData = (from receipt in entities.Receipts where receipt.VNo == voucherNo select receipt).FirstOrDefault();
                if (receiptData != null)
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
                        on rcpt.VNo equals detail.RefVNo
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
                            Photo = detail.Photo,
                            StockInOut = "STOCK"
                                //ProdImage = null
                            }
                        ).
                        Union
                        (
                        from rcpt in entities.Receipts
                        join
                        detail in entities.InOuts
                        on rcpt.VNo equals detail.RefVNo
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
                            Photo = "",
                            StockInOut = "INOUT"
                                //ProdImage = null
                            }
                        ).OrderBy(x => x.SeqNo).ToList<ReceiptModel>();

                foreach (ReceiptModel rm in gridData)
                {
                    rm.ProdImage = File.Exists(rm.Photo) ? this.LoadImage(rm.Photo) : null;                    
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

                this.txtVoucherNo.Text = voucherNo > 0 ? voucherNo.ToString() : "";

                var bindingListSP = new BindingList<ReceiptModel>(gridData);
                var sourceSP = new BindingSource(bindingListSP, null);
                dgvSP.DataSource = sourceSP;
                dgvSP.Columns["TID"].Visible = false;
                dgvSP.Columns["RefVNo"].Visible = false;
                dgvSP.Columns["OutDate"].Visible = false;
                dgvSP.Columns["OutBillNo"].Visible = false;
                dgvSP.Columns["OutType"].Visible = false;
                dgvSP.Columns["StockInOut"].Visible = false;
                dgvSP.Columns["ProdImage"].Resizable = DataGridViewTriState.True;

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

                //}
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
            try
            {
                if (voucherNo > 0)
                    SaveModify(voucherNo);
                else
                    Save();

                MessageBox.Show("Saved successfully!","Save");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error while saving!","Save");
            }
        }

        private void pbSPAdd_Click(object sender, EventArgs e)
        {
            BindingSource bslistSP = (BindingSource)dgvSP.DataSource;
            BindingList<ReceiptModel> listSP = (BindingList<ReceiptModel>)bslistSP.DataSource;
            if (seqNo > 0 && modify == true)
            {
                var model = (from rcpt in listSP where rcpt.SeqNo == seqNo select rcpt).FirstOrDefault();
                if (model != null)
                {
                    model.TDate = dtDate.Value;
                    model.PCode = Convert.ToString(cmbProductCode.SelectedValue);
                    model.BarCode = txtBarCode.Text.Trim();
                    model.MetalType = Convert.ToString(cmbMetal.SelectedValue);
                    model.InType = "IN";
                    model.RefVNo = voucherNo;
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
                }
            }
            else
            {

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
            }

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

        private void dgvSP_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            BindingSource bslistSP = (BindingSource)dgvSP.DataSource;
            BindingList<ReceiptModel> listSP = (BindingList<ReceiptModel>)bslistSP.DataSource;
            decimal totalGsWt = 0, totalNetWt = 0, totalRate = 0;
            int seqNo = 1;
            foreach (ReceiptModel model in listSP)
            {
                model.SeqNo = seqNo++;

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
            if (objOpenFD.ShowDialog() == DialogResult.OK)
            {
                filename = objOpenFD.FileName;
                //Image img = Image.FromFile(filename);
                //pbPhoto.Image = img;
                pbPhoto.ImageLocation = filename;
            }
        }

        private void cmbCustType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //using (entities = new DAL.Model.SilverEntities())
            //{
            var custSource = (from cust in entities.CustomerMs
                              where cust.CustType.Equals(((KeyValuePair<string, string>)cmbCustType.SelectedValue).Key)
                              select new { Name = cust.CustName, ID = cust.Code }).ToList();

            //Bind Customer Combobox
            cmbCustomer.DataSource = custSource;
            cmbCustomer.DisplayMember = "Name";
            cmbCustomer.ValueMember = "ID";
            if (custSource.Count == 0)
                cmbCustomer.Text = "";
            //}

        }

        private void txtNetWt_TextChanged(object sender, EventArgs e)
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

            //using (entities = new SilverEntities())
            //{
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

                    //Add Image
                    this.savePictureToFile(model);
                    entities.StockInfoes.Add(model);
                }
            }
            entities.SaveChanges();
            //}
        }

        private void SaveModify(int voucherNo)
        {
            BindingSource bslistSP = (BindingSource)dgvSP.DataSource;
            BindingList<ReceiptModel> listSP = (BindingList<ReceiptModel>)bslistSP.DataSource;

            //Adding in Receipt
            var objRec = (from rec in entities.Receipts where rec.VNo == voucherNo select rec).FirstOrDefault();
            if (objRec != null)
            {
                objRec.VNo = voucherNo;
                objRec.VDate = dtDate.Value;
                objRec.CustType = ((KeyValuePair<string, string>)cmbCustType.SelectedValue).Key;
                objRec.LCode = Convert.ToString(cmbCustomer.SelectedValue);
                objRec.GrossWt = Convert.ToDecimal(txtTotalGsWt.Text.Trim());
                objRec.NetWt = Convert.ToDecimal(txtTotalNetWt.Text.Trim());
                objRec.MakingTotal = Convert.ToDecimal(txtTotalMakingRate.Text.Trim());
                objRec.Remarks = txtRemark.Text.Trim();
                entities.Entry(objRec).State = System.Data.Entity.EntityState.Modified;

                foreach (ReceiptModel rcModel in listSP)
                {
                    if (String.IsNullOrEmpty(rcModel.BarCode))
                    {
                        #region InOut
                        if (rcModel.TID > 0)
                        {
                            //Modify in InOut
                            var model = (from inout in entities.InOuts where inout.RefVNo == voucherNo && inout.TID == rcModel.TID select inout).FirstOrDefault();
                            if (model != null)
                            {
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
                                entities.Entry(model).State = System.Data.Entity.EntityState.Modified;
                            }
                        }
                        else
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
                        #endregion
                    }
                    else
                    {
                        #region StockInfo
                        if (rcModel.TID > 0)
                        {
                            //Modify in InOut
                            var model = (from stockInfo in entities.StockInfoes where stockInfo.RefVNo == voucherNo && stockInfo.TID == rcModel.TID select stockInfo).FirstOrDefault();
                            if (model != null)
                            {
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
                                
                                //Add Image
                                this.savePictureToFile(model);
                                entities.Entry(model).State = System.Data.Entity.EntityState.Modified;
                            }
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

                            //Add Image
                            this.savePictureToFile(model);
                            entities.StockInfoes.Add(model);
                        }
                        #endregion
                    }
                }
            }
            entities.SaveChanges();
            //}
        }

        private void dgvSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (modify)//this.btnModify.Text.ToLower().Trim() == "cancel")
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow dgvr = dgvSP.Rows[e.RowIndex];
                    this.seqNo = Convert.ToInt32(dgvr.Cells["SeqNo"].Value);
                    this.cmbJobeCode.SelectedValue = Convert.ToString(dgvr.Cells["JobNo"].Value);
                    this.cmbMetal.SelectedValue = Convert.ToInt32(dgvr.Cells["MetalType"].Value);
                    this.cmbOrderNo.SelectedValue = Convert.ToString(dgvr.Cells["OrderNo"].Value);
                    this.cmbProductCode.SelectedValue = Convert.ToString(dgvr.Cells["PCode"].Value);
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
            this.cmbJobeCode.SelectedIndex = -1;
            this.cmbOrderNo.SelectedIndex = -1;
            this.cmbProductCode.SelectedIndex = -1;
            this.txtPCs.Text = "";
            this.txtGsWt.Text = "";
            this.txtNetWt.Text = "";
            this.txtMakingRate.Text = "";
            this.txtSellingRate.Text = "";
            this.txtBarCode.Text = "";
            this.pbPhoto.Image = null;
            this.seqNo = 0;
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            this.Dispose();
            using (ModifyReceipt receipt = new ModifyReceipt())
            {
                receipt.ShowDialog();
            }

        }

        private void dgvSP_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (e.Row.Cells["OutDate"] != null && e.Row.Cells["OutDate"].Value != null)
            {
                e.Cancel = true;
                MessageBox.Show("you can not delete");
            }
            else
            {
                if (e.Row.Cells["TID"] != null && Convert.ToInt32(e.Row.Cells["TID"].Value) > 0 && e.Row.Cells["StockInOut"] != null)
                {
                    int TID = Convert.ToInt32(e.Row.Cells["TID"].Value);
                    if (Convert.ToString(e.Row.Cells["StockInOut"].Value).Trim() == "STOCK")
                    {
                        var model = (from stockInfo in entities.StockInfoes where stockInfo.RefVNo == voucherNo && stockInfo.TID == TID select stockInfo).FirstOrDefault();
                        entities.Entry(model).State = System.Data.Entity.EntityState.Deleted;
                    }
                    else if (Convert.ToString(e.Row.Cells["StockInOut"].Value).Trim() == "INOUT")
                    {
                        var model = (from inout in entities.InOuts where inout.RefVNo == voucherNo && inout.TID == TID select inout).FirstOrDefault();
                        entities.Entry(model).State = System.Data.Entity.EntityState.Deleted;
                    }
                    this.ResetInputControls();
                }
            }
        }

        private void pbRefresh_Click(object sender, EventArgs e)
        {
            //this.cmbJobeCode.SelectedIndex = -1;
            //this.cmbOrderNo.SelectedIndex = -1;
            //this.cmbProductCode.SelectedIndex = -1;            
            //this.txtPCs.Text = "";
            //this.txtGsWt.Text = "";
            //this.txtNetWt.Text = "";
            //this.txtMakingRate.Text = "";
            //this.txtSellingRate.Text = "";
            //this.txtBarCode.Text = "";
            //this.pbPhoto.Image = null;
            //this.seqNo = 0;
            this.ResetInputControls();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                //Check for deletion
                var modelOutDateAny = (from stockInfo in entities.StockInfoes where stockInfo.RefVNo == voucherNo && stockInfo.OutDate > DateTime.MinValue select stockInfo).FirstOrDefault();
                if (modelOutDateAny != null)
                {
                    //do nothing
                    MessageBox.Show("You can not delete!","Delete");
                }
                else
                {
                    //delete Receipt
                    var delRec = (from rec in entities.Receipts where rec.VNo == voucherNo select rec).FirstOrDefault();
                    entities.Entry(delRec).State = System.Data.Entity.EntityState.Deleted;
                    //delete InOut
                    var delInOut = (from inout in entities.InOuts where inout.RefVNo == voucherNo select inout).ToList();
                    foreach (InOut io in delInOut)
                        entities.Entry(io).State = System.Data.Entity.EntityState.Deleted;
                    //delete StockInfo
                    var delStockInfo = (from stockInfo in entities.StockInfoes where stockInfo.RefVNo == voucherNo select stockInfo).ToList();
                    foreach (StockInfo si in delStockInfo)
                        entities.Entry(si).State = System.Data.Entity.EntityState.Deleted;

                    entities.SaveChanges();

                    //Delete image folder as well
                    this.Close();
                    string path = Application.StartupPath + String.Format("\\Data\\Images\\{0}\\", voucherNo);
                    if (Directory.Exists(path))
                        Directory.Delete(path, true);

                    MessageBox.Show("Deleted successfully!","Delete");
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while deleting!","Delete");
            }
        }

        private void txtPCs_KeyPress(object sender, KeyPressEventArgs e)
        {
            dbUtils.onlyDecimal(sender, ref e);
        }

        private void txtGsWt_KeyPress(object sender, KeyPressEventArgs e)
        {
            dbUtils.onlyDecimal(sender, ref e);
        }

        private void txtNetWt_KeyPress(object sender, KeyPressEventArgs e)
        {
            dbUtils.onlyDecimal(sender, ref e);
        }

        private void txtMakingRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            dbUtils.onlyDecimal(sender, ref e);
        }

        private void txtSellingRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            dbUtils.onlyDecimal(sender, ref e);
        }

        //private void SaveImages(int voucherNo)
        //{
        //    var stockInfos = (from stk in entities.StockInfoes where stk.RefVNo == voucherNo select stk).ToList();
        //    foreach(StockInfo si in stockInfos)
        //    {
        //        savePictureToFile(si);
        //        entities.SaveChanges();
        //    }
        //}

        private void savePictureToFile(StockInfo model)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            try
            {
                Image stkImage = File.Exists(model.Photo) ? Image.FromFile(model.Photo) : null;
                if (stkImage == null)
                {
                    return;
                }
                
                string fileName = Guid.NewGuid().ToString();
                Bitmap bitmap;
                Image imgThumb;
                int thumbsize = 0;
                int newWidth = 0;
                int newHeight = 0;

                string path = Application.StartupPath + String.Format("\\Data\\Images\\{0}\\",model.RefVNo);
                //check for folder
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                fileName = String.Format(@"{0}{1}.jpg",path, fileName);
                thumbsize = 300;

                if (stkImage.Height > stkImage.Width)
                {
                    newHeight = Convert.ToInt32(thumbsize);
                    newWidth = Convert.ToInt32(stkImage.Width * thumbsize / stkImage.Height);
                }
                else
                {
                    newWidth = Convert.ToInt32(thumbsize);
                    newHeight = Convert.ToInt32(stkImage.Height * thumbsize / stkImage.Width);
                }

                imgThumb = stkImage.GetThumbnailImage(newWidth, newHeight, null, new IntPtr());
                bitmap = new Bitmap(imgThumb);
                bitmap.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                bitmap = null;
                model.Photo = fileName;
               // entities.Entry(model).State = System.Data.Entity.EntityState.Modified;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + System.Environment.NewLine + ex.StackTrace);
                throw new ArgumentException("Exception Occured : Image Saving Error");
            }
            finally
            {
                ms.Close();
            }
        }

        private Image LoadImage(string path)
        {
            Image img = null;
            using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                img = Image.FromStream(stream);//.GetThumbnailImage(60,60,null,IntPtr.Zero);                
                stream.Dispose();
            }
            return img;
        }
    }
}
