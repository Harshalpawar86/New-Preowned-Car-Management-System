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
    public partial class ExistingSupplierForm : Form
    {
        String connectionString = DashBoardForm.connectionString;
        public String supplierName { set; get; }
        public long supplierId { set; get; }
        public long mobileNumber { set; get; }
        public String address { set; get; }
        public long carId { get; set; }
        public String carName { set; get; }
        public decimal purchaseAmount { set; get; }
        

        bool noException = false;
        private String selectForm;
        public ExistingSupplierForm(String selectForm)
        {
            this.selectForm = selectForm;
            InitializeComponent();
            dataGridView1.CellClick += dataGridView1_CellClick;
            dataGridView2.CellClick += dataGridView2_CellClick;
        }
        //private void LoadSupplierData(String filter = "")
        //{
        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {

        //        conn.Open();
        //        String query = "SELECT SupplierName,SupplierId,SupplierMobileNumber,CarId,SupplierAddress,AmountPaid,CarName FROM SupplierTable ";
        //        if (!String.IsNullOrEmpty(filter))
        //        {

        //            query += "WHERE SupplierName LIKE @filter";
        //        }
        //        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, conn);
        //        if (!String.IsNullOrEmpty(filter))
        //        {

        //            sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@filter", "%" + filter + "%");
        //        }
        //        DataTable dataTable = new DataTable();
        //        sqlDataAdapter.Fill(dataTable);
        //        dataGridView1.DataSource = dataTable;
        //        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        //        dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        //        dataGridView1.MultiSelect = false;
        //    }
        //}
        private void LoadSupplierData(String filter = "")
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                String query = @"
            SELECT SupplierName, SupplierId, SupplierMobileNumber, CarId, SupplierAddress, AmountPaid, CarName 
            FROM SupplierTable 
            WHERE CarId NOT IN (SELECT CarId FROM StockTable)";

                // Add filter for SupplierName if provided
                if (!String.IsNullOrEmpty(filter))
                {
                    query += " AND SupplierName LIKE @filter";
                }

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, conn);

                // Add filter parameter if provided
                if (!String.IsNullOrEmpty(filter))
                {
                    sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@filter", "%" + filter + "%");
                }

                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.MultiSelect = false;
            }
        }

        private void LoadHistoryData(String filter = "")
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {

                conn.Open();
                String query = "SELECT SupplierName,SupplierId,SupplierMobileNumber,SupplierAddress,CarName FROM HistoryTable ";
                if (!String.IsNullOrEmpty(filter))
                {

                    query += "WHERE SupplierName LIKE @filter";
                }
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, conn);
                if (!String.IsNullOrEmpty(filter))
                {

                    sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@filter", "%" + filter + "%");
                }
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                dataGridView2.DataSource = dataTable;
                dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView2.MultiSelect = false;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView2.ClearSelection();
            noException = false;
            try {

                if (e.RowIndex>=0) {

                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                    
                    
                    supplierName = (row.Cells["SupplierName"].Value).ToString();
                    supplierId = Convert.ToInt32(row.Cells["SupplierId"].Value);
                    mobileNumber =Convert.ToInt64( row.Cells["SupplierMobileNumber"].Value.ToString());
                    address = (row.Cells["SupplierAddress"].Value).ToString();
                    carName = row.Cells["CarName"].Value.ToString();

                    if (selectForm == "ForStock") {

                        carId = Convert.ToInt64(row.Cells["CarId"].Value);
                        purchaseAmount = Convert.ToDecimal(row.Cells["AmountPaid"].Value);
                    }
  
                    noException = true;
                }
            } catch (Exception exp) {
                  // MessageBox.Show(exp.ToString());
          //      MessageBox.Show("Please Select Valid Row");
                noException = false;
               
            }


        }
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.ClearSelection();
            noException = false;
            try
            {

                if (e.RowIndex >= 0)
                {

                    DataGridViewRow row = dataGridView2.Rows[e.RowIndex];


                    supplierName = (row.Cells["SupplierName"].Value).ToString();
                    supplierId = Convert.ToInt32(row.Cells["SupplierId"].Value);
                    mobileNumber = Convert.ToInt64(row.Cells["SupplierMobileNumber"].Value.ToString());
                    address = (row.Cells["SupplierAddress"].Value).ToString();
                    carName = row.Cells["CarName"].Value.ToString();

                    noException = true;
                }
            }
            catch (Exception exp)
            {
                 // MessageBox.Show(exp.ToString());
             //   MessageBox.Show("Please Select Valid Row");
                noException = false;

            }


        }


        private void ExistingSupplierForm_Load(object sender, EventArgs e)
        {
            if (selectForm == "ForStock")
            {
                LoadSupplierData();
                dataGridView2.Hide();
                tableLayoutPanel1.RowStyles[1].Height = 0;
                tableLayoutPanel1.RowStyles[0].Height = 100;
                dataGridView1.Dock = DockStyle.Fill;
                
            }
            else {

                tableLayoutPanel1.RowStyles[1].Height = 50;
                tableLayoutPanel1.RowStyles[0].Height = 50;
                LoadSupplierData();
                LoadHistoryData();
            }
        }

        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            String filter = SearchTextBox.Text.Trim();
            if (selectForm == "ForStock")
            {
                LoadSupplierData(filter);
            }
            else
            {

                LoadSupplierData(filter);
                LoadHistoryData(filter);
            }

           
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            SearchTextBox.Text = "";
            if (selectForm == "ForStock")
            {
                LoadSupplierData();
                dataGridView1.ClearSelection();

            }
            else
            {
                LoadSupplierData();
                LoadHistoryData();
                dataGridView1.ClearSelection();
                dataGridView2.ClearSelection();
            }
          
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (noException == true)
            {

                DialogResult = DialogResult.OK;
            }
            else {

                MessageBox.Show("Please Select Valid Row", "Selection Required",
    MessageBoxButtons.OK,
    MessageBoxIcon.Warning,
    MessageBoxDefaultButton.Button1);
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult= DialogResult.Cancel;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}