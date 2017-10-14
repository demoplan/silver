namespace StockManagement.Report
{
    partial class StockSummary
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
            this.cmbItem = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.btnShowReport = new System.Windows.Forms.Button();
            this.chkComposite = new System.Windows.Forms.CheckBox();
            this.chkPicture = new System.Windows.Forms.CheckBox();
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbItem
            // 
            this.cmbItem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbItem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbItem.FormattingEnabled = true;
            this.cmbItem.Location = new System.Drawing.Point(120, 38);
            this.cmbItem.Name = "cmbItem";
            this.cmbItem.Size = new System.Drawing.Size(176, 28);
            this.cmbItem.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Item";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.btnShowReport);
            this.pnlMain.Controls.Add(this.chkComposite);
            this.pnlMain.Controls.Add(this.chkPicture);
            this.pnlMain.Controls.Add(this.dtDate);
            this.pnlMain.Controls.Add(this.cmbItem);
            this.pnlMain.Controls.Add(this.label2);
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Location = new System.Drawing.Point(12, 12);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(307, 175);
            this.pnlMain.TabIndex = 2;
            // 
            // btnShowReport
            // 
            this.btnShowReport.BackColor = System.Drawing.Color.DarkTurquoise;
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
            // chkComposite
            // 
            this.chkComposite.AutoSize = true;
            this.chkComposite.Location = new System.Drawing.Point(120, 92);
            this.chkComposite.Name = "chkComposite";
            this.chkComposite.Size = new System.Drawing.Size(176, 24);
            this.chkComposite.TabIndex = 3;
            this.chkComposite.Text = "Composite item detail";
            this.chkComposite.UseVisualStyleBackColor = true;
            // 
            // chkPicture
            // 
            this.chkPicture.AutoSize = true;
            this.chkPicture.Location = new System.Drawing.Point(120, 72);
            this.chkPicture.Name = "chkPicture";
            this.chkPicture.Size = new System.Drawing.Size(139, 24);
            this.chkPicture.TabIndex = 3;
            this.chkPicture.Text = "Item with Picture";
            this.chkPicture.UseVisualStyleBackColor = true;
            // 
            // dtDate
            // 
            this.dtDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDate.Location = new System.Drawing.Point(120, 3);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(131, 29);
            this.dtDate.TabIndex = 2;
            this.dtDate.Value = new System.DateTime(2014, 1, 1, 0, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Report As On";
            // 
            // StockSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(326, 190);
            this.Controls.Add(this.pnlMain);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "StockSummary";
            this.Text = "StockSummary";
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtDate;
        private System.Windows.Forms.CheckBox chkComposite;
        private System.Windows.Forms.CheckBox chkPicture;
        private System.Windows.Forms.Button btnShowReport;
    }
}