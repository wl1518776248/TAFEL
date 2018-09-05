using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Ports;

namespace Winding.Cs
{
    public class SerPort
    {
        ~SerPort()
        { }
        SerialPort serialPort = new SerialPort();
        int scanLength = 0;
        byte[] scanStatus = new byte[] { 0x4C, 0x4F, 0x4E, 0x0D };

        public void InitComm()
        {
            serialPort.PortName = "COM1";
            serialPort.BaudRate = 9600;
            serialPort.Parity = Parity.None;
            serialPort.DataBits = 8;
            serialPort.StopBits = StopBits.One;
            serialPort.ReceivedBytesThreshold = 2;
            serialPort.DataReceived += new SerialDataReceivedEventHandler(Com_DataReceived);
            if (serialPort.IsOpen)
            {
                serialPort.Close();
            }
            serialPort.Open();
        }

        private void Com_DataReceived(System.Object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                byte[] byteData = new byte[2048];
                System.Threading.Thread.Sleep(400);
                scanLength = serialPort.BytesToRead;
                for (int i = 0; i < scanLength; i++)
                {
                    byteData[i] = Convert.ToByte(serialPort.ReadByte());
                    Cs.GlobalVariable.codeStr += (char)byteData[i];
                }
                Cs.GlobalVariable.scanState = true;
            }
            catch (Exception)
            {
            }
        }

        public void SentValueToDatalogic()
        {
            try
            {
                serialPort.Write("CLOSE");
                serialPort.Write("OPEN");
                serialPort.Write("READ");
            }
            catch (Exception)
            {
            }
        }

        public void SentValueToKeyence()
        {
            try
            {
                serialPort.Write(scanStatus, 0, 4);
            }
            catch (Exception)
            {
            }
        }
    }
}
