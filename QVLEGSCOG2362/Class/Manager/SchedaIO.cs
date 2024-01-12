using System;

namespace QVLEGSCOG2362.Class.Manager
{
    public class SchedaIO
    {

        private AdLinkPCI adlink = null;
        private DataType.Impostazioni config = null;

        public void Init(DataType.Impostazioni config)
        {
            this.config = config;

#if !_Simulazione
            if (config.TipologiaComunizazioneRisultato == DataType.Impostazioni.TipoComunizazioneRisultato.SchedaIO)
            {
                adlink = new AdLinkPCI();
                adlink.Connect();

                //adlink.WriteDO((ushort)this.config.IdxOutLedVerde, 1);
                //adlink.WriteDO((ushort)this.config.IdxOutLedRosso, 0);
                //adlink.WriteDO((ushort)this.config.IdxOutLedGiallo, 0);
            }
#endif
        }


        public void SetOutput(int idStazioe, bool ready, bool result, bool result2)
        {
            try
            {
#if !_Simulazione
                if (config.TipologiaComunizazioneRisultato == DataType.Impostazioni.TipoComunizazioneRisultato.SchedaIO)
                {
                    //SET RISULTATO
                    adlink.WriteDO((ushort)(idStazioe == 0 ? this.config.IdxOutResult : this.config.IdxOutResult2), (ushort)(result ? 1 : 0));
                    //SET RISULTATO2
                    adlink.WriteDO((ushort)(idStazioe == 0 ? this.config.IdxOutResult_2 : this.config.IdxOutResult2_2), (ushort)(result2 ? 1 : 0));
                    //SET BUSY
                    adlink.WriteDO((ushort)(idStazioe == 0 ? this.config.IdxOutReady : this.config.IdxOutReady2), (ushort)(ready ? 1 : 0));
                }
#endif
            }
            catch (Exception) { }
        }

        public void SetTorretta(bool verde, bool rosso, bool giallo, bool sirena)
        {
            try
            {
#if !_Simulazione
                //adlink.WriteDO((ushort)this.config.IdxOutLedVerde, (ushort)(verde ? 1 : 0));
                //adlink.WriteDO((ushort)this.config.IdxOutLedRosso, (ushort)(rosso ? 1 : 0));
                //adlink.WriteDO((ushort)this.config.IdxOutLedGiallo, (ushort)(giallo ? 1 : 0));
                //adlink.WriteDO((ushort)this.config.IdxOutSirena, (ushort)(sirena ? 1 : 0));
#endif
            }
            catch (Exception) { }
        }

        public void SetLifeBit(bool valore)
        {
            try
            {
                if (this.config.IdxOutLifeBit > 0)
                {
#if !_Simulazione
                    //adlink.WriteDO((ushort)this.config.IdxOutLifeBit, (ushort)(valore ? 1 : 0));
#endif
                }

            }
            catch (Exception) { }
        }

        public bool GetEnable()
        {
            bool ret = false;
            try
            {
                if (this.config.IdxInEnable > 0)
                {
#if !_Simulazione
                    //adlink.ReadDI((ushort)this.config.IdxInEnable, out int val);
                    //ret = val == 1;
#endif
                }
                else
                {
                    ret = true;
                }

            }
            catch (Exception) { }
            return ret;
        }

        public bool GetSoffioEnable()
        {
            bool ret = false;
            try
            {
                if (this.config.IdxInSelettoreSoffio > 0)
                {
#if !_Simulazione
                    //adlink.ReadDI((ushort)this.config.IdxInSelettoreSoffio, out int val);
                    //ret = val == 1;
#endif
                }
                else
                {
                    ret = true;
                }

            }
            catch (Exception) { }
            return ret;
        }

    }
}
