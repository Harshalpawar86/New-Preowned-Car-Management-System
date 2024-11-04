using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Preowned_Car_Management_System
{
    public partial class HistoryForm : Form
    {
        String connectionString = DashBoardForm.connectionString;
        ContextMenuStrip contextMenu;

        public HistoryForm()
        {
            InitializeComponent();
            contextMenu = new ContextMenuStrip();
            contextMenu.Items.Add("Get Detailed Information", null, ContextMenuOption1_Click);
        }
        private void ContextMenuOption1_Click(object sender, EventArgs e) {

            if (contextMenu.SourceControl is Panel panel)
            {
                long carId = (long)panel.Tag;
                HistoryDetailForm detailForm = new HistoryDetailForm(carId);
                detailForm.ShowDialog();
            }
        }

        private void HistoryForm_Load(object sender, EventArgs e)
        {
            LoadHistory();
        }
        private void AddHistoryData(long carId, Image image,String carName,String supplierName,String buyerName) {

            Panel panel = new Panel();
            panel.Name = "HistoryData";
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



            Label SupplierNameLabel = new Label();
            SupplierNameLabel.Name = "SupplierNameLabel";
            SupplierNameLabel.Text = "Supplier Name : " + supplierName;
            SupplierNameLabel.Location = new Point(12, CarNameLabel.Bottom + 5);
            SupplierNameLabel.ForeColor = Color.Black;
            SupplierNameLabel.Font = new Font(this.Font.FontFamily, 9.5f, FontStyle.Regular);
            SupplierNameLabel.AutoSize = true;

            Label BuyerNameLabel = new Label();
            BuyerNameLabel.Name = "BuyerNameLabel";
            BuyerNameLabel.Text = "Buyer Name : " + buyerName;
            BuyerNameLabel.Location = new Point(12, SupplierNameLabel.Bottom + 5);
            BuyerNameLabel.ForeColor = Color.Black;
            BuyerNameLabel.Font = new Font(this.Font.FontFamily, 9.5f, FontStyle.Regular);
            BuyerNameLabel.AutoSize = true;


            panel.Controls.Add(pictureBox);
            panel.Controls.Add(CarNameLabel);
            panel.Controls.Add(SupplierNameLabel);
            panel.Controls.Add(BuyerNameLabel);

            panel.MouseClick += Panel_MouseClick;
            pictureBox.MouseClick += Panel_MouseClick;
            CarNameLabel.MouseClick += Panel_MouseClick;
            SupplierNameLabel.MouseClick += Panel_MouseClick;
            BuyerNameLabel.MouseClick -= Panel_MouseClick;


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
        private void LoadHistory() {

            using (SqlConnection conn = new SqlConnection(connectionString)) {

                conn.Open();
                String query = "SELECT * FROM HistoryTable";
                using (SqlCommand cmd = new SqlCommand(query, conn)) {
                    using (SqlDataReader reader = cmd.ExecuteReader()) {

                        while (reader.Read()) {
                            Image image = ConvertToImage((byte[])reader["CarImage"]);
                            long carId = Convert.ToInt64(reader["CarId"]);
                            String carName = reader["CarName"].ToString();
                            String supplierName = reader["SupplierName"].ToString();
                            String buyerName = reader["BuyerName"].ToString();
                            AddHistoryData(image: image, carId:carId,carName:carName,supplierName:supplierName,buyerName:buyerName);
                        
                        }
                    }
                }
                conn.Close();
            }
        }

        private Image ConvertToImage(byte[] image)
        {
            using (MemoryStream ms = new MemoryStream(image))
            {

                return Image.FromStream(ms);
            }
        }



      
        void searchCar(string carName)
        {
            flowLayoutPanel1.Controls.Clear();
            try
            {
                String query = "SELECT * FROM HistoryTable WHERE CarName=@CarName";

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
                                String carNamedb = reader["CarName"].ToString();
                                Image image = convertFromBytes((byte[])reader["CarImage"]);
                                String supplierName = reader["SupplierName"].ToString();
                                String buyerName = reader["BuyerName"].ToString();

                                AddHistoryData(image: image, carId: carId, carName: carNamedb, supplierName: supplierName, buyerName: buyerName);

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
        private Image convertFromBytes(byte[] imageBytes)
        {

            using (MemoryStream ms = new MemoryStream(imageBytes))
            {

                return Image.FromStream(ms);
            }
        }

     

        private void ClearButton_Click_1(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            SearchTextBox.Clear();
            LoadHistory();
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

        private void SearchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter){
                e.SuppressKeyPress = true;
                SearchButton.PerformClick();
            }
        }
    }
}
