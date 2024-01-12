using System;

namespace ClientEEIP.ClassiMie
{
    public class Header
    {
        public ushort Command { get; set; }
        public ushort Length { get; set; }
        public uint SessionHandle { get; set; }
        public uint Status { get; set; }
        public byte[] SenderContext { get; set; }
        public uint Options { get; set; }
        public byte[] EncapsulatedData { get; set; }

        public Header() { }

        public Header(byte[] arrived)       // Table 2-4.1 – Encapsulation packet
        {
            try
            {
                SenderContext = new byte[8];

                Command = (ushort)(arrived[0] | arrived[1] << 8);
                Length = (ushort)(arrived[2] | arrived[3] << 8);
                SessionHandle = (uint)(arrived[4] | (arrived[5] << 8) | (arrived[6] << 16) | (arrived[7] << 24));
                Status = (ushort)(arrived[8] | arrived[9] << 8 | arrived[10] << 16 | arrived[11] << 32);
                SenderContext[0] = arrived[12];
                SenderContext[1] = arrived[13];
                SenderContext[2] = arrived[14];
                SenderContext[3] = arrived[15];
                SenderContext[4] = arrived[16];
                SenderContext[5] = arrived[17];
                SenderContext[6] = arrived[18];
                SenderContext[7] = arrived[19];
                Options = (ushort)(arrived[20] | arrived[21] << 8 | arrived[22] << 16 | arrived[23] << 32);

                if (Length > 0 && Length < arrived.Length)
                {
                    EncapsulatedData = new byte[Length];
                    for (int i = 0; i < Length; i++)
                        EncapsulatedData[i] = arrived[24 + i];
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
        }
    }
}
