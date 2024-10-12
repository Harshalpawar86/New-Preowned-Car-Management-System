namespace Preowned_Car_Management_System
{
    partial class SelectTransactionDetailsForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SupplierDataGridView = new System.Windows.Forms.DataGridView();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.OKButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BuyerDataGridView = new System.Windows.Forms.DataGridView();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.CancelButton = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.SupplierSearchTextBox = new System.Windows.Forms.TextBox();
            this.SearchSupplierButton = new System.Windows.Forms.Button();
            this.ClearSupplierButton = new System.Windows.Forms.Button();
            this.ClearBuyerSearchButton = new System.Windows.Forms.Button();
            this.SearchBuyersButton = new System.Windows.Forms.Button();
            this.BuyerSearchTextBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierDataGridView)).BeginInit();
            this.panel7.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BuyerDataGridView)).BeginInit();
            this.panel8.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1437, 731);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.SupplierDataGridView);
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(712, 725);
            this.panel1.TabIndex = 0;
            // 
            // SupplierDataGridView
            // 
            this.SupplierDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.SupplierDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SupplierDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SupplierDataGridView.Location = new System.Drawing.Point(0, 157);
            this.SupplierDataGridView.Name = "SupplierDataGridView";
            this.SupplierDataGridView.RowHeadersWidth = 51;
            this.SupplierDataGridView.RowTemplate.Height = 24;
            this.SupplierDataGridView.Size = new System.Drawing.Size(712, 500);
            this.SupplierDataGridView.TabIndex = 72;
            this.SupplierDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SupplierDataGridView_CellClick);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.ClearSupplierButton);
            this.panel7.Controls.Add(this.SearchSupplierButton);
            this.panel7.Controls.Add(this.SupplierSearchTextBox);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 100);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(712, 57);
            this.panel7.TabIndex = 71;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.OKButton);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 657);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(712, 68);
            this.panel5.TabIndex = 70;
            // 
            // OKButton
            // 
            this.OKButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.OKButton.Font = new System.Drawing.Font("Modern No. 20", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OKButton.Location = new System.Drawing.Point(518, 17);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(166, 42);
            this.OKButton.TabIndex = 63;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(712, 100);
            this.panel3.TabIndex = 68;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.Font = new System.Drawing.Font("Modern No. 20", 30.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(106)))), ((int)(((byte)(255)))));
            this.label4.Location = new System.Drawing.Point(34, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(635, 66);
            this.label4.TabIndex = 67;
            this.label4.Text = "Select Supplier Details : ";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.BuyerDataGridView);
            this.panel2.Controls.Add(this.panel8);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(721, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(713, 725);
            this.panel2.TabIndex = 1;
            // 
            // BuyerDataGridView
            // 
            this.BuyerDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.BuyerDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BuyerDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BuyerDataGridView.Location = new System.Drawing.Point(0, 157);
            this.BuyerDataGridView.Name = "BuyerDataGridView";
            this.BuyerDataGridView.RowHeadersWidth = 51;
            this.BuyerDataGridView.RowTemplate.Height = 24;
            this.BuyerDataGridView.Size = new System.Drawing.Size(713, 500);
            this.BuyerDataGridView.TabIndex = 73;
            this.BuyerDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.BuyerDataGridView_CellClick);
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.ClearBuyerSearchButton);
            this.panel8.Controls.Add(this.SearchBuyersButton);
            this.panel8.Controls.Add(this.BuyerSearchTextBox);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 100);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(713, 57);
            this.panel8.TabIndex = 72;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.CancelButton);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(0, 657);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(713, 68);
            this.panel6.TabIndex = 71;
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CancelButton.Font = new System.Drawing.Font("Modern No. 20", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelButton.Location = new System.Drawing.Point(28, 17);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(166, 42);
            this.CancelButton.TabIndex = 62;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(713, 100);
            this.panel4.TabIndex = 69;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 30.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(106)))), ((int)(((byte)(255)))));
            this.label1.Location = new System.Drawing.Point(28, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(635, 66);
            this.label1.TabIndex = 68;
            this.label1.Text = "Select Buyer Details : ";
            // 
            // SupplierSearchTextBox
            // 
            this.SupplierSearchTextBox.Location = new System.Drawing.Point(188, 6);
            this.SupplierSearchTextBox.Multiline = true;
            this.SupplierSearchTextBox.Name = "SupplierSearchTextBox";
            this.SupplierSearchTextBox.Size = new System.Drawing.Size(451, 45);
            this.SupplierSearchTextBox.TabIndex = 0;
            this.SupplierSearchTextBox.TextChanged += new System.EventHandler(this.SupplierSearchTextBox_TextChanged);
            // 
            // SearchSupplierButton
            // 
            this.SearchSupplierButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(106)))), ((int)(((byte)(255)))));
            this.SearchSupplierButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SearchSupplierButton.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchSupplierButton.ForeColor = System.Drawing.Color.White;
            this.SearchSupplierButton.Location = new System.Drawing.Point(9, 6);
            this.SearchSupplierButton.Name = "SearchSupplierButton";
            this.SearchSupplierButton.Size = new System.Drawing.Size(173, 45);
            this.SearchSupplierButton.TabIndex = 1;
            this.SearchSupplierButton.Text = "Search suppliers";
            this.SearchSupplierButton.UseVisualStyleBackColor = false;
            this.SearchSupplierButton.Click += new System.EventHandler(this.SearchSupplierButton_Click);
            // 
            // ClearSupplierButton
            // 
            this.ClearSupplierButton.BackColor = System.Drawing.Color.Red;
            this.ClearSupplierButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClearSupplierButton.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearSupplierButton.ForeColor = System.Drawing.Color.White;
            this.ClearSupplierButton.Location = new System.Drawing.Point(645, 6);
            this.ClearSupplierButton.Name = "ClearSupplierButton";
            this.ClearSupplierButton.Size = new System.Drawing.Size(53, 45);
            this.ClearSupplierButton.TabIndex = 2;
            this.ClearSupplierButton.Text = "X";
            this.ClearSupplierButton.UseVisualStyleBackColor = false;
            this.ClearSupplierButton.Click += new System.EventHandler(this.ClearSupplierButton_Click);
            // 
            // ClearBuyerSearchButton
            // 
            this.ClearBuyerSearchButton.BackColor = System.Drawing.Color.Red;
            this.ClearBuyerSearchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClearBuyerSearchButton.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearBuyerSearchButton.ForeColor = System.Drawing.Color.White;
            this.ClearBuyerSearchButton.Location = new System.Drawing.Point(648, 6);
            this.ClearBuyerSearchButton.Name = "ClearBuyerSearchButton";
            this.ClearBuyerSearchButton.Size = new System.Drawing.Size(53, 45);
            this.ClearBuyerSearchButton.TabIndex = 5;
            this.ClearBuyerSearchButton.Text = "X";
            this.ClearBuyerSearchButton.UseVisualStyleBackColor = false;
            this.ClearBuyerSearchButton.Click += new System.EventHandler(this.ClearBuyerSearchButton_Click);
            // 
            // SearchBuyersButton
            // 
            this.SearchBuyersButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(106)))), ((int)(((byte)(255)))));
            this.SearchBuyersButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SearchBuyersButton.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchBuyersButton.ForeColor = System.Drawing.Color.White;
            this.SearchBuyersButton.Location = new System.Drawing.Point(12, 6);
            this.SearchBuyersButton.Name = "SearchBuyersButton";
            this.SearchBuyersButton.Size = new System.Drawing.Size(173, 45);
            this.SearchBuyersButton.TabIndex = 4;
            this.SearchBuyersButton.Text = "Search Buyers";
            this.SearchBuyersButton.UseVisualStyleBackColor = false;
            this.SearchBuyersButton.Click += new System.EventHandler(this.SearchBuyersButton_Click);
            // 
            // BuyerSearchTextBox
            // 
            this.BuyerSearchTextBox.Location = new System.Drawing.Point(191, 6);
            this.BuyerSearchTextBox.Multiline = true;
            this.BuyerSearchTextBox.Name = "BuyerSearchTextBox";
            this.BuyerSearchTextBox.Size = new System.Drawing.Size(451, 45);
            this.BuyerSearchTextBox.TabIndex = 3;
            this.BuyerSearchTextBox.TextChanged += new System.EventHandler(this.BuyerSearchTextBox_TextChanged);
            // 
            // SelectTransactionDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1437, 731);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SelectTransactionDetailsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SelectTransactionDetailsForm";
            this.Load += new System.EventHandler(this.SelectTransactionDetailsForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SupplierDataGridView)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BuyerDataGridView)).EndInit();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.DataGridView SupplierDataGridView;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.DataGridView BuyerDataGridView;
        private System.Windows.Forms.Button SearchSupplierButton;
        private System.Windows.Forms.TextBox SupplierSearchTextBox;
        private System.Windows.Forms.Button ClearSupplierButton;
        private System.Windows.Forms.Button ClearBuyerSearchButton;
        private System.Windows.Forms.Button SearchBuyersButton;
        private System.Windows.Forms.TextBox BuyerSearchTextBox;
    }
}