using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Preowned_Car_Management_System
{
    public partial class AddBuyerInfoForm : Form
    {
        String connectionString = DashBoardForm.connectionString;
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
            LoadBuyerId();
        }
        private void LoadBuyerId()
        {
            long lastBuyerId = 301;
            string queryStock = "SELECT MAX(BuyerId) FROM BuyerTable";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(queryStock, conn);
                var result = cmd.ExecuteScalar();

                if (result != DBNull.Value && result != null)
                {
                    lastBuyerId = Convert.ToInt64(result) + 1;
                }
                else
                {
                    string queryHistory = "SELECT MAX(BuyerId) FROM HistoryTable";
                    SqlCommand cmd2 = new SqlCommand(queryHistory, conn);
                    var result2 = cmd2.ExecuteScalar();

                    if (result2 != DBNull.Value && result2 != null)
                    {
                        lastBuyerId = Convert.ToInt64(result2) + 1;
                    }
                }
            }

            BuyerIdTextBox.Text = lastBuyerId.ToString();
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



                MessageBox.Show("Please Enter All Fields..", "Input Required",
    MessageBoxButtons.OK,
    MessageBoxIcon.Warning,
    MessageBoxDefaultButton.Button1);
            }
            else if (MobileNumberTextBox.Text.Length != 10)
            {

                MessageBox.Show("Please Enter Valid Mobile Number..", "Invalid Input",
    MessageBoxButtons.OK,
    MessageBoxIcon.Warning,
    MessageBoxDefaultButton.Button1);
            }
            else if (exception == false)
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Please Enter Valid Data..", "Invalid Input",
    MessageBoxButtons.OK,
    MessageBoxIcon.Warning,
    MessageBoxDefaultButton.Button1);
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void ExistingBuyerLabel_Click(object sender, EventArgs e)
        {
            {
                ExistingBuyerForm form = new ExistingBuyerForm();
                if (form.ShowDialog() == DialogResult.OK)
                {
                    String supplierName = form.buyerName;
                    long mobileNumber = form.mobileNumber;
                    String address = form.address;

                    BuyerNameTextBox.Text = supplierName;
                    MobileNumberTextBox.Text = mobileNumber.ToString();
                    AddressTextBox.Text = address.ToString();
                }
            }
        }

        private void BuyerNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                CarNameTextBox.Focus();
            }
        }

        private void CarNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                MobileNumberTextBox.Focus();
            }
        }

        private void MobileNumberTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                AddressTextBox.Focus();
            }
        }

        private void AddressTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                OKButton.Focus();
            }
        }
    }
}
