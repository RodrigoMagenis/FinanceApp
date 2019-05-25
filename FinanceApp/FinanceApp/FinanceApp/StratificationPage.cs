using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace FinanceApp
{
    public partial class StratificationPage : Form
    {
        public StratificationPage()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void StratificationPage_Load(object sender, EventArgs e)
        {
            dtstart.Format = DateTimePickerFormat.Custom;
            dtstart.CustomFormat = "yyyy-MM-dd";
            dtend.Format = DateTimePickerFormat.Custom;
            dtend.CustomFormat = "yyyy-MM-dd";
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {


            //assetPriceChart.Series.Clear();
            //assetPriceChart.Series.Add("price");
            //assetPriceChart.Series["price"].Points.Add();
            this.CarregarGrafico();
        }

        public void CarregarGrafico()
        {
            assetPriceChart.Series.Clear();
            assetPriceChart.ResetAutoValues();
            try
            {
                DateTime dataInicial = dtstart.Value.Date;
                DateTime dataFinal = dtend.Value.Date.AddDays(1); // adiciona um dia para contar no término dele
                if ((dataFinal - dataInicial).TotalMilliseconds > 0) //verifica se a data de fim é menor que a data de inicio
                {
                    // query

                    AssetSql sql = new AssetSql();
                    var cur = sql.getAssetPrices(idasset.Text, dtstart.Text, dtend.Text);

                    if (cur.sqlData.Count() > 0)
                    {
                        assetPriceChart.Series.Add(cur.sqlData[0][1]);
                        foreach (var row in cur.sqlData)
                        {
                            assetPriceChart.Series[row[1]].ChartType = SeriesChartType.Line;
                            assetPriceChart.Series[row[1]].Points.AddXY(Convert.ToDateTime(row[2]).ToShortDateString(), row[3]);
                            assetPriceChart.Series[row[1]].ChartArea = "ChartArea1";
                        }
                    }
                    else
                    {
                        MessageBox.Show("Nenhum produto foi produzido nesse intervalo de tempo");
                    }
                }
                else
                {
                    MessageBox.Show("A data final não pode ser anterior a data inicial");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Ocorreu uma falha grave, por favor comunique o administrador");
            }



        }
    }
}
