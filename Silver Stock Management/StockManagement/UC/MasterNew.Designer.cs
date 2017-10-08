namespace StockManagement.UC
{
    partial class MasterNew
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
            this.panelLeft = new System.Windows.Forms.Panel();
            this.panelRight = new System.Windows.Forms.Panel();
            this.btnStoneM = new System.Windows.Forms.Button();
            this.btnDiamondM = new System.Windows.Forms.Button();
            this.btnMetalM = new System.Windows.Forms.Button();
            this.btnProductM = new System.Windows.Forms.Button();
            this.btnItemM = new System.Windows.Forms.Button();
            this.panelLeft.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLeft
            // 
            this.panelLeft.Controls.Add(this.btnStoneM);
            this.panelLeft.Controls.Add(this.btnDiamondM);
            this.panelLeft.Controls.Add(this.btnMetalM);
            this.panelLeft.Controls.Add(this.btnProductM);
            this.panelLeft.Controls.Add(this.btnItemM);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(325, 546);
            this.panelLeft.TabIndex = 0;
            // 
            // panelRight
            // 
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight.Location = new System.Drawing.Point(325, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(648, 546);
            this.panelRight.TabIndex = 1;
            // 
            // btnStoneM
            // 
            this.btnStoneM.BackColor = System.Drawing.Color.LightSlateGray;
            this.btnStoneM.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnStoneM.FlatAppearance.CheckedBackColor = System.Drawing.Color.Gainsboro;
            this.btnStoneM.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.btnStoneM.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.btnStoneM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStoneM.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStoneM.Location = new System.Drawing.Point(3, 324);
            this.btnStoneM.Name = "btnStoneM";
            this.btnStoneM.Size = new System.Drawing.Size(316, 103);
            this.btnStoneM.TabIndex = 5;
            this.btnStoneM.Text = "Dealer Master";
            this.btnStoneM.UseVisualStyleBackColor = false;
            this.btnStoneM.Click += new System.EventHandler(this.btnDealerM_Click);
            // 
            // btnDiamondM
            // 
            this.btnDiamondM.BackColor = System.Drawing.Color.Thistle;
            this.btnDiamondM.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnDiamondM.FlatAppearance.CheckedBackColor = System.Drawing.Color.Gainsboro;
            this.btnDiamondM.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.btnDiamondM.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.btnDiamondM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDiamondM.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDiamondM.Location = new System.Drawing.Point(3, 434);
            this.btnDiamondM.Name = "btnDiamondM";
            this.btnDiamondM.Size = new System.Drawing.Size(316, 103);
            this.btnDiamondM.TabIndex = 6;
            this.btnDiamondM.Text = "Artisan Master";
            this.btnDiamondM.UseVisualStyleBackColor = false;
            this.btnDiamondM.Click += new System.EventHandler(this.btnArtisanM_Click);
            // 
            // btnMetalM
            // 
            this.btnMetalM.BackColor = System.Drawing.Color.Gold;
            this.btnMetalM.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnMetalM.FlatAppearance.CheckedBackColor = System.Drawing.Color.Gainsboro;
            this.btnMetalM.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.btnMetalM.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.btnMetalM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMetalM.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMetalM.Location = new System.Drawing.Point(3, 112);
            this.btnMetalM.Name = "btnMetalM";
            this.btnMetalM.Size = new System.Drawing.Size(316, 103);
            this.btnMetalM.TabIndex = 7;
            this.btnMetalM.Text = "Metal Master";
            this.btnMetalM.UseVisualStyleBackColor = false;
            this.btnMetalM.Click += new System.EventHandler(this.btnMetalM_Click);
            // 
            // btnProductM
            // 
            this.btnProductM.BackColor = System.Drawing.Color.DarkTurquoise;
            this.btnProductM.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnProductM.FlatAppearance.CheckedBackColor = System.Drawing.Color.Gainsboro;
            this.btnProductM.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.btnProductM.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.btnProductM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProductM.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProductM.Location = new System.Drawing.Point(3, 5);
            this.btnProductM.Name = "btnProductM";
            this.btnProductM.Size = new System.Drawing.Size(316, 103);
            this.btnProductM.TabIndex = 8;
            this.btnProductM.Text = "Product Master";
            this.btnProductM.UseVisualStyleBackColor = false;
            this.btnProductM.Click += new System.EventHandler(this.btnProductM_Click);
            // 
            // btnItemM
            // 
            this.btnItemM.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnItemM.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnItemM.FlatAppearance.CheckedBackColor = System.Drawing.Color.Gainsboro;
            this.btnItemM.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.btnItemM.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.btnItemM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnItemM.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnItemM.Location = new System.Drawing.Point(3, 218);
            this.btnItemM.Name = "btnItemM";
            this.btnItemM.Size = new System.Drawing.Size(316, 103);
            this.btnItemM.TabIndex = 9;
            this.btnItemM.Text = "Customer Master";
            this.btnItemM.UseVisualStyleBackColor = false;
            this.btnItemM.Click += new System.EventHandler(this.btnICustomerM_Click);
            // 
            // MasterNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 546);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.Name = "MasterNew";
            this.Text = "MasterNew";
            this.panelLeft.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Button btnStoneM;
        private System.Windows.Forms.Button btnDiamondM;
        private System.Windows.Forms.Button btnMetalM;
        private System.Windows.Forms.Button btnProductM;
        private System.Windows.Forms.Button btnItemM;
    }
}