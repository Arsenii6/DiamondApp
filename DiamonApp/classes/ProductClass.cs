namespace DiamonApp.Classes
{
    /// <summary>
    /// Представляет товар на складе
    /// </summary>
    public class ProductClass
    {
        /// <summary>
        /// Уникальный идентификатор товара
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Наименование товара
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Единица измерения товара
        /// </summary>
        public string UniteOfMeasure { get; set; }

        /// <summary>
        /// Закупочная цена
        /// </summary>
        public decimal PurchasePrice { get; set; }

        /// <summary>
        /// Категория товара
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Остаток на складе
        /// </summary>
        public double Rest { get; set; }

        /// <summary>
        /// Создатель карточки товара
        /// </summary>
        public string Creator { get; set; }

        /// <summary>
        /// Дата окончания сезона
        /// </summary>
        public DateTime EndDateOfTheDay { get; set; }

        /// <summary>
        /// Количество недель до конца сезона для применения скидки
        /// </summary>
        public int UntilTheEndOfTheSeason { get; set; }

        /// <summary>
        /// Текущая скидка на товар
        /// </summary>
        public double Discount { get; set; }

        /// <summary>
        /// Порог в днях для применения скидки до конца сезона
        /// </summary>
        public int DiscountBeforeEnd { get; set; }

        /// <summary>
        /// Итоговая цена с учётом скидки
        /// </summary>
        public decimal FinalyPrice { get; set; }

        /// <summary>
        /// Статус активности товара
        /// </summary>
        public bool Status { get; set; }

        /// <summary>
        /// Инициализирует новый товар с указанными параметрами
        /// </summary>
        public ProductClass(string name, string uniteOfMeasure, decimal purchasePrice, string category, double rest, string creator, DateTime endDateOfTheDay, int untilTheEndOfTheSeason, double discount, int discountBeforeEnd, bool status)
        {
            Id = Guid.NewGuid();
            Name = name;
            UniteOfMeasure = uniteOfMeasure;
            PurchasePrice = purchasePrice;
            Category = category;
            Rest = rest;
            Creator = creator;
            EndDateOfTheDay = endDateOfTheDay;
            UntilTheEndOfTheSeason = untilTheEndOfTheSeason;
            Discount = discount;
            FinalyPrice = PurchasePrice - PurchasePrice * ((decimal)discount / 100);
            Status = status;
            DiscountBeforeEnd = discountBeforeEnd;
        }
    }
}
