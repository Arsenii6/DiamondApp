using System;

namespace DiamonApp.Classes
{
    public class ProductsOnShipmentClass
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Count { get; set; }
        public decimal Sum { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerPlace { get; set; } = string.Empty;
        public string LoginStorekeeper { get; set; } = string.Empty;
        public string Region { get; set; } = "Москва";
        public string Insurance { get; set; } = "—";

        public ProductsOnShipmentClass(string name, int count, decimal sum,
            string customerName, string customerPlace, string loginStorekeeper)
        {
            Id = Guid.NewGuid();
            Name = name ?? string.Empty;
            Count = count;
            Sum = sum;
            CustomerName = customerName ?? string.Empty;
            CustomerPlace = customerPlace ?? string.Empty;
            LoginStorekeeper = loginStorekeeper ?? string.Empty;
            Region = "Москва";
            Insurance = "—";
        }

        public ProductsOnShipmentClass()
        {
            Name = string.Empty;
            CustomerName = string.Empty;
            CustomerPlace = string.Empty;
            LoginStorekeeper = string.Empty;
            Region = "Москва";
            Insurance = "—";
        }
    }
}