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
    public partial class UpdateSupplierInfoForm : Form
    {
        public String supplierName { set; get; }
        public String carName { set; get; }
        public long mobileNumber { set; get; }
        public String address { set; get; }
        public decimal amountPaid { set; get; }
        public UpdateSupplierInfoForm()
        {
            InitializeComponent();
        }

        private void UpdateSupplierInfoForm_Load(object sender, EventArgs e)
        {
            SupplierNameTextBox.Text = supplierName;
            CarNameTextBox.Text = carName;
            MobileNumberTextBox.Text = mobileNumber.ToString();
            AddressTextBox.Text = address;
            AmountPaidTextBox.Text = amountPaid.ToString();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (ValidateData())
            {

                supplierName = SupplierNameTextBox.Text;
                carName = CarNameTextBox.Text;
                mobileNumber = Convert.ToInt64(MobileNumberTextBox.Text);
                address = AddressTextBox.Text;
                amountPaid = Convert.ToDecimal(AmountPaidTextBox.Text);

                DialogResult = DialogResult.OK;
            }
            else {

                MessageBox.Show("Please Enter Valid Data", "Invalid Input",
    MessageBoxButtons.OK,
    MessageBoxIcon.Warning,
    MessageBoxDefaultButton.Button1);
            }
        }
        private bool ValidateData()
        {
            // Implement validation logic, e.g., ensure fields are not empty
            return !string.IsNullOrEmpty(SupplierNameTextBox.Text) &&
                   !string.IsNullOrEmpty(CarNameTextBox.Text) &&
                   long.TryParse(MobileNumberTextBox.Text, out _) &&
                   !string.IsNullOrEmpty(AddressTextBox.Text) &&
                   decimal.TryParse(AmountPaidTextBox.Text, out _);
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
