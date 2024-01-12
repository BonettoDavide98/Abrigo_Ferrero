using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClientEEIP.ClassiMie
{
    public class TcpUdpData
    {
        public Socket Socket { get; set; }
        public IPEndPoint LocalEndPoint { get; set; }
        public IPEndPoint RemoteEndPoint { get; set; }
        public byte[] TcpData { get; set; }
        public byte[] UdpData { get; set; }

        public TcpUdpData(IPEndPoint Remoteep, IPEndPoint Localep, byte[] data)
        {
            LocalEndPoint = Localep;
            RemoteEndPoint = Remoteep;
            UdpData = data;
        }

        public TcpUdpData(Socket socketTcp, byte[] data)
        {
            Socket = socketTcp;
            TcpData = data;
        }
    }
}
