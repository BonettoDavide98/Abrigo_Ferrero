using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QVLEGSCOG2362.DBL
{
    public static class GestioneTurniManager
    {

        public static string ConnectionString { get; set; }

        private static DataType.Turno_Attuale Fill_TurnoAttuale(System.Data.IDataReader dr)
        {
            DataType.Turno_Attuale attuale = new DataType.Turno_Attuale();

            attuale.Id = (long)dr["Id"];

            return attuale;
        }

        private static DataType.Definizione_Turni Fill_DefinizioneTurni(System.Data.IDataReader dr)
        {
            DataType.Definizione_Turni defTurni = new DataType.Definizione_Turni();
            defTurni.NomeTurno = (short)dr["NomeTurno"];
            defTurni.Giorno = (short)dr["Giorno"];
            defTurni.OraFineTurno = (TimeSpan)dr["OraFineTurno"];
            defTurni.OraInizioTurno = (TimeSpan)dr["OraInizioTurno"];

            return defTurni;
        }

        private static DataType.StoricoTurni Fill_Statistiche_Turni(System.Data.IDataReader dr)
        {
            DataType.StoricoTurni defTurni = new DataType.StoricoTurni();
            defTurni.Id = (long)dr["Id"];
            defTurni.Data = Convert.ToDateTime(dr["Data"].ToString());
            defTurni.NomeTurno = (short)dr["NomeTurno"];

            return defTurni;
        }

        #region Gestione Turni

        public static void GetDatiTurnoCorrente(out DateTime dataRiferimentoTurno, out int nomeTurno)
        {
            DateTime oraAttuale = DateTime.Now;
            DataType.Definizione_Turni defTurno = Select_TurnoAttuale(DateTime.Now);
            nomeTurno = defTurno.NomeTurno;
            if (defTurno.Giorno == 1 && oraAttuale.TimeOfDay < new TimeSpan(14, 0, 0))
            {
                //se sono in un turno a cavallo di due giorni e sono al secondo giorno torno al giorno prima
                DateTime giornoPrima = oraAttuale.AddDays(-1);
                dataRiferimentoTurno = new DateTime(giornoPrima.Year, giornoPrima.Month, giornoPrima.Day);
            }
            else
            {
                dataRiferimentoTurno = new DateTime(oraAttuale.Year, oraAttuale.Month, oraAttuale.Day);
            }
        }

        public static long ReadID_TurnoAttuale()
        {
            long ret = -1;
            try
            {
                using (DBLBaseManager mngr = new DBLBaseManager(ConnectionString, false))
                {
                    DataType.Turno_Attuale att = mngr.GetFilledT("SELECT Id FROM Turno_Attuale", Fill_TurnoAttuale);
                    if (att != null)
                        ret = att.Id;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return ret;
        }

        public static bool AggiornoTurnoAttuale(DataType.Turno_Attuale turno)
        {
            bool ret = true;
            try
            {
                using (DBLBaseManager mngr = new DBLBaseManager(ConnectionString, true))
                {
                    try
                    {
                        string sqlStr = "DELETE FROM Turno_Attuale";
                        mngr.ExecuteNonQuery(sqlStr);

                        sqlStr = "INSERT INTO Turno_Attuale ([Id]) VALUES (@ID)";
                        List<SqlParameter> param = new List<SqlParameter>();
                        param.Add(new SqlParameter("@ID", turno.Id));

                        int i = mngr.ExecuteNonQuery(sqlStr, param);
                    }
                    catch (Exception)
                    {
                        ret = false;
                        throw;
                    }
                    finally
                    {
                        if (ret)
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
            catch (Exception ex)
            {
                ret = false;
                throw;
            }
            return ret;
        }

        public static DataType.Definizione_Turni Select_TurnoAttuale(DateTime oraAttuale)
        {
            DataType.Definizione_Turni definizioneTurni = null;
            try
            {
                using (DBLBaseManager mngr = new DBLBaseManager(ConnectionString, false))
                {
                    string query = @"
SELECT *
FROM Definizione_Turni
  WHERE
    (CASE
        WHEN CAST(@oraAttuale AS TIME(0)) BETWEEN [OraInizioTurno] AND [OraFineTurno] THEN [NomeTurno]
        WHEN CAST(@oraAttuale AS TIME(0)) BETWEEN [OraInizioTurno] AND '23:59:59' AND [Giorno] = 1 THEN [NomeTurno]
        WHEN CAST(@oraAttuale AS TIME(0)) BETWEEN '00:00:00' AND [OraFineTurno] AND [Giorno] = 1 THEN [NomeTurno]
        ELSE 0
    END) > 0;";

                    List<SqlParameter> param = new List<SqlParameter>
                    {
                        new SqlParameter("@oraAttuale", oraAttuale)
                    };


                    definizioneTurni = mngr.GetFilledT(query, param, Fill_DefinizioneTurni);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return definizioneTurni;
        }

        public static DataType.Definizione_Turni Select_NomeTurno(short nomeTurno)
        {
            DataType.Definizione_Turni definizioneTurni = null;
            try
            {
                using (DBLBaseManager mngr = new DBLBaseManager(ConnectionString, false))
                {
                    string query = "SELECT * FROM Definizione_Turni WHERE NomeTurno = @NomeTurno";
                    List<SqlParameter> param = new List<SqlParameter>
                    {
                        new SqlParameter("@nomeTurno", nomeTurno)
                    };

                    definizioneTurni = mngr.GetFilledT(query, param, Fill_DefinizioneTurni);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return definizioneTurni;
        }

        public static List<DataType.Definizione_Turni> Select_DefinizioneTurni()
        {
            List<DataType.Definizione_Turni> definizioneTurni = null;
            try
            {
                using (DBLBaseManager mngr = new DBLBaseManager(ConnectionString, false))
                {
                    string query = "SELECT * FROM Definizione_Turni";

                    definizioneTurni = mngr.GetFilledTArray(query, Fill_DefinizioneTurni);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return definizioneTurni;
        }

        public static DataType.StoricoTurni Select_StoricoTurni(long id)
        {
            DataType.StoricoTurni att = null;
            try
            {
                using (DBLBaseManager mngr = new DBLBaseManager(ConnectionString, false))
                {
                    string query = "SELECT * FROM StoricoTurni WHERE Id = @id";

                    att = mngr.GetFilledT(query, new SqlParameter("@id", id), Fill_Statistiche_Turni);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return att;
        }

        public static long MaxIndex_StoricoTurni()
        {
            long ret = -1;
            try
            {
                using (DBLBaseManager mngr = new DBLBaseManager(ConnectionString, false))
                {
                    object o = mngr.ExecuteScalar("SELECT MAX(Id) FROM StoricoTurni;");
                    if (o != DBNull.Value)
                    {
                        ret = (long)o;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return ret;
        }

        public static bool InsertNewStoricoTurni(DataType.StoricoTurni storico)
        {
            bool ret = true;
            try
            {
                using (DBLBaseManager mngr = new DBLBaseManager(ConnectionString, false))
                {
                    string sqlStr = "INSERT INTO [dbo].[StoricoTurni] ([Id], [Data], [NomeTurno]) VALUES (@Id, @Data, @NomeTurno);";

                    List<SqlParameter> param = new List<SqlParameter>();

                    param.Add(new SqlParameter("@Id", storico.Id));
                    param.Add(new SqlParameter("@Data", storico.Data));
                    param.Add(new SqlParameter("@NomeTurno", storico.NomeTurno));

                    mngr.ExecuteNonQuery(sqlStr, param);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return ret;
        }





        public static int GetMaxIdOrariTurni(string connectionString)
        {
            int ret = -1;
            try
            {

                using (DBLBaseManager mngr = new DBLBaseManager(connectionString, false))
                {
                    object obj = mngr.ExecuteScalar("SELECT MAX(NomeTurno) FROM Definizione_Turni");

                    if (obj != null && obj != DBNull.Value)
                        ret = (int)(short)obj;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return ret;
        }

        public static List<DataType.Definizione_Turni> ReadAllOrariTurni(string connectionString)
        {
            List<DataType.Definizione_Turni> ret = null;
            try
            {

                using (DBLBaseManager mngr = new DBLBaseManager(connectionString, false))
                {
                    ret = mngr.GetFilledTArray("SELECT * FROM Definizione_Turni;", Fill_DefinizioneTurni);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return ret;
        }

        public static bool InsertUpdateDefinizioneTurni(string connectionString, DataType.Definizione_Turni orariTurni)
        {
            bool ret = true;
            try
            {
                using (DBLBaseManager mngr = new DBLBaseManager(connectionString, true))
                {
                    List<SqlParameter> param = new List<SqlParameter>();
                    try
                    {
                        param.Add(new SqlParameter("@NomeTurno", orariTurni.NomeTurno));
                        param.Add(new SqlParameter("@OraInizioTurno", orariTurni.OraInizioTurno));
                        param.Add(new SqlParameter("@OraFineTurno", orariTurni.OraFineTurno));
                        param.Add(new SqlParameter("@Giorno", orariTurni.OraFineTurno.Hours < orariTurni.OraInizioTurno.Hours ? 1 : 0));

                        string sqlstr = @"IF EXISTS(SELECT * FROM Definizione_Turni WHERE NomeTurno = @NomeTurno)
                UPDATE Definizione_Turni SET OraInizioTurno = @OraInizioTurno, OraFineTurno = @OraFineTurno, Giorno = @Giorno WHERE NomeTurno = @NomeTurno;
                ELSE
                INSERT INTO Definizione_Turni (NomeTurno, OraInizioTurno, OraFineTurno, Giorno) VALUES (@NomeTurno, @OraInizioTurno, @OraFineTurno, @Giorno);";

                        mngr.ExecuteNonQuery(sqlstr, param);

                        param.Clear();
                    }
                    catch (Exception)
                    {
                        ret = false;
                        throw;
                    }
                    finally
                    {
                        if (ret)
                            mngr.CommitTransaction();
                        else
                            mngr.RollbackTransaction();
                    }
                }
            }
            catch (Exception)
            {
                ret = false;
                throw;
            }
            return ret;
        }

        public static bool DeleteDefinizioneTurni(string connectionString, int nomeTurno)
        {
            bool ret = true;
            try
            {
                using (DBLBaseManager mngr = new DBLBaseManager(connectionString, false))
                {
                    List<SqlParameter> param = new List<SqlParameter>();
                    try
                    {
                        param.Add(new SqlParameter("@NomeTurno", nomeTurno));

                        string sqlstr = @"DELETE FROM Definizione_Turni WHERE NomeTurno = @NomeTurno;";

                        mngr.ExecuteNonQuery(sqlstr, param);
                    }
                    catch (Exception)
                    {
                        ret = false;
                        throw;
                    }
                }
            }
            catch (Exception)
            {
                ret = false;
                throw;
            }

            return ret;
        }

        #endregion

    }
}