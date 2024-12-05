using ParticleMotion.Services;
using ParticleMotion.ViewModels;
using System.Windows;

namespace ParticleMotion.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel(new LogReaderService());
        }
    }
}