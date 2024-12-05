using ParticleMotion.Models;
using System.Globalization;
using System.IO;

namespace ParticleMotion.Services
{
    /// <summary>
    /// Implementa o serviço de leitura de logs de acordo com a interface ILogReaderService.
    /// </summary>
    public class LogReaderService : ILogReaderService
    {
        /// <summary>
        /// Lê as entradas de log de um arquivo especificado.
        /// </summary>
        /// <param name="filePath">O caminho do arquivo de log a ser lido.</param>
        /// <returns>Uma lista de entradas de log (LogEntry) lidas do arquivo.</returns>
        public List<LogEntry> ReadLogEntries(string filePath)
        {
            var logEntries = new List<LogEntry>();
            var lines = File.ReadAllLines(filePath);
            LogEntry currentEntry = null;
            bool isDataSection = false;

            foreach (var line in lines)
            {
                if (line.StartsWith("Condição de Atrito"))
                {
                    isDataSection = true;
                    if (currentEntry != null)
                        logEntries.Add(currentEntry);

                    currentEntry = new LogEntry
                    {
                        Posicoes = new List<double>(),
                        Velocidades = new List<double>(),
                        Tempos = new List<double>()
                    };
                }
                else if (isDataSection && !string.IsNullOrWhiteSpace(line))
                {
                    var parts = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length >= 2)
                    {
                        if (parts[0] == "Com" || parts[0] == "Sem")
                        {
                            currentEntry.AtritoCondicao = parts[0] + " " + parts[1];
                            currentEntry.Forca = int.Parse(parts[2].Replace("N", ""));
                            currentEntry.Massa = int.Parse(parts[3].Replace("kg", ""));
                        }
                        else if (double.TryParse(parts[0].Replace("s", ""), NumberStyles.Any, CultureInfo.InvariantCulture, out double tempo))
                        {
                            currentEntry.Tempos.Add(tempo);
                            currentEntry.Posicoes.Add(double.Parse(parts[1].Replace("m", ""), CultureInfo.InvariantCulture));
                            currentEntry.Velocidades.Add(double.Parse(parts[2].Replace("m/s", ""), CultureInfo.InvariantCulture));
                        }
                    }
                }
                else if (line.StartsWith("----"))
                {
                    isDataSection = false;
                }
            }

            if (currentEntry != null)
                logEntries.Add(currentEntry);

            return logEntries;
        }
    }
}