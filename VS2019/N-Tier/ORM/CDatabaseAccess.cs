using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Threading;

namespace ORM
{
	public class cDatabaseAccess
    {
        protected SqlConnection Connection;
        private string connectionString;
        private SqlTransaction cTrans;
        public cDatabaseAccess(string newConnectionString)
        {
            //in order to make sure that float format is properly converted as a string, force the "en-us" format number  
            CultureInfo enCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentCulture = enCulture;
            Thread.CurrentThread.CurrentUICulture = enCulture;

            connectionString = newConnectionString;
            Connection = new SqlConnection(connectionString);


        }
        public cDatabaseAccess(){}
        protected string ConnectionString
        {
            get
            {
                return connectionString;
            }
        }
        private SqlCommand BuildIntCommand(string storedProcName, IDataParameter[] parameters)
        {
            SqlCommand command = BuildQueryCommand(storedProcName, parameters);

            command.Parameters.Add(new SqlParameter("ReturnValue",
                SqlDbType.Int,
                4, /* Size */
                ParameterDirection.ReturnValue,
                false, /* is nullable */
                0, /* byte precision */
                0, /* byte scale */
                string.Empty,
                DataRowVersion.Default,
                null));

            return command;
        }
        private SqlCommand BuildQueryCommand(string storedProcName, IDataParameter[] parameters)
        {
            SqlCommand command = new SqlCommand(storedProcName, Connection);
            command.CommandType = CommandType.StoredProcedure;

            foreach (SqlParameter parameter in parameters)
            {
                command.Parameters.Add(parameter);
            }

            return command;

        }
        public int RunProcedure(string storedProcName, IDataParameter[] parameters, out int rowsAffected)
        {
            int result = 0;

            try
            {

                if (Connection.State == ConnectionState.Closed)
                    Connection.Open();

                SqlCommand command = BuildIntCommand(storedProcName, parameters);
                command.CommandTimeout = 1800;
                rowsAffected = command.ExecuteNonQuery();
                result = (int)command.Parameters["ReturnValue"].Value;

            }
            catch (Exception e)
            {
                string messgae = e.ToString();
                throw;
            }
            finally
            {
                if (Connection != null && Connection.State == ConnectionState.Open)
                    Connection.Close();
            }

            return result;
        }
                
        public void OpenConnection()
        {
            Connection.Open();
            cTrans = Connection.BeginTransaction(IsolationLevel.Snapshot);
        }
        public void CloseConnection()
        {
            Connection.Close();
        }
        public DataSet RunProcedure(string storedProcName, IDataParameter[] parameters, string tableName)
        {
            Exception ex = null;
            DataSet dataSet = new DataSet();
            try
            {
                Connection.Open();
                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.SelectCommand = BuildQueryCommand(storedProcName, parameters);
                sqlDA.SelectCommand.CommandTimeout = 3600;
                sqlDA.Fill(dataSet, tableName);
            }
            catch (Exception e)
            {
                ex = e;
            }
            finally
            {
                Connection.Close();
            }

            if (ex != null)
                throw ex;

            return dataSet;
        }
        public void RunProcedure(string storedProcName, IDataParameter[] parameters, DataSet dataSet, string tableName)
        {
            Connection.Open();
            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = BuildIntCommand(storedProcName, parameters);
            sqlDA.Fill(dataSet, tableName);
            Connection.Close();
        }
    }

    public class cDatabaseConn
    {
        private string _sConnectionString;
        public string sConnectionString
        {
            get
            {
                return _sConnectionString;
            }


            set
            {
                _sConnectionString = sConnectionString;
                cDatabaseAccess dbo = new cDatabaseAccess(_sConnectionString);
            }

        }
        public cDatabaseAccess dbo;
        public cDatabaseConn(string newConnectionString)
        {

            _sConnectionString = newConnectionString;
            dbo = new cDatabaseAccess(newConnectionString);
        }
    }
}