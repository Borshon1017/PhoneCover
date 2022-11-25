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

namespace WindowsFormsApp1
{
    public partial class PhoneDesigner : Form
    {
        public PhoneDesigner()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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
                // display image in picture box  
                pictureBox2.Visible = true;
                pictureBox2.Image = new Bitmap(open.FileName);
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
            if(brandComboBox.SelectedIndex == 0 || brandComboBox.SelectedIndex == 1 ||brandComboBox.SelectedIndex == 0) {
                modelComboBox.Enabled = true;
            }
        }
    }
}
