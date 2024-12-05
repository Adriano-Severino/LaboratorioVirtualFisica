﻿using System.ComponentModel;
using LiveCharts;
using LiveCharts.Wpf;
using ParticleMotion.Helpers;
using ParticleMotion.Services;

namespace ParticleMotion.ViewModels
{
    /// <summary>
    /// ViewModel principal que gerencia a lógica de apresentação para a visualização dos dados de movimento de partículas.
    /// </summary>
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly ILogReaderService _logReaderService;

        /// <summary>
        /// Obtém a coleção de séries de dados para o gráfico.
        /// </summary>
        public SeriesCollection SeriesCollection { get; private set; }

        /// <summary>
        /// Obtém a configuração do eixo X do gráfico.
        /// </summary>
        public Axis XAxis { get; private set; }

        /// <summary>
        /// Obtém a configuração do eixo Y do gráfico.
        /// </summary>
        public Axis YAxis { get; private set; }

        /// <summary>
        /// Inicializa uma nova instância da classe MainViewModel.
        /// </summary>
        /// <param name="logReaderService">O serviço de leitura de logs a ser utilizado.</param>
        public MainViewModel(ILogReaderService logReaderService)
        {
            _logReaderService = logReaderService;
            LoadData();
        }

        /// <summary>
        /// Carrega os dados do arquivo de log e configura o gráfico.
        /// </summary>
        private void LoadData()
        {
            var logEntries = _logReaderService.ReadLogEntries("log.txt");
            SeriesCollection = ChartHelper.CreateSeriesCollection(logEntries);
            XAxis = ChartHelper.CreateXAxis();
            YAxis = ChartHelper.CreateYAxis();
            OnPropertyChanged(nameof(SeriesCollection));
            OnPropertyChanged(nameof(XAxis));
            OnPropertyChanged(nameof(YAxis));
        }

        /// <summary>
        /// Evento que é disparado quando uma propriedade é alterada.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Método protegido para disparar o evento PropertyChanged.
        /// </summary>
        /// <param name="propertyName">O nome da propriedade que foi alterada.</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}