namespace StockManagement.Report
{
    partial class InvoicePrinting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbInvoice = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.btnShowReport = new System.Windows.Forms.Button();
            this.chkPicture = new System.Windows.Forms.CheckBox();
            this.rdoOriginal = new System.Windows.Forms.RadioButton();
            this.rdoDuplicate = new System.Windows.Forms.RadioButton();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbInvoice
            // 
            this.cmbInvoice.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbInvoice.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbInvoice.FormattingEnabled = true;
            this.cmbInvoice.Location = new System.Drawing.Point(120, 14);
            this.cmbInvoice.Name = "cmbInvoice";
            this.cmbInvoice.Size = new System.Drawing.Size(176, 28);
            this.cmbInvoice.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select Invoice ";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.rdoDuplicate);
            this.pnlMain.Controls.Add(this.rdoOriginal);
            this.pnlMain.Controls.Add(this.btnShowReport);
            this.pnlMain.Controls.Add(this.chkPicture);
            this.pnlMain.Controls.Add(this.cmbInvoice);
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Location = new System.Drawing.Point(12, 12);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(307, 175);
            this.pnlMain.TabIndex = 2;
            // 
            // btnShowReport
            // 
            this.btnShowReport.BackColor = System.Drawing.Color.AliceBlue;
            this.btnShowReport.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnShowReport.FlatAppearance.CheckedBackColor = System.Drawing.Color.Gainsboro;
            this.btnShowReport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.btnShowReport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.btnShowReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowReport.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowReport.Location = new System.Drawing.Point(120, 118);
            this.btnShowReport.Name = "btnShowReport";
            this.btnShowReport.Size = new System.Drawing.Size(176, 52);
            this.btnShowReport.TabIndex = 10;
            this.btnShowReport.Text = "Show";
            this.btnShowReport.UseVisualStyleBackColor = false;
            this.btnShowReport.Click += new System.EventHandler(this.btnShowReport_Click);
            // 
            // chkPicture
            // 
            this.chkPicture.AutoSize = true;
            this.chkPicture.Location = new System.Drawing.Point(120, 48);
            this.chkPicture.Name = "chkPicture";
            this.chkPicture.Size = new System.Drawing.Size(156, 24);
            this.chkPicture.TabIndex = 3;
            this.chkPicture.Text = "Invoice with Picture";
            this.chkPicture.UseVisualStyleBackColor = true;
            // 
            // rdoOriginal
            // 
            this.rdoOriginal.AutoSize = true;
            this.rdoOriginal.Location = new System.Drawing.Point(120, 79);
            this.rdoOriginal.Name = "rdoOriginal";
            this.rdoOriginal.Size = new System.Drawing.Size(80, 24);
            this.rdoOriginal.TabIndex = 11;
            this.rdoOriginal.Text = "Original";
            this.rdoOriginal.UseVisualStyleBackColor = true;
            // 
            // rdoDuplicate
            // 
            this.rdoDuplicate.AutoSize = true;
            this.rdoDuplicate.Checked = true;
            this.rdoDuplicate.Location = new System.Drawing.Point(196, 79);
            this.rdoDuplicate.Name = "rdoDuplicate";
            this.rdoDuplicate.Size = new System.Drawing.Size(91, 24);
            this.rdoDuplicate.TabIndex = 11;
            this.rdoDuplicate.TabStop = true;
            this.rdoDuplicate.Text = "Duplicate";
            this.rdoDuplicate.UseVisualStyleBackColor = true;
            // 
            // InvoicePrinting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSeaGreen;
            this.ClientSize = new System.Drawing.Size(326, 190);
            this.Controls.Add(this.pnlMain);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "InvoicePrinting";
            this.Text = "StockSummary";
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbInvoice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.CheckBox chkPicture;
        private System.Windows.Forms.Button btnShowReport;
        private System.Windows.Forms.RadioButton rdoDuplicate;
        private System.Windows.Forms.RadioButton rdoOriginal;
    }
}