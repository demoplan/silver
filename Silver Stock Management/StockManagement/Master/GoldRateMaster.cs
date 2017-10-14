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

namespace StockManagement.Master
{
    public partial class GoldRateMaster : Form
    {
        public GoldRateMaster()
        {
            InitializeComponent();
            if (dbUtils.dbcon.State == ConnectionState.Closed)
            {
                dbUtils.connection();
            }
            dtDate.Value = DateTime.Now;
            fillMetalList();
        }

        private void updateMetal(string mDate, string mDesc, double amount)
        {
            string sqlQry = "UPDATE METALDATA SET MRATE = " + amount + " WHERE MDESC = '" + mDesc + "' AND MDATE =#" + mDate + "#";
            dbUtils.saveToDB(sqlQry);
        }

        private void addMetalDetail(string mDate, string mDesc, double amount)
        {
            string sqlQry = "INSERT INTO METALDATA (MDESC,MDATE,MRATE) VALUES ('" + mDesc + "',#" + mDate + "#," + amount + ")";
            dbUtils.saveToDB(sqlQry);
        }

        private bool IsExistMetal(string mDate, string mDesc, double amount)
        {
            string sqlQry = "SELECT MRATE FROM  METALDATA  WHERE MDESC = '" + mDesc + "' AND MDATE =#" + mDate + "#";
            double result = dbUtils.FetchDouble(sqlQry);
            if (result > 0)
                return true;
            else
                return false;
        }

        private void saveData(string mDate, string mDesc, double amount)
        {
            if (IsExistMetal(mDate, mDesc, amount))
            {
                updateMetal(mDate, mDesc, amount);
            }
            else
            {
                addMetalDetail(mDate, mDesc, amount);
            }
        }

        private void fillMetalList()
        {
            string sqlQry = "SELECT DISTINCT MDESC FROM METALDATA";
            OleDbDataReader reader = dbUtils.fetch(sqlQry);
            cmbMetalList.Items.Clear();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    cmbMetalList.Items.Add(reader.GetString(0));
                }
            }
            reader.Close();
        }

        private void getMetalDetail(string curDate)
        {
            btnClose.Location = new Point(Screen.PrimaryScreen.Bounds.Width - btnClose.Size.Width - 5, 5);
            string sqlQry = "SELECT DISTINCT MDESC FROM METALDATA";
            OleDbDataReader reader = dbUtils.fetch(sqlQry);
            OleDbDataReader minfoReader=null;
            dgMetal.Rows.Clear();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                       sqlQry = "SELECT TOP 1 ID,MRATE,MDATE FROM METALDATA WHERE MDATE <= #" + curDate + "# AND MDESC='" + reader.GetString(0) + "' ORDER BY MDATE DESC";
                       minfoReader = dbUtils.fetch(sqlQry);
                       if (minfoReader.HasRows)
                       {
                           minfoReader.Read();
                           string[] row = new string[] {minfoReader.GetInt32(0).ToString(),reader.GetString(0) ,minfoReader.GetDateTime(2).ToShortDateString(),dbUtils.Decimal2digit(minfoReader.GetDouble(1).ToString()) };
                           dgMetal.Rows.Add(row);
                       }
                }
            }
            minfoReader.Close();
            reader.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            dbUtils.disConnect();
            Close();
        }

        private void dtDate_ValueChanged(object sender, EventArgs e)
        {
            getMetalDetail(dtDate.Value.ToShortDateString());
        }

        private void dgMetal_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string mDate = String.Format("{0:yyyy/MM/dd}", dtDate.Value);
            saveData(mDate, dgMetal.Rows[e.RowIndex].Cells[1].Value.ToString(), double.Parse(dgMetal.Rows[e.RowIndex].Cells[4].Value.ToString()));
        }

        private void btnAddMetal_Click(object sender, EventArgs e)
        {
            double amount = 0;
            string mDate = String.Format("{0:yyyy/MM/dd}", dtDate.Value);
            double.TryParse(txtAmount.Text,out amount);
            if (cmbMetalList.Text.Length > 0 && amount > 0)
            {
                saveData(mDate, cmbMetalList.Text, amount);
                cmbMetalList.Text = "";
                txtAmount.Text = "";
                getMetalDetail(mDate);
            }
        }

        private void deleteRow(string mDate, string mDesc, double amount)
        {
            string sql = "DELETE FROM METALDATA WHERE MDATE =#" + mDate + "# AND MDESC = '" + mDesc + "' AND MRATE = " + amount;
            dbUtils.saveToDB(sql);
        }

        private void dgMetal_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DialogResult answer = MessageBox.Show("Are you sure want to remove metal detail ? ", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer == DialogResult.Yes)
            {
                
                DateTime curDate;
                DateTime.TryParse(e.Row.Cells[2].Value.ToString(),out curDate);
                string mDate = String.Format("{0:yyyy/MM/dd}", curDate);
                double amount = 0;
                double.TryParse(e.Row.Cells[3].Value.ToString(), out amount);
                deleteRow(mDate, e.Row.Cells[1].Value.ToString(), amount);
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
