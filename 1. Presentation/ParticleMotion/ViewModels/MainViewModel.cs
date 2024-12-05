using System.ComponentModel;
using LiveCharts;
using LiveCharts.Wpf;
using ParticleMotion.Helpers;
using ParticleMotion.Services;

namespace ParticleMotion.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly ILogReaderService _logReaderService;
        public SeriesCollection SeriesCollection { get; private set; }
        public Axis XAxis { get; private set; }
        public Axis YAxis { get; private set; }

        public MainViewModel(ILogReaderService logReaderService)
        {
            _logReaderService = logReaderService;
            LoadData();
        }

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

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}