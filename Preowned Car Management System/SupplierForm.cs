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
    public partial class SupplierForm : Form
    {
        ContextMenuStrip contextMenu;
        String connectionString = DashBoardForm.connectionString;
        //Trust Server Certificate=True
        public SupplierForm()
        {
            InitializeComponent();
            contextMenu = new ContextMenuStrip();
            contextMenu.Items.Add("Update Information", null, ContextMenuOption1_Click);
            contextMenu.Items.Add("Delete Supplier", null, ContextMenuOption2_Click);
        }
        public void AddSupplierInfo(string supplierName, string carName, double amountPaid,long carId, long supplierId, long mobileNumber, string address)
        {
            Panel panel = new Panel();
            panel.Name = "SupplierData";
            panel.BackColor = Color.White;
            panel.AutoSize = true;
            panel.Margin = new Padding(10);
            panel.Tag = carId;
            panel.Padding = new Padding(10);
            panel.BorderStyle = BorderStyle.FixedSingle;

            Label label1 = new Label();
            label1.Name = "SupplierNameLabel";
            label1.Text = "Supplier Name : "+supplierName;
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
            label3.Name = "CarIdLabel";
            label3.Text = "Car Id : "+carId;
            label3.Location = new Point(12, label2.Bottom + 5);
            label3.ForeColor = Color.Black;
            label3.Font = new Font(this.Font.FontFamily, 9.5f, FontStyle.Regular);
            label3.AutoSize = true;

            Label supplierIdLabel = new Label();
            supplierIdLabel.Name = "SupplierIdLabel";
            supplierIdLabel.Text = "Supplier Id : "+supplierId;
            supplierIdLabel.Location = new Point(12, label3.Bottom + 5);
            supplierIdLabel.ForeColor = Color.Black;
            supplierIdLabel.Font = new Font(this.Font.FontFamily, 9.5f, FontStyle.Regular);
            supplierIdLabel.AutoSize = true;

            Label mobileNumberLabel = new Label();
            mobileNumberLabel.Name = "MobileNumberLabel";
            mobileNumberLabel.Text = "Mobile Number : "+mobileNumber;
            mobileNumberLabel.Location = new Point(12, supplierIdLabel.Bottom + 5);
            mobileNumberLabel.ForeColor = Color.Black;
            mobileNumberLabel.Font = new Font(this.Font.FontFamily, 9.5f, FontStyle.Regular);
            mobileNumberLabel.AutoSize = true;

            Label addressLabel = new Label();
            addressLabel.Name = "CarInfoLabel";
            addressLabel.Text = "Supplier Address : "+address;
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
            panel.Controls.Add(supplierIdLabel);
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
        private void ContextMenuOption2_Click(object sender, EventArgs e)
        {
            DialogResult dresult = MessageBox.Show("Are you sure you want to delete this supplier?",
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

                        String query = "DELETE FROM SupplierTable WHERE CarId = @CarId";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {

                            cmd.Parameters.AddWithValue("@CarId", carId);
                            conn.Open();
                            int result = cmd.ExecuteNonQuery();
                            if (result > 0)
                            {
                                MessageBox.Show("Supplier Data Deleted");
                                flowLayoutPanel1.Controls.Clear();
                                LoadExistingData();
                            }
                        }
                    }
                }
            }

        }
        private void ContextMenuOption1_Click(object sender, EventArgs e) {

            if (contextMenu.SourceControl is Panel panel) {

                long carId = (long)panel.Tag;
                using (SqlConnection conn = new SqlConnection(connectionString)) {

                    String query = "SELECT * FROM SupplierTable WHERE CarId=@CarId";
                    using (SqlCommand cmd = new SqlCommand(query,conn)) {

                        cmd.Parameters.AddWithValue("@CarId",carId);
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read()) { 
                        
                            UpdateSupplierInfoForm updateSupplierInfoForm = new UpdateSupplierInfoForm();
                            updateSupplierInfoForm.supplierName = reader["SupplierName"].ToString();
                            updateSupplierInfoForm.carName = reader["CarName"].ToString();
                            updateSupplierInfoForm.mobileNumber = Convert.ToInt64(reader["SupplierMobileNumber"]);
                            updateSupplierInfoForm.address = reader["SupplierAddress"].ToString();
                            updateSupplierInfoForm.amountPaid = Convert.ToDouble(reader["AmountPaid"]);

                            if (updateSupplierInfoForm.ShowDialog() == DialogResult.OK) {

                                string updateQuery = "UPDATE SupplierTable SET SupplierName = @SupplierName, CarName = @CarName, SupplierMobileNumber = @SupplierMobileNumber, AmountPaid = @AmountPaid, SupplierAddress = @SupplierAddress WHERE CarId = @CarId";

                                using (SqlCommand upd = new SqlCommand(updateQuery,conn)) {

                                    upd.Parameters.AddWithValue("@SupplierName", updateSupplierInfoForm.supplierName);
                                    upd.Parameters.AddWithValue("@CarName", updateSupplierInfoForm.carName);
                                    upd.Parameters.AddWithValue("@SupplierMobileNumber", updateSupplierInfoForm.mobileNumber);
                                    upd.Parameters.AddWithValue("@AmountPaid", updateSupplierInfoForm.amountPaid);
                                    upd.Parameters.AddWithValue("@SupplierAddress", updateSupplierInfoForm.address);
                                    upd.Parameters.AddWithValue("@CarId", carId);

                                    reader.Close();
                                    int result = upd.ExecuteNonQuery();
                                    if (result > 0)
                                    {

                                        MessageBox.Show("Supplier Data Updated Successfully");
                                        flowLayoutPanel1.Controls.Clear();
                                        LoadExistingData();
                                    }
                                    else {

                                        MessageBox.Show("Failed to Update Data");
                                    }
                                }
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
            AddSupplierInfo addSupplierInfo = new AddSupplierInfo();
            if (addSupplierInfo.ShowDialog() == DialogResult.OK)
            {
                String supplierName = addSupplierInfo.supplierName;
                long carId = addSupplierInfo.carId;
                long supplierId = addSupplierInfo.supplierId;
                String carName = addSupplierInfo.carName;
                long mobileNumber = addSupplierInfo.mobileNumber;
                String address = addSupplierInfo.address;
                double amountPaid = addSupplierInfo.amountPaid;

                using (SqlConnection conn = new SqlConnection(connectionString)) {

                    string query = "INSERT INTO SupplierTable (SupplierId, CarId, SupplierName, CarName, SupplierMobileNumber, AmountPaid, SupplierAddress) "+"VALUES (@SupplierId, @CarId, @SupplierName, @CarName, @SupplierMobileNumber, @AmountPaid, @SupplierAddress)";
                    using (SqlCommand cmd = new SqlCommand(query,conn)) {

                        cmd.Parameters.AddWithValue("@SupplierId", addSupplierInfo.supplierId);
                        cmd.Parameters.AddWithValue("@CarId", addSupplierInfo.carId);
                        cmd.Parameters.AddWithValue("@SupplierName", addSupplierInfo.supplierName);
                        cmd.Parameters.AddWithValue("@CarName", addSupplierInfo.carName);
                        cmd.Parameters.AddWithValue("@SupplierMobileNumber", addSupplierInfo.mobileNumber);
                        cmd.Parameters.AddWithValue("@AmountPaid", addSupplierInfo.amountPaid);
                        cmd.Parameters.AddWithValue("@SupplierAddress", addSupplierInfo.address);

                        conn.Open();
                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {

                            MessageBox.Show("Data Inserted Successfully..");
                        }
                        else {

                            MessageBox.Show("Data Insertion Failed..");
                        }
                    }
                }

                    AddSupplierInfo(supplierName: supplierName, carName: carName, amountPaid: amountPaid, carId: carId, supplierId: supplierId, mobileNumber: mobileNumber, address: address);
            }
        }
        private void LoadExistingData() {

            using (SqlConnection conn = new SqlConnection(connectionString)) {

                String query = "SELECT * FROM SupplierTable;";
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query,conn)) {

                    DataTable dataTable = new DataTable();
                    sqlDataAdapter.Fill(dataTable);

                    foreach (DataRow row in dataTable.Rows) {

                        String supplierName = row["SupplierName"].ToString();
                        long carId = Convert.ToInt64(row["CarId"]);
                        long supplierId = Convert.ToInt64(row["SupplierId"]);
                        String carName = row["CarName"].ToString();
                        long mobileNumber = Convert.ToInt64(row["SupplierMobileNumber"]);
                        double amountPaid = Convert.ToDouble(row["AmountPaid"]);
                        String address = row["SupplierAddress"].ToString();

                        AddSupplierInfo(supplierName:supplierName,carId:carId,supplierId:supplierId,carName:carName,mobileNumber:mobileNumber,amountPaid:amountPaid,address:address);
                    }
                }
            }
        }

        private void SupplierForm_Load(object sender, EventArgs e)
        {
                LoadExistingData();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}