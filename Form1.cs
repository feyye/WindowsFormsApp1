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
using COMDBG;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form, IView
    {
        private ComController controller;
        private SerialPort sp = new SerialPort();

        public Form1()
        {
            InitializeComponent();

            initMainComponent();
            initFollowComponent();
        }


        private void initFollowComponent()
        {
            string[] ports = SerialPort.GetPortNames();
            for (var i = 0; i < ports.Length; i++)
            {
                followSerialComboBox.Items.Add(ports[i]);
            }

            followSerialComboBox.SelectedIndex = 0;
            followRateComboBox.Items.AddRange(new object[] {4800, 9600, 19200, 38400, 57600, 115200});
            followRateComboBox.SelectedIndex = 5;
            followDTRCheckBox.Checked = true;
            followRTXCheckBox.Checked = true;
        }

        private void initMainComponent()
        {
            string[] ports = SerialPort.GetPortNames();
            for (var i = 0; i < ports.Length; i++)
            {
                mainSerialComboBox.Items.Add(ports[i]);
            }

            mainSerialComboBox.SelectedIndex = 0;
            mainRateComboBox.Items.AddRange(new object[] {4800, 9600, 19200, 38400, 57600, 115200});
            mainRateComboBox.SelectedIndex = 5;
            MainDTRCheckBox.Checked = true;
            MainRTXCheckBox.Checked = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Button1_Click(object sender, EventArgs e)
        {
//            SerialPort sp = new SerialPort();
//            string[]  ports = SerialPort.GetPortNames();
//            Console.WriteLine("sout");
//            Console.WriteLine(ports);

//            string dataBits, string stopBits, string parity,
//            string handshake

            Button btn = (Button) sender;
            if (btn.Text.Equals("open"))
            {
                string portName = mainSerialComboBox.Text;
                string baudRate = mainRateComboBox.Text;
                string dataBits = "8";
                string stopBits = "1";
                string parity = "None";
                string handshake = "None";
                controller.OpenSerialPort(portName, baudRate, dataBits, stopBits, parity, handshake);
            }
            else
            {
                controller.CloseSerialPort();
            }


//            OpenFileDialog openFileDialog = new OpenFileDialog();
//            openFileDialog.Title = "choose file to save";
//            if (openFileDialog.ShowDialog()==DialogResult.OK)
//            {
//                string file = openFileDialog.FileName;            
//            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void Label1_Click(object sender, EventArgs e)
        {
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void CheckBox1_CheckedChanged_1(object sender, EventArgs e)
        {
        }

        private void Label2_Click(object sender, EventArgs e)
        {
        }

        private void label5_Click(object sender, EventArgs e)
        {
//            throw new System.NotImplementedException();
        }

        private void label6_Click(object sender, EventArgs e)
        {
//            throw new System.NotImplementedException();
        }

        private void label7_Click(object sender, EventArgs e)
        {
//            throw new System.NotImplementedException();
        }

//        private void button2_Click(object sender, EventArgs e)
        private void testStartBtn(object sender, EventArgs e)
        {

            Button btn = (Button) sender;
            btn.Enabled = false;
            
            this.mainTextBox.Text = "开始测试\n";
            this.followTextBox.Text = "开始测试\n";
            
            
            this.controller.test(this.mainRSSIThreshold.Text);
//            this.controller.validateResult(this.mainTextBox);

            btn.Enabled = true;




//            this.mainTextBox.AppendText("测试结束\n");
//            this.followTextBox.AppendText("测试结束\n");
//            
        }

        private void rateComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
//            throw new System.NotImplementedException();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
//            throw new System.NotImplementedException();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
//            throw new System.NotImplementedException();
        }

        private void mainSend_Click(object sender, EventArgs e)
        {
            string text = this.mainSendTextBox.Text;
            if (text.Equals(""))
                return;

            controller.SendDataToCom(text);
        }


        public void SetController(ComController controller)
        {
            this.controller = controller;
        }

        public void OpenComEvent(object sender, SerialPortEventArgs e)
        {
            if (e.isOpend)
            {
                this.mainSerialOpenBtn.Text = "close";
            }
            else
            {
                MessageBox.Show("打开失败");
            }
        }

        public void CloseComEvent(object sender, SerialPortEventArgs e)
        {
            if (this.InvokeRequired)
            {
                Invoke(new Action<Object, SerialPortEventArgs>(CloseComEvent), sender, e);
                return;
            }

            if (!e.isOpend)
            {
                this.mainSerialOpenBtn.Text = "open";
            }
        }

        public void ComReceiveDataEvent(object sender, SerialPortEventArgs e)
        {
            if (this.InvokeRequired)
            {
                try
                {
                    Invoke(new Action<Object, SerialPortEventArgs>(ComReceiveDataEvent), sender, e);
                }
                catch (System.Exception)
                {
                    //disable form destroy exception
                }

                return;
            }

            this.mainTextBox.AppendText(Encoding.Default.GetString(e.receivedBytes));
        }

        public void followOpenComEvent(object sender, SerialPortEventArgs e)
        {
            if (e.isOpend)
            {
                this.followSerialOpenBtn.Text = "close";
            }
            else
            {
                MessageBox.Show("打开失败");
            }
        }

        public void followCloseComEvent(object sender, SerialPortEventArgs e)
        {
            if (this.InvokeRequired)
            {
                Invoke(new Action<Object, SerialPortEventArgs>(followCloseComEvent), sender, e);
                return;
            }

            if (!e.isOpend)
            {
                this.followSerialOpenBtn.Text = "open";
            }
        }

        public void followComReceiveDataEvent(object sender, SerialPortEventArgs e)
        {
            if (this.InvokeRequired)
            {
                try
                {
                    Invoke(new Action<Object, SerialPortEventArgs>(followComReceiveDataEvent), sender, e);
                }
                catch (System.Exception)
                {
                    //disable form destroy exception
                }

                return;
            }

            this.followTextBox.AppendText(Encoding.Default.GetString(e.receivedBytes));
        }

      

        public void testResuktEvent(Boolean success)
        {
            
            if (this.InvokeRequired)
            {
                try
                {
                    Invoke(new Action<Boolean> (testResuktEvent),success);
                }
                catch (System.Exception)
                {
                    //disable form destroy exception
                }

                return;
            }
            

            if (success)
            {
                showSuccessResult();

                
            }
            else
            {
                showFailResult();
            }

        }

        private void followSerialOpenBtn_Click(object sender, EventArgs e)
        {
            Button btn = (Button) sender;
            if (btn.Text.Equals("open"))
            {
                string portName = followSerialComboBox.Text;
                string baudRate = followRateComboBox.Text;
                string dataBits = "8";
                string stopBits = "1";
                string parity = "None";
                string handshake = "None";
                controller.followOpenSerialPort(portName, baudRate, dataBits, stopBits, parity, handshake);
            }
            else
            {
                controller.followCloseSerialPort();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button btn = (Button) sender;
            if (btn.Text.Equals("open"))
            {
                string portName = followSerialComboBox.Text;
                string baudRate = followRateComboBox.Text;
                string dataBits = "8";
                string stopBits = "1";
                string parity = "None";
                string handshake = "None";
                controller.followOpenSerialPort(portName, baudRate, dataBits, stopBits, parity, handshake);
            }
            else
            {
                controller.followCloseSerialPort();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string text = this.followSendTextBox.Text;
            if (text.Equals(""))
                return;

            controller.followSendDataToCom(text);
        }

        public void showFailResult()
        {
            MessageBox.Show("失败");
        }
        public void showSuccessResult()
        {
            MessageBox.Show("测试成功");
        }
        private void saveBtn_Click(object sender, EventArgs e)
        {
            if ("STAT: LIST-#11-0xBA0361220A3D".Contains("BA0361220A3D"))
            {
                String a = "";
            }
        }

        private void mainRSSIThreshold_TextChanged(object sender, EventArgs e)
        {
//            throw new System.NotImplementedException();
        }
    }
}