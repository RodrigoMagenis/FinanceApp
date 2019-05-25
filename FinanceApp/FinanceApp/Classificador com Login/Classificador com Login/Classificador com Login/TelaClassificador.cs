using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Classificador_com_Login
{
    public partial class TelaClassificador : Form
    {
        public TelaClassificador()
        {
            InitializeComponent();
        }

        OpenFileDialog openfiledialog = new OpenFileDialog();

        private void BtSelecionar_Click(object sender, EventArgs e)
        {
            openfiledialog.ShowDialog();
        }

        private void BtVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtClassificar_Click(object sender, EventArgs e)
        {
            List<Mercadoria> ListadeMercadoria = new List<Mercadoria>();

            float valormaximo = 0, valorminimo = float.MaxValue, primeirovalor = 0, ultimovalor = 0, penultimovalor = 0;
            float pontomedio = 0, dispersao = 0, media = 0, mediaparcial = 0; ;
            string Local;
            
            StreamReader streamReader = new StreamReader($@"{openfiledialog.FileName}");
            string linha = "";
            while (true)
            {
                linha = streamReader.ReadLine();
                if (linha != null)
                {
                    string[] DadosColetados = linha.Split(',');
                    ListadeMercadoria.Add(new Mercadoria
                    {
                        Valor = Convert.ToSingle(DadosColetados[0]),
                    });
                }
                else
                {
                    break;
                }
            }

            streamReader.Close();

            media = 0;

            for (int i = 0; i < ListadeMercadoria.Count; i++)
            {
                Mercadoria mercadoria = ListadeMercadoria[i];

                media += ListadeMercadoria[i].Valor;
                mediaparcial = media / (i + 1);

                ChartMercadoria.Series["Valor"].Points.AddXY(i, mercadoria.Valor);
                ChartMercadoria.Series["Media"].Points.AddXY(i, mediaparcial);

                if (valormaximo < mercadoria.Valor)
                {
                    valormaximo = mercadoria.Valor;
                }

                if(mercadoria.Valor < valorminimo)
                {
                    valorminimo = mercadoria.Valor;
                }

                if(i == 0)
                {
                    primeirovalor = mercadoria.Valor;
                }

                if(i == ListadeMercadoria.Count-1)
                {
                    ultimovalor = mercadoria.Valor;
                }

                if (i == ListadeMercadoria.Count - 2)
                {
                    penultimovalor = mercadoria.Valor;
                }
            }
            pontomedio = (valormaximo + valorminimo) / 2;

            dispersao = valormaximo - pontomedio;

            media = media / ListadeMercadoria.Count;

            if(primeirovalor < ultimovalor && penultimovalor < ultimovalor && ultimovalor < media)
            {
                System.Windows.Forms.MessageBox.Show($"Investimento Excelente, o Valor está subindo e tende a Subir, com Mercadoria em Ascenção, e a dispersão foi:{dispersao}");
            }

            if (primeirovalor < ultimovalor && penultimovalor < ultimovalor && ultimovalor > media)
            {
                System.Windows.Forms.MessageBox.Show($"Investimento Bom, o Valor está subindo mas tende a Cair, mas a Mercadoria está em Ascenção, e a dispersão foi:{dispersao}");
            }

            if (primeirovalor < ultimovalor && penultimovalor > ultimovalor && ultimovalor > media)
            {
                System.Windows.Forms.MessageBox.Show($"Investimento Ruim, o Valor está caindo e tende a Cair, mas a Mercadoria está em Ascenção, e a dispersão foi:{dispersao}");
            }

            if (primeirovalor < ultimovalor && penultimovalor > ultimovalor && ultimovalor < media)
            {
                System.Windows.Forms.MessageBox.Show($"Investimento Ruim, o Valor está caindo mas tende a Subir, e a Mercadoria está em Ascenção, a dispersão foi:{dispersao}");
            }

            if (primeirovalor > ultimovalor && penultimovalor > ultimovalor && ultimovalor > media)
            {
                System.Windows.Forms.MessageBox.Show($"Investimento Pessimo, o Valor está caindo e tende a Cair, e a Mercadoria está em Declive, e a dispersão foi:{dispersao}");
            }

            if (primeirovalor > ultimovalor && penultimovalor < ultimovalor && ultimovalor > media)
            {
                System.Windows.Forms.MessageBox.Show($"Investimento Ruim, o Valor está subindo mas tende a Cair, e a Mercadoria está em Declive, e a dispersão foi:{dispersao}");
            }

            if (primeirovalor > ultimovalor && penultimovalor < ultimovalor && ultimovalor < media)
            {
                System.Windows.Forms.MessageBox.Show($"Investimento Moderado, o Valor tende a Subir, mas a Mercadoria está em Declive, e a dispersão foi:{dispersao}");
            }

            if (primeirovalor > ultimovalor && penultimovalor > ultimovalor && ultimovalor < media)
            {
                System.Windows.Forms.MessageBox.Show($"Investimento Moderado, o Valor está caindo mas tende a Subir, e a Mercadoria está em Declive, e a dispersão foi:{dispersao}");
            }
        }

        private void TelaClassificador_Load(object sender, EventArgs e)
        {
            openfiledialog.Filter = "Text Files (.txt)| *.txt";
        }
    }
}
