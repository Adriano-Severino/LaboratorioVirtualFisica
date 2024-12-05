namespace Infrastructure.Persistence
{
    public class FileLogger
    {
        public void Log(string message)
        {
            System.IO.File.AppendAllText("log.txt", message + "\n");
        }
    }
}