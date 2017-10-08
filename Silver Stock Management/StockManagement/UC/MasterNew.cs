using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockManagement.UC
{
    public partial class MasterNew : Form
    {
        public MasterNew()
        {
            InitializeComponent();
        }

        private void btnProductM_Click(object sender, EventArgs e)
        {
            panelRight.Controls.Clear();
            uscProductMaster objProduct = new uscProductMaster();
            panelRight.Controls.Add(objProduct);
        }

        private void btnMetalM_Click(object sender, EventArgs e)
        {
            panelRight.Controls.Clear();
            uscMetalMaster objMetal = new uscMetalMaster();
            panelRight.Controls.Add(objMetal);
        }

        private void btnICustomerM_Click(object sender, EventArgs e)
        {
            panelRight.Controls.Clear();
            uscCustomerMaster objCustomer = new uscCustomerMaster();
            panelRight.Controls.Add(objCustomer);

        }

        private void btnDealerM_Click(object sender, EventArgs e)
        {
            panelRight.Controls.Clear();
            uscDealerMaster objDealer = new uscDealerMaster();
            panelRight.Controls.Add(objDealer);
        }

        private void btnArtisanM_Click(object sender, EventArgs e)
        {
            panelRight.Controls.Clear();
            uscArtisanMaster objArtisan = new uscArtisanMaster();
            panelRight.Controls.Add(objArtisan);
        }
    }
}
