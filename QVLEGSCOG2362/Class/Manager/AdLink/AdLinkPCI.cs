namespace QVLEGSCOG2362.Class
{
    public class AdLinkPCI
    {
        private short deviceNum = -1;

        public bool Connect()
        {
            this.deviceNum = DASK.Register_Card(DASK.PCI_7230, 0);

            return deviceNum >= 0;
        }

        public short WriteAllDO(uint valueByte)
        {
            short err = DASK.DO_WritePort((ushort)this.deviceNum, 0, valueByte);

            return err;
        }

        public short WriteDO(ushort port, ushort value)
        {
            short err = DASK.DO_WriteLine((ushort)this.deviceNum, 0, port, value);

            return err;
        }

        public short ReadDO(ushort port, out int value)
        {
            ushort val = 0;
            short err = DASK.DO_ReadLine((ushort)this.deviceNum, 0, port, out val);

            value = (int)val;

            return err;
        }

        public short ReadAllDI(out int values)
        {
            uint val;
            short err = DASK.DI_ReadPort((ushort)this.deviceNum, 0, out val);

            values = (int)val;

            return err;
        }

        public short ReadAllDO(out int values)
        {
            uint val;
            short err = DASK.DO_ReadPort((ushort)this.deviceNum, 0, out val);

            values = (int)val;

            return err;
        }

        public short ReadDI(ushort port, out int value)
        {
            ushort val = 0;
            short err = DASK.DI_ReadLine((ushort)this.deviceNum, 0, port, out val);

            value = (int)val;

            return err;
        }

        public void Disconnect()
        {
            if (this.deviceNum >= 0)
                DASK.Release_Card((ushort)this.deviceNum);
        }
    }
}
