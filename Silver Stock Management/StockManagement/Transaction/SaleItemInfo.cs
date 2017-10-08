using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using StockManagement.Utils;
using StockManagement.Master;

namespace StockManagement.Transaction
{
    public partial class SaleItemInfo : Form
    {
        private ItemInfo itemInfo;
        private  Sales salesForm;
        private int currentStatus; // 0 - mean new entry , 1 - mean modification
        string filePath;
        const string NO_IMAGE = "No_image";

        internal ItemInfo ItemInfo
        {
            get { return itemInfo; }
            set { itemInfo = value; }
        }

        public SaleItemInfo()
        {
            InitializeComponent();
            //setMainPanelPosition();
            dbUtils.connection();
        }

        public SaleItemInfo(ItemInfo item,Sales form)
        {
            InitializeComponent();
            //setMainPanelPosition();
            ItemInfo = item;
            salesForm = form;
            this.loadData(itemInfo);
            currentStatus = 0;
        }


        public SaleItemInfo(SalesLineItemDetail saleLineItemDetail, Sales form)
        {
            InitializeComponent();
            //setMainPanelPosition();
            itemInfo = new ItemInfo();
            itemInfo.ItemCode = saleLineItemDetail.ItemDesc;
            itemInfo.TagNo = saleLineItemDetail.TagNo;
            itemInfo.Pcs = saleLineItemDetail.Tid;
            itemInfo.SaleDate = form.selectedDate;
            salesForm = form;
            this.loadData(itemInfo);
            setVariousCharges(saleLineItemDetail);
            currentStatus = 1;
        }

        private void setVariousCharges(SalesLineItemDetail itemDetail)
        {
            cmbMakingOn.Text = itemDetail.MakingOn;
            txtMakingRate.Text = dbUtils.Decimal2digit(itemDetail.MakingRate.ToString());
            txtMakingChg.Text = dbUtils.Decimal2digit(itemDetail.MakingAmt.ToString());

            if (itemDetail.OtheChgAmt > 0)
            {
                cmbOtherChg.Text = itemDetail.OtheChgOn;
                txtOtherRate.Text = dbUtils.Decimal2digit(itemDetail.OtheChgRate.ToString());
                txtOtherChg.Text = dbUtils.Decimal2digit(itemDetail.OtheChgAmt.ToString());
            }
            
        }

        private void loadData(ItemInfo itemInfo)
        {
            lblItem.Text = itemInfo.ItemCode;
            lblTagNo.Text = itemInfo.TagNo.ToString();
            lblDate.Text = itemInfo.SaleDate.ToShortDateString();
             string sqlQry = "SELECT * FROM TRANS WHERE TID = "+ itemInfo.Pcs;
             OleDbDataReader oleDbDataReader = dbUtils.fetch(sqlQry);
            if (oleDbDataReader.HasRows)
            {

              
                oleDbDataReader.Read();
                if (!oleDbDataReader["Photo"].Equals(DBNull.Value) && oleDbDataReader.GetString(8).Length > 0)
                {
                    filePath = Application.StartupPath + "//Data//Images//" + oleDbDataReader.GetString(8);
                }
                else
                {
                    filePath = Application.StartupPath + "//Data//Images//No_image.jpg";
                }

                if (filePath.Length > 0)
                {
                    Image photo = Image.FromFile(filePath);
                    pbPhoto.Image = photo;
                }
                else
                {
                    pbPhoto.Image = null;
                }

                lblGrossWt.Text = dbUtils.Decimal3digit(oleDbDataReader["gw"].ToString().Trim()).Trim();
                lblNetWt.Text = dbUtils.Decimal3digit(oleDbDataReader["nw"].ToString().Trim()).Trim();
                txtMetalWeight.Text = dbUtils.Decimal3digit(oleDbDataReader["nw"].ToString().Trim()).Trim();
                lblPcs.Text = oleDbDataReader["pcs"].ToString();
                lblMetalType.Text = oleDbDataReader["metaltype"].ToString();
                itemInfo.Tid = int.Parse(oleDbDataReader["tid"].ToString());
            }
            oleDbDataReader.Close();
            getStoneDetail(itemInfo);
            getMetalRate();
            cmbMakingOn.Select();
        }

        private void getStoneDetail(ItemInfo itemInfo)
        {
            int rowCount = 1;
            string sqlQry = "SELECT * FROM STONEDATA WHERE PID =" + ItemInfo.Pcs + " ORDER BY STYPE";
             OleDbDataReader oleDbDataReader = dbUtils.fetch(sqlQry);
             if (oleDbDataReader.HasRows)
             {
                 while (oleDbDataReader.Read())
                 {
                     string[] row = new string[] { rowCount++.ToString(), oleDbDataReader["SDESC"].ToString(), oleDbDataReader["stype"].ToString(), dbUtils.Decimal2digit(oleDbDataReader["swt"].ToString()), dbUtils.Decimal2digit(oleDbDataReader["srate"].ToString()), dbUtils.Decimal2digit(oleDbDataReader["samt"].ToString()) };
                     dgDiamond.Rows.Add(row);
                 }
             }
             oleDbDataReader.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            dbUtils.disConnect();
            Close();
        }

