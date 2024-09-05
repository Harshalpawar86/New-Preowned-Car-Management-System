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
    public partial class ExistingBuyerForm : Form
    {
        String connectionString = DashBoardForm.connectionString;
        public String buyerName { set; get; }
        public long buyerId { set; get; }
        public long mobileNumber { set; get; }
        public String address { set; get; }


        bool noException = false;
        public ExistingBuyerForm()
        {
            InitializeComponent();
            dataGridView1.CellClick += dataGridView1_CellClick;
            dataGridView2.CellClick += dataGridView2_CellClick;
        }
        private void LoadBuyerData(String filter = "")
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {

                conn.Open();
                String query = "SELECT BuyerName,BuyerId,BuyerMobileNumber,BuyerAddress FROM BuyerTable ";
                if (!String.IsNullOrEmpty(filter))
                {

                    query += "WHERE BuyerName LIKE @filter";
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
        private void LoadHistoryData(String filter = "")
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {

                conn.Open();
                String query = "SELECT BuyerName,BuyerId,BuyerMobileNumber,BuyerAddress FROM HistoryTable ";
                if (!String.IsNullOrEmpty(filter))
                {

                    query += "WHERE BuyerName LIKE @filter";
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
            try
            {

                if (e.RowIndex >= 0)
                {

                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];


                    buyerName = (row.Cells["BuyerName"].Value).ToString();
                    buyerId = Convert.ToInt32(row.Cells["BuyerId"].Value);
                    mobileNumber = Convert.ToInt64(row.Cells["BuyerMobileNumber"].Value.ToString());
                    address = (row.Cells["BuyerAddress"].Value).ToString();

                    noException = true;
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
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


                    buyerName = (row.Cells["BuyerName"].Value).ToString();
                    buyerId = Convert.ToInt32(row.Cells["BuyerId"].Value);
                    mobileNumber = Convert.ToInt64(row.Cells["BuyerMobileNumber"].Value.ToString());
                    address = (row.Cells["BuyerAddress"].Value).ToString();

                    noException = true;
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
                //   MessageBox.Show("Please Select Valid Row");
                noException = false;

            }


        }


        private void ExistingBuyerForm_Load(object sender, EventArgs e)
        {
            

                tableLayoutPanel1.RowStyles[1].Height = 50;
                tableLayoutPanel1.RowStyles[0].Height = 50;
                LoadBuyerData();
                LoadHistoryData();
            
        }




        private void AddButton_Click_1(object sender, EventArgs e)
        {
            if (noException == true)
            {

                DialogResult = DialogResult.OK;
            }
            else
            {

                MessageBox.Show("Please Select Valid Row");
            }
        }

        private void CancelButton_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

        }

        private void SearchTextBox_TextChanged_1(object sender, EventArgs e)
        {
            String filter = SearchTextBox.Text.Trim();
           

                LoadBuyerData(filter);
                LoadHistoryData(filter);
            
        }

        private void ClearButton_Click_1(object sender, EventArgs e)
        {
            SearchTextBox.Text = "";
            
                LoadBuyerData();
                LoadHistoryData();
                dataGridView1.ClearSelection();
                dataGridView2.ClearSelection();
            
        }
    }
}
