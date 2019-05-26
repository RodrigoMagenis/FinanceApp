using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApp
{
    public class AssetSql
    {
        public SqlData getAssetPrices(string idasset, string dtstart, string dtend)
        {
            DatabaseConnection conn = new DatabaseConnection();

            String sql = $"SELECT ASSET.CDCOMPANY, " +
                         $"ASSET.CDNEGOCIATION, " +
                         $"ASPRICE.DTPRICE, " +
                         $"ASPRICE.VLAVG " +
                         $"FROM ASSET ASSET " +
                         $"INNER JOIN ASSETPRICE ASPRICE ON (ASPRICE.CDCOMPANY = ASSET.CDCOMPANY) " +
                         $"WHERE ASSET.CDNEGOCIATION = '{idasset}' " +
                                $"AND ASPRICE.DTPRICE >= '{dtstart}' " +
                                $"AND ASPRICE.DTPRICE <= '{dtend}' " +
                        $"ORDER BY ASPRICE.DTPRICE";
            return conn.Execute(sql);
        }
        
    }
}
