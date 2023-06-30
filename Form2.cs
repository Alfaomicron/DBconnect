using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace database_connection
{
    public partial class Form2 : Form
    {
        System.Timers.Timer dataTimer = new System.Timers.Timer();

        public class subprocess
        {
            public static Chart chart = new Chart();
        }

        public Form2()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            this.FormClosed += Form2_FormClosed;
            textBox1.Clear();
            textBox2.Clear();
            subprocess.chart = chart1;
            dataTimer.Elapsed += new ElapsedEventHandler(timeOutEvent);
            dataTimer.Interval = graphdata.tsampling;
            dataTimer.Enabled = true;
            dataTimer.AutoReset = true;
    }

        private void graphconfig(object source)
        {

        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            //throw new NotImplementedException();
            dataTimer.Stop();   
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'datasetsDataSet.IMDB_global' Puede moverla o quitarla según sea necesario.

        }

        private void timeOutEvent(object source, ElapsedEventArgs e)
        {
            //Data acquisition
            String[,] readdata = new String[2, graphdata.nsamples];

            readdata = connectionInstance.connection.getdata();

            subprocess.chart.Series["dbPoints"].Points.Clear();
            for (int i = 0; i < graphdata.nsamples; i++)
            {
                subprocess.chart.Series["dbPoints"].Points.AddXY(readdata[0, i], readdata[1, i]);
            }
        }


        private void chart1_Click(object sender, EventArgs e)
        {
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(12, 12);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "dbPoints";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "dbPoints2";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(858, 569);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            title1.Name = "Title1";
            title1.Text = "dbPoints";
            this.chart1.Titles.Add(title1);
            this.chart1.Click += new System.EventHandler(this.chart1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(739, 244);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(755, 216);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "N samples";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(739, 373);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 22);
            this.textBox2.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(755, 341);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "T sampling";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(758, 455);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form2
            // 
            this.ClientSize = new System.Drawing.Size(882, 593);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.chart1);
            this.Name = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataTimer.Enabled = false;
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                //Default samples number value;
                graphdata.nsamples = 20;
            }
            else
            {
                graphdata.nsamples = Convert.ToUInt16(textBox1.Text.ToString(), 16);
            }

            if (String.IsNullOrEmpty(textBox2.Text))
            {
                //Default sampling period (ms)
                graphdata.tsampling = 1000;
            }
            else
            {
                graphdata.tsampling = Convert.ToUInt16(textBox2.Text.ToString(), 16);
            }
            dataTimer.Enabled = true;
        }
    }
}
