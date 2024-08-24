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

        public String accessoriesCount { get;set; }
        public AddAccessoriesForm()
        {
            InitializeComponent();
        }
        private void OKButton_Click(object sender, EventArgs e)
        {
            accessoriesName = AccessoriesNameTextBox.Text;
            accessoriesDate= dateTimePicker1.Value.ToString();
            accessoriesCount = AccessoriesCountTextBox.Text;
            DialogResult = DialogResult.OK;
        }

        private void photo_button_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {

                openFileDialog.Filter = "Image Files|*.jpg;*.png;*.jpeg;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {

                    ImagePath = openFileDialog.FileName;

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