        private void setMainPanelPosition()
        {
            int x = Screen.PrimaryScreen.Bounds.Width;
            int y = Screen.PrimaryScreen.Bounds.Height;
            Size = new Size(x, y);
            btnClose.Location = new Point(x - btnClose.Size.Width - 5, 5);
            int mX = (Width - mainPanel.Width) / 2;
            int mY = (Height - mainPanel.Height) / 2;
            mainPanel.Location = new Point(mX, mY);
        }

        private void calculate()
        {
            double totalChg = 0;
            double metalValue = 0;
            double diamondValue = 0;
            double stoneValue = 0;
            double makingCharges = 0;
            double otherCharges = 0;

            if (txtMetalRate.Text.Length > 0 && double.Parse(txtMetalRate.Text) > 0)
            {
                txtMetalValue.Text = dbUtils.Decimal2digit(Math.Round(double.Parse(lblNetWt.Text) * double.Parse(txtMetalRate.Text), 0).ToString());
            }

            diamondValue = getDiamondValue();
            stoneValue = getStoneValue();
            txtDiamond.Text = dbUtils.Decimal2digit(diamondValue.ToString());
            txtStone.Text = dbUtils.Decimal2digit(stoneValue.ToString());
            txtStDiaTotal.Text = dbUtils.Decimal2digit((diamondValue + stoneValue).ToString());
            txtMakingChg.Text = dbUtils.Decimal2digit(getMakingCharges().ToString());
            txtOtherChg.Text = dbUtils.Decimal2digit(getOtherCharges().ToString());

            double.TryParse(txtMetalValue.Text,out metalValue);
            double.TryParse(txtStDiaTotal.Text, out diamondValue);
            double.TryParse(txtMakingChg.Text, out makingCharges);
            double.TryParse(txtOtherChg.Text, out otherCharges);

            totalChg = metalValue + diamondValue + makingCharges + otherCharges;
            txtTotalValue.Text = dbUtils.Decimal2digit(Math.Round(totalChg, 2).ToString());
        }

        private double getDiamondValue()
        {
            double amount = 0;
            double value=0;
            foreach (DataGridViewRow item in dgDiamond.Rows)
            {
                if (item.Cells[2].Value.ToString() == "D")
                {
                    if (double.TryParse(item.Cells[5].Value.ToString(), out value))
                    {
                        amount += value;
                    }
                }
                
            }
            return amount;
        }

        private double getDiamondWeight()
        {
            double weight = 0;
            foreach (DataGridViewRow item in dgDiamond.Rows)
            {
                if (item.Cells[2].Value.ToString() == "D")
                    weight += double.Parse(item.Cells[3].Value.ToString());
            }
            return weight;
        }

        private double getStoneValue()
        {
            double amount = 0;
            foreach (DataGridViewRow item in dgDiamond.Rows)
            {
                if (item.Cells[2].Value.ToString() == "S")
                    amount += double.Parse(item.Cells[5].Value.ToString());
            }
            return amount;
        }

        private double getStoneWeight()
        {
            double weight = 0;
            foreach (DataGridViewRow item in dgDiamond.Rows)
            {
                if (item.Cells[2].Value.ToString() == "S")
                    weight += double.Parse(item.Cells[3].Value.ToString());
            }
            return weight;
        }

        private double getMakingCharges()
        {
            //Pcs,Grm,Item
            double amount = 0;
            if(txtMakingRate.Text.Length > 0 && double.Parse(txtMakingRate.Text) > 0)
            {
                if (cmbMakingOn.Text.Equals("Pcs"))
                {
                    amount = Math.Round(int.Parse(lblPcs.Text) * double.Parse(txtMakingRate.Text), 2);
                }
                else if (cmbMakingOn.Text.Equals("Grm"))
                {
                    amount = Math.Round(double.Parse(lblNetWt.Text) * double.Parse(txtMakingRate.Text), 2);
                }
                else if (cmbMakingOn.Text.Equals("Item"))
                {
                    amount = double.Parse(txtMakingRate.Text);
                }
            }
            return amount;
        }

