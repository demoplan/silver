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


namespace StockManagement.Transaction
{
    public partial class StockIN : Form
    {
        private int uniqueNumber;
        private double totalStoneWt = 0.00;
        private Dictionary<int, ItemInfo> itemInfoList;
        private List<int> runtimeKeyList;
        private string transactionId;
        private double stoneAmt = 0;
        private double diamondAmt = 0;

        public StockIN()
        {
            InitializeComponent();
            dbUtils.connection();
            loadProductMaster();
            fillGoldMaster();
            fillDiamondDetail();
            fillStoneDetail();
            fillSubItemDetail();
            itemInfoList = new Dictionary<int, ItemInfo>();
            runtimeKeyList = new List<int>();
            dtDate.Value = DateTime.Today;
            dtDateC.Value = DateTime.Today;
            this.Left = 0;
            this.Top = 150;
            this.Width = GlobalVar.windowsWidth;
            cmbProductCode.SelectAll();
            this.ActiveControl = cmbProductCode;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //DialogResult result = MessageBox.Show("Are you sure want to close ? ", "Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (result == DialogResult.Yes)
            {
                dbUtils.disConnect();
                this.Close();
            }
        }


        private void fillGoldMaster()
        {
            String str = "SELECT ID, GDESC FROM METALM ORDER BY GDESC";
            DataTable metalTable = new DataTable();// dbUtils.fill_ComboData(str);
            dbUtils.setComboProperty(ref cmbMetal, str, ref metalTable);

            cmbMetalC.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbMetalC.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbMetalC.DisplayMember = "DESCRIPTION";
            cmbMetalC.ValueMember = "ID";
            cmbMetalC.DataSource = metalTable;
        }

        private void fillDiamondDetail()
        {
            String str = "SELECT ID,SDESC FROM STONEM WHERE STYPE = 'D' ORDER BY SDESC";
            DataTable metalTable = new DataTable();
            dbUtils.setComboProperty(ref cmbDiamond, str, ref metalTable);

            cmbIDiamond.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbIDiamond.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbIDiamond.DisplayMember = "DESCRIPTION";
            cmbIDiamond.ValueMember = "ID";
            cmbIDiamond.DataSource = metalTable;
        }

        private void fillSubItemDetail()
        {
            String str = "SELECT ID,SubItem FROM SUBITEMM ORDER BY SubItem";
            DataTable metalTable = new DataTable();
            dbUtils.setComboProperty(ref cmbItemCodeC, str, ref metalTable);
        }

        private void fillStoneDetail()
        {
            String str = "SELECT ID,SDESC FROM STONEM WHERE STYPE = 'S' ORDER BY SDESC";
            DataTable metalTable = new DataTable();
            dbUtils.setComboProperty(ref cmbStone, str, ref metalTable);

            cmbIStone.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbIStone.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbIStone.DisplayMember = "DESCRIPTION";
            cmbIStone.ValueMember = "ID";
            cmbIStone.DataSource = metalTable;
        }

        private void loadProductMaster()
        {
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                OleDbDataReader drStone;
                DataTable dt = new DataTable();
                dt.Columns.Add("ID", typeof(System.Int32));
                dt.Columns.Add("DESCRIPTION", typeof(System.String));
                String str = "SELECT ID, PNAME FROM PRODUCTM ORDER BY PNAME";
                drStone = dbUtils.fetch(str);
                while (drStone.Read())
                {
                    dt.Rows.Add(drStone.GetInt32(0), drStone.GetString(1));
                }
                cmbProductCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbProductCode.AutoCompleteSource = AutoCompleteSource.ListItems;
                cmbProductCode.DisplayMember = "DESCRIPTION";
                cmbProductCode.ValueMember = "ID";
                cmbProductCode.DataSource = dt;

                cmbProductCodeC.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbProductCodeC.AutoCompleteSource = AutoCompleteSource.ListItems;
                cmbProductCodeC.DisplayMember = "DESCRIPTION";
                cmbProductCodeC.ValueMember = "ID";
                cmbProductCodeC.DataSource = dt;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                LoggingManager.WriteToLog(0, "frmValuationEntry : fill_cmbStoneDetail() : " + e.Message);
            }
        }

        private void txtNetWt_KeyPress(object sender, KeyPressEventArgs e)
        {
            dbUtils.onlyDecimal(sender, ref e);
        }

        private void txtNetWt_Leave(object sender, EventArgs e)
        {
            TextBox txtbox = (TextBox)sender;
            dbUtils.Decimal3digit(ref txtbox);
            updateGrossWeight();
        }

        private void txtDiaWt_KeyPress(object sender, KeyPressEventArgs e)
        {
            dbUtils.onlyDecimal(sender, ref e);
            TextBox txtbox = (TextBox)sender;
            if (e.KeyChar == 13 & txtbox.Text.Length > 0)
            {
                dbUtils.Decimal2digit(ref txtbox);
                txtDiaRate.Select();
            }
          
        }

        private double totalAmount(string weight,string rate)
        {
            double dweight = 0;
            double drate = 0;
            double result = 0;

            if (Double.TryParse(weight, out dweight))
            {
              
            }
            else
            {
                return 0.00;
            }

            if (Double.TryParse(rate, out drate))
            {

            }
            else
            {
                return 0.00;
            }

            result = drate * dweight;
            return Math.Round(result,0);
        }

        private void addDiamondToGrid()
        {
            string[] rows = new string[] { cmbDiamond.Text, txtDiaWt.Text, txtDiaRate.Text,txtDiaAmt.Text };
            dgDiamond.Rows.Add(rows);
            totalStoneWt += double.Parse(txtDiaWt.Text);
            txtDiaWt.Text = "";
            txtDiaRate.Text = "";
            txtDiaAmt.Text = "";
            updateGrossWeight();
        }

        private void addDiamondCToGrid()
        {
            string[] rows = new string[] { cmbIDiamond.Text, txtIDiamondWt.Text,txtIDiamondRate.Text,txtIDiamondAmt.Text };
            dgIDiamond.Rows.Add(rows);
            txtIDiamondWt.Text = "";
            txtIDiamondRate.Text = "";
            txtIDiamondAmt.Text = "";
        }

        private void diamondSubTotal()
        {
            double sum = 0.00;
            double amount = 0.00;

            foreach (DataGridViewRow item in dgIDiamond.Rows)
            {
                sum += double.Parse(item.Cells[1].Value.ToString());
                amount += double.Parse(item.Cells[3].Value.ToString());
            }
            txtDiamondC.Text = string.Format("{0:0,0.00}", sum);
            txtDiamondAmtC.Text = string.Format("{0:0,0.00}", amount);
        }

        private void stoneSubTotal()
        {
            double sum = 0.00;
            double amount = 0.00;

            foreach (DataGridViewRow item in dgIStone.Rows)
            {
                sum += double.Parse(item.Cells[1].Value.ToString());
                amount += double.Parse(item.Cells[3].Value.ToString());
            }
            txtStoneC.Text = string.Format("{0:0,0.00}", sum);
            txtStoneAmtC.Text = string.Format("{0:0,0.00}", amount);
        }

        private void txtStoneWt_KeyPress(object sender, KeyPressEventArgs e)
        {
            dbUtils.onlyDecimal(sender, ref e);
            TextBox txtbox = (TextBox)sender;
            if (e.KeyChar == 13 & txtbox.Text.Length > 0)
            {
                dbUtils.Decimal2digit(ref txtbox);
                txtStoneRate.Select();
            }
        }

        private void addStoneToGrid()
        {
            string[] rows = new string[] { cmbStone.Text, txtStoneWt.Text ,txtStoneRate.Text,txtStoneAmt.Text};
            dgStone.Rows.Add(rows);
            totalStoneWt += double.Parse(txtStoneWt.Text);
            txtStoneWt.Text = "";
            txtStoneRate.Text = "";
            txtStoneAmt.Text = "";
            updateGrossWeight();
        }

        private void addStoneCToGrid()
        {
            string[] rows = new string[] { cmbIStone.Text, txtIStoneWt.Text,txtIStoneRate.Text,txtIStoneAmt.Text };
            dgIStone.Rows.Add(rows);
            txtIStoneWt.Text = "";
            txtIStoneRate.Text = "";
            txtIStoneAmt.Text = "";
        }

        private void btnAddDiamond_Click(object sender, EventArgs e)
        {
            if (txtDiaWt.Text.Length > 0)
            {
                dbUtils.Decimal2digit(ref txtDiaWt);
                addDiamondToGrid();
            }
        }

