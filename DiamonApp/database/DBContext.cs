using DiamonApp.classes;
namespace DiamonApp.DataBase
{
    /// <summary>
    /// Контекст базы данных приложения
    /// </summary>
    public class AllDB : DbContext
    {
        /// <summary>
        /// Таблица товаров
        /// </summary>
        public DbSet<ProductClass> Products { get; set; }

        /// <summary>
        /// Таблица категорий
        /// </summary>
        public DbSet<CategoryClass> Categories { get; set; }

        /// <summary>
        /// Таблица сотрудников
        /// </summary>
        public DbSet<EmployeeClass> Employess { get; set; }

        /// <summary>
        /// Таблица истории отгрузок
        /// </summary>
        public DbSet<HistoryShipment> HistoryShipment { get; set; }

        /// <summary>
        /// Таблица товаров в отгрузке
        /// </summary>
        public DbSet<ProductsOnShipmentClass> ProductsOnShipments { get; set; }

        /// <summary>
        /// Таблица принятых товаров
        /// </summary>
        public DbSet<ProductsOnAcceptanceClass> ProductsOnAcceptance { get; set; }

        /// <summary>
        /// Таблица единиц измерения
        /// </summary>
        public DbSet<UniteOfMeasureClass> UniteOfMeasures { get; set; }

        /// <summary>
        /// Инициализирует контекст базы данных и создаёт начальные данные
        /// </summary>
        public AllDB()
        {
            Logger.UserAction("System", "Инициализация базы данных AllDB");
            Database.EnsureCreated();
            Logger.UserAction("System", "Database.EnsureCreated() выполнен");
            EnsureExist();
            AddUnitesOfMeasure();
            AddDataCategories();
            AddDataProducts();
            Logger.UserAction("System", "Инициализация базы данных AllDB завершена");
        }

        /// <summary>
        /// Настраивает подключение к базе данных SQLite
        /// </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=allDataBase.db");
        }

        /// <summary>
        /// Настраивает схему базы данных и связи между таблицами
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Product base
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

