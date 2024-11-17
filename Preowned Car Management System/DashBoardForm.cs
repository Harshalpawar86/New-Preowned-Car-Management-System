using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Preowned_Car_Management_System
{
    public partial class DashBoardForm : Form
    {
        Form loginForm;
        long id;
        bool manager = false;

        public static String connectionString = "Data Source=LAPTOP-Q6RR7BFH\\SQLEXPRESS08;Initial Catalog=PreOwnedCarManagementDatabase;Integrated Security=True;";
     

       // public static String connectionString = "Data Source=MONU\\SQLEXPRESS;Initial Catalog=PreOwnedCarManagementDatabase;Integrated Security=True;TrustServerCertificate=True;";
        public DashBoardForm(Form loginForm,long id)
        {
            this.loginForm = loginForm;
            this.id = id;
            InitializeComponent();
          
        }


        private void DashBoardForm_Load(object sender, EventArgs e)
        {     
            CheckManager();
            LoadStaffName();
            
        }
        void CheckManager() {
            String name = "";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    String query = "SELECT StaffJob FROM StaffTable WHERE StaffId=@StaffId";
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {

                        cmd.Parameters.AddWithValue("@StaffId", id);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                name = reader["StaffJob"].ToString();
                            }
                        }
                    }
                 //   MessageBox.Show("Name : "+name);
                    if (name == "Manager" || name== "Sales Manager") {
                    
                        manager = true;
                    }
                    
                }
            }
            catch (Exception exp)
            {

                MessageBox.Show(exp.Message);
            }
        }
        void LoadStaffName() {
            String name = "";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    String query = "SELECT StaffName FROM StaffTable WHERE StaffId=@StaffId";
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {

                        cmd.Parameters.AddWithValue("@StaffId", id);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                name = reader["StaffName"].ToString();
                            }
                        }
                    }
                    UserNameLabel.Text = name;
                }
            }
            catch (Exception exp) { 
            
                MessageBox.Show(exp.Message);
            }
        }

        void LoadGivenForm(Form form) {

            panel15.Visible = false;
            FormLoadingPanel.Controls.Clear();
            form.TopLevel = false;
            FormLoadingPanel.Controls.Add(form);
            form.Dock = DockStyle.Fill;
            form.Show();
        } 
        

 

    
        private void panel16_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void panel16_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel17_Click(object sender, EventArgs e)
        {
        }

        private void flowLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void StockButton_Click(object sender, EventArgs e)
        {
            StockForm form = new StockForm();
            LoadGivenForm(form);
        }

        private void panel15_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormLoadingPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SupplierButton_Click(object sender, EventArgs e)
        {
            SupplierForm form = new SupplierForm();
            LoadGivenForm(form);
        }

        private void BuyerButton_Click(object sender, EventArgs e)
        {
            BuyersForm form = new BuyersForm();
            LoadGivenForm(form);
        }

        private void MaintenanceButton_Click(object sender, EventArgs e)
        {
            MaintenanceForm form = new MaintenanceForm();
            LoadGivenForm(form);
        }

        private void AccessoriesButton_Click(object sender, EventArgs e)
        {
            AccessoriesForm form = new AccessoriesForm();
            LoadGivenForm(form);
        }

        private void StaffButton_Click(object sender, EventArgs e)
        {
            if (manager == true)
            {
                StaffForm form = new StaffForm();
                LoadGivenForm(form);
            }
            else {

                MessageBox.Show("Your are not Allowed to Access this Tab");
            }
        }

        private void HistoryButton_Click(object sender, EventArgs e)
        {
            if (manager == true)
            {
                HistoryForm form = new HistoryForm();
                LoadGivenForm(form);
            }
            else
            {

                MessageBox.Show("Your are not Allowed to Access this Tab");
            }
        }

        private void panel18_Click(object sender, EventArgs e)
        {
            panel15.Visible = true;
            FormLoadingPanel.Controls.Clear();
           
        }

        private void DashBoardForm_Leave(object sender, EventArgs e)
        {
            
        }

        private void DashBoardForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            loginForm.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to log out?", "Logout Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                LoginForm form = new LoginForm();
                form.Show();
                this.Hide();
            }

        }

        private void panel17_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel16_Click_1(object sender, EventArgs e)
        {
            SeeProfile();
        }

        private void label2_Click_1(object sender, EventArgs e)
        {
            SeeProfile();
        }
        void SeeProfile() { 
        
            ProfileForm form = new ProfileForm(id);
            form.Show();
        }

        private void ReportsButton_Click(object sender, EventArgs e)
        {
            if (manager == true)
            {
                ReportsForm form = new ReportsForm();
                LoadGivenForm(form);
            }
            else
            {

                MessageBox.Show("Your are not Allowed to Access this Tab");
            }
        }

        private void panel18_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel17_Click_1(object sender, EventArgs e)
        {
            SeeProfile();
        }

        private void panel15_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}