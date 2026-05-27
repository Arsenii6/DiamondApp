namespace DiamonApp.Classes
{
    /// <summary>
    /// Представляет категорию товаров с набором названий категорий
    /// </summary>
    public class CategoryClass
    {
        /// <summary>
        /// Уникальный идентификатор категории
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Список названий категорий
        /// </summary>
        public List<string> NamesOfCategory { get; set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса CategoryClass с идентификатором и списком названий
        /// </summary>
        public CategoryClass(int id, List<string> namesOfCategory)
        {
            Id = id;
            NamesOfCategory = namesOfCategory;
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса CategoryClass и добавляет одно название категории
        /// </summary>
        public CategoryClass(string namesOfCategory)
        {
            NamesOfCategory.Add(namesOfCategory);
        }
    }
}