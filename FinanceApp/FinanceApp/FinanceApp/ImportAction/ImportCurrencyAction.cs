using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApp.ImportAction
{
    class ImportCurrencyAction : ImportAction
    {
        public Boolean ImportCurrencyPrice()
        {
            base.ShowImportationMenu();
            base.ReadFile();
            base.InsertInDatabase();
            return true;
        }

        protected override bool AfterDatabaseInsert()
        {
            Console.Clear();
            Console.WriteLine("Importação terminada! ");
            Console.WriteLine("Horário de inicio: " + base.TimeStart.ToString());
            Console.WriteLine("Horário de término: " + DateTime.Now.ToString());
            Console.ReadKey();
            return true;
        }

        protected override void DatabaseInsert(string[] data)
        {
            int cdcurrency = 0; /* C# acha que é esperto - Unsigned var */
            int cdprice;
            bool valid;
            do
            {
                /*Pesquisa pelo id da moeda
                 Retorna o campo cdcurrency*/
                var cur1 = base.conn.Execute($" SELECT CDCURRENCY FROM CURRENCY WHERE IDCURRENCY = '{data[0]}'; ");

                /* Se a moeda estiver cadastrada no banco de dados
                 * Obtém o código da moeda */
                if (cur1.sqlData.Count > 0)
                {
                    cdcurrency = Convert.ToInt32(cur1.sqlData[0][0]);
                    valid = true;
                }

                /* Se não pausa a operação para realizar a inserção manual no banco */
                else
                {
                    Console.Clear();
                    Console.WriteLine($"Moeda {data[0]} não cadastrada no banco");
                    Console.ReadKey();
                    valid = false;
                }
            } while ( !valid );

            /* Obtem o cdprice da ultima importação de cotação de moeda */
            var cur2 = this.conn.Execute(" SELECT MAX( CDPRICE ) FROM CURRENCYPRICE; ");
            /*Se não tiver nenhum registro insere valor 1*/
            if (cur2.sqlData[0][0] == "")
            {
                cdprice = -2147483648;
            }
            /*Pega o maior registro e adiciona 1*/
            else
            {
                cdprice = Convert.ToInt32(cur2.sqlData[0][0]);
                cdprice += 1; /* Novo maior registro */
            }

            string date = this.commons.FormatDateToDatabase(data[1]);

            /* Verifica existe um registro de cotação da moeda no dia */
            var cur3 = this.conn.Execute($" SELECT COUNT( CDPRICE ) FROM CURRENCYPRICE WHERE CDCURRENCY = '{cdcurrency}' AND DTPRICE = '{date}'; ");
            if (Convert.ToInt32( cur3.sqlData[0][0] ) == 0)
            {
                /*Insere o novo registro na tabela PRICE*/
                this.conn.Execute($" INSERT INTO CURRENCYPRICE ( CDPRICE, CDCURRENCY, DTPRICE, VLPRICE ) VALUES( '{cdprice}', '{cdcurrency}', '{date}', '{this.commons.FormatNumberToDatabase(data[2])}' ); ");
                base.CountNewRow();
            }
        }
    }
}
