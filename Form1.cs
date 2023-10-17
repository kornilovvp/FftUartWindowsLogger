using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Configuration;
using System.Windows.Forms.DataVisualization.Charting;
using System.Collections;






namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        


        public Form1()
        {
            InitializeComponent();
        }


        //int[] chart_data = null;
        //ArrayList my_array = new ArrayList();


        Series my_series = null;

        Timer my_timer = null;

        int my_cnt = 0;


        private void Form1_Load(object sender, EventArgs e)
        {
            string[] list_of_ports = System.IO.Ports.SerialPort.GetPortNames();

            comboBox1.Items.AddRange(list_of_ports);
            comboBox1.SelectedIndex = 0;


            //mylist.Add();

            my_series = new Series();

            


            double[] y = { 85, 156, 179.5, 211, 123 };
            string[] x = { "0", "5", "10", "15", "20" };

            my_series.Points.AddXY(x[0], y[0]);
            my_series.Points.AddXY(x[1], y[1]);
            my_series.Points.AddXY(x[2], y[2]);
            my_series.Points.AddXY(x[3], y[3]);
            my_series.Points.AddXY(x[4], y[4]);

           // my_series.Points[0].SetValueXY(333, "55"); 


            chart1.Series[0].LegendText = "Statistics";
            //chart1.Series[0].ChartType = SeriesChartType.Bar;
            chart1.Series[0].ChartType = SeriesChartType.Column;
            chart1.Series[0].IsValueShownAsLabel = true;
            chart1.Series[0].IsVisibleInLegend = false;

            //chart1.Series[0].Points.DataBindXY(x, y);
            chart1.Series.Add(my_series);

            // Задайте автоматический масштаб для осей X и Y
            chart1.ChartAreas[0].AxisX.Minimum = double.NaN;
            chart1.ChartAreas[0].AxisX.Maximum = double.NaN;
            chart1.ChartAreas[0].AxisY.Minimum = double.NaN;
            chart1.ChartAreas[0].AxisY.Maximum = double.NaN;

            chart1.Invalidate();

            chart1.Visible = true;
            chart1.Enabled = true;


            my_timer = new Timer();
            my_timer.Interval = 100;
            my_timer.Tick += my_timer_tick_ivent;
            my_timer.Start();


        }

        private void my_timer_tick_ivent(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            my_cnt++;

            if(my_cnt >= 255)
            {
                my_cnt = 0;
            }

            //my_series.Points.Add(my_cnt);
            my_series.Points[0].YValues[0] = my_cnt;

            chart1.Invalidate();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
