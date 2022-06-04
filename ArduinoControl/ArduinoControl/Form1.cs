using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace ArduinoControl
{
    public partial class Form1 : Form
    {
        String[] ports;
        SerialPort port;
        bool isConnected = false;
        String lcd_Text;

        public Form1()
        {
            InitializeComponent();
            getAvailableCOM_PORTS();

            foreach (string port in ports)
            {
                comboBox1.Items.Add(port);
                Console.WriteLine(port);

                if (ports[0] != null)
                {
                    comboBox1.SelectedItem = ports[0];
                }
            }


        }

        private void label6_Click(object sender, EventArgs e)
        {
            // PASS 
        }

        private void label7_Click(object sender, EventArgs e)
        {
            // PASS 
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (isConnected)
            {
                if (checkBox2.Checked)
                {
                    port.Write("$LEDGON");
                }
                else
                {
                    port.Write("$LEDGOF");
                }
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (isConnected)
            {
                if (checkBox3.Checked)
                {
                    port.Write("$LEDBON");
                }
                
                 else
                {
                    port.Write("$LEDBOF");
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void getAvailableCOM_PORTS ()
        {
            ports = SerialPort.GetPortNames();
        }

        private void connectToArduino ()
        {
            isConnected = true;
            string selectedPort = comboBox1.GetItemText(comboBox1.SelectedItem);
            port = new SerialPort(selectedPort, 9600, Parity.None, 8, StopBits.One);
            port.Open();
            button2.Text = "Disconnect";
        }

        private void disconnectFromArduino ()
        {
            isConnected = false;
            port.Close();
            button2.Text = "Connect";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!isConnected)
            {
                connectToArduino();
            }

            else
            {
                disconnectFromArduino();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (isConnected)
            {
                if (checkBox1.Checked)
                {
                    port.Write("$LEDRON");
                }

                else
                {
                    port.Write("$LEDROF");
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // PASS 
        }

        private void label4_Click(object sender, EventArgs e)
        {
            // PASS 
        }

        private void label5_Click(object sender, EventArgs e)
        {
            // PASS 
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (isConnected)
            {
                if (checkBox4.Checked)
                {
                    port.Write("$LEDYON");
                }
                
                else
                {
                    port.Write("$LEDYOF");
                }
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isConnected)
            {
                port.Write(string.Format("$LCD_{0}", textBox1.Text));
            }
        }
    }
}
