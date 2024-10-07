using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Preowned_Car_Management_System
{
    public partial class StockForm : Form
    {
        String connectionString = DashBoardForm.connectionString;
        ContextMenuStrip contextMenu;

        public StockForm()
        {
            InitializeComponent();
            contextMenu = new ContextMenuStrip();
            contextMenu.Items.Add("Update Information", null, ContextMenuOption1_Click);
            contextMenu.Items.Add("Sell Car", null, ContextMenuOption2_Click);
            contextMenu.Items.Add("Delete Car", null, ContextMenuOption3_Click);
        }
        public void AddStockInfo(String carName, long carId,long supplierId ,String carDate, Image image, String ownerType,double purchaseAmount, String carInfoLabel)
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
            pictureBox.Size = new Size(200,150);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;

            pictureBox.Image = image;

            Label CarNameLabel = new Label();
            CarNameLabel.Name = "CarNameLabel";
            CarNameLabel   .Text = "Car Name : "+carName;
            CarNameLabel.Location = new Point(12, pictureBox.Bottom+5);
            CarNameLabel.ForeColor = Color.Black;
            CarNameLabel.Font = new Font(this.Font.FontFamily, 9.5f, FontStyle.Regular);
            CarNameLabel.AutoSize = true;

            Label CarIdLabel = new Label();
            CarIdLabel.Name = "CarIdLabel";
            CarIdLabel.Text = "Car Id : "+carId;
            CarIdLabel.Location = new Point(12, CarNameLabel.Bottom + 5);
            CarIdLabel.ForeColor = Color.Black;
            CarIdLabel.Font = new Font(this.Font.FontFamily, 9.5f, FontStyle.Regular);
            CarIdLabel.AutoSize = true;

            Label SupplierIdLabel = new Label();
            SupplierIdLabel.Name = "SupplierIdLabel";
            SupplierIdLabel.Text = "Supplier Id : "+supplierId;
            SupplierIdLabel.Location = new Point(12, CarIdLabel.Bottom + 5);
            SupplierIdLabel.ForeColor = Color.Black;
            SupplierIdLabel.Font = new Font(this.Font.FontFamily, 9.5f, FontStyle.Regular);
            SupplierIdLabel.AutoSize = true;

            Label CarDateLabel = new Label();
            CarDateLabel.Name = "CarDateLabel";
            CarDateLabel.Text = "Purchased Date : "+carDate;
            CarDateLabel.Location = new Point(12, SupplierIdLabel.Bottom + 5);
            CarDateLabel.ForeColor = Color.Black;
            CarDateLabel.Font = new Font(this.Font.FontFamily, 9.5f, FontStyle.Regular);
            CarDateLabel.AutoSize = true;

            Label OwnerTypeLabel = new Label();
            OwnerTypeLabel.Name = "OwnerTypeLabel";
            OwnerTypeLabel.Text = "Owner Type : "+ownerType;
            OwnerTypeLabel.Location = new Point(12, CarDateLabel.Bottom + 5);
            OwnerTypeLabel.ForeColor = Color.Black;
            OwnerTypeLabel.Font = new Font(this.Font.FontFamily, 9.5f, FontStyle.Regular);
            OwnerTypeLabel.AutoSize = true;

            Label PurchaseAmountLabel = new Label();
            PurchaseAmountLabel.Name = "PurchaseAmountLabel";
            PurchaseAmountLabel.Text = "Purchase Amount : "+purchaseAmount;
            PurchaseAmountLabel.Location = new Point(12, OwnerTypeLabel.Bottom + 5);
            PurchaseAmountLabel.ForeColor = Color.Black;
            PurchaseAmountLabel.Font = new Font(this.Font.FontFamily, 9.5f, FontStyle.Regular);
            PurchaseAmountLabel.AutoSize = true;

            Label vehicleInfoLabel = new Label();
            vehicleInfoLabel.Name = "CarInfoLabel";
            vehicleInfoLabel.Text = "Car Information : "+carInfoLabel;
            vehicleInfoLabel.Location = new Point(12, PurchaseAmountLabel.Bottom + 5);
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
            panel.Controls.Add(vehicleInfoLabel);

            panel.MouseClick += Panel_MouseClick;
            pictureBox.MouseClick += Panel_MouseClick;
            CarNameLabel.MouseClick += Panel_MouseClick;
            CarIdLabel.MouseClick += Panel_MouseClick;
            PurchaseAmountLabel.MouseClick -= Panel_MouseClick;
            CarDateLabel.MouseClick += Panel_MouseClick;
            OwnerTypeLabel.MouseClick += Panel_MouseClick;
            SupplierIdLabel.MouseClick += Panel_MouseClick;
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
        private void ContextMenuOption1_Click(object sender, EventArgs e) {

            if (contextMenu.SourceControl is Panel panel) {

                long carId = (long)panel.Tag;
                using (SqlConnection conn = new SqlConnection(connectionString)) {

                    String query = "SELECT * FROM StockTable WHERE CarId = @CarId ";
                    using (SqlCommand cmd = new SqlCommand(query,conn)) {

                        cmd.Parameters.AddWithValue("@CarId",carId);
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read()) { 
                        
                            UpdateStockForm updateStockForm = new UpdateStockForm();
                            updateStockForm.carName = reader["CarName"].ToString();
                            updateStockForm.purchaseAmount = Convert.ToInt64(reader["PurchaseAmount"]);
                            updateStockForm.image = convertFromBytes((byte[])reader["CarImage"]);
                            updateStockForm.ownerType = reader["OwnerType"].ToString();
                            updateStockForm.carInfo = reader["CarInfo"].ToString();

                            if (updateStockForm.ShowDialog()==DialogResult.OK) {

                                String updateQuery = "UPDATE StockTable SET CarName = @CarName, PurchaseAmount = @PurchaseAmount, CarImage = @CarImage, OwnerType = @OwnerType, CarInfo = @CarInfo WHERE CarId = @CarId";
                                using (SqlCommand upd = new SqlCommand(updateQuery,conn)) {

                                    upd.Parameters.AddWithValue("@CarName",updateStockForm.carName);
                                    upd.Parameters.AddWithValue("@PurchaseAmount",updateStockForm.purchaseAmount);
                                    upd.Parameters.AddWithValue("@CarImage",convertToByte(updateStockForm.image));
                                    upd.Parameters.AddWithValue("@OwnerType", updateStockForm.ownerType);
                                    upd.Parameters.AddWithValue("@CarInfo", updateStockForm.carInfo);
                                    upd.Parameters.AddWithValue("@CarId",carId);

                                    reader.Close();
                                    int result = upd.ExecuteNonQuery();
                                    if (result > 0)
                                    {

                                        MessageBox.Show("Stock Data Updated Successfully");
                                        flowLayoutPanel1.Controls.Clear();
                                        LoadExistingData();
                                    }
                                    else
                                    {

                                        MessageBox.Show("Failed to Update Data");
                                    }

                                }
                                String updateQuery2 = "UPDATE SupplierTable SET CarName = @CarName WHERE CarId=@CarId";
                                using (SqlCommand upd = new SqlCommand(updateQuery2, conn))
                                {

                                    upd.Parameters.AddWithValue("@CarName", updateStockForm.carName);
                                    upd.Parameters.AddWithValue("@CarId", carId);
                                    reader.Close();
                                    int result = upd.ExecuteNonQuery();
                                   

                                }
                            }
                        }
                    }
                }
            }
        }
        private void ContextMenuOption2_Click(object sender, EventArgs e)
        {

            SellCarForm form = new SellCarForm();
            if (form.ShowDialog()==DialogResult.OK) {
                
                flowLayoutPanel1.Controls.Clear();
                LoadExistingData();
            }
            
        }
        private void ContextMenuOption3_Click(object sender, EventArgs e)
        {

            DialogResult dresult = MessageBox.Show("Are you sure you want to delete this Stock ?",
                                                          "Confirm Deletion",
                                                          MessageBoxButtons.OKCancel,
                                                          MessageBoxIcon.Warning);
            if (dresult == DialogResult.OK)
            {
                if (contextMenu.SourceControl is Panel panel)
                {

                    long carId = (long)panel.Tag;

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {

                        String query = "DELETE FROM StockTable WHERE CarId = @CarId";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {

                            cmd.Parameters.AddWithValue("@CarId", carId);
                            conn.Open();
                            int result = cmd.ExecuteNonQuery();
                            if (result > 0)
                            {
                                MessageBox.Show("Stock Data Deleted");
                                flowLayoutPanel1.Controls.Clear();
                                LoadExistingData();
                            }
                        }
                    }
                }
            }
        }
        private void LoadExistingData() {
            try
            {

                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    String query = "SELECT * FROM StockTable";
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, conn))
                    {

                        DataTable dataTable = new DataTable();
                        sqlDataAdapter.Fill(dataTable);

                        foreach (DataRow row in dataTable.Rows)
                        {

                            string carName = row["CarName"].ToString();
                            long carId = Convert.ToInt64(row["CarId"]);
                            long supplierId = Convert.ToInt64(row["SupplierId"]);
                            string carDate = row["PurchaseDate"].ToString();
                            Image image = convertFromBytes((byte[])row["CarImage"]);
                            string ownerType = row["OwnerType"].ToString();
                            string carInfoLabel = row["CarInfo"].ToString();
                            double purchaseAmount = Convert.ToDouble(row["PurchaseAmount"]);

                            AddStockInfo(carName: carName, carId: carId, supplierId: supplierId, carDate: carDate, image: image, ownerType: ownerType, carInfoLabel: carInfoLabel, purchaseAmount: purchaseAmount);

                        }
                    }
                }
            }
            catch (Exception exp) {

                MessageBox.Show(exp.ToString());
            }
        }
        private Image convertFromBytes(byte[] imageBytes) {

            using (MemoryStream ms = new MemoryStream(imageBytes)) {

                return Image.FromStream(ms);
            }
        }
        private byte[] convertToByte(Image image) {

            using (MemoryStream ms = new MemoryStream())
            {

                image.Save(ms, image.RawFormat);
                return ms.ToArray();
            }
        }
        private byte[] convertImage(String imageString) {

            Image image = Image.FromFile(imageString);

            using (MemoryStream ms = new MemoryStream()) {

                image.Save(ms,image.RawFormat);
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
            try {

                String query = "SELECT * FROM StockTable WHERE CarName=@CarName";

                using (SqlConnection conn = new SqlConnection(connectionString)) {
                    using (SqlCommand cmd = new SqlCommand(query,conn)) {
                        cmd.Parameters.AddWithValue("CarName",carName);
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
                                double purchaseAmount = Convert.ToDouble(reader["PurchaseAmount"]);
                                AddStockInfo(carName: carName, carId: carId, supplierId: supplierId, carDate: carDate, image: image, ownerType: ownerType, carInfoLabel: carInfoLabel, purchaseAmount: purchaseAmount);

                            }
                        }
                        else
                        {
                            MessageBox.Show("Car not found in the database.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }

            } catch (Exception e) {

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
                double purchaseAmount = addStockPopupForm.purchaseAmount;

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

                            MessageBox.Show("Data Inserted Successfully");
                        }
                        else
                        {

                            MessageBox.Show("Data Insertion Failed");
                        }
                    }
                }

                AddStockInfo(carName: carName, carId: carId, supplierId: supplierId, carDate: carDate, image: Image.FromFile(imageString), ownerType: ownerType, carInfoLabel: carInfoLabel, purchaseAmount: purchaseAmount);
            }
        }

        private void SearchButton_Click_1(object sender, EventArgs e)
        {
            if (SearchTextBox.Text == null || SearchTextBox.Text == "")
            {
                MessageBox.Show("Please Enter Car Name to Search");

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
    }
}