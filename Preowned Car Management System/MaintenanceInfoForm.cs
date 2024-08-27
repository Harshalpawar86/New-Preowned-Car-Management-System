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
    public partial class MaintenanceInfoForm : Form
    {
        public String carId { get; set; }
        public String maintenanceId { get; set; }
        public String maintenanceDate { get; set; }
        public String maintenanceInfo { get; set; }
        public String maintenanceCost { get; set; }

        public MaintenanceInfoForm()
        {
            InitializeComponent();
        }

        private void MaintenanceInfoForm_Load(object sender, EventArgs e)
        {

        }

        private void CarIdTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            carId = CarIdTextBox.Text;
            maintenanceId=MaintenanceIdTextBox.Text;
            maintenanceCost = MaintenanceCostTextBox.Text;
            maintenanceDate = dateTimePicker1.Value.ToString();
            maintenanceInfo = MaintenanceIdRichTextBox.Text;
            DialogResult = DialogResult.OK;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
