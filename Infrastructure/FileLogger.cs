namespace Infrastructure.Persistence
{
    public class FileLogger
    {
        private readonly string _filePath;

        public FileLogger(string filePath = "log.txt")
        {
            _filePath = filePath;
        }

        public void Log(string message)
        {
            System.IO.File.AppendAllText(_filePath, message + "\n");
        }

        public void LogDetails(bool considerFriction, double force, double mass)
        {
            string frictionStatus = considerFriction ? "Com atrito" : "Sem atrito";
            string message = $"Condição de atrito: {frictionStatus}, Força: {force}N, Massa: {mass}kg";
            Log(message);
        }
    }
}