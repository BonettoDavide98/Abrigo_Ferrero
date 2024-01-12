using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QVLEGSCOG2362.DBL
{
    internal class DBLBaseManager : IDisposable
    {

        private readonly SqlConnection cnn = null;
        private readonly SqlTransaction transaction = null;

        public DBLBaseManager(string connectionString, bool useTransaction)
        {
            try
            {
                this.cnn = new SqlConnection(connectionString);
                this.cnn.Open();
                if (useTransaction)
                    this.transaction = cnn.BeginTransaction();
            }
            catch (Exception) { throw; }
        }

        public void CommitTransaction()
        {
            if (transaction != null)
                transaction.Commit();
        }

        public void RollbackTransaction()
        {
            if (transaction != null)
                transaction.Rollback();
        }

        public object ExecuteScalar(string query)
        {
            return ExecuteScalar(query, new List<SqlParameter>());
        }

        public object ExecuteScalar(string query, SqlParameter parameter)
        {
            return ExecuteScalar(query, new List<SqlParameter>() { parameter });
        }

        public object ExecuteScalar(string query, List<SqlParameter> parameters)
        {
            object ret = null;
            using (SqlCommand cmd = new SqlCommand(query, this.cnn))
            {
                if (this.transaction != null)
                    cmd.Transaction = this.transaction;

                cmd.CommandTimeout = 0;
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters.ToArray());
                }
                ret = cmd.ExecuteScalar();
            }
            return ret;
        }

        public int ExecuteNonQuery(string query)
        {
            List<SqlParameter> param = null;
            return ExecuteNonQuery(query, param);
        }

        public int ExecuteNonQuery(string query, SqlParameter parameter)
        {
            return this.ExecuteNonQuery(query, new List<SqlParameter>() { parameter });
        }

        public int ExecuteNonQuery(string query, List<SqlParameter> parameters)
        {
            int ret = -1;
            using (SqlCommand cmd = new SqlCommand(query, this.cnn))
            {
                if (this.transaction != null)
                    cmd.Transaction = this.transaction;

                cmd.CommandTimeout = 0;
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters.ToArray());
                }
                ret = cmd.ExecuteNonQuery();
            }
            return ret;
        }

        public DataTable FillDataTable(string query)
        {
            return FillDataTable(query, new List<SqlParameter>());
        }

        public DataTable FillDataTable(string query, SqlParameter parameter)
        {
            return FillDataTable(query, new List<SqlParameter>() { parameter });
        }

        public DataTable FillDataTable(string query, List<SqlParameter> parameters)
        {
            DataTable ret = new DataTable();
            using (SqlCommand cmd = new SqlCommand(query, this.cnn))
            {
                if (this.transaction != null)
                    cmd.Transaction = this.transaction;

                cmd.CommandTimeout = 0;
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters.ToArray());
                }
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(ret);
                }
            }
            return ret;
        }

        public DataSet FillDataSet(string query)
        {
            return this.FillDataSet(query, new List<SqlParameter>());
        }

        public DataSet FillDataSet(string query, SqlParameter parameter)
        {
            return this.FillDataSet(query, new List<SqlParameter>() { parameter });
        }

        public DataSet FillDataSet(string query, List<SqlParameter> parameters)
        {
            DataSet ret = new DataSet();
            using (SqlCommand cmd = new SqlCommand(query, this.cnn))
            {
                if (this.transaction != null)
                    cmd.Transaction = this.transaction;

                cmd.CommandTimeout = 0;
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters.ToArray());
                }
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(ret);
                }
            }
            return ret;
        }

        public List<T> GetFilledTArray<T>(string query, Func<IDataReader, T> foo)
        {
            return this.GetFilledTArray(query, new List<SqlParameter>(), foo);
        }

        public List<T> GetFilledTArray<T>(string query, SqlParameter parameter, Func<IDataReader, T> foo)
        {
            return this.GetFilledTArray(query, new List<SqlParameter>() { parameter }, foo);
        }

        public List<T> GetFilledTArray<T>(string query, List<SqlParameter> parameters, Func<IDataReader, T> foo)
        {
            List<T> ret = new List<T>();

            using (SqlCommand cmd = new SqlCommand(query, this.cnn))
            {
                if (this.transaction != null)
                    cmd.Transaction = this.transaction;

                cmd.CommandTimeout = 0;
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters.ToArray());
                }
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ret.Add(foo(reader));
                    }
                    reader.Close();
                }
            }

            return ret;
        }

        public T GetFilledT<T>(string query, Func<IDataReader, T> foo)
        {
            return this.GetFilledT(query, new List<SqlParameter>(), foo);
        }

        public T GetFilledT<T>(string query, SqlParameter parameter, Func<IDataReader, T> foo)
        {
            return this.GetFilledT(query, new List<SqlParameter>() { parameter }, foo);
        }

        public T GetFilledT<T>(string query, List<SqlParameter> parameters, Func<IDataReader, T> foo)
        {
            List<T> ret = GetFilledTArray(query, parameters, foo);
            return ret.Count == 1 ? ret[0] : default(T);
        }

        public void BulkCopy(string destinationTable, Dictionary<string, string> mapping, DataTable dt)
        {
            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(this.cnn, SqlBulkCopyOptions.KeepNulls, this.transaction))
            {
                bulkCopy.DestinationTableName = destinationTable;

                //Optional mappings. Not required, if your ‘Data Table’ column names match with ‘SQL Table’ column names
                foreach (var item in mapping)
                {
                    bulkCopy.ColumnMappings.Add(item.Key, item.Value);
                }

                bulkCopy.WriteToServer(dt);
            }
        }

        public void Dispose()
        {
            try
            {
                if (this.cnn != null && this.cnn.State != ConnectionState.Closed)
                    this.cnn.Close();
            }
            catch (Exception) { throw; }
        }

    }
}
