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

namespace StockManagement.Transaction
{
    public partial class Master : Form
    {
        string fieldTableDetail; // Field name & table name seprated by colon (:)
        public Master()
        {
            InitializeComponent();
            setMainPanelPosition();
            dbUtils.connection();
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


        private void loadDatafromQuery(string qry)
        {
            OleDbDataReader reader = dbUtils.fetch(qry);
            if (reader.HasRows)
            {
                dataGrid.Rows.Clear();
                while (reader.Read())
                {
                    string[] row = new string[] { reader.GetInt32(0).ToString(), reader.GetString(1) };
                    dataGrid.Rows.Add(row);
                }
            }
        }

        private void prepareProductQuery()
        {
            string qry = "SELECT ID,PNAME AS DESCRIPTION FROM PRODUCTM ORDER BY PNAME";
            loadDatafromQuery(qry);
        }

        private void prepareStoneQuery()
        {
            string qry = "SELECT ID,SDESC AS DESCRIPTION FROM STONEM WHERE STYPE='S' ORDER BY SDESC";
            loadDatafromQuery(qry);
        }

        private void prepareDiamondQuery()
        {
            string qry = "SELECT ID,SDESC AS DESCRIPTION FROM STONEM WHERE STYPE='D' ORDER BY SDESC";
            loadDatafromQuery(qry);
        }

        private void prepareSubItemQuery()
        {
            string qry = "SELECT ID,Subitem AS DESCRIPTION FROM SUBITEMM ORDER BY Subitem";
            loadDatafromQuery(qry);
        }

        private void prepareMetalQuery()
        {
            string qry = "SELECT ID,GDESC AS DESCRIPTION FROM METALM ORDER BY GDESC";
            loadDatafromQuery(qry);
        }

        private void btnProductM_Click(object sender, EventArgs e)
        {
            prepareProductQuery();
            panel1.BackColor = btnProductM.BackColor;
            dataGrid.BackgroundColor = btnProductM.BackColor;
            fieldTableDetail = "ProductM:Pname";
            reset();
            btnProductM.Width = 336;
        }

        private void btnItemM_Click(object sender, EventArgs e)
        {
            prepareSubItemQuery();
            panel1.BackColor = btnItemM.BackColor;
            dataGrid.BackgroundColor = btnItemM.BackColor;
            fieldTableDetail = "SubItemM:SubItem";
            reset();
            btnItemM.Width = 336;
        }

        private void btnMetalM_Click(object sender, EventArgs e)
        {
            prepareMetalQuery();
            panel1.BackColor = btnMetalM.BackColor;
            dataGrid.BackgroundColor = btnMetalM.BackColor;
            fieldTableDetail = "MetalM:Gdesc";
            reset();
            btnMetalM.Width = 336;
        }

        private void btnStoneM_Click(object sender, EventArgs e)
        {
            prepareStoneQuery();
            panel1.BackColor = btnStoneM.BackColor;
            dataGrid.BackgroundColor = btnStoneM.BackColor;
            fieldTableDetail = "StoneM:Sdesc:S";
            reset();
            btnStoneM.Width = 336;
        }

        private void btnDiamondM_Click(object sender, EventArgs e)
        {
            prepareDiamondQuery();
            panel1.BackColor = btnDiamondM.BackColor;
            dataGrid.BackgroundColor = btnDiamondM.BackColor;
            fieldTableDetail = "StoneM:Sdesc:D";
            reset();
            btnDiamondM.Width=336;
        }

        private void reset()
        {
            btnProductM.Width = 316;
            btnMetalM.Width = 316;
            btnStoneM.Width = 316;
            btnItemM.Width = 316;
            btnDiamondM.Width = 316;
            btnSave.Text = "Save";
            btnDeleteC.Visible = false;
            btnModify.Text = "Modify";
            txtDesc.Text = string.Empty;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text.Equals("Save"))
            {
                if (txtDesc.Text.Length > 0)
                {
                    SaveData();
                }
            }
            else
            {
                if (txtDesc.Text.Length > 0)
                {
                    UpdateData();
                }
            }
        }

        private void UpdateData()
        {
            string[] fields = fieldTableDetail.Split(':');
            if (fields.Length > 0)
            {
                string ID = dataGrid.CurrentRow.Cells[0].Value.ToString();
                string sqlQry = "UPDATE " + fields[0] + " SET " + fields[1] + "='" + txtDesc.Text + "' WHERE ID = " + ID;
                dbUtils.saveToDB(sqlQry);
                changeButtonName(btnModify, "Modify");
                changeButtonName(btnSave, "Save");
                txtDesc.Text = "";
                resetDataGrid();
            }
        }

        private void resetDataGrid()
        {
            string master = fieldTableDetail.Split(':')[0];

            if (master.Equals("ProductM"))
            {
                prepareProductQuery();
            }
            else if (master.Equals("SubItemM"))
            {
                prepareSubItemQuery();
            }
            else if (master.Equals("MetalM"))
            {
                prepareMetalQuery();
            }
            else if (master.Equals("StoneM"))
            {
                string stoneType = fieldTableDetail.Split(':')[2];
                if (stoneType.Equals("D"))
                {
                    prepareDiamondQuery();
                }
                else
                {
                    prepareStoneQuery();
                }
            }
        }

        private void DeleteData()
        {
            string[] fields = fieldTableDetail.Split(':');
            if (fields.Length > 0)
            {
                string sqlQry = "DELETE FROM " + fields[0] + " WHERE " + fields[1] + "='" + txtDesc.Text +"'";
                dbUtils.saveToDB(sqlQry);
                resetDataGrid();
                clearControl();
            }
        }

        private void SaveData()
        {
            string[] fields=fieldTableDetail.Split(':');
            string sqlQry = string.Empty;
            if (fields.Length == 2)
            {
                sqlQry = "INSERT INTO " + fields[0] + " (" + fields[1] + ") VALUES ('" + txtDesc.Text + "')";
            }
            else if (fields.Length == 3)
            {
                sqlQry = "INSERT INTO " + fields[0] + "("+ fields[1] +",Stype) VALUES('" + txtDesc.Text + "','" + fields[2] + "')";
            }
            dbUtils.saveToDB(sqlQry);
            resetDataGrid();
            clearControl();
        }

        private void clearControl()
        {
            txtDesc.Text = "";
        }

        private void btnDeleteC_Click(object sender, EventArgs e)
        {
            if (txtDesc.Text.Length > 0)
            {
                if (MessageBox.Show("Are you sure want to delete ?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    DeleteData();
                    btnDeleteC.Visible = false;
                    changeButtonName(btnModify, "Modify");
                    changeButtonName(btnSave, "Save");
                }
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (btnModify.Text.Equals("Modify"))
            {
                txtDesc.Text = dataGrid.Rows[dataGrid.CurrentRow.Index].Cells[1].Value.ToString();
                changeButtonName(btnModify, "Cancel");
                changeButtonName(btnSave, "Update");
                btnDeleteC.Visible = true;
            }
            else
            {
                txtDesc.Text = "";
                changeButtonName(btnModify, "Modify");
                changeButtonName(btnSave, "Save");
                btnDeleteC.Visible = false;
            }
        }

        private void changeButtonName(Button btn, string name)
        {
            btn.Text = name;
        }

        private void dataGrid_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           //txtDesc.Text=dataGrid.Rows[e.RowIndex].Cells[1].Value.ToString();
        }
    }
}
