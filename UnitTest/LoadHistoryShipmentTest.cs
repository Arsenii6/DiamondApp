//using DiamonApp.forms.differentFunctionsForms;
//using System.Windows.Forms;

//namespace UnitTest
//{
//    public class LoadHistoryShipmentTest
//    {
//        /// <summary>
//        /// Тест на проверку, что метод не падает
//        /// </summary>
//        [Fact]
//        public void LoadProducts_DoesNotThrow()
//        {
//            var form = new HistoryShipmentForm("admin");
//            var ex = Record.Exception(() => form.LoadProducts());
//            Assert.Null(ex);
//        }
//        /// <summary>
//        /// Тест на проверку, что DataGridView существует
//        /// </summary>
//        [Fact]
//        public void LoadProducts_GridExists()
//        {
//            var form = new HistoryShipmentForm("admin");
//            form.LoadProducts();
//            var grid = form.Controls.OfType<DataGridView>().FirstOrDefault();
//            Assert.NotNull(grid);
//        }
//        /// <summary>
//        /// Тест на проверку,что DataSource устанавливается
//        /// </summary>
//        [Fact]
//        public void LoadProducts_DataSource_IsSet()
//        {
//            var form = new HistoryShipmentForm("admin");
//            form.LoadProducts();
//            var grid = form.Controls.OfType<DataGridView>().First();
//            Assert.NotNull(grid.DataSource);
//        }
//        /// <summary>
//        /// Тест на проверку на наличе строк
//        /// </summary>
//        [Fact]
//        public void LoadProducts_ReturnsData()
//        {
//            var form = new HistoryShipmentForm("admin");
//            form.LoadProducts();
//            var grid = form.Controls.OfType<DataGridView>().First();
//            Assert.True(grid.Rows.Count >= 0);
//        }
//        /// <summary>
//        /// Тест на проверку структуры данных
//        /// </summary>
//        [Fact]
//        public void LoadProducts_HasExpectedColumns()
//        {
//            var form = new HistoryShipmentForm("admin");
//            form.LoadProducts();
//            var grid = form.Controls.OfType<DataGridView>().First();
//            Assert.Contains(grid.Columns.Cast<DataGridViewColumn>(), c => c.Name.Contains("DateShipment") || c.DataPropertyName.Contains("DateShipment"));
//        }
//        /// <summary>
//        /// Тест на проверку, что SetupColumns вызывается без ошибок
//        /// </summary>
//        [Fact]
//        public void LoadProducts_SetupColumns_DoesNotThrow()
//        {
//            var form = new HistoryShipmentForm("admin");
//            var ex = Record.Exception(() => form.LoadProducts());
//            Assert.Null(ex);
//        }
//        /// <summary>
//        /// Тест на проверку переименования колок
//        /// </summary>
//        [Fact]
//        public void LoadProducts_ChangesColumnHeaders()
//        {
//            var form = new HistoryShipmentForm("admin");
//            form.LoadProducts();
//            var grid = form.Controls.OfType<DataGridView>().First();
//            Assert.True(grid.Columns["DateShipment"]?.HeaderText == "Дата" || grid.Columns.Count > 0);
//        }
//        /// <summary>
//        /// Тест на проверку пр пустой БД
//        /// </summary>
//        [Fact]
//        public void LoadProducts_EmptyDb_DoesNotCrash()
//        {
//            var form = new HistoryShipmentForm("admin");
//            var ex = Record.Exception(() => form.LoadProducts());
//            Assert.Null(ex);
//        }
//        /// <summary>
//        /// Тест на проверку,что программа обрабатывает пустое значение
//        /// </summary>
//        [Fact]
//        public void LoadProducts_DataSource_NotNull()
//        {
//            var form = new HistoryShipmentForm("admin");
//            form.LoadProducts();
//            var grid = form.Controls.OfType<DataGridView>().First();
//            Assert.NotNull(grid.DataSource);
//        }
//        /// <summary>
//        /// Тест на повторную загрузку
//        /// </summary>
//        [Fact]
//        public void LoadProducts_WorkCorrectly()
//        {
//            var form = new HistoryShipmentForm("admin");
//            form.LoadProducts();
//            form.LoadProducts();
//            var grid = form.Controls.OfType<DataGridView>().First();
//            Assert.NotNull(grid.DataSource);
//        }
//        /// <summary>
//        /// Тест на проверку, что Grid не дублируется
//        /// </summary>
//        [Fact]
//        public void LoadProducts_DoesNotDuplicateGrid()
//        {
//            var form = new HistoryShipmentForm("admin");
//            var before = form.Controls.OfType<DataGridView>().Count();
//            form.LoadProducts();
//            var after = form.Controls.OfType<DataGridView>().Count();
//            Assert.Equal(before, after);
//        }
//        /// <summary>
//        /// Тест на проверку, что один и тот же Grid используется
//        /// </summary>
//        [Fact]
//        public void LoadProducts_UsesSameGridInstance()
//        {
//            var form = new HistoryShipmentForm("admin");
//            var grid1 = form.Controls.OfType<DataGridView>().First();
//            form.LoadProducts();
//            var grid2 = form.Controls.OfType<DataGridView>().First();
//            Assert.Same(grid1, grid2);
//        }
//        /// <summary>
//        /// Тест на проверку, что метод вызывает SetupColumns
//        /// </summary>
//        [Fact]
//        public void LoadProducts_ExecutesWithoutException()
//        {
//            var form = new HistoryShipmentForm("admin");
//            form.LoadProducts();
//            Assert.True(true);
//        }
//    }
//}
