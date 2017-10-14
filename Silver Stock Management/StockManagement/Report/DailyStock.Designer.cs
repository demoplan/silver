namespace StockManagement.Report
{
    partial class DailyStock
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DailyStock));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnReport = new System.Windows.Forms.Button();
            this.dgReport = new System.Windows.Forms.DataGridView();
            this.pnlMain = new DevComponents.DotNetBar.PanelEx();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pbCancel = new System.Windows.Forms.PictureBox();
            this.pbPrintSelected = new System.Windows.Forms.PictureBox();
            this.rbMetal = new System.Windows.Forms.RadioButton();
            this.rbItem = new System.Windows.Forms.RadioButton();
            this.rbStock = new System.Windows.Forms.RadioButton();
            this.dgItemDetail = new System.Windows.Forms.DataGridView();
            this.INDATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TagNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MetalType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pcs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GW = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NW = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgMetalType = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pbPrint = new System.Windows.Forms.PictureBox();
            this.label28 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.SN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OpeningStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StockIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StockOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClosingStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Matal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgReport)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPrintSelected)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgItemDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMetalType)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPrint)).BeginInit();
            this.SuspendLayout();
            // 
            // dtDate
            // 
            this.dtDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDate.Location = new System.Drawing.Point(21, 23);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(131, 29);
            this.dtDate.TabIndex = 1;
            this.dtDate.Value = new System.DateTime(2014, 8, 23, 0, 0, 0, 0);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.btnReport);
            this.groupBox1.Controls.Add(this.dtDate);
            this.groupBox1.Location = new System.Drawing.Point(19, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(605, 71);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // btnReport
            // 
            this.btnReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(166)))), ((int)(((byte)(154)))));
            this.btnReport.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnReport.FlatAppearance.CheckedBackColor = System.Drawing.Color.Gainsboro;
            this.btnReport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.btnReport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.btnReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReport.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.ForeColor = System.Drawing.Color.White;
            this.btnReport.Location = new System.Drawing.Point(171, 22);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(138, 33);
            this.btnReport.TabIndex = 11;
            this.btnReport.Text = "View Report";
            this.btnReport.UseVisualStyleBackColor = false;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // dgReport
            // 
            this.dgReport.AllowUserToAddRows = false;
            this.dgReport.AllowUserToDeleteRows = false;
            this.dgReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgReport.BackgroundColor = System.Drawing.Color.DarkSeaGreen;
            this.dgReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgReport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SN,
            this.Description,
            this.OpeningStock,
            this.StockIN,
            this.StockOut,
            this.ClosingStock,
            this.Matal});
            this.dgReport.Location = new System.Drawing.Point(19, 127);
            this.dgReport.Name = "dgReport";
            this.dgReport.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgReport.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgReport.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgReport.Size = new System.Drawing.Size(627, 400);
            this.dgReport.TabIndex = 4;
            this.dgReport.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgReport_CellContentDoubleClick);
            // 
            // pnlMain
            // 
            this.pnlMain.CanvasColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlMain.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pnlMain.Controls.Add(this.panel1);
            this.pnlMain.Controls.Add(this.dgItemDetail);
            this.pnlMain.Controls.Add(this.dgMetalType);
            this.pnlMain.Controls.Add(this.dgReport);
            this.pnlMain.Controls.Add(this.panel3);
            this.pnlMain.Controls.Add(this.groupBox1);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(976, 780);
            this.pnlMain.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnlMain.Style.BackColor1.Color = System.Drawing.Color.DarkSeaGreen;
            this.pnlMain.Style.BackColor2.Color = System.Drawing.Color.LightGoldenrodYellow;
            this.pnlMain.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.pnlMain.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pnlMain.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnlMain.Style.GradientAngle = 90;
            this.pnlMain.TabIndex = 32;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel1.Controls.Add(this.pbCancel);
            this.panel1.Controls.Add(this.pbPrintSelected);
            this.panel1.Controls.Add(this.rbMetal);
            this.panel1.Controls.Add(this.rbItem);
            this.panel1.Controls.Add(this.rbStock);
            this.panel1.Location = new System.Drawing.Point(818, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(155, 139);
            this.panel1.TabIndex = 38;
            this.panel1.Visible = false;
            // 
            // pbCancel
            // 
            this.pbCancel.Image = global::StockManagement.Properties.Resources.appbar_close;
            this.pbCancel.Location = new System.Drawing.Point(83, 93);
            this.pbCancel.Name = "pbCancel";
            this.pbCancel.Size = new System.Drawing.Size(47, 42);
            this.pbCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCancel.TabIndex = 1;
            this.pbCancel.TabStop = false;
            this.pbCancel.Click += new System.EventHandler(this.pbCancel_Click);
            // 
            // pbPrintSelected
            // 
            this.pbPrintSelected.Image = global::StockManagement.Properties.Resources.appbar_printer_text;
            this.pbPrintSelected.Location = new System.Drawing.Point(30, 93);
            this.pbPrintSelected.Name = "pbPrintSelected";
            this.pbPrintSelected.Size = new System.Drawing.Size(47, 42);
            this.pbPrintSelected.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPrintSelected.TabIndex = 1;
            this.pbPrintSelected.TabStop = false;
            this.pbPrintSelected.Click += new System.EventHandler(this.pbPrintSelected_Click);
            // 
            // rbMetal
            // 
            this.rbMetal.AutoSize = true;
            this.rbMetal.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbMetal.Location = new System.Drawing.Point(13, 63);
            this.rbMetal.Name = "rbMetal";
            this.rbMetal.Size = new System.Drawing.Size(131, 24);
            this.rbMetal.TabIndex = 0;
            this.rbMetal.TabStop = true;
            this.rbMetal.Text = "Metal Summary";
            this.rbMetal.UseVisualStyleBackColor = true;
            // 
            // rbItem
            // 
            this.rbItem.AutoSize = true;
            this.rbItem.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbItem.Location = new System.Drawing.Point(13, 33);
            this.rbItem.Name = "rbItem";
            this.rbItem.Size = new System.Drawing.Size(123, 24);
            this.rbItem.TabIndex = 0;
            this.rbItem.TabStop = true;
            this.rbItem.Text = "Item Summary";
            this.rbItem.UseVisualStyleBackColor = true;
            // 
            // rbStock
            // 
            this.rbStock.AutoSize = true;
            this.rbStock.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbStock.Location = new System.Drawing.Point(13, 3);
            this.rbStock.Name = "rbStock";
            this.rbStock.Size = new System.Drawing.Size(129, 24);
            this.rbStock.TabIndex = 0;
            this.rbStock.TabStop = true;
            this.rbStock.Text = "Stock Summary";
            this.rbStock.UseVisualStyleBackColor = true;
            // 
            // dgItemDetail
            // 
            this.dgItemDetail.AllowUserToOrderColumns = true;
            this.dgItemDetail.BackgroundColor = System.Drawing.Color.DarkSeaGreen;
            this.dgItemDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgItemDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.INDATE,
            this.Desc,
            this.TagNo,
            this.MetalType,
            this.Pcs,
            this.GW,
            this.NW});
            this.dgItemDetail.Location = new System.Drawing.Point(652, 127);
            this.dgItemDetail.Name = "dgItemDetail";
            this.dgItemDetail.Size = new System.Drawing.Size(700, 400);
            this.dgItemDetail.TabIndex = 37;
            // 
            // INDATE
            // 
            this.INDATE.HeaderText = "IN DATE";
            this.INDATE.Name = "INDATE";
            // 
            // Desc
            // 
            this.Desc.HeaderText = "Desc";
            this.Desc.Name = "Desc";
            // 
            // TagNo
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.TagNo.DefaultCellStyle = dataGridViewCellStyle5;
            this.TagNo.HeaderText = "Tag";
            this.TagNo.Name = "TagNo";
            this.TagNo.Width = 80;
            // 
            // MetalType
            // 
            this.MetalType.HeaderText = "Metal";
            this.MetalType.Name = "MetalType";
            // 
            // Pcs
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Pcs.DefaultCellStyle = dataGridViewCellStyle6;
            this.Pcs.HeaderText = "Pcs";
            this.Pcs.Name = "Pcs";
            this.Pcs.Width = 80;
            // 
            // GW
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.GW.DefaultCellStyle = dataGridViewCellStyle7;
            this.GW.HeaderText = "GW";
            this.GW.Name = "GW";
            this.GW.Width = 80;
            // 
            // NW
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.NW.DefaultCellStyle = dataGridViewCellStyle8;
            this.NW.HeaderText = "NW";
            this.NW.Name = "NW";
            this.NW.Width = 80;
            // 
            // dgMetalType
            // 
            this.dgMetalType.AllowUserToAddRows = false;
            this.dgMetalType.AllowUserToDeleteRows = false;
            this.dgMetalType.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgMetalType.BackgroundColor = System.Drawing.Color.DarkSeaGreen;
            this.dgMetalType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgMetalType.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            this.dgMetalType.Location = new System.Drawing.Point(19, 533);
            this.dgMetalType.Name = "dgMetalType";
            this.dgMetalType.ReadOnly = true;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgMetalType.RowHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dgMetalType.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgMetalType.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgMetalType.Size = new System.Drawing.Size(627, 247);
            this.dgMetalType.TabIndex = 4;
            this.dgMetalType.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgReport_CellContentDoubleClick);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.RosyBrown;
            this.panel3.Controls.Add(this.pbPrint);
            this.panel3.Controls.Add(this.label28);
            this.panel3.Controls.Add(this.btnClose);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(976, 44);
            this.panel3.TabIndex = 36;
            // 
            // pbPrint
            // 
            this.pbPrint.BackColor = System.Drawing.Color.SeaShell;
            this.pbPrint.Dock = System.Windows.Forms.DockStyle.Right;
            this.pbPrint.Image = global::StockManagement.Properties.Resources.appbar_printer;
            this.pbPrint.Location = new System.Drawing.Point(898, 0);
            this.pbPrint.Name = "pbPrint";
            this.pbPrint.Size = new System.Drawing.Size(43, 44);
            this.pbPrint.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPrint.TabIndex = 34;
            this.pbPrint.TabStop = false;
            this.pbPrint.Click += new System.EventHandler(this.pbPrint_Click);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Segoe UI", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.Color.Gold;
            this.label28.Location = new System.Drawing.Point(3, 3);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(189, 40);
            this.label28.TabIndex = 32;
            this.label28.Text = "Daily Report";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.MintCream;
            this.btnClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClose.BackgroundImage")));
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(941, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(35, 44);
            this.btnClose.TabIndex = 31;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // SN
            // 
            this.SN.HeaderText = "S/N";
            this.SN.Name = "SN";
            this.SN.ReadOnly = true;
            this.SN.Width = 52;
            // 
            // Description
            // 
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            this.Description.Width = 85;
            // 
            // OpeningStock
            // 
            this.OpeningStock.HeaderText = "Opening Stock";
            this.OpeningStock.Name = "OpeningStock";
            this.OpeningStock.ReadOnly = true;
            this.OpeningStock.Width = 95;
            // 
            // StockIN
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.StockIN.DefaultCellStyle = dataGridViewCellStyle1;
            this.StockIN.HeaderText = "Stock-IN";
            this.StockIN.Name = "StockIN";
            this.StockIN.ReadOnly = true;
            this.StockIN.Width = 74;
            // 
            // StockOut
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.StockOut.DefaultCellStyle = dataGridViewCellStyle2;
            this.StockOut.HeaderText = "Stock-OUT";
            this.StockOut.Name = "StockOut";
            this.StockOut.ReadOnly = true;
            this.StockOut.Width = 86;
            // 
            // ClosingStock
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ClosingStock.DefaultCellStyle = dataGridViewCellStyle3;
            this.ClosingStock.HeaderText = "Closing Stock";
            this.ClosingStock.Name = "ClosingStock";
            this.ClosingStock.ReadOnly = true;
            this.ClosingStock.Width = 89;
            // 
            // Matal
            // 
            this.Matal.HeaderText = "MetalType";
            this.Matal.Name = "Matal";
            this.Matal.ReadOnly = true;
            this.Matal.Visible = false;
            this.Matal.Width = 82;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "S/N";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 52;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Description";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 85;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewTextBoxColumn3.HeaderText = "Opening Stock";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 95;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridViewTextBoxColumn4.HeaderText = "Stock-IN";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 74;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridViewTextBoxColumn5.HeaderText = "Stock-OUT";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 86;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridViewTextBoxColumn6.HeaderText = "Closing Stock";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 89;
            // 
            // DailyStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(976, 780);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DailyStock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "DailyStock";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgReport)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPrintSelected)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgItemDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMetalType)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPrint)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtDate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.DataGridView dgReport;
        private DevComponents.DotNetBar.PanelEx pnlMain;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgItemDetail;
        private System.Windows.Forms.DataGridView dgMetalType;
        private System.Windows.Forms.PictureBox pbPrint;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbMetal;
        private System.Windows.Forms.RadioButton rbItem;
        private System.Windows.Forms.RadioButton rbStock;
        private System.Windows.Forms.PictureBox pbPrintSelected;
        private System.Windows.Forms.PictureBox pbCancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn INDATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn Desc;
        private System.Windows.Forms.DataGridViewTextBoxColumn TagNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn MetalType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pcs;
        private System.Windows.Forms.DataGridViewTextBoxColumn GW;
        private System.Windows.Forms.DataGridViewTextBoxColumn NW;
        private System.Windows.Forms.DataGridViewTextBoxColumn SN;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn OpeningStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockIN;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClosingStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn Matal;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
    }
}