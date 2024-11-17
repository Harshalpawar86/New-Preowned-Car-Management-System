namespace Preowned_Car_Management_System
{
    partial class NewTransactionForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ClearBuyerSearchButton = new System.Windows.Forms.Button();
            this.SearchBuyersButton = new System.Windows.Forms.Button();
            this.BuyerSearchTextBox = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.BuyerDataGridView = new System.Windows.Forms.DataGridView();
            this.OKButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BuyerDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1127, 100);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 30.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(106)))), ((int)(((byte)(255)))));
            this.label1.Location = new System.Drawing.Point(304, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(533, 66);
            this.label1.TabIndex = 71;
            this.label1.Text = "Select Buyer Details : ";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ClearBuyerSearchButton);
            this.panel2.Controls.Add(this.SearchBuyersButton);
            this.panel2.Controls.Add(this.BuyerSearchTextBox);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1127, 62);
            this.panel2.TabIndex = 1;
            // 
            // ClearBuyerSearchButton
            // 
            this.ClearBuyerSearchButton.BackColor = System.Drawing.Color.Red;
            this.ClearBuyerSearchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClearBuyerSearchButton.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearBuyerSearchButton.ForeColor = System.Drawing.Color.White;
            this.ClearBuyerSearchButton.Location = new System.Drawing.Point(219, 8);
            this.ClearBuyerSearchButton.Name = "ClearBuyerSearchButton";
            this.ClearBuyerSearchButton.Size = new System.Drawing.Size(53, 45);
            this.ClearBuyerSearchButton.TabIndex = 14;
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
            this.SearchBuyersButton.Location = new System.Drawing.Point(735, 8);
            this.SearchBuyersButton.Name = "SearchBuyersButton";
            this.SearchBuyersButton.Size = new System.Drawing.Size(173, 45);
            this.SearchBuyersButton.TabIndex = 13;
            this.SearchBuyersButton.Text = "Search Buyers";
            this.SearchBuyersButton.UseVisualStyleBackColor = false;
            this.SearchBuyersButton.Click += new System.EventHandler(this.SearchBuyersButton_Click);
            // 
            // BuyerSearchTextBox
            // 
            this.BuyerSearchTextBox.Location = new System.Drawing.Point(278, 10);
            this.BuyerSearchTextBox.Multiline = true;
            this.BuyerSearchTextBox.Name = "BuyerSearchTextBox";
            this.BuyerSearchTextBox.Size = new System.Drawing.Size(451, 45);
            this.BuyerSearchTextBox.TabIndex = 12;
            this.BuyerSearchTextBox.TextChanged += new System.EventHandler(this.BuyerSearchTextBox_TextChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.OKButton);
            this.panel3.Controls.Add(this.CancelButton);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 627);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1127, 86);
            this.panel3.TabIndex = 2;
            // 
            // BuyerDataGridView
            // 
            this.BuyerDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.BuyerDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BuyerDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BuyerDataGridView.GridColor = System.Drawing.Color.White;
            this.BuyerDataGridView.Location = new System.Drawing.Point(0, 162);
            this.BuyerDataGridView.Name = "BuyerDataGridView";
            this.BuyerDataGridView.RowHeadersWidth = 51;
            this.BuyerDataGridView.RowTemplate.Height = 24;
            this.BuyerDataGridView.Size = new System.Drawing.Size(1127, 465);
            this.BuyerDataGridView.TabIndex = 3;
            // 
            // OKButton
            // 
            this.OKButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.OKButton.Font = new System.Drawing.Font("Modern No. 20", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OKButton.Location = new System.Drawing.Point(300, 22);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(166, 42);
            this.OKButton.TabIndex = 80;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CancelButton.Font = new System.Drawing.Font("Modern No. 20", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelButton.Location = new System.Drawing.Point(661, 22);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(166, 42);
            this.CancelButton.TabIndex = 79;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // NewTransactionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1127, 713);
            this.Controls.Add(this.BuyerDataGridView);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NewTransactionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NewTransactionForm";
            this.Load += new System.EventHandler(this.NewTransactionForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BuyerDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button ClearBuyerSearchButton;
        private System.Windows.Forms.Button SearchBuyersButton;
        private System.Windows.Forms.TextBox BuyerSearchTextBox;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView BuyerDataGridView;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button CancelButton;
    }
}