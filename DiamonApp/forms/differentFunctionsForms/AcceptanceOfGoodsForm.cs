using DiamonApp.Classes;
using DiamonApp.DataBase;
using DiamonApp.Enums;
using DiamondApp.Resourses;
using Draft_Diamond_BD;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace DiamondApp.forms.differentFunctionsForms
{
    /// <summary>
    /// Форма приёмки товаров.
    /// Содержит проверку контрагента по ИНН через API (SupplierCheckForm)
    /// и подтверждение приёмки (AcceptanceConfirmForm).
    /// </summary>
    public partial class AcceptanceOfGoodsForm : Form
    {
        private DataGridView dgvWarehouse;
        private string UserLogin;

        public AcceptanceOfGoodsForm(string userLogin)
        {
            InitializeComponent();
            UserLogin = userLogin;
            labelLogin.Text = Resources.LoginInMenu + userLogin;
            CreateDataGridView();
            LoadProducts();
            comboBoxName.Click += comboBoxName_SelectedIndexChanged;

            Logger.UserAction(UserLogin, "Открыта форма приёмки товаров");
        }

        /// <summary>
        /// Создаёт DataGridView для списка корзины приёмки
        /// </summary>
        private void CreateDataGridView()
        {
            dgvWarehouse = new DataGridView
            {
                Location = new System.Drawing.Point(520, 90),
                Size = new System.Drawing.Size(520, 400),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = System.Drawing.Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                RowHeadersVisible = false,
                AllowUserToAddRows = false,
                ReadOnly = true,
                Font = new System.Drawing.Font("Segoe UI", 10F),
                Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Left,
            };
            Controls.Add(dgvWarehouse);
        }

        /// <summary>
        /// Загружает список товаров в корзине
        /// </summary>
        public void LoadProducts()
        {
            Logger.UserAction(UserLogin, "Загрузка списка товаров в DataGridView");
            using (var db = new AllDB())
            {
                var acceptance = db.ProductsOnAcceptance.Select(p => new
                {
                    p.Name,
                    p.Count,
                    p.Price,
                    p.ProviderName,
                    p.LoginEmployee,
                }).ToList();
                dgvWarehouse.DataSource = acceptance;
                SetupColumns();
            }
        }

        private void SetupColumns()
        {
            if (dgvWarehouse.Columns[Resources.NameEng] != null)
                dgvWarehouse.Columns[Resources.NameEng].HeaderText = Resources.NameRus;
            if (dgvWarehouse.Columns[Resources.CountEng] != null)
                dgvWarehouse.Columns[Resources.CountEng].HeaderText = Resources.CountRus;
            if (dgvWarehouse.Columns[Resources.PriceEng] != null)
                dgvWarehouse.Columns[Resources.PriceEng].HeaderText = Resources.PriceRus;
            if (dgvWarehouse.Columns[Resources.ProviderNameEng] != null)
                dgvWarehouse.Columns[Resources.ProviderNameEng].HeaderText = Resources.ProviderNameRus;
            if (dgvWarehouse.Columns[Resources.LoginEmployeeEng] != null)
                dgvWarehouse.Columns[Resources.LoginEmployeeEng].HeaderText = Resources.LoginEmployeeRus;
        }

        /// <summary>
        /// Добавляет товар в корзину приёмки
        /// </summary>
        private void buttonAddToBusket_Click(object sender, EventArgs e)
        {
            Logger.UserAction(UserLogin, "Нажата кнопка добавления товара в корзину приёмки");

            using (var db = new AllDB())
            {
                if (comboBoxName.SelectedItem == null)
                {
                    MessageBox.Show(Resources.EnterProductName);
                    return;
                }
                if (!int.TryParse(numCount.Text, out int quantity) || quantity <= 0)
                {
                    MessageBox.Show(Resources.NumberCount);
                    return;
                }
                if (string.IsNullOrWhiteSpace(comboBoxProviderName.Text))
                {
                    MessageBox.Show(Resources.EnterTheProvider);
                    return;
                }
                if (!int.TryParse(numPrice.Text, out int price) || price <= 0)
                {
                    MessageBox.Show(Resources.PurchasePrice);
                    return;
                }

                var productOnAcceptance = new ProductsOnAcceptanceClass(
                    comboBoxName.Text,
                    (double)numCount.Value,
                    numPrice.Value,
                    comboBoxProviderName.Text,
                    UserLogin
                );
                db.ProductsOnAcceptance.Add(productOnAcceptance);
                db.SaveChanges();

                Logger.UserAction(UserLogin, $"Товар '{comboBoxName.Text}' добавлен в корзину");
                LoadProducts();
            }
        }

        private void comboBoxName_SelectedIndexChanged(object sender, EventArgs e)
        {
            Logger.UserAction(UserLogin, "Загрузка списка товаров в комбобокс");
            comboBoxName.Items.Clear();
            using (var db = new AllDB())
            {
                foreach (var card in db.Products)
                    comboBoxName.Items.Add(card.Name);
            }
        }

        /// <summary>
        /// Открывает форму проверки контрагента по ИНН через API.
        /// После успешной проверки и подтверждения данные возвращаются
        /// и поставщик с ИНН проставляются в поля формы.
        /// </summary>
        private void buttonCheckApi_Click(object sender, EventArgs e)
        {
            Logger.UserAction(UserLogin, "Открытие формы проверки контрагента по API");
            var checkForm = new SupplierCheckForm(UserLogin, this);
            checkForm.ShowDialog();
        }

        /// <summary>
        /// Заполняет поле поставщика после успешной проверки по API
        /// </summary>
        public void SetSupplierFromApi(string supplierName, string inn)
        {
            comboBoxProviderName.Text = supplierName;
            Logger.UserAction(UserLogin, $"Поставщик из API: {supplierName}, ИНН: {inn}");
        }

        /// <summary>
        /// Подтверждение приёмки — открывает форму подтверждения
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            Logger.UserAction(UserLogin, "Открытие формы подтверждения приёмки");

            using (var db = new AllDB())
            {
                if (!db.ProductsOnAcceptance.Any())
                {
                    MessageBox.Show(Resources.BusketIsEmpty);
                    return;
                }
            }

            var confirmForm = new AcceptanceConfirmForm(UserLogin, this);
            confirmForm.ShowDialog();
        }

        /// <summary>
        /// Фактически выполняет приёмку — вызывается из AcceptanceConfirmForm при подтверждении
        /// </summary>
        public void ConfirmAcceptance()
        {
            using (var db = new AllDB())
            {
                int acceptedCount = 0;
                foreach (var product in db.ProductsOnAcceptance)
                {
                    var existing = db.Products.FirstOrDefault(p => p.Name == product.Name);
                    if (existing != null)
                    {
                        existing.Rest += product.Count;
                        existing.PurchasePrice = product.Price;
                        acceptedCount++;
                    }
                }
                db.SaveChanges();

                Logger.UserAction(UserLogin, $"Приёмка подтверждена. Принято позиций: {acceptedCount}");
                MessageBox.Show(Resources.Success);

                foreach (var product in db.ProductsOnAcceptance.ToList())
                    db.ProductsOnAcceptance.Remove(product);
                db.SaveChanges();
                LoadProducts();
            }
        }

        private void сменитьАккаунтToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logger.UserAction(UserLogin, "Смена аккаунта из формы приёмки");
            new Authorization().Show();
            Hide();
        }

        private void назадToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logger.UserAction(UserLogin, "Возврат из формы приёмки");
            using (var db = new AllDB())
            {
                var emp = db.Employess.FirstOrDefault(e => e.Login == UserLogin);
                if (emp != null && emp.Job == JobsEnumcs.Administrator)
                    new WarehouseAdmin(UserLogin).Show();
                else
                    new WarehouseStorekeeper(UserLogin).Show();
            }
            Hide();
        }

        private void buttonImport_Click(object sender, EventArgs e)
        {
            Logger.UserAction(UserLogin, "Импорт товаров из JSON");
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "JSON files (*.json)|*.json";
                if (openFileDialog.ShowDialog() != DialogResult.OK) return;
                try
                {
                    string json = File.ReadAllText(openFileDialog.FileName);
                    var products = JsonConvert.DeserializeObject<List<ProductsOnAcceptanceClass>>(json);
                    using (var db = new AllDB())
                    {
                        foreach (var p in products)
                        {
                            db.ProductsOnAcceptance.Add(new ProductsOnAcceptanceClass
                            {
                                Name = p.Name,
                                Count = p.Count,
                                Price = p.Price,
                                ProviderName = p.ProviderName,
                                LoginEmployee = UserLogin,
                            });
                        }
                        db.SaveChanges();
                    }
                    Logger.UserAction(UserLogin, $"Импортировано {products?.Count ?? 0} товаров");
                    MessageBox.Show($"{Resources.Import}: {products?.Count ?? 0} {Resources.Products}");
                    LoadProducts();
                }
                catch (Exception ex)
                {
                    Logger.UserAction(UserLogin, $"Ошибка импорта: {ex.Message}");
                    MessageBox.Show($"Ошибка: {ex.Message}");
                }
            }
        }
    }
}