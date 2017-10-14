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


namespace StockManagement.UI
{
    public partial class Purchase : Form
    {
        private int uniqueNumber;
        private double totalStoneWt = 0.00;
        private Dictionary<int, ItemInfo> itemInfoList;
        private List<int> runtimeKeyList;
        private string transactionId;
        private double stoneAmt = 0;
        private double diamondAmt = 0;

        public Purchase()
        {
            InitializeComponent();
            dbUtils.connection();
            loadProductMaster();
            fillGoldMaster();
           
            fillSubItemDetail();
            itemInfoList = new Dictionary<int, ItemInfo>();
            runtimeKeyList = new List<int>();
            dtDate.Value = DateTime.Today;
            this.Left = 0;
            this.Top = 150;
            this.Width = GlobalVar.windowsWidth;
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

        }

      
        private void fillSubItemDetail()
        {
            String str = "SELECT ID,SubItem FROM SUBITEMM ORDER BY SubItem";
            DataTable metalTable = new DataTable();
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

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                LoggingManager.WriteToLog(0, "frmValuationEntry : fill_cmbStoneDetail() : " + e.Message);
            }
        }



      



    }
}
