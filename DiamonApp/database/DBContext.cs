using DiamonApp.classes;
namespace DiamonApp.DataBase
{
    public class AllDB : DbContext
    {
        public DbSet<ProductClass> Products { get; set; }
        public DbSet<CategoryClass> Categories { get; set; }
        public DbSet<EmployeeClass> Employess { get; set; }
        public DbSet<HistoryShipment> HistoryShipment { get; set; }
        public DbSet<ProductsOnShipmentClass> ProductsOnShipments { get; set; }
        public DbSet<ProductsOnAcceptanceClass> ProductsOnAcceptance { get; set; }
        public DbSet<UniteOfMeasureClass> UniteOfMeasures { get; set; }
        public AllDB()
        {
            Database.EnsureCreated();

            Task.Run(async () => await EnsureExistAsync()).Wait();
            Task.Run(async () => await AddUnitesOfMeasureAsync()).Wait();
            Task.Run(async () => await AddDataCategoriesAsync()).Wait();
            Task.Run(async () => await AddDataProductsAsync()).Wait();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=allDataBase.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductClass>().ToTable("Products");
            modelBuilder.Entity<ProductClass>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Name);
                entity.Property(p => p.UniteOfMeasure);
                entity.Property(p => p.Category);
                entity.Property(p => p.PurchasePrice);
                entity.Property(p => p.Rest);
                entity.Property(p => p.Creator);
                entity.Property(p => p.EndDateOfTheDay);
                entity.Property(p => p.UntilTheEndOfTheSeason);
                entity.Property(p => p.Discount);
                entity.Property(p => p.DiscountBeforeEnd);
                entity.Property(p => p.FinalyPrice);
                entity.Property(p => p.Status);
            });
            modelBuilder.Entity<UniteOfMeasureClass>().ToTable("UniteOfMeasures");
            modelBuilder.Entity<UniteOfMeasureClass>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.UnitesOfMeasure);
            });
            modelBuilder.Entity<CategoryClass>().ToTable("Categories");
            modelBuilder.Entity<CategoryClass>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.NamesOfCategory);
            });
            modelBuilder.Entity<EmployeeClass>().ToTable("Employess");
            modelBuilder.Entity<EmployeeClass>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Name);
                entity.Property(p => p.Surname);
                entity.Property(p => p.Login);
                entity.Property(p => p.Password);
                entity.Property(p => p.Job);
            });
            modelBuilder.Entity<HistoryShipment>().ToTable("HistoryShipment");
            modelBuilder.Entity<HistoryShipment>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(p => p.ProductsName);
                entity.Property(p => p.UniteOfMeasure);
                entity.Property(p => p.DateShipment);
                entity.Property(p => p.Count);
                entity.Property(p => p.SumShipment);
                entity.Property(p => p.Profit);
                entity.Property(p => p.CustomerName);
                entity.Property(p => p.CustomerPlace);
                entity.Property(p => p.LoginStorekeeper);
            });
            modelBuilder.Entity<ProductsOnShipmentClass>().ToTable("ProductsOnShipmentClass");
            modelBuilder.Entity<ProductsOnShipmentClass>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Name);
                entity.Property(p => p.Count);
                entity.Property(p => p.Sum);
                entity.Property(p => p.CustomerName);
                entity.Property(p => p.CustomerPlace);
                entity.Property(p => p.LoginStorekeeper);
                entity.Property(p => p.Region);
                entity.Property(p => p.Insurance);
            });
            modelBuilder.Entity<ProductsOnAcceptanceClass>().ToTable("ProductsOnAcceptanceClass");
            modelBuilder.Entity<ProductsOnAcceptanceClass>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Name);
                entity.Property(p => p.Count);
                entity.Property(p => p.Price);
                entity.Property(p => p.ProviderName);
                entity.Property(p => p.LoginEmployee);
            });
        }
        private async Task EnsureExistAsync()
        {
            if (!await Employess.AnyAsync(w => w.Login == "777"))
            {
                await Employess.AddAsync(new EmployeeClass("Admin", "One", "777", SimpleHash.HashSHA256("777"), Enums.JobsEnumcs.Administrator));
            }

            if (!await Employess.AnyAsync(w => w.Login == "12"))
            {
                await Employess.AddAsync(new EmployeeClass("Кладовщик", "Коробков", "12", SimpleHash.HashSHA256("12"), Enums.JobsEnumcs.Storekeeper));
            }

            await SaveChangesAsync();
        }
        private async Task AddDataCategoriesAsync()
        {
            if (!await Categories.AnyAsync())
            {
                var newListOfCategories = new List<string>() { "Кольцо", "Серьги", "Колье", "Браслет", "Брошь" };
                await Categories.AddAsync(new CategoryClass(1, newListOfCategories));
                await SaveChangesAsync();
            }
        }
        private async Task AddUnitesOfMeasureAsync()
        {
            if (!await UniteOfMeasures.AnyAsync())
            {
                var newListOfUnits = new List<string>() { "Штуки", "Граммы" };
                await UniteOfMeasures.AddAsync(new UniteOfMeasureClass(1, newListOfUnits));
                await SaveChangesAsync();
            }
        }
        private async Task AddDataProductsAsync()
        {
            if (!await Products.AnyAsync())
            {
                var categories = await Categories.ToListAsync();
                var allNamesLinq = new List<string>();
                foreach (var category in categories)
                {
                    allNamesLinq.AddRange(category.NamesOfCategory);
                }
                var units = await UniteOfMeasures.ToListAsync();
                var allUnitsLinq = new List<string>();
                foreach (var unite in units)
                {
                    allUnitsLinq.AddRange(unite.UnitesOfMeasure);
                }
                var dateEnd = new DateTime(2060, 12, 12);
                var dateNow = DateTime.Now;
                var admin = await Employess.FirstOrDefaultAsync(p => p.Login == "777");
                await Products.AddRangeAsync(new ProductClass[]
                {
                    new ProductClass( "Какое то кольцо", allUnitsLinq[0], 45000m, allNamesLinq[0], 30, admin?.Login ?? "777", dateEnd, ((dateEnd.Year - dateNow.Year)*12)+(dateEnd.Month - dateNow.Month), 0, 0, true),
                    new ProductClass( "Какие то серьги", allUnitsLinq[0], 45000m, allNamesLinq[1], 30, admin?.Login ?? "777", dateEnd, ((dateEnd.Year - dateNow.Year)*12)+(dateEnd.Month - dateNow.Month), 0, 0, true),
                    new ProductClass( "Какое то колье", allUnitsLinq[0], 45000m, allNamesLinq[2], 30, admin?.Login ?? "777", dateEnd, ((dateEnd.Year - dateNow.Year)*12)+(dateEnd.Month - dateNow.Month), 0, 0, true),
                    new ProductClass( "Какой то браслет", allUnitsLinq[0], 45000m, allNamesLinq[3], 30, admin?.Login ?? "777", dateEnd, ((dateEnd.Year - dateNow.Year)*12)+(dateEnd.Month - dateNow.Month), 0, 0, true),
                    new ProductClass( "Какая то брошь", allUnitsLinq[0], 45000m, allNamesLinq[4], 30, admin?.Login ?? "777", dateEnd, ((dateEnd.Year - dateNow.Year)*12)+(dateEnd.Month - dateNow.Month), 0, 0, true),
                    new ProductClass( "Какая то брошь(просроченный)", allUnitsLinq[0], 45000m, allNamesLinq[4], 30, admin?.Login ?? "777", new DateTime(2021, 12, 12), 0, 0, 0, false),
                    new ProductClass( "Кольцо 'Изумруд'", allUnitsLinq[0], 125000m, allNamesLinq[0], 25, admin?.Login ?? "777",
                        DateTime.Today.AddDays(400), 52, 0, 0, true),
                    new ProductClass( "Серьги 'Жемчуг'", allUnitsLinq[0], 89000m, allNamesLinq[1], 18, admin?.Login ?? "777",
                        DateTime.Today.AddDays(365), 48, 0, 0, true),
                    new ProductClass( "Колье 'Королевское'", allUnitsLinq[0], 350000m, allNamesLinq[2], 5, admin?.Login ?? "777",
                        DateTime.Today.AddDays(550), 72, 0, 0, true),

                    new ProductClass( "Браслет 'Летний'", allUnitsLinq[0], 45000m, allNamesLinq[3], 42, admin?.Login ?? "777",
                        DateTime.Today.AddDays(60), 12, 0, 0, true),
                    new ProductClass( "Брошь 'Осенняя'", allUnitsLinq[0], 67000m, allNamesLinq[4], 15, admin?.Login ?? "777",
                        DateTime.Today.AddDays(45), 8, 0, 0, true),
                    new ProductClass( "Кольцо 'Топаз'", allUnitsLinq[0], 78000m, allNamesLinq[0], 12, admin?.Login ?? "777",
                        DateTime.Today.AddDays(90), 16, 0, 0, true),

                    new ProductClass( "Серьги 'Хрусталь'", allUnitsLinq[0], 34000m, allNamesLinq[1], 8, admin?.Login ?? "777",
                        DateTime.Today.AddDays(14), 4, 0, 0, true),
                    new ProductClass( "Колье 'Сапфир'", allUnitsLinq[0], 180000m, allNamesLinq[2], 3, admin?.Login ?? "777",
                        DateTime.Today.AddDays(7), 2, 0, 0, true),
                    new ProductClass( "Браслет 'Зимний'", allUnitsLinq[0], 55000m, allNamesLinq[3], 20, admin?.Login ?? "777",
                        DateTime.Today.AddDays(3), 1, 0, 0, true),
                    new ProductClass( "Брошь 'Аметист'", allUnitsLinq[0], 92000m, allNamesLinq[4], 6, admin?.Login ?? "777",
                        DateTime.Today.AddDays(10), 2, 0, 0, true),
                    new ProductClass( "Кольцо 'Лунный камень'", allUnitsLinq[0], 63000m, allNamesLinq[0], 4, admin?.Login ?? "777",
                        DateTime.Today.AddDays(1), 1, 0, 0, true),
                });

                await SaveChangesAsync();
            }
        }


        public async Task<ProductClass?> GetProductByNameAsync(string name)
        {
            return await Products.FirstOrDefaultAsync(p => p.Name == name);
        }
        public async Task<List<ProductClass>> GetActiveProductsAsync()
        {
            return await Products.Where(p => p.Status).ToListAsync();
        }
        public async Task<List<ProductClass>> GetExpiredProductsAsync()
        {
            return await Products.Where(p => !p.Status).ToListAsync();
        }
        public async Task<List<ProductClass>> GetProductsByCategoryAsync(string category)
        {
            return await Products.Where(p => p.Category == category && p.Status).ToListAsync();
        }
        public async Task<EmployeeClass?> GetEmployeeByLoginAsync(string login)
        {
            return await Employess.FirstOrDefaultAsync(e => e.Login == login);
        }
        public async Task<List<string>> GetAllCategoriesAsync()
        {
            var categoryEntity = await Categories.FirstOrDefaultAsync(p => p.Id == 1);
            return categoryEntity?.NamesOfCategory ?? new List<string>();
        }
        public async Task<List<string>> GetAllUnitsAsync()
        {
            var unitsEntity = await UniteOfMeasures.FirstOrDefaultAsync(p => p.Id == 1);
            return unitsEntity?.UnitesOfMeasure ?? new List<string>();
        }
        public async Task<int> UpdateExpiredProductsStatusAsync()
        {
            var expiredProducts = await Products
                .Where(p => p.EndDateOfTheDay < DateTime.Today && p.Status)
                .ToListAsync();

            foreach (var product in expiredProducts)
            {
                product.Status = false;
            }

            await SaveChangesAsync();
            return expiredProducts.Count;
        }
        public async Task<List<HistoryShipment>> GetShipmentsByDateRangeAsync(DateTime start, DateTime end)
        {
            return await HistoryShipment
                .Where(s => s.DateShipment.Date >= start && s.DateShipment.Date <= end)
                .ToListAsync();
        }
        public async Task<List<ProductsOnShipmentClass>> GetShipmentCartAsync()
        {
            return await ProductsOnShipments.ToListAsync();
        }
        public async Task ClearShipmentCartAsync()
        {
            var items = await ProductsOnShipments.ToListAsync();
            ProductsOnShipments.RemoveRange(items);
            await SaveChangesAsync();
        }
        public async Task<List<ProductsOnAcceptanceClass>> GetAcceptanceCartAsync()
        {
            return await ProductsOnAcceptance.ToListAsync();
        }
        public async Task ClearAcceptanceCartAsync()
        {
            var items = await ProductsOnAcceptance.ToListAsync();
            ProductsOnAcceptance.RemoveRange(items);
            await SaveChangesAsync();
        }
        public async Task<List<ProductsOnShipmentClass>> GetShipmentCartWithRegionAsync()
        {
            return await ProductsOnShipments.ToListAsync();
        }
    }
}