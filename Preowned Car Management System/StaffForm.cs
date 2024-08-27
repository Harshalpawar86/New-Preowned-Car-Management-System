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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Preowned_Car_Management_System
{
    public partial class StaffForm : Form
    {
        ContextMenuStrip contextMenu;
        
        public StaffForm()
        {
            InitializeComponent();
            contextMenu = new ContextMenuStrip();
            contextMenu.Items.Add("Edit Information", null, ContextMenuOption1_Click);
        }
        public void AddStaffInfoFun(String staffName,String staffGender,String staffMobileNumber,String staffEmail,String staffAddress,String jobDesignation) {
            Panel panel = new Panel();
            panel.Name = "StaffData";
            panel.BackColor = Color.White;
            panel.AutoSize = true;
            panel.Margin = new Padding(10);
            panel.Padding = new Padding(10);
            panel.BorderStyle = BorderStyle.FixedSingle;



            Label StaffNameLabel = new Label();
            StaffNameLabel.Name = "StaffNameLabel";
            StaffNameLabel.Text = staffName;
            StaffNameLabel.Location = new Point(12,5);
            StaffNameLabel.ForeColor = Color.Black;
            StaffNameLabel.Font = new Font(this.Font.FontFamily, 9.5f, FontStyle.Regular);
            StaffNameLabel.AutoSize = true;

            Label StaffGenderLabel = new Label();
            StaffGenderLabel.Name = "StaffGenderLabel";
            StaffGenderLabel.Text = staffGender; ;
            StaffGenderLabel.Location = new Point(12, StaffNameLabel.Bottom + 5);
            StaffGenderLabel.ForeColor = Color.Black;
            StaffGenderLabel.Font = new Font(this.Font.FontFamily, 9.5f, FontStyle.Regular);
            StaffGenderLabel.AutoSize = true;

            Label StaffMobileNumberLabel = new Label();
            StaffMobileNumberLabel.Name = "StaffMobileNumberLabel";
            StaffMobileNumberLabel.Text = staffMobileNumber; ;
            StaffMobileNumberLabel.Location = new Point(12, StaffGenderLabel.Bottom + 5);
            StaffMobileNumberLabel.ForeColor = Color.Black;
            StaffMobileNumberLabel.Font = new Font(this.Font.FontFamily, 9.5f, FontStyle.Regular);
            StaffMobileNumberLabel.AutoSize = true;

            Label StaffEmailLabel = new Label();
            StaffEmailLabel.Name = "StaffEmailLabel";
            StaffEmailLabel.Text = staffEmail;
            StaffEmailLabel.Location = new Point(12, StaffMobileNumberLabel.Bottom + 5);
            StaffEmailLabel.ForeColor = Color.Black;
            StaffEmailLabel.Font = new Font(this.Font.FontFamily, 9.5f, FontStyle.Regular);
            StaffEmailLabel.AutoSize = true;


            Label JobDesignationLabel = new Label();
            JobDesignationLabel.Name = "JobDesignationLabel";
            JobDesignationLabel.Text = jobDesignation;
            JobDesignationLabel.Location = new Point(12, StaffEmailLabel.Bottom + 5);
            JobDesignationLabel.ForeColor = Color.Black;
            JobDesignationLabel.Font = new Font(this.Font.FontFamily, 9.5f, FontStyle.Regular);
            JobDesignationLabel.AutoSize = true;

            Label StaffaddressLabel = new Label();
            StaffaddressLabel.Name = "StaffaddressLabel";
            StaffaddressLabel.Text = staffAddress;
            StaffaddressLabel.Location = new Point(12, JobDesignationLabel.Bottom + 5);
            StaffaddressLabel.ForeColor = Color.Black;
            StaffaddressLabel.Font = new Font(this.Font.FontFamily, 9.5f, FontStyle.Regular);
            StaffaddressLabel.AutoSize = true;
            StaffaddressLabel.Width = 200;
            StaffaddressLabel.Height = 100;
            StaffaddressLabel.MaximumSize = new Size(200, 0);
            StaffaddressLabel.TextAlign = ContentAlignment.TopLeft;
            StaffaddressLabel.Padding = new Padding(0);



            panel.Controls.Add(StaffNameLabel);
            panel.Controls.Add(StaffGenderLabel);
            panel.Controls.Add(StaffMobileNumberLabel);
            panel.Controls.Add(StaffEmailLabel);
            panel.Controls.Add(JobDesignationLabel);
            panel.Controls.Add(StaffaddressLabel);

            panel.MouseClick += Panel_MouseClick;
            StaffNameLabel.MouseClick += Panel_MouseClick;
            StaffGenderLabel.MouseClick += Panel_MouseClick;
            StaffMobileNumberLabel.MouseClick += Panel_MouseClick;
            StaffaddressLabel.MouseClick += Panel_MouseClick;
            JobDesignationLabel.MouseClick += Panel_MouseClick;

            flowLayoutPanel1.Controls.Add(panel);
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



        private void AddStaffButton_Click(object sender, EventArgs e)
        {
            StaffAuthenticationForm form = new StaffAuthenticationForm();
            if (form.ShowDialog() == DialogResult.OK) { 
            
                form.Hide();
                AddStaffInfoForm addStaffInfoForm = new AddStaffInfoForm();
                if (addStaffInfoForm.ShowDialog() == DialogResult.OK) { 
                
                    String staffName=addStaffInfoForm.staffName;
                    String staffGender=addStaffInfoForm.staffGender;
                    String staffMobileNumber=addStaffInfoForm.staffMobileNumber;
                    String staffEmail=addStaffInfoForm.staffEmail;
                    String staffAddress=addStaffInfoForm.staffAddress;
                    String jobDesignation=addStaffInfoForm.jobDesignation;

                    AddStaffInfoFun(staffName:staffName,staffGender:staffGender,staffMobileNumber:staffMobileNumber,staffEmail:staffEmail,staffAddress:staffAddress,jobDesignation:jobDesignation);
                }

            }
        }
    }
}
