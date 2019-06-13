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
            //try
            //{
                CalcFunctions calcFunctions = new CalcFunctions();
                DateTime dataInicial = dtstart.Value.Date;
                DateTime dataFinal = dtend.Value.Date.AddDays(1); // adiciona um dia para contar no término dele
                if ((dataFinal - dataInicial).TotalMilliseconds > 0) //verifica se a data de fim é menor que a data de inicio
                {
                    // query

                    AssetSql sql = new AssetSql();
                    var cur = sql.getAssetPrices(idasset.Text, dtstart.Text, dtend.Text);

                    if (cur.sqlData.Count() > 0)
                    {
                        String assetChartName = "Asset";
                        Double auxValue = 0;
                        Boolean hasAuxValue = false;
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


                        String growthChartName = "Growth";
                        Double growthValue = 0;
                        Double auxGrowthValue = 0;
                        Boolean hasGrowthValue = false;
                        Boolean hasAuxGrowthValue = false;
                        growthChart.Series.Clear();
                        growthChart.Series.Add(growthChartName);
                        growthChart.Series[growthChartName].ChartType = SeriesChartType.Line;
                        growthChart.Series[growthChartName].ChartArea = "ChartArea1";

                        String accelerationChartName = "Acceleration";
                        Double accelerationValue;
                        accelerationChart.Series.Clear();
                        accelerationChart.Series.Add(accelerationChartName);
                        accelerationChart.Series[accelerationChartName].ChartType = SeriesChartType.Line;
                        accelerationChart.Series[accelerationChartName].ChartArea = "ChartArea1";
                        for(var i = 0; i < cur.sqlData.Count(); i++)
                        //foreach (var row in cur.sqlData)
                        {
                            Double value = Convert.ToDouble(cur.sqlData[i][3]);
                            String date = Convert.ToDateTime(cur.sqlData[i][2]).ToShortDateString();

                            /* Gráfico de tendência */
                            assetPriceChart.Series[assetChartName].Points.AddXY(date, value);
                            if (i < linearTrendValues.Count())
                            {
                                assetPriceChart.Series[linearTrendName].Points.AddXY(date, linearTrendValues[i]);
                            }

                            /* Gráfico de crescimento */
                            
                            if (hasAuxValue)
                            {
                                if (hasGrowthValue)
                                {
                                    auxGrowthValue = growthValue;
                                    hasAuxGrowthValue = true;
                                }
                                growthValue = value - auxValue;
                                hasGrowthValue = true;
                                growthChart.Series[growthChartName].Points.AddXY(date, (growthValue));
                            }
                            auxValue = value;
                            hasAuxValue = true;

                            /* Gráfico de aceleração */
                            if (hasAuxGrowthValue)
                            {
                                accelerationValue = auxGrowthValue - growthValue;
                                accelerationChart.Series[accelerationChartName].Points.AddXY(date, (accelerationValue));
                            }
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
            //}
            //catch (Exception e)
            //{
            //    MessageBox.Show("Ocorreu uma falha grave, por favor comunique o administrador");
            //}



        }
    }
}
