using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

namespace QVLEGSCOG2362.Class
{
    public class Fins
    {

        //READ
        //800003000100007B0006
        //0101820001000001

        //WRITE
        //800003000100007B0001
        //0102820001000002AAAABBBB
        public string leggi1 = "80-00-03-00-01-00-00-7B-00-06";
        public string MemoryAreaRead1 = "1";
        public string MemoryAreaRead2 = "1";
        public string MemoryAreaCode = "82";
        public string BeginningAddress1 = "0";
        public string BeginningAddress2 = "1";
        public string BeginningAddressBit = "0";
        public string Nvariabili = "0";
        public string CVar = "0";
        public string scrivi1 = "80-00-03-00-01-00-00-7B-00-01";
        public string MemoryAreaWrite = "2";
        public string riempi = "";

        //READ 
        IPEndPoint ep = null;
        UdpClient client = null;

        public enum InvioPLC : int
        {
            read = 1,
            write = 2
        }

        public Fins(string ip, int porta)
        {
            Connect(ip, porta);
        }

        public bool Connect(string ip, int porta)
        {
            bool ret = false;

            try
            {
                //if (TestConnection(ip))
                //{
                client = new UdpClient();
                ep = new IPEndPoint(IPAddress.Parse(ip), porta);
                client.Connect(ep);

                client.Client.SendTimeout = 1000;
                client.Client.ReceiveTimeout = 1000;

                ret = client.Client.Connected;
                //}
                //else
                //    ret = false;
            }
            catch (Exception ex)
            {
                throw;
            }

            return ret;
        }

        public void Disconnect()
        {
            try
            {
                if (client != null)
                    client.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private int ConvertiToWord(byte b1, byte b2)
        {
            try
            {
                //B1 byte più significativo
                int word = (int)b1 * 16 * 16;
                return word + b2;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public bool IsConnected()
        {
            return client.Client.Connected;
        }

        private List<byte> ComponiInvioPLC(InvioPLC richiesta, List<int> lista, int valoriDaLeggere, short IndirizzoVarPLC, string memoryAreaCode, bool dword)
        {
            List<byte> ret = new List<byte>();

            try
            {
                if (richiesta == InvioPLC.read)
                {
                    int val1 = 0;
                    string[] finale1 = leggi1.Split('-');
                    for (int i = 0; i < finale1.Length; i++)
                    {
                        val1 = Convert.ToInt32(finale1[i], 16);
                        ret.Add(Convert.ToByte(val1));
                    }

                    //string memoryy = memoryAreaCode.ToString("X");
                    int Memory = Convert.ToInt32(memoryAreaCode, 16);
                    ret.Add(Convert.ToByte(MemoryAreaRead1));

                    if (richiesta == InvioPLC.write)
                        ret.Add(Convert.ToByte(MemoryAreaWrite));
                    else if (richiesta == InvioPLC.read)
                        ret.Add(Convert.ToByte(MemoryAreaRead2));

                    ret.Add(Convert.ToByte(Memory));
                    byte[] indirizzo = GestioneWord.ConvertValoreToByteArray(IndirizzoVarPLC);
                    ret.Add(indirizzo[1]);
                    ret.Add(indirizzo[0]);
                    ret.Add(Convert.ToByte(BeginningAddressBit));

                    //ATTENZIONE NVariabili è il byte più significativo dei valori da leggere ORA  è SCHIANTATO a 0 (max255 valori assieme)

                    ret.Add(Convert.ToByte(Nvariabili));
                    ret.Add(Convert.ToByte(valoriDaLeggere));
                }
                else if (richiesta == InvioPLC.write)
                {
                    int val1 = 0;
                    string[] finale1 = leggi1.Split('-');
                    for (int i = 0; i < finale1.Length; i++)
                    {
                        val1 = Convert.ToInt32(finale1[i], 16);
                        ret.Add(Convert.ToByte(val1));
                    }
                    int Memory = Convert.ToInt32(memoryAreaCode.ToString(), 16);
                    ret.Add(Convert.ToByte(MemoryAreaRead1));

                    if (richiesta == InvioPLC.write)
                        ret.Add(Convert.ToByte(MemoryAreaWrite));
                    else if (richiesta == InvioPLC.read)
                        ret.Add(Convert.ToByte(MemoryAreaRead2));

                    ret.Add(Convert.ToByte(Memory));
                    byte[] indirizzo = GestioneWord.ConvertValoreToByteArray(IndirizzoVarPLC);
                    ret.Add(indirizzo[1]);
                    ret.Add(indirizzo[0]);
                    ret.Add(Convert.ToByte(BeginningAddressBit));

                    //ATTENZIONE NVariabili è il byte più significativo dei valori da leggere ORA  è SCHIANTATO a 0 (max255 valori assieme)
                    ret.Add(Convert.ToByte(Nvariabili));

                    if (dword == true)
                    {
                        ret.Add(Convert.ToByte(valoriDaLeggere * 2));
                        for (int i = 0; i < lista.Count; i++)
                        {
                            //SCRIVE IN DWORD
                            byte[] ValoridaScrivere = GestioneWord.ConvertValoreToByteArray(lista[i]);
                            Array.Reverse(ValoridaScrivere);
                            ret.Add(Convert.ToByte(ValoridaScrivere[2]));
                            ret.Add(Convert.ToByte(ValoridaScrivere[3]));
                            ret.Add(Convert.ToByte(ValoridaScrivere[0]));
                            ret.Add(Convert.ToByte(ValoridaScrivere[1]));
                        }
                    }
                    else
                    {
                        ret.Add(Convert.ToByte(valoriDaLeggere));
                        for (int i = 0; i < lista.Count; i++)
                        {
                            //SCRIVE IN WORD
                            byte[] ValoridaScrivere = GestioneWord.ConvertValoreToByteArray(lista[i]);
                            Array.Reverse(ValoridaScrivere);
                            ret.Add(Convert.ToByte(ValoridaScrivere[2]));
                            ret.Add(Convert.ToByte(ValoridaScrivere[3]));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ret;
        }

        public T Read<T>(int valoriDaLeggere, short indirizzoVariabilePLC, int memoryAreaCode, bool dword)
        {
            try
            {
                dynamic ret = default(T);
                List<int> listaInvio = new List<int>();

                List<byte> stringa = ComponiInvioPLC(InvioPLC.read, listaInvio, valoriDaLeggere * (dword ? 2 : 1), indirizzoVariabilePLC, memoryAreaCode.ToString(), dword);
                client.Send(stringa.ToArray(), stringa.Count);
                byte[] arrayRecive = client.Receive(ref ep);
                //posizione da leggere dalla 14 in avanti in base al numero di variabili\\
                //Index da cui si deve partire a leggere i valori
                int index = 14;
                ret = GestioneWord.ConvertByteArrToValore<T>(arrayRecive, ref index, valoriDaLeggere);

                //Codice.Clear();
                return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Write(List<int> lista, int valoriDaScrivere, short IndirizzoVarPLC, int memoryAreaCode, bool dword)
        {
            try
            {
                List<byte> stringa = ComponiInvioPLC(InvioPLC.write, lista, valoriDaScrivere, IndirizzoVarPLC, memoryAreaCode.ToString(), dword);
                client.Send(stringa.ToArray(), stringa.Count);
                //Volendo si può controllare che la write è andata a buon fine posizione 12 e 13 = 00 00
                byte[] array = client.Receive(ref ep);

                //Codice.Clear();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}