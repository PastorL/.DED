using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace Data.Database
{
    public class Adapter
    {
        const string consKeyDefaultCnnString = "ConnStringLocal";
        public SqlConnection sqlConn;

        protected void OpenConnection()
        {
            string connString = ConfigurationManager.ConnectionStrings[consKeyDefaultCnnString].ConnectionString;
            sqlConn = new SqlConnection(connString);
            sqlConn.Open();
            //throw new Exception("Metodo no implementado");
        }

        protected void CloseConnection()
        {
            sqlConn.Close();
            sqlConn = null;
            //throw new Exception("Metodo no implementado");
        }

        /*protected SqlDataReader ExecuteReader(String commandText)
        {
            throw new Exception("Metodo no implementado");
        }*/
    }
}
