using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Janus
{
    class ConnectionClass : IDisposable
    {
        public SqlConnection sqlConn;

        public ConnectionClass()
        {
            sqlConn = openSqlConn();
            if (sqlConn == null)
            {
                sqlConn.Dispose();
            }
        }

        private SqlConnection openSqlConn()
        {
            SqlConnection conn = null;
            string server = "DESKTOP-MRTU3J5";
            string db = "LocalTest";
            string cnnString = string.Format("Server={0};Database={1};Trusted_Connection=SSPI;", server, db);
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = cnnString;
                conn.Open();
                return conn;
            }
            catch
            {
                conn.Dispose();
                return null;
            }
        }

        public void Dispose()
        {
            if (sqlConn != null)
            {
                sqlConn.Dispose();
            }
        }
    }
}
