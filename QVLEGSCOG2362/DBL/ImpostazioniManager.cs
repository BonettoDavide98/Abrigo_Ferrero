using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace QVLEGSCOG2362.DBL
{
    public class ImpostazioniManager
    {

        public static string ConnectionString { get; set; }

        public static DataType.Impostazioni ReadImpostazioni()
        {
            DataType.Impostazioni ret = null;
            try
            {
                using (DBLBaseManager mngr = new DBLBaseManager(ConnectionString, false))
                {
                    DataTable dt = mngr.FillDataTable("SELECT * FROM TabImpostazioni WHERE Chiave <> '__IdFormato';");
                    Dictionary<string, string> dict = new Dictionary<string, string>();
                    foreach (DataRow r in dt.Rows)
                    {
                        dict.Add((string)r["Chiave"], (string)r["Valore"]);
                    }
                    ret = DictionaryToImpostazioni(dict);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return ret;
        }

        public static void WriteImpostazioni(DataType.Impostazioni impostazioni)
        {
            try
            {
                using (DBLBaseManager mngr = new DBLBaseManager(ConnectionString, true))
                {
                    bool ok = true;
                    try
                    {

                        mngr.ExecuteNonQuery("DELETE FROM TabImpostazioni WHERE Chiave <> '__IdFormato';");

                        string sqlStr = "INSERT INTO [dbo].[TabImpostazioni] ([Chiave],[Valore]) VALUES (@Chiave,@Valore);";


                        Dictionary<string, string> dict = ImpostazioniToDictionary(impostazioni);

                        foreach (var p in dict)
                        {
                            List<SqlParameter> param = new List<SqlParameter>();

                            param.Add(new SqlParameter("@Chiave", p.Key));
                            param.Add(new SqlParameter("@Valore", p.Value));

                            mngr.ExecuteNonQuery(sqlStr, param);
                        }

                    }
                    catch (Exception)
                    {
                        ok = false;
                        throw;
                    }
                    finally
                    {
                        if (ok)
                        {
                            mngr.CommitTransaction();
                        }
                        else
                        {
                            mngr.RollbackTransaction();
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string ReadFormatoCorrente()
        {
            string ret = string.Empty;
            try
            {
                using (DBLBaseManager mngr = new DBLBaseManager(ConnectionString, false))
                {
                    object obj = mngr.ExecuteScalar("SELECT Valore FROM TabImpostazioni WHERE Chiave = '__IdFormato';");
                    if (obj != null && obj != DBNull.Value)
                    {
                        ret = obj as string;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return ret;
        }

        public static void WriteFormatoCorrente(string idFormato)
        {
            try
            {
                using (DBLBaseManager mngr = new DBLBaseManager(ConnectionString, true))
                {
                    bool ok = true;
                    try
                    {

                        mngr.ExecuteNonQuery("DELETE FROM TabImpostazioni WHERE Chiave = '__IdFormato';");

                        string sqlStr = "INSERT INTO [dbo].[TabImpostazioni] ([Chiave],[Valore]) VALUES ('__IdFormato',@Valore);";

                        mngr.ExecuteNonQuery(sqlStr, new SqlParameter("@Valore", idFormato));

                    }
                    catch (Exception)
                    {
                        ok = false;
                        throw;
                    }
                    finally
                    {
                        if (ok)
                        {
                            mngr.CommitTransaction();
                        }
                        else
                        {
                            mngr.RollbackTransaction();
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        private static DataType.Impostazioni DictionaryToImpostazioni(Dictionary<string, string> dictionary)
        {
            DataType.Impostazioni ret = new DataType.Impostazioni();

            ret.PathDatiBase = GetValueString(dictionary, "PathDatiBase");
            ret.Password = GetValueString(dictionary, "Password");

            string sImpostazioniCamera1 = GetValueString(dictionary, "ImpostazioniCamera1");
            if (!string.IsNullOrWhiteSpace(sImpostazioniCamera1))
                ret.ImpostazioniCamera1 = DataType.Extension.DeSerializeStringAsT<DataType.ImpostazioniCamera>(sImpostazioniCamera1);

            string sImpostazioniCamera2 = GetValueString(dictionary, "ImpostazioniCamera2");
            if (!string.IsNullOrWhiteSpace(sImpostazioniCamera2))
                ret.ImpostazioniCamera2 = DataType.Extension.DeSerializeStringAsT<DataType.ImpostazioniCamera>(sImpostazioniCamera2);

            string sImpostazioniCamera3 = GetValueString(dictionary, "ImpostazioniCamera3");
            if (!string.IsNullOrWhiteSpace(sImpostazioniCamera3))
                ret.ImpostazioniCamera3 = DataType.Extension.DeSerializeStringAsT<DataType.ImpostazioniCamera>(sImpostazioniCamera3);

            string sImpostazioniCamera4 = GetValueString(dictionary, "ImpostazioniCamera4");
            if (!string.IsNullOrWhiteSpace(sImpostazioniCamera4))
                ret.ImpostazioniCamera4 = DataType.Extension.DeSerializeStringAsT<DataType.ImpostazioniCamera>(sImpostazioniCamera4);

            string sImpostazioniCamera5 = GetValueString(dictionary, "ImpostazioniCamera5");
            if (!string.IsNullOrWhiteSpace(sImpostazioniCamera5))
                ret.ImpostazioniCamera5 = DataType.Extension.DeSerializeStringAsT<DataType.ImpostazioniCamera>(sImpostazioniCamera5);

            string sImpostazioniCamera6 = GetValueString(dictionary, "ImpostazioniCamera6");
            if (!string.IsNullOrWhiteSpace(sImpostazioniCamera6))
                ret.ImpostazioniCamera6 = DataType.Extension.DeSerializeStringAsT<DataType.ImpostazioniCamera>(sImpostazioniCamera6);

            ret.IpGocator = GetValueString(dictionary, "IpGocator");

            ret.PLC_1_IP = GetValueString(dictionary, "PLC_1_IP");
            ret.PLC_2_IP = GetValueString(dictionary, "PLC_2_IP");
            ret.PLC_Rack = GetValueInt(dictionary, "PLC_Rack");
            ret.PLC_Slot = GetValueInt(dictionary, "PLC_Slot");

            ret.NumeroErrori = GetValueInt(dictionary, "NumeroErrori");
            ret.NumeroErroriSuDisco = GetValueInt(dictionary, "NumeroErroriSuDisco");
            ret.ErroriSuDisco = GetValueBool(dictionary, "ErroriSuDisco");
            ret.PathErrori = GetValueString(dictionary, "PathErrori", @"C:\QUALIVISION\ERRORS");

            ret.TipologiaDispositivoScarto = (DataType.Impostazioni.DispositiviScarto)GetValueInt(dictionary, "TipologiaDispositivoScarto");
            ret.TipologiaComunizazioneRisultato = (DataType.Impostazioni.TipoComunizazioneRisultato)GetValueInt(dictionary, "TipologiaComunizazioneRisultato");
            ret.KConv_mm_enc = GetValueDouble(dictionary, "KConv_mm_enc");
            ret.IpGardasoft = GetValueString(dictionary, "IpGardasoft");
            ret.PortaGardasoft = GetValueInt(dictionary, "PortaGardasoft");

            ret.LoginTimeout = GetValueInt(dictionary, "LoginTimeout");
            ret.BypassLogin = GetValueBool(dictionary, "BypassLogin");
            ret.TipologiaLogin = (DataType.Impostazioni.TipoLogin)GetValueInt(dictionary, "TipologiaLogin");

            ret.ControlloNastro = GetValueBool(dictionary, "ControlloNastro");
            ret.TempoControlloNastro = GetValueInt(dictionary, "TempoControlloNastro");

            ret.IdxOutReady = GetValueInt(dictionary, "IdxOutReady");
            ret.IdxOutResult = GetValueInt(dictionary, "IdxOutResult");
            ret.IdxOutResult_2 = GetValueInt(dictionary, "IdxOutResult_2");
            ret.IdxOutReady2 = GetValueInt(dictionary, "IdxOutReady2");
            ret.IdxOutResult2 = GetValueInt(dictionary, "IdxOutResult2");
            ret.IdxOutResult2_2 = GetValueInt(dictionary, "IdxOutResult2_2");
            ret.IdxOutSirena = GetValueInt(dictionary, "IdxOutSirena");
            ret.IdxOutLedRosso = GetValueInt(dictionary, "IdxOutLedRosso");
            ret.IdxOutLedVerde = GetValueInt(dictionary, "IdxOutLedVerde");
            ret.IdxOutLedGiallo = GetValueInt(dictionary, "IdxOutLedGiallo");
            ret.IdxOutLifeBit = GetValueInt(dictionary, "IdxOutLifeBit", -1);
            ret.IdxInEnable = GetValueInt(dictionary, "IdxInEnable", -1);
            ret.IdxInSelettoreSoffio = GetValueInt(dictionary, "IdxInSelettoreSoffio", -1);

            ret.MaxPercentualeScarto = GetValueInt(dictionary, "MaxPercentualeScarto");
            ret.NumPezziCalcoloPercentualeScarto = GetValueInt(dictionary, "NumPezziCalcoloPercentualeScarto");
            ret.TimeoutSirena = GetValueInt(dictionary, "TimeoutSirena");

            ret.Lingua1 = GetValueString(dictionary, "Lingua1");
            ret.Lingua2 = GetValueString(dictionary, "Lingua2");
            ret.Lingua3 = GetValueString(dictionary, "Lingua3");

            ret.SogliaPercScatoRosso = GetValueDouble(dictionary, "SogliaPercScatoRosso");
            ret.SogliaPercScatoGiallo = GetValueDouble(dictionary, "SogliaPercScatoGiallo");

            ret.AbilitaVistaAvanzata = GetValueBool(dictionary, "AbilitaVistaAvanzata");
            ret.AreaMinimaSegmentazione2 = GetValueDouble(dictionary, "AreaMinimaSegmentazione2", 500.0);

            ret.AbilitaSceltaModo = GetValueBool(dictionary, "AbilitaSceltaModo", false);

            ret.BucketSize_3D = GetValueDouble(dictionary, "BucketSize_3D", 0.3);
            ret.OffsetX_3D = GetValueInt(dictionary, "OffsetX_3D", 300);
            ret.OffsetZ_3D = GetValueInt(dictionary, "OffsetZ_3D", 300);
            ret.ImageW_3DTop = GetValueInt(dictionary, "ImageW_3DTop", 600);
            ret.ImageH_3DTop = GetValueInt(dictionary, "ImageH_3DTop", 150);
            ret.ScaleW_3DTop = GetValueDouble(dictionary, "ScaleW_3DTop", 1.0);
            ret.ScaleH_3DTop = GetValueDouble(dictionary, "ScaleH_3DTop", 5.0);
            ret.ImageW_3DLato = GetValueInt(dictionary, "ImageW_3DLato", 600);
            ret.ImageH_3DLato = GetValueInt(dictionary, "ImageH_3DLato", 200);
            ret.ScaleW_3DLato = GetValueDouble(dictionary, "ScaleW_3DLato", 4.0);
            ret.ScaleH_3DLato = GetValueDouble(dictionary, "ScaleH_3DLato", 5.0);

            ret.AbilitaIntegrita2 = GetValueBool(dictionary, "AbilitaIntegrita2", true);
            ret.AbilitaIntegrita3 = GetValueBool(dictionary, "AbilitaIntegrita3", true);
            ret.AbilitaIntegrita4 = GetValueBool(dictionary, "AbilitaIntegrita4", true);

            ret.PercentualeTolleranzaAlgoritmi = GetValueDouble(dictionary, "PercentualeTolleranzaAlgoritmi", 0.2);

            return ret;
        }

        private static Dictionary<string, string> ImpostazioniToDictionary(DataType.Impostazioni impostazioni)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();

            dict.Add("PathDatiBase", impostazioni.PathDatiBase);
            dict.Add("Password", impostazioni.Password);

            dict.Add("ImpostazioniCamera1", DataType.Extension.SerializeAsString(impostazioni.ImpostazioniCamera1));
            dict.Add("ImpostazioniCamera2", DataType.Extension.SerializeAsString(impostazioni.ImpostazioniCamera2));
            dict.Add("ImpostazioniCamera3", DataType.Extension.SerializeAsString(impostazioni.ImpostazioniCamera3));
            dict.Add("ImpostazioniCamera4", DataType.Extension.SerializeAsString(impostazioni.ImpostazioniCamera4));
            dict.Add("ImpostazioniCamera5", DataType.Extension.SerializeAsString(impostazioni.ImpostazioniCamera5));
            dict.Add("ImpostazioniCamera6", DataType.Extension.SerializeAsString(impostazioni.ImpostazioniCamera6));
            dict.Add("IpGocator", impostazioni.IpGocator);

            dict.Add("PLC_1_IP", impostazioni.PLC_1_IP);
            dict.Add("PLC_2_IP", impostazioni.PLC_2_IP);
            dict.Add("PLC_Rack", impostazioni.PLC_Rack.ToString());
            dict.Add("PLC_Slot", impostazioni.PLC_Slot.ToString());

            dict.Add("NumeroErrori", impostazioni.NumeroErrori.ToString());
            dict.Add("NumeroErroriSuDisco", impostazioni.NumeroErroriSuDisco.ToString());
            dict.Add("ErroriSuDisco", impostazioni.ErroriSuDisco.ToString());
            dict.Add("PathErrori", impostazioni.PathErrori);

            dict.Add("TipologiaDispositivoScarto", ((int)impostazioni.TipologiaDispositivoScarto).ToString());
            dict.Add("TipologiaComunizazioneRisultato", ((int)impostazioni.TipologiaComunizazioneRisultato).ToString());
            dict.Add("KConv_mm_enc", impostazioni.KConv_mm_enc.ToString(CultureInfo.InvariantCulture));
            dict.Add("IpGardasoft", impostazioni.IpGardasoft.ToString());
            dict.Add("PortaGardasoft", impostazioni.PortaGardasoft.ToString());

            dict.Add("LoginTimeout", impostazioni.LoginTimeout.ToString());
            dict.Add("BypassLogin", impostazioni.BypassLogin.ToString());
            dict.Add("TipologiaLogin", ((int)impostazioni.TipologiaLogin).ToString());

            dict.Add("ControlloNastro", impostazioni.ControlloNastro.ToString());
            dict.Add("TempoControlloNastro", impostazioni.TempoControlloNastro.ToString());

            dict.Add("IdxOutReady", impostazioni.IdxOutReady.ToString());
            dict.Add("IdxOutResult", impostazioni.IdxOutResult.ToString());
            dict.Add("IdxOutResult_2", impostazioni.IdxOutResult_2.ToString());
            dict.Add("IdxOutReady2", impostazioni.IdxOutReady2.ToString());
            dict.Add("IdxOutResult2", impostazioni.IdxOutResult2.ToString());
            dict.Add("IdxOutResult2_2", impostazioni.IdxOutResult2_2.ToString());

            dict.Add("IdxOutSirena", impostazioni.IdxOutSirena.ToString());
            dict.Add("IdxOutLedRosso", impostazioni.IdxOutLedRosso.ToString());
            dict.Add("IdxOutLedVerde", impostazioni.IdxOutLedVerde.ToString());
            dict.Add("IdxOutLedGiallo", impostazioni.IdxOutLedGiallo.ToString());
            dict.Add("IdxOutLifeBit", impostazioni.IdxOutLifeBit.ToString());
            dict.Add("IdxInEnable", impostazioni.IdxInEnable.ToString());
            dict.Add("IdxInSelettoreSoffio", impostazioni.IdxInSelettoreSoffio.ToString());

            dict.Add("MaxPercentualeScarto", impostazioni.MaxPercentualeScarto.ToString());
            dict.Add("NumPezziCalcoloPercentualeScarto", impostazioni.NumPezziCalcoloPercentualeScarto.ToString());
            dict.Add("TimeoutSirena", impostazioni.TimeoutSirena.ToString());

            dict.Add("Lingua1", impostazioni.Lingua1.ToString());
            dict.Add("Lingua2", impostazioni.Lingua2.ToString());
            dict.Add("Lingua3", impostazioni.Lingua3.ToString());

            dict.Add("SogliaPercScatoRosso", impostazioni.SogliaPercScatoRosso.ToString(CultureInfo.InvariantCulture));
            dict.Add("SogliaPercScatoGiallo", impostazioni.SogliaPercScatoGiallo.ToString(CultureInfo.InvariantCulture));

            dict.Add("AbilitaVistaAvanzata", impostazioni.AbilitaVistaAvanzata.ToString());
            dict.Add("AreaMinimaSegmentazione2", impostazioni.AreaMinimaSegmentazione2.ToString(CultureInfo.InvariantCulture));

            dict.Add("AbilitaSceltaModo", impostazioni.AbilitaSceltaModo.ToString(CultureInfo.InvariantCulture));

            dict.Add("BucketSize_3D", impostazioni.BucketSize_3D.ToString(CultureInfo.InvariantCulture));
            dict.Add("OffsetX_3D", impostazioni.OffsetX_3D.ToString(CultureInfo.InvariantCulture));
            dict.Add("OffsetZ_3D", impostazioni.OffsetZ_3D.ToString(CultureInfo.InvariantCulture));
            dict.Add("ImageW_3DTop", impostazioni.ImageW_3DTop.ToString(CultureInfo.InvariantCulture));
            dict.Add("ImageH_3DTop", impostazioni.ImageH_3DTop.ToString(CultureInfo.InvariantCulture));
            dict.Add("ScaleW_3DTop", impostazioni.ScaleW_3DTop.ToString(CultureInfo.InvariantCulture));
            dict.Add("ScaleH_3DTop", impostazioni.ScaleH_3DTop.ToString(CultureInfo.InvariantCulture));
            dict.Add("ImageW_3DLato", impostazioni.ImageW_3DLato.ToString(CultureInfo.InvariantCulture));
            dict.Add("ImageH_3DLato", impostazioni.ImageH_3DLato.ToString(CultureInfo.InvariantCulture));
            dict.Add("ScaleW_3DLato", impostazioni.ScaleW_3DLato.ToString(CultureInfo.InvariantCulture));
            dict.Add("ScaleH_3DLato", impostazioni.ScaleH_3DLato.ToString(CultureInfo.InvariantCulture));

            dict.Add("AbilitaIntegrita2", impostazioni.AbilitaIntegrita2.ToString(CultureInfo.InvariantCulture));
            dict.Add("AbilitaIntegrita3", impostazioni.AbilitaIntegrita3.ToString(CultureInfo.InvariantCulture));
            dict.Add("AbilitaIntegrita4", impostazioni.AbilitaIntegrita4.ToString(CultureInfo.InvariantCulture));

            dict.Add("PercentualeTolleranzaAlgoritmi", impostazioni.PercentualeTolleranzaAlgoritmi.ToString(CultureInfo.InvariantCulture));

            return dict;
        }




        private static bool GetValueBool(Dictionary<string, string> dictionary, string key)
        {
            return GetValueBool(dictionary, key, false);
        }

        private static bool GetValueBool(Dictionary<string, string> dictionary, string key, bool defaultvalue)
        {
            if (dictionary.ContainsKey(key))
                return bool.Parse(dictionary[key]);
            else
                return defaultvalue;
        }

        private static string GetValueString(Dictionary<string, string> dictionary, string key)
        {
            return GetValueString(dictionary, key, string.Empty);
        }

        private static string GetValueString(Dictionary<string, string> dictionary, string key, string defaultvalue)
        {
            if (dictionary.ContainsKey(key))
                return dictionary[key];
            else
                return defaultvalue;
        }

        private static int GetValueInt(Dictionary<string, string> dictionary, string key)
        {
            return GetValueInt(dictionary, key, 0);
        }

        private static int GetValueInt(Dictionary<string, string> dictionary, string key, int defaultvalue)
        {
            if (dictionary.ContainsKey(key))
                return int.Parse(dictionary[key]);
            else
                return defaultvalue;
        }

        private static long GetValueLong(Dictionary<string, string> dictionary, string key)
        {
            return GetValueLong(dictionary, key, 0);
        }

        private static long GetValueLong(Dictionary<string, string> dictionary, string key, long defaultvalue)
        {
            if (dictionary.ContainsKey(key))
                return long.Parse(dictionary[key]);
            else
                return 0;
        }

        private static double GetValueDouble(Dictionary<string, string> dictionary, string key)
        {
            return GetValueDouble(dictionary, key, 0.0);
        }

        private static double GetValueDouble(Dictionary<string, string> dictionary, string key, double defaultvalue)
        {
            if (dictionary.ContainsKey(key))
                return double.Parse(dictionary[key], CultureInfo.InvariantCulture);
            else
                return defaultvalue;
        }

    }
}