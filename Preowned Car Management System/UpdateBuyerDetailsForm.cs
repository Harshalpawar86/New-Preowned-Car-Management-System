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
    public partial class UpdateBuyerDetailsForm : Form
    {
        public String buyerName { get; set; }
        public String carName { get; set; }
        public long mobileNumber { get; set; }
        public String address { get; set;}
        public UpdateBuyerDetailsForm()
        {
            InitializeComponent();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (ValidateData())
            {

                buyerName = BuyerNameTextBox.Text;
                carName = CarNameTextBox.Text;
                mobileNumber = Convert.ToInt64(MobileNumberTextBox.Text);
                address = AddressTextBox.Text;

                DialogResult = DialogResult.OK;

            }
            else {

                MessageBox.Show("Please Enter Valid Data");
            }
        }
            private bool ValidateData()
            {
            return !string.IsNullOrEmpty(BuyerNameTextBox.Text) &&
                   !string.IsNullOrEmpty(CarNameTextBox.Text) &&
                   long.TryParse(MobileNumberTextBox.Text, out _) &&
                   !string.IsNullOrEmpty(AddressTextBox.Text);
            }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void UpdateBuyerDetailsForm_Load(object sender, EventArgs e)
        {
            BuyerNameTextBox.Text = buyerName;
            CarNameTextBox.Text = carName;
            MobileNumberTextBox.Text=mobileNumber.ToString();
            AddressTextBox.Text = address.ToString();
        }
    }
}
