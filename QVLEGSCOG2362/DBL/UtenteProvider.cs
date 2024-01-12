using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QVLEGSCOG2362.DBL
{
    public static class UtenteProvider
    {

        public static string ConnectionString { get; set; }

        public static bool TryLogin(string username, string password, ref DataType.Utente utente)
        {
            bool result = true;

            try
            {
                using (SqlConnection cnn = new SqlConnection(ConnectionString))
                {
                    cnn.Open();

                    string sql = "SELECT u.*, l.Descrizione AS Livello FROM AnagraficaUtenti u LEFT JOIN Livelli l ON l.ID = u.IdLivello WHERE Username = @username AND Password = @password";

                    using (SqlCommand cmd = new SqlCommand(sql, cnn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        using (SqlDataReader dr = cmd.ExecuteReader())
                            if (dr.Read())
                            {
                                utente = new DataType.Utente();

                                if (!dr.IsDBNull(dr.GetOrdinal("ID"))) utente.ID = dr.GetInt32(dr.GetOrdinal("ID"));
                                if (!dr.IsDBNull(dr.GetOrdinal("Username"))) utente.Username = dr.GetString(dr.GetOrdinal("Username"));
                                if (!dr.IsDBNull(dr.GetOrdinal("Password"))) utente.Password = dr.GetString(dr.GetOrdinal("Password"));
                                if (!dr.IsDBNull(dr.GetOrdinal("Operatore"))) utente.Operatore = dr.GetString(dr.GetOrdinal("Operatore"));

                                utente.LivelloUtente = (DataType.Livello.LivelloUtente)dr.GetInt32(dr.GetOrdinal("IdLivello"));
                            }
                            else
                                utente = null;
                    }

                    cnn.Close();
                }
            }
            catch (Exception)
            {
                result = false;
                throw;
            }

            return result;
        }

        public static bool GetAllUsers(ref List<DataType.Utente> listaUtenti)
        {
            bool result = true;

            try
            {
                using (SqlConnection cnn = new SqlConnection(ConnectionString))
                {
                    cnn.Open();

                    string sql = "SELECT u.*, l.Descrizione AS Livello FROM AnagraficaUtenti u LEFT JOIN Livelli l ON l.ID = u.IdLivello WHERE Username <> 'qualivision'";

                    using (SqlCommand cmd = new SqlCommand(sql, cnn))
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader())
                            while (dr.Read())
                            {
                                DataType.Utente utente = new DataType.Utente();

                                if (!dr.IsDBNull(dr.GetOrdinal("ID"))) utente.ID = dr.GetInt32(dr.GetOrdinal("ID"));
                                if (!dr.IsDBNull(dr.GetOrdinal("Username"))) utente.Username = dr.GetString(dr.GetOrdinal("Username"));
                                if (!dr.IsDBNull(dr.GetOrdinal("Password"))) utente.Password = dr.GetString(dr.GetOrdinal("Password"));
                                if (!dr.IsDBNull(dr.GetOrdinal("Operatore"))) utente.Operatore = dr.GetString(dr.GetOrdinal("Operatore"));

                                utente.LivelloUtente = (DataType.Livello.LivelloUtente)dr.GetInt32(dr.GetOrdinal("IdLivello"));

                                listaUtenti.Add(utente);
                            }
                    }

                    cnn.Close();
                }
            }
            catch (Exception)
            {
                result = false;
                throw;
            }

            return result;
        }

        public static bool GetUserUtente(out DataType.Utente utente)
        {
            bool result = true;
            utente = null;

            try
            {
                using (SqlConnection cnn = new SqlConnection(ConnectionString))
                {
                    cnn.Open();

                    string sql = "SELECT u.*, l.Descrizione AS Livello FROM AnagraficaUtenti u LEFT JOIN Livelli l ON l.ID = u.IdLivello WHERE u.IdLivello = 3";

                    using (SqlCommand cmd = new SqlCommand(sql, cnn))
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader())
                            if (dr.Read())
                            {
                                utente = new DataType.Utente();

                                if (!dr.IsDBNull(dr.GetOrdinal("ID"))) utente.ID = dr.GetInt32(dr.GetOrdinal("ID"));
                                if (!dr.IsDBNull(dr.GetOrdinal("Username"))) utente.Username = dr.GetString(dr.GetOrdinal("Username"));
                                if (!dr.IsDBNull(dr.GetOrdinal("Password"))) utente.Password = dr.GetString(dr.GetOrdinal("Password"));
                                if (!dr.IsDBNull(dr.GetOrdinal("Operatore"))) utente.Operatore = dr.GetString(dr.GetOrdinal("Operatore"));

                                utente.LivelloUtente = (DataType.Livello.LivelloUtente)dr.GetInt32(dr.GetOrdinal("IdLivello"));

                                //listaUtenti.Add(utente);
                            }
                    }

                    cnn.Close();
                }
            }
            catch (Exception)
            {
                result = false;
                throw;
            }

            return result;
        }

        public static DataTable GetAllLivelli()
        {
            DataTable result = null;

            try
            {
                using (SqlConnection cnn = new SqlConnection(ConnectionString))
                {
                    cnn.Open();

                    string sql = "SELECT * FROM Livelli";

                    using (SqlCommand cmd = new SqlCommand(sql, cnn))
                    {
                        result = new DataTable();

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                            da.Fill(result);
                    }

                    cnn.Close();
                }
            }
            catch (Exception)
            {
                result = null;
                throw;
            }

            return result;
        }

        public static bool InsertUser(string username, string password, string operatore, int livello)
        {
            bool result = true;

            try
            {
                using (SqlConnection cnn = new SqlConnection(ConnectionString))
                {
                    cnn.Open();

                    string sql = "INSERT INTO AnagraficaUtenti VALUES (@username, @password, @operatore, @idLivello)";

                    using (SqlCommand cmd = new SqlCommand(sql, cnn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);
                        cmd.Parameters.AddWithValue("@operatore", operatore);
                        cmd.Parameters.AddWithValue("@idLivello", livello);

                        result = cmd.ExecuteNonQuery() > 0;
                    }

                    cnn.Close();
                }
            }
            catch (Exception)
            {
                result = false;
                throw;
            }

            return result;
        }

        public static bool UpdateUser(int idUtente, string username, string password, string operatore, int livello)
        {
            bool result = true;

            try
            {
                using (SqlConnection cnn = new SqlConnection(ConnectionString))
                {
                    cnn.Open();

                    string sql = "UPDATE AnagraficaUtenti SET Username = @username, Password = @password, Operatore = @operatore, IdLivello = @idLivello WHERE ID = @id";

                    using (SqlCommand cmd = new SqlCommand(sql, cnn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);
                        cmd.Parameters.AddWithValue("@operatore", operatore);
                        cmd.Parameters.AddWithValue("@idLivello", livello);
                        cmd.Parameters.AddWithValue("@id", idUtente);

                        result = cmd.ExecuteNonQuery() > 0;
                    }

                    cnn.Close();
                }
            }
            catch (Exception)
            {
                result = false;
                throw;
            }

            return result;
        }

        public static bool DeleteUser(int idUtente)
        {
            bool result = true;

            try
            {
                using (SqlConnection cnn = new SqlConnection(ConnectionString))
                {
                    cnn.Open();

                    string sql = "DELETE FROM AnagraficaUtenti WHERE ID = @id";

                    using (SqlCommand cmd = new SqlCommand(sql, cnn))
                    {
                        cmd.Parameters.AddWithValue("@id", idUtente);

                        result = cmd.ExecuteNonQuery() > 0;
                    }

                    cnn.Close();
                }
            }
            catch (Exception)
            {
                result = false;
                throw;
            }

            return result;
        }

    }
}