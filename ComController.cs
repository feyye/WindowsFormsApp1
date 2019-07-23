using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
//using System.Threading.Tasks;
using System.Windows.Forms;
using COMDBG;
using Timer = System.Threading.Timer;

namespace WindowsFormsApp1
{
    public class ComController
    {
        ComModel comModel = new ComModel();
        ComModel followComModel = new ComModel();
        IView view;
        List<String> flows = new List<String>();

        private String followMac = "";
        private Boolean isDone = false;


        private String mainRssiThreshold;
        private String followRssiThreshold;
        private String sendRssi;
        private String recieveRssi;
        private TestModel testModel = new TestModel();
        private Dictionary<String,TestModel> testModelMap = new Dictionary<String,TestModel>();

        private StringBuilder comReceiveData = new StringBuilder();
        private StringBuilder followComReceiveData = new StringBuilder();

        public ComController(IView view)
        {
            this.view = view;
            this.view.SetController(this);


            //main
            comModel.comCloseEvent += new SerialPortEventHandler(this.view.CloseComEvent);
            comModel.comOpenEvent += new SerialPortEventHandler(this.view.OpenComEvent);
            comModel.comReceiveDataEvent += new SerialPortEventHandler(this.view.ComReceiveDataEvent);


            //follow
            followComModel.comCloseEvent += new SerialPortEventHandler(this.view.followCloseComEvent);
            followComModel.comOpenEvent += new SerialPortEventHandler(this.view.followOpenComEvent);
            followComModel.comReceiveDataEvent += new SerialPortEventHandler(this.view.followComReceiveDataEvent);


            comModel.comReceiveDataEvent += ComReceiveDataEvent;
            followComModel.comReceiveDataEvent += followComReceiveDataEvent;
            
            
            
            
            
        }


        private void comNum()
        {
            
        }


