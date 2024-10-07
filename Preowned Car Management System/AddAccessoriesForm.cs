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
    public partial class AddAccessoriesForm : Form
    {
        public String ImagePath { get; set; }
        public String accessoriesName { get; set; }
        public String accessoriesDate { get; set; }

        public int accessoriesCount { get;set; }
        bool noException = false;
        bool getImage = false;

        public AddAccessoriesForm()
        {
            InitializeComponent();
        }
        void getData() {

            accessoriesName = AccessoriesNameTextBox.Text;
            accessoriesDate = dateTimePicker1.Value.ToString();
            accessoriesCount = Convert.ToInt32(AccessoriesCountTextBox.Text);
        }
        private void OKButton_Click(object sender, EventArgs e)
        {
            

            noException = false;
            if (ValidateData())
            {
                try
                {
                    getData();
                    noException = true;
                }
                catch (Exception exp)
                {

                    noException = false;
                }
            }
            else
            {

                MessageBox.Show("Please Enter Valid Data");
            }
            if (getImage == false)
            {

                MessageBox.Show("Please Select image");
            }
            if (noException == true && getImage == true)
            {
                DialogResult = DialogResult.OK;
            }



        }
        private bool ValidateData()
        {

            return !string.IsNullOrEmpty(AccessoriesNameTextBox.Text) &&
                   int.TryParse(AccessoriesCountTextBox.Text, out _) &&
                   !string.IsNullOrEmpty(dateTimePicker1.Text);
        }
        private void photo_button_Click(object sender, EventArgs e)
        {
            getImage = false;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {

                openFileDialog.Filter = "Image Files|*.jpg;*.png;*.jpeg;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {

                    ImagePath = openFileDialog.FileName;
                    getImage = true;

                }
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void AddAccessoriesForm_Load(object sender, EventArgs e)
        {

        }
    }
}
