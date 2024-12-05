using ParticleMotion.Views;
using System.Windows;

namespace ParticleMotion
{
    /// <summary>
    /// Classe principal da aplicação ParticleMotion.
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Método chamado quando a aplicação é iniciada.
        /// </summary>
        /// <param name="e">Argumentos do evento de inicialização.</param>
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}