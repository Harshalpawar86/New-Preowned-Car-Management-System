using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Preowned_Car_Management_System
{
    public partial class AddSupplierInfo : Form
    {
        public String supplierName { set; get; }
        public String carName { set; get; }
        public String carId { set; get; }
        public String supplierId { set; get; }
        public String mobileNumber { set; get; }
        public String address { set; get; }

        public AddSupplierInfo()
        {
            InitializeComponent();
        }

        private void AddSupplierInfo_Load(object sender, EventArgs e)
        {

        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            supplierName = SupplierNameTextBox.Text;
            carName = CarNameTextBox.Text;
            carId = CarIdTextBox.Text;
            supplierId = SupplierIdTextBox.Text;
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