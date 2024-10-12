using System;
using System.Collections.Generic;
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
            decimal amt = 0;
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
                            SellingAmtLabel.Text = $"Selling Amount : ₹{reader["AmountPaid"].ToString()}";
                            BuyingAmountLabel.Text = $"Buying Amount : ₹{reader["AmountRecieved"].ToString()}";
                            SellingDateTextBox.Text = $"Selling Date : {reader["PurchaseDate"].ToString()}";
                            amt = Convert.ToDecimal(reader["ProfitOrLoss"]);
                            if (amt > 0)
                            {
                                AmountLabel.ForeColor = Color.LimeGreen;
                                AmountLabel.Text = $"Profit : ₹{reader["ProfitOrLoss"].ToString()}";
                            }
                            else {

                                AmountLabel.ForeColor = Color.Red;
                                AmountLabel.Text = $"Loss : ₹{reader["ProfitOrLoss"].ToString()}";
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
                    conn.Close();
                }
            }
            catch (Exception ex) {

                MessageBox.Show("Error No staff Id Doesnt Exist "+staffId+"\n"+ex.Message);
            }
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT MaintenanceInfo, MaintenanceCost FROM MaintenanceTable WHERE CarId = @CarId";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@CarId", carId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Initialize an empty string for maintenance info and a variable to hold the total cost
                            string maintenanceInfo = "Maintenance Information:\n";
                            decimal totalMaintenanceCost = 0;

                            // Iterate through all the rows for the specific CarId
                            while (reader.Read())
                            {
                                // Retrieve the maintenance info and cost from the current row
                                string info = reader["MaintenanceInfo"].ToString();
                                decimal cost = Convert.ToDecimal(reader["MaintenanceCost"]);

                                // Add this maintenance info to the string
                                maintenanceInfo += $"{info}{Environment.NewLine}";

                                // Accumulate the total maintenance cost
                                totalMaintenanceCost += cost;
                            }

                            // Display the maintenance info and total maintenance cost
                            MaintenanceInfoLabel.Text = maintenanceInfo.TrimEnd();  // To display all the maintenance info
                            decimal mCost = totalMaintenanceCost;  // Display total cost
                            if (mCost != 0)
                            {
                                mCostLabel.Text = "Maintenance Cost : ₹" + mCost.ToString();
                            }
                            else {
                                mCostLabel.ForeColor = Color.FromArgb(0, 106, 255);
                                mCostLabel.Text = "Maintenance Cost : N/A";
                            }
                            decimal tp = (amt - mCost);
                            if (tp>0) {

                                TotalProfitLabel.Text = "Net Profit : "+tp;
                                TotalProfitLabel.ForeColor = Color.LimeGreen;
                            }
                            else{

                                TotalProfitLabel.Text = "Net Loss : " + tp;
                                TotalProfitLabel.ForeColor = Color.Red;
                            }

                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT AccessoryName, AccessoryPrice, AccessorySoldCount, TotalPrice FROM AccessorySales WHERE CarId = @CarId";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@CarId", carId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Dictionary to store accessory names, their counts, and total prices
                            Dictionary<string, (int TotalSoldCount, decimal TotalPrice)> accessoryInfo = new Dictionary<string, (int, decimal)>();

                            // Initialize a variable to hold the total accessory amount
                            decimal totalAccessoryAmount = 0;

                            // Iterate through all the rows in the result set
                            while (reader.Read())
                            {
                                string accessoryName = reader["AccessoryName"].ToString();
                                int accessorySoldCount = reader.GetInt32(reader.GetOrdinal("AccessorySoldCount"));
                                decimal totalPrice = reader.GetDecimal(reader.GetOrdinal("TotalPrice"));

                                // If the accessory name is already in the dictionary, update its count and total price
                                if (accessoryInfo.ContainsKey(accessoryName))
                                {
                                    accessoryInfo[accessoryName] = (
                                        accessoryInfo[accessoryName].TotalSoldCount + accessorySoldCount,
                                        accessoryInfo[accessoryName].TotalPrice + totalPrice
                                    );
                                }
                                else
                                {
                                    // Otherwise, add the accessory name to the dictionary with the sold count and total price
                                    accessoryInfo.Add(accessoryName, (accessorySoldCount, totalPrice));
                                }

                                // Accumulate the total price for all accessories
                                totalAccessoryAmount += totalPrice;
                            }

                            // Initialize an empty string to store the final output
                            string accessoryNames = "Accessory Information:\n";

                            // Build the string from the dictionary
                            foreach (var entry in accessoryInfo)
                            {
                                // Append "AccessoryName - TotalSoldCount [Total Price]"
                                accessoryNames += $"{entry.Key} - {entry.Value.TotalSoldCount} [₹{entry.Value.TotalPrice:F2}]{Environment.NewLine}";
                            }

                            // Display the result
                            AccessoryInformtaionLabel.Text = accessoryNames.TrimEnd();

                            // Optionally, you can display or use the totalAccessoryAmount
                            AccessoryAmountLabel.Text = $"Accessory Amount : ₹{totalAccessoryAmount:F2}";
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception exp)
            {
                // Handle the exception (you can log it or display a message)
                Console.WriteLine(exp.Message);
            }

            // Check if accessory information contains only the header (no actual accessories)
            if (string.IsNullOrWhiteSpace(AccessoryInformtaionLabel.Text) || AccessoryInformtaionLabel.Text == "Accessory Information:")
            {
                AccessoryInformtaionLabel.Text = "Accessory Information: N/A";
            }


            LoadTotalBuyingAmount();



        }
        void loadStaffCommission(decimal amt)
        {
            decimal commission = 100;
            if (amt >= 0)
            {
                commission = (1M * amt) / 100;
            }

            

            StaffComissionLabel.Text = "Staff Commission: ₹" + commission.ToString("F2");
        }
        void LoadTotalBuyingAmount() {

            string buyinglabelText = BuyingAmountLabel.Text;

            string buyingnumericPart = buyinglabelText.Replace("Buying Amount : ", "").Replace("₹", "").Trim();

            decimal buyingamt = Convert.ToDecimal(buyingnumericPart);
            // TotalBuyingAmountLabel.Text = buyingamt.ToString();
            string accessorylabelText = AccessoryAmountLabel.Text;

            string accessorynumericpart = accessorylabelText.Replace("Accessory Amount : ", "").Replace("₹", "").Trim();

            decimal accessoryamt = Convert.ToDecimal(accessorynumericpart);
            // TotalBuyingAmountLabel.Text = accessoryamt.ToString();
            TotalBuyingAmountLabel.Text = "Total Buying Amount : ₹" + (buyingamt + accessoryamt);
            loadStaffCommission(buyingamt + accessoryamt);
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

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
