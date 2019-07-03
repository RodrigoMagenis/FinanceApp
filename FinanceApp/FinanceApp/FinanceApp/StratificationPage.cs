using System;
using System.Collections.Generic;
using System.Linq;
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
            DateTime dataInicial = dtstart.Value.Date;
            DateTime dataFinal = dtend.Value.Date.AddDays(1); // adiciona um dia para contar no término dele

            if ((dataFinal - dataInicial).TotalMilliseconds > 0) //verifica se a data de fim é menor que a data de inicio
            {
                AssetSql sql = new AssetSql();
                List<List<String>> data = sql.getAssetPrices(idasset.Text, dtstart.Text, dtend.Text).sqlData;

                if (data.Count() > 0)
                {
                    List<List<string>> chartPoints = this.SetPointsToChart(data, 25);
                    this.LoadAssetChart(chartPoints);
                    this.LoadGrowthChart(chartPoints);
                    this.LoadAccelerationChart(chartPoints);
                    this.ShowReport(chartPoints);
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

        private List<List<string>> SetPointsToChart(List<List<string>> data, int qtPoints)
        {
            int sampleSize = Convert.ToInt32(data.Count() / qtPoints);
            double mean = 0;
            int count = 0;
            List<List<string>> Serie = new List<List<string>>();
            for (var i = 0; i < data.Count(); i++)
            {
                count++;
                mean += Convert.ToDouble(data[i][3]);
                if((i+1) % sampleSize == 0 )
                {
                    //adiciona o valor médio
                    //adiciona a data
                    Serie.Add(new List<string> { Convert.ToString(mean / count), data[i][2] });
                    count = 0;
                    mean = 0;
                }
            }

            //Adiciona o último ponto remanecente
            if(count != 0)
            {
                Serie.Add(new List<string> {Convert.ToString(mean / count), data[data.Count()-1][2]});
            }

            return Serie;
        }

        public void LoadAssetChart(List<List<String>> data)
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
                foreach (var row in data)
                {
                    assetValues.Add(Convert.ToDouble(row[0]));
                }
                String linearTrendName = "Trend";
                assetPriceChart.Series.Add(linearTrendName);
                assetPriceChart.Series[linearTrendName].ChartType = SeriesChartType.Line;
                assetPriceChart.Series[linearTrendName].ChartArea = "ChartArea1";
                var linearTrendValues = calcFunctions.LinearTrend(assetValues);

                for (var i = 0; i < data.Count(); i++)
                {
                    Double value = Convert.ToDouble(data[i][0]);
                    String date = Convert.ToDateTime(data[i][1]).ToShortDateString();

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

        public void LoadGrowthChart(List<List<String>> data)
        {
            try
            {
                String growthChartName = "Growth";
                growthChart.Series.Clear();
                growthChart.Series.Add(growthChartName);
                growthChart.Series[growthChartName].ChartType = SeriesChartType.Line;
                growthChart.Series[growthChartName].ChartArea = "ChartArea1";

                //gera pontos no gráfico por semana
                //double mean = 0;
                //double aux = 0;
                //bool hasAux = false;
                List<double> ChartPointsSeries = new List<double>();
                for (var i = 1/*0*/; i < data.Count(); i++)
                {
                    String date = Convert.ToDateTime(data[i][1]).ToShortDateString();

                    //mean += Convert.ToDouble(data[i][3]);
                    //if( (i+1) % 5 == 0)
                    //{
                    //    mean = mean / 5;
                    //    if (hasAux)
                    //    {
                    //        ChartPointsSeries.Add(mean - aux);
                    //    }
                    //    aux = mean;
                    //    mean = 0;
                    //    hasAux = true;
                    //}


                    Double value = Convert.ToDouble(data[i][0]);
                    Double aux = Convert.ToDouble(data[i-1][0]);
                    

                    growthChart.Series[growthChartName].Points.AddXY(date, (value - aux));
                }

                for (var i = 0; i < ChartPointsSeries.Count(); i++)
                {
                    growthChart.Series[growthChartName].Points.AddXY((i+1), ChartPointsSeries[i]);
                }


            }
            catch (Exception e)
            {
                MessageBox.Show("Ocorreu uma falha grave ao gerar o gráfico de crescimento, por favor comunique o administrador");
            }
        }

        public void LoadAccelerationChart(List<List<String>> data)
        {
            try
            {
                String accelerationChartName = "Acceleration";
                accelerationChart.Series.Clear();
                accelerationChart.Series.Add(accelerationChartName);
                accelerationChart.Series[accelerationChartName].ChartType = SeriesChartType.Line;
                accelerationChart.Series[accelerationChartName].ChartArea = "ChartArea1";

                for (var i = 2; i < data.Count(); i++)
                {
                    Double value = Convert.ToDouble(data[i][0]);
                    Double aux1 = Convert.ToDouble(data[i-1][0]);
                    Double aux2 = Convert.ToDouble(data[i-2][0]);
                    String date = Convert.ToDateTime(data[i][1]).ToShortDateString();
                    accelerationChart.Series[accelerationChartName].Points.AddXY(date, ((value - aux1) - (aux1 - aux2)));
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Ocorreu uma falha grave ao gerar o gráfico de aceleração, por favor comunique o administrador");
            }
        }

        public void ShowReport(List<List<String>> data)
        {
            Double primeirovalor = Convert.ToDouble(data[0][0]);
            Double ultimovalor = Convert.ToDouble(data[data.Count()-1][0]);
            Double penultimovalor = Convert.ToDouble(data[data.Count()-2][0]);
            Double media = 0;
            for (var i = 0; i < data.Count(); i++)
            {
                media += Convert.ToDouble(data[i][0]);
            }
            media = media / data.Count();

            if (primeirovalor <= ultimovalor && penultimovalor <= ultimovalor && ultimovalor <= media)
            {
                MessageBox.Show($"Investimento Excelente, o Valor está subindo e tende a Subir, com o preço do ativo em Ascenção");
            }

            else if (primeirovalor <= ultimovalor && penultimovalor <= ultimovalor && ultimovalor >= media)
            {
                MessageBox.Show($"Investimento Bom, o Valor está subindo mas tende a Cair, mas o preço do ativo está em Ascenção");
            }

            else if (primeirovalor <= ultimovalor && penultimovalor >= ultimovalor && ultimovalor >= media)
            {
                MessageBox.Show($"Investimento Ruim, o Valor está caindo e tende a Cair, mas o preço do ativo está em Ascenção");
            }

            else if (primeirovalor <= ultimovalor && penultimovalor >= ultimovalor && ultimovalor <= media)
            {
                MessageBox.Show($"Investimento Ruim, o Valor está caindo mas tende a Subir, e o preço do ativo está em Ascenção");
            }

            else if (primeirovalor >= ultimovalor && penultimovalor >= ultimovalor && ultimovalor >= media)
            {
                MessageBox.Show($"Investimento Pessimo, o Valor está caindo e tende a Cair, e o preço do ativo está em Declive");
            }

            else if (primeirovalor >= ultimovalor && penultimovalor <= ultimovalor && ultimovalor >= media)
            {
                MessageBox.Show($"Investimento Ruim, o Valor está subindo mas tende a Cair, e o preço do ativo está em Declive");
            }

            else if (primeirovalor >= ultimovalor && penultimovalor <= ultimovalor && ultimovalor <= media)
            {
                MessageBox.Show($"Investimento Moderado, o Valor tende a Subir, mas o preço do ativo está em Declive");
            }

            else if (primeirovalor >= ultimovalor && penultimovalor >= ultimovalor && ultimovalor <= media)
            {
                MessageBox.Show($"Investimento Moderado, o Valor está caindo mas tende a Subir, e o preço do ativo está em Declive");
            }
        }
    }
}
