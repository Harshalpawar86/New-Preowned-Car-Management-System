using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Preowned_Car_Management_System
{
    public partial class HistoryDetailForm : Form
    {
        String connectionString = DashBoardForm.connectionString;
        long carId;

        public HistoryDetailForm(long carId)
        {
            InitializeComponent();
            this.carId = carId;
        }

        private void HistoryDetailForm_Load(object sender, EventArgs e)
        {
            LoadHistoryDetails();
        }
        
        private void LoadHistoryDetails()
        {
            int staffId = 0;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM HistoryTable WHERE CarId = @CarId";

                
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CarId", carId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        if (reader.Read())
                        {
                            pictureBox1.Image = ConvertToImage((byte[])reader["CarImage"]);
                            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                            CarNameLabel.Text = $"Car Name: {reader["CarName"].ToString()}";
                            CarIdTextBox.Text = $"Car Id: {reader["CarId"].ToString()}";
                            OwnerLabel.Text = $"Owner Type: {reader["OwnerType"].ToString()}";
                            SellerNameLabel.Text = $"Seller Name: {reader["SupplierName"].ToString()}";
                            SellerIdLabel.Text = $"Seller Id: {reader["SupplierId"].ToString()}";
                            BuyerNameLabel.Text = $"Buyer Name: {reader["BuyerName"].ToString()}";
                            BuyerIdLabel.Text = $"Buyer Id: {reader["BuyerId"].ToString()}";
                            SellingAmtLabel.Text = $"Selling Amount : {reader["AmountPaid"].ToString()}";
                            BuyingAmountLabel.Text = $"Buying Amount : {reader["AmountRecieved"].ToString()}";
                            SellingDateTextBox.Text = $"Selling Date : {reader["PurchaseDate"].ToString()}";
                            double amt = Convert.ToDouble(reader["ProfitOrLoss"]);
                            if (amt > 0)
                            {
                                AmountLabel.ForeColor = Color.LimeGreen;
                                AmountLabel.Text = $"Profit : {reader["ProfitOrLoss"].ToString()}";
                            }
                            else {

                                AmountLabel.ForeColor = Color.Red;
                                AmountLabel.Text = $"Loss : {reader["ProfitOrLoss"].ToString()}";
                            }
                            SellerNumberLabel.Text = $"Seller Mobile Number: {reader["SupplierMobileNumber"].ToString()}";
                            BuyerMobileLabel.Text = $"Buyer Mobile Number: {reader["BuyerMobileNumber"].ToString()}";
                            //label13.Text = $"Supplier Address: {reader["SupplierAddress"].ToString()}";
                            //label14.Text = $"Buyer Address: {reader["BuyerAddress"].ToString()}";
                            CarInfoLabel.Text = $"Car Info: {reader["CarInfo"].ToString()}";
                            staffId = Convert.ToInt32(reader["StaffId"]);

                            if (reader["MaintenanceId"] == DBNull.Value || reader["MaintenanceId"].ToString() == "0" || string.IsNullOrEmpty(reader["MaintenanceId"].ToString()))
                            {
                                MaintenanceIdLabel.Text = "Maintenance Id : N/A";
                            }
                            else
                            {
                                MaintenanceIdLabel.Text = $"Maintenance Id: {reader["MaintenanceId"].ToString()}";
                            }
                            if (MaintenanceIdLabel.Text == "Maintenance Id : N/A") {
                                MaintenanceInfoLabel.Text = "Maintenance Information : N/A";
                            }
                        }
                    }
                    

                }
                conn.Close();
            }
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    String query = "SELECT * FROM StaffTable WHERE StaffId = @StaffId";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@StaffId", staffId);
                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            if (reader.Read()) { 
                                StaffNameLabel.Text = $"Staff Name : {reader["StaffName"].ToString()}";
                                StaffIdLabel.Text = $"Staff Id : {reader["StaffId"].ToString()}";
                                StaffMobileLabel.Text = $"Staff Mobile Number : {reader["StaffNumber"].ToString()}";
                            }
                        }

                    }
                }
            }
            catch (Exception ex) {

                MessageBox.Show("Error No staff Id Doesnt Exist "+staffId+"\n"+ex.Message);
            }
        }

        private Image ConvertToImage(byte[] image)
        {
            using (MemoryStream ms = new MemoryStream(image))
            {
                return Image.FromStream(ms);
            }
        }



        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CarNameLabel_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MaintenanceInfoLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
