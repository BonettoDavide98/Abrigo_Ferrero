using ClientEEIP.ClassiMie.Instance;
using ClientEEIP.ClassiMie.Other;
using System;
using System.Net;

namespace ClientEEIP.ClassiMie
{
    public class GestisciRichiesta
    {
        public static IPEndPoint epSlave { get; set; }
        public static IPEndPoint epMaster { get; set; }

        public byte[] Gestisci(byte[] richiesta)
        {
            byte[] send = null;
            try
            {
                Header headerArrived = new Header(richiesta);

                if (headerArrived.Status == 0)                          // Nessun errore, 2-4.5 Status field
                {
                    switch (headerArrived.Command)
                    {
                        case 0:
                            send = new byte[1];
                            break;
                        case 0x04:      // List Services
                            send = ListServicesReply(headerArrived);
                            break;

                        case 0x63:      // List Identity
                            send = ListIdentityReply(headerArrived);
                            break;

                        case 0x65:      // Register Session
                            send = RegisterSessionReply(headerArrived);
                            break;

                        case 0x66:
                            //Console.WriteLine("===== COMANDO DI UNREGISTERSESSION DA PARTE DEL MASTER ====="); // "Non c'è risposta a questa domanda." ~Manuale, 2-5.5UnRegisterSession 
                            send = new byte[1];
                            break;

                        case 0x6F:      // Send RR Data
                            send = SendRRDataReply(headerArrived);
                            break;
                        default:
                            throw new Exception("Richiesta non gestita : " + headerArrived.Command);
                    }
                }
            }
            catch (Exception ex)
            {
                ClientEEIP.ExceptionHandler.HandleException(ex);
            }
            if (send == null)
                send = new byte[1];
            return send;
        }

        byte[] ListServicesReply(Header arrived)            // Table 2-5.11 – ListServices reply
        {
            byte[] buffer = new byte[50];
            try
            {
                buffer[0] = 0x04;   // Comando 0x0004 di risposta
                buffer[1] = 0;
                buffer[2] = 26;     // Lunghezza fissa della risposta
                for (int i = 3; i < 24; i++)
                    buffer[i] = 0;
                buffer[24] = 1;     // Number of items to follow (1)
                buffer[25] = 0;
                buffer[26] = 0;     // Item type code (0x0100)    
                buffer[27] = 1;
                buffer[28] = 20;    // Item Length (0x0014)
                buffer[29] = 0;
                buffer[30] = 1;     // Version of encapsulated protocol shall be set to 1
                buffer[31] = 0;
                buffer[32] = 32;     // Capability Flags
                buffer[33] = 1;
                for (int i = 0; i < 14; i++)
                    buffer[i + 34] = Convert.ToByte("Communications"[i]);
                buffer[48] = 0;
                buffer[49] = 0;     // Scritta "Communications" e due bit a 0, non ho capito perchè
            }
            catch (Exception ex)
            {
                ClientEEIP.ExceptionHandler.HandleException(ex);
            }
            return buffer;
        }

        byte[] ListIdentityReply(Header arrived)            // Table 2-5.3 – ListIdentity reply
        {
            byte[] buffer = null;
            try
            {
                IdentityType identity = new IdentityType();
                byte[] CIPIdentityItem = identity.GetCIPIdentityItem(epSlave);
                buffer = new byte[26 + CIPIdentityItem.Length];

                buffer[0] = 0x63;      // Comando 0x0063 di risposta
                buffer[1] = 0;
                buffer[2] = (byte)(2 + CIPIdentityItem.Length);
                buffer[3] = (byte)((2 + CIPIdentityItem.Length) >> 8);
                for (int i = 4; i < 24; i++)
                    buffer[i] = 0;      // Session handle, Status, Sender Context, Options => Devono essere 0
                buffer[24] = 1;         // Number of target items to follow
                buffer[25] = 0;

                for (int i = 0; i < CIPIdentityItem.Length; i++)
                    buffer[26 + i] = CIPIdentityItem[i];
            }
            catch (Exception ex)
            {
                ClientEEIP.ExceptionHandler.HandleException(ex);
            }
            return buffer;
        }

