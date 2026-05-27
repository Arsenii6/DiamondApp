namespace DiamonApp.Classes
{
    /// <summary>
    /// Представляет товары в корзине отгрузки
    /// </summary>
    public class ProductsOnShipmentClass
    {
        /// <summary>
        /// Уникальный идентификатор позиции отгрузки
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Наименование товара
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Количество товара для отгрузки
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Сумма отгрузки
        /// </summary>
        public decimal Sum { get; set; }

        /// <summary>
        /// Имя получателя
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// Адрес доставки
        /// </summary>
        public string CustomerPlace { get; set; }

        /// <summary>
        /// Логин кладовщика, создавшего отгрузку
        /// </summary>
        public string LoginStorekeeper { get; set; }

        /// <summary>
        /// Инициализирует новую позицию отгрузки
        /// </summary>
        public ProductsOnShipmentClass(string name, int count, decimal sum, string customerName, string customerPlace, string loginStorekeeper)
        {
            Id = Guid.NewGuid();
            Name = name;
            Count = count;
            Sum = sum;
            CustomerName = customerName;
            CustomerPlace = customerPlace;
            LoginStorekeeper = loginStorekeeper;
        }
    }
}