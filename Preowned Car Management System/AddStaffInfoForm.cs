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
    public partial class AddStaffInfoForm : Form
    {
        public String staffName { get; set; }
        public String staffGender { get; set; }
        public String staffBOD { get; set; }
        public int staffMobileNumber { get; set; }
        public String staffEmail { get; set; }
        public String staffAddress { get; set; }
        public String jobDesignation { get; set; }

        public AddStaffInfoForm()
        {
            InitializeComponent();
        }

        private void AddStaffInfoForm_Load(object sender, EventArgs e)
        {

        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            staffName=StaffNameTextBox.Text;
            staffGender=GenderComboBox.Text;
            staffMobileNumber = Convert.ToInt32(textBox2.Text);
            staffEmail=StaffEmailTextBox.Text;
            staffBOD = dateTimePicker1.Value.ToString();
            staffAddress=richTextBox1.Text;
            jobDesignation=JobDesignationComboBox.Text;
            DialogResult = DialogResult.OK;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
