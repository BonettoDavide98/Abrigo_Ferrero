using ClientEEIP.ClassiMie;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ClientEEIP
{
    internal class UdpDataServer
    {
        private Socket _socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        private const int bufSize = 8 * 1024;
        private State state = new State();
        private EndPoint epFrom = new IPEndPoint(IPAddress.Any, 0);
        private AsyncCallback recv = null;

        public static event EventHandler<TcpUdpData> OnReceiveData;

        public class State
        {
            public byte[] buffer = new byte[bufSize];
        }

        public void Server(string address, int port)
        {
            try
            {
                _socket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.ReuseAddress, true);
                _socket.Bind(new IPEndPoint(IPAddress.Parse(address), port));
                Receive();
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
        }

        public void Client(string address, int port)
        {
            try
            {
                _socket.Connect(IPAddress.Parse(address), port);
                Receive();
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
        }

        public void Send(string text)
        {
            try
            {
                byte[] data = Encoding.ASCII.GetBytes(text);
                _socket.BeginSend(data, 0, data.Length, SocketFlags.None, (ar) =>
                {
                    State so = (State)ar.AsyncState;
                    int bytes = _socket.EndSend(ar);
                    //Console.WriteLine("SEND: {0}, {1}", bytes, text);
                }, state);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
        }

        private void Receive()
        {
            try
            {
                _socket.BeginReceiveFrom(state.buffer, 0, bufSize, SocketFlags.None, ref epFrom, recv = (ar) =>
                {
                    try
                    {
                        State so = (State)ar.AsyncState;
                        int bytes = _socket.EndReceiveFrom(ar, ref epFrom);
                        _socket.BeginReceiveFrom(so.buffer, 0, bufSize, SocketFlags.None, ref epFrom, recv, so);

                        byte[] ret = new byte[bytes];
                        for (int i = 0; i < bytes; i++)
                            ret[i] = so.buffer[i];

                        if (OnReceiveData != null)
                            OnReceiveData(new object(), new TcpUdpData(epFrom as IPEndPoint, _socket.LocalEndPoint as IPEndPoint, ret));
                        //Console.WriteLine("RECV: {0}: {1}, {2}", epFrom.ToString(), bytes, Encoding.ASCII.GetString(so.buffer, 0, bytes));
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }, state);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
        }
    }
}