using System;
using System.Collections.Generic;
using System.Net;

namespace ClientEEIP.ClassiMie
{
    public class CommonPacketFormatType
    {
        public List<AddressDataItemType> ItemList { get; set; }



        public CommonPacketFormatType()
        {
            ItemList = new List<AddressDataItemType>();
        }

        public CommonPacketFormatType(Header arrived)
        {
            try
            {
                ItemList = new List<AddressDataItemType>();
                int prevDataLength = 0;
                for (int i = 0; i < (arrived.EncapsulatedData[6] | (arrived.EncapsulatedData[7] << 8)); i++)
                {
                    ushort type = (ushort)(arrived.EncapsulatedData[8 + (i * 4) + prevDataLength] | (arrived.EncapsulatedData[9 + i * 4 + prevDataLength] << 8));     // Il primo item parte al byte 8, ogni item occupa 4 + Length bytes
                    ushort length = (ushort)(arrived.EncapsulatedData[10 + (i * 4) + prevDataLength] | (arrived.EncapsulatedData[11 + i * 4 + prevDataLength] << 8));
                    AddressDataItemType tmp = new AddressDataItemType(type, length);
                    for (int j = 0; j < tmp.Length; j++)
                        tmp.Data[j] = arrived.EncapsulatedData[12 + i * 4 + prevDataLength + j];
                    prevDataLength += length;
                    ItemList.Add(tmp);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
        }



        public byte[] toBytes()
        {
            byte[] ret = null;
            try
            {
                int dimensioneTotale = 0;
                foreach (AddressDataItemType addressDataItem in ItemList)
                    dimensioneTotale += addressDataItem.Length + 4;

                ret = new byte[dimensioneTotale + 2];
                int lunghezzaAttuale = 0;

                foreach (AddressDataItemType addressDataItemType in ItemList)
                {
                    byte[] packet = addressDataItemType.toBytes();
                    packet.CopyTo(ret, 2 + lunghezzaAttuale);
                    lunghezzaAttuale += packet.Length;
                }

                ret[0] = (byte)ItemList.Count;
                ret[1] = (byte)(ItemList.Count >> 8);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
            return ret;
        }



        public class AddressDataItemType
        {
            public ushort TypeID { get; set; }
            public ushort Length { get; set; }
            public byte[] Data { get; set; }



            public AddressDataItemType() { }

            public AddressDataItemType(ushort length)
            {
                Length = length;
                Data = new byte[Length];
            }

            public AddressDataItemType(ushort typeID, byte[] data)
            {
                TypeID = typeID;
                Data = data;
                Length = (ushort)Data.Length;
            }

            public AddressDataItemType(ushort typeID, ushort length)
            {
                TypeID = typeID;
                Length = length;
                Data = new byte[length];
            }



            public byte[] toBytes()
            {
                byte[] ret = null;
                try
                {
                    ret = new byte[4 + Length];

                    ret[0] = (byte)TypeID;
                    ret[1] = (byte)(TypeID >> 8);
                    ret[2] = (byte)Length;
                    ret[3] = (byte)(Length >> 8);
                    for (int i = 0; i < Data.Length; i++)
                        ret[i + 4] = Data[i];
                }
                catch (Exception ex)
                {
                    ExceptionHandler.HandleException(ex);
                }
                return ret;
            }
        }

        public class SockaddrItemType
        {
            public ushort TypeID { get; set; }
            public ushort Length { get; set; }
            public short Sin_Family { get; set; }
            public ushort Sin_Port { get; set; }
            public IPAddress Sin_Addr { get; set; }



            public SockaddrItemType() { }

            public SockaddrItemType(ushort Type, short Family, ushort Port, IPAddress Addr)
            {
                TypeID = Type;
                Length = 16;
                Sin_Family = Family;
                Sin_Port = Port;
                Sin_Addr = Addr;
            }



            public AddressDataItemType toAddressDataItemType()
            {
                byte[] data = null;
                try
                {
                    data = new byte[16];
                    data[0] = (byte)(Sin_Family >> 8);
                    data[1] = (byte)Sin_Family;
                    data[2] = (byte)(Sin_Port >> 8);
                    data[3] = (byte)Sin_Port;

                    data[4] = Sin_Addr.GetAddressBytes()[0];
                    data[5] = Sin_Addr.GetAddressBytes()[1];
                    data[6] = Sin_Addr.GetAddressBytes()[2];
                    data[7] = Sin_Addr.GetAddressBytes()[3];

                    for (int i = 0; i < 8; i++)
                        data[8 + i] = 0;
                }
                catch (Exception ex)
                {
                    ExceptionHandler.HandleException(ex);
                }
                return new AddressDataItemType(TypeID, data);
            }
        }
    }
}
