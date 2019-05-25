using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApp.ImportAction
{
    public class ImportAssetAction : ImportAction
    {
        public Boolean ImportAssetPrice()
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
            int cdcompany;
            int cdcurrency;
            int cdprice;
            /*Pesquisa pelo código de negociação da bolsa para ver se ele existe
             Retorna o campo cdcompany respectivo ao código de negociação*/
            var cur1 = base.conn.Execute(String.Format(" SELECT CDCOMPANY FROM ASSET WHERE CDNEGOCIATION = '{0}'; ", data[3]));

            /*Se o código de negociação está presente no banco apenas associar cdcompany no novo registro de cotação*/
            if (cur1.sqlData.Count > 0)
            {
                cdcompany = Convert.ToInt16(cur1.sqlData[0][0]);
            }
            /* Se não ele pega o maior valor de cdcompany e acrecenta 1 e
             * Cria um novo registro de código de negociação na tabela ASSET
             */
            else
            {
                var cur2 = this.conn.Execute(" SELECT MAX( CDCOMPANY) FROM ASSET; ");
                /*Se não tiver nenhum registro insere valor 1*/
                if (cur2.sqlData[0][0] == "")
                {
                    cdcompany = -32768;
                }
                /*Pega o maior registro e adiciona 1*/
                else
                {
                    cdcompany = Convert.ToInt16(cur2.sqlData[0][0]);
                    cdcompany += 1; /* Novo maior registro */
                }

                /*Insere o novo registro na tabela ASSET*/
                this.conn.Execute(String.Format(" INSERT INTO ASSET ( CDCOMPANY, CDNEGOCIATION ) VALUES( '{0}', '{1}' ); ", cdcompany, data[3]));

            }


            /*Pesquisa pela moeda utilizada na cotação da bolsa para ver se ele existe
            Retorna o campo cdcurrency respectivo ao nome da moeda*/
            var cur3 = this.conn.Execute(String.Format(" SELECT CDCURRENCY FROM CURRENCY WHERE SYMCURRENCY = '{0}'; ", data[8]));

            /*Se a moeda está presente no banco apenas associar cdcurrency no novo registro de cotação*/
            if (cur3.sqlData.Count > 0)
            {
                cdcurrency = Convert.ToInt16(cur3.sqlData[0][0]);
            }
            /* Se não ele pega o maior valor de cdccurrency e acrecenta 1 e
             * Cria um novo registro de código de negociação na tabela CURRENCY
             */
            else
            {
                var cur4 = this.conn.Execute(" SELECT MAX( CDCURRENCY) FROM CURRENCY; ");
                /*Se não tiver nenhum registro insere valor 1*/
                if (cur4.sqlData[0][0] == "")
                {
                    cdcurrency = -32768;
                }
                /*Pega o maior registro e adiciona 1*/
                else
                {
                    cdcurrency = Convert.ToInt16(cur4.sqlData[0][0]);
                    cdcurrency += 1; /* Novo maior registro */
                }

                /*Insere o novo registro na tabela CURRENCY*/
                this.conn.Execute(String.Format(" INSERT INTO CURRENCY ( CDCURRENCY, SYMCURRENCY ) VALUES( '{0}', '{1}' ); ", cdcurrency, data[8]));

            }

            /* Insere a nova cotação na tabela ASSETPRICE*/
            var cur5 = this.conn.Execute(" SELECT MAX( CDPRICE ) FROM ASSETPRICE; ");
            /*Se não tiver nenhum registro insere valor 1*/
            if (cur5.sqlData[0][0] == "")
            {
                cdprice = -2147483648;
            }
            /*Pega o maior registro e adiciona 1*/
            else
            {
                cdprice = Convert.ToInt32(cur5.sqlData[0][0]);
                cdprice += 1; /* Novo maior registro */
            }

            string date = this.commons.FormatDateToDatabase(data[1]);

            var hasExistPrice = false;
            /*Verifica se a cotação do respectivo código para a data já existe no banco de dados*/
            var cur6 = this.conn.Execute(String.Format(" SELECT COUNT( CDPRICE ) FROM ASSETPRICE WHERE CDCOMPANY = '{0}' AND DTPRICE = '{1}'; ", cdcompany, date));
            if (Convert.ToInt32(cur6.sqlData[0][0]) > 0)
            {
                //    Console.Clear();
                //    Console.WriteLine("Já existe uma cotação para esse código e data. Selecione uma alternativa:");
                //    Console.WriteLine("1. Ignorar cotação");
                //    Console.WriteLine("2. Sobrescrever cotação");
                //    Console.WriteLine("3. Ignorar todas as cotações repetidas");
                //    Console.WriteLine("4. Sobrescrever todas as cotações repetidas");
                //    Console.WriteLine("0. Cancelar ( Cancela a importação atual e as seguintes )");
                //    var option = Console.ReadLine();

                //    switch( option)
                //    {
                //        case "1":

                //            break;
                //    }
                hasExistPrice = true;
            }

            if (hasExistPrice == false)
            {
                /* Insere o novo registro na tabela ASSETPRICE */
                this.conn.Execute($" INSERT INTO ASSETPRICE ( CDPRICE, DTPRICE, CDCOMPANY, CDCURRENCY, VLOPEN, VLMAX, VLLOW, VLAVG, VLLAST, VLHIGHERBUY, VLHIGHERSELL, QTDAILYTRANS, QTTOTALTRANS, VLTOTALTITLE ) VALUES( '{cdprice}', '{date}', '{cdcompany}', '{cdcurrency}', '{this.FormatPriceFields(data[9])}', '{this.FormatPriceFields(data[10])}', '{this.FormatPriceFields(data[11])}', '{this.FormatPriceFields(data[12])}', '{this.FormatPriceFields(data[13])}', '{this.FormatPriceFields(data[14])}', '{this.FormatPriceFields(data[15])}', '{data[16]}', '{data[17]}', '{this.FormatPriceFields(data[18])}' ); ");
                base.CountNewRow();
            }

            if (base.RowsCount % 1000 == 0)
            {
                Console.Clear();
                Console.WriteLine("Gravando no banco de dados");
                Console.WriteLine("rows affecteds = " + base.RowsCount);
                Console.WriteLine("Horário de inicio = " + base.TimeStart.ToString());
            }
        }

        /**
         * Divide o número por cem a fim de adicionar duas casas após a vírgula
         * Ex: 1234 => 12,34
         */
        public Decimal FormatPriceFields(String num)
        {
            return Convert.ToUInt64(num) / 100;
        }
    }
}
