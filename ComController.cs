using System;
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

        public void test()
        {


            String followMac = getFollowMac();


            int followMacLength = followMac.Length;
            
            String macs = globalScan(followMac);
            
            
//            String destination = destinationScan(followMac);
            
          

            


//            Console.WriteLine("Hello World");
        }

        private String destinationScan(String mac)
        {
            SendDataToCom("AT:DS-"+mac);
            Thread.Sleep(200);
            SerialPortEventArgs serialPortEventArgs = comModel.getSerialPortEvent();
            string hex2String = Hex2String(Bytes2Hex(serialPortEventArgs.receivedBytes));

            return hex2String;
        }
        private String globalScan(String mac)
        {
            SendDataToCom("AT:GS");
            Thread.Sleep(5000);
           
            
            
            

            Timer timer = new Timer(o =>
            {
                string[] results = loadGlobalScanRecieveData();
                for (var i = 0; i < results.Length; i++)
                {
                    String result = results[i];
                    if (result.Contains(mac))
                    {

                        String rssiStr = results[i + 1];
                        int start = rssiStr.IndexOf('(')+1;
                        int end = rssiStr.IndexOf(')');
                        String rssi = rssiStr.Substring(start, end-start);

                        String a = "a";
                    }
                }
                string scan = destinationScan(mac);
            }, null, 500, -1);
            

//            new Timer(o => loadRecieveData());
            
//            Task.Delay(5000, tokenSource.Token);
            return null;
        }

        private String[] loadGlobalScanRecieveData()
        {
            SerialPortEventArgs serialPortEventArgs = comModel.getSerialPortEvent();
            string hex2String = Hex2String(Bytes2Hex(serialPortEventArgs.receivedBytes));
            string[] results = Regex.Split(hex2String, "\r\n");
            return results;
        }
        private String getFollowMac()
        {
            followSendDataToCom("TTM:MAC-?");
            Thread.Sleep(100);
            SerialPortEventArgs serialPortEventArgs = followComModel.getSerialPortEvent();
            
            string hex2String = Hex2String(Bytes2Hex(serialPortEventArgs.receivedBytes));
            String mac = hex2String.Replace("\r\n", "").Replace("TTM:MAC-?","").Replace("TTM:MAC-","").Replace(" ","");
            //解决最后一位空格的问题
            mac = mac.Substring(0, mac.Length - 1);
            return mac.Trim();
        }
        
    }
}