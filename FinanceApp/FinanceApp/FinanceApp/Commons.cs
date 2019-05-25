using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApp
{
    public class Commons
    {
        /**
         * Adiciona 0 em números menores que 10
         * Ex: 9 => "09"
         */
        public String formatIntNumber( int num )
        {
            String result;
            if ( num < 10 )
            {
                result = "0" + num;
            }
            else
            {
                result = Convert.ToString(num);
            }
            return result;
        }

        /*Formata a data para o banco de dados ( YYYY/MM/DD ) */
        public string FormatDateToDatabase( string originalDate )
        {
            DateTime date = Convert.ToDateTime( originalDate );
            return String.Format("{0}-{1}-{2}", date.Year, this.formatIntNumber(date.Month), this.formatIntNumber(date.Day));
        }

        /* Formata números para o banco de dados */
        public string FormatNumberToDatabase( string value )
        {
            return value.Replace(".", "").Replace(",", ".");
        }
    }
}
