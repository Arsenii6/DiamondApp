namespace DiamonApp.Classes
{
    /// <summary>
    /// Класс для логирования событий в приложении
    /// </summary>
    public static class Logger
    {
        private static readonly string LogDirectory;
        static Logger()
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
        public static void UserAction(string userLogin, string action)
        {
            WriteLog("USER", $"Пользователь '{userLogin}' выполнил: {action}");
        }
        public static void OpenLogFolder()
        {
            Process.Start("explorer.exe", LogDirectory);
        }
    }
}