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
                            label1.Text = $"Car Name: {reader["CarName"].ToString()}";
                            label2.Text = $"Car Id: {reader["CarId"].ToString()}";
                            label3.Text = $"Owner Type: {reader["OwnerType"].ToString()}";
                            label4.Text = $"Supplier Name: {reader["SupplierName"].ToString()}";
                            label5.Text = $"Supplier Id: {reader["SupplierId"].ToString()}";
                            label6.Text = $"Buyer Name: {reader["BuyerName"].ToString()}";
                            label7.Text = $"Buyer Id: {reader["BuyerId"].ToString()}";
                            label8.Text = $"Amount Paid: {reader["AmountPaid"].ToString()}";
                            label9.Text = $"Amount Received: {reader["AmountRecieved"].ToString()}";
                            label10.Text = $"Profit: {reader["ProfitOrLoss"].ToString()}";
                            label11.Text = $"Supplier Mobile Number: {reader["SupplierMobileNumber"].ToString()}";
                            label12.Text = $"Buyer Mobile Number: {reader["BuyerMobileNumber"].ToString()}";
                            label13.Text = $"Supplier Address: {reader["SupplierAddress"].ToString()}";
                            label14.Text = $"Buyer Address: {reader["BuyerAddress"].ToString()}";
                            label15.Text = $"Car Info: {reader["CarInfo"].ToString()}";
                            label16.Text = $"Staff Member: {reader["StaffMember"].ToString()}";

                            if (reader["MaintenanceId"] == DBNull.Value || reader["MaintenanceId"].ToString() == "0" || string.IsNullOrEmpty(reader["MaintenanceId"].ToString()))
                            {
                                label17.Text = "Maintenance Id : N/A";
                            }
                            else
                            {
                                label17.Text = $"Maintenance Id: {reader["MaintenanceId"].ToString()}";
                            }
                        }
                    }

                }
            }
        }

        private Image ConvertToImage(byte[] image)
        {
            using (MemoryStream ms = new MemoryStream(image))
            {
                return Image.FromStream(ms);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
