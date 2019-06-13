using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApp
{
    public class CalcFunctions
    {
        public List<double> LinearTrend(List<double> yValues/*, List<double> xValues = null*/)
        {
            List<double> xValues = new List<double>();
            List<double> trend = new List<double>();
            /* Popula os valores de y com números incrementais */
            for(var i = 1; i <= yValues.Count(); i++)
            {
                xValues.Add(i);
            }

            // encontrando a média do valor das variáveis independentes (eixo x) e dependentes (eixo y)
            double xMedia = 0;
            double yMedia = 0;
            for (int index = 0; index<xValues.Count(); index++)
            {
                xMedia += xValues[index];
                yMedia += yValues[index];
            }
            xMedia = xMedia / xValues.Count();
            yMedia = yMedia / yValues.Count();


            // codificando a fórmula para calcular a inclinação
            double dividendo = 0;
            double divisor = 0; 
            for (int index = 0; index<xValues.Count(); index++)
            {
                // a soma do produto da dispersão das variáveis independentes e dependentes = distâncias entre cada um dos valores e o valor médio daquele eixo = covariância de x e y
                dividendo += (xValues[index] - xMedia) * (yValues[index] - yMedia);
                // a soma do quadrado da dispersão das variáveis independentes (do eixo x)
                divisor += Math.Pow(xValues[index] - xMedia, 2);
            }
            // encontrando a inclinação
            double m = dividendo / divisor;

            // codificando a fórmula para encontrar o ponto onde a linha de tendência intercepta o eixo y
            // a média das variáveis dependentes, subtraido o produto da inclinação com a média das variáveis independentes
            double b = yMedia - m * xMedia;

            for (var i = 0; i < xValues.Count(); i++)
            {
                trend.Add((m * xValues[i]) + b);
            }
            return trend;
        }
    }
}
