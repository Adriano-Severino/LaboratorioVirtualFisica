using ParticleMotion.Models;

namespace ParticleMotion.Services
{
    /// <summary>
    /// Define uma interface para um serviço de leitura de logs.
    /// </summary>
    public interface ILogReaderService
    {
        /// <summary>
        /// Lê as entradas de log de um arquivo especificado.
        /// </summary>
        /// <param name="filePath">O caminho do arquivo de log a ser lido.</param>
        /// <returns>Uma lista de entradas de log (LogEntry) lidas do arquivo.</returns>
        List<LogEntry> ReadLogEntries(string filePath);
    }
}