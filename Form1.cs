using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using COMDBG;
using Microsoft.Office.Interop;


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
            this.Closing += new CancelEventHandler(Form1_Closing);
        }


        private void initFollowComponent()
        {
            string[] ports = SerialPort.GetPortNames();
            for (var i = 0; i < ports.Length; i++)
            {
                followSerialComboBox.Items.Add(ports[i]);
                followSerialComboBox.SelectedIndex = 0;

            }

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
                mainSerialComboBox.SelectedIndex = 0;
            }

            
            mainRateComboBox.Items.AddRange(new object[] {4800, 9600, 19200, 38400, 57600, 115200});
            mainRateComboBox.SelectedIndex = 5;
            MainDTRCheckBox.Checked = true;
            MainRTXCheckBox.Checked = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Console.Write("");
        }
        
        private void Form1_Closing(object sender, CancelEventArgs e)
        {
            if (MessageBox.Show("退出测试数据会消失，是否要退出!", "是否确认退出？", MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question) == DialogResult.OK)
            {
                
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            try
            {
                Button btn = (Button) sender;
                if (btn.Text.Equals("打开"))
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
            }
            catch (Exception exception)
            {
                
            }
            
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
            
            this.BackColor = Color.White;
            Button btn = (Button) sender;
            btn.Enabled = false;

            this.mainTextBox.Text = "开始测试\r\n";
            this.followTextBox.Text = "开始测试\r\n";
            this.testResultLabel.Text = "";


            this.controller.test(this.mainRSSIThreshold.Text, this.followRSSIThreshold.Text);
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
//            throw new System.NotImplementedException();
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
                this.mainSerialOpenBtn.Text = "关闭";
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
                this.mainSerialOpenBtn.Text = "打开";
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
                this.followSerialOpenBtn.Text = "关闭";
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
                this.followSerialOpenBtn.Text = "打开";
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


        public void testResuktEvent(bool success, Dictionary<string, TestModel> testModel)
        {
            if (this.InvokeRequired)
            {
                try
                {
//                    Invoke(new Action<Object, SerialPortEventArgs>(followCloseComEvent), sender, e);

                    Invoke(new Action<Boolean, Dictionary<string, TestModel>>((success1, testModel1) => testResuktEvent(success1, testModel1)), success, testModel);
                }
                catch (System.Exception)
                {
                    //disable form destroy exception
                }

                return;
            }


            if (success)
            {
                showSuccessResult(testModel);
            }
            else
            {
                showFailResult();
            }
        }

        public void start()
        {
            if (this.InvokeRequired)
            {
                try
                {
//                    Invoke(new Action<Object, SerialPortEventArgs>(followCloseComEvent), sender, e);


                    Invoke(new Action(start));

                }
                catch (System.Exception)
                {
                    //disable form destroy exception
                }

                return;
            }
            
            
            this.testBtn.PerformClick();
            
        }

        public void clear()
        {
            this.testResultLabel.Text = "";
            this.BackColor = Color.White;
            this.resultLabel.Text = "测试成功0个";

        }

        private void followSerialOpenBtn_Click(object sender, EventArgs e)
        {
            Button btn = (Button) sender;
            if (btn.Text.Equals("打开"))
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
            try
            {
                Button btn = (Button) sender;
                if (btn.Text.Equals("打开"))
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
            catch (Exception exception)
            {
                
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
//            MessageBox.Show("失败");
            this.BackColor = Color.DarkRed;
            this.testResultLabel.Text = "失败";
        }

        public void showSuccessResult(Dictionary<string, TestModel> testModel)
        {
//            MessageBox.Show("测试成功");

            this.resultLabel.Text = "测试成功" + testModel.Count + "个";
            this.BackColor = Color.Green;
            this.testResultLabel.Text = "成功";
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog openFileDialog = new FolderBrowserDialog();
            openFileDialog.Description = "choose file to save";
//            openFileDialog.
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string file = openFileDialog.SelectedPath;
                if (file != null)
                {
                    this.controller.saveTestResult(file);
                }
            }
        }
        
        
        
        

        private void mainRSSIThreshold_TextChanged(object sender, KeyPressEventArgs e)
        {
//            throw new System.NotImplementedException();

            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char) 13 && e.KeyChar != (char) 8)
            {
                e.Handled = true;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            mainSerialComboBox.Items.Clear();
            string selectedText = mainSerialComboBox.SelectedText;
//            int selectedIndex = mainSerialComboBox.SelectedIndex;
//            object item = mainSerialComboBox.SelectedItem;
//            string text = mainSerialComboBox.Text;
            for (var i = 0; i < ports.Length; i++)
            {
                mainSerialComboBox.Items.Add(ports[i]);
                mainSerialComboBox.SelectedIndex = 0;
                if (selectedText.Equals(ports[i]))
                {
                    mainSerialComboBox.SelectedIndex = i;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            followSerialComboBox.Items.Clear();
            string selectedText = followSerialComboBox.SelectedText;
            for (var i = 0; i < ports.Length; i++)
            {
                followSerialComboBox.Items.Add(ports[i]);
                followSerialComboBox.SelectedIndex = 0;
                if (selectedText.Equals(ports[i]))
                {
                    followSerialComboBox.SelectedIndex = i;
                }
            }
        }

        private void mainTextBox_TextChanged(object sender, EventArgs e)
        {
//            Console.Write("sadada");
            this.controller.mainBoxTextChange(this.mainTextBox.Text);
        }

        private void followTextBox_TextChanged(object sender, EventArgs e)
        {
            this.controller.followBoxTextChange(this.followTextBox.Text);
        }
    }
}