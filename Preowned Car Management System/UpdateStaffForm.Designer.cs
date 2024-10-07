namespace Preowned_Car_Management_System
{
    partial class UpdateStaffForm
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
            this.UpdateButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.JobDesignationComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.AddressTextBox = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.StaffEmailTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.MobileNumberTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.StaffNameTextBox = new System.Windows.Forms.TextBox();
            this.CarIdLabel = new System.Windows.Forms.Label();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.Font = new System.Drawing.Font("Modern No. 20", 30.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(106)))), ((int)(((byte)(255)))));
            this.label4.Location = new System.Drawing.Point(181, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(594, 66);
            this.label4.TabIndex = 112;
            this.label4.Text = "Update Staff Details : ";
            // 
            // UpdateButton
            // 
            this.UpdateButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UpdateButton.Font = new System.Drawing.Font("Modern No. 20", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateButton.Location = new System.Drawing.Point(205, 618);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(197, 51);
            this.UpdateButton.TabIndex = 109;
            this.UpdateButton.Text = "UPDATE";
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CancelButton.Font = new System.Drawing.Font("Modern No. 20", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelButton.Location = new System.Drawing.Point(461, 618);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(169, 51);
            this.CancelButton.TabIndex = 108;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // JobDesignationComboBox
            // 
            this.JobDesignationComboBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.JobDesignationComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.JobDesignationComboBox.FormattingEnabled = true;
            this.JobDesignationComboBox.Items.AddRange(new object[] {
            "Assistant Manager",
            "Sales Manager",
            "Accountant",
            "Mechanic",
            "Office Boy"});
            this.JobDesignationComboBox.Location = new System.Drawing.Point(552, 463);
            this.JobDesignationComboBox.Name = "JobDesignationComboBox";
            this.JobDesignationComboBox.Size = new System.Drawing.Size(133, 24);
            this.JobDesignationComboBox.TabIndex = 125;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Modern No. 20", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(106)))), ((int)(((byte)(255)))));
            this.label6.Location = new System.Drawing.Point(142, 463);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(167, 30);
            this.label6.TabIndex = 124;
            this.label6.Text = "Promotion : ";
            // 
            // AddressTextBox
            // 
            this.AddressTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AddressTextBox.Location = new System.Drawing.Point(552, 356);
            this.AddressTextBox.Name = "AddressTextBox";
            this.AddressTextBox.Size = new System.Drawing.Size(133, 79);
            this.AddressTextBox.TabIndex = 123;
            this.AddressTextBox.Text = "";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Modern No. 20", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(106)))), ((int)(((byte)(255)))));
            this.label3.Location = new System.Drawing.Point(142, 356);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(227, 30);
            this.label3.TabIndex = 122;
            this.label3.Text = "Update Address : ";
            // 
            // StaffEmailTextBox
            // 
            this.StaffEmailTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.StaffEmailTextBox.Location = new System.Drawing.Point(552, 300);
            this.StaffEmailTextBox.Multiline = true;
            this.StaffEmailTextBox.Name = "StaffEmailTextBox";
            this.StaffEmailTextBox.Size = new System.Drawing.Size(133, 35);
            this.StaffEmailTextBox.TabIndex = 121;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Modern No. 20", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(106)))), ((int)(((byte)(255)))));
            this.label5.Location = new System.Drawing.Point(142, 297);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(236, 30);
            this.label5.TabIndex = 120;
            this.label5.Text = "Update E - Mail : ";
            // 
            // MobileNumberTextBox
            // 
            this.MobileNumberTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.MobileNumberTextBox.Location = new System.Drawing.Point(552, 243);
            this.MobileNumberTextBox.Multiline = true;
            this.MobileNumberTextBox.Name = "MobileNumberTextBox";
            this.MobileNumberTextBox.Size = new System.Drawing.Size(133, 35);
            this.MobileNumberTextBox.TabIndex = 119;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Modern No. 20", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(106)))), ((int)(((byte)(255)))));
            this.label2.Location = new System.Drawing.Point(142, 240);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(320, 30);
            this.label2.TabIndex = 118;
            this.label2.Text = "Update Mobile Number : ";
            // 
            // StaffNameTextBox
            // 
            this.StaffNameTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.StaffNameTextBox.Location = new System.Drawing.Point(552, 183);
            this.StaffNameTextBox.Multiline = true;
            this.StaffNameTextBox.Name = "StaffNameTextBox";
            this.StaffNameTextBox.Size = new System.Drawing.Size(133, 35);
            this.StaffNameTextBox.TabIndex = 114;
            // 
            // CarIdLabel
            // 
            this.CarIdLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CarIdLabel.AutoSize = true;
            this.CarIdLabel.Font = new System.Drawing.Font("Modern No. 20", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CarIdLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(106)))), ((int)(((byte)(255)))));
            this.CarIdLabel.Location = new System.Drawing.Point(142, 183);
            this.CarIdLabel.Name = "CarIdLabel";
            this.CarIdLabel.Size = new System.Drawing.Size(199, 30);
            this.CarIdLabel.TabIndex = 113;
            this.CarIdLabel.Text = "Update Name : ";
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PasswordTextBox.Location = new System.Drawing.Point(552, 515);
            this.PasswordTextBox.Multiline = true;
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.Size = new System.Drawing.Size(133, 35);
            this.PasswordTextBox.TabIndex = 127;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(106)))), ((int)(((byte)(255)))));
            this.label1.Location = new System.Drawing.Point(142, 515);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(246, 30);
            this.label1.TabIndex = 126;
            this.label1.Text = "Update Password : ";
            // 
            // UpdateStaffForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(863, 736);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.JobDesignationComboBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.AddressTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.StaffEmailTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.MobileNumberTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.StaffNameTextBox);
            this.Controls.Add(this.CarIdLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.UpdateButton);
            this.Controls.Add(this.CancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UpdateStaffForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UpdateStaffForm";
            this.Load += new System.EventHandler(this.UpdateStaffForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.ComboBox JobDesignationComboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox AddressTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox StaffEmailTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox MobileNumberTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox StaffNameTextBox;
        private System.Windows.Forms.Label CarIdLabel;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Label label1;
    }
}