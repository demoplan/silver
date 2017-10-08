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

        public Receipt()
        {
            InitializeComponent();
            ResetForm();
        }

        private void ResetForm()
        {
            try
            {
                this.dgvLP.ReadOnly = true;
                this.dgvSP.ReadOnly = true;
                dtDate.Value = DateTime.Now;

                using (entities = new DAL.Model.SilverEntities())
                {
                    var custSource = (from cust in entities.CustomerMs select new { Name = cust.CustName, ID = cust.Code }).ToList();
                    var prodSource = (from prod in entities.ProductMs select new { Name=prod.PName,ID=prod.ItemCode}).ToList();
                    var metalSource = (from metal in entities.MetalMs select new { Name = metal.MetalDesc, ID = metal.ID }).ToList();
                    var gridLP = entities.InOuts.ToList<InOut>();
                    var gridSP = entities.StockInfoes.ToList<StockInfo>();

                    //Bind Metal Combobox
                    cmbMetal.DataSource = metalSource;
                    cmbMetal.DisplayMember = "Name";
                    cmbMetal.ValueMember = "ID";

                    //Bind Customer Combobox
                    cmbCustomer.DataSource = custSource;
                    cmbCustomer.DisplayMember = "Name";
                    cmbCustomer.ValueMember = "ID";

                    //Bind Product Combobox LP
                    cmbLPCode.DataSource = prodSource;
                    cmbLPCode.DisplayMember = "Name";
                    cmbLPCode.ValueMember = "ID";

                    //Bind Product Combobox SP
                    cmbSPCode.DataSource = prodSource;
                    cmbSPCode.DisplayMember = "Name";
                    cmbSPCode.ValueMember = "ID";

                    var bindingListLP = new BindingList<InOut>(gridLP);
                    var sourceLP = new BindingSource(bindingListLP, null);
                    dgvLP.DataSource = sourceLP;

                    var bindingListSP = new BindingList<StockInfo>(gridSP);
                    var sourceSP = new BindingSource(bindingListSP, null);
                    dgvSP.DataSource = sourceSP;
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
            #region Calculation logic for GrossWT,NetWt,NetAmount
            BindingSource bslistLP = (BindingSource)dgvLP.DataSource;
            BindingList<InOut> listLP = (BindingList<InOut>)bslistLP.DataSource;

            BindingSource bslistSP = (BindingSource)dgvSP.DataSource;
            BindingList<StockInfo> listSP = (BindingList<StockInfo>)bslistSP.DataSource;

            decimal totalGsWtLP = 0, totalNetWtLP = 0, totalRateLP = 0;
            decimal?    totalNetAmtLP=0;
            foreach (InOut inout in listLP)
            {
                //totalGsWtLP = totalGsWtLP + Convert.ToDecimal(inout.GrossWt);
                //totalNetWtLP = totalNetWtLP + Convert.ToDecimal(inout.NetWt);
                totalNetAmtLP = totalNetAmtLP.Value + ((inout.Pcs != null || inout.Pcs > 0) ? inout.Rate * inout.Pcs : inout.Rate * inout.GrossWt);
            }

            decimal totalGsWtSP = 0, totalNetWtSP = 0, totalRateSP = 0;
            decimal? totalNetAmtSP = 0;
            foreach (StockInfo stockInfo in listSP)
            {
                //totalGsWtSP = totalGsWtSP + Convert.ToDecimal(stockInfo.GrossWt);
                //totalNetWtSP = totalNetWtSP + Convert.ToDecimal(stockInfo.NetWt);
                totalNetAmtSP = totalNetAmtSP.Value + (stockInfo.Rate * stockInfo.GrossWt);
            }
            #endregion Calculation logic for GrossWT,NetWt,NetAmount
            
            using (entities = new SilverEntities())
            {
                //Adding in Receipt
                int voucherNo = entities.Receipts.Count() + 1;
                DAL.Model.Receipt objRec = new DAL.Model.Receipt();
                objRec.VNo = voucherNo;
                objRec.VDate = dtDate.Value;
                objRec.LCode = Convert.ToString(cmbCustomer.SelectedValue);
                objRec.GrossWt = Convert.ToDecimal(tLPGsWt.Text.Trim()) + Convert.ToDecimal(tSPGsWt.Text.Trim());
                objRec.NetWt = Convert.ToDecimal(tLPNetWt.Text.Trim()) + Convert.ToDecimal(tSPNetWt.Text.Trim());                
                objRec.MakingRate = 100;
                objRec.MakingCharge = 100;
                objRec.RoundOff = 1;
                objRec.TotalAmt = totalNetAmtLP.Value + totalNetAmtSP.Value;
                entities.Receipts.Add(objRec);

                //Adding in InOut   
                foreach (InOut inout in listLP)
                {
                    inout.RefVNo = voucherNo;
                    entities.InOuts.Add(inout);
                }

                //Adding in StockInfo
                foreach (StockInfo stockInfo in listSP)
                {
                    stockInfo.RefVNo = voucherNo;
                    entities.StockInfoes.Add(stockInfo);
                }
                entities.SaveChanges();
            }



        }

        private void pbLPAdd_Click(object sender, EventArgs e)
        {            
            BindingSource bslistLP = (BindingSource)dgvLP.DataSource;
            BindingList<InOut> listLP = (BindingList<InOut>)bslistLP.DataSource;
            InOut inOut = new InOut();
            inOut.TDate = dtDate.Value;
            inOut.SeqNo = listLP.Count + 1;
            inOut.LCode = Convert.ToString(cmbCustomer.SelectedValue);
            inOut.MetalType = Convert.ToString(cmbLPCode.SelectedValue);
            inOut.PCode = Convert.ToString(cmbLPCode.SelectedValue);
            inOut.TType = "IN";
            inOut.RefVNo = 0;
            inOut.Pcs = Convert.ToDecimal(txtLPPcs.Text.Trim());
            inOut.GrossWt = Convert.ToDecimal(txtLPGsWt.Text.Trim());
            inOut.NetWt = Convert.ToDecimal(txtLPNetWt.Text.Trim());
            inOut.Rate = Convert.ToDecimal(txtLPRate.Text.Trim());
            listLP.Add(inOut);

            var bindingList = new BindingList<InOut>(listLP);
            var source = new BindingSource(bindingList, null);
            dgvLP.DataSource = source;
        }

        private void pbSPAdd_Click(object sender, EventArgs e)
        {
            BindingSource bslistSP = (BindingSource)dgvSP.DataSource;
            BindingList<StockInfo> listSP = (BindingList<StockInfo>)bslistSP.DataSource;
            StockInfo stockInfo = new StockInfo();
            stockInfo.TDate = dtDate.Value;
            stockInfo.SeqNo = listSP.Count + 1;
            stockInfo.LCode = Convert.ToString(cmbCustomer.SelectedValue);
            stockInfo.MetalType = Convert.ToString(cmbLPCode.SelectedValue);
            stockInfo.PCode = Convert.ToString(cmbSPCode.SelectedValue);
            stockInfo.TagNo = txtSPBarCode.Text.Trim();
            stockInfo.InType = "IN";
            stockInfo.RefVNo = 0;
            stockInfo.Pcs = 1;
            stockInfo.GrossWt = Convert.ToDecimal(txtSPGsWt.Text.Trim());
            stockInfo.NetWt = Convert.ToDecimal(txtSPNetWt.Text.Trim());
            stockInfo.Rate = Convert.ToDecimal(txtSPRate.Text.Trim());
            stockInfo.Photo = pbPhoto.ImageLocation;
            listSP.Add(stockInfo);

            var bindingList = new BindingList<StockInfo>(listSP);
            var source = new BindingSource(bindingList, null);
            dgvSP.DataSource = source;

        }

        private void dgvLP_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            BindingSource bslistLP = (BindingSource)dgvLP.DataSource;
            BindingList<InOut> listLP = (BindingList<InOut>)bslistLP.DataSource;
            decimal totalGsWt = 0,totalNetWt=0,totalRate=0;
            foreach(InOut inout in listLP)
            {
                totalGsWt = totalGsWt + Convert.ToDecimal(inout.GrossWt);
                totalNetWt = totalNetWt + Convert.ToDecimal(inout.NetWt);
                //totalRate = totalRate + Convert.ToDecimal(txtLPRate.Text.Trim());
            }
            tLPGsWt.Text = Convert.ToString(totalGsWt);
            tLPNetWt.Text = Convert.ToString(totalNetWt);
        }

        private void dgvSP_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            BindingSource bslistSP = (BindingSource)dgvSP.DataSource;
            BindingList<StockInfo> listSP = (BindingList<StockInfo>)bslistSP.DataSource;
            decimal totalGsWt = 0, totalNetWt = 0, totalRate = 0;
            foreach (StockInfo stockInfo in listSP)
            {
                totalGsWt = totalGsWt + Convert.ToDecimal(stockInfo.GrossWt);
                totalNetWt = totalNetWt + Convert.ToDecimal(stockInfo.NetWt);
                //totalRate = totalRate + Convert.ToDecimal(txtLPRate.Text.Trim());
            }
            tSPGsWt.Text = Convert.ToString(totalGsWt);
            tSPNetWt.Text = Convert.ToString(totalNetWt);
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
    }
}
