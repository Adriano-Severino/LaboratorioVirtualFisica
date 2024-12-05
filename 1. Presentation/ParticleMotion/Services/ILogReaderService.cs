using ParticleMotion.Models;

namespace ParticleMotion.Services
{
    public interface ILogReaderService
    {
        List<LogEntry> ReadLogEntries(string filePath);
    }
}