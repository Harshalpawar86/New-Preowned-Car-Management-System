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
        public double purchaseAmount { set; get; }
        

        bool noException = false;
        private String selectForm;
        public ExistingSupplierForm(String selectForm)
        {
            this.selectForm = selectForm;
            InitializeComponent();
            dataGridView1.CellClick += dataGridView1_CellClick;
        }
        private void LoadSupplierData(String filter = "")
        {
            String tableName;
            if (selectForm == "ForSupplier")
            {

                tableName = "HistoryTable";
            }
          //  else if(selectForm=="ForStock")
            else{

                tableName = "SupplierTable";
            }
            using (SqlConnection conn = new SqlConnection(connectionString))
            {

                conn.Open();
                String query = "SELECT SupplierName,SupplierId,SupplierMobileNumber,SupplierAddress,CarId,CarName,AmountPaid FROM "+tableName+" ";
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
                dataGridView1.DataSource = dataTable;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.MultiSelect = false;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            noException = false;
            try {

                if (e.RowIndex>=0) {

                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                    
                    
                    supplierName = (row.Cells["SupplierName"].Value).ToString();
                    supplierId = Convert.ToInt32(row.Cells["SupplierId"].Value);
                    mobileNumber =Convert.ToInt64( row.Cells["SupplierMobileNumber"].Value.ToString());
                    address = (row.Cells["SupplierAddress"].Value).ToString();
                    carName = row.Cells["CarName"].Value.ToString();
                    carId = Convert.ToInt64(row.Cells["CarId"].Value);
                    purchaseAmount = Convert.ToDouble(row.Cells["AmountPaid"].Value);
                    
                    noException = true;
                }
            } catch (Exception exp) {
                MessageBox.Show(exp.ToString());
                noException = false;
               
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ExistingSupplierForm_Load(object sender, EventArgs e)
        {
            LoadSupplierData();
        }

        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            String filter = SearchTextBox.Text.Trim();
            LoadSupplierData(filter);
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            SearchTextBox.Text = "";
            LoadSupplierData();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (noException == true)
            {

                DialogResult = DialogResult.OK;
            }
            else {

                MessageBox.Show("Please Select Valid Row");
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult= DialogResult.Cancel;
        }
    }
}
