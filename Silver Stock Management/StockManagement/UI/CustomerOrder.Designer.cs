namespace StockManagement.UI
{
    partial class CustomerOrder
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
            this.ofdLoadPhoto = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabSingle = new System.Windows.Forms.TabPage();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtOrderNo = new System.Windows.Forms.TextBox();
            this.txtMetalRate = new System.Windows.Forms.TextBox();
            this.dtDeliveryDate = new System.Windows.Forms.DateTimePicker();
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.cmbMetal = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.txtTotalGsWt = new System.Windows.Forms.TextBox();
            this.dgvOrder = new System.Windows.Forms.DataGridView();
            this.pbSPAdd = new System.Windows.Forms.PictureBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.cmbProductCode = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.txtNetWt = new System.Windows.Forms.TextBox();
            this.txtTotalWeight = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabSingle.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSPAdd)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // ofdLoadPhoto
            // 
            this.ofdLoadPhoto.Filter = "Supported Image Files |*.jpeg;*.jpg;*.png;*.bmp";
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabSingle);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1306, 780);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.Tag = "Composite";
            // 
            // tabSingle
            // 
            this.tabSingle.BackColor = System.Drawing.Color.Cornsilk;
            this.tabSingle.Controls.Add(this.txtEmail);
            this.tabSingle.Controls.Add(this.txtMobile);
            this.tabSingle.Controls.Add(this.txtAddress);
            this.tabSingle.Controls.Add(this.label17);
            this.tabSingle.Controls.Add(this.label1);
            this.tabSingle.Controls.Add(this.cmbCustomer);
            this.tabSingle.Controls.Add(this.panel1);
            this.tabSingle.Controls.Add(this.txtOrderNo);
            this.tabSingle.Controls.Add(this.txtMetalRate);
            this.tabSingle.Controls.Add(this.dtDeliveryDate);
            this.tabSingle.Controls.Add(this.dtDate);
            this.tabSingle.Controls.Add(this.btnReset);
            this.tabSingle.Controls.Add(this.btnModify);
            this.tabSingle.Controls.Add(this.btnDelete);
            this.tabSingle.Controls.Add(this.btnSave);
            this.tabSingle.Controls.Add(this.cmbMetal);
            this.tabSingle.Controls.Add(this.label20);
            this.tabSingle.Controls.Add(this.label2);
            this.tabSingle.Controls.Add(this.label6);
            this.tabSingle.Controls.Add(this.label27);
            this.tabSingle.Controls.Add(this.panel3);
            this.tabSingle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabSingle.Location = new System.Drawing.Point(4, 25);
            this.tabSingle.Name = "tabSingle";
            this.tabSingle.Padding = new System.Windows.Forms.Padding(3);
            this.tabSingle.Size = new System.Drawing.Size(1298, 751);
            this.tabSingle.TabIndex = 1;
            this.tabSingle.Text = "Single";
            // 
            // txtEmail
            // 
            this.txtEmail.ForeColor = System.Drawing.Color.Silver;
            this.txtEmail.Location = new System.Drawing.Point(13, 174);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(273, 29);
            this.txtEmail.TabIndex = 43;
            this.txtEmail.Text = "Email";
            // 
            // txtMobile
            // 
            this.txtMobile.ForeColor = System.Drawing.Color.Silver;
            this.txtMobile.Location = new System.Drawing.Point(13, 208);
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(273, 29);
            this.txtMobile.TabIndex = 42;
            this.txtMobile.Text = "Mobile";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(13, 107);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAddress.Size = new System.Drawing.Size(273, 61);
            this.txtAddress.TabIndex = 41;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(524, 62);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(83, 21);
            this.label17.TabIndex = 40;
            this.label17.Text = "Order No :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 21);
            this.label1.TabIndex = 35;
            this.label1.Text = "Customer Details :";
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCustomer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCustomer.BackColor = System.Drawing.Color.Gainsboro;
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Location = new System.Drawing.Point(13, 74);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(273, 29);
            this.cmbCustomer.TabIndex = 0;
            this.cmbCustomer.SelectedIndexChanged += new System.EventHandler(this.cmbCustomer_SelectedIndexChanged);
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
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Gold;
            this.label5.Location = new System.Drawing.Point(490, -1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(275, 40);
            this.label5.TabIndex = 0;
            this.label5.Text = "CUSTOMER ORDER";
            // 
            // txtOrderNo
            // 
            this.txtOrderNo.BackColor = System.Drawing.Color.Gainsboro;
            this.txtOrderNo.Location = new System.Drawing.Point(528, 89);
            this.txtOrderNo.Name = "txtOrderNo";
            this.txtOrderNo.Size = new System.Drawing.Size(115, 29);
            this.txtOrderNo.TabIndex = 3;
            this.txtOrderNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtMetalRate
            // 
            this.txtMetalRate.BackColor = System.Drawing.Color.Gainsboro;
            this.txtMetalRate.Location = new System.Drawing.Point(528, 221);
            this.txtMetalRate.Name = "txtMetalRate";
            this.txtMetalRate.Size = new System.Drawing.Size(115, 29);
            this.txtMetalRate.TabIndex = 5;
            this.txtMetalRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dtDeliveryDate
            // 
            this.dtDeliveryDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDeliveryDate.Location = new System.Drawing.Point(339, 158);
            this.dtDeliveryDate.Name = "dtDeliveryDate";
            this.dtDeliveryDate.Size = new System.Drawing.Size(128, 29);
            this.dtDeliveryDate.TabIndex = 2;
            this.dtDeliveryDate.Value = new System.DateTime(2017, 9, 23, 0, 0, 0, 0);
            // 
            // dtDate
            // 
            this.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDate.Location = new System.Drawing.Point(339, 89);
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
            this.btnReset.Location = new System.Drawing.Point(403, 676);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(121, 75);
            this.btnReset.TabIndex = 9;
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
            this.btnModify.Location = new System.Drawing.Point(274, 676);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(121, 75);
            this.btnModify.TabIndex = 8;
            this.btnModify.Text = "Modify";
            this.btnModify.UseVisualStyleBackColor = false;
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
            this.btnDelete.Location = new System.Drawing.Point(16, 676);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(121, 75);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Visible = false;
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
            this.btnSave.Location = new System.Drawing.Point(145, 676);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(121, 75);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // cmbMetal
            // 
            this.cmbMetal.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbMetal.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbMetal.BackColor = System.Drawing.Color.Gainsboro;
            this.cmbMetal.FormattingEnabled = true;
            this.cmbMetal.Location = new System.Drawing.Point(524, 151);
            this.cmbMetal.Name = "cmbMetal";
            this.cmbMetal.Size = new System.Drawing.Size(131, 29);
            this.cmbMetal.TabIndex = 4;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(339, 134);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(110, 21);
            this.label20.TabIndex = 0;
            this.label20.Text = "Delivery Date :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(524, 197);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Metal Rate:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(522, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 21);
            this.label6.TabIndex = 1;
            this.label6.Text = "Metal :";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(339, 65);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(94, 21);
            this.label27.TabIndex = 0;
            this.label27.Text = "Order Date :";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.panel3.Controls.Add(this.label15);
            this.panel3.Controls.Add(this.txtTotalGsWt);
            this.panel3.Controls.Add(this.dgvOrder);
            this.panel3.Controls.Add(this.pbSPAdd);
            this.panel3.Controls.Add(this.groupBox4);
            this.panel3.Controls.Add(this.cmbProductCode);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.txtQty);
            this.panel3.Controls.Add(this.txtNetWt);
            this.panel3.Controls.Add(this.txtTotalWeight);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Location = new System.Drawing.Point(16, 256);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1276, 402);
            this.panel3.TabIndex = 6;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(480, 266);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(159, 21);
            this.label15.TabIndex = 0;
            this.label15.Text = "Approx Total Weight :";
            // 
            // txtTotalGsWt
            // 
            this.txtTotalGsWt.Location = new System.Drawing.Point(484, 290);
            this.txtTotalGsWt.Name = "txtTotalGsWt";
            this.txtTotalGsWt.ReadOnly = true;
            this.txtTotalGsWt.Size = new System.Drawing.Size(155, 29);
            this.txtTotalGsWt.TabIndex = 1;
            // 
            // dgvOrder
            // 
            this.dgvOrder.AllowUserToAddRows = false;
            this.dgvOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrder.Location = new System.Drawing.Point(9, 70);
            this.dgvOrder.Name = "dgvOrder";
            this.dgvOrder.ReadOnly = true;
            this.dgvOrder.RowTemplate.Height = 26;
            this.dgvOrder.Size = new System.Drawing.Size(844, 177);
            this.dgvOrder.TabIndex = 3;
            // 
            // pbSPAdd
            // 
            this.pbSPAdd.Image = global::StockManagement.Properties.Resources.add_icon;
            this.pbSPAdd.Location = new System.Drawing.Point(617, 35);
            this.pbSPAdd.Name = "pbSPAdd";
            this.pbSPAdd.Size = new System.Drawing.Size(31, 29);
            this.pbSPAdd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSPAdd.TabIndex = 31;
            this.pbSPAdd.TabStop = false;
            this.pbSPAdd.Click += new System.EventHandler(this.pbSPAdd_Click_1);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtRemark);
            this.groupBox4.Location = new System.Drawing.Point(3, 253);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(453, 133);
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
            this.txtRemark.Size = new System.Drawing.Size(447, 105);
            this.txtRemark.TabIndex = 0;
            // 
            // cmbProductCode
            // 
            this.cmbProductCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbProductCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbProductCode.BackColor = System.Drawing.Color.Gainsboro;
            this.cmbProductCode.FormattingEnabled = true;
            this.cmbProductCode.Location = new System.Drawing.Point(8, 35);
            this.cmbProductCode.Name = "cmbProductCode";
            this.cmbProductCode.Size = new System.Drawing.Size(219, 29);
            this.cmbProductCode.TabIndex = 0;
            this.cmbProductCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbProductCode_KeyDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(255, 11);
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
            this.label4.Location = new System.Drawing.Point(8, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 21);
            this.label4.TabIndex = 1;
            this.label4.Text = "Item Code :";
            // 
            // txtQty
            // 
            this.txtQty.BackColor = System.Drawing.Color.Gainsboro;
            this.txtQty.Location = new System.Drawing.Point(259, 35);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(51, 29);
            this.txtQty.TabIndex = 1;
            this.txtQty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPCs_KeyDown);
            // 
            // txtNetWt
            // 
            this.txtNetWt.BackColor = System.Drawing.Color.Gainsboro;
            this.txtNetWt.Location = new System.Drawing.Point(342, 35);
            this.txtNetWt.Name = "txtNetWt";
            this.txtNetWt.Size = new System.Drawing.Size(115, 29);
            this.txtNetWt.TabIndex = 2;
            this.txtNetWt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNetWt.TextChanged += new System.EventHandler(this.txtNetWt_TextChanged_1);
            this.txtNetWt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNetWt_KeyPress);
            // 
            // txtTotalWeight
            // 
            this.txtTotalWeight.BackColor = System.Drawing.Color.Gainsboro;
            this.txtTotalWeight.Location = new System.Drawing.Point(489, 35);
            this.txtTotalWeight.Name = "txtTotalWeight";
            this.txtTotalWeight.Size = new System.Drawing.Size(96, 29);
            this.txtTotalWeight.TabIndex = 3;
            this.txtTotalWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(490, 11);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(105, 21);
            this.label10.TabIndex = 1;
            this.label10.Text = "Approx Total :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(342, 11);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(115, 21);
            this.label12.TabIndex = 1;
            this.label12.Text = "Appox Weight :";
            // 
            // CustomerOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1306, 780);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CustomerOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "StockIN";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tabControl1.ResumeLayout(false);
            this.tabSingle.ResumeLayout(false);
            this.tabSingle.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSPAdd)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog ofdLoadPhoto;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabSingle;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtMobile;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtTotalGsWt;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCustomer;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtDeliveryDate;
        private System.Windows.Forms.DateTimePicker dtDate;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cmbMetal;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvOrder;
        private System.Windows.Forms.PictureBox pbSPAdd;
        private System.Windows.Forms.ComboBox cmbProductCode;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.TextBox txtNetWt;
        private System.Windows.Forms.TextBox txtTotalWeight;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOrderNo;
        private System.Windows.Forms.TextBox txtMetalRate;
    }
}