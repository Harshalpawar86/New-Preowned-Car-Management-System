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
        public long carId { set; get; }
        public long supplierId { set; get; }
        public long mobileNumber { set; get; }
        public String address { set; get; }
        public double amountPaid { set; get; }

        public AddSupplierInfo()
        {
            InitializeComponent();
        }

        private void AddSupplierInfo_Load(object sender, EventArgs e)
        {

        }
        void getData() {
            supplierName = SupplierNameTextBox.Text;
            carName = CarNameTextBox.Text;
            supplierId = long.Parse(SupplierIdTextBox.Text);
            mobileNumber = long.Parse(MobileNumberTextBox.Text);
            amountPaid = double.Parse(AmountPaidTextBox.Text);
            address = AddressTextBox.Text;
            carId = long.Parse(CarIdTextBox.Text);

        }
        private void OKButton_Click(object sender, EventArgs e)
        {
            bool exception = false;
            try
            {
                getData();
                exception = false;
            }
            catch (Exception exp) {
                exception = true;
                MessageBox.Show(exp.ToString());
            }
            if (SupplierNameTextBox.Text == "" || AmountPaidTextBox.Text==""||CarNameTextBox.Text == "" || SupplierIdTextBox.Text == "" || MobileNumberTextBox.Text == "" || AddressTextBox.Text == "") {

                MessageBox.Show("Please Enter All Fields..");
            } else if (MobileNumberTextBox.Text.Length!=10) {

                MessageBox.Show("Please Enter Valid Mobile Number..");
            }else if (exception == false)
            {
                DialogResult = DialogResult.OK;
            } else {
                MessageBox.Show("Please Enter Valid Data..");
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void ExistingSupplierLabel_Click(object sender, EventArgs e)
        {
            ExistingSupplierForm form = new ExistingSupplierForm("ForSupplier");
            if (form.ShowDialog()==DialogResult.OK) {
                String supplierName = form.supplierName;
                long supplierId = form.supplierId;
                long mobileNumber = form.mobileNumber;
                String address = form.address;

                SupplierNameTextBox.Text = supplierName;
                SupplierIdTextBox.Text=supplierId.ToString();
                MobileNumberTextBox.Text = mobileNumber.ToString();
                AddressTextBox.Text = address.ToString();
            }
        }
    }
}