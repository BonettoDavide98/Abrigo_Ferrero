using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ClientEEIP.ClassiMie
{
    public class StateObject
    {

        public Socket workSocket = null;

        public const int BufferSize = 1024;

        public byte[] buffer = new byte[BufferSize];

        public StringBuilder sb = new StringBuilder();

    }

    public class TcpServerAsync
    {

        public static ManualResetEvent allDone = new ManualResetEvent(false);

        public static event EventHandler<TcpUdpData> OnReceiveData;

        private static bool stop = false;

        public TcpServerAsync() { }

        public static void StartListening(IPEndPoint epMaster, SocketType st, ProtocolType pt)
        {
            try
            {
                Socket listener = new Socket(epMaster.Address.AddressFamily, st, pt);
                listener.Bind(epMaster);
                listener.Listen(100);
                while (!stop)
                {
                    allDone.Reset();

                    listener.BeginAccept(new AsyncCallback(AcceptCallback), listener);

                    allDone.WaitOne();
                }

                listener.Close();
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
        }

        public static void AcceptCallback(IAsyncResult ar)
        {
            try
            {
                allDone.Set();

                Socket listener = (Socket)ar.AsyncState;
                Socket handler = listener.EndAccept(ar);

                StateObject state = new StateObject();
                state.workSocket = handler;
                handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReadCallback), state);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
                allDone.Set();
            }
        }

        public static void ReadCallback(IAsyncResult ar)
        {
            try
            {
                String content = String.Empty;

                StateObject state = (StateObject)ar.AsyncState;
                Socket handler = state.workSocket;

                int bytesRead = handler.EndReceive(ar);

                if (bytesRead > 0)
                {
                    state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead));
                    content = state.sb.ToString();

                    if (OnReceiveData != null)
                        OnReceiveData(new object(), new TcpUdpData(handler, state.buffer));

                    //state.sb.Clear();

                    handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReadCallback), state);
                }
            }
            catch (SocketException sex)
            {
                ExceptionHandler.HandleException(sex);  // Questa eccezione è abbastanza normale
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
        }

        public static void Stop()
        {
            stop = true;
            allDone.Set();
        }

    }
}
