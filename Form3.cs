using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace database_connection
{
    public partial class Form3 : Form
    {
        //Variable readable from other forms.
        public Form3()
        {
            InitializeComponent();
            textBox4.PasswordChar = '*';
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == null || textBox2.Text == null || textBox3.Text == null || textBox4.Text == null)
            {
                MessageBox.Show("Error: Fields cannot be empty!");
            }
            else
            {
                configParams.dbURL = textBox1.Text.ToString();
                configParams.dbPort = textBox2.Text;
                configParams.dbUname = textBox3.Text;
                configParams.dbPasswd = textBox4.Text;
                configParams.ready = true;
            }
            this.Hide();
        }
    }
}
