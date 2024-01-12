using ClientEEIP.ClassiMie;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace ClientEEIP
{
    public class ClientEEIPManager
    {
        private GestisciRichiesta gestisciRichiesta;
        private Action<byte[], byte[], bool> action = null;

        public IPAddress SlaveIP;

        private UdpServer s = null;
        private Task t1 = null;
        private Thread t2 = null;

        private bool stop = false;

        public ClientEEIPManager(Action<byte[], byte[], bool> action)
        {
            try
            {
                this.action = action;
                this.gestisciRichiesta = new GestisciRichiesta();
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
        }

        public void Start(IPAddress slaveIP)
        {
            try
            {
                //UdpServer.OnReceiveData += UdpServerAsync_OnReceiveData;
                //s = new UdpServer();
                //s.Server("0.0.0.0", 44818);

                t1 = Task.Run(() =>
                {
                    TcpServerAsync.OnReceiveData += TcpServerAsync_OnReceiveData;
                    TcpServerAsync.StartListening(new IPEndPoint(IPAddress.Parse("0.0.0.0"), 44818), SocketType.Stream, ProtocolType.Tcp);
                });

                t2 = new Thread(new ThreadStart(() =>
                {
                    while (!stop)
                    {
                        if (ClassiMie.TcpUdp.UdpDataHandler.arrayLeggi != null && ClassiMie.TcpUdp.UdpDataHandler.arrayScrivi != null)
                        {
                            bool onLine = DateTime.Now.Subtract(ClassiMie.TcpUdp.UdpDataHandler.lastArrived).TotalMilliseconds < 1000;
                            this.action?.Invoke(ClassiMie.TcpUdp.UdpDataHandler.arrayLeggi, ClassiMie.TcpUdp.UdpDataHandler.arrayScrivi, onLine);

                        }
                        Thread.Sleep(10);
                    }
                }));
                t2.Priority = ThreadPriority.Highest;
                t2.Start();
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
        }

        public void Stop()
        {
            stop = true;
            ClientEEIP.ClassiMie.TcpUdp.UdpDataHandler.chiudi = true;
            TcpServerAsync.Stop();
            t1.Wait();
            t2.Join();
            s?.Close();
        }

        private void TcpServerAsync_OnReceiveData(object sender, TcpUdpData received)
        {
            try
            {
                Socket s = received.Socket;

                gestisciRichiesta.setSlaveEp((IPEndPoint)s.LocalEndPoint);
                gestisciRichiesta.setMasterEp((IPEndPoint)s.RemoteEndPoint);

                byte[] toSend = gestisciRichiesta.Gestisci(received.TcpData);
                s.Send(toSend);
                Salva(received.TcpData);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
        }

        private void UdpServerAsync_OnReceiveData(object sender, TcpUdpData received)
        {
            try
            {
                Socket s = new Socket(SocketType.Dgram, ProtocolType.Udp);

                //gestisciRichiesta.setSlaveEp(received.LocalEndPoint);
                gestisciRichiesta.setSlaveEp(new IPEndPoint(SlaveIP, 44818));
                gestisciRichiesta.setMasterEp(received.RemoteEndPoint);

                s.Bind(gestisciRichiesta.GetSlaveEp());
                s.Connect(gestisciRichiesta.getMasterEp());
                s.Send(gestisciRichiesta.Gestisci(received.UdpData));
                s.Close();
                Salva(received.UdpData);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
        }

        private void Salva(byte[] arrived)
        {
            //try
            //{
            //    bool salva = false;
            //    if (salva)
            //    {
            //        int valoriPerBlocco = 8;
            //        int blocchiPerRiga = 2;

            //        string contents = "";
            //        for (int i = 1; i < (arrived.Length + 1); i++)
            //        {
            //            contents += arrived[i - 1].ToString("X2") + "\t";
            //            if (i % valoriPerBlocco == 0)
            //                contents += "\t\t";
            //            if (i % (valoriPerBlocco * blocchiPerRiga) == 0)
            //                contents += Environment.NewLine;
            //        }
            //        System.IO.File.WriteAllText(pathSalvataggio + "Received_" + contatore + ".txt", contents);
            //        Application.DoEvents();
            //        contatore++;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    ExceptionHandler.HandleException(ex);
            //}
        }
    }
}
