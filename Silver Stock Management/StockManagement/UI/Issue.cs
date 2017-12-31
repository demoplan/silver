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
    public partial class Issue : Form
    {
        DAL.Model.SilverEntities entities;
        private int voucherNo = 0;
        private bool modify = false;
        private int seqNo = 0;
        private string wtFormat = "0.000", rateFormat = "0.00";
        public Issue(int vNo = 0, bool edit = false)
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
                List<CustomerM> custSource = (from cust in entities.CustomerMs orderby cust.CustName select cust).ToList();
                // custSource   
                DataTable datatable = MiscUtils.ToDataTable<CustomerM>(custSource);

                //var custSource = (from cust in entities.CustomerMs select new { Name = cust.CustName, ID = cust.Code }).ToList();
                var prodSource = (from prod in entities.ProductMs select new { Name = prod.PName, ID = prod.ItemCode }).ToList();
                var metalSource = (from metal in entities.MetalMs select new { Name = metal.MetalDesc, ID = metal.ID }).ToList();
                var issueData = (from issue in entities.Issues where issue.VNo == voucherNo select issue).FirstOrDefault();
                var extraSettingCGST = (from extra in entities.ExtraSettings where extra.Settingkey == "CGST" select extra.SettingValue).FirstOrDefault();
                var extraSettingSGST = (from extra in entities.ExtraSettings where extra.Settingkey == "SGST" select extra.SettingValue).FirstOrDefault();
                if (extraSettingCGST != null)
                    txtCGSTRate.Text = extraSettingCGST;
                if (extraSettingSGST != null)
                    txtSGSTRate.Text = extraSettingSGST;

                if (issueData != null)
                {
                    dtDate.Value = issueData.VDate.Value;
                    cmbCustType.SelectedValue = issueData.CustType;
                    cmbCustomer.SelectedValue = issueData.LCode;
                    txtTotalGsWt.Text = Convert.ToDecimal(issueData.GrossWt).ToString(wtFormat);
                    txtTotalNetWt.Text = Convert.ToDecimal(issueData.NetWt).ToString(wtFormat);
                    txtTotalMakingRate.Text = Convert.ToDecimal(issueData.MakingTotal).ToString(rateFormat);
                    txtCGST.Text = Convert.ToDecimal(issueData.CGST).ToString(rateFormat);
                    txtSGST.Text = Convert.ToDecimal(issueData.SGST).ToString(rateFormat);
                    txtNetTotal.Text = Convert.ToDecimal(issueData.NetTotal).ToString(rateFormat);
                    txtRemark.Text = issueData.Remarks;
                }
                var gridData = (
                        from issu in entities.Issues
                        join
                        detail in entities.StockInfoes
                        on issu.VNo equals detail.OutBillNo
                        where issu.VNo == voucherNo && detail.OutType == "I"
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
                            RefVouType = detail.RefVouType,
                            Pcs = detail.Pcs,
                            GrossWt = detail.GrossWt,
                            NetWt = detail.NetWt,
                            MakingRate = detail.MakingRate,
                            TotalRate = detail.TotalRate,
                            Photo = detail.Photo,
                            StockInOut = "STOCK"
                            //ProdImage = null
                        }
                        ).
                        Union
                        (
                        from issu in entities.Issues
                        join
                        detail in entities.InOuts
                        on issu.VNo equals detail.RefVNo
                        where issu.VNo == voucherNo && detail.RefVouType == "I"
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
                            RefVouType = detail.RefVouType,
                            Pcs = detail.Pcs,
                            GrossWt = detail.GrossWt,
                            NetWt = detail.NetWt,
                            MakingRate = detail.MakingRate,
                            TotalRate = detail.TotalRate,
                            Photo = "",
                            StockInOut = "INOUT"
                            //ProdImage = null
                        }
                        ).OrderBy(x => x.SeqNo).ToList<ReceiptModel>();

                foreach (ReceiptModel rm in gridData)
                {
                    rm.ProdImage = MiscUtils.LoadImage(rm.Photo);//this.LoadImage(rm.Photo);
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
                dgvSP.Columns["SellingRate"].Visible = false;
                dgvSP.Columns["JobNo"].Visible = false;
                dgvSP.Columns["OrderNo"].Visible = false;
                dgvSP.Columns["TDate"].Visible = false;
                dgvSP.Columns["InType"].Visible = false;
                dgvSP.Columns["MetalType"].Visible = false;
                dgvSP.Columns["Photo"].Visible = false;

                dgvSP.Columns["SeqNo"].HeaderText = "Seq No";
                //dgvSP.Columns["TDate"].HeaderText = "Date";
                dgvSP.Columns["PCode"].HeaderText = "Item Name";
                dgvSP.Columns["BarCode"].HeaderText = "Bar Code";
                //dgvSP.Columns["MetalType"].HeaderText = "Metal";
                //dgvSP.Columns["InType"].HeaderText = "Type";

                //dgvSP.Columns["JobNo"].HeaderText = "Job No";
                //dgvSP.Columns["OrderNo"].HeaderText = "Order No";
                dgvSP.Columns["Pcs"].HeaderText = "Quantity";
                dgvSP.Columns["GrossWt"].HeaderText = "Gross Weight";
                dgvSP.Columns["NetWt"].HeaderText = "Net Weight";
                dgvSP.Columns["MakingRate"].HeaderText = "Making Rate";
                dgvSP.Columns["TotalRate"].HeaderText = "Total Rate";
                dgvSP.Columns["ProdImage"].HeaderText = "Photo";

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

                MessageBox.Show("Saved successfully!", "Save");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while saving!", "Save");
            }
        }

        private void pbSPAdd_Click(object sender, EventArgs e)
        {
            AddToGrid("INOUT");
        }

        private void AddToGrid(string pStockInout, StockInfo siModel = null)
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
                    model.Pcs = Convert.ToDecimal(txtPCs.Text.Trim());
                    model.GrossWt = Convert.ToDecimal(txtGsWt.Text.Trim());
                    model.NetWt = Convert.ToDecimal(txtNetWt.Text.Trim());
                    model.MakingRate = Convert.ToDecimal(txtMakingRate.Text.Trim());
                    model.TotalRate = Convert.ToDecimal(txtTotalRate.Text.Trim());
                    // model.SellingRate = Convert.ToDecimal(txtSellingRate.Text.Trim());
                }
            }
            else
            {
                if (pStockInout == "INOUT")
                {
                    ReceiptModel model = new ReceiptModel();
                    model.SeqNo = listSP.Count + 1;
                    model.TDate = dtDate.Value;
                    model.PCode = Convert.ToString(cmbProductCode.SelectedValue);
                    model.BarCode = txtBarCode.Text.Trim();
                    model.MetalType = Convert.ToString(cmbMetal.SelectedValue);
                    model.InType = "OUT";
                    model.RefVNo = 0;
                    model.RefVouType = "I";
                    model.Pcs = Convert.ToDecimal(txtPCs.Text.Trim());
                    model.GrossWt = Convert.ToDecimal(txtGsWt.Text.Trim());
                    model.NetWt = Convert.ToDecimal(txtNetWt.Text.Trim());
                    model.MakingRate = Convert.ToDecimal(txtMakingRate.Text.Trim());
                    model.TotalRate = Convert.ToDecimal(txtTotalRate.Text.Trim());
                    listSP.Add(model);
                }
                else if (pStockInout == "STOCKINFO" && siModel != null)
                {
                    ReceiptModel model = new ReceiptModel();
                    model.BarCode = siModel.BarCode;
                    model.PCode = siModel.PCode;
                    model.ProdImage = MiscUtils.LoadImage(siModel.Photo);//this.LoadImage(siModel.Photo);
                    model.Pcs = siModel.Pcs;
                    model.GrossWt = siModel.GrossWt;
                    model.NetWt = siModel.NetWt;
                    model.MakingRate = siModel.MakingRate;
                    model.TotalRate = siModel.TotalRate;
                    model.SeqNo = listSP.Count + 1;
                    listSP.Add(model);
                }
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
            txtTotalGsWt.Text = totalGsWt.ToString(wtFormat);
            txtTotalNetWt.Text = totalNetWt.ToString(wtFormat);
            txtTotalMakingRate.Text = totalRate.ToString(rateFormat);
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
            txtTotalGsWt.Text = totalGsWt.ToString(wtFormat);
            txtTotalNetWt.Text = totalNetWt.ToString(wtFormat);
            txtTotalMakingRate.Text = totalRate.ToString(rateFormat);
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
            //////////List<CustomerM> custSource = (from cust in entities.CustomerMs orderby cust.CustName select cust).ToList();
            //////////// custSource   
            //////////DataTable datatable = MiscUtils.ToDataTable<CustomerM>(custSource);
            //////////LoadComboBox(datatable);
        }

        //private void LoadComboBox(DataTable myDataTable)
        //{


        //    //Now set the Data of the ColumnComboBox
        //    myColumnComboBox.Data = myDataTable;
        //    myColumnComboBox.ValueMember = "CODE";
        //    myColumnComboBox.DisplayMember = "CustName";
        //    //Set which row will be displayed in the text box
        //    //If you set this to a column that isn't displayed then the suggesting functionality won't work.
        //    myColumnComboBox.ViewColumn = 2;
        //    //Set a few columns to not be shown
        //    myColumnComboBox.Columns[0].Display = false;
        //    //myColumnComboBox.Columns[1].Display = false;
        //    myColumnComboBox.Columns[3].Display = false;
        //    myColumnComboBox.Columns[7].Display = false;
        //}

        //private void myColumnComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
        //{
        //    //You can get data from the selected row out of the ColumnComboBox like this:
        //    if (myColumnComboBox1.SelectedIndex > -1)//If there is no selected index the indexer will return null
        //    {                
        //        myColumnComboBox.Text = myColumnComboBox["CustName"].ToString();
        //        myColumnComboBox.ValueMember = myColumnComboBox["Code"].ToString();
        //    }
        //}


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
            txtTotalRate.Text = dTotalRate.ToString(rateFormat);
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
            txtTotalRate.Text = dTotalRate.ToString(rateFormat);
        }

        private void Save()
        {
            BindingSource bslistSP = (BindingSource)dgvSP.DataSource;
            BindingList<ReceiptModel> listSP = (BindingList<ReceiptModel>)bslistSP.DataSource;

            int voucherNo = entities.Issues.Max(x => x.VNo).GetValueOrDefault() + 1;
            DAL.Model.Issue objIssue = new DAL.Model.Issue();
            objIssue.VNo = voucherNo;
            objIssue.VDate = dtDate.Value;
            objIssue.CustType = ((KeyValuePair<string, string>)cmbCustType.SelectedValue).Key;
            objIssue.LCode = Convert.ToString(cmbCustomer.SelectedValue);
            objIssue.GrossWt = Convert.ToDecimal(txtTotalGsWt.Text.Trim());
            objIssue.NetWt = Convert.ToDecimal(txtTotalNetWt.Text.Trim());
            objIssue.MakingTotal = Convert.ToDecimal(txtTotalMakingRate.Text.Trim());
            objIssue.CGST = Convert.ToDecimal(txtCGST.Text.Trim());
            objIssue.SGST = Convert.ToDecimal(txtSGST.Text.Trim());
            objIssue.NetTotal = Convert.ToDecimal(txtNetTotal.Text.Trim());
            objIssue.Remarks = txtRemark.Text.Trim();
            entities.Issues.Add(objIssue);

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
                    model.RefVouType = rcModel.RefVouType;
                    model.Pcs = rcModel.Pcs;
                    model.GrossWt = rcModel.GrossWt;
                    model.NetWt = rcModel.NetWt;
                    model.MakingRate = rcModel.MakingRate;
                    model.TotalRate = rcModel.TotalRate;
                    entities.InOuts.Add(model);
                }
                else
                {
                    //Update in StockInfo
                    var stockInfo = (from stk in entities.StockInfoes where stk.BarCode == rcModel.BarCode && (stk.OutBillNo == null || stk.OutBillNo <= 0) select stk).FirstOrDefault();
                    if (stockInfo != null)
                    {
                        stockInfo.OutBillNo = voucherNo;
                        stockInfo.OutType = "I";
                        stockInfo.OutDate = dtDate.Value;
                        entities.Entry(stockInfo).State = System.Data.Entity.EntityState.Modified;
                    }
                }
            }
            entities.SaveChanges();            
        }

        private void SaveModify(int voucherNo)
        {
            BindingSource bslistSP = (BindingSource)dgvSP.DataSource;
            BindingList<ReceiptModel> listSP = (BindingList<ReceiptModel>)bslistSP.DataSource;

            //Adding in Receipt
            var objIssue = (from issue in entities.Issues where issue.VNo == voucherNo select issue).FirstOrDefault();
            if (objIssue != null)
            {
                objIssue.VNo = voucherNo;
                objIssue.VDate = dtDate.Value;
                objIssue.CustType = ((KeyValuePair<string, string>)cmbCustType.SelectedValue).Key;
                objIssue.LCode = Convert.ToString(cmbCustomer.SelectedValue);
                objIssue.GrossWt = Convert.ToDecimal(txtTotalGsWt.Text.Trim());
                objIssue.NetWt = Convert.ToDecimal(txtTotalNetWt.Text.Trim());
                objIssue.MakingTotal = Convert.ToDecimal(txtTotalMakingRate.Text.Trim());
                objIssue.CGST = Convert.ToDecimal(txtCGST.Text.Trim());
                objIssue.SGST = Convert.ToDecimal(txtSGST.Text.Trim());
                objIssue.NetTotal = Convert.ToDecimal(txtNetTotal.Text.Trim());
                objIssue.Remarks = txtRemark.Text.Trim();
                entities.Entry(objIssue).State = System.Data.Entity.EntityState.Modified;

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
                                model.RefVouType = rcModel.RefVouType;
                                model.Pcs = rcModel.Pcs;
                                model.GrossWt = rcModel.GrossWt;
                                model.NetWt = rcModel.NetWt;
                                model.MakingRate = rcModel.MakingRate;
                                model.TotalRate = rcModel.TotalRate;
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
                            model.RefVouType = rcModel.RefVouType;
                            model.Pcs = rcModel.Pcs;
                            model.GrossWt = rcModel.GrossWt;
                            model.NetWt = rcModel.NetWt;
                            model.MakingRate = rcModel.MakingRate;
                            model.TotalRate = rcModel.TotalRate;
                            entities.InOuts.Add(model);
                        }
                        #endregion
                    }
                    else
                    {
                        #region StockInfo
                        //Update in StockInfo
                        var stockInfo = (from stk in entities.StockInfoes where stk.BarCode == rcModel.BarCode && (stk.OutBillNo == null || stk.OutBillNo <= 0) select stk).FirstOrDefault();
                        if (stockInfo != null)
                        {
                            stockInfo.OutBillNo = voucherNo;
                            stockInfo.OutType = "I";
                            stockInfo.OutDate = dtDate.Value;
                            entities.Entry(stockInfo).State = System.Data.Entity.EntityState.Modified;
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
                    this.cmbMetal.SelectedValue = Convert.ToInt32(dgvr.Cells["MetalType"].Value);
                    this.cmbProductCode.SelectedValue = Convert.ToString(dgvr.Cells["PCode"].Value);
                    this.txtPCs.Text = Convert.ToDecimal(dgvr.Cells["PCs"].Value).ToString(wtFormat);
                    this.txtGsWt.Text = Convert.ToDecimal(dgvr.Cells["GrossWt"].Value).ToString(wtFormat);
                    this.txtNetWt.Text = Convert.ToDecimal(dgvr.Cells["NetWt"].Value).ToString(wtFormat);
                    this.txtMakingRate.Text = Convert.ToDecimal(dgvr.Cells["MakingRate"].Value).ToString(rateFormat);
                    //this.txtSellingRate.Text = Convert.ToString(dgvr.Cells["SellingRate"].Value);
                    this.txtBarCode.Text = Convert.ToString(dgvr.Cells["BarCode"].Value);
                }
            }
        }

        private void ResetInputControls()
        {
            this.cmbProductCode.SelectedIndex = -1;
            this.txtPCs.Text = "";
            this.txtGsWt.Text = "";
            this.txtNetWt.Text = "";
            this.txtMakingRate.Text = "";
            //this.txtSellingRate.Text = "";
            this.txtBarCode.Text = "";
            this.seqNo = 0;
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            this.Dispose();
            using (ModifyIssue issue = new ModifyIssue())
            {
                issue.ShowDialog();
            }

        }

        private void dgvSP_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (e.Row.Cells["TID"] != null && Convert.ToInt32(e.Row.Cells["TID"].Value) > 0 && e.Row.Cells["StockInOut"] != null)
            {
                int TID = Convert.ToInt32(e.Row.Cells["TID"].Value);
                if (Convert.ToString(e.Row.Cells["StockInOut"].Value).Trim() == "STOCK")
                {
                    var model = (from stockInfo in entities.StockInfoes where stockInfo.OutBillNo == voucherNo && stockInfo.OutType == "I" && stockInfo.TID == TID select stockInfo).FirstOrDefault();

                    model.OutBillNo = null;
                    model.OutDate = null;
                    model.OutType = null;
                    entities.Entry(model).State = System.Data.Entity.EntityState.Modified;
                }
                else if (Convert.ToString(e.Row.Cells["StockInOut"].Value).Trim() == "INOUT")
                {
                    var model = (from inout in entities.InOuts where inout.RefVNo == voucherNo && inout.RefVouType == "I" && inout.TID == TID select inout).FirstOrDefault();
                    entities.Entry(model).State = System.Data.Entity.EntityState.Deleted;
                }
                this.ResetInputControls();
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
                //var modelOutDateAny = (from stockInfo in entities.StockInfoes where stockInfo.RefVNo == voucherNo && stockInfo.OutDate > DateTime.MinValue select stockInfo).FirstOrDefault();
                //if (modelOutDateAny != null)
                //{
                //    //do nothing
                //    MessageBox.Show("You can not delete!","Delete");
                //}
                //else
                //{
                //delete Issue
                var delIssue = (from issu in entities.Issues where issu.VNo == voucherNo select issu).FirstOrDefault();
                entities.Entry(delIssue).State = System.Data.Entity.EntityState.Deleted;
                //delete InOut
                var delInOut = (from inout in entities.InOuts where inout.RefVNo == voucherNo && inout.RefVouType == "I" select inout).ToList();
                foreach (InOut io in delInOut)
                    entities.Entry(io).State = System.Data.Entity.EntityState.Deleted;
                //delete StockInfo
                var delStockInfo = (from stockInfo in entities.StockInfoes where stockInfo.OutBillNo == voucherNo && stockInfo.OutType == "I" select stockInfo).ToList();
                foreach (StockInfo si in delStockInfo)
                {
                    si.OutBillNo = null;
                    si.OutDate = null;
                    si.OutType = null;
                    entities.Entry(si).State = System.Data.Entity.EntityState.Modified;
                }

                entities.SaveChanges();

                //Delete image folder as well
                this.Close();
                MessageBox.Show("Deleted successfully!", "Delete");
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while deleting!", "Delete");
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

        //private void savePictureToFile(StockInfo model)
        //{
        //    System.IO.MemoryStream ms = new System.IO.MemoryStream();
        //    try
        //    {
        //        Image stkImage = LoadImage(model.Photo);
        //        if (stkImage == null)
        //        {
        //            return;
        //        }

        //        string fileName = Guid.NewGuid().ToString();
        //        Bitmap bitmap;
        //        Image imgThumb;
        //        int thumbsize = 0;
        //        int newWidth = 0;
        //        int newHeight = 0;

        //        string path = Application.StartupPath + String.Format("\\Data\\Images\\{0}\\", model.RefVNo);
        //        model.Photo = String.Format("\\Data\\Images\\{0}\\{1}.jpg", model.RefVNo, fileName);
        //        //check for folder
        //        if (!Directory.Exists(path))
        //        {
        //            Directory.CreateDirectory(path);
        //        }
        //        fileName = String.Format(@"{0}{1}.jpg", path, fileName);
        //        thumbsize = 300;

        //        if (stkImage.Height > stkImage.Width)
        //        {
        //            newHeight = Convert.ToInt32(thumbsize);
        //            newWidth = Convert.ToInt32(stkImage.Width * thumbsize / stkImage.Height);
        //        }
        //        else
        //        {
        //            newWidth = Convert.ToInt32(thumbsize);
        //            newHeight = Convert.ToInt32(stkImage.Height * thumbsize / stkImage.Width);
        //        }

        //        imgThumb = stkImage.GetThumbnailImage(newWidth, newHeight, null, new IntPtr());
        //        bitmap = new Bitmap(imgThumb);
        //        bitmap.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
        //        bitmap = null;
        //        //model.Photo = fileName;
        //        // entities.Entry(model).State = System.Data.Entity.EntityState.Modified;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message + System.Environment.NewLine + ex.StackTrace);
        //        throw new ArgumentException("Exception Occured : Image Saving Error");
        //    }
        //    finally
        //    {
        //        ms.Close();
        //    }
        //}

        //private Image LoadImage(string path)
        //{
        //    string imgPath = Application.StartupPath + path;
        //    Image img = null;
        //    if (!File.Exists(imgPath))
        //        return null;
        //    using (FileStream stream = new FileStream(imgPath, FileMode.Open, FileAccess.Read))
        //    {
        //        img = Image.FromStream(stream);
        //        stream.Dispose();
        //    }
        //    return img;
        //}

        private void txtBarCode_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    var stockInfo = (from stk in entities.StockInfoes where stk.BarCode == txtBarCode.Text.Trim() && (stk.OutBillNo == null || stk.OutBillNo <= 0)  select stk).FirstOrDefault();
            //    if(stockInfo !=null)
            //    this.AddToGrid("STOCKINFO", stockInfo);
            //}
            //catch(Exception ex)
            //{
            //    MessageBox.Show("Error while getting details for Barcode :" + txtBarCode.Text, "Error");
            //}
        }

        private void MultiColumnComboBox()
        {

        }

        private void txtTotalMakingRate_TextChanged(object sender, EventArgs e)
        {
            RateCalculationOnTotal();
        }

        private void txtBarCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                try
                {
                    var stockInfo = (from stk in entities.StockInfoes where stk.BarCode == txtBarCode.Text.Trim() && (stk.OutBillNo == null || stk.OutBillNo <= 0) select stk).FirstOrDefault();
                    if (stockInfo != null)
                        this.AddToGrid("STOCKINFO", stockInfo);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while getting details for Barcode :" + txtBarCode.Text, "Error");
                }
            }
        }

        private void RateCalculationOnTotal()
        {
            decimal dTotalMakingRate = 0, dCGSTRate = 0, dSGSTRate = 0, dCGST = 0, dSGST = 0, dNetTotal = 0;
            //Total Making Rate
            if (!String.IsNullOrEmpty(txtTotalMakingRate.Text))
            {
                dTotalMakingRate = Convert.ToDecimal(txtTotalMakingRate.Text.Trim());
            }
            //CGST Rate
            if (!String.IsNullOrEmpty(txtCGSTRate.Text))
            {
                dCGSTRate = Convert.ToDecimal(txtCGSTRate.Text.Trim());
            }
            //SGST Rate
            if (!String.IsNullOrEmpty(txtSGSTRate.Text))
            {
                dSGSTRate = Convert.ToDecimal(txtSGSTRate.Text.Trim());
            }
            dCGST = dTotalMakingRate * dCGSTRate / 100;
            dSGST = dTotalMakingRate * dSGSTRate / 100;
            dNetTotal = dTotalMakingRate + dCGST + dSGST;

            txtCGST.Text = dCGST.ToString(rateFormat);
            txtSGST.Text = dSGST.ToString(rateFormat);
            txtNetTotal.Text = dNetTotal.ToString(rateFormat);
        }
    }
}
