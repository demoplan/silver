namespace StockManagement.UI
{
    partial class ModifyReceipt
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
            this.pnlMain = new DevComponents.DotNetBar.PanelEx();
            this.dgModify = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.label23 = new System.Windows.Forms.Label();
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtCustName = new System.Windows.Forms.TextBox();
            this.chkProductwise = new System.Windows.Forms.CheckBox();
            this.txtNetWtTo = new System.Windows.Forms.TextBox();
            this.txtNetWtFrom = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlTransport = new System.Windows.Forms.Panel();
            this.chkDatewise = new System.Windows.Forms.CheckBox();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgModify)).BeginInit();
            this.panel1.SuspendLayout();
            this.pnlContainer.SuspendLayout();
            this.panel4.SuspendLayout();
            this.pnlTransport.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.CanvasColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlMain.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pnlMain.Controls.Add(this.dgModify);
            this.pnlMain.Controls.Add(this.panel1);
            this.pnlMain.Controls.Add(this.pnlContainer);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1086, 563);
            this.pnlMain.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnlMain.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(241)))));
            this.pnlMain.Style.BackColor2.Color = System.Drawing.Color.LightGoldenrodYellow;
            this.pnlMain.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.pnlMain.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pnlMain.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnlMain.Style.GradientAngle = 90;
            this.pnlMain.TabIndex = 1;
            // 
            // dgModify
            // 
            this.dgModify.AllowUserToAddRows = false;
            this.dgModify.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.BurlyWood;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.PaleGreen;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dgModify.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgModify.BackgroundColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgModify.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgModify.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.PaleGreen;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgModify.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgModify.GridColor = System.Drawing.Color.Beige;
            this.dgModify.Location = new System.Drawing.Point(12, 196);
            this.dgModify.MultiSelect = false;
            this.dgModify.Name = "dgModify";
            this.dgModify.ReadOnly = true;
            this.dgModify.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgModify.Size = new System.Drawing.Size(846, 360);
            this.dgModify.TabIndex = 0;
            this.dgModify.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgModify_CellMouseDoubleClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.label23);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1086, 39);
            this.panel1.TabIndex = 29;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.MintCream;
            this.btnClose.BackgroundImage = global::StockManagement.Properties.Resources.appbar_close;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(1051, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(35, 39);
            this.btnClose.TabIndex = 30;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Segoe UI", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.Gold;
            this.label23.Location = new System.Drawing.Point(0, -2);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(112, 40);
            this.label23.TabIndex = 0;
            this.label23.Text = "Modify";
            // 
            // pnlContainer
            // 
            this.pnlContainer.Controls.Add(this.label4);
            this.pnlContainer.Controls.Add(this.panel4);
            this.pnlContainer.Controls.Add(this.pnlTransport);
            this.pnlContainer.Controls.Add(this.btnSearch);
            this.pnlContainer.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlContainer.Location = new System.Drawing.Point(12, 57);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(846, 133);
            this.pnlContainer.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.MintCream;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(701, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 21);
            this.label4.TabIndex = 0;
            this.label4.Text = "Search";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Orange;
            this.panel4.Controls.Add(this.txtCustName);
            this.panel4.Controls.Add(this.chkProductwise);
            this.panel4.Controls.Add(this.txtNetWtTo);
            this.panel4.Controls.Add(this.txtNetWtFrom);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Location = new System.Drawing.Point(288, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(405, 125);
            this.panel4.TabIndex = 1;
            // 
            // txtCustName
            // 
            this.txtCustName.BackColor = System.Drawing.Color.Gainsboro;
            this.txtCustName.Enabled = false;
            this.txtCustName.Location = new System.Drawing.Point(172, 13);
            this.txtCustName.Name = "txtCustName";
            this.txtCustName.Size = new System.Drawing.Size(205, 27);
            this.txtCustName.TabIndex = 7;
            this.txtCustName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // chkProductwise
            // 
            this.chkProductwise.AutoSize = true;
            this.chkProductwise.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkProductwise.ForeColor = System.Drawing.Color.White;
            this.chkProductwise.Location = new System.Drawing.Point(16, 98);
            this.chkProductwise.Name = "chkProductwise";
            this.chkProductwise.Size = new System.Drawing.Size(172, 25);
            this.chkProductwise.TabIndex = 3;
            this.chkProductwise.Text = "Productwise Search";
            this.chkProductwise.UseVisualStyleBackColor = true;
            this.chkProductwise.CheckedChanged += new System.EventHandler(this.chkProductwise_CheckedChanged);
            // 
            // txtNetWtTo
            // 
            this.txtNetWtTo.BackColor = System.Drawing.Color.Gainsboro;
            this.txtNetWtTo.Enabled = false;
            this.txtNetWtTo.Location = new System.Drawing.Point(289, 53);
            this.txtNetWtTo.Name = "txtNetWtTo";
            this.txtNetWtTo.Size = new System.Drawing.Size(88, 27);
            this.txtNetWtTo.TabIndex = 2;
            this.txtNetWtTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNetWtTo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNetWtTo_KeyPress);
            // 
            // txtNetWtFrom
            // 
            this.txtNetWtFrom.BackColor = System.Drawing.Color.Gainsboro;
            this.txtNetWtFrom.Enabled = false;
            this.txtNetWtFrom.Location = new System.Drawing.Point(172, 53);
            this.txtNetWtFrom.Name = "txtNetWtFrom";
            this.txtNetWtFrom.Size = new System.Drawing.Size(88, 27);
            this.txtNetWtFrom.TabIndex = 1;
            this.txtNetWtFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNetWtFrom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNetWtFrom_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(154, 21);
            this.label5.TabIndex = 6;
            this.label5.Text = "Net Weight Between:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 21);
            this.label8.TabIndex = 6;
            this.label8.Text = "Net Weight :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Customer Name :";
            // 
            // pnlTransport
            // 
            this.pnlTransport.BackColor = System.Drawing.Color.Thistle;
            this.pnlTransport.Controls.Add(this.chkDatewise);
            this.pnlTransport.Controls.Add(this.dtFromDate);
            this.pnlTransport.Controls.Add(this.dtToDate);
            this.pnlTransport.Controls.Add(this.label1);
            this.pnlTransport.Controls.Add(this.label27);
            this.pnlTransport.Location = new System.Drawing.Point(3, 3);
            this.pnlTransport.Name = "pnlTransport";
            this.pnlTransport.Size = new System.Drawing.Size(279, 125);
            this.pnlTransport.TabIndex = 0;
            // 
            // chkDatewise
            // 
            this.chkDatewise.AutoSize = true;
            this.chkDatewise.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDatewise.ForeColor = System.Drawing.Color.White;
            this.chkDatewise.Location = new System.Drawing.Point(23, 98);
            this.chkDatewise.Name = "chkDatewise";
            this.chkDatewise.Size = new System.Drawing.Size(148, 25);
            this.chkDatewise.TabIndex = 3;
            this.chkDatewise.Text = "Datewise Search";
            this.chkDatewise.UseVisualStyleBackColor = true;
            this.chkDatewise.CheckedChanged += new System.EventHandler(this.chkDatewise_CheckedChanged);
            // 
            // dtFromDate
            // 
            this.dtFromDate.Enabled = false;
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFromDate.Location = new System.Drawing.Point(123, 13);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(128, 27);
            this.dtFromDate.TabIndex = 0;
            this.dtFromDate.Value = new System.DateTime(2017, 10, 28, 0, 0, 0, 0);
            // 
            // dtToDate
            // 
            this.dtToDate.Enabled = false;
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtToDate.Location = new System.Drawing.Point(123, 49);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(128, 27);
            this.dtToDate.TabIndex = 1;
            this.dtToDate.Value = new System.DateTime(2017, 10, 28, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "To Date :";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(19, 19);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(90, 21);
            this.label27.TabIndex = 2;
            this.label27.Text = "From Date :";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.MintCream;
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MintCream;
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Image = global::StockManagement.Properties.Resources.appbar_magnify;
            this.btnSearch.Location = new System.Drawing.Point(699, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(123, 125);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // ModifyReceipt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1086, 563);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ModifyReceipt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ModifyStockIn";
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgModify)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlContainer.ResumeLayout(false);
            this.pnlContainer.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.pnlTransport.ResumeLayout(false);
            this.pnlTransport.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx pnlMain;
        private System.Windows.Forms.Panel pnlContainer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel pnlTransport;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNetWtFrom;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtNetWtTo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkProductwise;
        private System.Windows.Forms.CheckBox chkDatewise;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgModify;
        private System.Windows.Forms.TextBox txtCustName;
    }
}