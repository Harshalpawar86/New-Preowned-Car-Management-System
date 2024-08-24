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
        public String buyerId { set; get; }
        public String mobileNumber { set; get; }
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

        private void OKButton_Click(object sender, EventArgs e)
        {
            buyerName = BuyerNameTextBox.Text;
            carName = CarNameTextBox.Text;
            buyerId = BuyerIdTextBox.Text;
            mobileNumber = MobileNumberTextBox.Text;
            address = AddressTextBox.Text;
            DialogResult = DialogResult.OK;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
