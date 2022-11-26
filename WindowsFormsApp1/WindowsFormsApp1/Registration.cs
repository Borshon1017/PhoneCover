using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace WindowsFormsApp1
{
    public partial class Registration : Form
    {

        public Registration()
        {
            InitializeComponent(); 

        }

        OleDbConnection con = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source = C:/Users/User/source/repos/PhoneCover/WindowsFormsApp1/Databases/UserInfo.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();

        public string FullName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string DateOfBirth { get; set; }

        private void Registration_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (textBox4.Text != textBox5.Text)
            {
                label7.Visible = true;
            }
            else {

                con.Open();
                this.FullName = textBox1.Text;
                this.Email = textBox2.Text;
                this.Address = textBox3.Text;
                this.DateOfBirth = dateTimePicker1.Value.ToString();
                this.Password = textBox4.Text;

                string register = "INSERT INTO UserInfo VALUES ('" + this.FullName + "', '" + this.Password + "', '" + this.Email + "', '" + this.Address + "', '" + this.DateOfBirth + "')";
                cmd = new OleDbCommand(register, con);
                cmd.ExecuteNonQuery();
                con.Close();
                this.Hide();
                new Login();
            }
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = checkBox1.Checked;
        }
    }
}
