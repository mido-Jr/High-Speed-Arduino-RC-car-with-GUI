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

namespace CIProjectTeamA5
{
    public partial class Form1 : Form
    {
        string[] arr = { "", "", "" };
        string distanse ;
        SerialPort port = null;
        delegate void serialCalback(string val);

        public Form1()
        {
            InitializeComponent();
            refresh_com();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Led_OFF();
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            Stop();
        }

        private void Btnled_Click(object sender, EventArgs e)
        {
            Led_on();
        }

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            connect();

           
        }

        private void BtnSensor_Click(object sender, EventArgs e)
        {
            distance();
            textBox1.Text = distanse;
        }

        private void DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                SerialPort sp = (SerialPort)sender;
                string incomSting = sp.ReadLine();
                setText(incomSting);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }
        }
        private void setText(string val)
        {
            if (this.textBox1.InvokeRequired)
            {
                serialCalback scb = new serialCalback(setText);
                this.Invoke(scb, new object[] { val });

            }
            else
            {
                distanse = val;

            }
        }
        private void refresh_com()
        {
            comboBox1.DataSource = SerialPort.GetPortNames();
        }
        private void connect()
        {

            port = new SerialPort(comboBox1.SelectedItem.ToString());
            port.BaudRate = 9600;
            port.DataBits = 8;
            port.StopBits = StopBits.One;

            try
            {
                if (!port.IsOpen)
                {
                    port.Open();
                    label3.Text = "connected";
                    label3.ForeColor = Color.Green;
                    MessageBox.Show("Connected Successfully");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            port.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(DataReceived);
        }
        private void disconnect()
        {
            try
            {
                if (port.IsOpen)
                {
                    port.Close();
                    label3.Text = "disconnected";
                    label3.ForeColor = Color.Red;
                    MessageBox.Show("Disconnected Successfully");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            disconnect();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            refresh_com();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void up()
        {
            try
            {
                port.Write("F");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void back()
        {
            try
            {
                port.Write("B");
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
        private void right()
        {
            try
            {
                port.Write("R");
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
        private void left()
        {
            try
            {
                port.Write("F");
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
        private void Stop()
        {
            try
            {
                port.Write("S");
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
        private void Led_on()
        {
            try
            {
                port.Write("X");
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
        private void Led_OFF()
        {
            try
            {
                port.Write("Z");
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
        private void distance()
        {
            try
            {
                port.Write("D");
               // distanse = port.ReadExisting();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            up();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            left();
        }

        private void BtnRight_Click_1(object sender, EventArgs e)
        {
            right();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            back();
        }
    }
}
