using ClientEEIP.ClassiMie.Other;
using ClientEEIP.ClassiMie.TcpUdp;
using System;
using System.Collections.Generic;
using System.Net;

namespace ClientEEIP.ClassiMie.Instance
{
    public class ConnectionManagerType
    {
        public AttributesType Attributes { get; set; }
        public SpecificServiceParametersType SpecificServiceParameters { get; set; }
        public UdpDataHandler udpDataReader { get; set; }


        public ConnectionManagerType()
        {
            Attributes = new AttributesType();
            SpecificServiceParameters = new SpecificServiceParametersType();
        }



        public byte[] GetAttributesAll()
        {
            byte[] ret = null;
            try
            {
                int connOpenBitsSize = (int)Math.Ceiling(Attributes.ConnectionEntryList.ConnOpenBits.Count / 8m);
                ret = new byte[28 + connOpenBitsSize];

                ret[0] = (byte)Attributes.OpenRequests;
                ret[1] = (byte)(Attributes.OpenRequests >> 8);
                ret[2] = (byte)Attributes.OpenFormatRejects;
                ret[3] = (byte)(Attributes.OpenFormatRejects >> 8);
                ret[4] = (byte)Attributes.OpenResourceRejects;
                ret[5] = (byte)(Attributes.OpenResourceRejects >> 8);
                ret[6] = (byte)Attributes.OpenOtherRejects;
                ret[7] = (byte)(Attributes.OpenOtherRejects >> 8);
                ret[8] = (byte)Attributes.CloseRequests;
                ret[9] = (byte)(Attributes.CloseRequests >> 8);
                ret[10] = (byte)Attributes.CloseFormatRequests;
                ret[11] = (byte)(Attributes.CloseFormatRequests >> 8);
                ret[12] = (byte)Attributes.CloseOtherRequests;
                ret[13] = (byte)(Attributes.CloseOtherRequests >> 8);
                ret[14] = (byte)Attributes.ConnectionTimeouts;
                ret[15] = (byte)(Attributes.ConnectionTimeouts >> 8);
                ret[16] = (byte)Attributes.ConnectionEntryList.NumConnEntries;
                ret[17] = (byte)(Attributes.ConnectionEntryList.NumConnEntries >> 8);
                for (int i = 0; i < connOpenBitsSize; i++)
                {
                    ret[18 + i] = 0;
                    for (int j = 0; j < 8; j++)
                        if (Attributes.ConnectionEntryList.ConnOpenBits[i * 8 + j])
                            ret[18 + i] |= (byte)(1 << j);
                }
                ret[18 + connOpenBitsSize] = (byte)Attributes.CpuUtilization;
                ret[19 + connOpenBitsSize] = (byte)(Attributes.CpuUtilization >> 8);
                ret[20 + connOpenBitsSize] = (byte)Attributes.MaxBuffSize;
                ret[21 + connOpenBitsSize] = (byte)(Attributes.MaxBuffSize >> 8);
                ret[22 + connOpenBitsSize] = (byte)(Attributes.MaxBuffSize >> 16);
                ret[23 + connOpenBitsSize] = (byte)(Attributes.MaxBuffSize >> 24);
                ret[24 + connOpenBitsSize] = (byte)Attributes.BufSizeRemaining;
                ret[25 + connOpenBitsSize] = (byte)(Attributes.BufSizeRemaining >> 8);
                ret[26 + connOpenBitsSize] = (byte)(Attributes.BufSizeRemaining >> 16);
                ret[27 + connOpenBitsSize] = (byte)(Attributes.BufSizeRemaining >> 24);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
            return ret;
        }

        public byte[] Forward_Open(Header arrived)
        {
            CommonPacketFormatType commonPacketFormat = new CommonPacketFormatType();
            try
            {
                SpecificServiceParameters.O_to_T_NetworkConnectionID = 0;
                SpecificServiceParameters.T_to_O_NetworkConnectionID = 0;
                SpecificServiceParameters.ConnectionSerialNumber = 0;
                SpecificServiceParameters.OriginatorVendorID = 0;

                // Un po' di parametri che ricevo
                byte RequestedPathSize = arrived.EncapsulatedData[17];
                int offset = 2 * RequestedPathSize + 1;

                // BENE BENE BENE CI SONO GIUSTAMENTE ANCHE I PARAMETRI DI ROUTING AKA n BYTES PRIMA DEL 17esimo DEL PRIORITY TIMETICK
                SpecificServiceParameters.Priority_TimeTick = arrived.EncapsulatedData[17 + offset];     // Priority/Time_tick
                SpecificServiceParameters.TimeOutTicks = arrived.EncapsulatedData[18 + offset];      // Timeout ticks
                SpecificServiceParameters.O_to_T_NetworkConnectionID |= arrived.EncapsulatedData[19 + offset];       // O_to_T Network Connection ID
                SpecificServiceParameters.O_to_T_NetworkConnectionID |= (uint)(arrived.EncapsulatedData[20 + offset] << 8);
                SpecificServiceParameters.O_to_T_NetworkConnectionID |= (uint)(arrived.EncapsulatedData[21 + offset] << 16);
                SpecificServiceParameters.O_to_T_NetworkConnectionID |= (uint)(arrived.EncapsulatedData[22 + offset] << 24);
                SpecificServiceParameters.T_to_O_NetworkConnectionID |= arrived.EncapsulatedData[23 + offset];       // T_to_O Network Connection ID
                SpecificServiceParameters.T_to_O_NetworkConnectionID |= (uint)(arrived.EncapsulatedData[24 + offset] << 8);
                SpecificServiceParameters.T_to_O_NetworkConnectionID |= (uint)(arrived.EncapsulatedData[25 + offset] << 16);
                SpecificServiceParameters.T_to_O_NetworkConnectionID |= (uint)(arrived.EncapsulatedData[26 + offset] << 24);
                SpecificServiceParameters.ConnectionSerialNumber |= arrived.EncapsulatedData[27 + offset];       // Connection Serial Number
                SpecificServiceParameters.ConnectionSerialNumber |= (ushort)(arrived.EncapsulatedData[28 + offset] << 8);
                SpecificServiceParameters.OriginatorVendorID |= arrived.EncapsulatedData[29 + offset];       // Originator Vendor ID
                SpecificServiceParameters.OriginatorVendorID |= (ushort)(arrived.EncapsulatedData[30 + offset] << 8);
                SpecificServiceParameters.OriginatorSerialNumber |= arrived.EncapsulatedData[31 + offset];      // Originator Serial Number
                SpecificServiceParameters.OriginatorSerialNumber |= (ushort)(arrived.EncapsulatedData[32 + offset] << 8);
                SpecificServiceParameters.OriginatorSerialNumber |= (ushort)(arrived.EncapsulatedData[33 + offset] << 16);
                SpecificServiceParameters.OriginatorSerialNumber |= (ushort)(arrived.EncapsulatedData[34 + offset] << 24);
                SpecificServiceParameters.ConnectionTimeoutMultiplier = arrived.EncapsulatedData[35 + offset];       // Connection Timeout Multiplier
                                                                                                                     // 3 bytes RESERVED
                SpecificServiceParameters.O_to_T_RPI |= arrived.EncapsulatedData[39 + offset];       // T_to_O RPI
                SpecificServiceParameters.O_to_T_RPI |= (uint)(arrived.EncapsulatedData[40 + offset] << 8);
                SpecificServiceParameters.O_to_T_RPI |= (uint)(arrived.EncapsulatedData[41 + offset] << 16);
                SpecificServiceParameters.O_to_T_RPI |= (uint)(arrived.EncapsulatedData[42 + offset] << 24);
                SpecificServiceParameters.O_to_T_ConnectionParameters = new SpecificServiceParametersType.NetworkConnectionParametersType((ushort)(arrived.EncapsulatedData[43 + offset] | arrived.EncapsulatedData[44 + offset] << 8));
                SpecificServiceParameters.T_to_O_RPI |= arrived.EncapsulatedData[45 + offset];       // T_to_O RPI
                SpecificServiceParameters.T_to_O_RPI |= (uint)(arrived.EncapsulatedData[46 + offset] << 8);
                SpecificServiceParameters.T_to_O_RPI |= (uint)(arrived.EncapsulatedData[47 + offset] << 16);
                SpecificServiceParameters.T_to_O_RPI |= (uint)(arrived.EncapsulatedData[48 + offset] << 24);
                SpecificServiceParameters.T_to_O_ConnectionParameters = new SpecificServiceParametersType.NetworkConnectionParametersType((ushort)(arrived.EncapsulatedData[49 + offset] | arrived.EncapsulatedData[50 + offset] << 8));
                SpecificServiceParameters.TransportType_Trigger = arrived.EncapsulatedData[51 + offset];
                SpecificServiceParameters.ConnectionPathSize = arrived.EncapsulatedData[52 + offset];
                List<ushort> pathTmp = new List<ushort>();
                for (int i = 0; i < SpecificServiceParameters.ConnectionPathSize; i++)
                    pathTmp.Add((ushort)(arrived.EncapsulatedData[53 + offset + i * 2] | arrived.EncapsulatedData[54 + offset + i * 2]));
                SpecificServiceParameters.ConnectionPath = new EPathType(pathTmp);

                //if (SpecificServiceParameters.O_to_T_NetworkConnectionID != 0 || SpecificServiceParameters.T_to_O_NetworkConnectionID != 0)
                //    Console.WriteLine("Finalmente");

                //Console.WriteLine("T--->O conn ID: " + SpecificServiceParameters.T_to_O_NetworkConnectionID.ToString("X2"));

                // Vol1 Table 3-5.5.2 Table 3-5.10. Successful Forward Open Response
                byte[] ForwardOpenResponse = new byte[30];      // Yeah, un altro pacchetto di lunghezza fissa
                ForwardOpenResponse[0] = 0xD4;
                ForwardOpenResponse[1] = 0;
                ForwardOpenResponse[2] = 0;
                ForwardOpenResponse[3] = 0;
                ForwardOpenResponse[4] = (byte)SpecificServiceParameters.O_to_T_NetworkConnectionID;
                ForwardOpenResponse[5] = (byte)(SpecificServiceParameters.O_to_T_NetworkConnectionID >> 8);
                ForwardOpenResponse[6] = (byte)(SpecificServiceParameters.O_to_T_NetworkConnectionID >> 16);
                ForwardOpenResponse[7] = (byte)(SpecificServiceParameters.O_to_T_NetworkConnectionID >> 24);
                ForwardOpenResponse[8] = (byte)SpecificServiceParameters.T_to_O_NetworkConnectionID;
                ForwardOpenResponse[9] = (byte)(SpecificServiceParameters.T_to_O_NetworkConnectionID >> 8);
                ForwardOpenResponse[10] = (byte)(SpecificServiceParameters.T_to_O_NetworkConnectionID >> 16);
                ForwardOpenResponse[11] = (byte)(SpecificServiceParameters.T_to_O_NetworkConnectionID >> 24);
                ForwardOpenResponse[12] = (byte)SpecificServiceParameters.ConnectionSerialNumber;
                ForwardOpenResponse[13] = (byte)(SpecificServiceParameters.ConnectionSerialNumber >> 8);
                ForwardOpenResponse[14] = (byte)SpecificServiceParameters.OriginatorVendorID;
                ForwardOpenResponse[15] = (byte)(SpecificServiceParameters.OriginatorVendorID >> 8);
                ForwardOpenResponse[16] = (byte)SpecificServiceParameters.OriginatorSerialNumber;
                ForwardOpenResponse[17] = (byte)(SpecificServiceParameters.OriginatorSerialNumber >> 8);
                ForwardOpenResponse[18] = (byte)(SpecificServiceParameters.OriginatorSerialNumber >> 16);
                ForwardOpenResponse[19] = (byte)(SpecificServiceParameters.OriginatorSerialNumber >> 24);
                ForwardOpenResponse[20] = (byte)SpecificServiceParameters.T_to_O_RPI;
                ForwardOpenResponse[21] = (byte)(SpecificServiceParameters.T_to_O_RPI >> 8);
                ForwardOpenResponse[22] = (byte)(SpecificServiceParameters.T_to_O_RPI >> 16);
                ForwardOpenResponse[23] = (byte)(SpecificServiceParameters.T_to_O_RPI >> 24);
                ForwardOpenResponse[24] = (byte)SpecificServiceParameters.O_to_T_RPI;
                ForwardOpenResponse[25] = (byte)(SpecificServiceParameters.O_to_T_RPI >> 8);
                ForwardOpenResponse[26] = (byte)(SpecificServiceParameters.O_to_T_RPI >> 16);
                ForwardOpenResponse[27] = (byte)(SpecificServiceParameters.O_to_T_RPI >> 24);
                ForwardOpenResponse[28] = 0;        // Appication reply size
                ForwardOpenResponse[29] = 0;        // Reserved


                CommonPacketFormatType.SockaddrItemType sockaddrItemType0 = new CommonPacketFormatType.SockaddrItemType(0x8000, 2, 2222, GestisciRichiesta.epSlave.Address);
                CommonPacketFormatType.SockaddrItemType sockaddrItemType1 = new CommonPacketFormatType.SockaddrItemType(0x8001, 2, 2222, GestisciRichiesta.epMaster.Address);


                commonPacketFormat.ItemList.Add(new CommonPacketFormatType.AddressDataItemType(0, 0));  // NULL ADDRESS
                commonPacketFormat.ItemList.Add(new CommonPacketFormatType.AddressDataItemType(0xB2, ForwardOpenResponse));
                commonPacketFormat.ItemList.Add(sockaddrItemType0.toAddressDataItemType());
                commonPacketFormat.ItemList.Add(sockaddrItemType1.toAddressDataItemType());

                udpDataReader = new UdpDataHandler(sockaddrItemType0, sockaddrItemType1);
                udpDataReader.beginHandle(SpecificServiceParameters.T_to_O_RPI, SpecificServiceParameters.T_to_O_NetworkConnectionID);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
            return commonPacketFormat.toBytes();
        }

        public byte[] Forward_Close(Header arrived)
        {
            CommonPacketFormatType commonPacketFormat = new CommonPacketFormatType();
            try
            {
                byte[] ret = new byte[14];

                byte RequestedPathSize = arrived.EncapsulatedData[17];
                int offset = 2 * RequestedPathSize + 1;

                // BENE BENE BENE CI SONO GIUSTAMENTE ANCHE I PARAMETRI DI ROUTING AKA n BYTES PRIMA DEL 17esimo DEL PRIORITY TIMETICK
                SpecificServiceParameters.Priority_TimeTick = arrived.EncapsulatedData[17 + offset];     // Priority/Time_tick
                SpecificServiceParameters.TimeOutTicks = arrived.EncapsulatedData[18 + offset];      // Timeout ticks

                SpecificServiceParameters.ConnectionSerialNumber |= arrived.EncapsulatedData[19 + offset];       // Connection Serial Number
                SpecificServiceParameters.ConnectionSerialNumber |= (ushort)(arrived.EncapsulatedData[20 + offset] << 8);
                SpecificServiceParameters.OriginatorVendorID |= arrived.EncapsulatedData[21 + offset];       // Originator Vendor ID
                SpecificServiceParameters.OriginatorVendorID |= (ushort)(arrived.EncapsulatedData[22 + offset] << 8);
                SpecificServiceParameters.OriginatorSerialNumber |= arrived.EncapsulatedData[23 + offset];      // Originator Serial Number
                SpecificServiceParameters.OriginatorSerialNumber |= (ushort)(arrived.EncapsulatedData[24 + offset] << 8);
                SpecificServiceParameters.OriginatorSerialNumber |= (ushort)(arrived.EncapsulatedData[25 + offset] << 16);
                SpecificServiceParameters.OriginatorSerialNumber |= (ushort)(arrived.EncapsulatedData[26 + offset] << 24);
                SpecificServiceParameters.ConnectionPathSize = arrived.EncapsulatedData[27 + offset];
                // Reserved
                List<ushort> pathTmp = new List<ushort>();
                for (int i = 0; i < SpecificServiceParameters.ConnectionPathSize; i++)
                    pathTmp.Add((ushort)(arrived.EncapsulatedData[29 + offset + i * 2] | arrived.EncapsulatedData[30 + offset + i * 2]));
                SpecificServiceParameters.ConnectionPath = new EPathType(pathTmp);

                ret[0] = 0xDE;
                ret[1] = 0;
                ret[2] = 0;
                ret[3] = 0;
                ret[4] = (byte)SpecificServiceParameters.ConnectionSerialNumber;
                ret[5] = (byte)(SpecificServiceParameters.ConnectionSerialNumber >> 8);
                ret[6] = (byte)SpecificServiceParameters.OriginatorVendorID;
                ret[7] = (byte)(SpecificServiceParameters.OriginatorVendorID >> 16);
                ret[8] = (byte)SpecificServiceParameters.OriginatorSerialNumber;
                ret[9] = (byte)(SpecificServiceParameters.OriginatorSerialNumber >> 8);
                ret[10] = (byte)(SpecificServiceParameters.OriginatorSerialNumber >> 16);
                ret[11] = (byte)(SpecificServiceParameters.OriginatorSerialNumber >> 24);
                ret[12] = 0;        // Remaining Path Size
                ret[13] = 0;        // Reserved



                commonPacketFormat.ItemList.Add(new CommonPacketFormatType.AddressDataItemType(0, 0));
                commonPacketFormat.ItemList.Add(new CommonPacketFormatType.AddressDataItemType(0xB2, ret));
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
            return commonPacketFormat.toBytes();
        }



        public class AttributesType
        {
            // Vol1 Table 3-5.3.
            public ushort OpenRequests { get; set; }
            public ushort OpenFormatRejects { get; set; }
            public ushort OpenResourceRejects { get; set; }
            public ushort OpenOtherRejects { get; set; }
            public ushort CloseRequests { get; set; }
            public ushort CloseFormatRequests { get; set; }
            public ushort CloseOtherRequests { get; set; }
            public ushort ConnectionTimeouts { get; set; }
            public ConnectionEntryListType ConnectionEntryList { get; set; }
            // Reserved/Obsolete
            public ushort CpuUtilization { get; set; }
            public uint MaxBuffSize { get; set; }
            public uint BufSizeRemaining { get; set; }



            public AttributesType()
            {
                ConnectionEntryList = new ConnectionEntryListType();
            }



            public class ConnectionEntryListType
            {
                public ushort NumConnEntries { get; set; }
                public List<bool> ConnOpenBits { get; set; }



                public ConnectionEntryListType()
                {
                    ConnOpenBits = new List<bool>();
                }
            }
        }

        public class SpecificServiceParametersType
        {
            public byte Priority_TimeTick { get; set; }
            public byte TimeOutTicks { get; set; }
            public uint O_to_T_NetworkConnectionID { get; set; }
            public uint T_to_O_NetworkConnectionID { get; set; }
            public ushort ConnectionSerialNumber { get; set; }
            public ushort OriginatorVendorID { get; set; }
            public uint OriginatorSerialNumber { get; set; }
            public byte ConnectionTimeoutMultiplier { get; set; }
            public uint O_to_T_RPI { get; set; }
            public NetworkConnectionParametersType O_to_T_ConnectionParameters { get; set; }
            public uint T_to_O_RPI { get; set; }
            public NetworkConnectionParametersType T_to_O_ConnectionParameters { get; set; }
            public byte TransportType_Trigger { get; set; }
            public byte ConnectionPathSize { get; set; }
            public EPathType ConnectionPath { get; set; }



            public SpecificServiceParametersType()
            {
                O_to_T_ConnectionParameters = new NetworkConnectionParametersType(true);
                T_to_O_ConnectionParameters = new NetworkConnectionParametersType(true);
                ConnectionPath = new EPathType();
            }



            public class NetworkConnectionParametersType
            {
                //Vol1 3-5.5.1.1 Network Connection Parameters
                public ushort ConnectionSize { get; set; }
                public bool Variable { get; set; }
                public NetworkConnectionParametersPriority Priority { get; set; }
                public NetworkConnectionParametersConnectionType ConnectionType { get; set; }
                public bool RedundantOwner { get; set; }



                public NetworkConnectionParametersType(bool configured = false)
                {
                    if (configured)
                    {
                        ConnectionSize = 255;
                        Variable = true;
                        Priority = NetworkConnectionParametersPriority.LowPriority;
                        ConnectionType = NetworkConnectionParametersConnectionType.PointToPoint;
                        RedundantOwner = true;
                    }
                }

                public NetworkConnectionParametersType(ushort parameters)
                {
                    ConnectionSize = (ushort)(parameters & 0x1F);
                    Variable = ((parameters >> 9) & 1) == 1 ? true : false;

                    // È stata la cosa migliore che mi sia venuta in mente per guardare un dato di 2 bit, perdoname por mi vida loca
                    if (((parameters >> 11) & 1) == 0 && ((parameters >> 10) & 1) == 0)
                        Priority = NetworkConnectionParametersPriority.LowPriority;
                    else if (((parameters >> 11) & 1) == 0 && ((parameters >> 10) & 1) == 1)
                        Priority = NetworkConnectionParametersPriority.HighPriority;
                    else if (((parameters >> 11) & 1) == 1 && ((parameters >> 10) & 1) == 0)
                        Priority = NetworkConnectionParametersPriority.Scheduled;
                    else
                        Priority = NetworkConnectionParametersPriority.Urgent;

                    if (((parameters >> 14) & 1) == 0 && ((parameters >> 13) & 1) == 0)
                        ConnectionType = NetworkConnectionParametersConnectionType.Null;
                    else if (((parameters >> 14) & 1) == 0 && ((parameters >> 13) & 1) == 1)
                        ConnectionType = NetworkConnectionParametersConnectionType.Multicast;
                    else if (((parameters >> 14) & 1) == 1 && ((parameters >> 13) & 1) == 0)
                        ConnectionType = NetworkConnectionParametersConnectionType.PointToPoint;
                    else
                        ConnectionType = NetworkConnectionParametersConnectionType.Reserved;

                    RedundantOwner = ((parameters >> 15) & 1) == 1 ? true : false;
                }



                public enum NetworkConnectionParametersPriority
                {
                    LowPriority = 0b00,
                    HighPriority = 0b01,
                    Scheduled = 0b10,
                    Urgent = 0b11
                }

                public enum NetworkConnectionParametersConnectionType
                {
                    Null = 0b00,
                    Multicast = 0b01,
                    PointToPoint = 0b10,
                    Reserved = 0b11
                }
            }
        }
    }
}
