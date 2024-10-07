using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Preowned_Car_Management_System
{
    public partial class DashBoardForm : Form
    {
        Form loginForm;

        public static String connectionString = "Data Source=LAPTOP-Q6RR7BFH\\SQLEXPRESS08;Initial Catalog=PreOwnedCarManagementDatabase;Integrated Security=True;";
     

       // public static String connectionString = "Data Source=MONU\\SQLEXPRESS;Initial Catalog=PreOwnedCarManagementDatabase;Integrated Security=True;TrustServerCertificate=True";
        public DashBoardForm(Form loginForm)
        {
            this.loginForm = loginForm;
            InitializeComponent();
          
        }




        private void DashBoardForm_Load(object sender, EventArgs e)
        {
           
        }

        void LoadGivenForm(Form form) {

            panel15.Visible = false;
            FormLoadingPanel.Controls.Clear();
            form.TopLevel = false;
            FormLoadingPanel.Controls.Add(form);
            form.Dock = DockStyle.Fill;
            form.Show();
        } 
        

 

        private void LoadProfile() {
        

        }

        private void panel16_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void panel16_Click(object sender, EventArgs e)
        {
            LoadProfile();

        }

        private void label2_Click(object sender, EventArgs e)
        {
            LoadProfile();

        }

        private void panel17_Click(object sender, EventArgs e)
        {
            LoadProfile();
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
            StaffForm form = new StaffForm();
            LoadGivenForm(form);
        }

        private void HistoryButton_Click(object sender, EventArgs e)
        {
            HistoryForm form = new HistoryForm();
            LoadGivenForm(form);
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
            LoginForm form = new LoginForm();
            form.Show();
            this.Hide();
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
        
            ProfileForm form = new ProfileForm();
            form.Show();
        }
    }
}