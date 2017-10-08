using StockManagement.Utils;
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
using Excel = Microsoft.Office.Interop.Excel; 

namespace StockManagement.Transaction
{
    public partial class Import : Form
    {
        Dictionary<String, GroupInfo> groupInfo = new Dictionary<string, GroupInfo>();

        public Import()
        {
            InitializeComponent();
            dbUtils.connection();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            dbUtils.disConnect();
            Close();
        }

        private void Import_Load(object sender, EventArgs e)
        {

        }

        private void pbImport_Click(object sender, EventArgs e)
        {
            ofDialog.Filter = "Excel Files|*.xls;*.xlsx";
            ofDialog.FilterIndex = 1;
            ofDialog.FileName = "";
            DialogResult result = ofDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (txtFilePath.Text.Length > 0)
                {
                    ImportData(txtFilePath.Text);
                }
            }
            else
            {
                txtFilePath.Text = "";
            }
        }

        private void ofDialog_FileOk(object sender, CancelEventArgs e)
        {
            txtFilePath.Text = ofDialog.FileName.ToString();
        }

        private void ImportData(string fileName)
        {
            Excel.Application xlApp=null;
            Excel.Workbook xlWorkBook=null;
            Excel.Worksheet xlWorkSheet=null;
            Excel.Range range;

            string tagNo;
            string itemDesc;
            double weight=0;
            double grosswt= 0;
            int pcs = 0;

            int rCnt = 0;
            try
            {
                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Open(fileName, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                range = xlWorkSheet.UsedRange;
                //MessageBox.Show(range.Columns.Count.ToString());
                if (range.Columns.Count != 5)
                {
                    MessageBox.Show("Please choose a valid excel file.");
                    return;
                }
                dynamic value;
                string metalType = "";
                for (rCnt = 1; rCnt <= range.Rows.Count; rCnt++)
                {
                    value = (range.Cells[rCnt, 1] as Excel.Range).Value2;
                    if (value != null)
                    {
                        tagNo = value.ToString();
                    }
                    else
                    {
                        tagNo = "";
                    }

                    value = (range.Cells[rCnt, 2] as Excel.Range).Value2;
                    if (value != null)
                    {
                        itemDesc = value.ToString();
                    }
                    else
                    {
                        itemDesc = "";
                    }

                    if ((range.Cells[rCnt, 3] as Excel.Range).Value != null)
                    {
                       // MessageBox.Show(range.Cells[rCnt, 3].GetType().ToString());
                        weight = (double)(range.Cells[rCnt, 3] as Excel.Range).Value2;
                        grosswt = (double)(range.Cells[rCnt, 4] as Excel.Range).Value2;
                        pcs = (int)(range.Cells[rCnt, 5] as Excel.Range).Value2;
                    }
                    if (itemDesc.Length > 0)
                    {
                        string startwith = itemDesc.Trim().Substring(0, 2);
                        if (startwith.Equals("D.") || startwith.Equals("D "))
                        {
                            metalType = "Gold 18K";
                        }
                        else
                        {
                            metalType = "Gold 22K";
                        }
                        string[] row = new string[] { itemDesc, tagNo, metalType, pcs.ToString(), grosswt.ToString(), weight.ToString() };
                        dgData.Rows.Add(row);
                    }
                }
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(2);
                Dictionary<string, double> diamondList = getDiamondDetail(xlWorkSheet);
                fillDiamondWeight(diamondList);
            }
            catch(Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
            finally
            {
                xlWorkBook.Close(0);
                xlApp.Quit();
            }
        }

        private void fillDiamondWeight(Dictionary<string, double> diamondList)
        {
            string key;
            foreach (DataGridViewRow item in dgData.Rows)
            {
                key = item.Cells[1].Value + ":" + item.Cells[0].Value;
                try
                {
                    item.Cells[6].Value = diamondList[key];
                }
                catch (Exception)
                {
                    
                   // throw;
                }
               
            }
        }


        private Dictionary<string, double> getDiamondDetail(Excel.Worksheet xlWorkSheet)
        {
            int rCnt;
            string tagNo;
            string itemDesc;
            double diamondWt=0;
            Dictionary<string, double> diamondList = new Dictionary<string, double>();

            Excel.Range range = xlWorkSheet.UsedRange;
            if (range.Columns.Count != 3)
            {
                MessageBox.Show("Please choose a valid excel file.");
                return null;
            }
            dynamic value;

            for (rCnt = 1; rCnt <= range.Rows.Count; rCnt++)
            {
                value = (range.Cells[rCnt, 1] as Excel.Range).Value2;
                if (value != null)
                {
                    tagNo = value.ToString();
                }
                else
                {
                    continue;
                }

                value = (range.Cells[rCnt, 2] as Excel.Range).Value2;
                if (value != null)
                {
                    itemDesc = value.ToString();
                }
                else
                {
                    continue;
                }

                if ((range.Cells[rCnt, 3] as Excel.Range).Value != null)
                    diamondWt = (double)(range.Cells[rCnt, 3] as Excel.Range).Value2;

                if (itemDesc.Length > 0)
                {
                    diamondList.Add(tagNo + ":" + itemDesc, diamondWt);
                }
            }
            return diamondList;
        }

       
        private void pbSave_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void SaveData()
        {   //ITEMdESC,Tag, Metal, Pcs, gw, nw, Diamond
            OleDbCommand command = new OleDbCommand();
            OleDbTransaction transaction = null;
            OleDbConnection dbConnection = null;
            List<int> uniqueList = new List<int>();
            string sqlQry = "";
            int uniqueNumber = 0;
            string diamondQry="";
            int stoneId = 0;

            try
            {
                sqlQry = "INSERT INTO TRANS (TID,TDATE,PCODE,TNO,METALTYPE,PCS,GW,NW) VALUES (@1,@2,@3,@4,@5,@6,@7,@8)";
                dbConnection = dbUtils.getConnection();
                transaction = dbConnection.BeginTransaction();
                command.Connection = dbConnection;
                command.Transaction = transaction;
                command.CommandText = sqlQry;
                foreach (DataGridViewRow item in dgData.Rows)
                {
                    command.Parameters.Clear();
                    while (true)
                    {
                        uniqueNumber = dbUtils.getUniqueNumber("SELECT TID FROM TRANS WHERE TID = ");
                        if (!uniqueList.Contains(uniqueNumber))
                        {
                            uniqueList.Add(uniqueNumber);
                            break;
                        }
                    }
                    command.Parameters.Add("@1", OleDbType.Integer, 10).Value = uniqueNumber;
                    command.Parameters.Add("@2", OleDbType.Date, 10).Value = String.Format("{0:yyyy/MM/dd}",DateTime.Now.ToShortDateString());
                    command.Parameters.Add("@3", OleDbType.VarChar, 80).Value = item.Cells[0].Value.ToString();
                    command.Parameters.Add("@4", OleDbType.Integer, 10).Value = item.Cells[1].Value;
                    command.Parameters.Add("@5", OleDbType.VarChar, 50).Value = item.Cells[2].Value;
                    command.Parameters.Add("@6", OleDbType.Integer, 10).Value = item.Cells[3].Value;
                    command.Parameters.Add("@7", OleDbType.Double, 10).Value = item.Cells[4].Value;
                    command.Parameters.Add("@8", OleDbType.Double, 10).Value = item.Cells[5].Value;
                    LoggingManager.WriteToLog(1, sqlQry);
                    LoggingManager.WriteToLog(1, uniqueNumber +"-" + String.Format("{0:yyyy/MM/dd}",DateTime.Now.ToShortDateString()) + "-" + item.Cells[0].Value.ToString() + "-" + item.Cells[1].Value +"-" + item.Cells[2].Value+"-"+item.Cells[3].Value+"-"+item.Cells[4].Value+"-"+item.Cells[5].Value);

                    command.ExecuteNonQuery();

                    if (item.Cells[6].Value != null && item.Cells[6].Value.ToString().Length > 0)
                    {
                        diamondQry = "INSERT INTO STONEDATA (ID,PID,SDESC,STYPE,SWT) VALUES ({0},{1},'{2}','D',{3})";
                        stoneId = dbUtils.get5DigitUniqueNumber("SELECT ID FROM STONEDATA WHERE ID = ", uniqueList);
                        dbUtils.saveToDB2(string.Format(diamondQry,stoneId,uniqueNumber,"Mixed",item.Cells[6].Value), transaction,dbConnection);
                    }
                }
                transaction.Commit();
                MessageBox.Show("Data Successfully Imported ");
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                MessageBox.Show(ex.Message);
            }
            finally
            {
                dbConnection.Close();
                command.Dispose();
            }
        }

        private void pbCheck_Click(object sender, EventArgs e)
        {
            if (dgData.Rows.Count > 0)
                ImportCheck();
        }

        private void ImportCheck()
        {
            groupInfo.Clear();
            foreach (DataGridViewRow item in dgData.Rows)
            {
                if (groupInfo.ContainsKey(item.Cells[0].Value.ToString()))
                {
                    GroupInfo itemDesc = groupInfo[item.Cells[0].Value.ToString()];
                    itemDesc.Pcs = itemDesc.Pcs + int.Parse(item.Cells[3].Value.ToString());
                    itemDesc.Netwt = itemDesc.Netwt + double.Parse(item.Cells[5].Value.ToString());
                    if (item.Cells[6].Value != null && item.Cells[6].Value.ToString().Length > 0)
                    itemDesc.Diamond = itemDesc.Diamond + double.Parse(item.Cells[6].Value.ToString());
                }
                else
                {
                    GroupInfo itemDesc = new GroupInfo();
                    itemDesc.ItemDesc = item.Cells[0].Value.ToString();
                    itemDesc.MetalType = item.Cells[2].Value.ToString();
                    itemDesc.Pcs = int.Parse(item.Cells[3].Value.ToString());
                    itemDesc.Netwt = double.Parse(item.Cells[5].Value.ToString());
                    if (item.Cells[6].Value != null && item.Cells[6].Value.ToString().Length > 0)
                    itemDesc.Diamond = double.Parse(item.Cells[6].Value.ToString());
                    else
                    itemDesc.Diamond = 0;
                    groupInfo.Add(itemDesc.ItemDesc, itemDesc);
                }

            }
            dgItemGroup.Rows.Clear();
            foreach (string key in groupInfo.Keys)
	        {
                GroupInfo infoObject = groupInfo[key];
                dgItemGroup.Rows.Add(new string[]{infoObject.ItemDesc,infoObject.MetalType,infoObject.Pcs.ToString(),infoObject.Netwt.ToString(),infoObject.Diamond.ToString()});
	        }   
        }

        private void pbCreateProductMaster_Click(object sender, EventArgs e)
        {
            if (dgItemGroup.Rows.Count > 0)
                createProductMaster();
        }

        private void createProductMaster()
        {
            string pname = "";
            string result = "";
            string saveQry = "INSERT INTO PRODUCTM (PNAME) VALUES ('{0}')";
            string checkQry = "SELECT PNAME FROM PRODUCTM WHERE PNAME = '{0}'";

            foreach (DataGridViewRow item in dgItemGroup.Rows)
            {
                pname = item.Cells[0].Value.ToString();
                result = dbUtils.FetchString(string.Format(checkQry,pname));
                if (result.Length == 0)
                {
                    dbUtils.saveToDB(string.Format(saveQry,pname));
                }
            }
            MessageBox.Show("Item Master Created !!! ");
        }
    }
}
