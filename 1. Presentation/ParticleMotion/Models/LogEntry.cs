namespace ParticleMotion.Models
{
    public class LogEntry
    {
        public string AtritoCondicao { get; set; }
        public int Forca { get; set; }
        public int Massa { get; set; }
        public List<double> Tempos { get; set; } = new List<double>();
        public List<double> Posicoes { get; set; } = new List<double>();
        public List<double> Velocidades { get; set; } = new List<double>();
    }
}