using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockManagement.Report
{
    public partial class CrystalReportViewer : Form
    {

        public delegate void CustomPrintDelegate();
        public Delegate CustomPrintMethod { get; set; }

        public CrystalReportViewer()
        {
            InitializeComponent();
            //InitializeButtons();  // Take custom action when user hit print button
            setCloseButtonLocation();
        }

        private void InitializeButtons()
        {
            foreach (Control control in crystalReportViewer1.Controls)
            {
                if (control is System.Windows.Forms.ToolStrip)
                {

                    //Default Print Button
                    ToolStripItem tsItem = ((ToolStrip)control).Items[1];
                    tsItem.Click += new EventHandler(tsItem_Click);
                    tsItem.ToolTipText = "My custom print ";

                    //Custom Button
                    ToolStripItem tsNewItem = ((ToolStrip)control).Items.Add("");
                    tsNewItem.ToolTipText = "Custom Print Button";
                    //tsNewItem.Image = Resources.CustomButton;
                    tsNewItem.Tag = "99";
                    ((ToolStrip)control).Items.Insert(0, tsNewItem);
                    tsNewItem.Click += new EventHandler(tsNewItem_Click);
                }
            }
        }


        void tsNewItem_Click(object sender, EventArgs e)
        {
            if (CustomPrintMethod != null)
            {
                CustomPrintMethod.DynamicInvoke(null);
            }
        }

        void tsItem_Click(object sender, EventArgs e)
        {
            if (CustomPrintMethod != null)
            {

                MessageBox.Show("Custom print");
                MessageBox.Show(sender.GetType().ToString());
                CustomPrintMethod.DynamicInvoke(null);
            }
            else
            {
                MessageBox.Show("Custom print");
                MessageBox.Show(sender.GetType().ToString());
            
            }
        }

        private void setCloseButtonLocation()
        {
            int x = Screen.PrimaryScreen.Bounds.Width;
            btnClose.Location = new Point(x - btnClose.Size.Width - 5, 5);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
