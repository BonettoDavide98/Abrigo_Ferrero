using System;

namespace ClientEEIP.ClassiMie.Instance
{
    public class IdentityType
    {
        //Manuale: 5-2.3.2.
        public ushort Vendor;
        public ushort DeviceType;
        public ushort ProductCode;
        public byte MajorRevision;
        public byte MinorRevision;
        public IdentityStatus Status;
        public uint SerialNumber;
        public string ProductName;
        public byte State;
        public byte ConfigurationConsistencyValue;
        public byte HeartbeatInterval;

        public IdentityType()                                   // INSTANCE ATTRIBUTES 5-2.2. (Vol1) (Alla pagina sotto la descrizione dei parametri)
        {
            Vendor = 100;                                   // (367 credo sia Keyence)
            DeviceType = 43;                                 // (43 per l'XG-X2000 Series)
            ProductCode = 2;                                // (5004 per l'XG-X2000 Series)
            MajorRevision = 1;                              // (1 per l'XG-X2000 Series)
            MinorRevision = 1;                              // (1 per l'XG-X2000 Series)
            Status = new IdentityStatus();                  // (0x0034 per l'XG-X2000 Series)
            SerialNumber = 45654;                               // (0x0025B6BC per l'XG-X2000 Series)
            ProductName = "Qualivision's EtherNet/IP";      // ("XG-X2000 Series" per l'XG-X2000 Series)
            State = 255;                                    // State, Default = 255
            ConfigurationConsistencyValue = 0;              // Configuration Consistency Value, Default = 0
            HeartbeatInterval = 0;                          // Heartbeat Interval, Default = 0
        }