        private double getOtherCharges()
        {
            //Pcs,Grm,Item
            double amount = 0;
            if (txtOtherRate.Text.Length > 0 && double.Parse(txtOtherRate.Text) > 0)
            {
                if (cmbOtherChg.Text.Equals("Pcs"))
                {
                    amount = Math.Round(int.Parse(lblPcs.Text) * double.Parse(txtOtherRate.Text), 2);
                }
                else if (cmbOtherChg.Text.Equals("Grm"))
                {
                    amount = Math.Round(double.Parse(lblNetWt.Text) * double.Parse(txtOtherRate.Text), 2);
                }
                else if (cmbOtherChg.Text.Equals("Item"))
                {
                    amount = double.Parse(txtOtherRate.Text);
                }
            }
            return amount;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtMetalRate_TextChanged(object sender, EventArgs e)
        {
            double rate;
            double.TryParse(txtMetalRate.Text, out rate);
            if(rate > 0)
            calculate();
        }

        private void txtMetalValue_TextChanged(object sender, EventArgs e)
        {
            double rate;
            double.TryParse(txtMetalValue.Text, out rate);
            if (rate > 0)
            calculate();
        }

        private void cmbMakingOn_SelectedIndexChanged(object sender, EventArgs e)
        {
            calculate();
        }

        private void cmbOtherChg_SelectedIndexChanged(object sender, EventArgs e)
        {
            calculate();
        }

        private void txtMakingRate_TextChanged(object sender, EventArgs e)
        {
            double rate;
            double.TryParse(txtMakingRate.Text, out rate);
            if (rate > 0)
            calculate();
        }

        private void txtOtherRate_TextChanged(object sender, EventArgs e)
        {
            double rate;
            double.TryParse(txtOtherRate.Text, out rate);
            if (rate > 0)
            calculate();
        }

        private void txtMetalRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            dbUtils.onlyDecimal(sender, ref e);
        }

        private void getMetalRate()
        {
            try
            {
                string sqlstr = "SELECT TOP 1 MRATE,MDATE FROM METALDATA WHERE MDATE <= #" + itemInfo.SaleDate.ToShortDateString() + "# AND MDESC='" + lblMetalType.Text + "' ORDER BY MDATE DESC";
                OleDbDataReader reader = dbUtils.fetch(sqlstr);
                if (reader.HasRows)
                {
                    reader.Read();
                    double metalRate = reader.GetDouble(0);
                    txtMetalRate.Text = dbUtils.Decimal3digit(metalRate.ToString());
                    lblGoldDate.Text = " as on " + reader.GetDateTime(1).ToShortDateString();
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error::" + ex.Message);
                LoggingManager.WriteToLog(0, "SaleItemInfo : getMetalRate() : " + ex.Message);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            double makingChg =0 ;
            double.TryParse(txtMakingChg.Text,out makingChg);
            if (makingChg <= 0)
            {
                DialogResult result = MessageBox.Show("Do you want to accept without any Making Charges ?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult.Yes == result)
                {
                    addToSalesGrid();
                }
            }
            else
            {
                addToSalesGrid();
            }
        }

        public void addToSalesGrid()
        {
            SalesLineItemDetail salesLineItemDetail = new SalesLineItemDetail();
            salesLineItemDetail.Tid = itemInfo.Tid;
            salesLineItemDetail.ItemDesc = lblItem.Text;
            salesLineItemDetail.MetalType = lblMetalType.Text;
            salesLineItemDetail.TagNo = int.Parse(lblTagNo.Text);
            salesLineItemDetail.Pcs = int.Parse(lblPcs.Text);
            salesLineItemDetail.GrossWeight = double.Parse(lblGrossWt.Text);
            salesLineItemDetail.NetWeight = double.Parse(lblNetWt.Text);
            salesLineItemDetail.DiamondWeight = getDiamondWeight();
            salesLineItemDetail.DiamondValue = getDiamondValue();
            salesLineItemDetail.StoneWeight = getStoneWeight();
            salesLineItemDetail.StoneValue = getStoneValue();
            salesLineItemDetail.MetalRate = double.Parse(txtMetalRate.Text);
            salesLineItemDetail.MetalValue = double.Parse(txtMetalValue.Text);
            salesLineItemDetail.MakingOn = cmbMakingOn.Text;
            double makingRate = 0;
            double makingAmt = 0;
            double otherChgRate = 0; ;
            double otherChgAmt = 0;
            double totalAmt = 0;
            double.TryParse(txtMakingRate.Text, out makingRate);
            double.TryParse(txtMakingChg.Text, out makingAmt);
            double.TryParse(txtOtherRate.Text, out otherChgRate);
            double.TryParse(txtOtherChg.Text, out otherChgAmt);
            double.TryParse(txtTotalValue.Text, out totalAmt);

            salesLineItemDetail.MakingRate = makingRate;
            salesLineItemDetail.MakingAmt = makingAmt;
            salesLineItemDetail.OtheChgOn = cmbOtherChg.Text;
            salesLineItemDetail.OtheChgRate = otherChgRate;
            salesLineItemDetail.OtheChgAmt = otherChgAmt;
            salesLineItemDetail.TotalAmt = totalAmt;

            if (filePath.Contains(NO_IMAGE))
            {
                //To be decided later 
            }
            else
            {
                salesLineItemDetail.PicPath = filePath;
            }

            if (currentStatus == 0)
            {
                salesForm.addToSalesGrid(salesLineItemDetail);
            }
            else
            {
                salesForm.UpdateSalesGrid(salesLineItemDetail);
            }
            
            Close();
        }

        private void lblGoldDate_DoubleClick(object sender, EventArgs e)
        {
            ShowGoldRateForm();
            getMetalRate();
        }

        private void ShowGoldRateForm()
        {
            GoldRateMaster goldRateMasterForm = new GoldRateMaster();
            goldRateMasterForm.ShowDialog();
        }
    }
}
