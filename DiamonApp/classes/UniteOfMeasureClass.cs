namespace DiamonApp.classes
{
    /// <summary>
    /// Представляет справочник единиц измерения
    /// </summary>
    public class UniteOfMeasureClass
    {
        /// <summary>
        /// Уникальный идентификатор записи
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Список единиц измерения
        /// </summary>
        public List<string> UnitesOfMeasure { get; set; }

        /// <summary>
        /// Инициализирует новый экземпляр с идентификатором и списком единиц измерения
        /// </summary>
        public UniteOfMeasureClass(int id, List<string> unitesOfMeasure)
        {
            Id = id;
            UnitesOfMeasure = unitesOfMeasure ?? new List<string>();
        }

        /// <summary>
        /// Инициализирует новый экземпляр и добавляет одну единицу измерения
        /// </summary>
        public UniteOfMeasureClass(string uniteOfMeasure)
        {
            UnitesOfMeasure = new List<string>();
            if (!string.IsNullOrEmpty(uniteOfMeasure))
                UnitesOfMeasure.Add(uniteOfMeasure);
        }

        /// <summary>
        /// Конструктор по умолчанию для EF
        /// </summary>
        public UniteOfMeasureClass()
        {
            UnitesOfMeasure = new List<string>();
        }
    }
}