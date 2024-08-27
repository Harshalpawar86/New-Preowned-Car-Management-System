using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Preowned_Car_Management_System
{
    public partial class MaintenanceForm : Form
    {
        ContextMenuStrip contextMenu;
        public MaintenanceForm()
        {
            InitializeComponent();
            contextMenu = new ContextMenuStrip();
            contextMenu.Items.Add("Update", null, ContextMenuOption1_Click);
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

        private void ContextMenuOption1_Click(object sender, EventArgs e)
        {


        }
        public void AddMaintenanceRecord(String carId,String maintenanceId,String maintenanceCost,String maintenanceDate,String maintenanceInfo) {


            Panel panel = new Panel();
            panel.Name = "StockData";
            panel.BackColor = Color.White;
            panel.AutoSize = true;
            panel.Margin = new Padding(10);
            panel.Padding = new Padding(10);
            panel.BorderStyle = BorderStyle.FixedSingle;

            Label carIdLabel = new Label();
            carIdLabel.Name = "CarIdLabel";
            carIdLabel.Text = carId;
            carIdLabel.Location = new Point(12,5);
            carIdLabel.ForeColor = Color.Black;
            carIdLabel.Font = new Font(this.Font.FontFamily, 9.5f, FontStyle.Regular);
            carIdLabel.AutoSize = true;

            Label maintenanceIdLabel = new Label();
            maintenanceIdLabel.Name = "MaintenanceIdLabel";
            maintenanceIdLabel.Text = maintenanceId;
            maintenanceIdLabel.Location = new Point(12, carIdLabel.Bottom + 5);
            maintenanceIdLabel.ForeColor = Color.Black;
            maintenanceIdLabel.Font = new Font(this.Font.FontFamily, 9.5f, FontStyle.Regular);
            maintenanceIdLabel.AutoSize = true;

            Label maintenanceDateLabel = new Label();
            maintenanceDateLabel.Name = "MaintenanceDateDateLabel";
            maintenanceDateLabel.Text = maintenanceDate;
            maintenanceDateLabel.Location = new Point(12, maintenanceIdLabel.Bottom + 5);
            maintenanceDateLabel.ForeColor = Color.Black;
            maintenanceDateLabel.Font = new Font(this.Font.FontFamily, 9.5f, FontStyle.Regular);
            maintenanceDateLabel.AutoSize = true;

            Label maintenanceCostLabel = new Label();
            maintenanceCostLabel.Name = "MaintenanceCostLabel";
            maintenanceCostLabel.Text = maintenanceCost;
            maintenanceCostLabel.Location = new Point(12, maintenanceDateLabel.Bottom + 5);
            maintenanceCostLabel.ForeColor = Color.Black;
            maintenanceCostLabel.Font = new Font(this.Font.FontFamily, 9.5f, FontStyle.Regular);
            maintenanceCostLabel.AutoSize = true;

            Label maintenanceInfoLabel = new Label();
            maintenanceInfoLabel.Name = "MaintenanceInfoLabel";
            maintenanceInfoLabel.Text = maintenanceInfo;
            maintenanceInfoLabel.Location = new Point(12, maintenanceCostLabel.Bottom + 5);
            maintenanceInfoLabel.ForeColor = Color.Black;
            maintenanceInfoLabel.Font = new Font(this.Font.FontFamily, 9.5f, FontStyle.Regular);
            maintenanceInfoLabel.AutoSize = true;
            maintenanceInfoLabel.Width = 200;
            maintenanceInfoLabel.Height = 100;
            maintenanceInfoLabel.MaximumSize = new Size(200, 0);
            maintenanceInfoLabel.TextAlign = ContentAlignment.TopLeft;
            maintenanceInfoLabel.Padding = new Padding(0);

            panel.Controls.Add(carIdLabel);
            panel.Controls.Add(maintenanceIdLabel);
            panel.Controls.Add(maintenanceDateLabel);
            panel.Controls.Add(maintenanceCostLabel);
            panel.Controls.Add(maintenanceInfoLabel);

            panel.MouseClick += Panel_MouseClick;
            carIdLabel.MouseClick += Panel_MouseClick;
            maintenanceIdLabel.MouseClick += Panel_MouseClick;
            maintenanceDateLabel.MouseClick += Panel_MouseClick;
            maintenanceCostLabel.MouseClick += Panel_MouseClick;
            maintenanceInfoLabel.MouseClick += Panel_MouseClick;

            flowLayoutPanel1.Controls.Add(panel);
        }

        private void AddMaintenanceButton_Click(object sender, EventArgs e)
        {
            MaintenanceInfoForm maintenanceInfoForm = new MaintenanceInfoForm();
            if (maintenanceInfoForm.ShowDialog() == DialogResult.OK)
            {
                String carId = maintenanceInfoForm.carId;
                String maintenanceId = maintenanceInfoForm.maintenanceId;
                String maintenanceCost = maintenanceInfoForm.maintenanceDate;
                String maintenanceDate = maintenanceInfoForm.maintenanceInfo;
                String maintenanceInfo = maintenanceInfoForm.maintenanceCost;

                AddMaintenanceRecord(carId:carId,maintenanceId:maintenanceId,maintenanceCost:maintenanceCost,maintenanceDate:maintenanceDate,maintenanceInfo:maintenanceInfo);

            }
        }
    }
}
