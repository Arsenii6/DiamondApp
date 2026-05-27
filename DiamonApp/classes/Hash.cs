namespace DiamondApp.Hash
{
    /// <summary>
    /// Предоставляет методы для хэширования строк
    /// </summary>
    public class SimpleHash
    {
        /// <summary>
        /// Вычисляет SHA256 хэш для входной строки
        /// </summary>
        public static string HashSHA256(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(input);
                var hash = sha256.ComputeHash(bytes);
                var sb = new StringBuilder();
                foreach (byte b in hash)
                {
                    sb.Append(b.ToString("x2"));
                }
                return sb.ToString();
            }
        }
    }
}