        private void btnAddStone_Click(object sender, EventArgs e)
        {
            if (txtStoneWt.Text.Length > 0)
            {
                dbUtils.Decimal2digit(ref txtStoneWt);
                addStoneToGrid();
            }
        }

        private void pbPhoto_Click(object sender, EventArgs e)
        {
            ofdLoadPhoto.FileName = "";
            ofdLoadPhoto.ShowDialog();
            PictureBox pBox = (PictureBox)sender;
            if (ofdLoadPhoto.FileName.Length != 0)
            {
                FileStream fs = new FileStream(ofdLoadPhoto.FileName, FileMode.Open, FileAccess.Read);
                Image photo = Image.FromStream(fs);
                pBox.Image = photo;
                fs.Close();
                pbCamera.Visible = false;
            }
            else
            {
                pBox.Image = null;
                pbCamera.Visible = true;
            }
        }

        private void savePictureToFile(PictureBox pbPhoto)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            try
            {
                uniqueNumber = dbUtils.getUniqueNumber("SELECT TID FROM TRANS WHERE TID = ");

                if (pbPhoto.Image == null)
                {
                    return;
                }

                string fileName = uniqueNumber.ToString();
                Bitmap bitmap;
                Image imgThumb;
                int thumbsize = 0;
                int newWidth = 0;
                int newHeight = 0;

                string path = Application.StartupPath + "\\Data\\Images\\";
                fileName = path + fileName + ".jpg";
                thumbsize = 300;

                if (pbPhoto.Image.Height > pbPhoto.Image.Width)
                {
                    newHeight = Convert.ToInt32(thumbsize);
                    newWidth = Convert.ToInt32(pbPhoto.Image.Width * thumbsize / pbPhoto.Image.Height);
                }
                else
                {
                    newWidth = Convert.ToInt32(thumbsize);
                    newHeight = Convert.ToInt32(pbPhoto.Image.Height * thumbsize / pbPhoto.Image.Width);
                }

                imgThumb = pbPhoto.Image.GetThumbnailImage(newWidth, newHeight, null, new IntPtr());
                bitmap = new Bitmap(imgThumb);
                bitmap.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                bitmap = null;
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

        private bool checkUniqueTag(string pcode, int tagNo)
        {
            string sqlQry = "SELECT TNO FROM TRANS WHERE PCODE ='" + pcode + "'  AND OUTDATE is NULL AND TNO = " + tagNo;
            int result = dbUtils.FetchInteger(sqlQry);
            if (result == -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void SaveData(OleDbTransaction trans, OleDbConnection connection)
        {
            if (txtTagNo.Text.Length == 0 && txtNetWt.Text.Length == 0)
            {
                MessageBox.Show("Nothing to Save.");
                return;
            }
            savePictureToFile(pbPhoto);
            OleDbCommand command = new OleDbCommand();
            OleDbTransaction transaction = null;
            OleDbConnection con = null;
            try
            {
                if (connection == null)
                {
                    con = dbUtils.getConnection();
                }
                else
                {
                    con = connection;
                }
                command.Connection = con;
                if (trans == null)
                {
                    transaction = con.BeginTransaction();
                }
                else
                {
                    transaction = trans;
                }


                //Data to be inserted into Transction table
                String sqlQry = "INSERT INTO TRANS(TID,tDate,Pcode,Tno,MetalType,PCS,GW,NW,Photo,Remark) VALUES (@TID,@tDate,@Pcode,@Tno,@MetalType,@PCS,@GW,@NW,@Photo,@Remark)";
                command.CommandText = sqlQry;
                command.Transaction = transaction;
                command.Parameters.Add("@TID", OleDbType.Integer, 10).Value = uniqueNumber;
                command.Parameters.Add("@tDate", OleDbType.Date, 10).Value = String.Format("{0:yyyy/MM/dd}", dtDate.Value);
                command.Parameters.Add("@Pcode", OleDbType.VarChar, 20).Value = cmbProductCode.Text;
                command.Parameters.Add("@Tno", OleDbType.Integer, 10).Value = txtTagNo.Text;
                command.Parameters.Add("@MetalType", OleDbType.VarChar, 20).Value = cmbMetal.Text;
                command.Parameters.Add("@PCS", OleDbType.Integer, 3).Value = txtPcs.Text;
                command.Parameters.Add("@GW", OleDbType.Double, 10).Value = txtGsWt.Text;
                command.Parameters.Add("@NW", OleDbType.Double, 10).Value = txtNetWt.Text;
                if (pbPhoto.Image != null)
                    command.Parameters.Add("@Photo", OleDbType.VarChar, 30).Value = uniqueNumber + ".jpg";
                else
                    command.Parameters.Add("@Photo", OleDbType.VarChar, 30).Value = "";
                command.Parameters.Add("@Remark", OleDbType.VarChar, 250).Value = txtRemark.Text;
                command.ExecuteNonQuery();

                //Diamond Data to be inserted into StoneData Table
                command.Parameters.Clear();
                sqlQry = "INSERT INTO STONEDATA VALUES (@ID,@PID,@SDESC,'D',@SWT,@SRATE,@SAMT)";
                command.CommandText = sqlQry;
                foreach (DataGridViewRow item in dgDiamond.Rows)
                {
                    if (item.Cells[0].Value != null && item.Cells[0].Value.ToString() != String.Empty)
                    {
                        command.Parameters.Clear();
                        int id = dbUtils.get5DigitUniqueNumber("SELECT ID FROM STONEDATA WHERE ID = ", runtimeKeyList);
                        command.Parameters.Add("@ID", OleDbType.Integer, 5).Value = id;
                        command.Parameters.Add("@PID", OleDbType.Integer, 8).Value = uniqueNumber;
                        command.Parameters.Add("@SDESC", OleDbType.VarChar, 30).Value = item.Cells[0].Value;
                        command.Parameters.Add("@SWT", OleDbType.Double, 10).Value = Double.Parse(item.Cells[1].Value.ToString());
                        command.Parameters.Add("@SRATE", OleDbType.Double, 10).Value = Double.Parse(item.Cells[2].Value.ToString());
                        command.Parameters.Add("@SAMT", OleDbType.Double, 10).Value = Double.Parse(item.Cells[3].Value.ToString());
                        command.ExecuteNonQuery();
                    }
                }

                //Stone Data to be inserted into StoneData Table
                command.Parameters.Clear();
                sqlQry = "INSERT INTO STONEDATA VALUES (@ID,@PID,@SDESC,'S',@SWT,@SRATE,@SAMT)";
                command.CommandText = sqlQry;
                foreach (DataGridViewRow item in dgStone.Rows)
                {
                    if (item.Cells[1].Value != null && item.Cells[1].Value.ToString() != String.Empty)
                    {
                        command.Parameters.Clear();
                        int id = dbUtils.get5DigitUniqueNumber("SELECT ID FROM STONEDATA WHERE ID = ", runtimeKeyList);
                        command.Parameters.Add("@ID", OleDbType.Integer, 5).Value = id;
                        command.Parameters.Add("@PID", OleDbType.Integer, 8).Value = uniqueNumber;
                        command.Parameters.Add("@SDESC", OleDbType.VarChar, 30).Value = item.Cells[0].Value;
                        Double dblStoneWt = Double.Parse(item.Cells[1].Value.ToString());
                        command.Parameters.Add("@SWT", OleDbType.Double, 10).Value = dblStoneWt;
                        command.Parameters.Add("@SRATE", OleDbType.Double, 10).Value = Double.Parse(item.Cells[2].Value.ToString());
                        command.Parameters.Add("@SAMT", OleDbType.Double, 10).Value = Double.Parse(item.Cells[3].Value.ToString());
                        command.ExecuteNonQuery();
                    }
                }
                transaction.Commit();
                clearControl();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                removePhoto();
                MessageBox.Show(ex.Message);
                LoggingManager.WriteToLog(0, "Error : SaveData() : " + ex.Message);
            }
        }

        private void removePhoto()
        {
            string path = Application.StartupPath + "\\Data\\Images\\";
            string fileName = path + uniqueNumber + ".jpg";
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
        }

        private void clearControl()
        {
            txtTagNo.Text = "";
            txtPcs.Text = "";
            txtNetWt.Text = "";
            txtGsWt.Text = "";
            dgDiamond.Rows.Clear();
            dgStone.Rows.Clear();
            pbPhoto.Image = null;
            txtRemark.Text = "";
            runtimeKeyList.Clear();
            cmbProductCode.Select();
            totalStoneWt = 0.00;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (checkMandateFields())
            {
                if (btnSaveSingle.Text.Equals("Save"))
                {
                    SaveData(null, null);
                }
                else
                {
                    updateData();
                    btnDelete.Visible = false;
                    changeButtonName(btnModify, "Modify");
                    changeButtonName(btnSaveSingle, "Save");
                }

                cmbProductCode.Focus();
            }
        }

        private void updateData()
        {
            OleDbConnection connection = dbUtils.getConnection();
            OleDbTransaction trans = connection.BeginTransaction();
            try
            {
                if (transactionId.Length > 0)
                {
                    deleteInTransTable(trans, transactionId, connection);
                    deleteInStoneTable(trans, transactionId, connection);
                }
                if (pbPhoto.Image != null)
                {
                    string filePath = Application.StartupPath + "//Data//Images//" + transactionId + ".jpg";
                    uniqueNumber = getIntegerValue(transactionId);
                    removePhoto();
                }
                SaveData(trans, connection);
            }
            catch (Exception ex)
            {
                if (trans.Connection != null)
                {
                    trans.Rollback();
                    removePhoto();
                }
                MessageBox.Show(ex.Message);
                LoggingManager.WriteToLog(0, "Error : SaveData() : " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void updateDataC()
        {
            OleDbConnection connection = dbUtils.getConnection();
            OleDbTransaction trans = connection.BeginTransaction();
            try
            {
                if (transactionId.Length > 0)
                {
                    deleteInTransTable(trans, transactionId, connection);
                    deleteInStoneTable(trans, transactionId, connection);
                    string sqlQry = "SELECT SUBID FROM SUBITEMTRANS WHERE TID = " + transactionId;
                    OleDbDataReader subItemReader = dbUtils.fetch(sqlQry);
                    if (subItemReader.HasRows)
                    {
                        while (subItemReader.Read())
                        {
                            string subId = subItemReader.GetInt32(0).ToString();
                            deleteInSubStoneDataTable(trans, subId, connection);
                        }
                    }
                    subItemReader = null;
                    deleteInSubItemTransTable(trans, transactionId, connection);
                }
                if (pbPhotoC.Image != null)
                {
                    string filePath = Application.StartupPath + "//Data//Images//" + transactionId + ".jpg";
                    uniqueNumber = getIntegerValue(transactionId);
                    removePhoto();
                }
                SaveDataC(trans, connection);
            }
            catch (Exception ex)
            {
                if (trans.Connection != null)
                {
                    trans.Rollback();
                    removePhoto();
                }
                MessageBox.Show(ex.Message);
                LoggingManager.WriteToLog(0, "Error : SaveData() : " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private bool checkMandateFields()
        {
            if (cmbProductCode.SelectedIndex == -1 || txtTagNo.Text.Length == 0 || cmbMetal.SelectedIndex == -1 || txtPcs.Text.Length == 0 || txtNetWt.Text.Length == 0)
            {
                MessageBox.Show("All the mandatory fields are not filled.", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            return true;
        }

        private void dgDiamond_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DataGridViewRow currentRow = dgDiamond.SelectedRows[0];
            totalStoneWt -= double.Parse(currentRow.Cells[1].Value.ToString());
            updateGrossWeight();
        }

        private void dgStone_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DataGridViewRow currentRow = dgStone.SelectedRows[0];
            totalStoneWt -= double.Parse(currentRow.Cells[1].Value.ToString());
            updateGrossWeight();
        }

        private void updateGrossWeight()
        {
            double stoneWt = totalStoneWt * 0.2;
            if (txtNetWt.Text.Length > 0)
            {
                txtGsWt.Text = Math.Round(double.Parse(txtNetWt.Text.ToString()) + stoneWt, 2).ToString();
                dbUtils.Decimal3digit(ref txtGsWt);
            }
        }

        private void txtTagNo_Leave(object sender, EventArgs e)
        {
            if (txtTagNo.Text.Length > 0)
                if (!checkUniqueTag(cmbProductCode.Text, int.Parse(txtTagNo.Text)))
                {
                    MessageBox.Show("This Tag no is used. Try some other no.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTagNo.Text = "";
                }
        }

        private void txtTagNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            dbUtils.onlyDecimal(sender, ref e);
        }

        private void chkDiamond_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDiamond.Checked)
            {
                gbDiamond.Visible = true;
                gbDiamond.Location = new Point(428, 5);
                gbDiamond.BringToFront();
                this.ActiveControl = cmbIDiamond;
            }
            else
            {
                gbDiamond.Visible = false;
            }
        }

        private void btnCloseC_Click(object sender, EventArgs e)
        {
            dbUtils.disConnect();
            Close();
        }

        private void btnStoneCancel_Click(object sender, EventArgs e)
        {
            gbStone.Visible = false;
            stoneSubTotal();
            btnAddItem.Focus();
        }

        private void btnDiamondCancel_Click(object sender, EventArgs e)
        {
            gbDiamond.Visible = false;
            diamondSubTotal();
            chkStone.Focus();
        }

        private void btnStoneOk_Click(object sender, EventArgs e)
        {
            gbStone.Visible = false;
            stoneSubTotal();
            ActiveControl = btnAddItem;
        }

        private void btnDiamondOk_Click(object sender, EventArgs e)
        {
            gbDiamond.Visible = false;
            diamondSubTotal();
            chkStone.Focus();
        }

        private void chkStone_CheckedChanged(object sender, EventArgs e)
        {
            if (chkStone.Checked)
            {
                gbStone.Visible = true;
                gbStone.Location = new Point(570, 8);
                gbStone.BringToFront();
                this.ActiveControl = cmbIStone;
            }
            else
            {
                gbStone.Visible = false;
            }
        }

        private void txtIDiamondWt_KeyPress(object sender, KeyPressEventArgs e)
        {
            dbUtils.onlyDecimal(sender, ref e);
            TextBox txtbox = (TextBox)sender;
            if (e.KeyChar == 13 && txtbox.Text.Length > 0 && cmbIDiamond.SelectedIndex != -1)
            {
                dbUtils.Decimal2digit(ref txtbox);
                txtIDiamondRate.Select();
                //addDiamondCToGrid();
            }
        }

        private void txtINetWtC_KeyPress(object sender, KeyPressEventArgs e)
        {
            dbUtils.onlyDecimal(sender, ref e);
        }

        private void txtINetWtC_Leave(object sender, EventArgs e)
        {
            TextBox txtbox = (TextBox)sender;
            dbUtils.Decimal3digit(ref txtbox);
        }

        private void txtTagNoC_Leave(object sender, EventArgs e)
        {
            if (txtTagNoC.Text.Length > 0)
                if (!checkUniqueTag(cmbProductCodeC.Text, int.Parse(txtTagNoC.Text)))
                {
                    MessageBox.Show("This Tag no is used. Try some other no.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTagNoC.Text = "";
                }
        }

        private void txtIStoneWt_KeyPress(object sender, KeyPressEventArgs e)
        {
            dbUtils.onlyDecimal(sender, ref e);
            TextBox txtbox = (TextBox)sender;
            if (e.KeyChar == 13 && txtbox.Text.Length > 0 && cmbIStone.SelectedIndex != -1)
            {
                dbUtils.Decimal2digit(ref txtbox);
                txtIStoneRate.Select();
            }
        }

        private void pbPhotoC_Click(object sender, EventArgs e)
        {
            ofdLoadPhoto.FileName = "";
            ofdLoadPhoto.ShowDialog();
            if (ofdLoadPhoto.FileName.Length != 0)
            {
                pbPhotoC.Image = Image.FromFile(ofdLoadPhoto.FileName);
                pbCamera2.Visible = false;
            }
            else
            {
                pbPhotoC.Image = null;
                pbCamera2.Visible = true;
            }
        }

        private void txtIGrossWtC_TextChanged(object sender, EventArgs e)
        {
            txtIGrossWtC.Text = string.Format("{0:0,0.000}", getDoubleValue(txtINetWtC.Text) + getDoubleValue(txtDiamondC.Text) * 0.2 + getDoubleValue(txtStoneC.Text) * 0.2);
        }

        private double getDoubleValue(string str)
        {
            if (str.Length > 0)
            {
                return double.Parse(str);
            }
            else
            {
                return 0;
            }
        }

        private int getIntegerValue(string str)
        {
            if (str.Length > 0)
            {
                return int.Parse(str);
            }
            else
            {
                return 0;
            }
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (txtIPcsC.Text.Length > 0 && txtINetWtC.Text.Length > 0)
                AddCompositeItemToGrid();
            else
            {
                MessageBox.Show("Enter valid pcs / net weight", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddCompositeItemToGrid()
        {
            List<StoneInfo> stoneInfoList = new List<StoneInfo>();
            List<StoneInfo> diamondInfoList = new List<StoneInfo>();
            ItemInfo rowItem = new ItemInfo();

            foreach (DataGridViewRow row in dgIDiamond.Rows)
            {
                diamondInfoList.Add(new StoneInfo(row.Cells[0].Value.ToString(), double.Parse(row.Cells[1].Value.ToString()), double.Parse(row.Cells[2].Value.ToString()), double.Parse(row.Cells[3].Value.ToString())));
            }

            foreach (DataGridViewRow row in dgIStone.Rows)
            {
                stoneInfoList.Add(new StoneInfo(row.Cells[0].Value.ToString(), double.Parse(row.Cells[1].Value.ToString()), double.Parse(row.Cells[2].Value.ToString()), double.Parse(row.Cells[3].Value.ToString())));
            }

            rowItem.DiamondList = diamondInfoList;
            rowItem.GrossWeight = getDoubleValue(txtIGrossWtC.Text);
            rowItem.ItemCode = cmbItemCodeC.Text;
            rowItem.NetWeight = getDoubleValue(txtINetWtC.Text);
            rowItem.Pcs = getIntegerValue(txtIPcsC.Text);
            rowItem.StoneList = stoneInfoList;


            int rowCount;

            if (dgStockOutC.Rows.Count == 0)
            {
                rowCount = 1;
            }
            else
            {
                rowCount = getIntegerValue(dgStockOutC.Rows[dgStockOutC.Rows.Count - 1].Cells[0].Value.ToString()) + 1;
            }
            itemInfoList.Add(rowCount, rowItem);
            string[] gridRow = new string[] { (rowCount).ToString(), rowItem.ItemCode, rowItem.Pcs.ToString(), dbUtils.Decimal3digit(rowItem.GrossWeight.ToString()), dbUtils.Decimal2digit(txtDiamondC.Text),dbUtils.Decimal2digit(txtDiamondAmtC.Text), dbUtils.Decimal2digit(txtStoneC.Text),dbUtils.Decimal2digit(txtStoneAmtC.Text), dbUtils.Decimal3digit(rowItem.NetWeight.ToString()) };
            dgStockOutC.Rows.Add(gridRow);
            updateItemTotal(rowItem);
            clearItemsControls();
            ActiveControl = cmbItemCodeC;
        }

        private void clearItemsControls()
        {
            txtIPcsC.Text = "";
            txtINetWtC.Text = "";
            txtIDiamondWt.Text = "";
            txtIStoneWt.Text = "";
            txtIGrossWtC.Text = "";
            txtDiamondC.Text = "";
            txtDiamondAmtC.Text = "";
            txtStoneC.Text = "";
            txtStoneAmtC.Text = "";
            dgIStone.Rows.Clear();
            dgIDiamond.Rows.Clear();
            chkDiamond.Checked = false;
            chkStone.Checked = false;

        }

        private void updateItemTotal(ItemInfo itemInfo)
        {
            txtPcsC.Text = (getDoubleValue(txtPcsC.Text) + itemInfo.Pcs).ToString();
            txtNetWtC.Text = dbUtils.Decimal3digit((getDoubleValue(txtNetWtC.Text) + itemInfo.NetWeight).ToString());
            txtGrossWtC.Text = dbUtils.Decimal3digit((getDoubleValue(txtGrossWtC.Text) + itemInfo.GrossWeight).ToString());
            txtDiamontWtC.Text = dbUtils.Decimal2digit((getDoubleValue(txtDiamontWtC.Text) + getDiamondWeight(itemInfo)).ToString());
            txtStoneWtC.Text = dbUtils.Decimal2digit((getDoubleValue(txtStoneWtC.Text) + getStoneWeight(itemInfo)).ToString());
            stoneAmt = stoneAmt + getStoneAmount(itemInfo);
            diamondAmt = diamondAmt = getDiamondAmount(itemInfo);
        }

        private double getDiamondWeight(ItemInfo itemInfo)
        {
            double diamondWeight = 0.00;
            List<StoneInfo> stoneInfoList = itemInfo.DiamondList;
            if (stoneInfoList != null)
                foreach (StoneInfo item in stoneInfoList)
                {
                    diamondWeight += item.Weight;
                }
            return diamondWeight;
        }

        private double getDiamondValue(ItemInfo itemInfo)
        {
            double diamondValue= 0.00;
            List<StoneInfo> stoneInfoList = itemInfo.DiamondList;
            if (stoneInfoList != null)
                foreach (StoneInfo item in stoneInfoList)
                {
                    diamondValue += item.Samount;
                }
            return diamondValue;
        }

        private double getDiamondAmount(ItemInfo itemInfo)
        {
            double diamondAmount = 0.00;
            List<StoneInfo> stoneInfoList = itemInfo.DiamondList;
            if (stoneInfoList != null)
                foreach (StoneInfo item in stoneInfoList)
                {
                    diamondAmount += item.Samount;
                }
            return diamondAmount;
        }

        private double getStoneWeight(ItemInfo itemInfo)
        {
            double stoneWeight = 0.00;
            List<StoneInfo> stoneInfoList = itemInfo.StoneList;
            if (stoneInfoList != null)
                foreach (StoneInfo item in stoneInfoList)
                {
                    stoneWeight += item.Weight;
                }
            return stoneWeight;
        }

        private double getStoneValue(ItemInfo itemInfo)
        {
            double stoneValue = 0.00;
            List<StoneInfo> stoneInfoList = itemInfo.StoneList;
            if (stoneInfoList != null)
                foreach (StoneInfo item in stoneInfoList)
                {
                    stoneValue += item.Samount;
                }
            return stoneValue;
        }

        private double getStoneAmount(ItemInfo itemInfo)
        {
            double stoneAmount = 0.00;
            List<StoneInfo> stoneInfoList = itemInfo.StoneList;
            if (stoneInfoList != null)
                foreach (StoneInfo item in stoneInfoList)
                {
                    stoneAmount += item.Samount;
                }
            return stoneAmount;
        }

        private void updateAfterRemoveItemTotal(ItemInfo itemInfo)
        {
            txtPcsC.Text = (getDoubleValue(txtPcsC.Text) - itemInfo.Pcs).ToString();
            txtNetWtC.Text = dbUtils.Decimal3digit((getDoubleValue(txtNetWtC.Text) - itemInfo.NetWeight).ToString());
            txtGrossWtC.Text = dbUtils.Decimal3digit((getDoubleValue(txtGrossWtC.Text) - itemInfo.GrossWeight).ToString());
            txtDiamontWtC.Text = dbUtils.Decimal2digit((getDoubleValue(txtDiamontWtC.Text) - getDiamondWeight(itemInfo)).ToString());
            txtStoneWtC.Text = dbUtils.Decimal2digit((getDoubleValue(txtStoneWtC.Text) - getStoneWeight(itemInfo)).ToString());
            stoneAmt = stoneAmt - getStoneAmount(itemInfo);
            diamondAmt = diamondAmt = getDiamondAmount(itemInfo);
        }

        private void btnDiamondAdd_Click(object sender, EventArgs e)
        {
            if (txtIDiamondWt.Text.Length > 0 && cmbDiamond.SelectedIndex != -1)
                addDiamondCToGrid();
        }

        private void btnStoneAdd_Click(object sender, EventArgs e)
        {
            if (txtIStoneWt.Text.Length > 0 && cmbIStone.SelectedIndex != -1)
                addStoneCToGrid();
        }

        private void dgStockOutC_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            ItemInfo item = itemInfoList[e.Row.Index + 1];
            updateAfterRemoveItemTotal(item);
            removeFromList(getIntegerValue(dgStockOutC.Rows[e.Row.Index].Cells[0].Value.ToString()));
        }

        private void removeFromList(int index)
        {
            if (itemInfoList.ContainsKey(index))
            {
                itemInfoList.Remove(index);
            }
        }

        private bool checkManditateFields()
        {
            if (cmbProductCodeC.SelectedIndex == -1 || txtTagNoC.Text.Length == 0 || cmbMetalC.SelectedIndex == -1 || txtPcsC.Text.Length == 0 || txtNetWtC.Text.Length == 0 || txtGrossWtC.Text.Length == 0)
            {
                MessageBox.Show("All the manditary fields are not field.", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (checkManditateFields())
            {
                if (btnSave.Text.Equals("Save"))
                {
                    SaveDataC(null, null);
                }
                else
                {
                    updateDataC();
                    changeButtonName(btnSave, "Save");
                    changeButtonName(btnModifyC, "Modify");
                    btnDeleteC.Visible = false;
                }
            }

        }


        private void SaveDataC(OleDbTransaction trans, OleDbConnection connection)
        {
            savePictureToFile(pbPhotoC);
            double stoneRate = 0;
            double diamondRate =0;
            OleDbCommand command = new OleDbCommand();
            OleDbTransaction transaction = null;
            OleDbConnection dbConnection = null;
            try
            {

                if (connection == null)
                {
                    dbConnection = dbUtils.getConnection();
                }
                else
                {
                    dbConnection = connection;
                }
                command.Connection = dbConnection;
                if (trans == null)
                {
                    transaction = dbConnection.BeginTransaction();
                }
                else
                {
                    transaction = trans;
                }
                

                //Data to be inserted into Transction table
                String sqlQry = "INSERT INTO TRANS(TID,tDate,Pcode,Tno,MetalType,PCS,GW,NW,Photo,Remark,SubItem) VALUES (@TID,@tDate,@Pcode,@Tno,@MetalType,@PCS,@GW,@NW,@Photo,@Remark,@SubItem)";
                command.CommandText = sqlQry;
                command.Transaction = transaction;
                command.Parameters.Add("@TID", OleDbType.Integer, 10).Value = uniqueNumber;
                command.Parameters.Add("@tDate", OleDbType.Date, 10).Value = String.Format("{0:yyyy/MM/dd}", dtDateC.Value);
                command.Parameters.Add("@Pcode", OleDbType.VarChar, 20).Value = cmbProductCodeC.Text;
                command.Parameters.Add("@Tno", OleDbType.Integer, 10).Value = txtTagNoC.Text;
                command.Parameters.Add("@MetalType", OleDbType.VarChar, 20).Value = cmbMetalC.Text;
                command.Parameters.Add("@PCS", OleDbType.Integer, 3).Value = txtPcsC.Text;
                command.Parameters.Add("@GW", OleDbType.Double, 10).Value = txtGrossWtC.Text;
                command.Parameters.Add("@NW", OleDbType.Double, 10).Value = txtNetWtC.Text;
                if (pbPhotoC.Image != null)
                    command.Parameters.Add("@Photo", OleDbType.VarChar, 30).Value = uniqueNumber + ".jpg";
                else
                    command.Parameters.Add("@Photo", OleDbType.VarChar, 30).Value = "";
                command.Parameters.Add("@Remark", OleDbType.VarChar, 250).Value = txtRemarkC.Text;
                command.Parameters.Add("@SubItem", OleDbType.Integer, 1).Value = 1;
                command.ExecuteNonQuery();

                //Diamond Data to be inserted into StoneData Table
                command.Parameters.Clear();
                sqlQry = "INSERT INTO STONEDATA VALUES (@ID,@PID,@SDESC,'D',@SWT,@SRATE,@SAMT)";
                command.CommandText = sqlQry;
                if (txtDiamontWtC.Text.Length > 0)
                {
                    int id = dbUtils.get5DigitUniqueNumber("SELECT ID FROM STONEDATA WHERE ID = ", runtimeKeyList);
                    command.Parameters.Add("@ID", OleDbType.Integer, 5).Value = id;
                    command.Parameters.Add("@PID", OleDbType.Integer, 8).Value = uniqueNumber;
                    command.Parameters.Add("@SDESC", OleDbType.VarChar, 30).Value = "Mixed";
                    command.Parameters.Add("@SWT", OleDbType.Double, 10).Value = Double.Parse(txtDiamontWtC.Text);
                    if (diamondAmt > 0)
                    {
                        diamondRate = Math.Round(diamondAmt / Double.Parse(txtDiamontWtC.Text));
                    }
                    else
                    {
                        diamondRate = 0;
                    }
                    command.Parameters.Add("@SRATE", OleDbType.Double, 10).Value = diamondRate;
                    command.Parameters.Add("@SAMT", OleDbType.Double, 10).Value = diamondAmt;
                    command.ExecuteNonQuery();
                }

                //Stone Data to be inserted into StoneData Table
                command.Parameters.Clear();
                sqlQry = "INSERT INTO STONEDATA VALUES (@ID,@PID,@SDESC,'S',@SWT,@SRATE,@SAMT)";
                command.CommandText = sqlQry;
                double stWeight = 0;
                double.TryParse(txtStoneWtC.Text, out stWeight);
                if (stWeight > 0)
                {
                    int id = dbUtils.get5DigitUniqueNumber("SELECT ID FROM STONEDATA WHERE ID = ", runtimeKeyList);
                    command.Parameters.Add("@ID", OleDbType.Integer, 5).Value = id;
                    command.Parameters.Add("@PID", OleDbType.Integer, 8).Value = uniqueNumber;
                    command.Parameters.Add("@SDESC", OleDbType.VarChar, 30).Value = "Other";
                    Double dblStoneWt = getDoubleValue(txtStoneWtC.Text);
                    command.Parameters.Add("@SWT", OleDbType.Double, 10).Value = dblStoneWt;
                    if (stoneAmt > 0)
                    {
                        stoneRate = Math.Round(stoneAmt / dblStoneWt);
                    }
                    else
                    {
                        stoneRate = 0;
                    }
                    command.Parameters.Add("@SRATE", OleDbType.Double, 10).Value = stoneRate;
                    command.Parameters.Add("@SAMT", OleDbType.Double, 10).Value = stoneAmt;
                    command.ExecuteNonQuery();
                }

                //Inserting item to SubItemTrans 
                if(itemInfoList != null)
                foreach (KeyValuePair<int, ItemInfo> entry in itemInfoList)
                {
                    command.Parameters.Clear();
                    sqlQry = "INSERT INTO SUBITEMTRANS VALUES (@SUBID,@TID,@IDESC,@PCS,@GWT,@NWT)";
                    command.CommandText = sqlQry;
                    ItemInfo item = entry.Value;
                    int subId = dbUtils.get5DigitUniqueNumber("SELECT SUBID FROM SUBITEMTRANS WHERE SUBID = ", runtimeKeyList);
                    command.Parameters.Add("@SUBID", OleDbType.Integer, 10).Value = subId;
                    command.Parameters.Add("@TID", OleDbType.Integer, 10).Value = uniqueNumber;
                    command.Parameters.Add("@IDESC", OleDbType.VarChar, 20).Value = item.ItemCode;
                    command.Parameters.Add("@PCS", OleDbType.Integer, 10).Value = item.Pcs;
                    command.Parameters.Add("@GWT", OleDbType.Double, 20).Value = item.GrossWeight;
                    command.Parameters.Add("@NWT", OleDbType.Double, 20).Value = item.NetWeight;
                    command.ExecuteNonQuery();

                    List<StoneInfo> diamondInfoList = item.DiamondList;
                    sqlQry = "INSERT INTO SUBSTONEDATA VALUES (@ID,@SUBID,@SDESC,'D',@SWT,@SRATE,@SAMT) ";
                    command.Parameters.Clear();
                    command.CommandText = sqlQry;
                    if (diamondInfoList != null)
                    foreach (StoneInfo diaDetail in diamondInfoList)
                    {
                        command.Parameters.Clear();
                        int dId = dbUtils.get5DigitUniqueNumber("SELECT ID FROM SUBSTONEDATA WHERE ID =", runtimeKeyList);
                        command.Parameters.Add("@ID", OleDbType.Integer, 10).Value = dId;
                        command.Parameters.Add("@SUBID", OleDbType.Integer, 10).Value = subId;
                        command.Parameters.Add("@SDESC", OleDbType.VarChar, 20).Value = diaDetail.Desc;
                        command.Parameters.Add("@SWT", OleDbType.Double, 20).Value = diaDetail.Weight;
                        command.Parameters.Add("@SRATE", OleDbType.Double, 20).Value = diaDetail.Srate;
                        command.Parameters.Add("@SAMT", OleDbType.Double, 20).Value = diaDetail.Samount;
                        command.ExecuteNonQuery();
                    }


                    List<StoneInfo> stoneInfoList = item.StoneList;
                    sqlQry = "INSERT INTO SUBSTONEDATA VALUES (@ID,@SUBID,@SDESC,'S',@SWT,@SRATE,@SAMT) ";
                    command.CommandText = sqlQry;
                    if (stoneInfoList != null)
                    {
                        foreach (StoneInfo stoneDetail in stoneInfoList)
                        {
                            command.Parameters.Clear();
                            int sId = dbUtils.get5DigitUniqueNumber("SELECT ID FROM SUBSTONEDATA WHERE ID =", runtimeKeyList);
                            command.Parameters.Add("@ID", OleDbType.Integer, 10).Value = sId;
                            command.Parameters.Add("@SUBID", OleDbType.Integer, 10).Value = subId;
                            command.Parameters.Add("@SDESC", OleDbType.VarChar, 20).Value = stoneDetail.Desc;
                            command.Parameters.Add("@SWT", OleDbType.Double, 20).Value = stoneDetail.Weight;
                            command.Parameters.Add("@SRATE", OleDbType.Double, 20).Value = stoneDetail.Srate;
                            command.Parameters.Add("@SAMT", OleDbType.Double, 20).Value = stoneDetail.Samount;
                            command.ExecuteNonQuery();
                        }
                    }
                }

                transaction.Commit();
                clearControlAfterCompositeSave();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                removePhoto();
                MessageBox.Show(ex.Message);
                LoggingManager.WriteToLog(0, "Error : SaveData() : " + ex.Message);
            }
        }

        private void clearControlAfterCompositeSave()
        {
            itemInfoList.Clear();
            dgStockOutC.Rows.Clear();
            runtimeKeyList.Clear();
            cmbProductCodeC.Text = "";
            txtTagNoC.Text = "";
            cmbMetalC.Text = "";
            txtPcsC.Text = "";
            txtNetWtC.Text = "";
            txtGrossWtC.Text = "";
            txtDiamontWtC.Text = "";
            txtStoneWtC.Text = "";
            pbPhotoC.Image = null;
            txtRemarkC.Text = "";
            stoneAmt = 0;
        }

        private void txtTagNoC_KeyPress(object sender, KeyPressEventArgs e)
        {
            dbUtils.onlyDecimal(sender, ref e);
        }



        private void cmbIDiamond_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13 && cmbIDiamond.SelectedIndex != -1)
            {
                txtIDiamondWt.Select();
            }
            else if (e.KeyValue == 13 && cmbIDiamond.SelectedIndex == -1)
            {
                btnDiamondOk.Select();
            }
        }

        private void cmbIStone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13 && cmbIStone.SelectedIndex != -1)
            {
                txtIStoneWt.Select();
            }
            else if (e.KeyValue == 13 && cmbIStone.SelectedIndex == -1)
            {
                btnStoneOk.Select();
            }
        }

        private void cmbMetalC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13 && cmbMetalC.SelectedIndex != -1)
            {
                cmbItemCodeC.Select();
            }
        }

        private void cmbProductCodeC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13 && cmbProductCodeC.SelectedIndex != -1)
            {
                txtTagNoC.Select();
            }
        }

        private void cmbItemCodeC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13 && cmbItemCodeC.SelectedIndex != -1)
            {
                txtIPcsC.Select();
            }
        }

        private void txtTagNoC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13 && txtTagNoC.Text.Length > 0)
            {
                cmbMetalC.Select();
            }
        }