        byte[] RegisterSessionReply(Header arrived)         // Table 2-5.8 – RegisterSession reply
        {
            byte[] buffer = null;
            try
            {
                /***** La reply ha uno schema pressocchè fisso, variano solo i bytes da 12 a 19 (inclusi) *****/
                buffer = new byte[28];

                buffer[0] = 0x65;   // Comando 0x0065 di risposta
                buffer[1] = 0;
                buffer[2] = 4;      // Lunghezza fissa della risposta
                buffer[3] = 0;

                buffer[4] = (byte)(new Random().Next(0xFFFFFFF) + 1);           // Session Handle
                buffer[5] = (byte)((new Random().Next(0xFFFFFFF) + 1) >> 8);
                buffer[6] = (byte)((new Random().Next(0xFFFFFFF) + 1) >> 16);
                buffer[7] = (byte)((new Random().Next(0xFFFFFFF) + 1) >> 24);

                buffer[8] = 0;      // Status, deve essere 0
                buffer[9] = 0;
                buffer[10] = 0;
                buffer[11] = 0;
                buffer[12] = arrived.SenderContext[0];      // Il sender context deve essere uguale a quello arrivato
                buffer[13] = arrived.SenderContext[1];
                buffer[14] = arrived.SenderContext[2];
                buffer[15] = arrived.SenderContext[3];
                buffer[16] = arrived.SenderContext[4];
                buffer[17] = arrived.SenderContext[5];
                buffer[18] = arrived.SenderContext[6];
                buffer[19] = arrived.SenderContext[7];
                buffer[20] = 0;     // Options, deve essere 0
                buffer[21] = 0;
                buffer[22] = 0;
                buffer[23] = 0;
                buffer[24] = 1;     // Protocol version, deve essere 1
                buffer[25] = 0;
                buffer[26] = 0;     // Options Flags, deve essere 0
                buffer[27] = 0;
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
            return buffer;
        }

        byte[] SendRRDataReply(Header arrived)              // Table 2-5.14 – SendRRData reply
        {
            byte[] ret = null;
            try
            {
                CommonPacketFormatType commonPacketFormat = new CommonPacketFormatType(arrived);       // Ottengo la lista dei CommonPacketFormat

                // Per ogni CommonPacketFormat gestisco la richiesta
                foreach (CommonPacketFormatType.AddressDataItemType addressDataItem in commonPacketFormat.ItemList)
                {
                    switch (addressDataItem.TypeID)
                    {
                        case 0:
                            // null item
                            break;

                        case 0xB2:
                            MessageRouterType messageRouter = new MessageRouterType(addressDataItem.Data);
                            ret = messageRouter.GetResponse(arrived);
                            break;

                        case 0x8001:
                            //Console.WriteLine("===== ARRIVA STO PACKET FORMAT MA NON SERVE =====");
                            break;

                        default:
                            throw new Exception("CommonPacketFormat non gestito : " + addressDataItem.TypeID.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }        
            return ret;
            //CommonPacketFormatType commonPacketFormat = new CommonPacketFormatType();       // Ottengo la lista dei CommonPacketFormat 
            //int prevDataLength = 0;
            //for (int i = 0; i < (arrived.EncapsulatedData[6] | (arrived.EncapsulatedData[7] << 8)); i++)
            //{
            //    ushort type = (ushort)(arrived.EncapsulatedData[8 + (i * 4) + prevDataLength] | (arrived.EncapsulatedData[9 + i * 4 + prevDataLength] << 8));     // Il primo item parte al byte 8, ogni item occupa 4 + Length bytes
            //    ushort length = (ushort)(arrived.EncapsulatedData[10 + (i * 4) + prevDataLength] | (arrived.EncapsulatedData[11 + i * 4 + prevDataLength] << 8));
            //    CommonPacketFormatType.AddressDataItemType tmp = new CommonPacketFormatType.AddressDataItemType(type, length);
            //    for (int j = 0; j < tmp.Length; j++)
            //        tmp.Data[j] = arrived.EncapsulatedData[12 + i * 4 + prevDataLength + j];
            //    prevDataLength += length;
            //    commonPacketFormat.ItemList.Add(tmp);
            //}
        }

        public void setMasterEp(IPEndPoint ep) { epMaster = ep; }
        public IPEndPoint getMasterEp() { return epMaster; }
        public void setSlaveEp(IPEndPoint ep) { epSlave = ep; }
        public IPEndPoint GetSlaveEp() { return epSlave; }
    }
}
