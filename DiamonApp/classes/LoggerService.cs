using DiamondApp.Interfaces;
namespace DiamondApp.classes
{
    public class LoggerService : ILogger
    {
        private static readonly string LogDirectory;
        static LoggerService()
        {
            string appDirectory = Application.StartupPath;
            LogDirectory = Path.Combine(appDirectory, "Logs");

            if (!Directory.Exists(LogDirectory))
                Directory.CreateDirectory(LogDirectory);
        }
        private static string GetLogFilePath()
        {
            return Path.Combine(LogDirectory, $"log_{DateTime.Now:yyyy-MM-dd}.txt");
        }
        private static void WriteLog(string level, string message)
        {
            string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff} [{level}] {message}";
            File.AppendAllText(GetLogFilePath(), logEntry + Environment.NewLine);
        }
        public void UserAction(string userLogin, string action)
        {
            WriteLog("USER", $"Пользователь '{userLogin}' выполнил: {action}");
        }
        public void OpenLogFolder()
        {
            Process.Start("explorer.exe", LogDirectory);
        }
    }
}