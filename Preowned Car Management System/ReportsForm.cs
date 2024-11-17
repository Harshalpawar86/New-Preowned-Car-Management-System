using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Preowned_Car_Management_System
{
    public partial class ReportsForm : Form
    {
        public ReportsForm()
        {
            InitializeComponent();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ReportsForm_Load(object sender, EventArgs e)
        {
            BuyerReportsButton.Text = "B U Y E R \nR E P O R T S";
            SupplierReportsButton.Text = "S U P P L I E R \nR E P O R T S";
            StockReportsButton.Text = "S T O C K \nR E P O R T S";
            StaffReoprtsButton.Text = "S T A F F \nR E P O R T S";
            MaintenanceReportsButton.Text = "M A I N T E N A N C E \nR E P O R T S";
            AccessoryReportsButton.Text = "A C C E S S O R I E S \nR E P O R T S";
            HistoryReportsButton.Text = "T R A N S A C T I O N\nR E P O R T S";
        }

        private void SupplierReportsButton_Click(object sender, EventArgs e)
        {
            ReportDetailsFrom form = new ReportDetailsFrom("Supplier");
            form.Show();
        }


        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BuyerReportsButton_Click_1(object sender, EventArgs e)
        {
            ReportDetailsFrom form = new ReportDetailsFrom("Buyer");
            form.Show();
        }

        private void StockReportsButton_Click_1(object sender, EventArgs e)
        {
            ReportDetailsFrom form = new ReportDetailsFrom("Stock");
            form.Show();
        }

        private void StaffReoprtsButton_Click(object sender, EventArgs e)
        {
            ReportDetailsFrom form = new ReportDetailsFrom("Staff");
            form.Show();
        }

        private void MaintenanceReportsButton_Click(object sender, EventArgs e)
        {
            ReportDetailsFrom form = new ReportDetailsFrom("Maintenance");
            form.Show();
        }

        private void AccessoryReportsButton_Click(object sender, EventArgs e)
        {
            ReportDetailsFrom form = new ReportDetailsFrom("Accessory");
            form.Show();
        }

        private void HistoryReportsButton_Click(object sender, EventArgs e)
        {
            ReportDetailsFrom form = new ReportDetailsFrom("History");
            form.Show();
        }
    }
}
