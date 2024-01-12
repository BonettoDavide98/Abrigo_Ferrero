using ClientEEIP.ClassiMie.Instance;
using System;

namespace ClientEEIP.ClassiMie.Other
{
    public class MessageRouterType
    {
        public byte Service { get; set; }
        public byte Path_Size { get; set; }
        public EPathType Path { get; set; }
        public byte[] RequestData { get; set; }
        ConnectionManagerType connectionManager { get; set; }


        public MessageRouterType(byte[] data)
        {
            try
            {
                Service = data[0];
                Path_Size = data[1];
                RequestData = new byte[data.Length - 2 - (Path_Size * 2)];

                ushort[] PathData = new ushort[Path_Size];

                for (int i = 0; i < Path_Size; i++)
                    PathData[i] = (ushort)(data[2 + i * 2] | data[3 + i * 2]);

                Path = new EPathType(PathData);
                for (int i = 0; i < RequestData.Length; i++)
                    RequestData[i] = data[(Path_Size * 2) + 2 + i];

                connectionManager = new ConnectionManagerType();
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
        }



        public byte[] GetResponse(Header arrived)
        {
            byte[] ret = null;
            try
            {
                byte[] reply = null;
                switch (arrived.EncapsulatedData[16])
                {
                    case 0x01:
                        reply = RRDataReplyGetAttributeAll(arrived);
                        break;

                    case 0x0E:
                        reply = RRDataReplyGetAttributeSingle(arrived);
                        break;

                    case 0x4e:
                        reply = connectionManager.Forward_Close(arrived);
                        break;

                    case 0x54:
                        reply = connectionManager.Forward_Open(arrived);
                        break;

                    default:
                        throw new Exception("Service non gestito : " + arrived.EncapsulatedData[16]);
                }

                byte[] packet = new byte[6 + reply.Length];
                packet[0] = 0;        // Interface handle, shall be 0 for CIP
                packet[1] = 0;
                packet[2] = 0;
                packet[3] = 0;
                packet[4] = 0;        // Timeout, not used for reply
                packet[5] = 0;
                reply.CopyTo(packet, 6);

                ret = new byte[24 + packet.Length];
                ret[0] = 0x6F;      // Commmand, SendRRData (0x006F)
                ret[1] = 0;
                ret[2] = (byte)packet.Length;        // Length of command specific data portion
                ret[3] = (byte)(packet.Length >> 8);
                ret[4] = (byte)(arrived.SessionHandle);     // Handle returned by RegisterSession
                ret[5] = (byte)(arrived.SessionHandle >> 8);
                ret[6] = (byte)(arrived.SessionHandle >> 16);
                ret[7] = (byte)(arrived.SessionHandle >> 24);
                ret[8] = 0;     // Status, 0
                ret[9] = 0;
                ret[10] = 0;
                ret[11] = 0;
                ret[12] = arrived.SenderContext[0];     // Sender Context, copied from the corresponding UCMM request
                ret[13] = arrived.SenderContext[1];
                ret[14] = arrived.SenderContext[2];
                ret[15] = arrived.SenderContext[3];
                ret[16] = arrived.SenderContext[4];
                ret[17] = arrived.SenderContext[5];
                ret[18] = arrived.SenderContext[6];
                ret[19] = arrived.SenderContext[7];
                ret[20] = 0;        // 0
                ret[21] = 0;
                ret[22] = 0;
                ret[23] = 0;

                packet.CopyTo(ret, 24);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
            return ret;
        }

        public byte[] RRDataReplyGetAttributeSingle(Header header)
        {
            CommonPacketFormatType commonPacketFormat = new CommonPacketFormatType();
            try
            {
                byte[] attributes = new IdentityType().GetAttributeSingle(header.EncapsulatedData[23]);

                byte[] packet = new byte[4 + attributes.Length];
                packet[0] = 0x8E;
                packet[1] = 0;
                packet[2] = 0;
                packet[3] = 0;
                attributes.CopyTo(packet, 4);

                commonPacketFormat.ItemList.Add(new CommonPacketFormatType.AddressDataItemType(0, 0));
                commonPacketFormat.ItemList.Add(new CommonPacketFormatType.AddressDataItemType(0xB2, packet));
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
            return commonPacketFormat.toBytes();
        }

        public byte[] RRDataReplyGetAttributeAll(Header header)
        {
            CommonPacketFormatType commonPacketFormat = new CommonPacketFormatType();
            try
            {
                IdentityType identity = new IdentityType();
                byte[] attributes = identity.GetAttributesAll(0);

                byte[] packet = new byte[4 + attributes.Length];
                packet[0] = 0x81;
                packet[1] = 0;
                packet[2] = 0;
                packet[3] = 0;
                attributes.CopyTo(packet, 4);
                commonPacketFormat.ItemList.Add(new CommonPacketFormatType.AddressDataItemType(0, 0));
                commonPacketFormat.ItemList.Add(new CommonPacketFormatType.AddressDataItemType(0xB2, packet));
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
            return commonPacketFormat.toBytes();
        }
    }
}
