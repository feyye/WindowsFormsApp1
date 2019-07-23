using System;
using System.Collections.Generic;
using COMDBG;

namespace WindowsFormsApp1
{
    public interface IView
    {
        
        
        void SetController(ComController controller);
        //Open serial port event
        void OpenComEvent(Object sender, SerialPortEventArgs e);
        //Close serial port event
        void CloseComEvent(Object sender, SerialPortEventArgs e);
        //Serial port receive data event
        void ComReceiveDataEvent(Object sender, SerialPortEventArgs e);
        
        
        
        void followOpenComEvent(Object sender, SerialPortEventArgs e);
        //Close serial port event
        void followCloseComEvent(Object sender, SerialPortEventArgs e);
        //Serial port receive data event
        void followComReceiveDataEvent(Object sender, SerialPortEventArgs e);
        
        
        
        
        void testResuktEvent(bool success, Dictionary<string, TestModel> testModel);
        void start();
        
        
    }
}