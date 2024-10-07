namespace Preowned_Car_Management_System
{
    partial class AddAccessoriesForm
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
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.OKButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.photo_button = new System.Windows.Forms.Button();
            this.photo_label = new System.Windows.Forms.Label();
            this.AccessoriesNameTextBox = new System.Windows.Forms.TextBox();
            this.CarNameLabel = new System.Windows.Forms.Label();
            this.AccessoriesCountTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dateTimePicker1.Location = new System.Drawing.Point(438, 243);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker1.TabIndex = 50;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(106)))), ((int)(((byte)(255)))));
            this.label1.Location = new System.Drawing.Point(64, 235);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(292, 30);
            this.label1.TabIndex = 65;
            this.label1.Text = "Enter Purchase Date : ";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.Font = new System.Drawing.Font("Modern No. 20", 30.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(106)))), ((int)(((byte)(255)))));
            this.label4.Location = new System.Drawing.Point(50, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(607, 66);
            this.label4.TabIndex = 62;
            this.label4.Text = "Enter Accessories Details : ";
            // 
            // OKButton
            // 
            this.OKButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.OKButton.Font = new System.Drawing.Font("Modern No. 20", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OKButton.Location = new System.Drawing.Point(151, 419);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(210, 57);
            this.OKButton.TabIndex = 57;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CancelButton.Font = new System.Drawing.Font("Modern No. 20", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelButton.Location = new System.Drawing.Point(379, 419);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(210, 57);
            this.CancelButton.TabIndex = 56;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // photo_button
            // 
            this.photo_button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.photo_button.Font = new System.Drawing.Font("Modern No. 20", 8.799999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.photo_button.Location = new System.Drawing.Point(474, 354);
            this.photo_button.Name = "photo_button";
            this.photo_button.Size = new System.Drawing.Size(133, 30);
            this.photo_button.TabIndex = 55;
            this.photo_button.Text = "Add Image";
            this.photo_button.UseVisualStyleBackColor = true;
            this.photo_button.Click += new System.EventHandler(this.photo_button_Click);
            // 
            // photo_label
            // 
            this.photo_label.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.photo_label.AutoSize = true;
            this.photo_label.Font = new System.Drawing.Font("Modern No. 20", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.photo_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(106)))), ((int)(((byte)(255)))));
            this.photo_label.Location = new System.Drawing.Point(64, 354);
            this.photo_label.Name = "photo_label";
            this.photo_label.Size = new System.Drawing.Size(325, 30);
            this.photo_label.TabIndex = 54;
            this.photo_label.Text = "Enter Accessories Photo: ";
            // 
            // AccessoriesNameTextBox
            // 
            this.AccessoriesNameTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AccessoriesNameTextBox.Location = new System.Drawing.Point(474, 179);
            this.AccessoriesNameTextBox.Multiline = true;
            this.AccessoriesNameTextBox.Name = "AccessoriesNameTextBox";
            this.AccessoriesNameTextBox.Size = new System.Drawing.Size(133, 35);
            this.AccessoriesNameTextBox.TabIndex = 52;
            // 
            // CarNameLabel
            // 
            this.CarNameLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CarNameLabel.AutoSize = true;
            this.CarNameLabel.Font = new System.Drawing.Font("Modern No. 20", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CarNameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(106)))), ((int)(((byte)(255)))));
            this.CarNameLabel.Location = new System.Drawing.Point(64, 176);
            this.CarNameLabel.Name = "CarNameLabel";
            this.CarNameLabel.Size = new System.Drawing.Size(327, 30);
            this.CarNameLabel.TabIndex = 51;
            this.CarNameLabel.Text = "Enter Accessories Name : ";
            // 
            // AccessoriesCountTextBox
            // 
            this.AccessoriesCountTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AccessoriesCountTextBox.Location = new System.Drawing.Point(474, 293);
            this.AccessoriesCountTextBox.Multiline = true;
            this.AccessoriesCountTextBox.Name = "AccessoriesCountTextBox";
            this.AccessoriesCountTextBox.Size = new System.Drawing.Size(133, 35);
            this.AccessoriesCountTextBox.TabIndex = 67;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Modern No. 20", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(106)))), ((int)(((byte)(255)))));
            this.label2.Location = new System.Drawing.Point(64, 290);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(331, 30);
            this.label2.TabIndex = 66;
            this.label2.Text = "Enter Accessories Count : ";
            // 
            // AddAccessoriesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 620);
            this.Controls.Add(this.AccessoriesCountTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.photo_button);
            this.Controls.Add(this.photo_label);
            this.Controls.Add(this.AccessoriesNameTextBox);
            this.Controls.Add(this.CarNameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddAccessoriesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddAccessoriesForm";
            this.Load += new System.EventHandler(this.AddAccessoriesForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button photo_button;
        private System.Windows.Forms.Label photo_label;
        private System.Windows.Forms.TextBox AccessoriesNameTextBox;
        private System.Windows.Forms.Label CarNameLabel;
        private System.Windows.Forms.TextBox AccessoriesCountTextBox;
        private System.Windows.Forms.Label label2;
    }
}