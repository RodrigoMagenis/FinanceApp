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
            //this.CarregarGrafico();

            DateTime dataInicial = dtstart.Value.Date;
            DateTime dataFinal = dtend.Value.Date.AddDays(1); // adiciona um dia para contar no término dele

            if ((dataFinal - dataInicial).TotalMilliseconds > 0) //verifica se a data de fim é menor que a data de inicio
            {
                AssetSql sql = new AssetSql();
                SqlData cur = sql.getAssetPrices(idasset.Text, dtstart.Text, dtend.Text);

                if (cur.sqlData.Count() > 0)
                {
                    this.LoadAssetChart(cur);
                    this.LoadGrowthChart(cur);
                    this.LoadAccelerationChart(cur);
                    this.ShowReport(cur);
                }
                else
                {
                    MessageBox.Show("O sistema não possui cotações do ativo para o intervalo selecionado");
                }
            }
            else
            {
                MessageBox.Show("A data final não pode ser anterior a data inicial");
            }
        }

        public void LoadAssetChart(SqlData cur)
        {
            try
            {
                CalcFunctions calcFunctions = new CalcFunctions();
                String assetChartName = "Asset";
                assetPriceChart.Series.Clear();
                assetPriceChart.Series.Add(assetChartName);
                assetPriceChart.Series[assetChartName].ChartType = SeriesChartType.Line;
                assetPriceChart.Series[assetChartName].ChartArea = "ChartArea1";
                List<double> assetValues = new List<double>();
                foreach (var row in cur.sqlData)
                {
                    assetValues.Add(Convert.ToDouble(row[3]));
                }
                String linearTrendName = "Trend";
                assetPriceChart.Series.Add(linearTrendName);
                assetPriceChart.Series[linearTrendName].ChartType = SeriesChartType.Line;
                assetPriceChart.Series[linearTrendName].ChartArea = "ChartArea1";
                var linearTrendValues = calcFunctions.LinearTrend(assetValues);

                for (var i = 0; i < cur.sqlData.Count(); i++)
                {
                    Double value = Convert.ToDouble(cur.sqlData[i][3]);
                    String date = Convert.ToDateTime(cur.sqlData[i][2]).ToShortDateString();

                    /*Série de preço*/
                    assetPriceChart.Series[assetChartName].Points.AddXY(date, value);

                    /* Série de tendência */
                    if (i < linearTrendValues.Count())
                    {
                        assetPriceChart.Series[linearTrendName].Points.AddXY(date, linearTrendValues[i]);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Ocorreu uma falha grave ao gerar o gráfico de ativo, por favor comunique o administrador");
            }
        }

        public void LoadGrowthChart(SqlData cur)
        {
            try
            {
                String growthChartName = "Growth";
                growthChart.Series.Clear();
                growthChart.Series.Add(growthChartName);
                growthChart.Series[growthChartName].ChartType = SeriesChartType.Line;
                growthChart.Series[growthChartName].ChartArea = "ChartArea1";

                for (var i = 1; i < cur.sqlData.Count(); i++)
                {
                    Double value = Convert.ToDouble(cur.sqlData[i][3]);
                    Double aux = Convert.ToDouble(cur.sqlData[i-1][3]);
                    String date = Convert.ToDateTime(cur.sqlData[i][2]).ToShortDateString();

                    growthChart.Series[growthChartName].Points.AddXY(date, (value - aux));
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Ocorreu uma falha grave ao gerar o gráfico de crescimento, por favor comunique o administrador");
            }
        }

        public void LoadAccelerationChart(SqlData cur)
        {
            try
            {
                String accelerationChartName = "Acceleration";
                accelerationChart.Series.Clear();
                accelerationChart.Series.Add(accelerationChartName);
                accelerationChart.Series[accelerationChartName].ChartType = SeriesChartType.Line;
                accelerationChart.Series[accelerationChartName].ChartArea = "ChartArea1";

                for (var i = 2; i < cur.sqlData.Count(); i++)
                {
                    Double value = Convert.ToDouble(cur.sqlData[i][3]);
                    Double aux1 = Convert.ToDouble(cur.sqlData[i-1][3]);
                    Double aux2 = Convert.ToDouble(cur.sqlData[i-2][3]);
                    String date = Convert.ToDateTime(cur.sqlData[i][2]).ToShortDateString();
                    accelerationChart.Series[accelerationChartName].Points.AddXY(date, ((value - aux1) - (aux1 - aux2)));
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Ocorreu uma falha grave ao gerar o gráfico de aceleração, por favor comunique o administrador");
            }
        }

        public void ShowReport(SqlData cur)
        {
            Double primeirovalor = Convert.ToDouble(cur.sqlData[0][3]);
            Double ultimovalor = Convert.ToDouble(cur.sqlData[cur.sqlData.Count()-1][3]);
            Double penultimovalor = Convert.ToDouble(cur.sqlData[cur.sqlData.Count()-2][3]);
            Double media = 0;
            for (var i = 0; i < cur.sqlData.Count(); i++)
            {
                media += Convert.ToDouble(cur.sqlData[i][3]);
            }
            media = media / cur.sqlData.Count();

            if (primeirovalor <= ultimovalor && penultimovalor <= ultimovalor && ultimovalor <= media)
            {
                System.Windows.Forms.MessageBox.Show($"Investimento Excelente, o Valor está subindo e tende a Subir, com o preço do ativo em Ascenção");
            }

            else if (primeirovalor <= ultimovalor && penultimovalor <= ultimovalor && ultimovalor >= media)
            {
                System.Windows.Forms.MessageBox.Show($"Investimento Bom, o Valor está subindo mas tende a Cair, mas o preço do ativo está em Ascenção");
            }

            else if (primeirovalor <= ultimovalor && penultimovalor >= ultimovalor && ultimovalor >= media)
            {
                System.Windows.Forms.MessageBox.Show($"Investimento Ruim, o Valor está caindo e tende a Cair, mas o preço do ativo está em Ascenção");
            }

            else if (primeirovalor <= ultimovalor && penultimovalor >= ultimovalor && ultimovalor <= media)
            {
                System.Windows.Forms.MessageBox.Show($"Investimento Ruim, o Valor está caindo mas tende a Subir, e o preço do ativo está em Ascenção");
            }

            else if (primeirovalor >= ultimovalor && penultimovalor >= ultimovalor && ultimovalor >= media)
            {
                System.Windows.Forms.MessageBox.Show($"Investimento Pessimo, o Valor está caindo e tende a Cair, e o preço do ativo está em Declive");
            }

            else if (primeirovalor >= ultimovalor && penultimovalor <= ultimovalor && ultimovalor >= media)
            {
                System.Windows.Forms.MessageBox.Show($"Investimento Ruim, o Valor está subindo mas tende a Cair, e o preço do ativo está em Declive");
            }

            else if (primeirovalor >= ultimovalor && penultimovalor <= ultimovalor && ultimovalor <= media)
            {
                System.Windows.Forms.MessageBox.Show($"Investimento Moderado, o Valor tende a Subir, mas o preço do ativo está em Declive");
            }

            else if (primeirovalor >= ultimovalor && penultimovalor >= ultimovalor && ultimovalor <= media)
            {
                System.Windows.Forms.MessageBox.Show($"Investimento Moderado, o Valor está caindo mas tende a Subir, e o preço do ativo está em Declive");
            }
        }
    }
}
