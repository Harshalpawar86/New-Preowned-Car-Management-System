using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Preowned_Car_Management_System
{
    public partial class AccessoriesForm : Form
    {
        ContextMenuStrip contextMenu;
        public AccessoriesForm()
        {
            InitializeComponent();
            contextMenu = new ContextMenuStrip();
            contextMenu.Items.Add("Sell Accessories", null, ContextMenuOption1_Click);
        }
        public void AddAccessoriesData(string accessoriesName, string accessoriesDate, String accessoriesImage,String accessoriesCount)
        {
            Panel panel = new Panel();
            panel.Name = "AccessoriesData";
            panel.BackColor = Color.White;
            panel.AutoSize = true;
            panel.Margin = new Padding(10);
            panel.Padding = new Padding(10);
            panel.BorderStyle = BorderStyle.FixedSingle;

            PictureBox pictureBox = new PictureBox();
            pictureBox.Padding = new Padding(10);
            pictureBox.Name = "AccessoriesImage";
            pictureBox.Size = new Size(200, 150);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;

            pictureBox.Image = Image.FromFile(accessoriesImage);

            Label label1 = new Label();
            label1.Name = "AccessoriesNameLabel";
            label1.Text = accessoriesName;
            label1.Location = new Point(12, pictureBox.Bottom + 5);
            label1.ForeColor = Color.Black;
            label1.Font = new Font(this.Font.FontFamily, 9.5f, FontStyle.Regular);
            label1.AutoSize = true;

            Label label2 = new Label();
            label2.Name = "AccessoriesCountLabel";
            label2.Text = accessoriesCount;
            label2.Location = new Point(12, label1.Bottom + 5);
            label2.ForeColor = Color.Black;
            label2.Font = new Font(this.Font.FontFamily, 9.5f, FontStyle.Regular);
            label2.AutoSize = true;

            Label label3 = new Label();
            label3.Name = "AccessoriesDateLabel";
            label3.Text = accessoriesDate;
            label3.Location = new Point(12, label2.Bottom + 5);
            label3.ForeColor = Color.Black;
            label3.Font = new Font(this.Font.FontFamily, 9.5f, FontStyle.Regular);
            label3.AutoSize = true;

            panel.Controls.Add(pictureBox);
            panel.Controls.Add(label1);
            panel.Controls.Add(label2);
            panel.Controls.Add(label3);

            panel.MouseClick += Panel_MouseClick;
            pictureBox.MouseClick += Panel_MouseClick;
            label1.MouseClick += Panel_MouseClick;
            label2.MouseClick += Panel_MouseClick;

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

        private void AddStockButton_Click(object sender, EventArgs e)
        {
               AddAccessoriesForm addAccessoriesForm = new AddAccessoriesForm();
            if (addAccessoriesForm.ShowDialog() == DialogResult.OK)
            {
                String accessoriesName = addAccessoriesForm.accessoriesName;
                String accessoriesDate = addAccessoriesForm.accessoriesDate;
                String accessoriesCount = addAccessoriesForm.accessoriesCount;
                String image = addAccessoriesForm.ImagePath;

                AddAccessoriesData(accessoriesName:accessoriesName,accessoriesDate:accessoriesDate,accessoriesImage:image,accessoriesCount:accessoriesCount);

            }
        }
    }
}
