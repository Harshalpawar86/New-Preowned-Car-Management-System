namespace Preowned_Car_Management_System
{
    partial class MaintenanceInfoForm
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
            this.MaintenanceIdTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.OKButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.costLabel = new System.Windows.Forms.Label();
            this.CarIdTextBox = new System.Windows.Forms.TextBox();
            this.CarIdLabel = new System.Windows.Forms.Label();
            this.MaintenanceCostTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.MaintenanceIdRichTextBox = new System.Windows.Forms.RichTextBox();
            this.GetCarIdButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // MaintenanceIdTextBox
            // 
            this.MaintenanceIdTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.MaintenanceIdTextBox.BackColor = System.Drawing.Color.White;
            this.MaintenanceIdTextBox.Location = new System.Drawing.Point(488, 244);
            this.MaintenanceIdTextBox.Multiline = true;
            this.MaintenanceIdTextBox.Name = "MaintenanceIdTextBox";
            this.MaintenanceIdTextBox.ReadOnly = true;
            this.MaintenanceIdTextBox.Size = new System.Drawing.Size(133, 35);
            this.MaintenanceIdTextBox.TabIndex = 78;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Modern No. 20", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(24)))), ((int)(((byte)(158)))));
            this.label2.Location = new System.Drawing.Point(78, 241);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(307, 30);
            this.label2.TabIndex = 77;
            this.label2.Text = "Enter Maintenance Id : ";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dateTimePicker1.Location = new System.Drawing.Point(452, 359);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker1.TabIndex = 68;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(24)))), ((int)(((byte)(158)))));
            this.label1.Location = new System.Drawing.Point(78, 351);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(336, 30);
            this.label1.TabIndex = 76;
            this.label1.Text = "Enter Maintenance Date : ";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.Font = new System.Drawing.Font("Modern No. 20", 30.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(24)))), ((int)(((byte)(158)))));
            this.label4.Location = new System.Drawing.Point(63, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(607, 66);
            this.label4.TabIndex = 75;
            this.label4.Text = "Enter Maintenance Info : ";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // OKButton
            // 
            this.OKButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.OKButton.Font = new System.Drawing.Font("Modern No. 20", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OKButton.Location = new System.Drawing.Point(140, 506);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(210, 57);
            this.OKButton.TabIndex = 74;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CancelButton.Font = new System.Drawing.Font("Modern No. 20", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelButton.Location = new System.Drawing.Point(368, 506);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(210, 57);
            this.CancelButton.TabIndex = 73;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // costLabel
            // 
            this.costLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.costLabel.AutoSize = true;
            this.costLabel.Font = new System.Drawing.Font("Modern No. 20", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.costLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(24)))), ((int)(((byte)(158)))));
            this.costLabel.Location = new System.Drawing.Point(78, 297);
            this.costLabel.Name = "costLabel";
            this.costLabel.Size = new System.Drawing.Size(320, 30);
            this.costLabel.TabIndex = 71;
            this.costLabel.Text = "Enter Mantenance Cost : ";
            // 
            // CarIdTextBox
            // 
            this.CarIdTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CarIdTextBox.BackColor = System.Drawing.Color.White;
            this.CarIdTextBox.Location = new System.Drawing.Point(488, 193);
            this.CarIdTextBox.Multiline = true;
            this.CarIdTextBox.Name = "CarIdTextBox";
            this.CarIdTextBox.ReadOnly = true;
            this.CarIdTextBox.Size = new System.Drawing.Size(133, 35);
            this.CarIdTextBox.TabIndex = 70;
            this.CarIdTextBox.TextChanged += new System.EventHandler(this.CarIdTextBox_TextChanged);
            // 
            // CarIdLabel
            // 
            this.CarIdLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CarIdLabel.AutoSize = true;
            this.CarIdLabel.Font = new System.Drawing.Font("Modern No. 20", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CarIdLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(24)))), ((int)(((byte)(158)))));
            this.CarIdLabel.Location = new System.Drawing.Point(78, 190);
            this.CarIdLabel.Name = "CarIdLabel";
            this.CarIdLabel.Size = new System.Drawing.Size(192, 30);
            this.CarIdLabel.TabIndex = 69;
            this.CarIdLabel.Text = "Enter Car Id : ";
            // 
            // MaintenanceCostTextBox
            // 
            this.MaintenanceCostTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.MaintenanceCostTextBox.Location = new System.Drawing.Point(488, 297);
            this.MaintenanceCostTextBox.Multiline = true;
            this.MaintenanceCostTextBox.Name = "MaintenanceCostTextBox";
            this.MaintenanceCostTextBox.Size = new System.Drawing.Size(133, 35);
            this.MaintenanceCostTextBox.TabIndex = 79;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Modern No. 20", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(24)))), ((int)(((byte)(158)))));
            this.label3.Location = new System.Drawing.Point(78, 402);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(333, 30);
            this.label3.TabIndex = 80;
            this.label3.Text = "Enter Maintenance Info : ";
            // 
            // MaintenanceIdRichTextBox
            // 
            this.MaintenanceIdRichTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.MaintenanceIdRichTextBox.Location = new System.Drawing.Point(485, 409);
            this.MaintenanceIdRichTextBox.Name = "MaintenanceIdRichTextBox";
            this.MaintenanceIdRichTextBox.Size = new System.Drawing.Size(133, 61);
            this.MaintenanceIdRichTextBox.TabIndex = 81;
            this.MaintenanceIdRichTextBox.Text = "";
            // 
            // GetCarIdButton
            // 
            this.GetCarIdButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.GetCarIdButton.Font = new System.Drawing.Font("Modern No. 20", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GetCarIdButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(24)))), ((int)(((byte)(158)))));
            this.GetCarIdButton.Location = new System.Drawing.Point(662, 193);
            this.GetCarIdButton.Name = "GetCarIdButton";
            this.GetCarIdButton.Size = new System.Drawing.Size(122, 35);
            this.GetCarIdButton.TabIndex = 82;
            this.GetCarIdButton.Text = "Get Car Id";
            this.GetCarIdButton.UseVisualStyleBackColor = true;
            this.GetCarIdButton.Click += new System.EventHandler(this.GetCarIdButton_Click);
            // 
            // MaintenanceInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 620);
            this.Controls.Add(this.GetCarIdButton);
            this.Controls.Add(this.MaintenanceIdRichTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.MaintenanceCostTextBox);
            this.Controls.Add(this.MaintenanceIdTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.costLabel);
            this.Controls.Add(this.CarIdTextBox);
            this.Controls.Add(this.CarIdLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MaintenanceInfoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MaintenanceInfoForm";
            this.Load += new System.EventHandler(this.MaintenanceInfoForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox MaintenanceIdTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Label costLabel;
        private System.Windows.Forms.TextBox CarIdTextBox;
        private System.Windows.Forms.Label CarIdLabel;
        private System.Windows.Forms.TextBox MaintenanceCostTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox MaintenanceIdRichTextBox;
        private System.Windows.Forms.Button GetCarIdButton;
    }
}