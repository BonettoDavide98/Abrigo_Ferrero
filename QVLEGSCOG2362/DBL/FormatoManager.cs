using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace QVLEGSCOG2362.DBL
{
    public static class FormatoManager
    {

        public static string ConnectionString { get; set; }

        #region FillObjects

        private static DataType.Formato FillFormatoHeader(System.Data.IDataReader dr)
        {
            DataType.Formato formato = new DataType.Formato();
            formato.IdFormato = (string)dr["IdFormato"];
            formato.DescrizioneFormato = (string)dr["DescrizioneFormato"];
            return formato;
        }

        private static DataType.ParametriAlgoritmo FillParametriAlgoritmo(System.Data.IDataReader dr)
        {
            DataType.ParametriAlgoritmo formato = DataType.Extension.DeSerializeStringAsT<DataType.ParametriAlgoritmo>((string)dr["XML"]);
            formato.IdFormato = (string)dr["IdFormato"];

            return formato;
        }

        #endregion FillObjects

        public static List<DataType.Formato> ReadAllFormatiHeader()
        {
            List<DataType.Formato> ret = null;
            try
            {
                using (DBLBaseManager mngr = new DBLBaseManager(ConnectionString, false))
                {
                    ret = mngr.GetFilledTArray("SELECT * FROM Formati;", FillFormatoHeader);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return ret;
        }

        public static DataType.Formato ReadFormatiHeader(string idFormato)
        {
            DataType.Formato ret = null;
            try
            {
                using (DBLBaseManager mngr = new DBLBaseManager(ConnectionString, false))
                {
                    ret = mngr.GetFilledTArray("SELECT * FROM Formati WHERE [IdFormato] = @IdFormato;", new SqlParameter("@IdFormato", idFormato), FillFormatoHeader).SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return ret;
        }

        public static bool AddNewFormato(DataType.Formato formato)
        {
            bool ret = true;
            try
            {
                using (DBLBaseManager mngr = new DBLBaseManager(ConnectionString, false))
                {
                    string sqlStr = "INSERT INTO Formati ([IdFormato], [DescrizioneFormato]) VALUES (@IdFormato, @DescrizioneFormato);";

                    List<SqlParameter> param = new List<SqlParameter>();

                    param.Add(new SqlParameter("@IdFormato", formato.IdFormato));
                    param.Add(new SqlParameter("@DescrizioneFormato", formato.DescrizioneFormato));

                    mngr.ExecuteNonQuery(sqlStr, param);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return ret;
        }

        public static bool DeleteFormato(string idFormato)
        {
            bool ret = true;
            try
            {
                using (DBLBaseManager mngr = new DBLBaseManager(ConnectionString, false))
                {
                    string sqlStr = "DELETE FROM Formati WHERE [IdFormato] = @IdFormato;";
                    List<SqlParameter> param = new List<SqlParameter>();

                    param.Add(new SqlParameter("@IdFormato", idFormato));

                    mngr.ExecuteNonQuery(sqlStr, param);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return ret;
        }

        public static bool EsisteFormato(string idFormato)
        {
            bool ret = true;
            try
            {
                using (DBLBaseManager mngr = new DBLBaseManager(ConnectionString, false))
                {
                    string sqlStr = "SELECT COUNT(*) FROM Formati WHERE [IdFormato] = @IdFormato;";

                    object obj = mngr.ExecuteScalar(sqlStr, new SqlParameter("@IdFormato", idFormato));
                    if (obj != null && obj != DBNull.Value)
                    {
                        ret = (int)obj > 0;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return ret;
        }

        public static string GetDescrizioneFormato(string idFormato)
        {
            string ret = string.Empty;
            try
            {
                using (DBLBaseManager mngr = new DBLBaseManager(ConnectionString, false))
                {
                    string sqlStr = "SELECT DescrizioneFormato FROM Formati WHERE [IdFormato] = @IdFormato;";

                    object obj = mngr.ExecuteScalar(sqlStr, new SqlParameter("@IdFormato", idFormato));

                    if (obj != null && obj != DBNull.Value)
                        ret = (string)obj;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return ret;
        }

        #region ParametriAlgoritmo

        public static bool WriteParametriAlgoritmo(string idFormato, int idCamera, DataType.ParametriAlgoritmo parametri)
        {
            bool ret = true;
            try
            {
                using (DBLBaseManager mngr = new DBLBaseManager(ConnectionString, true))
                {
                    try
                    {
                        string sqlStr = "DELETE FROM [dbo].[ParametriAlgoritmo] WHERE [IdFormato] = @IdFormato AND IdCamera = @IdCamera;";

                        List<SqlParameter> paramDelete = new List<SqlParameter>();

                        paramDelete.Add(new SqlParameter("@IdFormato", idFormato));
                        paramDelete.Add(new SqlParameter("@IdCamera", idCamera));

                        mngr.ExecuteNonQuery(sqlStr, paramDelete);

                        sqlStr = "INSERT INTO [dbo].[ParametriAlgoritmo] ([IdFormato], [IdCamera], [XML]) VALUES (@IdFormato, @IdCamera, @XML);";

                        List<SqlParameter> paramUpdate = new List<SqlParameter>();

                        paramUpdate.Add(new SqlParameter("@IdFormato", idFormato));
                        paramUpdate.Add(new SqlParameter("@IdCamera", idCamera));
                        paramUpdate.Add(new SqlParameter("@XML", DataType.Extension.SerializeAsString(parametri)));

                        mngr.ExecuteNonQuery(sqlStr, paramUpdate);
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
            catch (Exception)
            {
                throw;
            }
            return ret;
        }

        public static DataType.ParametriAlgoritmo ReadParametriAlgoritmo(string idFormato, int idCamera)
        {
            DataType.ParametriAlgoritmo ret = null;
            try
            {
                using (DBLBaseManager mngr = new DBLBaseManager(ConnectionString, false))
                {
                    List<SqlParameter> param = new List<SqlParameter>();

                    param.Add(new SqlParameter("@IdFormato", idFormato));
                    param.Add(new SqlParameter("@IdCamera", idCamera));

                    ret = mngr.GetFilledTArray("SELECT * FROM [dbo].[ParametriAlgoritmo] WHERE [IdFormato] = @IdFormato AND IdCamera = @IdCamera;", param, FillParametriAlgoritmo).SingleOrDefault();
                }

                if (ret == null)
                    ret = new DataType.ParametriAlgoritmo();
            }
            catch (Exception)
            {
                throw;
            }
            return ret;
        }

        #endregion

    }
}