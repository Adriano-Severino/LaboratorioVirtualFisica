namespace Infrastructure.Persistence
{
    public class FileLogger
    {
        private readonly string _filePath;
        private readonly List<string[]> _logEntries;

        public FileLogger(string filePath = "log.txt")
        {
            _filePath = filePath;
            _logEntries = new List<string[]>();
        }

        public void LogDetails(bool considerFriction, double force, double mass)
        {
            string frictionStatus = considerFriction ? "Com atrito" : "Sem atrito";
            _logEntries.Add(new[] { frictionStatus, $"{force}N", $"{mass}kg", "", "", "", "" }); // Adicionado um campo vazio para a velocidade média
        }

        public void LogCalculation(double time, double position, double velocity)
        {
            _logEntries.Add(new[] { "", "", "", $"{time}s", $"{position:F2}m", $"{velocity:F2}m/s", "" });
        }

        public void LogAverageVelocity(double averageVelocity)
        {
            _logEntries.Add(new[] { "", "", "", "", "", "", $"{averageVelocity:F2}m/s" });
        }

        public void SaveLog()
        {
            var headers = new[] { "Condição de Atrito", "Força", "Massa", "Tempo", "Posição", "Velocidade", "Velocidade Média" };
            var table = new List<string[]> { headers };
            table.AddRange(_logEntries);

            int[] columnWidths = headers.Select((h, i) => table.Max(row => row[i].Length)).ToArray();

            using (var writer = new StreamWriter(_filePath, true)) // true para append
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

                writer.WriteLine(); // Linha em branco entre registros
            }

            // Limpa as entradas para a próxima execução
            _logEntries.Clear();
        }
    }
}