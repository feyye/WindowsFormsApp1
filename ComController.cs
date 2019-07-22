using System;
using System.Collections;
using System.Collections.Generic;
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
            if (lastCommand.Equals("AT:GS")&&hex2String.Contains("STAT:"))
            {
                
                string[] results = Regex.Split(hex2String, "\r\n");
                for (var i = 0; i < results.Length; i++)
                {
                    String result = results[i];
                    if (result.Contains(followMac))
                    {

                        String rssiStr = results[i + 1];
                        int start = rssiStr.IndexOf('(') + 1;
                        int end = rssiStr.IndexOf(')');
                        String rssi = rssiStr.Substring(start, end - start);
                        Console.Write(hex2String);
                        
                        sendCommand("AT:DS-"+followMac);
                        break;

                    }
                }

                Console.Write(hex2String);

            }else if (lastCommand.Contains("AT:DS-"))
            {
                Console.Write(hex2String);
                if (hex2String.Contains("OK"))
                {
                    testResult(true);
                }else if (hex2String.Contains("CM"))
                {
                    testResult(true);
                }

            }
            
            if (hex2String.Contains("ERR-")){
                testResult(false);
                
            }
        }

        void followComReceiveDataEvent(Object sender, SerialPortEventArgs e)
        {
            followComReceiveData.Append(Encoding.Default.GetString(e.receivedBytes));
            Console.WriteLine(e.receivedBytes);
            string lastCommand = getLastCommand();
            if (lastCommand.Equals("TTM:MAC-?"))
            {
                string hex2String = Hex2String(Bytes2Hex(e.receivedBytes));

                if (hex2String.Contains(lastCommand))
                {
                    String mac = hex2String.Replace("\r\n", "").Replace("TTM:MAC-?", "").Replace("TTM:MAC-", "")
                        .Replace(" ", "");
                    //解决最后一位空格的问题
                    mac = mac.Substring(0, mac.Length - 1);
                    followMac = mac;
                    sendCommand("AT:GS");
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
            view.testResuktEvent(success);

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

        public void test()
        {
            followComReceiveData.Clear();
            comReceiveData.Clear();
            followMac = "";
            isDone = false;
            
            flows.Clear();
            sendFollowCommand("TTM:MAC-?");
            
        }

    }
}