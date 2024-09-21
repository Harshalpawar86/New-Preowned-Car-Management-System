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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            //if (UseridTextbox.Text == "Monu@123" && PasswordTextbox.Text == "12345")
            //{
            //    DashBoardForm dashBoardForm = new DashBoardForm();
            //    UseridTextbox.Text = "";
            //    PasswordTextbox.Text = "";
            //    dashBoardForm.Show();
            //}
            //else {

            //    MessageBox.Show("Enter Valid User Id & Password");
            //}
            DashBoardForm form = new DashBoardForm();
            form.Show();
          //  this.Hide();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
