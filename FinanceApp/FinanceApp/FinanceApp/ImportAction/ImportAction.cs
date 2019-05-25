using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApp.ImportAction
{
    public abstract class ImportAction
    {
        protected DatabaseConnection conn;
        protected Commons commons;

        private string fileDirectory;    /* Diretório em que o arquivo csv se encontra */
        private string fileName;         /* Nome do arquivo csv a ser lido */
        private DateTime timeStart;      /* Define a data de início da importação */
        private UInt32 rowsCount = 0;    /* Registra a quantidade de linhas de cotação inseridas no banco de dados */
        private List<String[]> fileData; /* Matriz que armazena os dados contidos no arquivo csv */
        protected ImportAction()
        {
            conn = new DatabaseConnection();
            commons = new Commons();
        }

        /*Coleta o diretório e o nome do arquivo*/
        protected void ShowImportationMenu()
        {
            Console.Clear();
            Console.WriteLine("Importação de novas cotações");
            Console.WriteLine("qual é o diretório do arquivo CSV que deverá ser importado?");
            this.fileDirectory = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Importação de novas cotações");
            Console.WriteLine("qual é o nome do arquivo CSV que deverá ser importado?");
            this.fileName = Console.ReadLine();
            Console.Clear();
        }

        /*Faz a leitura do arquivo csv e retorna uma matriz com as informações*/
        private List<String[]> ReadCSVfile(String directory, String fileName)
        {
            using (StreamReader file = new StreamReader(directory + "\\" + fileName + ".csv"))
            {
                var data = new List<String[]>();
                var countRow = 1;
                Console.WriteLine("Lendo arquivo");
                while (!file.EndOfStream)
                {
                    string line = file.ReadLine();
                    string[] values = line.Split(';');
                    data.Add(values);
                    countRow++;
                }
                Console.Clear();
                Console.WriteLine("Leitura do arquivo csv '" + fileName + "' concluída!");
                Console.WriteLine("Número de linhas lidas: " + countRow);
                Console.ReadKey();
                Console.Clear();
                return data;
            }
        }

        /* Realiza a leitura do arquivo e guarda os valores */
        protected void ReadFile()
        {
            this.fileData = this.ReadCSVfile(this.FileDirectory, this.FileName);
        }

        /*Se ocorreu um erro registra no log a mensagem de erro*/
        protected void ShowErrorMessageIfExists(Boolean state, String message)
        {
            if (state)
            {
                Console.WriteLine(message);
            }
        }

        /* Insere as informações no banco de dados */
        protected bool InsertInDatabase()
        {
            this.BeforeDatabaseInsert();
            foreach (var data in this.fileData)
            {
                this.DatabaseInsert(data);
            }
            return this.AfterDatabaseInsert();
        }

        /* Método executado antes da inclusão no banco de dados */
        protected virtual void BeforeDatabaseInsert()
        {

        }

        /* Método responsável pela inclusão no banco de dados. Ele deve ser implementado na classe específica */
        protected abstract void DatabaseInsert(String[] data);

        /* Método executado depois da inclusão no banco de dados */
        protected virtual bool AfterDatabaseInsert()
        {
            return true;
        }

        /* Adiciona mais uma linha na contagem de linhas */
        protected void CountNewRow()
        {
            this.rowsCount += 1;
        }

        protected string FileDirectory { get => fileDirectory; set => fileDirectory = value; }
        protected string FileName { get => fileName; set => fileName = value; }
        protected DateTime TimeStart { get => timeStart; set => timeStart = value; }
        protected uint RowsCount { get => rowsCount; set => rowsCount = value; }
        protected List<string[]> FileData { get => fileData; set => fileData = value; }
    }
}
