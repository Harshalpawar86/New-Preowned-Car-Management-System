using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Preowned_Car_Management_System
{
    public partial class SelectTransactionDetailsForm : Form
    {
        String connectionString = DashBoardForm.connectionString;
        public Image carImage { get; set; }
        public long supplierMobileNumber{ get; set; }
        public long buyerMobileNumber { get; set; }
        public String supplierAddress { get; set; }
        public String buyerAddress { get; set; }
        public long supplierId { get; set; }
        public long buyerId { get; set; }
        public String ownerType { get; set; }
        public String carInfo { get; set; }
        public long carId { get; set; }
        public String carName { get; set; }
        public String supplierName { get; set; }
        public String buyerName { get; set; }
        public decimal amountPaid { get; set; }
        public decimal amountRecieved { get; set; }
        public String staffMember { get; set; }
        public String purchaseDate { get; set; }
        public decimal profitOrLoss { get; set; }

        public int maintenanceId { get; set; }

        private bool noException1 = false;
        private bool noException2 = false;

        public SelectTransactionDetailsForm()
        {
            InitializeComponent();
            SupplierDataGridView.CellClick += SupplierDataGridView_CellClick;
            BuyerDataGridView.CellClick += BuyerDataGridView_CellClick;
            SupplierDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            BuyerDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (noException1 == true && noException2 == true)
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {

                        conn.Open();
                        string query = "SELECT * FROM StockTable WHERE CarId = @CarId";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {

                            cmd.Parameters.AddWithValue("@CarId", carId);
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {

                                if (reader.Read())
                                {

                                    carImage = convertImage((byte[])reader["CarImage"]);
                                    purchaseDate = reader["PurchaseDate"].ToString();
                                    ownerType = reader["OwnerType"].ToString();
                                    carInfo = reader["CarInfo"].ToString();
                                }
                            }
                        }
                    }
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {

                        conn.Open();
                        string query = "SELECT MaintenanceId FROM MaintenanceTable WHERE CarId = @CarId";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {

                            cmd.Parameters.AddWithValue("@CarId", carId);
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {

                                if (reader.Read())
                                {
                                    maintenanceId = Convert.ToInt32(reader["MaintenanceId"]);
                                }
                            }
                        }
                    }

                    DialogResult = DialogResult.OK;
                }
                else
                {

                    MessageBox.Show("Please Select Data for Both Rows", "Selection Required",
    MessageBoxButtons.OK,
    MessageBoxIcon.Warning,
    MessageBoxDefaultButton.Button1);
                }
            }catch (Exception exp) {

            //    MessageBox.Show(exp.ToString());
            }
        }
        private Image convertImage(byte[] imageData) {

                using (MemoryStream ms = new MemoryStream(imageData))
                {
                    return Image.FromStream(ms);
                }
        }
        private void LoadSupplierData() {


            using (SqlConnection conn = new SqlConnection(connectionString))
            {

                String query = "SELECT * FROM SupplierTable;";
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, conn))
                {

                    DataTable dataTable = new DataTable();
                    sqlDataAdapter.Fill(dataTable);

                    SupplierDataGridView.DataSource = dataTable;
                }
            }
        }
        private void LoadBuyerData() {

            using (SqlConnection conn = new SqlConnection(connectionString))
            {

                String query = "SELECT * FROM BuyerTable;";
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, conn))
                {

                    DataTable dataTable = new DataTable();
                    sqlDataAdapter.Fill(dataTable);

                    BuyerDataGridView.DataSource = dataTable;
                }
            }
        }

        private void SelectTransactionDetailsForm_Load(object sender, EventArgs e)
        {
            LoadSupplierData();
            LoadBuyerData();
            SupplierDataGridView.ClearSelection();
            BuyerDataGridView.ClearSelection();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void SupplierDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            noException1 = false;
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = SupplierDataGridView.Rows[e.RowIndex];

                    supplierId = Convert.ToInt64(row.Cells["SupplierId"].Value);
                    carId = Convert.ToInt64(row.Cells["CarId"].Value);
                    supplierName = row.Cells["SupplierName"].Value.ToString();
                    carName = row.Cells["CarName"].Value.ToString();
                    supplierMobileNumber = Convert.ToInt64(row.Cells["SupplierMobileNumber"].Value);
                    amountPaid = Convert.ToDecimal(row.Cells["AmountPaid"].Value);
                    supplierAddress = row.Cells["SupplierAddress"].Value.ToString();
                    noException1 = true;
                }
            }
            catch (Exception exp)
            {
                noException1 = false;
            }
        }

        private void BuyerDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            noException2 = false;
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = BuyerDataGridView.Rows[e.RowIndex];

                    buyerId = Convert.ToInt64(row.Cells["BuyerId"].Value);
                    buyerName = row.Cells["BuyerName"].Value.ToString();
                    buyerMobileNumber = Convert.ToInt64(row.Cells["BuyerMobileNumber"].Value);
                    buyerAddress = row.Cells["BuyerAddress"].Value.ToString();
                    noException2 = true;
                }
            }
            catch (Exception exp)
            {
                noException2 = false;
            }
        }

        private void SearchSupplierButton_Click(object sender, EventArgs e)
        {

            string searchText = SupplierSearchTextBox.Text;
            SearchSupplier(searchText);
        }

        private void SupplierSearchTextBox_TextChanged(object sender, EventArgs e)
        {
            string searchText = SupplierSearchTextBox.Text;
            SearchSupplier(searchText);
        }
        private void SearchSupplier(string searchText)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM SupplierTable WHERE SupplierName LIKE @SearchText";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SearchText", "%" + searchText + "%");

                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        sqlDataAdapter.Fill(dataTable);

                        SupplierDataGridView.DataSource = dataTable;
                    }
                }
            }
        }

        private void ClearSupplierButton_Click(object sender, EventArgs e)
        {
            SupplierSearchTextBox.Clear();
            SupplierDataGridView.ClearSelection();

        }

        private void SearchBuyersButton_Click(object sender, EventArgs e)
        {
            string searchText = BuyerSearchTextBox.Text;
            SearchBuyer(searchText);
        }
        private void SearchBuyer(string searchText)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM BuyerTable WHERE BuyerName LIKE @SearchText";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SearchText", "%" + searchText + "%");

                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        sqlDataAdapter.Fill(dataTable);

                        BuyerDataGridView.DataSource = dataTable;
                    }
                }
            }
        }

        private void BuyerSearchTextBox_TextChanged(object sender, EventArgs e)
        {
            string searchText = BuyerSearchTextBox.Text;
            SearchBuyer(searchText);
        }

        private void ClearBuyerSearchButton_Click(object sender, EventArgs e)
        {
            BuyerSearchTextBox.Clear();
            BuyerDataGridView.ClearSelection();
        }
    }
}