        public byte[] GetAttributesAll(int opzionali)                    // 5-2.3.2. Get_Attributes_All Response
        {
            byte[] ret = null;
            //Gli ultimi 3 parametri sono opzionali, ma in alcuni casi serve filtrarli
            //
            // 0 => Non ne inserisce nessuno
            // 1 => Inserisce State
            // 2 => Inserisce State e Configuration Consistency Value
            // 3 => Inserisce State, Configuration Consistency Value e Hearbeat Interval
            try
            {
                if (opzionali > 3)
                    return null;
                ret = new byte[0 + 14 + 1 + ProductName.Length + opzionali];
                /*
                    4 bytes riservati
                    14 di lunghezza fissa
                    1 per la lunghezza "L" del nome
                    "L" per il nome
                    3 bytes per gli ultimi parametri
                */

                ret[0] = (byte)Vendor;                                                  // Vendor (Low Byte)
                ret[1] = (byte)(Vendor >> 8);                                           // Vendor (High Byte)
                ret[2] = (byte)DeviceType;                                              // Device Type (Low Byte)
                ret[3] = (byte)(DeviceType >> 8);                                       // Device Type (High Byte)
                ret[4] = (byte)ProductCode;                                             // Product Code (Low Byte)
                ret[5] = (byte)(ProductCode >> 8);                                      // Product Code (High Byte)
                ret[6] = MajorRevision;                                                 // Major Version
                ret[7] = MinorRevision;                                                 // Minor Version
                ret[8] = Status.ToBytes()[1];                                           // Status (Low Byte)
                ret[9] = Status.ToBytes()[0];                                           // Status (High Byte)
                ret[10] = (byte)SerialNumber;                                           // Serial Number (Low byte)
                ret[11] = (byte)(SerialNumber >> 8);                                    // Serial Number
                ret[12] = (byte)(SerialNumber >> 16);                                   // Serial Number
                ret[13] = (byte)(SerialNumber >> 24);                                   // Serial Number (High byte)
                ret[14] = (byte)ProductName.Length;                                     // Product Name Length

                for (int i = 0; i < ProductName.Length; i++)                            // Product Name From 0
                    ret[15 + i] = (byte)ProductName[i];                                 // Product Name To Length-1

                if (opzionali > 0)
                    ret[15 + ProductName.Length] = State;                               // State, Default = 255
                if (opzionali > 1)
                    ret[15 + ProductName.Length + 1] = ConfigurationConsistencyValue;   // Configuration Consistency Value, Default = 0
                if (opzionali > 2)
                    ret[15 + ProductName.Length + 2] = HeartbeatInterval;                   // HeartBeat Interval, Default = 0
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
            return ret;
        }

        public byte[] GetAttributeSingle(byte Attribute)    // Sfortunatamente non c'è nulla nella documentazione, ma in base a Get_Attributes_All Response e sullo sniffer
        {
            byte[] ret = null;
            try
            {
                switch (Attribute)
                {
                    case 1:
                        ret = new byte[2];
                        ret[0] = (byte)Vendor;
                        ret[1] = (byte)(Vendor >> 8);
                        break;

                    case 2:
                        ret = new byte[2];
                        ret[0] = (byte)DeviceType;
                        ret[1] = (byte)(DeviceType >> 8);
                        break;

                    case 3:
                        ret = new byte[2];
                        ret[0] = (byte)ProductCode;
                        ret[1] = (byte)(ProductCode >> 8);
                        break;

                    case 4:
                        ret = new byte[2];
                        ret[0] = MajorRevision;
                        ret[1] = MinorRevision;
                        break;

                    case 5:
                        ret = new byte[2];
                        ret[0] = Status.ToBytes()[1];
                        ret[1] = Status.ToBytes()[0];
                        break;

                    case 6:
                        ret = new byte[4];
                        ret[0] = (byte)SerialNumber;
                        ret[1] = (byte)(SerialNumber >> 8);
                        ret[2] = (byte)(SerialNumber >> 16);
                        ret[3] = (byte)(SerialNumber >> 24);
                        break;

                    case 7:
                        ret = new byte[1 + ProductName.Length];
                        ret[0] = (byte)ProductName.Length;
                        for (int i = 0; i < ProductName.Length; i++)
                            ret[1 + i] = (byte)ProductName[i];
                        break;

                    default:
                        ret = null;
                        break;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
            return ret;
        }

        public byte[] GetCIPIdentityItem(System.Net.IPEndPoint epSlave)      // Table 2-5.4 – CIP Identity item
        {
            byte[] ret = null;
            try
            {
                byte[] IdentityObject = GetAttributesAll(1);
                ret = new byte[22 + IdentityObject.Length];

                ret[0] = 0x0C;                                      // Code indicating item type of CIP Identity (0x0C)
                ret[1] = 0;
                ret[2] = (byte)(18 + IdentityObject.Length);        // Number of bytes in item which follow (length varies depending on Product Name string)
                ret[3] = (byte)((18 + IdentityObject.Length) >> 8);
                ret[4] = 1;                                         // Encapsulation Protocol Version supported (also returned with Register Sesstion reply).
                ret[5] = 0;
                // Table 2 - 7.9 – Sockaddr item
                ret[6] = 0;                                         // sin_family (big-endian)
                ret[7] = 2;
                ret[8] = (byte)(epSlave.Port >> 8);                   // sin_port (big-endian)
                ret[9] = (byte)(epSlave.Port);
                ret[10] = epSlave.Address.GetAddressBytes()[0];     // sin_addr (big-endian)
                ret[11] = epSlave.Address.GetAddressBytes()[1];
                ret[12] = epSlave.Address.GetAddressBytes()[2];
                ret[13] = epSlave.Address.GetAddressBytes()[3];
                for (int i = 0; i < 8; i++)                         // sin_zero (length of 8) (big-endian)
                    ret[14 + i] = 0;
                for (int i = 0; i < IdentityObject.Length; i++)     // CIP Common specification Vol.1, chapter 5, Object Library
                    ret[i + 22] = IdentityObject[i];

            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
            return ret;
        }

        public class IdentityStatus                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            // Table 5-2.1. Bit Definitions for Status Instance Attribute of Identity Object
        {
            public bool Owned { get; set; }
            public bool Configured { get; set; }
            public ExtendedDeviceStatusDescription ExtendedDeviceStatusDescription { get; set; }
            public bool MinorRecoverableFault { get; set; }
            public bool MinorUnrecoverableFault { get; set; }
            public bool MajorRecoverableFault { get; set; }
            public bool MajorUnrecoverableFault { get; set; }

            public IdentityStatus()
            {
                Owned = false;
                Configured = true;
                ExtendedDeviceStatusDescription = ExtendedDeviceStatusDescription.SelfTestingOrUnknown;
                MinorRecoverableFault = false;
                MinorUnrecoverableFault = false;
                MajorRecoverableFault = false;
                MajorUnrecoverableFault = false;
            }

            public IdentityStatus(bool owned, bool configured, ExtendedDeviceStatusDescription extendedDeviceStatusDescription, bool minorRecoverableFault, bool minorUnrecoverableFault, bool majorRecoverableFault, bool majorUnrecoverableFault)
            {
                Owned = owned;
                Configured = configured;
                ExtendedDeviceStatusDescription = extendedDeviceStatusDescription;
                MinorRecoverableFault = minorRecoverableFault;
                MinorUnrecoverableFault = minorUnrecoverableFault;
                MajorRecoverableFault = majorRecoverableFault;
                MajorUnrecoverableFault = majorUnrecoverableFault;
            }

            public byte[] ToBytes()
            {
                byte[] ret = null;
                try
                {
                    ret = new byte[2];

                    ret[0] = 0;
                    ret[1] = 0;

                    ret[0] |= (byte)(MinorRecoverableFault ? 1 : 0);
                    ret[0] |= (byte)((MinorUnrecoverableFault ? 1 : 0) << 1);
                    ret[0] |= (byte)((MajorRecoverableFault ? 1 : 0) << 2);
                    ret[0] |= (byte)((MajorUnrecoverableFault ? 1 : 0) << 3);
                    ret[0] &= 0b00001111;

                    ret[1] |= (byte)(Owned ? 1 : 0);
                    ret[1] |= (byte)((Configured ? 1 : 0) << 2);
                    ret[1] |= (byte)ExtendedDeviceStatusDescription;
                    ret[1] &= 0b11110101;
                }
                catch (Exception ex)
                {
                    ExceptionHandler.HandleException(ex);
                }
                return ret;
            }
        }

        public enum ExtendedDeviceStatusDescription                     // Table 5-2.2. Bit Definitions for Extended Device Status Field
        {
            SelfTestingOrUnknown = 0b00000000,                          // 0b0000 0000
            FirmwareUpdateInProgress = 0b00010000,                      // 0b0001 0000
            AtLeastOneFaultedIOConnection = 0b00100000,                 // 0b0010 0000
            NoIOConnectionsEstablished = 0b00110000,                    // 0b0011 0000
            NonVolatileConfigurationBad = 0b01000000,                   // 0b0100 0000
            MajorFault = 0b01010000,                                    // 0b0101 0000
            AtLeastOneIOConnectionInRunMode = 0b01100000,               // 0b0110 0000
            AtLeastOneIOConnectionEstablished = 0b01110000              // 0b0111 0000
        };
    }
}