        private void txtIPcsC_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyValue == 13 && txtIPcsC.Text.Length > 0)
            {
                txtINetWtC.Select();
            }
        }

        private void txtINetWtC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13 && txtINetWtC.Text.Length > 0)
            {
                chkDiamond.Select();
            }
        }

        private void chkDiamond_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                chkDiamond.Checked = true;
                gbDiamond.Visible = true;
                gbDiamond.Location = new Point(428, 5);
                gbDiamond.BringToFront();
                this.ActiveControl = cmbIDiamond;
            }
        }

        private void chkStone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                gbStone.Visible = true;
                gbStone.Location = new Point(570, 8);
                gbStone.BringToFront();
                this.ActiveControl = cmbIStone;
            }
        }

        private void cmbProductCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13 && cmbProductCode.SelectedIndex != -1)
            {
                txtTagNo.Select();
            }
        }

        private void cmbMetal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13 && cmbMetal.SelectedIndex != -1)
            {
                txtPcs.Select();
            }
        }

        private void cmbDiamond_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13 && cmbDiamond.SelectedIndex != -1)
            {
                txtDiaWt.Select();
            }
            else if (e.KeyValue == 13 && cmbDiamond.SelectedIndex == -1)
            {
                cmbStone.Select();
            }
        }

        private void cmbStone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13 && cmbStone.SelectedIndex != -1)
            {
                txtStoneWt.Select();
            }
            else if (e.KeyValue == 13 && cmbStone.SelectedIndex == -1)
            {
                txtRemark.Select();
            }
        }

        private void txtTagNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13 && txtTagNo.Text.Length > 0)
            {
                cmbMetal.Select();
            }
        }

        private void txtPcs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13 && txtPcs.Text.Length > 0)
            {
                txtNetWt.Select();
            }
        }

        private void txtNetWt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13 && txtNetWt.Text.Length > 0)
            {
                cmbDiamond.Select();
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (btnModify.Text.Equals("Modify"))
            {
                ModifyStockIn modifyForm = new ModifyStockIn(this);
                modifyForm.callingStatus = 1;
                modifyForm.preCondition = "OUTDATE IS NULL AND SUBITEM IS NULL";
                modifyForm.Location = new Point(8, 45);
                modifyForm.ShowDialog();
            }
            else
            {
                clearControl();
                changeButtonName(btnModify, "Modify");
                changeButtonName(btnSaveSingle, "Save");
                btnDelete.Visible = false;
            }
        }

        private void changeButtonName(Button btn, string name)
        {
            btn.Text = name;
        }

        public void loadDataToModify(string tid)
        {
            transactionId = tid;
            string sqlQry = "SELECT * FROM TRANS WHERE TID =" + tid;
            OleDbDataReader reader = dbUtils.fetch(sqlQry);
            changeButtonName(btnSaveSingle, "Update");
            changeButtonName(btnModify, "Cancel");
            if (reader.HasRows)
            {
                reader.Read();
                dtDate.Value = Convert.ToDateTime(reader.GetDateTime(1)); //date
                cmbProductCode.Text = reader.GetString(2); //pdesc
                txtTagNo.Text = reader.GetInt32(3).ToString(); //tag no
                cmbMetal.Text = reader.GetString(4);//metal type
                txtPcs.Text = reader.GetInt16(5).ToString(); //pcs
                txtGsWt.Text = dbUtils.Decimal3digit(reader.GetDouble(6).ToString());//gross weight
                txtNetWt.Text = dbUtils.Decimal3digit(reader.GetDouble(7).ToString());//net weight
                totalStoneWt = (reader.GetDouble(6) - reader.GetDouble(7)) / 0.2;
                string filePath = "";
                if (!reader["Photo"].Equals(DBNull.Value) && reader.GetString(8).Length > 0)
                {
                    filePath = Application.StartupPath + "//Data//Images//" + reader.GetString(8); //photo
                }
                if (filePath.Length > 0 && System.IO.File.Exists(filePath))
                {
                    FileStream fs = null;
                    try
                    {
                        fs = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite);
                        Image photo = Image.FromStream(fs);
                        pbPhoto.Image = photo;
                        pbCamera.Visible = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Exception during file loading : " + ex.Message);
                    }
                    finally
                    {
                        fs.Close();
                    }
                }
                else
                {
                    pbPhoto.Image = null;
                }
                if (reader[10].GetType().ToString() != "System.DBNull")
                txtRemark.Text = reader.GetString(10); //remark  
                loadDiamondandStone(tid);
                btnDelete.Visible = true;
            }
        }

        public void loadDataToModifyC(string tid)
        {
            transactionId = tid;
            string sqlQry = "SELECT * FROM TRANS WHERE TID =" + tid;
            OleDbDataReader reader = dbUtils.fetch(sqlQry);
            changeButtonName(btnSave, "Update");
            changeButtonName(btnModifyC, "Cancel");
            if (reader.HasRows)
            {
                reader.Read();
                dtDateC.Value = Convert.ToDateTime(reader.GetDateTime(1)); //date
                cmbProductCodeC.Text = reader.GetString(2); //pdesc
                txtTagNoC.Text = reader.GetInt32(3).ToString(); //tag no
                cmbMetalC.Text = reader.GetString(4);//metal type
                txtPcsC.Text = reader.GetInt16(5).ToString(); //pcs
                txtGrossWtC.Text = dbUtils.Decimal3digit(reader.GetDouble(6).ToString());//gross weight
                txtNetWtC.Text = dbUtils.Decimal3digit(reader.GetDouble(7).ToString());//net weight
                totalStoneWt = (reader.GetDouble(6) - reader.GetDouble(7)) / 0.2;
                string filePath = "";
                if (!reader["Photo"].Equals(DBNull.Value) && reader.GetString(8).Length > 0)
                {
                    filePath = Application.StartupPath + "//Data//Images//" + reader.GetString(8); //photo
                }
                if (filePath.Length > 0 && System.IO.File.Exists(filePath))
                {
                    FileStream fs = null;
                    try
                    {
                        fs = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite);
                        Image photo = Image.FromStream(fs);
                        pbPhotoC.Image = photo;
                        pbCamera2.Visible = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Exception during file loading : " + ex.Message);
                    }
                    finally
                    {
                        fs.Close();
                    }
                }
                else
                {
                    pbPhoto.Image = null;
                }
                if (reader[10].GetType().ToString() != "System.DBNull")
                txtRemarkC.Text = reader.GetString(10); //remark  
                sqlQry = "SELECT * FROM STONEDATA WHERE PID =" + tid;
                OleDbDataReader stoneReader = dbUtils.fetch(sqlQry);
                if (stoneReader.HasRows)
                {
                    while (stoneReader.Read())
                    {
                        if (stoneReader.GetString(3).Equals("D"))
                        {
                            txtDiamontWtC.Text = dbUtils.Decimal2digit(stoneReader.GetDouble(4).ToString());
                        }
                        else
                        {
                            txtStoneWtC.Text = dbUtils.Decimal2digit(stoneReader.GetDouble(4).ToString());
                        }
                    }
                }
                stoneReader.Close();
                stoneReader = null;
                prepareItemInfoList(tid);
                btnDeleteC.Visible = true;
            }
            reader.Close();
        }

        private void prepareItemInfoList(string tid)
        {
            string sqlQry = "SELECT * FROM SUBITEMTRANS WHERE TID = " + tid;
            OleDbDataReader reader = dbUtils.fetch(sqlQry);
            if (reader.HasRows)
            {
                ItemInfo itemInfo = null;
                StoneInfo stoneInfo = null;
                List<StoneInfo> diamondList = null;
                List<StoneInfo> stoneList = null;
                while (reader.Read())
                {
                    itemInfo = new ItemInfo();
                    string subId = reader.GetInt32(0).ToString();

                    itemInfo.ItemCode = reader.GetString(2);
                    itemInfo.Pcs = reader.GetInt16(3);
                    itemInfo.GrossWeight = reader.GetDouble(4);
                    itemInfo.NetWeight = reader.GetDouble(5);

                    string stoneQry = "SELECT * FROM SUBSTONEDATA WHERE SUBID = " + subId;
                    OleDbDataReader stoneReader = dbUtils.fetch(stoneQry);
                    if (stoneReader.HasRows)
                    {
                        diamondList = new List<StoneInfo>();
                        stoneList = new List<StoneInfo>();
                        while (stoneReader.Read())
                        {
                            stoneInfo = new StoneInfo();

                            stoneInfo.Desc = stoneReader.GetString(2);
                            stoneInfo.Weight = stoneReader.GetDouble(4);
                            if(!stoneReader[5].Equals(DBNull.Value))
                            stoneInfo.Srate = stoneReader.GetDouble(5);
                            if (!stoneReader[6].Equals(DBNull.Value))
                            stoneInfo.Samount = stoneReader.GetDouble(6);
                            if (stoneReader.GetString(3).Equals("D"))
                            {
                                diamondList.Add(stoneInfo);
                            }
                            else
                            {
                                stoneList.Add(stoneInfo);
                            }
                        }
                    }
                    stoneReader.Close();

                    if (diamondList != null && diamondList.Count > 0)
                    {
                        itemInfo.DiamondList = diamondList;
                    }
                    else
                    {
                        itemInfo.DiamondList = null;
                    }

                    if (stoneList != null && stoneList.Count > 0)
                    {
                        itemInfo.StoneList = stoneList;
                    }
                    else
                    {
                        itemInfo.StoneList = null;
                    }
                    populateItemDataGrid(itemInfo);
                }

            }
        }

        private void populateItemDataGrid(ItemInfo itemInfo)
        {
            int rowCount;
            if (dgStockOutC.Rows.Count == 0)
            {
                rowCount = 1;
            }
            else
            {
                rowCount = getIntegerValue(dgStockOutC.Rows[dgStockOutC.Rows.Count - 1].Cells[0].Value.ToString()) + 1;
            }
            itemInfoList.Add(rowCount, itemInfo);
            string[] gridRow = new string[] { (rowCount).ToString(), itemInfo.ItemCode, itemInfo.Pcs.ToString(), dbUtils.Decimal3digit(itemInfo.GrossWeight.ToString()), dbUtils.Decimal2digit(getDiamondWeight(itemInfo).ToString()), dbUtils.Decimal2digit(getDiamondValue(itemInfo).ToString()), dbUtils.Decimal2digit(getStoneWeight(itemInfo).ToString()),dbUtils.Decimal2digit(getStoneValue(itemInfo).ToString()), dbUtils.Decimal3digit(itemInfo.NetWeight.ToString()) };
            dgStockOutC.Rows.Add(gridRow);
            dgStockOutC.AutoResizeColumns();
        }

        private void loadDiamondandStone(string tid)
        {
            string desc = "";
            string weight = "";
            string rate = "";
            string amount = "";
            string sqlQry = "SELECT * FROM STONEDATA WHERE PID = " + tid;
            OleDbDataReader reader = dbUtils.fetch(sqlQry);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    desc = reader.GetString(2);
                    if (!reader[4].Equals(DBNull.Value))
                    weight = dbUtils.Decimal2digit(reader.GetDouble(4).ToString());

                    if (!reader[5].Equals(DBNull.Value))
                    rate = dbUtils.Decimal2digit(reader.GetDouble(5).ToString());

                    if (!reader[6].Equals(DBNull.Value))
                    amount = dbUtils.Decimal2digit(reader.GetDouble(6).ToString());

                    string[] row = new string[] { desc, weight, rate, amount };
                    if (reader.GetString(3) == "D")
                    {
                        dgDiamond.Rows.Add(row);
                    }
                    else
                    {
                        dgStone.Rows.Add(row);
                    }
                }
            }
        }
        private void deleteData()
        {
            OleDbTransaction trans = null;
            OleDbConnection connection = null;
            try
            {
                connection = dbUtils.getConnection();
                trans = connection.BeginTransaction();
                if (transactionId.Length > 0)
                {
                    deleteInTransTable(trans, transactionId, connection);
                    deleteInStoneTable(trans, transactionId, connection);
                }
                if (pbPhoto.Image != null)
                {
                    string filePath = Application.StartupPath + "//Data//Images//" + transactionId + ".jpg";
                    uniqueNumber = getIntegerValue(transactionId);
                    removePhoto();
                }
                trans.Commit();
                clearControl();
                changeButtonName(btnSaveSingle, "Save");
            }
            catch (Exception ex)
            {
                trans.Rollback();
                LoggingManager.WriteToLog(0, " Delete : " + ex.Message);
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }


        private void deleteDataC()
        {
            OleDbTransaction trans = null;
            OleDbConnection connection = null;
            try
            {
                connection = dbUtils.getConnection();
                trans = connection.BeginTransaction();
                if (transactionId.Length > 0)
                {
                    deleteInTransTable(trans, transactionId, connection);
                    deleteInStoneTable(trans, transactionId, connection);
                    string sqlQry = "SELECT SUBID FROM SUBITEMTRANS WHERE TID = " + transactionId;
                    OleDbDataReader subItemReader = dbUtils.fetch(sqlQry);
                    if (subItemReader.HasRows)
                    {
                        while (subItemReader.Read())
                        {
                            string subId = subItemReader.GetInt32(0).ToString();
                            deleteInSubStoneDataTable(trans, subId, connection);
                        }
                    }
                    subItemReader = null;
                    deleteInSubItemTransTable(trans, transactionId, connection);
                }
                if (pbPhoto.Image != null)
                {
                    string filePath = Application.StartupPath + "//Data//Images//" + transactionId + ".jpg";
                    uniqueNumber = getIntegerValue(transactionId);
                    removePhoto();
                }
                trans.Commit();
                clearControlAfterCompositeSave();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                LoggingManager.WriteToLog(0, " Delete : " + ex.Message);
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure want to delete ?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                btnDelete.Visible = false;
                deleteData();
                changeButtonName(btnModify, "Modify");
            }
        }

        private void deleteInTransTable(OleDbTransaction trans, string tid, OleDbConnection connection)
        {
            string sqlQry = "DELETE FROM TRANS WHERE tid = " + tid;
            dbUtils.saveToDB2(sqlQry, trans, connection);
        }

        private void deleteInStoneTable(OleDbTransaction trans, string tid, OleDbConnection connection)
        {
            string sqlQry = "DELETE FROM STONEDATA WHERE pid = " + tid;
            dbUtils.saveToDB2(sqlQry, trans, connection);
        }

        private void deleteInSubItemTransTable(OleDbTransaction trans, string tid, OleDbConnection connection)
        {
            string sqlQry = "DELETE FROM SUBITEMTRANS WHERE tid = " + tid;
            dbUtils.saveToDB2(sqlQry, trans, connection);
        }

        private void deleteInSubStoneDataTable(OleDbTransaction trans, string SubId, OleDbConnection connection)
        {
            string sqlQry = "DELETE FROM SUBSTONEDATA WHERE subid = " + SubId;
            dbUtils.saveToDB2(sqlQry, trans, connection);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            clearControl();
        }

        private void btnModifyC_Click(object sender, EventArgs e)
        {
            if (btnModifyC.Text.Equals("Modify"))
            {
                ModifyStockIn modifyForm = new ModifyStockIn(this);
                modifyForm.callingStatus = 2;
                modifyForm.preCondition = "OUTDATE IS NULL AND SUBITEM = 1";
                modifyForm.Location = new Point(8, 45);
                modifyForm.ShowDialog();
            }
            else
            {
                clearControlAfterCompositeSave();
                changeButtonName(btnModifyC, "Modify");
                changeButtonName(btnSave, "Save");
                btnDeleteC.Visible = false;
            }
        }

        private void btnDeleteC_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure want to delete ?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                btnDeleteC.Visible = false;
                deleteDataC();
                changeButtonName(btnModifyC, "Modify");
                changeButtonName(btnSave, "Save");
            }
        }

        private void txtRemark_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnSaveSingle.Select();
            }
        }

        private void txtDiaRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            dbUtils.onlyDecimal(sender, ref e);
            TextBox txtbox = (TextBox)sender;
            if (e.KeyChar == 13 & txtbox.Text.Length > 0)
            {
                dbUtils.Decimal2digit(ref txtbox);
                txtDiaAmt.Select();
            }
            else if (e.KeyChar == 13)
            {
                txtDiaAmt.Select();
            }
            
        }

        private void txtDiaAmt_KeyPress(object sender, KeyPressEventArgs e)
        {
            dbUtils.onlyDecimal(sender, ref e);
            TextBox txtbox = (TextBox)sender;
            if (e.KeyChar == 13 & txtbox.Text.Length > 0)
            {
                dbUtils.Decimal2digit(ref txtbox);
                addDiamondToGrid();
                cmbDiamond.Select();
            }
            
        }

        private void txtDiaAmt_TextChanged(object sender, EventArgs e)
        {
            if (txtDiaWt.Text.Length > 0 && txtDiaAmt.Text.Length >0 )
            {
                txtDiaRate.Text = (Math.Round(double.Parse(txtDiaAmt.Text) / double.Parse(txtDiaWt.Text)).ToString());
            }
        }

        private void txtDiaWt_TextChanged(object sender, EventArgs e)
        {
            if (txtDiaWt.Text.Length > 0 && txtDiaRate.Text.Length > 0 && double.Parse(txtDiaRate.Text) > 0 && txtDiaAmt.Text.Length > 0)
            {
                txtDiaAmt.Text = totalAmount(txtDiaRate.Text, txtDiaWt.Text).ToString();
            }
        }

        private void txtDiaAmt_Enter(object sender, EventArgs e)
        {
            if (txtDiaWt.Text.Length > 0 && txtDiaRate.Text.Length > 0 && double.Parse(txtDiaRate.Text) > 0)
            {
                txtDiaAmt.Text = totalAmount(txtDiaRate.Text, txtDiaWt.Text).ToString();
            }
        }

        private void txtStoneRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            dbUtils.onlyDecimal(sender, ref e);
            TextBox txtbox = (TextBox)sender;
            if (e.KeyChar == 13)
            {
                txtStoneAmt.Select();
            }
        }

        private void txtStoneAmt_KeyPress(object sender, KeyPressEventArgs e)
        {
            dbUtils.onlyDecimal(sender, ref e);
            TextBox txtbox = (TextBox)sender;
            if (e.KeyChar == 13)
            {
                addStoneToGrid();
                cmbStone.Select();
            }
        }

        private void txtStoneAmt_Enter(object sender, EventArgs e)
        {
            if (txtStoneRate.Text.Length > 0 && double.Parse(txtStoneRate.Text) > 0 && txtStoneWt.Text.Length > 0)
            {
                txtStoneAmt.Text = totalAmount(txtStoneWt.Text, txtStoneRate.Text).ToString();
            }
        }

        private void txtStoneAmt_TextChanged(object sender, EventArgs e)
        {
            if (txtStoneWt.Text.Length > 0 && txtStoneAmt.Text.Length > 0)
            {
                txtStoneRate.Text = (Math.Round(double.Parse(txtStoneAmt.Text) / double.Parse(txtStoneWt.Text)).ToString());
            }
        }

        private void txtIStoneWt_TextChanged(object sender, EventArgs e)
        {
            if (txtIStoneWt.Text.Length > 0 && txtIStoneRate.Text.Length > 0 && double.Parse(txtIStoneRate.Text) > 0)
            {
                txtIStoneAmt.Text = totalAmount(txtIStoneWt.Text,txtIStoneRate.Text).ToString();
            }
        }

        private void txtIStoneAmt_Enter(object sender, EventArgs e)
        {
            if (txtIStoneWt.Text.Length > 0 && txtIStoneRate.Text.Length > 0 && double.Parse(txtIStoneRate.Text) > 0)
            {
                txtIStoneAmt.Text = totalAmount(txtIStoneWt.Text, txtIStoneRate.Text).ToString();
            }
        }

        private void txtIStoneAmt_TextChanged(object sender, EventArgs e)
        {
            if (txtIStoneWt.Text.Length > 0 && txtIStoneAmt.Text.Length > 0)
            {
                txtIStoneRate.Text = (Math.Round(double.Parse(txtIStoneAmt.Text) / double.Parse(txtIStoneWt.Text)).ToString());
            }
        }

        private void txtIStoneAmt_KeyPress(object sender, KeyPressEventArgs e)
        {
            dbUtils.onlyDecimal(sender, ref e);
            TextBox txtbox = (TextBox)sender;
            if (e.KeyChar == 13 && txtbox.Text.Length > 0 && cmbIStone.SelectedIndex != -1)
            {
                dbUtils.Decimal2digit(ref txtbox);
                addStoneCToGrid();
                cmbIStone.Select();
            }
        }

        private void txtIDiamondRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            dbUtils.onlyDecimal(sender, ref e);
            TextBox txtbox = (TextBox)sender;
            if (e.KeyChar == 13)
            {
                txtIDiamondAmt.Select();
            }
        }

        private void txtIDiamondAmt_Enter(object sender, EventArgs e)
        {
            if (txtIDiamondWt.Text.Length > 0 && txtIDiamondRate.Text.Length > 0 && double.Parse(txtIDiamondRate.Text) > 0)
            {
                txtIDiamondAmt.Text = totalAmount(txtIDiamondWt.Text, txtIDiamondRate.Text).ToString();
            }
        }

        private void txtIDiamondAmt_TextChanged(object sender, EventArgs e)
        {
            if (txtIDiamondWt.Text.Length > 0 && txtIDiamondAmt.Text.Length > 0)
            {
                txtIDiamondRate.Text = (Math.Round(double.Parse(txtIDiamondAmt.Text) / double.Parse(txtIDiamondWt.Text)).ToString());
            }
        }

        private void txtIDiamondAmt_KeyPress(object sender, KeyPressEventArgs e)
        {
            dbUtils.onlyDecimal(sender, ref e);
            TextBox txtbox = (TextBox)sender;
            if (e.KeyChar == 13 && txtbox.Text.Length > 0)
            {
                dbUtils.Decimal2digit(ref txtbox);
                addDiamondCToGrid();
                cmbIDiamond.Select();
            }
        }

        private void txtIStoneRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            dbUtils.onlyDecimal(sender, ref e);
            TextBox txtbox = (TextBox)sender;
            if (e.KeyChar == 13)
            {
                txtIStoneAmt.Select();
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabControl control = (TabControl)sender;
            if (control.SelectedTab.Name == "tabSingle")
            {
                cmbProductCode.Select();
            }
            else
            {
                cmbProductCodeC.Select();
            }
        }

        private void txtIPcsC_KeyPress(object sender, KeyPressEventArgs e)
        {
            dbUtils.onlyInteger(sender, ref e);
        }


    }
}
