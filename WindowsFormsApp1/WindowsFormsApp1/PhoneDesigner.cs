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

        int brandId;

        public PhoneDesigner()
        {

            InitializeComponent();

            DataTable dt = new DataTable();
            string showBrand = "SELECT * FROM BRAND";

            con.Open();
            cmd = new OleDbCommand(showBrand, con);
            da = new OleDbDataAdapter(cmd);
            da.Fill(dt);
            con.Close();

            brandComboBox.DisplayMember = "BRAND_NAME";
            brandComboBox.ValueMember = "BRAND_ID";
            brandComboBox.DataSource = dt;

        }

        OleDbConnection con = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source = Databases/PhoneModel.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void brandComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (brandComboBox.SelectedValue.ToString() != null) {

                DataTable dt = new DataTable();
                brandId = Convert.ToInt32(brandComboBox.SelectedValue.ToString());
                string showModel = "SELECT * FROM MODEL WHERE BRAND_ID = " + brandId;

                con.Open();
                cmd = new OleDbCommand(showModel, con);
                cmd.Parameters.AddWithValue("BRAND_ID", brandId);
                da = new OleDbDataAdapter(cmd);
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
