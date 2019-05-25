using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace FinanceApp
{
    public class DatabaseConnection
    {

        public SqlData Execute(String query) {
            var conn = new SqlConnection(GetConnString());
            var sqlCommand = new SqlCommand(query, conn);
            SqlDataReader reader;
            var sqlData = new SqlData();

            try
            {
                conn.Open();
                reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    var sqlRowData = new List<String>();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        sqlRowData.Add(reader[i].ToString());
                    }
                    sqlData.sqlData.Add(sqlRowData);
                }
                sqlData.status = true;
                reader.Close();
            }
            catch (Exception e)
            {
                sqlData.status = false;
                sqlData.error = e;
                //throw e;
            }
            finally
            {
                conn.Close();
            }
            return sqlData;
        }

        string GetConnString()
        {
            return "Data Source=(local); Initial Catalog=db_financeApp; Integrated Security=SSPI;";
        }
    }

    public class SqlData
    {
        public List<List<String>> sqlData;
        public Boolean status;
        public Exception error;

        public SqlData()
        {
            sqlData = new List<List<String>>();
        }
    }
}
