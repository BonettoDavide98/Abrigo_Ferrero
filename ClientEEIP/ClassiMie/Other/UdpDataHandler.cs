using static ClientEEIP.ClassiMie.CommonPacketFormatType;
using System.Net;
using System.Threading.Tasks;
using System;
using System.Threading;

namespace ClientEEIP.ClassiMie.TcpUdp
{
    public class UdpDataHandler
    {
        IPAddress localAddr;
        int localPort;
        int localAddressFamily;

        IPAddress remoteAddr;
        int remotePort;
        int remoteAddressFamily;

        uint packetCounter = 0;
        public static ushort numberOfChanges { get; set; }

        public static byte[] arrayLeggi;
        public static byte[] arrayScrivi;
        public static int isInizialized { get; set; } = 0;
        byte[] lastHeader;

        public static uint connIdGlobal { get; set; }
        public static uint rpiGlobal { get; set; }

        internal static DateTime lastArrived;
        UdpDataServer s { get; set; }

        public static bool chiudi = false;

        public UdpDataHandler(SockaddrItemType localSockAddr, SockaddrItemType remoteSockAddr)
        {
            try
            {
                s = new UdpDataServer();

                localAddr = localSockAddr.Sin_Addr;
                localPort = localSockAddr.Sin_Port;
                localAddressFamily = localSockAddr.Sin_Family;

                remoteAddr = remoteSockAddr.Sin_Addr;
                remotePort = remoteSockAddr.Sin_Port;
                remoteAddressFamily = remoteSockAddr.Sin_Family;

                lastHeader = new byte[24];
                if(arrayLeggi == null)
                    arrayLeggi = new byte[505];      // Max size of received data after a forwardOpen
                if(arrayScrivi == null)
                    arrayScrivi = new byte[505];

                connIdGlobal = 0;
                rpiGlobal = 0;
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
        }

        public void beginHandle(uint RPI, uint ConnID)
        {
            try
            {
                beginReceive();
                beginSend(RPI, ConnID);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
        }

        void beginReceive()
        {
            try
            {
                Task.Run(() =>
                {
                    if (isInizialized == 0)
                    {
                        UdpDataServer.OnReceiveData += DataReceived;
                        isInizialized = 1;
                        s.Server(localAddr.ToString(), localPort);
                    }
                });
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
        }

        void beginSend(uint RPI, uint ConnID)
        {
            try
            {
                rpiGlobal = RPI;
                connIdGlobal = ConnID;

                if (isInizialized < 2)
                    sendLoop();
                //else
                //    Console.WriteLine("Aggiorno connection id sent: -----> " + connIdGlobal.ToString("X2"));
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
        }

        void sendLoop()
        {
            try
            {
                Task.Run(() =>
                {

                    isInizialized = 2;
                    System.Net.Sockets.UdpClient sender = new System.Net.Sockets.UdpClient();
                    sender.Connect(remoteAddr, remotePort);
                    byte[] arrayToSend = new byte[arrayScrivi.Length + 20];
                    try
                    {
                        while (!chiudi)
                        {

                            lastHeader.CopyTo(arrayToSend, 0);
                            arrayScrivi.CopyTo(arrayToSend, 20);

                            arrayToSend[0] = 2;
                            arrayToSend[1] = 0;     // Item count
                            arrayToSend[2] = 2;
                            arrayToSend[3] = 0x80;  // TypeID
                            arrayToSend[4] = 8;
                            arrayToSend[5] = 0;     // Length                    
                            arrayToSend[6] = (byte)connIdGlobal;
                            arrayToSend[7] = (byte)(connIdGlobal >> 8);
                            arrayToSend[8] = (byte)(connIdGlobal >> 16);
                            arrayToSend[9] = (byte)(connIdGlobal >> 24);      // Address Data
                            arrayToSend[10] = (byte)packetCounter;
                            arrayToSend[11] = (byte)(packetCounter >> 8);
                            arrayToSend[12] = (byte)(packetCounter >> 16);
                            arrayToSend[13] = (byte)(packetCounter >> 24);      // Sequence number
                            arrayToSend[14] = 0xB1;
                            arrayToSend[15] = 0;
                            arrayToSend[16] = (byte)(arrayScrivi.Length + 2);
                            arrayToSend[17] = (byte)((arrayScrivi.Length + 2) >> 8);
                            arrayToSend[18] = (byte)packetCounter;
                            arrayToSend[19] = (byte)(packetCounter >> 8);

                            if (packetCounter == uint.MaxValue)
                                packetCounter = 0;
                            else
                                packetCounter++;

                            sender.Send(arrayToSend, arrayToSend.Length);

                            Thread.Sleep(10);
                            //sniff(arrayToSend, false);

                            //System.Threading.Thread.Sleep((int)(rpiGlobal / 1000));
                            //if (DateTime.Now.Subtract(lastArrived).TotalMilliseconds > 2000)
                            //{
                            //    sender.Dispose();
                            //    break;
                            //}
                            //DateTime dataStart = DateTime.Now;
                            //while (DateTime.Now.Subtract(dataStart).TotalMilliseconds < 10) ;   // Requested Packet Interval è in microsecondi
                        }
                    }
                    catch (Exception ex)
                    {
                        ExceptionHandler.HandleException(ex);
                        sender.Close();

                        isInizialized = 0;
                    }

                });
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
        }

        void DataReceived(object sender, TcpUdpData received)
        {
            try
            {
                lastArrived = DateTime.Now;
                for (int i = 0; i < received.UdpData.Length; i++)
                    if (i <= 23)
                        lastHeader[i] = received.UdpData[i];
                    else
                        arrayLeggi[i - 24] = received.UdpData[i];
                //sniff(received.UdpData, true);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
        }

        void sniff(byte[] buffer, bool received)
        {
            try
            {
                int valoriPerBlocco = 8;
                int blocchiPerRiga = 2;
                string contents = "";

                if (received)
                    Console.Write("========== BEGIN RECEIVED ==========");
                else
                    Console.Write("========== BEGIN SENT ==========");

                for (int i = 0; i < buffer.Length; i++)
                {
                    if (i % valoriPerBlocco == 0)
                        contents += "\t\t";

                    if (i % (valoriPerBlocco * blocchiPerRiga) == 0)
                        contents += Environment.NewLine + (i / (valoriPerBlocco * blocchiPerRiga)) + ")\t";

                    contents += buffer[i].ToString("X2") + "\t";
                }
                Console.WriteLine(contents);
                Console.WriteLine("========== END ==========" + Environment.NewLine);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
        }
    }
}
