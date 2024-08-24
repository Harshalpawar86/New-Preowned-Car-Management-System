﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Preowned_Car_Management_System
{
    public partial class AddStockPopupForm : Form
    {
        public String ImagePath { get; set; }
        public String carName { get; set; }
        public String carId { get; set; }
        public String supplierId { get; set; }
        public String ownerType { get; set; }
        public String carDate { get; set; }
        public String carInfo { get; set; }


        public AddStockPopupForm()
        {
            InitializeComponent();
        }

        private void photo_button_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {

                openFileDialog.Filter = "Image Files|*.jpg;*.png;*.jpeg;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {

                    ImagePath = openFileDialog.FileName;

                }
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void AddStockPopupForm_Load(object sender, EventArgs e)
        {

        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            carName = CarNameTextBox.Text;
            carId = CarIdTextBox.Text;
            supplierId = SupplierIdTextBox.Text;
            carDate = dateTimePicker1.Value.ToString("dd / MM / yyyy");
            ownerType = OwnerTypeTextBox.Text;
            carInfo = CarInfoTextBox.Text;
            DialogResult = DialogResult.OK;
        }

        private void name_label_Click(object sender, EventArgs e)
        {

        }
    }
}
