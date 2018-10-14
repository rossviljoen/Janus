using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Janus
{
    class QueryHelper
    {
        private static SqlConnection sqlConn = Program.dbConn.sqlConn;

        public static List<DWTable> GetSPs()
        {
            string spQuery = String.Format("select SPECIFIC_NAME from {0}.information_schema.routines where routine_type = 'PROCEDURE'", sqlConn.Database) ;

            using (SqlCommand comm = new SqlCommand(spQuery, sqlConn))
            using (SqlDataReader reader = comm.ExecuteReader())
            {
                List<DWTable> spList = new List<DWTable>();
                while (reader.Read())
                {
                    DWTable table = new DWTable(reader.GetValue(0).ToString());
                    spList.Add(table);
                }
                return spList;
            }
        }

        //private static DWTable CreateSpDwTable(string inputName)
        //{
        //    string trimmedName = Regex.Replace(inputName, "(update_)", "");
        //    return new DWTable(inputName, trimmedName);
        //}

        public static List<string> GetSpDependencies(DWTable table)
        {
            string depQuery = String.Format("USE {0} SELECT DISTINCT referenced_entity_name FROM sys.dm_sql_referenced_entities('dbo.{1}', 'OBJECT') WHERE CHARINDEX(referenced_entity_name , '{1}') = 0", sqlConn.Database, table.strProc);

            using (SqlCommand comm = new SqlCommand(depQuery, sqlConn))
            using (SqlDataReader reader = comm.ExecuteReader())
            {
                List<string> depList = new List<string>();
                while (reader.Read())
                {
                    depList.Add(reader.GetValue(0).ToString());
                }
                return depList;
            }
        }
    }
}
