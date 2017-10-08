namespace StockManagement.Transaction
{
    partial class StockOUT
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btnStockOut = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.cmbTagNo = new System.Windows.Forms.ComboBox();
            this.cmbProductDesc = new System.Windows.Forms.ComboBox();
            this.dgStockOut = new System.Windows.Forms.DataGridView();
            this.Photo = new System.Windows.Forms.DataGridViewImageColumn();
            this.Product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TagNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MetailDetail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiamondDetail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StoneDetail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtStoneWt = new System.Windows.Forms.TextBox();
            this.txtDiamondWt = new System.Windows.Forms.TextBox();
            this.txtNetWt = new System.Windows.Forms.TextBox();
            this.txtTotalPcs = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgStockOut)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtDate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnStockOut);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label27);
            this.groupBox1.Controls.Add(this.cmbTagNo);
            this.groupBox1.Controls.Add(this.cmbProductDesc);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1073, 89);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // dtDate
            // 
            this.dtDate.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDate.Location = new System.Drawing.Point(28, 37);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(128, 29);
            this.dtDate.TabIndex = 0;
            this.dtDate.Value = new System.DateTime(2014, 8, 23, 0, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 21);
            this.label2.TabIndex = 13;
            this.label2.Text = "Date :";
            // 
            // btnStockOut
            // 
            this.btnStockOut.BackColor = System.Drawing.Color.PaleGreen;
            this.btnStockOut.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnStockOut.FlatAppearance.CheckedBackColor = System.Drawing.Color.Gainsboro;
            this.btnStockOut.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.btnStockOut.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.btnStockOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStockOut.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStockOut.Image = global::StockManagement.Properties.Resources.appbar_stock;
            this.btnStockOut.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStockOut.Location = new System.Drawing.Point(665, 27);
            this.btnStockOut.Name = "btnStockOut";
            this.btnStockOut.Size = new System.Drawing.Size(142, 47);
            this.btnStockOut.TabIndex = 3;
            this.btnStockOut.Text = "Stock Out";
            this.btnStockOut.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStockOut.UseVisualStyleBackColor = false;
            this.btnStockOut.Click += new System.EventHandler(this.btnStockOut_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(496, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tag :";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(226, 13);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(111, 21);
            this.label27.TabIndex = 3;
            this.label27.Text = "Product Code :";
            // 
            // cmbTagNo
            // 
            this.cmbTagNo.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cmbTagNo.FormattingEnabled = true;
            this.cmbTagNo.Location = new System.Drawing.Point(496, 37);
            this.cmbTagNo.Name = "cmbTagNo";
            this.cmbTagNo.Size = new System.Drawing.Size(113, 29);
            this.cmbTagNo.TabIndex = 2;
            this.cmbTagNo.Enter += new System.EventHandler(this.cmbTagNo_Enter);
            this.cmbTagNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbTagNo_KeyPress);
            // 
            // cmbProductDesc
            // 
            this.cmbProductDesc.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cmbProductDesc.FormattingEnabled = true;
            this.cmbProductDesc.Location = new System.Drawing.Point(226, 37);
            this.cmbProductDesc.Name = "cmbProductDesc";
            this.cmbProductDesc.Size = new System.Drawing.Size(166, 29);
            this.cmbProductDesc.TabIndex = 1;
            // 
            // dgStockOut
            // 
            this.dgStockOut.AllowUserToAddRows = false;
            this.dgStockOut.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgStockOut.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgStockOut.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgStockOut.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Photo,
            this.Product,
            this.TagNo,
            this.MetailDetail,
            this.DiamondDetail,
            this.StoneDetail,
            this.TID,
            this.Delete});
            this.dgStockOut.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgStockOut.Location = new System.Drawing.Point(0, 0);
            this.dgStockOut.Name = "dgStockOut";
            this.dgStockOut.ReadOnly = true;
            this.dgStockOut.Size = new System.Drawing.Size(999, 360);
            this.dgStockOut.TabIndex = 0;
            this.dgStockOut.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgStockOut_CellContentClick);
            // 
            // Photo
            // 
            this.Photo.HeaderText = "Photo";
            this.Photo.Name = "Photo";
            this.Photo.ReadOnly = true;
            // 
            // Product
            // 
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Product.DefaultCellStyle = dataGridViewCellStyle2;
            this.Product.HeaderText = "Product";
            this.Product.Name = "Product";
            this.Product.ReadOnly = true;
            // 
            // TagNo
            // 
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.TagNo.DefaultCellStyle = dataGridViewCellStyle3;
            this.TagNo.HeaderText = "TagNo";
            this.TagNo.Name = "TagNo";
            this.TagNo.ReadOnly = true;
            this.TagNo.Width = 50;
            // 
            // MetailDetail
            // 
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.MetailDetail.DefaultCellStyle = dataGridViewCellStyle4;
            this.MetailDetail.HeaderText = "Metail Detail";
            this.MetailDetail.Name = "MetailDetail";
            this.MetailDetail.ReadOnly = true;
            this.MetailDetail.Width = 260;
            // 
            // DiamondDetail
            // 
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DiamondDetail.DefaultCellStyle = dataGridViewCellStyle5;
            this.DiamondDetail.HeaderText = "Diamond Detail";
            this.DiamondDetail.Name = "DiamondDetail";
            this.DiamondDetail.ReadOnly = true;
            this.DiamondDetail.Width = 150;
            // 
            // StoneDetail
            // 
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.StoneDetail.DefaultCellStyle = dataGridViewCellStyle6;
            this.StoneDetail.HeaderText = "Stone Detail";
            this.StoneDetail.Name = "StoneDetail";
            this.StoneDetail.ReadOnly = true;
            this.StoneDetail.Width = 200;
            // 
            // TID
            // 
            this.TID.HeaderText = "TID";
            this.TID.Name = "TID";
            this.TID.ReadOnly = true;
            this.TID.Visible = false;
            // 
            // Delete
            // 
            this.Delete.HeaderText = "X";
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            this.Delete.Width = 40;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DarkTurquoise;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnSave.FlatAppearance.CheckedBackColor = System.Drawing.Color.Gainsboro;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(20, 444);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(121, 75);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnModify
            // 
            this.btnModify.BackColor = System.Drawing.Color.SteelBlue;
            this.btnModify.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnModify.FlatAppearance.CheckedBackColor = System.Drawing.Color.Gainsboro;
            this.btnModify.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.btnModify.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.btnModify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModify.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModify.Location = new System.Drawing.Point(168, 444);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(121, 75);
            this.btnModify.TabIndex = 2;
            this.btnModify.Text = "Modify";
            this.btnModify.UseVisualStyleBackColor = false;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtStoneWt);
            this.groupBox2.Controls.Add(this.txtDiamondWt);
            this.groupBox2.Controls.Add(this.txtNetWt);
            this.groupBox2.Controls.Add(this.txtTotalPcs);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.groupBox2.Location = new System.Drawing.Point(0, 360);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(999, 54);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Summary";
            // 
            // txtStoneWt
            // 
            this.txtStoneWt.BackColor = System.Drawing.Color.FloralWhite;
            this.txtStoneWt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStoneWt.Location = new System.Drawing.Point(704, 17);
            this.txtStoneWt.Name = "txtStoneWt";
            this.txtStoneWt.ReadOnly = true;
            this.txtStoneWt.Size = new System.Drawing.Size(199, 29);
            this.txtStoneWt.TabIndex = 3;
            this.txtStoneWt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtDiamondWt
            // 
            this.txtDiamondWt.BackColor = System.Drawing.Color.FloralWhite;
            this.txtDiamondWt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDiamondWt.Location = new System.Drawing.Point(558, 17);
            this.txtDiamondWt.Name = "txtDiamondWt";
            this.txtDiamondWt.ReadOnly = true;
            this.txtDiamondWt.Size = new System.Drawing.Size(140, 29);
            this.txtDiamondWt.TabIndex = 2;
            this.txtDiamondWt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtNetWt
            // 
            this.txtNetWt.BackColor = System.Drawing.Color.FloralWhite;
            this.txtNetWt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNetWt.Location = new System.Drawing.Point(295, 17);
            this.txtNetWt.Name = "txtNetWt";
            this.txtNetWt.ReadOnly = true;
            this.txtNetWt.Size = new System.Drawing.Size(257, 29);
            this.txtNetWt.TabIndex = 1;
            this.txtNetWt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotalPcs
            // 
            this.txtTotalPcs.BackColor = System.Drawing.Color.FloralWhite;
            this.txtTotalPcs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalPcs.Location = new System.Drawing.Point(245, 17);
            this.txtTotalPcs.Name = "txtTotalPcs";
            this.txtTotalPcs.ReadOnly = true;
            this.txtTotalPcs.Size = new System.Drawing.Size(44, 29);
            this.txtTotalPcs.TabIndex = 0;
            this.txtTotalPcs.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(174, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 21);
            this.label3.TabIndex = 13;
            this.label3.Text = "Total :";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.RosyBrown;
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1073, 39);
            this.panel1.TabIndex = 29;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.MintCream;
            this.btnClose.BackgroundImage = global::StockManagement.Properties.Resources.appbar_close;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(1038, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(35, 39);
            this.btnClose.TabIndex = 4;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Gold;
            this.label5.Location = new System.Drawing.Point(490, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(237, 40);
            this.label5.TabIndex = 0;
            this.label5.Text = "Stock OUT Entry";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.dgStockOut);
            this.panel2.Controls.Add(this.btnModify);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Location = new System.Drawing.Point(30, 140);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(999, 540);
            this.panel2.TabIndex = 14;
            // 
            // StockOUT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.ClientSize = new System.Drawing.Size(1073, 671);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StockOUT";
            this.Text = "StockOUT";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgStockOut)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbProductDesc;
        private System.Windows.Forms.DataGridView dgStockOut;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.ComboBox cmbTagNo;
        private System.Windows.Forms.Button btnStockOut;
        private System.Windows.Forms.DateTimePicker dtDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtStoneWt;
        private System.Windows.Forms.TextBox txtDiamondWt;
        private System.Windows.Forms.TextBox txtNetWt;
        private System.Windows.Forms.TextBox txtTotalPcs;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewImageColumn Photo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product;
        private System.Windows.Forms.DataGridViewTextBoxColumn TagNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn MetailDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiamondDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn StoneDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn TID;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel2;
    }
}