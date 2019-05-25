using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApp
{
    public class Authentication
    {
        DatabaseConnection conn;
        public Authentication()
        {
            conn = new DatabaseConnection();
        }
        public Boolean userAuthentication(String username, String userpw)
        {
            String sql = $"SELECT 1 FROM ADUSER WHERE IDUSER = '{username}' AND PWUSER = '{userpw}'";
            var response = conn.Execute(sql);

            return response.sqlData.Count() > 0 ? true : false;
        }
    }
}
