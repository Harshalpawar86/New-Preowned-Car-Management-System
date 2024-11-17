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
    public partial class AddAccessoriesForm : Form
    {
        String connectionString = DashBoardForm.connectionString;
        public String ImagePath { get; set; }
        public String accessoriesName { get; set; }
        public String accessoriesDate { get; set; }
        public decimal accessoriesPrice { get; set; }
        public long accessoryId { get; set; }

        public int accessoriesCount { get; set; }
        bool noException = false;
        bool getImage = false;

        public AddAccessoriesForm()
        {
            InitializeComponent();
        }
        void getData()
        {

            accessoriesName = AccessoriesNameTextBox.Text;
            accessoriesDate = dateTimePicker1.Value.Date.ToString("d");
            accessoriesCount = Convert.ToInt32(AccessoriesCountTextBox.Text);
            accessoriesPrice = Convert.ToDecimal(PriceTextBox.Text);
            accessoryId = Convert.ToInt64(AccessoryIdTextBox.Text);
        }
        private void OKButton_Click(object sender, EventArgs e)
        {


            noException = false;
            if (ValidateData())
            {
                try
                {
                    getData();
                    noException = true;
                }
                catch (Exception exp)
                {

                    noException = false;
                }
            }
            else
            {

                MessageBox.Show("Please Enter Valid Data", "Error",
    MessageBoxButtons.OK,
    MessageBoxIcon.Error,
    MessageBoxDefaultButton.Button1);
            }
            if (getImage == false)
            {

                MessageBox.Show("Please Select image", "Image Selection Required", MessageBoxButtons.OK,
    MessageBoxIcon.Information,
    MessageBoxDefaultButton.Button1);
            }
            if (noException == true && getImage == true)
            {
                DialogResult = DialogResult.OK;
            }



        }
        private bool ValidateData()
        {

            return !string.IsNullOrEmpty(AccessoriesNameTextBox.Text) &&
                   int.TryParse(AccessoriesCountTextBox.Text, out _) &&
                   decimal.TryParse(PriceTextBox.Text, out _) &&
                   !string.IsNullOrEmpty(dateTimePicker1.Text);
        }
        private void photo_button_Click(object sender, EventArgs e)
        {
            getImage = false;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {

                openFileDialog.Filter = "Image Files|*.jpg;*.png;*.jpeg;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {

                    ImagePath = openFileDialog.FileName;
                    getImage = true;

                    OKButton.Focus();


                }
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void AddAccessoriesForm_Load(object sender, EventArgs e)
        {
            LoadAccessoryId();
        }
        void LoadAccessoryId()
        {



            long lastaccessoryId = 601;
            string queryStock = "SELECT MAX(AccessoryId) FROM AccessoryTable";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(queryStock, conn);
                var result = cmd.ExecuteScalar();

                if (result != DBNull.Value && result != null)
                {
                    lastaccessoryId = Convert.ToInt64(result) + 1;
                }
                else
                {
                    string queryHistory = "SELECT MAX(AccessoryId) FROM AccessorySales";
                    SqlCommand cmd2 = new SqlCommand(queryHistory, conn);
                    var result2 = cmd2.ExecuteScalar();

                    if (result2 != DBNull.Value && result2 != null)
                    {
                        lastaccessoryId = Convert.ToInt64(result2) + 1;
                    }
                }
            }

            AccessoryIdTextBox.Text = lastaccessoryId.ToString();

        }

        private void AccessoriesNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                AccessoriesCountTextBox.Focus();
            }
        }

        private void AccessoriesCountTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                PriceTextBox.Focus();
            }
        }

        private void PriceTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                photo_button.Focus();
            }
        }
    }
}
