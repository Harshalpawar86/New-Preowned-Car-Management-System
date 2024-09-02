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
    public partial class AddBuyerInfoForm : Form
    {
        public String buyerName { set; get; }
        public String carName { set; get; }
        public long buyerId { set; get; }
        public long mobileNumber { set; get; }
        public String address { set; get; }
        public AddBuyerInfoForm()
        {
            InitializeComponent();
        }

        private void AddBuyerInfoForm_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void getData() {

            
            buyerName = BuyerNameTextBox.Text;
            carName = CarNameTextBox.Text;
            buyerId = long.Parse(BuyerIdTextBox.Text);
            mobileNumber = long.Parse(MobileNumberTextBox.Text);
            address = AddressTextBox.Text;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {


            bool exception = false;
            try
            {
                getData();
                exception = false;
            }
            catch (Exception exp)
            {
                exception = true;
            }
            if (BuyerNameTextBox.Text == "" || BuyerIdTextBox.Text == "" || CarNameTextBox.Text == "" || MobileNumberTextBox.Text == "" || AddressTextBox.Text == "")
            {

                MessageBox.Show("Please Enter All Fields..");
            }
            else if (MobileNumberTextBox.Text.Length != 10)
            {

                MessageBox.Show("Please Enter Valid Mobile Number..");
            }
            else if (exception == false)
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Please Enter Valid Data..");
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
