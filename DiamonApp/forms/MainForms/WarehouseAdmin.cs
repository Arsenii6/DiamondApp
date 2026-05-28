using DiamonApp.Classes;
using DiamonApp.DataBase;
using DiamonApp.Forms.DifferentFunctionsForms;
using Draft_Diamond_BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Draft_Diamond_BD
{
    public partial class WarehouseAdmin : Form
    {
        private DataGridView dgvWarehouseTrue;
        private string userLogin;
        private List<double> _seasonPercents = new();

        public WarehouseAdmin(string login)
        {
            InitializeComponent();
            userLogin = login;
            labelLogin.Text = "Логин:" + userLogin;
            CreateDataGridView();
            LoadProductsTrue();
            FilterProducts();
            весьСкладToolStripMenuItem.Click += (s, a) => LoadProductsTrue();
            exitToolStripMenuItemOutput.Click += Exit_Click;
            addCardToolStripMenuItem.Click += AddCardToolStripMenuItem_Click;
            NewCategoryToolStripMenuItem.Click += newCategoryToolStripMenuItem_Click;
            changeCardToolStripMenuItem.Click += changeCardToolStripMenuItem_Click;
            changeCategoryToolStripMenuItem1.Click += CategoryChangeToolStripMenuItem1_Click;
            deleteCardToolStripMenuItem.Click += deleteCardToolStripMenuItem_Click;
            DeleteCategoryToolStripMenuItem2.Click += deleteCategoryToolStripMenuItem2_Click;
            toolStripMenuItemCollections.Click += toolStripMenuItemCollections_Click;
            принятьПоставкуToolStripMenuItem.Click += принятьПоставкуToolStripMenuItem_Click;
            toolStripMenuItemCurrency.Click += toolStripMenuItemCurrency_Click;
            changeAccountToolStripMenuItem.Click += changeAccountToolStripMenuItem_Click;

            Logger.UserAction(userLogin, "Открыта форма администратора склада");
        }

        private void CreateDataGridView()
        {
            dgvWarehouseTrue = new DataGridView
            {
                Location = new System.Drawing.Point(20, 90),
                Size = new System.Drawing.Size(1060, 540),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = System.Drawing.Color.White,
                BorderStyle = BorderStyle.None,
                RowHeadersVisible = false,
                AllowUserToAddRows = false,
                ReadOnly = true,
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom,
                Font = new System.Drawing.Font("Segoe UI", 10F),
            };
            dgvWarehouseTrue.CellFormatting += DgvWarehouseTrue_CellFormatting;
            Controls.Add(dgvWarehouseTrue);
        }

        private void DgvWarehouseTrue_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= _seasonPercents.Count) return;

            double percent = _seasonPercents[e.RowIndex];
            var row = dgvWarehouseTrue.Rows[e.RowIndex];

            System.Drawing.Color color;
            if (percent > 50)
                color = System.Drawing.Color.FromArgb(144, 238, 144);
            else if (percent >= 25)
                color = System.Drawing.Color.FromArgb(255, 255, 102);
            else
                color = System.Drawing.Color.FromArgb(255, 102, 102);

            row.DefaultCellStyle.BackColor = color;
            row.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(
                color.R - 20 < 0 ? 0 : color.R - 20,
                color.G - 20 < 0 ? 0 : color.G - 20,
                color.B - 20 < 0 ? 0 : color.B - 20);
        }

        private void FilterProducts()
        {
            Logger.UserAction(userLogin, "Фильтрация продуктов по категориям");
            using var db = new AllDB();
            foreach (var cat in db.Categories.ToList())
            {
                foreach (var category in cat.NamesOfCategory)
                {
                    var alreadyExists = false;
                    foreach (ToolStripMenuItem existingItem in категорииToolStripMenuItem.DropDownItems)
                    {
                        if (existingItem.Text == category) { alreadyExists = true; break; }
                    }
                    if (alreadyExists) continue;

                    var menuItem = new ToolStripMenuItem(category);
                    menuItem.Click += (s, e) =>
                    {
                        Logger.UserAction(userLogin, $"Фильтрация по категории: {category}");
                        using var db = new AllDB();
                        var raw = db.Products.Where(p => p.Category == category && p.Status == true).ToList();
                        BindProductsWithPercents(raw);
                    };
                    категорииToolStripMenuItem.DropDownItems.Add(menuItem);
                }
            }
        }

        public void LoadProductsTrue()
        {
            Logger.UserAction(userLogin, "Загрузка активных товаров");
            using var db = new AllDB();
            ExpirationDateCheck();
            var raw = db.Products.Where(p => p.Status == true).ToList();
            BindProductsWithPercents(raw);
        }

        private void BindProductsWithPercents(List<DiamonApp.Classes.ProductClass> products)
        {
            _seasonPercents.Clear();

            var display = products.Select(p =>
            {
                int daysLeft = (int)(p.EndDateOfTheDay - DateTime.Today).TotalDays;
                int totalDays = p.UntilTheEndOfTheSeason * 7;
                double percent;

                if (totalDays > 0)
                    percent = (double)daysLeft / totalDays * 100.0;
                else
                    percent = daysLeft > 0 ? Math.Min((double)daysLeft / 365.0 * 100.0, 100.0) : 0;

                if (percent < 0) percent = 0;
                _seasonPercents.Add(percent);

                return new
                {
                    Название = p.Name,
                    Единица_измерения = p.UniteOfMeasure,
                    Цена_закупки = AppCurrencyManager.Format(p.PurchasePrice),
                    Текущий_остаток = p.Rest,
                    Сезон_до = p.EndDateOfTheDay.ToString("d"),
                    До_конца = p.UntilTheEndOfTheSeason,
                    Скидка = p.Discount,
                    Итоговая_стоимость = AppCurrencyManager.Format(p.FinalyPrice),
                };
            }).ToList();

            dgvWarehouseTrue.DataSource = display;
            SetupColumnsTrue();
        }

        private void ExpirationDateCheck()
        {
            using var db = new AllDB();
            foreach (var product in db.Products)
            {
                if (product.EndDateOfTheDay < DateTime.Today)
                {
                    product.Status = false;
                    Logger.UserAction(userLogin, $"Товар '{product.Name}' просрочен");
                    db.SaveChanges();
                }
            }
        }

        private void SetupColumnsTrue()
        {
            foreach (DataGridViewColumn col in dgvWarehouseTrue.Columns)
                col.HeaderText = col.HeaderText.Replace("_", " ");
        }

        private void AddCardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logger.UserAction(userLogin, "Открытие формы добавления карточки");
            new AddCard(userLogin).Show();
            Hide();
        }

        private void newCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logger.UserAction(userLogin, "Открытие формы добавления категории");
            new AddCategory(userLogin).Show();
            Hide();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Logger.UserAction(userLogin, "Выход из приложения");
            Application.Exit();
        }

        private void changeAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logger.UserAction(userLogin, "Смена аккаунта");
            new Authorization().Show();
            Hide();
        }

        private void changeCardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logger.UserAction(userLogin, "Открытие формы изменения карточки");
            new ChangeCard(userLogin).Show();
            Hide();
        }

        private void CategoryChangeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Logger.UserAction(userLogin, "Открытие формы изменения категории");
            new ChangeCategory(userLogin).Show();
            Hide();
        }

        private void deleteCardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logger.UserAction(userLogin, "Открытие формы удаления карточки");
            new DeleteCard(userLogin).Show();
            Hide();
        }

        private void deleteCategoryToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Logger.UserAction(userLogin, "Открытие формы удаления категории");
            new DeleteCategory(userLogin).Show();
            Hide();
        }

        private void buttonHistoryShipment_Click(object sender, EventArgs e)
        {
            Logger.UserAction(userLogin, "Открытие истории отгрузок");
            new HistoryShipmentForm(userLogin).Show();
            Hide();
        }

        private void buttonWrittenOff_Click(object sender, EventArgs e)
        {
            Logger.UserAction(userLogin, "Открытие склада списанных товаров");
            new WrittenOffForm(userLogin).Show();
            Hide();
        }

        private void toolStripMenuItemCollections_Click(object sender, EventArgs e)
        {
            Logger.UserAction(userLogin, "Открытие формы сезонных коллекций");
            new SeasonalCollectionsForm(userLogin).Show();
            Hide();
        }

        private void toolStripMenuItemCurrency_Click(object sender, EventArgs e)
        {
            Logger.UserAction(userLogin, "Открытие настроек валюты");
            new CurrencySettings(userLogin).Show();
            Hide();
        }

        private void принятьПоставкуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logger.UserAction(userLogin, "Открытие формы приёмки поставки");
            new AcceptanceOfGoodsForm(userLogin).Show();
            Hide();
        }
    }
}