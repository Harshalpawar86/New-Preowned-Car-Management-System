using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Preowned_Car_Management_System
{
    public partial class AccessoriesForm : Form
    {
        ContextMenuStrip contextMenu;
        String connectionString = DashBoardForm.connectionString;
        public AccessoriesForm()
        {
            InitializeComponent();
            contextMenu = new ContextMenuStrip();
            contextMenu.Items.Add("Sell Accessories", null, ContextMenuOption1_Click);
        }
        public void AddAccessoriesData(string accessoriesName, string accessoriesDate, Image accessoriesImage,int accessoriesCount)
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

            pictureBox.Image = accessoriesImage;

            Label label1 = new Label();
            label1.Name = "AccessoriesNameLabel";
            label1.Text = "Accessory Name : "+accessoriesName;
            label1.Location = new Point(12, pictureBox.Bottom + 5);
            label1.ForeColor = Color.Black;
            label1.Font = new Font(this.Font.FontFamily, 9.5f, FontStyle.Regular);
            label1.AutoSize = true;

            Label label2 = new Label();
            label2.Name = "AccessoriesCountLabel";
            label2.Text = "Accessory Count : "+accessoriesCount;
            label2.Location = new Point(12, label1.Bottom + 5);
            label2.ForeColor = Color.Black;
            label2.Font = new Font(this.Font.FontFamily, 9.5f, FontStyle.Regular);
            label2.AutoSize = true;

            Label label3 = new Label();
            label3.Name = "AccessoriesDateLabel";
            label3.Text = "Purchase Date : "+accessoriesDate;
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
           
        }
        private byte[] convertImage(String imageString)
        {

            Image image = Image.FromFile(imageString);

            using (MemoryStream ms = new MemoryStream())
            {

                image.Save(ms, image.RawFormat);
                return ms.ToArray();
            }
        }
        private Image convertFromBytes(byte[] imageBytes)
        {

            using (MemoryStream ms = new MemoryStream(imageBytes))
            {

                return Image.FromStream(ms);
            }
        }
        private void LoadExistingData()
        {

            using (SqlConnection conn = new SqlConnection(connectionString))
            {

                String query = "SELECT * FROM AccessoryTable";
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, conn))
                {

                    DataTable dataTable = new DataTable();
                    sqlDataAdapter.Fill(dataTable);

                    foreach (DataRow row in dataTable.Rows)
                    {

                        string accessoriesName = row["AccessoryName"].ToString();
                        int accessoriesCount = Convert.ToInt32(row["AccessoryCount"]);
                        string accessoriesDate = row["AccessoryDate"].ToString();
                        Image image = convertFromBytes((byte[])row["AccessoryImage"]);


                        AddAccessoriesData(accessoriesName: accessoriesName, accessoriesDate: accessoriesDate, accessoriesImage: image, accessoriesCount: accessoriesCount);

                    }
                }
            }
        }

        private void AddBuyerButton_Click(object sender, EventArgs e)
        {
            AddAccessoriesForm addAccessoriesForm = new AddAccessoriesForm();
            if (addAccessoriesForm.ShowDialog() == DialogResult.OK)
            {
                String accessoriesName = addAccessoriesForm.accessoriesName;
                String accessoriesDate = addAccessoriesForm.accessoriesDate;
                int accessoriesCount = addAccessoriesForm.accessoriesCount;
                String image = addAccessoriesForm.ImagePath;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    String query = "INSERT INTO AccessoryTable(AccessoryName,AccessoryDate,AccessoryCount,AccessoryImage) VALUES (@AccessoryName,@AccessoryDate,@AccessoryCount,@AccessoryImage);";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {

                        cmd.Parameters.AddWithValue("@AccessoryName", accessoriesName);
                        cmd.Parameters.AddWithValue("@AccessoryDate", accessoriesDate);
                        cmd.Parameters.AddWithValue("@AccessoryCount", accessoriesCount);
                        cmd.Parameters.AddWithValue("@AccessoryImage", convertImage(image));


                        conn.Open();
                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {

                            MessageBox.Show("Data Inserted Successfully");
                        }
                        else
                        {

                            MessageBox.Show("Data Insertion Failed");
                        }
                    }
                }
                flowLayoutPanel1.Controls.Clear();
                LoadExistingData();

            }
        }

        private void AccessoriesForm_Load(object sender, EventArgs e)
        {
            LoadExistingData();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            //if (SearchTextBox.Text == null || SearchTextBox.Text == "")
            //{
            //    MessageBox.Show("Please Enter Car Id to Search Maintenance Records..");

            //}
            //else
            //{
            //    searchId(SearchTextBox.Text);

            //}
        }
        //private void searchId(String name)
        //{

        //    flowLayoutPanel1.Controls.Clear();
        //    try
        //    {

        //        String query = "SELECT * FROM MaintenanceTable WHERE CarId=@CarId";

        //        using (SqlConnection conn = new SqlConnection(connectionString))
        //        {
        //            using (SqlCommand cmd = new SqlCommand(query, conn))
        //            {
        //                cmd.Parameters.AddWithValue("CarId", name);
        //                conn.Open();
        //                SqlDataReader reader = cmd.ExecuteReader();
        //                if (reader.HasRows)
        //                {
        //                    while (reader.Read())
        //                    {
        //                        String carId = reader["CarId"].ToString();
        //                        string accessoriesName 
        //                        string accessoriesDate 
        //                        Image accessoriesImage
        //                        int accessoriesCount

        //                        AddAccessoriesData(accessoriesName: accessoriesName, accessoriesDate: accessoriesDate, accessoriesImage: image, accessoriesCount: accessoriesCount);

        //                    }
        //                }
        //                else
        //                {
        //                    MessageBox.Show("Maintenance Record not found in the database.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                }
        //            }
        //        }

        //    }
        //    catch (Exception e)
        //    {

        //        MessageBox.Show(e.ToString());
        //    }
        //}

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
