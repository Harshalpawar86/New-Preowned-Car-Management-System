﻿namespace Preowned_Car_Management_System
{
    partial class DashBoardForm
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
            this.flowLayoutPanel1 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.DashPanel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.StaffButton = new System.Windows.Forms.Button();
            this.HistoryButton = new System.Windows.Forms.Button();
            this.ReportsButton = new System.Windows.Forms.Button();
            this.MaintenanceButton = new System.Windows.Forms.Button();
            this.AccessoriesButton = new System.Windows.Forms.Button();
            this.BuyersButton = new System.Windows.Forms.Button();
            this.SuppliersButton = new System.Windows.Forms.Button();
            this.StockButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.DashPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(347, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(967, 809);
            this.flowLayoutPanel1.TabIndex = 6;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(347, 100);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Showcard Gothic", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(31, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(284, 52);
            this.label1.TabIndex = 20;
            this.label1.Text = "DashBoard";
            // 
            // DashPanel
            // 
            this.DashPanel.AutoScroll = true;
            this.DashPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(24)))), ((int)(((byte)(158)))));
            this.DashPanel.Controls.Add(this.panel2);
            this.DashPanel.Controls.Add(this.panel1);
            this.DashPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.DashPanel.Location = new System.Drawing.Point(0, 0);
            this.DashPanel.Name = "DashPanel";
            this.DashPanel.Size = new System.Drawing.Size(347, 809);
            this.DashPanel.TabIndex = 5;
            this.DashPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.DashPanel_Paint);
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.StaffButton);
            this.panel2.Controls.Add(this.HistoryButton);
            this.panel2.Controls.Add(this.ReportsButton);
            this.panel2.Controls.Add(this.MaintenanceButton);
            this.panel2.Controls.Add(this.AccessoriesButton);
            this.panel2.Controls.Add(this.BuyersButton);
            this.panel2.Controls.Add(this.SuppliersButton);
            this.panel2.Controls.Add(this.StockButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(347, 709);
            this.panel2.TabIndex = 1;
            // 
            // StaffButton
            // 
            this.StaffButton.Font = new System.Drawing.Font("Modern No. 20", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StaffButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.StaffButton.Location = new System.Drawing.Point(31, 500);
            this.StaffButton.Name = "StaffButton";
            this.StaffButton.Size = new System.Drawing.Size(284, 64);
            this.StaffButton.TabIndex = 27;
            this.StaffButton.Text = "Staff";
            this.StaffButton.UseVisualStyleBackColor = true;
            this.StaffButton.Click += new System.EventHandler(this.StaffButton_Click);
            // 
            // HistoryButton
            // 
            this.HistoryButton.Font = new System.Drawing.Font("Modern No. 20", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HistoryButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.HistoryButton.Location = new System.Drawing.Point(31, 416);
            this.HistoryButton.Name = "HistoryButton";
            this.HistoryButton.Size = new System.Drawing.Size(284, 64);
            this.HistoryButton.TabIndex = 26;
            this.HistoryButton.Text = "History";
            this.HistoryButton.UseVisualStyleBackColor = true;
            this.HistoryButton.Click += new System.EventHandler(this.HistoryButton_Click);
            // 
            // ReportsButton
            // 
            this.ReportsButton.Font = new System.Drawing.Font("Modern No. 20", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReportsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ReportsButton.Location = new System.Drawing.Point(31, 589);
            this.ReportsButton.Name = "ReportsButton";
            this.ReportsButton.Size = new System.Drawing.Size(284, 64);
            this.ReportsButton.TabIndex = 25;
            this.ReportsButton.Text = "Reports";
            this.ReportsButton.UseVisualStyleBackColor = true;
            // 
            // MaintenanceButton
            // 
            this.MaintenanceButton.Font = new System.Drawing.Font("Modern No. 20", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaintenanceButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MaintenanceButton.Location = new System.Drawing.Point(31, 334);
            this.MaintenanceButton.Name = "MaintenanceButton";
            this.MaintenanceButton.Size = new System.Drawing.Size(284, 64);
            this.MaintenanceButton.TabIndex = 24;
            this.MaintenanceButton.Text = "Maintenance";
            this.MaintenanceButton.UseVisualStyleBackColor = true;
            this.MaintenanceButton.Click += new System.EventHandler(this.MaintenanceButton_Click);
            // 
            // AccessoriesButton
            // 
            this.AccessoriesButton.Font = new System.Drawing.Font("Modern No. 20", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccessoriesButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AccessoriesButton.Location = new System.Drawing.Point(31, 252);
            this.AccessoriesButton.Name = "AccessoriesButton";
            this.AccessoriesButton.Size = new System.Drawing.Size(284, 64);
            this.AccessoriesButton.TabIndex = 23;
            this.AccessoriesButton.Text = "Accessories";
            this.AccessoriesButton.UseVisualStyleBackColor = true;
            this.AccessoriesButton.Click += new System.EventHandler(this.AccessoriesButton_Click);
            // 
            // BuyersButton
            // 
            this.BuyersButton.Font = new System.Drawing.Font("Modern No. 20", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BuyersButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BuyersButton.Location = new System.Drawing.Point(31, 170);
            this.BuyersButton.Name = "BuyersButton";
            this.BuyersButton.Size = new System.Drawing.Size(284, 64);
            this.BuyersButton.TabIndex = 22;
            this.BuyersButton.Text = "Buyers";
            this.BuyersButton.UseVisualStyleBackColor = true;
            this.BuyersButton.Click += new System.EventHandler(this.BuyersButton_Click);
            // 
            // SuppliersButton
            // 
            this.SuppliersButton.Font = new System.Drawing.Font("Modern No. 20", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SuppliersButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SuppliersButton.Location = new System.Drawing.Point(31, 90);
            this.SuppliersButton.Name = "SuppliersButton";
            this.SuppliersButton.Size = new System.Drawing.Size(284, 64);
            this.SuppliersButton.TabIndex = 21;
            this.SuppliersButton.Text = "Suppliers";
            this.SuppliersButton.UseVisualStyleBackColor = true;
            this.SuppliersButton.Click += new System.EventHandler(this.SuppliersButton_Click);
            // 
            // StockButton
            // 
            this.StockButton.Font = new System.Drawing.Font("Modern No. 20", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StockButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.StockButton.Location = new System.Drawing.Point(31, 6);
            this.StockButton.Name = "StockButton";
            this.StockButton.Size = new System.Drawing.Size(284, 64);
            this.StockButton.TabIndex = 20;
            this.StockButton.Text = "Stock";
            this.StockButton.UseVisualStyleBackColor = true;
            this.StockButton.Click += new System.EventHandler(this.StockButton_Click_1);
            // 
            // DashBoardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1314, 809);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.DashPanel);
            this.Name = "DashBoardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DashBoardForm";
            this.Load += new System.EventHandler(this.DashBoardForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.DashPanel.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel DashPanel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button StaffButton;
        private System.Windows.Forms.Button HistoryButton;
        private System.Windows.Forms.Button ReportsButton;
        private System.Windows.Forms.Button MaintenanceButton;
        private System.Windows.Forms.Button AccessoriesButton;
        private System.Windows.Forms.Button BuyersButton;
        private System.Windows.Forms.Button SuppliersButton;
        private System.Windows.Forms.Button StockButton;
    }
}