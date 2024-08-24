namespace Preowned_Car_Management_System
{
    partial class AddSupplierInfo
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
            this.label1 = new System.Windows.Forms.Label();
            this.SupplierIdTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CarIdTextBox = new System.Windows.Forms.TextBox();
            this.AddressTextBox = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.OKButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.car_label = new System.Windows.Forms.Label();
            this.SupplierNameTextBox = new System.Windows.Forms.TextBox();
            this.CarNameLabel = new System.Windows.Forms.Label();
            this.MobileNumberTextBox = new System.Windows.Forms.TextBox();
            this.CarNameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(24)))), ((int)(((byte)(158)))));
            this.label1.Location = new System.Drawing.Point(135, 383);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(303, 30);
            this.label1.TabIndex = 65;
            this.label1.Text = "Enter Mobile Number : ";
            // 
            // SupplierIdTextBox
            // 
            this.SupplierIdTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SupplierIdTextBox.Location = new System.Drawing.Point(545, 325);
            this.SupplierIdTextBox.Multiline = true;
            this.SupplierIdTextBox.Name = "SupplierIdTextBox";
            this.SupplierIdTextBox.Size = new System.Drawing.Size(133, 35);
            this.SupplierIdTextBox.TabIndex = 64;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Modern No. 20", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(24)))), ((int)(((byte)(158)))));
            this.label5.Location = new System.Drawing.Point(135, 318);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(256, 30);
            this.label5.TabIndex = 63;
            this.label5.Text = "Enter Supplier Id : ";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.Font = new System.Drawing.Font("Modern No. 20", 30.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(24)))), ((int)(((byte)(158)))));
            this.label4.Location = new System.Drawing.Point(158, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(594, 66);
            this.label4.TabIndex = 62;
            this.label4.Text = "Enter Supplier Details : ";
            // 
            // CarIdTextBox
            // 
            this.CarIdTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CarIdTextBox.Location = new System.Drawing.Point(545, 275);
            this.CarIdTextBox.Multiline = true;
            this.CarIdTextBox.Name = "CarIdTextBox";
            this.CarIdTextBox.Size = new System.Drawing.Size(133, 35);
            this.CarIdTextBox.TabIndex = 61;
            // 
            // AddressTextBox
            // 
            this.AddressTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AddressTextBox.Location = new System.Drawing.Point(517, 454);
            this.AddressTextBox.Name = "AddressTextBox";
            this.AddressTextBox.Size = new System.Drawing.Size(161, 71);
            this.AddressTextBox.TabIndex = 60;
            this.AddressTextBox.Text = "";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Modern No. 20", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(24)))), ((int)(((byte)(158)))));
            this.label3.Location = new System.Drawing.Point(136, 454);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(210, 30);
            this.label3.TabIndex = 59;
            this.label3.Text = "Enter Address : ";
            // 
            // OKButton
            // 
            this.OKButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.OKButton.Font = new System.Drawing.Font("Modern No. 20", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OKButton.Location = new System.Drawing.Point(290, 579);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(125, 42);
            this.OKButton.TabIndex = 57;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CancelButton.Font = new System.Drawing.Font("Modern No. 20", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelButton.Location = new System.Drawing.Point(426, 579);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(125, 42);
            this.CancelButton.TabIndex = 56;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // car_label
            // 
            this.car_label.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.car_label.AutoSize = true;
            this.car_label.Font = new System.Drawing.Font("Modern No. 20", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.car_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(24)))), ((int)(((byte)(158)))));
            this.car_label.Location = new System.Drawing.Point(135, 268);
            this.car_label.Name = "car_label";
            this.car_label.Size = new System.Drawing.Size(192, 30);
            this.car_label.TabIndex = 53;
            this.car_label.Text = "Enter Car Id : ";
            // 
            // SupplierNameTextBox
            // 
            this.SupplierNameTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SupplierNameTextBox.Location = new System.Drawing.Point(545, 167);
            this.SupplierNameTextBox.Multiline = true;
            this.SupplierNameTextBox.Name = "SupplierNameTextBox";
            this.SupplierNameTextBox.Size = new System.Drawing.Size(133, 35);
            this.SupplierNameTextBox.TabIndex = 52;
            // 
            // CarNameLabel
            // 
            this.CarNameLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CarNameLabel.AutoSize = true;
            this.CarNameLabel.Font = new System.Drawing.Font("Modern No. 20", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CarNameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(24)))), ((int)(((byte)(158)))));
            this.CarNameLabel.Location = new System.Drawing.Point(135, 164);
            this.CarNameLabel.Name = "CarNameLabel";
            this.CarNameLabel.Size = new System.Drawing.Size(296, 30);
            this.CarNameLabel.TabIndex = 51;
            this.CarNameLabel.Text = "Enter Supplier Name : ";
            // 
            // MobileNumberTextBox
            // 
            this.MobileNumberTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.MobileNumberTextBox.Location = new System.Drawing.Point(545, 383);
            this.MobileNumberTextBox.Multiline = true;
            this.MobileNumberTextBox.Name = "MobileNumberTextBox";
            this.MobileNumberTextBox.Size = new System.Drawing.Size(133, 35);
            this.MobileNumberTextBox.TabIndex = 67;
            // 
            // CarNameTextBox
            // 
            this.CarNameTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CarNameTextBox.Location = new System.Drawing.Point(546, 223);
            this.CarNameTextBox.Multiline = true;
            this.CarNameTextBox.Name = "CarNameTextBox";
            this.CarNameTextBox.Size = new System.Drawing.Size(133, 35);
            this.CarNameTextBox.TabIndex = 69;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Modern No. 20", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(24)))), ((int)(((byte)(158)))));
            this.label2.Location = new System.Drawing.Point(136, 216);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(232, 30);
            this.label2.TabIndex = 68;
            this.label2.Text = "Enter Car Name : ";
            // 
            // AddSupplierInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 735);
            this.Controls.Add(this.CarNameTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.MobileNumberTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SupplierIdTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CarIdTextBox);
            this.Controls.Add(this.AddressTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.car_label);
            this.Controls.Add(this.SupplierNameTextBox);
            this.Controls.Add(this.CarNameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddSupplierInfo";
            this.Text = "AddSupplierInfo";
            this.Load += new System.EventHandler(this.AddSupplierInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox SupplierIdTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox CarIdTextBox;
        private System.Windows.Forms.RichTextBox AddressTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Label car_label;
        private System.Windows.Forms.TextBox SupplierNameTextBox;
        private System.Windows.Forms.Label CarNameLabel;
        private System.Windows.Forms.TextBox MobileNumberTextBox;
        private System.Windows.Forms.TextBox CarNameTextBox;
        private System.Windows.Forms.Label label2;
    }
}