namespace Infrastructure.Persistence
{
    /// <summary>
    /// Classe responsável por registrar e salvar logs de simulações físicas em um arquivo.
    /// </summary>
    public class FileLogger
    {
        private readonly string _filePath;
        private readonly List<string[]> _logEntries;

        /// <summary>
        /// Inicializa uma nova instância da classe FileLogger.
        /// </summary>
        /// <param name="filePath">Caminho do arquivo onde os logs serão salvos. O valor padrão é "log.txt".</param>
        public FileLogger(string filePath = "log.txt")
        {
            _filePath = filePath;
            _logEntries = new List<string[]>();
        }

        /// <summary>
        /// Registra os detalhes iniciais de uma simulação.
        /// </summary>
        /// <param name="considerFriction">Indica se o atrito é considerado na simulação.</param>
        /// <param name="force">Força aplicada na simulação, em Newtons.</param>
        /// <param name="mass">Massa da partícula, em quilogramas.</param>
        public void LogDetails(bool considerFriction, double force, double mass)
        {
            string frictionStatus = considerFriction ? "Com atrito" : "Sem atrito";
            _logEntries.Add(new[] { frictionStatus, $"{force}N", $"{mass}kg", "", "", "", "" });
        }

        /// <summary>
        /// Registra os resultados de um cálculo de movimento.
        /// </summary>
        /// <param name="time">Tempo da simulação, em segundos.</param>
        /// <param name="position">Posição calculada, em metros.</param>
        /// <param name="velocity">Velocidade calculada, em metros por segundo.</param>
        public void LogCalculation(double time, double position, double velocity)
        {
            _logEntries.Add(new[] { "", "", "", $"{time}s", $"{position:F2}m", $"{velocity:F2}m/s", "" });
        }

        /// <summary>
        /// Registra a velocidade média calculada para a simulação.
        /// </summary>
        /// <param name="averageVelocity">Velocidade média, em metros por segundo.</param>
        public void LogAverageVelocity(double averageVelocity)
        {
            _logEntries.Add(new[] { "", "", "", "", "", "", $"{averageVelocity:F2}m/s" });
        }

        /// <summary>
        /// Salva todos os logs registrados no arquivo especificado.
        /// </summary>
        public void SaveLog()
        {
            var headers = new[] { "Condição de Atrito", "Força", "Massa", "Tempo", "Posição", "Velocidade", "Velocidade Média" };
            var table = new List<string[]> { headers };
            table.AddRange(_logEntries);

            int[] columnWidths = headers.Select((h, i) => table.Max(row => row[i].Length)).ToArray();

            using (var writer = new StreamWriter(_filePath, true))
            {
                writer.WriteLine(new string('-', columnWidths.Sum() + columnWidths.Length * 3));
                writer.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                writer.WriteLine(new string('-', columnWidths.Sum() + columnWidths.Length * 3));

                foreach (var row in table)
                {
                    for (int i = 0; i < row.Length; i++)
                    {
                        writer.Write(row[i].PadRight(columnWidths[i] + 2));
                    }
                    writer.WriteLine();
                }

                writer.WriteLine();
            }

            _logEntries.Clear();
        }
    }
}