        private static byte[] FromHex(string hex)
        {
            hex = hex.Replace("-", "");
            byte[] raw = new byte[hex.Length / 2];
            for (int i = 0; i < raw.Length; i++)
            {
                try
                {
                    raw[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
                }
                catch (System.Exception)
                {
                    //Do Nothing
                }
            }

            return raw;
        }

        /// <summary>
        /// Hex string to string
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        public static String Hex2String(String hex)
        {
            byte[] data = FromHex(hex);
            return Encoding.Default.GetString(data);
        }

        /// <summary>
        /// String to hex string
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static String String2Hex(String str)
        {
            Byte[] data = Encoding.Default.GetBytes(str);
            return BitConverter.ToString(data);
        }

        /// <summary>
        /// Hex string to bytes
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        public static Byte[] Hex2Bytes(String hex)
        {
            return FromHex(hex);
        }

        /// <summary>
        /// Bytes to Hex String
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static String Bytes2Hex(Byte[] bytes)
        {
            return BitConverter.ToString(bytes);
        }

        /// <summary>
        /// send bytes to serial port
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool SendDataToCom(Byte[] data)
        {
            return comModel.Send(data);
        }

        /// <summary>
        /// Send string to serial port
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public bool SendDataToCom(String str)
        {
            if (str != null && str != "")
            {
                return comModel.Send(Encoding.Default.GetBytes(str));
            }

            return true;
        }

        /// <summary>
        /// Open serial port in comModel
        /// </summary>
        /// <param name="portName"></param>
        /// <param name="baudRate"></param>
        /// <param name="dataBits"></param>
        /// <param name="stopBits"></param>
        /// <param name="parity"></param>
        /// <param name="handshake"></param>
        public void OpenSerialPort(string portName, String baudRate,
            string dataBits, string stopBits, string parity, string handshake)
        {
            if (portName != null && portName != "")
            {
                comModel.Open(portName, baudRate, dataBits, stopBits, parity, handshake);
            }
        }

        /// <summary>
        /// Close serial port in comModel
        /// </summary>
        public void CloseSerialPort()
        {
            comModel.Close();
        }


        /// <summary>
        /// send bytes to serial port
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool followSendDataToCom(Byte[] data)
        {
            return followComModel.Send(data);
        }

        /// <summary>
        /// Send string to serial port
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public bool followSendDataToCom(String str)
        {
            if (str != null && str != "")
            {
                return followComModel.Send(Encoding.Default.GetBytes(str));
            }

            return true;
        }

        /// <summary>
        /// Open serial port in comModel
        /// </summary>
        /// <param name="portName"></param>
        /// <param name="baudRate"></param>
        /// <param name="dataBits"></param>
        /// <param name="stopBits"></param>
        /// <param name="parity"></param>
        /// <param name="handshake"></param>
        public void followOpenSerialPort(string portName, String baudRate,
            string dataBits, string stopBits, string parity, string handshake)
        {
            if (portName != null && portName != "")
            {
                followComModel.Open(portName, baudRate, dataBits, stopBits, parity, handshake);
            }
        }

        /// <summary>
        /// Close serial port in comModel
        /// </summary>
        public void followCloseSerialPort()
        {
            followComModel.Close();
        }


        void ComReceiveDataEvent(Object sender, SerialPortEventArgs e)
        {
            comReceiveData.Append(Encoding.Default.GetString(e.receivedBytes));
            string hex2String = Hex2String(Bytes2Hex(e.receivedBytes));

            string lastCommand = getLastCommand();
            if (getLastCommand().Equals("AT:GS") && hex2String.Contains("STAT:"))
            {
                string[] results = Regex.Split(hex2String, "\r\n");
                for (var i = 0; i < results.Length; i++)
                {
                    String result = results[i];
                    if (result.Contains(testModel.mac))
                    {
                        String rssiStr = results[i + 1];
                        int start = rssiStr.IndexOf('(') + 1;
                        int end = rssiStr.IndexOf(')');
                        String rssi = rssiStr.Substring(start, end - start);
                        if (Int32.Parse(rssi) < Int32.Parse(testModel.sendRssiThreshold))
                        {
                            testResult(false);
                        }
                        else
                        {
                            testModel.sendRssi = rssi;
                            sendCommand("AT:DS-" + testModel.mac);
                        }

                        break;
                    }
                }

                Console.Write(hex2String);
            }
            else if (getLastCommand().Contains("AT:DS-"))
            {
                if (hex2String.Contains("SBM"))
                {
                    testResult(false);
                    
                }else if (hex2String.Contains("OK"))
                {
//                    testResult(true);
                }
                else if (hex2String.Contains("CM"))
                {
//                    testResult(true);

                    sendFollowCommand("TTM:RSI-ON");
                }
            }

            if (hex2String.Contains("ERR-"))
            {
                testResult(false);
            }
        }

        void followComReceiveDataEvent(Object sender, SerialPortEventArgs e)
        {
            followComReceiveData.Append(Encoding.Default.GetString(e.receivedBytes));
//            Console.WriteLine(flows.ToString());
            string hex2String = Hex2String(Bytes2Hex(e.receivedBytes));

            string lastCommand = getLastCommand();
            
            if (hex2String.Contains("Module is work!"))
            {
//                test("-60", "-60");
                this.view.start();
            }else if (getLastCommand().Equals("TTM:MAC-?"))
            {
                if (hex2String.Contains(getLastCommand()))
                {
                    String mac = hex2String.Replace("\r\n", "").Replace("TTM:MAC-?", "").Replace("TTM:MAC-", "")
                        .Replace(" ", "");
                    //解决最后一位空格的问题
                    mac = mac.Substring(0, mac.Length - 1);
                    followMac = mac;
                    testModel.mac = mac;
                    sendCommand("AT:GS");
                }
            }
            else if (getLastCommand().Equals("TTM:RSI-ON"))
            {
                string[] results = Regex.Split(hex2String, "\r\n");
                for (var i = 0; i < results.Length; i++)
                {
//                    Int32 sum = 0;
                    if (results[i].Contains("TTM:RSI") && results[i].Contains("dBm"))
                    {
                        String rssi = results[i].Replace("TTM:RSI", "").Replace("dBm", "").Trim();
                        testModel.rssiList.Add(Int32.Parse(rssi));
//                        sum = Int32.Parse(rssi)+ sum;
                        //合格

//                        Console.Write(hex2String);
                        if (testModel.rssiList.Count == 3)
                        {
                            int sum = testModel.rssiList.Sum();

                            if (sum / testModel.rssiList.Count > Int32.Parse(testModel.recieveRssiThreshold)) //合格
                            {
                                testModel.recieveRssi = (sum / testModel.rssiList.Count).ToString();
                                testModelMap.Remove(testModel.mac);
                                testModelMap.Add(testModel.mac,testModel);
                                testResult(true);
                            }
                            else
                            {
                                testResult(false);
                            }

                            sendFollowCommand("TTM:RSI-OFF");
                        }
                    }
                }
            }
        }

        public void testResult(Boolean success)
        {
            if (isDone)
            {
                return;
            }

            isDone = true;
            view.testResuktEvent(success, testModelMap);
        }


        public String getLastCommand()
        {
            if (flows == null || flows.Count == 0)
            {
                return "";
            }

            string lastCommand = flows[flows.Count - 1];

            return lastCommand;
        }

        public void sendCommand(String command)
        {
            flows.Add(command);
            SendDataToCom(command);
        }

        public void sendFollowCommand(String command)
        {
            flows.Add(command);
            followSendDataToCom(command);
        }

        public void test(string sendRssiThreshold, string recieveRssiThreshold)
        {
            followComReceiveData.Clear();
            comReceiveData.Clear();
            followMac = "";
            isDone = false;
            flows.Clear();
            testModel = new TestModel();
//            testModel.mac = followMac;
            testModel.sendRssiThreshold = sendRssiThreshold;
            testModel.recieveRssiThreshold = recieveRssiThreshold;
            testModel.time = DateTime.Now;
            testModel.rssiList = new List<Int32>();
            sendFollowCommand("TTM:MAC-?");
        }

        public void saveTestResult(string file)
        {
            String dateTime = DateTime.Now.ToString("yyyy年MM月dd日HH时mm分ss秒");
            String path = file + "\\test-"+dateTime+".txt";
            String lineBreak = "\r\n";
            foreach (KeyValuePair<string,TestModel> model in testModelMap)
            {
                
                File.AppendAllText(path, "mac : "+model.Value.mac + lineBreak, Encoding.UTF8);
                File.AppendAllText(path, "time : "+model.Value.time + lineBreak, Encoding.UTF8);
                File.AppendAllText(path, "sendRssi : "+model.Value.sendRssi + lineBreak, Encoding.UTF8);
                File.AppendAllText(path, "recieveRssi : "+model.Value.recieveRssi + lineBreak, Encoding.UTF8);
                File.AppendAllText(path, lineBreak, Encoding.UTF8);
                
            }
            
            
            
            File.AppendAllText(path, "总共 : "+testModelMap.Count + "个测试通过", Encoding.UTF8);
            
            testModelMap = new Dictionary<String,TestModel>();

            
        }
    }
}