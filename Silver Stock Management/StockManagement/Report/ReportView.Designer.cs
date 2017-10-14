namespace StockManagement.Report
{
    partial class ReportView
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
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.pnlMasterEntry = new System.Windows.Forms.Panel();
            this.pbMasterEntry = new System.Windows.Forms.PictureBox();
            this.lblMasterEntry = new System.Windows.Forms.Label();
            this.pnlStockDetail = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlTransport = new System.Windows.Forms.Panel();
            this.pbTransport = new System.Windows.Forms.PictureBox();
            this.panelStockOut = new System.Windows.Forms.Panel();
            this.pnlEmptyTag = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlInvoiceDetail = new System.Windows.Forms.Panel();
            this.pnlBackup = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlContainer.SuspendLayout();
            this.pnlMasterEntry.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMasterEntry)).BeginInit();
            this.pnlStockDetail.SuspendLayout();
            this.pnlTransport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTransport)).BeginInit();
            this.pnlEmptyTag.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.pnlInvoiceDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContainer
            // 
            this.pnlContainer.BackColor = System.Drawing.Color.Linen;
            this.pnlContainer.Controls.Add(this.pnlMasterEntry);
            this.pnlContainer.Controls.Add(this.pnlStockDetail);
            this.pnlContainer.Controls.Add(this.panel1);
            this.pnlContainer.Controls.Add(this.pnlTransport);
            this.pnlContainer.Controls.Add(this.panelStockOut);
            this.pnlContainer.Controls.Add(this.pnlEmptyTag);
            this.pnlContainer.Controls.Add(this.pnlInvoiceDetail);
            this.pnlContainer.Controls.Add(this.pnlBackup);
            this.pnlContainer.Location = new System.Drawing.Point(12, 12);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(1134, 570);
            this.pnlContainer.TabIndex = 19;
            // 
            // pnlMasterEntry
            // 
            this.pnlMasterEntry.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(196)))), ((int)(((byte)(42)))));
            this.pnlMasterEntry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMasterEntry.Controls.Add(this.pbMasterEntry);
            this.pnlMasterEntry.Controls.Add(this.lblMasterEntry);
            this.pnlMasterEntry.Location = new System.Drawing.Point(22, 24);
            this.pnlMasterEntry.Name = "pnlMasterEntry";
            this.pnlMasterEntry.Size = new System.Drawing.Size(374, 224);
            this.pnlMasterEntry.TabIndex = 9;
            this.pnlMasterEntry.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pnlMasterEntry_MouseClick);
            this.pnlMasterEntry.MouseHover += new System.EventHandler(this.pnlMasterEntry_MouseHover);
            // 
            // pbMasterEntry
            // 
            this.pbMasterEntry.BackColor = System.Drawing.Color.Transparent;
            this.pbMasterEntry.Image = global::StockManagement.Properties.Resources.dailyReport;
            this.pbMasterEntry.Location = new System.Drawing.Point(62, 41);
            this.pbMasterEntry.Name = "pbMasterEntry";
            this.pbMasterEntry.Size = new System.Drawing.Size(255, 129);
            this.pbMasterEntry.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbMasterEntry.TabIndex = 4;
            this.pbMasterEntry.TabStop = false;
            this.pbMasterEntry.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pnlMasterEntry_MouseClick);
            // 
            // lblMasterEntry
            // 
            this.lblMasterEntry.AutoSize = true;
            this.lblMasterEntry.BackColor = System.Drawing.Color.Transparent;
            this.lblMasterEntry.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMasterEntry.ForeColor = System.Drawing.Color.Black;
            this.lblMasterEntry.Location = new System.Drawing.Point(3, 196);
            this.lblMasterEntry.Name = "lblMasterEntry";
            this.lblMasterEntry.Size = new System.Drawing.Size(84, 19);
            this.lblMasterEntry.TabIndex = 0;
            this.lblMasterEntry.Text = "Daily Report";
            // 
            // pnlStockDetail
            // 
            this.pnlStockDetail.AutoScroll = true;
            this.pnlStockDetail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.pnlStockDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStockDetail.Controls.Add(this.label2);
            this.pnlStockDetail.Location = new System.Drawing.Point(425, 24);
            this.pnlStockDetail.Name = "pnlStockDetail";
            this.pnlStockDetail.Size = new System.Drawing.Size(374, 224);
            this.pnlStockDetail.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(12, 196);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Stock Detail";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Crimson;
            this.panel1.Location = new System.Drawing.Point(998, 233);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(125, 125);
            this.panel1.TabIndex = 8;
            // 
            // pnlTransport
            // 
            this.pnlTransport.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.pnlTransport.Controls.Add(this.pbTransport);
            this.pnlTransport.Location = new System.Drawing.Point(867, 102);
            this.pnlTransport.Name = "pnlTransport";
            this.pnlTransport.Size = new System.Drawing.Size(256, 125);
            this.pnlTransport.TabIndex = 16;
            // 
            // pbTransport
            // 
            this.pbTransport.BackColor = System.Drawing.Color.Transparent;
            this.pbTransport.Image = global::StockManagement.Properties.Resources.appbar_cog;
            this.pbTransport.Location = new System.Drawing.Point(90, 17);
            this.pbTransport.Name = "pbTransport";
            this.pbTransport.Size = new System.Drawing.Size(76, 76);
            this.pbTransport.TabIndex = 2;
            this.pbTransport.TabStop = false;
            // 
            // panelStockOut
            // 
            this.panelStockOut.BackColor = System.Drawing.Color.Yellow;
            this.panelStockOut.Location = new System.Drawing.Point(867, 364);
            this.panelStockOut.Name = "panelStockOut";
            this.panelStockOut.Size = new System.Drawing.Size(125, 125);
            this.panelStockOut.TabIndex = 8;
            // 
            // pnlEmptyTag
            // 
            this.pnlEmptyTag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(111)))), ((int)(((byte)(67)))));
            this.pnlEmptyTag.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlEmptyTag.Controls.Add(this.pictureBox2);
            this.pnlEmptyTag.Controls.Add(this.label1);
            this.pnlEmptyTag.Location = new System.Drawing.Point(22, 289);
            this.pnlEmptyTag.Name = "pnlEmptyTag";
            this.pnlEmptyTag.Size = new System.Drawing.Size(374, 224);
            this.pnlEmptyTag.TabIndex = 10;
            this.pnlEmptyTag.Click += new System.EventHandler(this.pnlEmptyTag_Click);
            this.pnlEmptyTag.MouseHover += new System.EventHandler(this.pnlEmptyTag_MouseHover);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::StockManagement.Properties.Resources.appbar_tag_label;
            this.pictureBox2.Location = new System.Drawing.Point(149, 61);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(76, 76);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pnlEmptyTag_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(13, 192);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Empty Tag";
            // 
            // pnlInvoiceDetail
            // 
            this.pnlInvoiceDetail.BackColor = System.Drawing.Color.LightSeaGreen;
            this.pnlInvoiceDetail.Controls.Add(this.label3);
            this.pnlInvoiceDetail.Location = new System.Drawing.Point(425, 289);
            this.pnlInvoiceDetail.Name = "pnlInvoiceDetail";
            this.pnlInvoiceDetail.Size = new System.Drawing.Size(374, 224);
            this.pnlInvoiceDetail.TabIndex = 13;
            // 
            // pnlBackup
            // 
            this.pnlBackup.BackColor = System.Drawing.Color.DeepPink;
            this.pnlBackup.Location = new System.Drawing.Point(998, 364);
            this.pnlBackup.Name = "pnlBackup";
            this.pnlBackup.Size = new System.Drawing.Size(125, 125);
            this.pnlBackup.TabIndex = 12;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.MintCream;
            this.btnClose.BackgroundImage = global::StockManagement.Properties.Resources.appbar_close;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(1152, -3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(35, 39);
            this.btnClose.TabIndex = 32;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(13, 193);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 19);
            this.label3.TabIndex = 1;
            this.label3.Text = "Invoice Printing";
            // 
            // ReportView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Linen;
            this.ClientSize = new System.Drawing.Size(1230, 594);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.pnlContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ReportView";
            this.Text = "ReportView";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlContainer.ResumeLayout(false);
            this.pnlMasterEntry.ResumeLayout(false);
            this.pnlMasterEntry.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMasterEntry)).EndInit();
            this.pnlStockDetail.ResumeLayout(false);
            this.pnlStockDetail.PerformLayout();
            this.pnlTransport.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbTransport)).EndInit();
            this.pnlEmptyTag.ResumeLayout(false);
            this.pnlEmptyTag.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.pnlInvoiceDetail.ResumeLayout(false);
            this.pnlInvoiceDetail.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlContainer;
        private System.Windows.Forms.Panel pnlMasterEntry;
        private System.Windows.Forms.PictureBox pbMasterEntry;
        private System.Windows.Forms.Label lblMasterEntry;
        private System.Windows.Forms.Panel pnlStockDetail;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlTransport;
        private System.Windows.Forms.PictureBox pbTransport;
        private System.Windows.Forms.Panel panelStockOut;
        private System.Windows.Forms.Panel pnlEmptyTag;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlInvoiceDetail;
        private System.Windows.Forms.Panel pnlBackup;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}