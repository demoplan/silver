namespace StockManagement.UC
{
    partial class uscMetalMaster
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDeleteC = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.label22 = new System.Windows.Forms.Label();
            this.txtMetalDesc = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkTurquoise;
            this.panel1.Controls.Add(this.btnDeleteC);
            this.panel1.Controls.Add(this.btnModify);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.dataGrid);
            this.panel1.Controls.Add(this.label22);
            this.panel1.Controls.Add(this.txtMetalDesc);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(689, 542);
            this.panel1.TabIndex = 6;
            // 
            // btnDeleteC
            // 
            this.btnDeleteC.BackColor = System.Drawing.Color.Red;
            this.btnDeleteC.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.btnDeleteC.FlatAppearance.CheckedBackColor = System.Drawing.Color.Gainsboro;
            this.btnDeleteC.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Firebrick;
            this.btnDeleteC.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick;
            this.btnDeleteC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteC.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteC.ForeColor = System.Drawing.Color.White;
            this.btnDeleteC.Location = new System.Drawing.Point(394, 461);
            this.btnDeleteC.Name = "btnDeleteC";
            this.btnDeleteC.Size = new System.Drawing.Size(121, 75);
            this.btnDeleteC.TabIndex = 41;
            this.btnDeleteC.Text = "Delete";
            this.btnDeleteC.UseVisualStyleBackColor = false;
            this.btnDeleteC.Visible = false;
            this.btnDeleteC.Click += new System.EventHandler(this.btnDeleteC_Click);
            // 
            // btnModify
            // 
            this.btnModify.BackColor = System.Drawing.Color.DarkTurquoise;
            this.btnModify.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnModify.FlatAppearance.CheckedBackColor = System.Drawing.Color.Gainsboro;
            this.btnModify.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.btnModify.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.btnModify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModify.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModify.Location = new System.Drawing.Point(267, 461);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(121, 75);
            this.btnModify.TabIndex = 40;
            this.btnModify.Text = "Modify";
            this.btnModify.UseVisualStyleBackColor = false;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
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
            this.btnSave.Location = new System.Drawing.Point(140, 461);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(121, 75);
            this.btnSave.TabIndex = 40;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dataGrid
            // 
            this.dataGrid.AllowUserToAddRows = false;
            this.dataGrid.AllowUserToDeleteRows = false;
            this.dataGrid.BackgroundColor = System.Drawing.Color.DarkTurquoise;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Location = new System.Drawing.Point(90, 111);
            this.dataGrid.MultiSelect = false;
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.ReadOnly = true;
            this.dataGrid.Size = new System.Drawing.Size(519, 344);
            this.dataGrid.TabIndex = 39;
            this.dataGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_CellClick);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(86, 56);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(96, 21);
            this.label22.TabIndex = 38;
            this.label22.Text = "Description :";
            // 
            // txtMetalDesc
            // 
            this.txtMetalDesc.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMetalDesc.Location = new System.Drawing.Point(221, 53);
            this.txtMetalDesc.MaxLength = 250;
            this.txtMetalDesc.Name = "txtMetalDesc";
            this.txtMetalDesc.Size = new System.Drawing.Size(388, 29);
            this.txtMetalDesc.TabIndex = 0;
            // 
            // uscMetalMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "uscMetalMaster";
            this.Size = new System.Drawing.Size(689, 542);
            this.Load += new System.EventHandler(this.uscMetalMaster_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDeleteC;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtMetalDesc;
    }
}
