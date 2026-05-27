namespace DiamonApp.Classes
{
    /// <summary>
    /// Представляет сотрудника системы с учётными данными и должностью
    /// </summary>
    public class EmployeeClass
    {
        /// <summary>
        /// Уникальный идентификатор сотрудника
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Имя сотрудника
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Фамилия сотрудника
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Логин для входа в систему
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Должность сотрудника
        /// </summary>
        public JobsEnumcs Job { get; set; }

        /// <summary>
        /// Инициализирует нового сотрудника с указанными данными
        /// </summary>
        public EmployeeClass(string name, string surname, string login, string password, JobsEnumcs job)
        {
            Id = Guid.NewGuid();
            Name = name;
            Surname = surname;
            Login = login;
            Password = password;
            Job = job;
        }
    }
}