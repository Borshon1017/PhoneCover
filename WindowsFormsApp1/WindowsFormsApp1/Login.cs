﻿using System;
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
    public partial class Login : Form
    {

        public Login()
        {
            InitializeComponent();
        }

        OleDbConnection con = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source = UserInfo.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Registration().Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            con.Open();
            string login = "SELECT * FROM UserInfo WHERE FULLNAME = '" + textBox1.Text + "' AND PASSWORD = '" + textBox2.Text + "' ";
            cmd = new OleDbCommand(login, con);
            OleDbDataReader dr = cmd.ExecuteReader();
            

            if (dr.Read() == true)
            {
                 
                new UserMainMenu().Show();
               

            }
            else {

                label4.Visible = true;

            }


        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
