using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
        String connectionString = DashBoardForm.connectionString;
        public String supplierName { set; get; }
        public String carName { set; get; }
        public long carId { set; get; }
        public long supplierId { set; get; }
        public long mobileNumber { set; get; }
        public String address { set; get; }
        public decimal amountPaid { set; get; }

        public AddSupplierInfo()
        {
            InitializeComponent();
        }
        private void LoadCarId()
        {
            long lastCarId = 101;
            string queryStock = "SELECT MAX(CarId) FROM SupplierTable";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(queryStock, conn);
                var result = cmd.ExecuteScalar();

                if (result != DBNull.Value && result != null)
                {
                    lastCarId = Convert.ToInt64(result) + 1;  
                }
                else
                {
                    string queryHistory = "SELECT MAX(CarId) FROM HistoryTable";
                    SqlCommand cmd2 = new SqlCommand(queryHistory, conn);
                    var result2 = cmd2.ExecuteScalar();

                    if (result2 != DBNull.Value && result2 != null)
                    {
                        lastCarId = Convert.ToInt64(result2) + 1;  
                    }
                }
            }

            CarIdTextBox.Text = lastCarId.ToString();
        }
        private void LoadSupplierId()
        {
            long lastSupplierId = 201;
            string queryStock = "SELECT MAX(SupplierId) FROM SupplierTable";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(queryStock, conn);
                var result = cmd.ExecuteScalar();

                if (result != DBNull.Value && result != null)
                {
                    lastSupplierId = Convert.ToInt64(result) + 1;
                }
                else
                {
                    string queryHistory = "SELECT MAX(SupplierId) FROM HistoryTable";
                    SqlCommand cmd2 = new SqlCommand(queryHistory, conn);
                    var result2 = cmd2.ExecuteScalar();

                    if (result2 != DBNull.Value && result2 != null)
                    {
                        lastSupplierId = Convert.ToInt64(result2) + 1;
                    }
                }
            }

            SupplierIdTextBox.Text = lastSupplierId.ToString();
        }


        private void AddSupplierInfo_Load(object sender, EventArgs e)
        {
            LoadCarId();
            LoadSupplierId();
        }
        void getData() {
            supplierName = SupplierNameTextBox.Text;
            carName = CarNameTextBox.Text;
            supplierId = long.Parse(SupplierIdTextBox.Text);
            mobileNumber = long.Parse(MobileNumberTextBox.Text);
            amountPaid = decimal.Parse(AmountPaidTextBox.Text);
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
                long mobileNumber = form.mobileNumber;
                String address = form.address;

                SupplierNameTextBox.Text = supplierName;
                MobileNumberTextBox.Text = mobileNumber.ToString();
                AddressTextBox.Text = address.ToString();
            }
        }
    }
}