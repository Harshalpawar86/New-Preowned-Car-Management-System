using System;
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
        public string name { get; set; }
        public string carName { get; set; }
        public string mobilenum { get; set; }
        public string adress { get; set; }

        public string information { get; set; }
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
            name = OwnerNameTextBox.Text;
            carName = CarNameTextBox.Text;
            mobilenum = MobileNumberTextBox.Text;
            information = VehicleInfoTextBox.Text;
            adress = OwnerAdressTextBox.Text;
            DialogResult = DialogResult.OK;
        }
    }
}
