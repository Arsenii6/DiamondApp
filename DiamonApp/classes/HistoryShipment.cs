namespace DiamonApp.Classes
{
    /// <summary>
    /// Представляет запись об отгрузке товаров
    /// </summary>
    public class HistoryShipment
    {
        /// <summary>
        /// Уникальный идентификатор отгрузки
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Наименования отгруженных товаров
        /// </summary>
        public string ProductsName { get; set; }

        /// <summary>
        /// Единица измерения
        /// </summary>
        public string UniteOfMeasure { get; set; }

        /// <summary>
        /// Дата отгрузки
        /// </summary>
        public DateTime DateShipment { get; set; }

        /// <summary>
        /// Количество отгруженного товара
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Общая сумма отгрузки
        /// </summary>
        public decimal SumShipment { get; set; }

        /// <summary>
        /// Прибыль от отгрузки
        /// </summary>
        public decimal Profit { get; set; }

        /// <summary>
        /// Имя получателя
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// Адрес доставки
        /// </summary>
        public string CustomerPlace { get; set; }

        /// <summary>
        /// Логин кладовщика, оформившего отгрузку
        /// </summary>
        public string LoginStorekeeper { get; set; }

        /// <summary>
        /// Инициализирует новую запись истории отгрузки
        /// </summary>
        public HistoryShipment(string productsName, string uniteOfMeasure, DateTime dateShipment, int count, decimal sumShipment, decimal profit, string customerName, string customerPlace, string loginStorekeeper)
        {
            ProductsName = productsName;
            UniteOfMeasure = uniteOfMeasure;
            DateShipment = dateShipment;
            Count = count;
            SumShipment = sumShipment;
            Profit = profit;
            CustomerName = customerName;
            CustomerPlace = customerPlace;
            LoginStorekeeper = loginStorekeeper;
        }
    }
}