            // UniteOfMeasure base
            modelBuilder.Entity<UniteOfMeasureClass>().ToTable("UniteOfMeasures");
            modelBuilder.Entity<UniteOfMeasureClass>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.UnitesOfMeasure);
            });

            // Categories base
            modelBuilder.Entity<CategoryClass>().ToTable("Categories");
            modelBuilder.Entity<CategoryClass>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.NamesOfCategory);
            });

            //Employees base
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

            //History shipment base
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

            //Products on shipment base
            modelBuilder.Entity<ProductsOnShipmentClass>().ToTable("ProductsOnShipmentClass");
            modelBuilder.Entity<ProductsOnShipmentClass>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Name);
                entity.Property(p => p.Count);
                entity.Property(p => p.CustomerName);
                entity.Property(p => p.CustomerPlace);
                entity.Property(p => p.LoginStorekeeper);
            });

            //Products on acceptance base
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

        /// <summary>
        /// Проверяет наличие администратора и кладовщика, создаёт при их отсутствии
        /// </summary>
        private void EnsureExist()
        {
            Logger.UserAction("System", "EnsureExist: проверка наличия администратора");
            if (!Employess.Any(w => w.Login == "777"))
            {
                Logger.UserAction("System", "EnsureExist: администратор '777' не найден, добавляю");
                Employess.Add(new EmployeeClass("Admin", "One", "777", SimpleHash.HashSHA256("777"), Enums.JobsEnumcs.Administrator));
                Logger.UserAction("System", "EnsureExist: администратор '777' добавлен");
            }

            Logger.UserAction("System", "EnsureExist: проверка наличия кладовщика");
            if (!Employess.Any(w => w.Login == "12"))
            {
                Logger.UserAction("System", "EnsureExist: кладовщик '12' не найден, добавляю");
                Employess.Add(new EmployeeClass("Кладовщик", "Коробков", "12", SimpleHash.HashSHA256("12"), Enums.JobsEnumcs.Storekeeper));
                Logger.UserAction("System", "EnsureExist: кладовщик '12' добавлен");
            }

            SaveChanges();
            Logger.UserAction("System", "EnsureExist: изменения сохранены");
        }

        /// <summary>
        /// Добавляет начальные категории 
        /// </summary>
        private void AddDataCategories()
        {
            Logger.UserAction("System", "AddDataCategories: проверка наличия категорий");
            if (!Categories.Any())
            {
                Logger.UserAction("System", "AddDataCategories: категории не найдены, добавляю стандартные");
                var newListOfCategories = new List<string>() { "Кольцо", "Серьги", "Колье", "Браслет", "Брошь" };
                Categories.Add(new CategoryClass(1, newListOfCategories));
                Logger.UserAction("System", $"AddDataCategories: добавлено {newListOfCategories.Count} категорий");
            }
            SaveChanges();
        }

        /// <summary>
        /// Добавляет начальные единицы измерения 
        /// </summary>
        private void AddUnitesOfMeasure()
        {
            Logger.UserAction("System", "AddUnitesOfMeasure: проверка наличия единиц измерения");
            if (!UniteOfMeasures.Any())
            {
                Logger.UserAction("System", "AddUnitesOfMeasure: единицы измерения не найдены, добавляю стандартные");
                var newListOfCategories = new List<string>() { "Штуки", "Граммы" };
                UniteOfMeasures.Add(new UniteOfMeasureClass(1, newListOfCategories));
                Logger.UserAction("System", $"AddUnitesOfMeasure: добавлено {newListOfCategories.Count} единиц измерения");
            }
            SaveChanges();
        }

        /// <summary>
        /// Добавляет начальные товары 
        /// </summary>
        private void AddDataProducts()
        {
            Logger.UserAction("System", "AddDataProducts: проверка наличия товаров");
            if (!Products.Any())
            {
                Logger.UserAction("System", "AddDataProducts: товары не найдены, добавляю стандартные");

                //достаёт список категорий из бд
                var allNamesLinq = new List<string>();
                foreach (var category in Categories)
                {
                    allNamesLinq.AddRange(category.NamesOfCategory);
                }

                var allUnitsLinq = new List<string>();
                foreach (var unite in UniteOfMeasures)
                {
                    allUnitsLinq.AddRange(unite.UnitesOfMeasure);
                }

                var dateEnd = new DateTime(2060, 12, 12);
                var dateNow = DateTime.Now;

                Products.AddRange(new ProductClass[]
                {
                    new ProductClass( "Какое то кольцо", allUnitsLinq[0], 45000m, allNamesLinq[0], 30, Employess.FirstOrDefault(p => p.Login=="777").Login, dateEnd, ((dateEnd.Year - dateNow.Year)*12)+(dateEnd.Month - dateNow.Month), 0, 0, true),
                    new ProductClass( "Какие то серьги", allUnitsLinq[0], 45000m, allNamesLinq[1], 30, Employess.FirstOrDefault(p => p.Login=="777").Login, dateEnd, ((dateEnd.Year - dateNow.Year)*12)+(dateEnd.Month - dateNow.Month), 0, 0, true),
                    new ProductClass( "Какое то колье", allUnitsLinq[0], 45000m, allNamesLinq[2], 30, Employess.FirstOrDefault(p => p.Login == "777").Login, dateEnd, ((dateEnd.Year - dateNow.Year)*12)+(dateEnd.Month - dateNow.Month), 0, 0, true),
                    new ProductClass( "Какой то браслет", allUnitsLinq[0], 45000m, allNamesLinq[3], 30, Employess.FirstOrDefault(p => p.Login == "777").Login, dateEnd, ((dateEnd.Year - dateNow.Year)*12)+(dateEnd.Month - dateNow.Month), 0, 0, true),
                    new ProductClass( "Какая то брошь", allUnitsLinq[0], 45000m, allNamesLinq[4], 30, Employess.FirstOrDefault(p => p.Login == "777").Login, dateEnd, ((dateEnd.Year - dateNow.Year)*12)+(dateEnd.Month - dateNow.Month), 0, 0, true),
                    new ProductClass( "Какая то брошь(просроченный)", allUnitsLinq[0], 45000m, allNamesLinq[4], 30, Employess.FirstOrDefault(p => p.Login == "777").Login, new DateTime(2021, 12, 12), ((dateEnd.Year - dateNow.Year)*12)+(dateEnd.Month - dateNow.Month), 0, 0, false)
                });

                SaveChanges();
                Logger.UserAction("System", "AddDataProducts: товары успешно добавлены в базу данных");
            }
        }
    }
}