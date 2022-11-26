using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.OleDb;

namespace WindowsFormsApp1
{
    public partial class PhoneDesigner : Form
    {
        public PhoneDesigner()
        {
            InitializeComponent();
        }

        int brandId;

        OleDbConnection con = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source = Databases/PhoneModel.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();

        private void Form1_Load(object sender, EventArgs e)
        {

            con.Open();
            string showBrand = "SELECT * FROM BRAND";
            cmd = new OleDbCommand(showBrand, con);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            brandComboBox.DisplayMember = "BRAND_NAME";
            brandComboBox.ValueMember = "BRAND_ID";
            brandComboBox.DataSource = dt;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            // image filters  
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // image file path  
                label1.Text = open.FileName;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (colorComboBox.SelectedIndex == 0)
            {
                colorComboBox.ForeColor=Color.Gray;
            }
            else if (colorComboBox.SelectedIndex == 1) { colorComboBox.ForeColor = Color.Black; }
            else if (colorComboBox.SelectedIndex == 2) { colorComboBox.ForeColor = Color.Blue; }

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (brandComboBox.SelectedIndex == 0 || brandComboBox.SelectedIndex == 1 || brandComboBox.SelectedIndex == 0)
            {
                colorComboBox.Enabled = true;
            }
            
        }

        private void brandComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(brandComboBox.SelectedValue.ToString() != null ) {

                brandId = Convert.ToInt32(brandComboBox.SelectedValue.ToString());

                con.Open();
                string showModel = "SELECT * FROM MODEL WHERE BRAND_ID = " + brandId;
                cmd.Parameters.AddWithValue("BRAND_ID", brandId);
                cmd = new OleDbCommand(showModel, con);
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                modelComboBox.DisplayMember = "MODEL_NAME";
                modelComboBox.ValueMember = "MODEL_ID";
                modelComboBox.DataSource = dt;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new UserMainMenu().Show();
        }
    }
}
