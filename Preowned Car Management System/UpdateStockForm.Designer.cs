namespace Preowned_Car_Management_System
{
    partial class UpdateStockForm
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
            this.label4 = new System.Windows.Forms.Label();
            this.CarInfoTextBox = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.OKButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.photo_button = new System.Windows.Forms.Button();
            this.photo_label = new System.Windows.Forms.Label();
            this.CarNameTextBox = new System.Windows.Forms.TextBox();
            this.CarNameLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.OwnerTypeComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.PurchaseAmountTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.Font = new System.Drawing.Font("Modern No. 20", 30.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(24)))), ((int)(((byte)(158)))));
            this.label4.Location = new System.Drawing.Point(181, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(474, 66);
            this.label4.TabIndex = 66;
            this.label4.Text = "Enter Stock Details : ";
            // 
            // CarInfoTextBox
            // 
            this.CarInfoTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CarInfoTextBox.Location = new System.Drawing.Point(511, 456);
            this.CarInfoTextBox.Name = "CarInfoTextBox";
            this.CarInfoTextBox.Size = new System.Drawing.Size(161, 71);
            this.CarInfoTextBox.TabIndex = 64;
            this.CarInfoTextBox.Text = "";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Modern No. 20", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(24)))), ((int)(((byte)(158)))));
            this.label3.Location = new System.Drawing.Point(130, 456);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 30);
            this.label3.TabIndex = 63;
            this.label3.Text = "Car Info : ";
            // 
            // OKButton
            // 
            this.OKButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.OKButton.Font = new System.Drawing.Font("Modern No. 20", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OKButton.Location = new System.Drawing.Point(297, 577);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(125, 42);
            this.OKButton.TabIndex = 61;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CancelButton.Font = new System.Drawing.Font("Modern No. 20", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelButton.Location = new System.Drawing.Point(433, 577);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(125, 42);
            this.CancelButton.TabIndex = 60;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // photo_button
            // 
            this.photo_button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.photo_button.Font = new System.Drawing.Font("Modern No. 20", 8.799999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.photo_button.Location = new System.Drawing.Point(539, 328);
            this.photo_button.Name = "photo_button";
            this.photo_button.Size = new System.Drawing.Size(133, 30);
            this.photo_button.TabIndex = 59;
            this.photo_button.Text = "Add Image";
            this.photo_button.UseVisualStyleBackColor = true;
            this.photo_button.Click += new System.EventHandler(this.photo_button_Click);
            // 
            // photo_label
            // 
            this.photo_label.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.photo_label.AutoSize = true;
            this.photo_label.Font = new System.Drawing.Font("Modern No. 20", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.photo_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(24)))), ((int)(((byte)(158)))));
            this.photo_label.Location = new System.Drawing.Point(129, 326);
            this.photo_label.Name = "photo_label";
            this.photo_label.Size = new System.Drawing.Size(230, 30);
            this.photo_label.TabIndex = 58;
            this.photo_label.Text = "Enter Car Photo: ";
            // 
            // CarNameTextBox
            // 
            this.CarNameTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CarNameTextBox.Location = new System.Drawing.Point(539, 210);
            this.CarNameTextBox.Multiline = true;
            this.CarNameTextBox.Name = "CarNameTextBox";
            this.CarNameTextBox.Size = new System.Drawing.Size(133, 35);
            this.CarNameTextBox.TabIndex = 56;
            // 
            // CarNameLabel
            // 
            this.CarNameLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CarNameLabel.AutoSize = true;
            this.CarNameLabel.Font = new System.Drawing.Font("Modern No. 20", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CarNameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(24)))), ((int)(((byte)(158)))));
            this.CarNameLabel.Location = new System.Drawing.Point(130, 215);
            this.CarNameLabel.Name = "CarNameLabel";
            this.CarNameLabel.Size = new System.Drawing.Size(232, 30);
            this.CarNameLabel.TabIndex = 55;
            this.CarNameLabel.Text = "Enter Car Name : ";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Modern No. 20", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(24)))), ((int)(((byte)(158)))));
            this.label2.Location = new System.Drawing.Point(129, 376);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(259, 30);
            this.label2.TabIndex = 62;
            this.label2.Text = "Enter Owner Type : ";
            // 
            // OwnerTypeComboBox
            // 
            this.OwnerTypeComboBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.OwnerTypeComboBox.FormattingEnabled = true;
            this.OwnerTypeComboBox.Items.AddRange(new object[] {
            "First Owner",
            "Second Owner",
            "Third Owner",
            "Fourth Owner",
            "Fifth Owner"});
            this.OwnerTypeComboBox.Location = new System.Drawing.Point(539, 383);
            this.OwnerTypeComboBox.Name = "OwnerTypeComboBox";
            this.OwnerTypeComboBox.Size = new System.Drawing.Size(133, 24);
            this.OwnerTypeComboBox.TabIndex = 72;
            this.OwnerTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.OwnerTypeComboBox_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Modern No. 20", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(24)))), ((int)(((byte)(158)))));
            this.label6.Location = new System.Drawing.Point(129, 264);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(333, 30);
            this.label6.TabIndex = 70;
            this.label6.Text = "Enter Purchase Amount : ";
            // 
            // PurchaseAmountTextBox
            // 
            this.PurchaseAmountTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PurchaseAmountTextBox.Location = new System.Drawing.Point(539, 271);
            this.PurchaseAmountTextBox.Multiline = true;
            this.PurchaseAmountTextBox.Name = "PurchaseAmountTextBox";
            this.PurchaseAmountTextBox.Size = new System.Drawing.Size(133, 35);
            this.PurchaseAmountTextBox.TabIndex = 71;
            // 
            // UpdateStockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 653);
            this.Controls.Add(this.OwnerTypeComboBox);
            this.Controls.Add(this.PurchaseAmountTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CarInfoTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.photo_button);
            this.Controls.Add(this.photo_label);
            this.Controls.Add(this.CarNameTextBox);
            this.Controls.Add(this.CarNameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UpdateStockForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UpdateStockForm";
            this.Load += new System.EventHandler(this.UpdateStockForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox CarInfoTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button photo_button;
        private System.Windows.Forms.Label photo_label;
        private System.Windows.Forms.TextBox CarNameTextBox;
        private System.Windows.Forms.Label CarNameLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox OwnerTypeComboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox PurchaseAmountTextBox;
    }
}