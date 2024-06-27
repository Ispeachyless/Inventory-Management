using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FINAL_PROJECT
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           // panel1.BackColor = Color.FromArgb(100,0,0,0); 
           // code to make something transparent
        }


        public void setEmpty()
        {
            this.textBox1.Text = string.Empty;
            this.textBox2.Text = string.Empty;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String n = textBox1.Text;
            String p = textBox2.Text;
            Form2 form = new Form2(this);

            if (n.Equals("admin") && p.Equals("1234"))
            {
                form.Show();
                this.Hide();
            }
            else if (n.Equals("admin"))
            {
                MessageBox.Show("Invalid password. Please try again", "Warning",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (p.Equals("1234"))
            {
                MessageBox.Show("Invalid username. Please try again", "Warning",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Invalid input. Please try again", "Warning",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
