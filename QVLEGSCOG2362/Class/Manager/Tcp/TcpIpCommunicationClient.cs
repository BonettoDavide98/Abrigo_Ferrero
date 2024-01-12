using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace QVLEGSCOG2362.Class
{
    public class TcpIpCommunicationClient
    {

        //public delegate void onRispostaServer(string stringaDiRispostaServer);
        //public event onRispostaServer RispostaServer = null;
        private int timeout = 0;

        public TcpIpCommunicationClient(string ip, int port)
        {
            this.IpAddress = IPAddress.Parse(ip);
            this.Port = port;
            this.timeout = 5000;
        }

        private IPAddress IpAddress { get; set; }
        private int Port { get; set; }

        public string StartClient(string message)
        {
            string response = "";
            // Data buffer for incoming data.
            byte[] bytes = new byte[1024];
            byte[] bytesTemp = new byte[1];

            // Connect to a remote device.
            try
            {
                // Establish the remote endpoint for the socket.
                IPEndPoint remoteEP = new IPEndPoint(this.IpAddress, this.Port);

                // Create a TCP/IP  socket.
                Socket sender = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                // Connect the socket to the remote endpoint. Catch any errors.
                try
                {
                    sender.Connect(remoteEP);

                    //TIMEOUT RICEZIONE RISPOSTA DAL SERVER
                    sender.ReceiveTimeout = this.timeout;

                    // Encode the data string into a byte array.
                    byte[] msg = Encoding.ASCII.GetBytes(message);

                    // Send the data through the socket.
                    int bytesSent = sender.Send(msg);

                    int bytesRec = 0;
                    int i = 0;
                    DateTime end = DateTime.Now.AddSeconds(sender.ReceiveTimeout);
                    bool terminatore = false;

                    //leggo fino a quando non trovo il terminatore
                    while (!terminatore && DateTime.Now < end)
                    {
                        // Receive the response from the remote device.
                        bytesRec = sender.Receive(bytesTemp, 0, 1, SocketFlags.None);
                        bytes[i] = bytesTemp[0];
                        i++;

                        if (i >= 2)
                        {
                            //verifico che la risposta termini con "10"
                            if (bytes[i - 2].Equals(10) && bytes[i - 1].Equals(13))
                            {
                                terminatore = true;
                            }
                        }
                    }
                    //se bytesRec = 0 vuol dire che il server non ha risposto niente, nessun carettere (probabilmente si è disconesso)
                    if (bytesRec == 0)
                    {
                        response = "NULL";
                        //chiamo evento per scrivere risposta textBox in form1
                        //if (RispostaServer != null) RispostaServer("Nessuna Risposta dal Server");
                    }
                    else
                    {
                        response = Encoding.ASCII.GetString(bytes, 0, i);
                        //if (RispostaServer != null) RispostaServer(Encoding.ASCII.GetString(bytes, 0, i));
                    }

                    // Release the socket.
                    sender.Shutdown(SocketShutdown.Both);
                    sender.Close();

                }
                catch (ArgumentNullException)
                {
                    throw;
                }
                catch (SocketException)
                {
                    throw;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return response;
        }

    }
}