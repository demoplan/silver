﻿namespace StockManagement.UI
{
    partial class Issue
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Issue));
            this.ofdLoadPhoto = new System.Windows.Forms.OpenFileDialog();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.myColumnComboBox = new StockManagement.UC.ColumnComboBox();
            this.txtVoucherNo = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSGSTRate = new System.Windows.Forms.TextBox();
            this.txtCGSTRate = new System.Windows.Forms.TextBox();
            this.txtSGST = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNetTotal = new System.Windows.Forms.TextBox();
            this.txtCGST = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtTotalGsWt = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtTotalMakingRate = new System.Windows.Forms.TextBox();
            this.txtTotalNetWt = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.cmbCustType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.cmbMetal = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBarCode = new System.Windows.Forms.TextBox();
            this.pbRefresh = new System.Windows.Forms.PictureBox();
            this.dgvSP = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.pbSPAdd = new System.Windows.Forms.PictureBox();
            this.cmbProductCode = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPCs = new System.Windows.Forms.TextBox();
            this.txtNetWt = new System.Windows.Forms.TextBox();
            this.txtTotalRate = new System.Windows.Forms.TextBox();
            this.txtMakingRate = new System.Windows.Forms.TextBox();
            this.txtGsWt = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.mainPanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSPAdd)).BeginInit();
            this.SuspendLayout();
            // 
            // ofdLoadPhoto
            // 
            this.ofdLoadPhoto.Filter = "Supported Image Files |*.jpeg;*.jpg;*.png;*.bmp";
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.Cornsilk;
            this.mainPanel.Controls.Add(this.myColumnComboBox);
            this.mainPanel.Controls.Add(this.txtVoucherNo);
            this.mainPanel.Controls.Add(this.label17);
            this.mainPanel.Controls.Add(this.groupBox1);
            this.mainPanel.Controls.Add(this.cmbCustType);
            this.mainPanel.Controls.Add(this.label1);
            this.mainPanel.Controls.Add(this.cmbCustomer);
            this.mainPanel.Controls.Add(this.label14);
            this.mainPanel.Controls.Add(this.groupBox4);
            this.mainPanel.Controls.Add(this.panel1);
            this.mainPanel.Controls.Add(this.dtDate);
            this.mainPanel.Controls.Add(this.btnReset);
            this.mainPanel.Controls.Add(this.btnModify);
            this.mainPanel.Controls.Add(this.btnDelete);
            this.mainPanel.Controls.Add(this.btnSave);
            this.mainPanel.Controls.Add(this.cmbMetal);
            this.mainPanel.Controls.Add(this.label6);
            this.mainPanel.Controls.Add(this.label27);
            this.mainPanel.Controls.Add(this.panel3);
            this.mainPanel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainPanel.Location = new System.Drawing.Point(4, 25);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Padding = new System.Windows.Forms.Padding(3);
            this.mainPanel.Size = new System.Drawing.Size(1298, 678);
            this.mainPanel.TabIndex = 0;
            this.mainPanel.Text = "Single";
            // 
            // myColumnComboBox
            // 
            this.myColumnComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.myColumnComboBox.DropDownWidth = 17;
            this.myColumnComboBox.FormattingEnabled = true;
            this.myColumnComboBox.Location = new System.Drawing.Point(839, 68);
            this.myColumnComboBox.Name = "myColumnComboBox";
            this.myColumnComboBox.Size = new System.Drawing.Size(121, 30);
            this.myColumnComboBox.TabIndex = 41;
            this.myColumnComboBox.ViewColumn = 0;
            // 
            // txtVoucherNo
            // 
            this.txtVoucherNo.BackColor = System.Drawing.Color.Gainsboro;
            this.txtVoucherNo.Location = new System.Drawing.Point(625, 72);
            this.txtVoucherNo.Name = "txtVoucherNo";
            this.txtVoucherNo.ReadOnly = true;
            this.txtVoucherNo.Size = new System.Drawing.Size(131, 29);
            this.txtVoucherNo.TabIndex = 33;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(625, 45);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(99, 21);
            this.label17.TabIndex = 40;
            this.label17.Text = "Voucher No :";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.groupBox1.Controls.Add(this.txtSGSTRate);
            this.groupBox1.Controls.Add(this.txtCGSTRate);
            this.groupBox1.Controls.Add(this.txtSGST);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtNetTotal);
            this.groupBox1.Controls.Add(this.txtCGST);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.txtTotalGsWt);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.txtTotalMakingRate);
            this.groupBox1.Controls.Add(this.txtTotalNetWt);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Location = new System.Drawing.Point(8, 464);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(916, 121);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Summary";
            // 
            // txtSGSTRate
            // 
            this.txtSGSTRate.Location = new System.Drawing.Point(567, 16);
            this.txtSGSTRate.Name = "txtSGSTRate";
            this.txtSGSTRate.ReadOnly = true;
            this.txtSGSTRate.Size = new System.Drawing.Size(61, 29);
            this.txtSGSTRate.TabIndex = 11;
            this.txtSGSTRate.Text = "2.5";
            this.txtSGSTRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtCGSTRate
            // 
            this.txtCGSTRate.Location = new System.Drawing.Point(567, 49);
            this.txtCGSTRate.Name = "txtCGSTRate";
            this.txtCGSTRate.ReadOnly = true;
            this.txtCGSTRate.Size = new System.Drawing.Size(61, 29);
            this.txtCGSTRate.TabIndex = 12;
            this.txtCGSTRate.Text = "2.5";
            this.txtCGSTRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtSGST
            // 
            this.txtSGST.Location = new System.Drawing.Point(643, 15);
            this.txtSGST.Name = "txtSGST";
            this.txtSGST.ReadOnly = true;
            this.txtSGST.Size = new System.Drawing.Size(105, 29);
            this.txtSGST.TabIndex = 8;
            this.txtSGST.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(498, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 21);
            this.label2.TabIndex = 5;
            this.label2.Text = "SGST :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(498, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 21);
            this.label3.TabIndex = 6;
            this.label3.Text = "CGST :";
            // 
            // txtNetTotal
            // 
            this.txtNetTotal.Location = new System.Drawing.Point(643, 82);
            this.txtNetTotal.Name = "txtNetTotal";
            this.txtNetTotal.ReadOnly = true;
            this.txtNetTotal.Size = new System.Drawing.Size(107, 29);
            this.txtNetTotal.TabIndex = 10;
            this.txtNetTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtCGST
            // 
            this.txtCGST.Location = new System.Drawing.Point(643, 48);
            this.txtCGST.Name = "txtCGST";
            this.txtCGST.ReadOnly = true;
            this.txtCGST.Size = new System.Drawing.Size(105, 29);
            this.txtCGST.TabIndex = 9;
            this.txtCGST.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(498, 85);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(78, 21);
            this.label20.TabIndex = 7;
            this.label20.Text = "Net Total :";
            // 
            // txtTotalGsWt
            // 
            this.txtTotalGsWt.Location = new System.Drawing.Point(354, 15);
            this.txtTotalGsWt.Name = "txtTotalGsWt";
            this.txtTotalGsWt.ReadOnly = true;
            this.txtTotalGsWt.Size = new System.Drawing.Size(105, 29);
            this.txtTotalGsWt.TabIndex = 1;
            this.txtTotalGsWt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(209, 18);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(110, 21);
            this.label15.TabIndex = 0;
            this.label15.Text = "Gross Weight :";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(209, 51);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(95, 21);
            this.label18.TabIndex = 0;
            this.label18.Text = "Net Weight :";
            // 
            // txtTotalMakingRate
            // 
            this.txtTotalMakingRate.Location = new System.Drawing.Point(354, 82);
            this.txtTotalMakingRate.Name = "txtTotalMakingRate";
            this.txtTotalMakingRate.ReadOnly = true;
            this.txtTotalMakingRate.Size = new System.Drawing.Size(107, 29);
            this.txtTotalMakingRate.TabIndex = 4;
            this.txtTotalMakingRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotalMakingRate.TextChanged += new System.EventHandler(this.txtTotalMakingRate_TextChanged);
            // 
            // txtTotalNetWt
            // 
            this.txtTotalNetWt.Location = new System.Drawing.Point(354, 48);
            this.txtTotalNetWt.Name = "txtTotalNetWt";
            this.txtTotalNetWt.ReadOnly = true;
            this.txtTotalNetWt.Size = new System.Drawing.Size(105, 29);
            this.txtTotalNetWt.TabIndex = 2;
            this.txtTotalNetWt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(209, 85);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(105, 21);
            this.label19.TabIndex = 0;
            this.label19.Text = "Making Total :";
            // 
            // cmbCustType
            // 
            this.cmbCustType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCustType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCustType.BackColor = System.Drawing.Color.Gainsboro;
            this.cmbCustType.FormattingEnabled = true;
            this.cmbCustType.Location = new System.Drawing.Point(325, 72);
            this.cmbCustType.Name = "cmbCustType";
            this.cmbCustType.Size = new System.Drawing.Size(131, 29);
            this.cmbCustType.TabIndex = 3;
            this.cmbCustType.SelectedIndexChanged += new System.EventHandler(this.cmbCustType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(475, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 21);
            this.label1.TabIndex = 35;
            this.label1.Text = "Ledger Code :";
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCustomer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCustomer.BackColor = System.Drawing.Color.Gainsboro;
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Location = new System.Drawing.Point(479, 72);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(131, 29);
            this.cmbCustomer.TabIndex = 3;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(321, 45);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(109, 21);
            this.label14.TabIndex = 35;
            this.label14.Text = "Receipt From :";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtRemark);
            this.groupBox4.Location = new System.Drawing.Point(930, 455);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(313, 133);
            this.groupBox4.TabIndex = 29;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Remark";
            // 
            // txtRemark
            // 
            this.txtRemark.BackColor = System.Drawing.Color.Gainsboro;
            this.txtRemark.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRemark.Location = new System.Drawing.Point(3, 25);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(307, 105);
            this.txtRemark.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.RosyBrown;
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1292, 39);
            this.panel1.TabIndex = 28;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.MintCream;
            this.btnClose.BackgroundImage = global::StockManagement.Properties.Resources.appbar_close;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(1257, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(35, 39);
            this.btnClose.TabIndex = 30;
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
            this.label5.Size = new System.Drawing.Size(94, 40);
            this.label5.TabIndex = 0;
            this.label5.Text = "ISSUE";
            // 
            // dtDate
            // 
            this.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDate.Location = new System.Drawing.Point(8, 69);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(128, 29);
            this.dtDate.TabIndex = 1;
            this.dtDate.Value = new System.DateTime(2017, 9, 23, 0, 0, 0, 0);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnReset.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnReset.FlatAppearance.CheckedBackColor = System.Drawing.Color.Gainsboro;
            this.btnReset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.btnReset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(412, 594);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(121, 75);
            this.btnReset.TabIndex = 11;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            // 
            // btnModify
            // 
            this.btnModify.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnModify.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnModify.FlatAppearance.CheckedBackColor = System.Drawing.Color.Gainsboro;
            this.btnModify.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.btnModify.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.btnModify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModify.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModify.Location = new System.Drawing.Point(283, 594);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(121, 75);
            this.btnModify.TabIndex = 10;
            this.btnModify.Text = "Modify";
            this.btnModify.UseVisualStyleBackColor = false;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.btnDelete.BackColor = System.Drawing.Color.Red;
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.btnDelete.FlatAppearance.CheckedBackColor = System.Drawing.Color.Gainsboro;
            this.btnDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Brown;
            this.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(25, 594);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(121, 75);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
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
            this.btnSave.Location = new System.Drawing.Point(154, 594);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(121, 75);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cmbMetal
            // 
            this.cmbMetal.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbMetal.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbMetal.BackColor = System.Drawing.Color.Gainsboro;
            this.cmbMetal.FormattingEnabled = true;
            this.cmbMetal.Location = new System.Drawing.Point(171, 72);
            this.cmbMetal.Name = "cmbMetal";
            this.cmbMetal.Size = new System.Drawing.Size(131, 29);
            this.cmbMetal.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(167, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 21);
            this.label6.TabIndex = 1;
            this.label6.Text = "Metal :";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(8, 45);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(49, 21);
            this.label27.TabIndex = 0;
            this.label27.Text = "Date :";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.txtBarCode);
            this.panel3.Controls.Add(this.pbRefresh);
            this.panel3.Controls.Add(this.dgvSP);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.pbSPAdd);
            this.panel3.Controls.Add(this.cmbProductCode);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.txtPCs);
            this.panel3.Controls.Add(this.txtNetWt);
            this.panel3.Controls.Add(this.txtTotalRate);
            this.panel3.Controls.Add(this.txtMakingRate);
            this.panel3.Controls.Add(this.txtGsWt);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Location = new System.Drawing.Point(8, 107);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1276, 342);
            this.panel3.TabIndex = 34;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(12, 41);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 21);
            this.label9.TabIndex = 34;
            this.label9.Text = "BarCode:";
            // 
            // txtBarCode
            // 
            this.txtBarCode.BackColor = System.Drawing.Color.Gainsboro;
            this.txtBarCode.Location = new System.Drawing.Point(14, 65);
            this.txtBarCode.Name = "txtBarCode";
            this.txtBarCode.Size = new System.Drawing.Size(251, 29);
            this.txtBarCode.TabIndex = 35;
            this.txtBarCode.TextChanged += new System.EventHandler(this.txtBarCode_TextChanged);
            this.txtBarCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBarCode_KeyPress);
            // 
            // pbRefresh
            // 
            this.pbRefresh.Image = global::StockManagement.Properties.Resources.appbar_checkmark_cross;
            this.pbRefresh.Location = new System.Drawing.Point(1223, 65);
            this.pbRefresh.Name = "pbRefresh";
            this.pbRefresh.Size = new System.Drawing.Size(31, 29);
            this.pbRefresh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbRefresh.TabIndex = 33;
            this.pbRefresh.TabStop = false;
            this.pbRefresh.Click += new System.EventHandler(this.pbRefresh_Click);
            // 
            // dgvSP
            // 
            this.dgvSP.AllowUserToAddRows = false;
            this.dgvSP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSP.Location = new System.Drawing.Point(12, 100);
            this.dgvSP.Name = "dgvSP";
            this.dgvSP.ReadOnly = true;
            this.dgvSP.RowTemplate.Height = 50;
            this.dgvSP.Size = new System.Drawing.Size(1223, 239);
            this.dgvSP.TabIndex = 32;
            this.dgvSP.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSP_CellClick);
            this.dgvSP.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvSP_RowsAdded);
            this.dgvSP.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvSP_RowsRemoved);
            this.dgvSP.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvSP_UserDeletingRow);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label7.Location = new System.Drawing.Point(13, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(203, 40);
            this.label7.TabIndex = 0;
            this.label7.Text = "Stock Product";
            // 
            // pbSPAdd
            // 
            this.pbSPAdd.Image = global::StockManagement.Properties.Resources.add_icon;
            this.pbSPAdd.Location = new System.Drawing.Point(1186, 65);
            this.pbSPAdd.Name = "pbSPAdd";
            this.pbSPAdd.Size = new System.Drawing.Size(31, 29);
            this.pbSPAdd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSPAdd.TabIndex = 31;
            this.pbSPAdd.TabStop = false;
            this.pbSPAdd.Click += new System.EventHandler(this.pbSPAdd_Click);
            // 
            // cmbProductCode
            // 
            this.cmbProductCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbProductCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbProductCode.BackColor = System.Drawing.Color.Gainsboro;
            this.cmbProductCode.FormattingEnabled = true;
            this.cmbProductCode.Location = new System.Drawing.Point(271, 65);
            this.cmbProductCode.Name = "cmbProductCode";
            this.cmbProductCode.Size = new System.Drawing.Size(131, 29);
            this.cmbProductCode.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(406, 41);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 21);
            this.label8.TabIndex = 1;
            this.label8.Text = "Qty :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(271, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 21);
            this.label4.TabIndex = 1;
            this.label4.Text = "Item Code :";
            // 
            // txtPCs
            // 
            this.txtPCs.BackColor = System.Drawing.Color.Gainsboro;
            this.txtPCs.Location = new System.Drawing.Point(408, 65);
            this.txtPCs.Name = "txtPCs";
            this.txtPCs.Size = new System.Drawing.Size(51, 29);
            this.txtPCs.TabIndex = 12;
            this.txtPCs.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPCs_KeyPress);
            // 
            // txtNetWt
            // 
            this.txtNetWt.BackColor = System.Drawing.Color.Gainsboro;
            this.txtNetWt.Location = new System.Drawing.Point(584, 65);
            this.txtNetWt.Name = "txtNetWt";
            this.txtNetWt.Size = new System.Drawing.Size(96, 29);
            this.txtNetWt.TabIndex = 14;
            this.txtNetWt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNetWt.TextChanged += new System.EventHandler(this.txtNetWt_TextChanged);
            this.txtNetWt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNetWt_KeyPress);
            // 
            // txtTotalRate
            // 
            this.txtTotalRate.BackColor = System.Drawing.Color.Gainsboro;
            this.txtTotalRate.Location = new System.Drawing.Point(790, 65);
            this.txtTotalRate.Name = "txtTotalRate";
            this.txtTotalRate.ReadOnly = true;
            this.txtTotalRate.Size = new System.Drawing.Size(96, 29);
            this.txtTotalRate.TabIndex = 16;
            this.txtTotalRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtMakingRate
            // 
            this.txtMakingRate.BackColor = System.Drawing.Color.Gainsboro;
            this.txtMakingRate.Location = new System.Drawing.Point(686, 65);
            this.txtMakingRate.Name = "txtMakingRate";
            this.txtMakingRate.Size = new System.Drawing.Size(96, 29);
            this.txtMakingRate.TabIndex = 15;
            this.txtMakingRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMakingRate.TextChanged += new System.EventHandler(this.txtMakingRate_TextChanged);
            this.txtMakingRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMakingRate_KeyPress);
            // 
            // txtGsWt
            // 
            this.txtGsWt.BackColor = System.Drawing.Color.Gainsboro;
            this.txtGsWt.Location = new System.Drawing.Point(471, 65);
            this.txtGsWt.Name = "txtGsWt";
            this.txtGsWt.Size = new System.Drawing.Size(107, 29);
            this.txtGsWt.TabIndex = 13;
            this.txtGsWt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtGsWt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGsWt_KeyPress);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(792, 41);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(80, 21);
            this.label13.TabIndex = 1;
            this.label13.Text = "Total Rate:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(467, 41);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(110, 21);
            this.label11.TabIndex = 1;
            this.label11.Text = "Gross Weight :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(686, 41);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 21);
            this.label10.TabIndex = 1;
            this.label10.Text = "Making Rate:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(584, 41);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(95, 21);
            this.label12.TabIndex = 1;
            this.label12.Text = "Net Weight :";
            // 
            // Issue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1306, 707);
            this.Controls.Add(this.mainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Issue";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "StockIN";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbRefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSPAdd)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog ofdLoadPhoto;
        private System.Windows.Forms.Panel mainPanel;        
        private System.Windows.Forms.DataGridView dgvSP;
        private System.Windows.Forms.PictureBox pbSPAdd;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtDate;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtMakingRate;
        private System.Windows.Forms.TextBox txtNetWt;
        private System.Windows.Forms.TextBox txtGsWt;
        private System.Windows.Forms.TextBox txtPCs;
        private System.Windows.Forms.ComboBox cmbProductCode;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label27;        
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox cmbCustomer;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtTotalMakingRate;
        private System.Windows.Forms.TextBox txtTotalNetWt;
        private System.Windows.Forms.TextBox txtTotalGsWt;
        private System.Windows.Forms.ComboBox cmbCustType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTotalRate;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbMetal;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtVoucherNo;
        private System.Windows.Forms.PictureBox pbRefresh;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtBarCode;
        private System.Windows.Forms.TextBox txtSGST;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNetTotal;
        private System.Windows.Forms.TextBox txtCGST;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtSGSTRate;
        private System.Windows.Forms.TextBox txtCGSTRate;
        private UC.ColumnComboBox myColumnComboBox;
    }
}