namespace Preowned_Car_Management_System
{
    partial class AddStockPopupForm
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
            this.CarInfoTextBox = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.OKButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.photo_button = new System.Windows.Forms.Button();
            this.photo_label = new System.Windows.Forms.Label();
            this.car_label = new System.Windows.Forms.Label();
            this.CarNameTextBox = new System.Windows.Forms.TextBox();
            this.CarNameLabel = new System.Windows.Forms.Label();
            this.CarIdTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SupplierIdTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.OwnerTypeTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // CarInfoTextBox
            // 
            this.CarInfoTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CarInfoTextBox.Location = new System.Drawing.Point(546, 536);
            this.CarInfoTextBox.Name = "CarInfoTextBox";
            this.CarInfoTextBox.Size = new System.Drawing.Size(161, 71);
            this.CarInfoTextBox.TabIndex = 41;
            this.CarInfoTextBox.Text = "";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Modern No. 20", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(24)))), ((int)(((byte)(158)))));
            this.label3.Location = new System.Drawing.Point(165, 536);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 30);
            this.label3.TabIndex = 39;
            this.label3.Text = "Car Info : ";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Modern No. 20", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(24)))), ((int)(((byte)(158)))));
            this.label2.Location = new System.Drawing.Point(164, 456);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(259, 30);
            this.label2.TabIndex = 38;
            this.label2.Text = "Enter Owner Type : ";
            // 
            // OKButton
            // 
            this.OKButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.OKButton.Font = new System.Drawing.Font("Modern No. 20", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OKButton.Location = new System.Drawing.Point(275, 663);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(125, 42);
            this.OKButton.TabIndex = 36;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CancelButton.Font = new System.Drawing.Font("Modern No. 20", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelButton.Location = new System.Drawing.Point(411, 663);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(125, 42);
            this.CancelButton.TabIndex = 35;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // photo_button
            // 
            this.photo_button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.photo_button.Font = new System.Drawing.Font("Modern No. 20", 8.799999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.photo_button.Location = new System.Drawing.Point(574, 408);
            this.photo_button.Name = "photo_button";
            this.photo_button.Size = new System.Drawing.Size(133, 30);
            this.photo_button.TabIndex = 34;
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
            this.photo_label.Location = new System.Drawing.Point(164, 408);
            this.photo_label.Name = "photo_label";
            this.photo_label.Size = new System.Drawing.Size(230, 30);
            this.photo_label.TabIndex = 33;
            this.photo_label.Text = "Enter Car Photo: ";
            // 
            // car_label
            // 
            this.car_label.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.car_label.AutoSize = true;
            this.car_label.Font = new System.Drawing.Font("Modern No. 20", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.car_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(24)))), ((int)(((byte)(158)))));
            this.car_label.Location = new System.Drawing.Point(164, 228);
            this.car_label.Name = "car_label";
            this.car_label.Size = new System.Drawing.Size(192, 30);
            this.car_label.TabIndex = 31;
            this.car_label.Text = "Enter Car Id : ";
            // 
            // CarNameTextBox
            // 
            this.CarNameTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CarNameTextBox.Location = new System.Drawing.Point(574, 180);
            this.CarNameTextBox.Multiline = true;
            this.CarNameTextBox.Name = "CarNameTextBox";
            this.CarNameTextBox.Size = new System.Drawing.Size(133, 35);
            this.CarNameTextBox.TabIndex = 30;
            // 
            // CarNameLabel
            // 
            this.CarNameLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CarNameLabel.AutoSize = true;
            this.CarNameLabel.Font = new System.Drawing.Font("Modern No. 20", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CarNameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(24)))), ((int)(((byte)(158)))));
            this.CarNameLabel.Location = new System.Drawing.Point(164, 177);
            this.CarNameLabel.Name = "CarNameLabel";
            this.CarNameLabel.Size = new System.Drawing.Size(232, 30);
            this.CarNameLabel.TabIndex = 29;
            this.CarNameLabel.Text = "Enter Car Name : ";
            this.CarNameLabel.Click += new System.EventHandler(this.name_label_Click);
            // 
            // CarIdTextBox
            // 
            this.CarIdTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CarIdTextBox.Location = new System.Drawing.Point(574, 235);
            this.CarIdTextBox.Multiline = true;
            this.CarIdTextBox.Name = "CarIdTextBox";
            this.CarIdTextBox.Size = new System.Drawing.Size(133, 35);
            this.CarIdTextBox.TabIndex = 43;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.Font = new System.Drawing.Font("Modern No. 20", 30.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(24)))), ((int)(((byte)(158)))));
            this.label4.Location = new System.Drawing.Point(187, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(474, 66);
            this.label4.TabIndex = 45;
            this.label4.Text = "Enter Stock Details : ";
            // 
            // SupplierIdTextBox
            // 
            this.SupplierIdTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SupplierIdTextBox.Location = new System.Drawing.Point(574, 285);
            this.SupplierIdTextBox.Multiline = true;
            this.SupplierIdTextBox.Name = "SupplierIdTextBox";
            this.SupplierIdTextBox.Size = new System.Drawing.Size(133, 35);
            this.SupplierIdTextBox.TabIndex = 47;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Modern No. 20", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(24)))), ((int)(((byte)(158)))));
            this.label5.Location = new System.Drawing.Point(164, 278);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(256, 30);
            this.label5.TabIndex = 46;
            this.label5.Text = "Enter Supplier Id : ";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(24)))), ((int)(((byte)(158)))));
            this.label1.Location = new System.Drawing.Point(164, 343);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 30);
            this.label1.TabIndex = 48;
            this.label1.Text = "Enter Car Date : ";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(507, 348);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // OwnerTypeTextBox
            // 
            this.OwnerTypeTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.OwnerTypeTextBox.Location = new System.Drawing.Point(574, 456);
            this.OwnerTypeTextBox.Multiline = true;
            this.OwnerTypeTextBox.Name = "OwnerTypeTextBox";
            this.OwnerTypeTextBox.Size = new System.Drawing.Size(133, 35);
            this.OwnerTypeTextBox.TabIndex = 49;
            // 
            // AddStockPopupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(863, 735);
            this.Controls.Add(this.OwnerTypeTextBox);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SupplierIdTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CarIdTextBox);
            this.Controls.Add(this.CarInfoTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.photo_button);
            this.Controls.Add(this.photo_label);
            this.Controls.Add(this.car_label);
            this.Controls.Add(this.CarNameTextBox);
            this.Controls.Add(this.CarNameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddStockPopupForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddStockPopupForm";
            this.Load += new System.EventHandler(this.AddStockPopupForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox CarInfoTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button photo_button;
        private System.Windows.Forms.Label photo_label;
        private System.Windows.Forms.Label car_label;
        private System.Windows.Forms.TextBox CarNameTextBox;
        private System.Windows.Forms.Label CarNameLabel;
        private System.Windows.Forms.TextBox CarIdTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox SupplierIdTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox OwnerTypeTextBox;
    }
}