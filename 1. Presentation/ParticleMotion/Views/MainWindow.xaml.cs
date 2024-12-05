using ParticleMotion.Services;
using ParticleMotion.ViewModels;
using System.Windows;

namespace ParticleMotion.Views
{
    /// <summary>
    /// Janela principal da aplicação ParticleMotion.
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Inicializa uma nova instância da classe MainWindow.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel(new LogReaderService());
        }
    }
}