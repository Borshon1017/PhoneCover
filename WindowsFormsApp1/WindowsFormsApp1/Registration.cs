using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Registration : Form
    {
        

        public string FullName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }

        public Registration()
        {
            InitializeComponent();
        }

        private void Registration_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.FullName = textBox1.Text;
            this.Email = textBox2.Text;
            this.Address = textBox3.Text;
            this.DateOfBirth = dateTimePicker1.Value;
            this.Password = textBox4.Text;
            if (textBox4.Text != textBox5.Text)
            {
                label7.Visible = true;
            }
            else {
                this.Hide();
                Form2 form2 = new Form2();
                form2.Show();
            }
            
        }

    }
}
