namespace ParticleMotion.Models
{
    /// <summary>
    /// Representa uma entrada de log para o movimento de uma partícula.
    /// </summary>
    public class LogEntry
    {
        /// <summary>
        /// Obtém ou define a condição de atrito para esta entrada de log.
        /// </summary>
        public string AtritoCondicao { get; set; }

        /// <summary>
        /// Obtém ou define a força aplicada à partícula em Newtons.
        /// </summary>
        public int Forca { get; set; }

        /// <summary>
        /// Obtém ou define a massa da partícula em quilogramas.
        /// </summary>
        public int Massa { get; set; }

        /// <summary>
        /// Obtém ou define a lista de tempos registrados para o movimento da partícula.
        /// </summary>
        public List<double> Tempos { get; set; } = new List<double>();

        /// <summary>
        /// Obtém ou define a lista de posições registradas para o movimento da partícula.
        /// </summary>
        public List<double> Posicoes { get; set; } = new List<double>();

        /// <summary>
        /// Obtém ou define a lista de velocidades registradas para o movimento da partícula.
        /// </summary>
        public List<double> Velocidades { get; set; } = new List<double>();
    }
}