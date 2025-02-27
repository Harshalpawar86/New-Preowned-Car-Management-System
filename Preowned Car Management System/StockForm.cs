﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Preowned_Car_Management_System
{

    public partial class StockForm : Form
    {
        String connectionString = DashBoardForm.connectionString;
        ContextMenuStrip contextMenu;
        public static List<CarData> carDataList = null;  // Class-level list to hold the data

        public StockForm()
        {
            InitializeComponent();
            contextMenu = new ContextMenuStrip();
            contextMenu.Items.Add("Add Accessories", null, ContextMenuOption1_Click);
            contextMenu.Items.Add("Update Information", null, ContextMenuOption2_Click);
            contextMenu.Items.Add("Sell Car", null, ContextMenuOption3_Click);
        }
        public void AddStockInfo(String carName, long carId, long supplierId, String carDate, Image image, String ownerType, decimal purchaseAmount, String carInfoLabel, String accCount = "N/A")
        {
            Panel panel = new Panel();
            panel.Name = "StockData";
            panel.BackColor = Color.White;
            panel.AutoSize = true;
            panel.Margin = new Padding(10);
            panel.Tag = carId;
            panel.Padding = new Padding(10);
            panel.BorderStyle = BorderStyle.FixedSingle;

            PictureBox pictureBox = new PictureBox();
            pictureBox.Padding = new Padding(10);
            pictureBox.Name = "StockImage";
            pictureBox.Size = new Size(200, 150);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;

            pictureBox.Image = image;

            Label CarNameLabel = new Label();
            CarNameLabel.Name = "CarNameLabel";
            CarNameLabel.Text = "Car Name : " + carName;
            CarNameLabel.Location = new Point(12, pictureBox.Bottom + 5);
            CarNameLabel.ForeColor = Color.Black;
            CarNameLabel.Font = new Font(this.Font.FontFamily, 9.5f, FontStyle.Regular);
            CarNameLabel.AutoSize = true;

            Label CarIdLabel = new Label();
            CarIdLabel.Name = "CarIdLabel";
            CarIdLabel.Text = "Car Id : " + carId;
            CarIdLabel.Location = new Point(12, CarNameLabel.Bottom + 5);
            CarIdLabel.ForeColor = Color.Black;
            CarIdLabel.Font = new Font(this.Font.FontFamily, 9.5f, FontStyle.Regular);
            CarIdLabel.AutoSize = true;

            Label SupplierIdLabel = new Label();
            SupplierIdLabel.Name = "SupplierIdLabel";
            SupplierIdLabel.Text = "Supplier Id : " + supplierId;
            SupplierIdLabel.Location = new Point(12, CarIdLabel.Bottom + 5);
            SupplierIdLabel.ForeColor = Color.Black;
            SupplierIdLabel.Font = new Font(this.Font.FontFamily, 9.5f, FontStyle.Regular);
            SupplierIdLabel.AutoSize = true;

            Label CarDateLabel = new Label();
            CarDateLabel.Name = "CarDateLabel";
            CarDateLabel.Text = "Purchased Date : " + carDate;
            CarDateLabel.Location = new Point(12, SupplierIdLabel.Bottom + 5);
            CarDateLabel.ForeColor = Color.Black;
            CarDateLabel.Font = new Font(this.Font.FontFamily, 9.5f, FontStyle.Regular);
            CarDateLabel.AutoSize = true;

            Label OwnerTypeLabel = new Label();
            OwnerTypeLabel.Name = "OwnerTypeLabel";
            OwnerTypeLabel.Text = "Owner Type : " + ownerType;
            OwnerTypeLabel.Location = new Point(12, CarDateLabel.Bottom + 5);
            OwnerTypeLabel.ForeColor = Color.Black;
            OwnerTypeLabel.Font = new Font(this.Font.FontFamily, 9.5f, FontStyle.Regular);
            OwnerTypeLabel.AutoSize = true;

            Label PurchaseAmountLabel = new Label();
            PurchaseAmountLabel.Name = "PurchaseAmountLabel";
            PurchaseAmountLabel.Text = "Purchase Amount : " + purchaseAmount;
            PurchaseAmountLabel.Location = new Point(12, OwnerTypeLabel.Bottom + 5);
            PurchaseAmountLabel.ForeColor = Color.Black;
            PurchaseAmountLabel.Font = new Font(this.Font.FontFamily, 9.5f, FontStyle.Regular);
            PurchaseAmountLabel.AutoSize = true;

            Label AccessoryDetailLabel = new Label();
            AccessoryDetailLabel.Name = "AccessoryDetailLabel";
            AccessoryDetailLabel.Text = "Accessories Count : " + accCount;
            AccessoryDetailLabel.Location = new Point(12, PurchaseAmountLabel.Bottom + 2);
            AccessoryDetailLabel.ForeColor = Color.Black;
            AccessoryDetailLabel.Font = new Font(this.Font.FontFamily, 9.5f, FontStyle.Regular);
            AccessoryDetailLabel.AutoSize = true;




            Label vehicleInfoLabel = new Label();
            vehicleInfoLabel.Name = "CarInfoLabel";
            vehicleInfoLabel.Text = "Car Information : " + carInfoLabel;
            vehicleInfoLabel.Location = new Point(12, AccessoryDetailLabel.Bottom + 5);
            vehicleInfoLabel.ForeColor = Color.Black;
            vehicleInfoLabel.Font = new Font(this.Font.FontFamily, 9.5f, FontStyle.Regular);
            vehicleInfoLabel.AutoSize = true;
            vehicleInfoLabel.Width = 200;
            vehicleInfoLabel.Height = 100;
            vehicleInfoLabel.MaximumSize = new Size(200, 0);
            vehicleInfoLabel.TextAlign = ContentAlignment.TopLeft;
            vehicleInfoLabel.Padding = new Padding(0);



            panel.Controls.Add(pictureBox);
            panel.Controls.Add(CarNameLabel);
            panel.Controls.Add(CarIdLabel);
            panel.Controls.Add(PurchaseAmountLabel);
            panel.Controls.Add(SupplierIdLabel);
            panel.Controls.Add(CarDateLabel);
            panel.Controls.Add(OwnerTypeLabel);
            panel.Controls.Add(AccessoryDetailLabel);
            panel.Controls.Add(vehicleInfoLabel);

            panel.MouseClick += Panel_MouseClick;
            pictureBox.MouseClick += Panel_MouseClick;
            CarNameLabel.MouseClick += Panel_MouseClick;
            CarIdLabel.MouseClick += Panel_MouseClick;
            PurchaseAmountLabel.MouseClick -= Panel_MouseClick;
            CarDateLabel.MouseClick += Panel_MouseClick;
            OwnerTypeLabel.MouseClick += Panel_MouseClick;
            SupplierIdLabel.MouseClick += Panel_MouseClick;
            AccessoryDetailLabel.MouseClick += Panel_MouseClick;
            vehicleInfoLabel.MouseClick += Panel_MouseClick;

            flowLayoutPanel1.Controls.Add(panel);
        }
        private void Panel_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Panel panel = sender as Panel;
                if (panel != null)
                {
                    contextMenu.Show(panel, e.Location);
                }
            }
        }

        private void StockForm_Load(object sender, EventArgs e)
        {
            LoadExistingData();
        }
        private void ContextMenuOption1_Click(object sender, EventArgs e)
        {
            if (contextMenu.SourceControl is Panel panel)
            {
                long carId = (long)panel.Tag;

                SellAccessoriesForm form = new SellAccessoriesForm(carId);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    UpdateAccessoryCount(carId);
                    LoadExistingData();
                }
            }
        }
        private void UpdateAccessoryCount(long carId)
        {
            try
            {
                int accessoryCount = 0;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string accQuery = "SELECT COUNT(*) FROM AccessorySales WHERE CarId = @CarId;";
                    using (SqlCommand cmd = new SqlCommand(accQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@CarId", carId);
                        accessoryCount = (int)cmd.ExecuteScalar();
                    }
                }

                // Update the corresponding CarData object in carDataList
                var carData = carDataList.FirstOrDefault(c => c.CarId == carId);
                if (carData != null)
                {
                    carData.AccCount = accessoryCount == 0 ? "N/A" : accessoryCount.ToString();
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("Failed to update accessory count: " + exp.ToString());
            }
        }

        private void ContextMenuOption3_Click(object sender, EventArgs e)
        {

            //SellCarForm form = new SellCarForm();
            //if (form.ShowDialog() == DialogResult.OK)
            //{
            //    flowLayoutPanel1.Controls.Clear();
            //    LoadExistingData();
            //}
            if (contextMenu.SourceControl is Panel panel)
            {
                try
                {
                    long supplierId = 0;
                    // Get the CarId from the panel's Tag
                    long carId = (long)panel.Tag;
                    using (SqlConnection conn = new SqlConnection(connectionString)) {

                        String query = "SELECT SupplierId FROM StockTable WHERE CarId=@CarId";
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand(query,conn)) {

                            cmd.Parameters.AddWithValue("@CarId",carId);
                            var result = cmd.ExecuteScalar();
                            supplierId = (long)result;
                        }
                    }

                        // Show the SellCarForm
                        SellCarForm form = new SellCarForm(carId, supplierId);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        // Remove the car from the list
                        var carData = carDataList.FirstOrDefault(c => c.CarId == carId);
                        if (carData != null)
                        {
                            carDataList.Remove(carData);
                        }

                        // Refresh the UI
                        flowLayoutPanel1.Controls.Clear();
                        LoadExistingData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        private void ContextMenuOption2_Click(object sender, EventArgs e)
        {
            if (contextMenu.SourceControl is Panel panel)
            {
                try
                {
                    long carId = (long)panel.Tag;

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        // Begin a transaction for consistent updates
                        using (SqlTransaction transaction = conn.BeginTransaction())
                        {
                            try
                            {
                                // Fetch data from StockTable
                                string query = "SELECT * FROM StockTable WHERE CarId = @CarId";
                                using (SqlCommand cmd = new SqlCommand(query, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@CarId", carId);
                                    SqlDataReader reader = cmd.ExecuteReader();

                                    if (reader.Read())
                                    {
                                        UpdateStockForm updateStockForm = new UpdateStockForm
                                        {
                                            carName = reader["CarName"].ToString(),
                                            purchaseAmount = Convert.ToInt64(reader["PurchaseAmount"]),
                                            image = convertFromBytes((byte[])reader["CarImage"]),
                                            ownerType = reader["OwnerType"].ToString(),
                                            carInfo = reader["CarInfo"].ToString()
                                        };

                                        reader.Close();

                                        if (updateStockForm.ShowDialog() == DialogResult.OK)
                                        {
                                            // Update StockTable
                                            string updateQuery = @"
                                    UPDATE StockTable
                                    SET CarName = @CarName,
                                        PurchaseAmount = @PurchaseAmount,
                                        CarImage = @CarImage,
                                        OwnerType = @OwnerType,
                                        CarInfo = @CarInfo
                                    WHERE CarId = @CarId";

                                            using (SqlCommand updateCmd = new SqlCommand(updateQuery, conn, transaction))
                                            {
                                                updateCmd.Parameters.AddWithValue("@CarName", updateStockForm.carName);
                                                updateCmd.Parameters.AddWithValue("@PurchaseAmount", updateStockForm.purchaseAmount);
                                                updateCmd.Parameters.AddWithValue("@CarImage", convertToByte(updateStockForm.image));
                                                updateCmd.Parameters.AddWithValue("@OwnerType", updateStockForm.ownerType);
                                                updateCmd.Parameters.AddWithValue("@CarInfo", updateStockForm.carInfo);
                                                updateCmd.Parameters.AddWithValue("@CarId", carId);

                                                int stockResult = updateCmd.ExecuteNonQuery();
                                                if (stockResult == 0)
                                                {
                                                    throw new Exception("No rows updated in StockTable.");
                                                }
                                            }

                                            // Update SupplierTable
                                            string updateQuery2 = @"
                                    UPDATE SupplierTable
                                    SET CarName = @CarName
                                    WHERE CarId = @CarId";

                                            using (SqlCommand updateCmd2 = new SqlCommand(updateQuery2, conn, transaction))
                                            {
                                                updateCmd2.Parameters.AddWithValue("@CarName", updateStockForm.carName);
                                                updateCmd2.Parameters.AddWithValue("@CarId", carId);

                                                int supplierResult = updateCmd2.ExecuteNonQuery();
                                                if (supplierResult == 0)
                                                {
                                                    throw new Exception("No rows updated in SupplierTable.");
                                                }
                                            }

                                            // Commit the transaction if all updates succeed
                                            transaction.Commit();

                                            MessageBox.Show("Stock and Supplier data updated successfully!", "Success",
                                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                                            // Update carDataList
                                            var carData = carDataList.FirstOrDefault(c => c.CarId == carId);
                                            if (carData != null)
                                            {
                                                carData.CarName = updateStockForm.carName;
                                                carData.PurchaseAmount = updateStockForm.purchaseAmount;
                                                carData.CarImage = updateStockForm.image;
                                                carData.OwnerType = updateStockForm.ownerType;
                                                carData.CarInfo = updateStockForm.carInfo;
                                            }

                                            // Refresh the FlowLayoutPanel
                                            flowLayoutPanel1.Controls.Clear();
                                            LoadExistingData();
                                        }
                                    }
                                    else
                                    {
                                        reader.Close();
                                        throw new Exception("CarId not found in StockTable.");
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                // Roll back the transaction in case of an error
                                transaction.Rollback();
                                MessageBox.Show($"Error: {ex.Message}", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception exp)
                {
                    MessageBox.Show($"Unexpected error: {exp.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


            //        if (contextMenu.SourceControl is Panel panel)
            //        {

            //            try { 
            //            long carId = (long)panel.Tag;
            //            using (SqlConnection conn = new SqlConnection(connectionString))
            //            {
            //                conn.Open();

            //                String query = "SELECT * FROM StockTable WHERE CarId = @CarId ";
            //                using (SqlCommand cmd = new SqlCommand(query, conn))
            //                {

            //                    cmd.Parameters.AddWithValue("@CarId", carId);
            //                    SqlDataReader reader = cmd.ExecuteReader();
            //                    if (reader.Read())
            //                    {
            //                        UpdateStockForm updateStockForm = new UpdateStockForm();
            //                        updateStockForm.carName = reader["CarName"].ToString();
            //                        updateStockForm.purchaseAmount = Convert.ToInt64(reader["PurchaseAmount"]);
            //                        updateStockForm.image = convertFromBytes((byte[])reader["CarImage"]);
            //                        updateStockForm.ownerType = reader["OwnerType"].ToString();
            //                        updateStockForm.carInfo = reader["CarInfo"].ToString();

            //                        if (updateStockForm.ShowDialog() == DialogResult.OK)
            //                        {

            //                            String updateQuery = "UPDATE StockTable SET CarName = @CarName, PurchaseAmount = @PurchaseAmount, CarImage = @CarImage, OwnerType = @OwnerType, CarInfo = @CarInfo WHERE CarId = @CarId";

            //                            using (SqlCommand upd = new SqlCommand(updateQuery, conn))
            //                            {

            //                                upd.Parameters.AddWithValue("@CarName", updateStockForm.carName);
            //                                upd.Parameters.AddWithValue("@PurchaseAmount", updateStockForm.purchaseAmount);
            //                                upd.Parameters.AddWithValue("@CarImage", convertToByte(updateStockForm.image));
            //                                upd.Parameters.AddWithValue("@OwnerType", updateStockForm.ownerType);
            //                                upd.Parameters.AddWithValue("@CarInfo", updateStockForm.carInfo);
            //                                upd.Parameters.AddWithValue("@CarId", carId);

            //                                reader.Close();
            //                                int result = upd.ExecuteNonQuery();
            //                                if (result > 0)
            //                                {

            //                                    MessageBox.Show("Stock Data Updated Successfully", "Success",
            //MessageBoxButtons.OK,
            //MessageBoxIcon.Information,
            //MessageBoxDefaultButton.Button1);
            //                                    flowLayoutPanel1.Controls.Clear();
            //                                    LoadExistingData();
            //                                }
            //                                else
            //                                {

            //                                    MessageBox.Show("Failed to Update Data", "Error",
            //MessageBoxButtons.OK,
            //MessageBoxIcon.Error,
            //MessageBoxDefaultButton.Button1);
            //                                }

            //                            }
            //                            String updateQuery2 = "UPDATE SupplierTable SET CarName = @CarName WHERE CarId=@CarId";
            //                            using (SqlCommand upd = new SqlCommand(updateQuery2, conn))
            //                            {

            //                                upd.Parameters.AddWithValue("@CarName", updateStockForm.carName);
            //                                upd.Parameters.AddWithValue("@CarId", carId);
            //                                reader.Close();
            //                                int result = upd.ExecuteNonQuery();


            //                            }
            //                        }
            //                    }
            //                }
            //                conn.Close();
            //            }
            //        }catch(Exception exp){

            //            MessageBox.Show(exp.Message);
            //        }
            //        }

        }

        //private void LoadExistingData() {
        //   flowLayoutPanel1.Controls.Clear();
        //    try
        //    {


        //        using (SqlConnection conn = new SqlConnection(connectionString))
        //        {
        //            conn.Open();
        //            String query = "SELECT * FROM StockTable";
        //            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, conn))
        //            {

        //                DataTable dataTable = new DataTable();
        //                sqlDataAdapter.Fill(dataTable);

        //                foreach (DataRow row in dataTable.Rows)
        //                {
        //                    int count = 0;
        //                    string carName = row["CarName"].ToString();
        //                    long carId = Convert.ToInt64(row["CarId"]);
        //                    long supplierId = Convert.ToInt64(row["SupplierId"]);
        //                    string carDate = row["PurchaseDate"].ToString();
        //                    Image image = convertFromBytes((byte[])row["CarImage"]);
        //                    string ownerType = row["OwnerType"].ToString();
        //                    string carInfoLabel = row["CarInfo"].ToString();

        //                    decimal purchaseAmount = Convert.ToDecimal(row["PurchaseAmount"]);

        //                    String accQuery = "SELECT CarId, COUNT(*) AS Count FROM AccessorySales WHERE CarId = @CarId GROUP BY CarId;";
        //                    using (SqlCommand cmd = new SqlCommand(accQuery, conn))
        //                    {
        //                        cmd.Parameters.AddWithValue("@CarId", carId);


        //                        using (SqlDataReader reader = cmd.ExecuteReader())
        //                        {
        //                            if (reader.Read())
        //                            {
        //                                count = reader.GetInt32(1); // Get the count
        //                               // MessageBox.Show("Accesssory Count : " + count);
        //                            }
        //                        }
        //                    }
        //                    String accCount;
        //                    if (count == 0)
        //                    {

        //                        accCount = "N/A";
        //                    }
        //                    else {

        //                        accCount=count.ToString();
        //                    }
        //                    AddStockInfo(carName: carName, carId: carId, supplierId: supplierId, carDate: carDate, image: image, ownerType: ownerType, carInfoLabel: carInfoLabel, purchaseAmount: purchaseAmount,accCount:accCount);

        //                }
        //            }
        //        }
        //    }
        //    catch (Exception exp) {

        //        MessageBox.Show(exp.ToString());
        //    }
        //}
        private void LoadExistingData()
        {
            flowLayoutPanel1.Controls.Clear();

            // If data is already cached in the list, use it
            if (carDataList != null && carDataList.Count > 0)
            {
                foreach (var car in carDataList)
                {
                    AddStockInfo(
                        carName: car.CarName,
                        carId: car.CarId,
                        supplierId: car.SupplierId,
                        carDate: car.CarDate,
                        image: car.CarImage,
                        ownerType: car.OwnerType,
                        carInfoLabel: car.CarInfo,
                        purchaseAmount: car.PurchaseAmount,
                        accCount: car.AccCount
                    );
                }
                // MessageBox.Show("Retrieved From List");
                return;
            }

            // Data not cached, so load from the database
            try
            {
                carDataList = new List<CarData>();  // Initialize the list

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM StockTable";
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, conn))
                    {
                        DataTable dataTable = new DataTable();
                        sqlDataAdapter.Fill(dataTable);

                        foreach (DataRow row in dataTable.Rows)
                        {
                            int count = 0;
                            string carName = row["CarName"].ToString();
                            long carId = Convert.ToInt64(row["CarId"]);
                            long supplierId = Convert.ToInt64(row["SupplierId"]);
                            string carDate = row["PurchaseDate"].ToString();
                            Image image = convertFromBytes((byte[])row["CarImage"]);
                            string ownerType = row["OwnerType"].ToString();
                            string carInfoLabel = row["CarInfo"].ToString();
                            decimal purchaseAmount = Convert.ToDecimal(row["PurchaseAmount"]);

                            // Retrieve accessory count for each car
                            string accQuery = "SELECT CarId, COUNT(*) AS Count FROM AccessorySales WHERE CarId = @CarId GROUP BY CarId;";
                            using (SqlCommand cmd = new SqlCommand(accQuery, conn))
                            {
                                cmd.Parameters.AddWithValue("@CarId", carId);
                                using (SqlDataReader reader = cmd.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        count = reader.GetInt32(1); // Get the count
                                    }
                                }
                            }

                            // If no accessories found, set the count as "N/A"
                            string accCount = (count == 0) ? "N/A" : count.ToString();

                            // Create a new CarData object and add it to the list
                            CarData carData = new CarData
                            {
                                CarName = carName,
                                CarId = carId,
                                SupplierId = supplierId,
                                CarDate = carDate,
                                CarImage = image,
                                OwnerType = ownerType,
                                CarInfo = carInfoLabel,
                                PurchaseAmount = purchaseAmount,
                                AccCount = accCount
                            };

                            carDataList.Add(carData);  // Add to the cached list

                            // Add the stock info to the form
                            AddStockInfo(carName: carName, carId: carId, supplierId: supplierId, carDate: carDate, image: image, ownerType: ownerType, carInfoLabel: carInfoLabel, purchaseAmount: purchaseAmount, accCount: accCount);
                        }
                    }
                }
                // MessageBox.Show("Retrieved From Database");
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }
        }

        private Image convertFromBytes(byte[] imageBytes)
        {

            using (MemoryStream ms = new MemoryStream(imageBytes))
            {

                return Image.FromStream(ms);
            }
        }
        private byte[] convertToByte(Image image)
        {

            using (MemoryStream ms = new MemoryStream())
            {

                image.Save(ms, image.RawFormat);
                return ms.ToArray();
            }
        }
        private byte[] convertImage(String imageString)
        {

            Image image = Image.FromFile(imageString);

            using (MemoryStream ms = new MemoryStream())
            {

                image.Save(ms, image.RawFormat);
                return ms.ToArray();
            }
        }
        private void AddStockButton_Click(object sender, EventArgs e)
        {


        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        void searchCar(string carName)
        {
            flowLayoutPanel1.Controls.Clear();
            try
            {
                String query = "SELECT * FROM StockTable WHERE CarName=@CarName";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@CarName", carName);
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                long carId = Convert.ToInt64(reader["CarId"]);
                                long supplierId = Convert.ToInt64(reader["SupplierId"]);
                                String carDate = reader["PurchaseDate"].ToString();
                                Image image = convertFromBytes((byte[])reader["CarImage"]);
                                String ownerType = reader["OwnerType"].ToString();
                                String carInfoLabel = reader["CarInfo"].ToString();
                                decimal purchaseAmount = Convert.ToDecimal(reader["PurchaseAmount"]);

                                int count = 0; // Initialize count here

                                // Use a new connection for the accessory count query
                                using (SqlConnection conn2 = new SqlConnection(connectionString))
                                {
                                    String accQuery = "SELECT COUNT(*) AS Count FROM AccessorySales WHERE CarId = @CarId;";

                                    using (SqlCommand cmd2 = new SqlCommand(accQuery, conn2))
                                    {
                                        cmd2.Parameters.AddWithValue("@CarId", carId);
                                        conn2.Open(); // Open the new connection

                                        // Execute the query and retrieve the count
                                        count = (int)cmd2.ExecuteScalar(); // Use ExecuteScalar for a single value
                                    }
                                }

                                String accCount = (count == 0) ? "N/A" : count.ToString();
                                AddStockInfo(carName: carName, carId: carId, supplierId: supplierId, carDate: carDate, image: image, ownerType: ownerType, carInfoLabel: carInfoLabel, purchaseAmount: purchaseAmount, accCount: accCount);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Car not found in the database.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }


        private void SearchButton_Click(object sender, EventArgs e)
        {

        }

        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void ClearButton_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AddStockButton_Click_1(object sender, EventArgs e)
        {
            AddStockPopupForm addStockPopupForm = new AddStockPopupForm();
            if (addStockPopupForm.ShowDialog() == DialogResult.OK)
            {
                string carName = addStockPopupForm.carName;
                long carId = addStockPopupForm.carId;
                long supplierId = addStockPopupForm.supplierId;
                string carDate = addStockPopupForm.carDate;
                String imageString = addStockPopupForm.ImagePath;
                string ownerType = addStockPopupForm.ownerType;
                string carInfoLabel = addStockPopupForm.carInfo;
                decimal purchaseAmount = addStockPopupForm.purchaseAmount;
                MessageBox.Show("" + carId);
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {

                        String query = "INSERT INTO StockTable(CarName,CarId,SupplierId,PurchaseAmount,carImage,PurchaseDate,OwnerType,CarInfo) VALUES (@CarName,@CarId,@SupplierId,@PurchaseAmount,@carImage,@PurchaseDate,@OwnerType,@CarInfo);";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {

                            cmd.Parameters.AddWithValue("@CarName", carName);
                            cmd.Parameters.AddWithValue("@CarId", carId);
                            cmd.Parameters.AddWithValue("@SupplierId", supplierId);
                            cmd.Parameters.AddWithValue("@PurchaseAmount", purchaseAmount);
                            cmd.Parameters.AddWithValue("@carImage", convertImage(imageString));
                            cmd.Parameters.AddWithValue("@PurchaseDate", carDate);
                            cmd.Parameters.AddWithValue("@OwnerType", ownerType);
                            cmd.Parameters.AddWithValue("@CarInfo", carInfoLabel);

                            conn.Open();
                            int result = cmd.ExecuteNonQuery();
                            if (result > 0)
                            {

                                MessageBox.Show("Data Inserted Successfully", "Success",
        MessageBoxButtons.OK,
        MessageBoxIcon.Information,
        MessageBoxDefaultButton.Button1);
                            }
                            else
                            {

                                MessageBox.Show("Data Insertion Failed", "Error",
        MessageBoxButtons.OK,
        MessageBoxIcon.Error,
        MessageBoxDefaultButton.Button1);
                            }
                        }
                    }
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }

                AddStockInfo(carName: carName, carId: carId, supplierId: supplierId, carDate: carDate, image: Image.FromFile(imageString), ownerType: ownerType, carInfoLabel: carInfoLabel, purchaseAmount: purchaseAmount);
                CarData carData = new CarData
                {
                    CarName = carName,
                    CarId = carId,
                    SupplierId = supplierId,
                    CarDate = carDate,
                    CarImage = Image.FromFile(imageString),
                    OwnerType = ownerType,
                    CarInfo = carInfoLabel,
                    PurchaseAmount = purchaseAmount,
                    AccCount = "N/A"
                };

                carDataList.Add(carData);  // Add to the cached list
            }
        }

        private void SearchButton_Click_1(object sender, EventArgs e)
        {
            if (SearchTextBox.Text == null || SearchTextBox.Text == "")
            {
                MessageBox.Show("Please Enter Car Name to Search", "Input Required",
    MessageBoxButtons.OK,
    MessageBoxIcon.Warning,
    MessageBoxDefaultButton.Button1);

            }
            else
            {
                searchCar(SearchTextBox.Text.Trim());

            }
        }

        private void ClearButton_Click_1(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            SearchTextBox.Clear();
            LoadExistingData();
        }

        private void flowLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void SearchTextBox_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void SearchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                e.SuppressKeyPress = true;
                SearchButton.PerformClick();
            }
        }
    }
    public class CarData
    {
        public string CarName { get; set; }
        public long CarId { get; set; }
        public long SupplierId { get; set; }
        public string CarDate { get; set; }
        public Image CarImage { get; set; }
        public string OwnerType { get; set; }
        public string CarInfo { get; set; }
        public decimal PurchaseAmount { get; set; }
        public string AccCount { get; set; }
    }
}