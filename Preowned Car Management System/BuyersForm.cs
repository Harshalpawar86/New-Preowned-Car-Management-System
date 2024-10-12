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
    public partial class BuyersForm : Form
    {
        String connectionString = DashBoardForm.connectionString;
        ContextMenuStrip contextMenu;
        public BuyersForm()
        {
            InitializeComponent();
            contextMenu = new ContextMenuStrip();
            contextMenu.Items.Add("Update Information", null, ContextMenuOption1_Click);
            contextMenu.Items.Add("Delete Buyer", null, ContextMenuOption2_Click);
        }
        public void AddBuyerInfoFun(string buyerName, string carName, long buyerId, long mobileNumber, string address)
        {
            Panel panel = new Panel();
            panel.Name = "BuyerData";
            panel.BackColor = Color.White;
            panel.AutoSize = true;
            panel.Tag = buyerId;
            panel.Margin = new Padding(10);
            panel.Padding = new Padding(10);
            panel.BorderStyle = BorderStyle.FixedSingle;

            Label label1 = new Label();
            label1.Name = "BuyerNameLabel";
            label1.Text = "Buyer Name : "+buyerName;
            label1.Location = new Point(12, 5);
            label1.ForeColor = Color.Black;
            label1.Font = new Font(this.Font.FontFamily, 9.5f, FontStyle.Regular);
            label1.AutoSize = true;

            Label label2 = new Label();
            label2.Name = "CarNameLabel";
            label2.Text = "Car Name : "+carName;
            label2.Location = new Point(12, label1.Bottom + 5);
            label2.ForeColor = Color.Black;
            label2.Font = new Font(this.Font.FontFamily, 9.5f, FontStyle.Regular);
            label2.AutoSize = true;

            Label label3 = new Label();
            label3.Name = "BuyerIdLabel";
            label3.Text = "Buyer Id : "+buyerId.ToString();
            label3.Location = new Point(12, label2.Bottom + 5);
            label3.ForeColor = Color.Black;
            label3.Font = new Font(this.Font.FontFamily, 9.5f, FontStyle.Regular);
            label3.AutoSize = true;

            Label mobileNumberLabel = new Label();
            mobileNumberLabel.Name = "MobileNumberLabel";
            mobileNumberLabel.Text = "Mobile Number : "+mobileNumber.ToString();
            mobileNumberLabel.Location = new Point(12, label3.Bottom + 5);
            mobileNumberLabel.ForeColor = Color.Black;
            mobileNumberLabel.Font = new Font(this.Font.FontFamily, 9.5f, FontStyle.Regular);
            mobileNumberLabel.AutoSize = true;

            Label addressLabel = new Label();
            addressLabel.Name = "CarInfoLabel";
            addressLabel.Text = "Address : "+address;
            addressLabel.Location = new Point(12, mobileNumberLabel.Bottom + 5);
            addressLabel.ForeColor = Color.Black;
            addressLabel.Font = new Font(this.Font.FontFamily, 9.5f, FontStyle.Regular);
            addressLabel.AutoSize = true;
            addressLabel.Width = 200;
            addressLabel.Height = 100;
            addressLabel.MaximumSize = new Size(200, 0);
            addressLabel.TextAlign = ContentAlignment.TopLeft;
            addressLabel.Padding = new Padding(0);


            panel.Controls.Add(label1);
            panel.Controls.Add(label2);
            panel.Controls.Add(label3);
            panel.Controls.Add(mobileNumberLabel);
            panel.Controls.Add(addressLabel);

            panel.MouseClick += Panel_MouseClick;
            label1.MouseClick += Panel_MouseClick;
            label2.MouseClick += Panel_MouseClick;
            mobileNumberLabel.MouseClick += Panel_MouseClick;
            addressLabel.MouseClick += Panel_MouseClick;
            addressLabel.MouseClick += Panel_MouseClick;

            flowLayoutPanel1.Controls.Add(panel);
        }
        private void ContextMenuOption1_Click(object sender, EventArgs e)
        {

            if (contextMenu.SourceControl is Panel panel)
            {

                long buyerId = (long)panel.Tag;
                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    String query = "SELECT * FROM BuyerTable WHERE BuyerId=@BuyerId";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {

                        cmd.Parameters.AddWithValue("@BuyerId",buyerId );
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            UpdateBuyerDetailsForm updateBuyerDetailsForm = new UpdateBuyerDetailsForm();
                            updateBuyerDetailsForm.buyerName = reader["BuyerName"].ToString();
                            updateBuyerDetailsForm.carName = reader["CarName"].ToString();
                            updateBuyerDetailsForm.mobileNumber = Convert.ToInt64(reader["BuyerMobileNumber"]);
                            updateBuyerDetailsForm.address = reader["BuyerAddress"].ToString();

                            if (updateBuyerDetailsForm.ShowDialog() == DialogResult.OK)
                            {

                                string updateQuery = "UPDATE BuyerTable SET BuyerName = @BuyerName,CarName = @CarName, BuyerMobileNumber = @BuyerMobileNumber, BuyerAddress = @BuyerAddress WHERE BuyerId = @BuyerId";

                                using (SqlCommand upd = new SqlCommand(updateQuery, conn))
                                {

                                    upd.Parameters.AddWithValue("@BuyerName", updateBuyerDetailsForm.buyerName);
                                    upd.Parameters.AddWithValue("@BuyerId", buyerId);
                                    upd.Parameters.AddWithValue("@CarName", updateBuyerDetailsForm.carName);
                                    upd.Parameters.AddWithValue("@BuyerMobileNumber", updateBuyerDetailsForm.mobileNumber);
                                    upd.Parameters.AddWithValue("@BuyerAddress", updateBuyerDetailsForm.address);

                                    reader.Close();
                                    int result = upd.ExecuteNonQuery();
                                    if (result > 0)
                                    {

                                        MessageBox.Show("Buyer Data Updated Successfully");
                                        flowLayoutPanel1.Controls.Clear();
                                        LoadExistingData();
                                    }
                                    else
                                    {

                                        MessageBox.Show("Failed to Update Data");
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
        private void ContextMenuOption2_Click(object sender, EventArgs e)
        {
            DialogResult dresult = MessageBox.Show("Are you sure you want to delete this Buyer?",
                                                          "Confirm Deletion",
                                                          MessageBoxButtons.OKCancel,
                                                          MessageBoxIcon.Warning);
            if (dresult == DialogResult.OK)
            {
                if (contextMenu.SourceControl is Panel panel)
                {

                    long buyerId = (long)panel.Tag;

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {

                        String query = "DELETE FROM BuyerTable WHERE BuyerId = @BuyerId";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {

                            cmd.Parameters.AddWithValue("@BuyerId", buyerId);
                            conn.Open();
                            int result = cmd.ExecuteNonQuery();
                            if (result > 0)
                            {
                                MessageBox.Show("Buyer Data Deleted");
                                flowLayoutPanel1.Controls.Clear();
                                LoadExistingData();
                            }
                        }
                    }
                }
            }

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

        private void AddStockButton_Click(object sender, EventArgs e)
        {
            
        }
        private void LoadExistingData() {

            using (SqlConnection conn = new SqlConnection(connectionString)) {

                String query = "SELECT * FROM BuyerTable";
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query,conn)) { 
                
                    DataTable dataTable = new DataTable();
                    sqlDataAdapter.Fill(dataTable);

                    foreach (DataRow row in dataTable.Rows) { 
                    
                        String buyerName = row["BuyerName"].ToString();
                        long buyerId = Convert.ToInt64(row["BuyerId"]);
                        String carName = row["CarName"].ToString();
                        long mobileNumber = Convert.ToInt64(row["BuyerMobileNumber"]);
                        String address = row["BuyerAddress"].ToString();

                        AddBuyerInfoFun(buyerName: buyerName, carName: carName, buyerId: buyerId, mobileNumber: mobileNumber, address: address);

                    }
                }
            }
        }

        private void BuyersForm_Load(object sender, EventArgs e)
        {
            LoadExistingData();
        }

        private void searchBuyer(String name) {

            flowLayoutPanel1.Controls.Clear();
            try
            {

                String query = "SELECT * FROM BuyerTable WHERE BuyerName=@BuyerName";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("BuyerName", name);
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                String buyerName = reader["BuyerName"].ToString();
                                String carName = reader["CarName"].ToString();
                                long buyerId = Convert.ToInt64(reader["BuyerId"]);
                                long mobileNumber = Convert.ToInt64(reader["BuyerMobileNumber"]);
                                String address = reader["BuyerAddress"].ToString();

                                AddBuyerInfoFun(buyerName: buyerName, carName: carName, buyerId: buyerId, mobileNumber: mobileNumber, address: address);

                            }
                        }
                        else
                        {
                            MessageBox.Show("Supplier not found in the database.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (SearchTextBox.Text == null || SearchTextBox.Text == "")
            {
                MessageBox.Show("Please Enter Buyer Name to Search");

            }
            else
            {
                searchBuyer(SearchTextBox.Text);

            }
        }

        private void AddBuyerButton_Click(object sender, EventArgs e)
        {
            AddBuyerInfoForm addBuyerInfo = new AddBuyerInfoForm();
            if (addBuyerInfo.ShowDialog() == DialogResult.OK)
            {
                String buyerName = addBuyerInfo.buyerName;
                long buyerId = addBuyerInfo.buyerId;
                String carName = addBuyerInfo.carName;
                long mobileNumber = addBuyerInfo.mobileNumber;
                String address = addBuyerInfo.address;
                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    String query = "INSERT INTO BuyerTable(BuyerName,CarName,BuyerId,BuyerMobileNumber,BuyerAddress) VALUES (@BuyerName,@CarName,@BuyerId,@BuyerMobileNumber,@BuyerAddress);";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {

                        cmd.Parameters.AddWithValue("@BuyerName", buyerName);
                        cmd.Parameters.AddWithValue("@CarName", carName);
                        cmd.Parameters.AddWithValue("@BuyerId", buyerId);
                        cmd.Parameters.AddWithValue("@BuyerMobileNumber", mobileNumber);
                        cmd.Parameters.AddWithValue("@BuyerAddress", address);

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

                AddBuyerInfoFun(buyerName: buyerName, carName: carName, buyerId: buyerId, mobileNumber: mobileNumber, address: address);
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            SearchTextBox.Clear();
            LoadExistingData();
        }
    }
}
