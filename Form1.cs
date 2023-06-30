using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Timers;
using System.Threading;

namespace database_connection
{
    public partial class Form1 : Form
    {
        public bool connected;
        public Form1()

        {
            InitializeComponent();
            outBox.ScrollBars = ScrollBars.Vertical;
            inBox.ScrollBars = ScrollBars.Vertical;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            (new Form3()).Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!configParams.ready)
            {
                outBox.AppendText("Error: Check config first");
                outBox.AppendText(Environment.NewLine);
                return;
            }

            if(configParams.dbURL == "" || configParams.dbPort == "" || configParams.dbUname == "" || configParams.dbPasswd == "")
            {
                outBox.AppendText("Error: Bad config data");
                outBox.AppendText(Environment.NewLine);
                return;
            }
            else
            {
                outBox.AppendText("URL and Port retrieved");
                outBox.AppendText(Environment.NewLine);
                connectionInstance.connection = new dbconnection();

            }
            connected = connectionInstance.connection.open();
            if (connected)
            {
                outBox.AppendText("Database connected");
                outBox.AppendText(Environment.NewLine);
                connectionInstance.connected = true;

            }
            else
            {
                outBox.AppendText("Error: Bad connection. Check network access and config data!");
                outBox.AppendText(Environment.NewLine);
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (!connected)
            {
                outBox.AppendText("Error: No active connection found");
                outBox.AppendText(Environment.NewLine);
                return;
            }
            else
            {
                connected = false;
                outBox.AppendText("Connection closed");
                outBox.AppendText(Environment.NewLine);
                connectionInstance.connection.close();
                connectionInstance.connected = false;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {

            String query;
            String[] readdata;
            query = inBox.Text.ToString();
            inBox.Clear();



            if (!connected)
            {
                outBox.AppendText("Error: No active connection found");
                outBox.AppendText(Environment.NewLine);
                return;
            }
            else
            {
                try
                {
                    readdata = connectionInstance.connection.showdb(query);
                    for (int i = 0; i < readdata.Length; i++)
                    {
                        outBox.AppendText(readdata[i]);
                        outBox.AppendText(Environment.NewLine);
                    }
                }
                catch
                {

                    return;
                }



            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            outBox.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (connectionInstance.connected)
            {
                (new Form2()).Show();
            }
            else
            {
                outBox.AppendText("Error: Create a connection instance first!");
                outBox.AppendText(Environment.NewLine);
            }


        }

        private void inBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void outBox_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
