using LiveCharts;
using LiveCharts.Wpf;
using ParticleMotion.Models;
using System.Windows.Media;

namespace ParticleMotion.Helpers
{
    /// <summary>
    /// Fornece métodos auxiliares para criar e configurar gráficos usando a biblioteca LiveCharts.
    /// </summary>
    public static class ChartHelper
    {
        /// <summary>
        /// Cria uma coleção de séries para o gráfico com base em uma lista de entradas de log.
        /// </summary>
        /// <param name="logEntries">A lista de entradas de log contendo os dados para o gráfico.</param>
        /// <returns>Uma coleção de séries para o gráfico.</returns>
        public static SeriesCollection CreateSeriesCollection(List<LogEntry> logEntries)
        {
            var series = new SeriesCollection();
            var colors = new[] { Colors.Red, Colors.Blue, Colors.Green, Colors.Orange, Colors.Purple };
            int colorIndex = 0;

            foreach (var entry in logEntries)
            {
                var posicaoSeries = new LineSeries
                {
                    Title = $"Posição ({entry.AtritoCondicao}) - Força: {entry.Forca}N, Massa: {entry.Massa}kg",
                    Values = new ChartValues<double>(entry.Posicoes),
                    Stroke = new SolidColorBrush(colors[colorIndex]),
                    Fill = Brushes.Transparent,
                    PointGeometry = DefaultGeometries.Circle,
                    PointGeometrySize = 6
                };
                series.Add(posicaoSeries);

                var velocidadeSeries = new LineSeries
                {
                    Title = $"Velocidade ({entry.AtritoCondicao}) - Força: {entry.Forca}N, Massa: {entry.Massa}kg",
                    Values = new ChartValues<double>(entry.Velocidades),
                    Stroke = new SolidColorBrush(colors[(colorIndex + 1) % colors.Length]),
                    Fill = Brushes.Transparent,
                    PointGeometry = null,
                    LineSmoothness = 0
                };
                series.Add(velocidadeSeries);

                colorIndex = (colorIndex + 2) % colors.Length;
            }

            return series;
        }

        /// <summary>
        /// Cria e configura o eixo X do gráfico.
        /// </summary>
        /// <returns>Um objeto Axis configurado para o eixo X.</returns>
        public static Axis CreateXAxis()
        {
            return new Axis
            {
                Title = "Tempo (s)",
                LabelFormatter = value => value.ToString("F1")
            };
        }

        /// <summary>
        /// Cria e configura o eixo Y do gráfico.
        /// </summary>
        /// <returns>Um objeto Axis configurado para o eixo Y.</returns>
        public static Axis CreateYAxis()
        {
            return new Axis
            {
                Title = "Valores",
                LabelFormatter = value => value.ToString("F2")
            };
        }
    }
}