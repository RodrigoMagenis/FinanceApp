using FinanceApp.commons;
using FinanceApp.ImportAction;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinanceApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainPage());
            //Boolean exit = false;
            //int option = 0;
            //Boolean state = false;
            //do
            //{
            //    Console.Clear();
            //    Console.WriteLine("Menu principal");
            //    Console.WriteLine("1. Importar cota��es de ativos");
            //    Console.WriteLine("2. Importar cota��es de moedas");
            //    Console.WriteLine("3. Estratifica�ao");
            //    Console.WriteLine("0. Sair");
            //    try
            //    {
            //        option = Convert.ToInt32(Console.ReadLine());
            //        state = true;
            //    }
            //    catch
            //    {
            //        state = false;
            //    }
            //    Console.Clear();
            //    if (state)
            //    {
            //        switch (option)
            //        {
            //            case 1:/* Inserir novas cota��es */
            //                var assetAction = new ImportAssetAction();
            //                assetAction.ImportAssetPrice();
            //                break;
            //            case 2:
            //                var currencyAction = new ImportCurrencyAction();
            //                currencyAction.ImportCurrencyPrice();
            //                break;
            //            case 0:/* Sair */
            //                exit = true;
            //                break;
            //            default:
            //                Console.WriteLine("( Op��o inexistente! tente novamente )");
            //                break;
            //        }
            //    }
            //    else
            //    {
            //        Console.WriteLine("( Op��o inv�lida! tente novamente )");
            //    }
            //} while( exit == false );
        }
    }
}
