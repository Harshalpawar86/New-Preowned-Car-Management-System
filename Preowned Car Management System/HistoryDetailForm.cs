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

                    using (SqlDataReader reader = cmd.ExecuteReader()){

                        if (reader.Read()) {
                            pictureBox1.Image = ConvertToImage((byte[])reader["CarImage"]);
                            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                            richTextBox1.Text = $"Supplier Mobile Number : {reader["SupplierMobileNumber"].ToString()}\n" +
                                                $"Buyer Mobile Number : {reader["BuyerMobileNumber"].ToString()}\n" +
                                                $"Supplier Address : {reader["SupplierAddress"].ToString()}\n" +
                                                $"Buyer Address : {reader["BuyerAddress"].ToString()}\n" +
                                                $"Supplier Id : {reader["SupplierId"].ToString()}\n" +
                                                $"Buyer Id : {reader["BuyerId"].ToString()}\n" +
                                                $"Owner Type : {reader["OwnerType"].ToString()}\n" +
                                                $"Car Info : {reader["CarInfo"].ToString()}\n" +
                                                $"Car Id : {reader["CarId"].ToString()}\n" +
                                                $"Car Name : {reader["CarName"].ToString()}\n" +
                                                $"Supplier Name : {reader["SupplierName"].ToString()}\n" +
                                                $"Buyer Name : {reader["BuyerName"].ToString()}\n" +
                                                $"Amount Paid : {reader["AmountPaid"].ToString()}\n" +
                                                $"Amount Received : {reader["AmountRecieved"].ToString()}\n" +
                                                $"Staff Member : {reader["StaffMember"].ToString()}";
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

        
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
