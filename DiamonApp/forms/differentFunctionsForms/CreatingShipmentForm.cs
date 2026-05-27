using DiamonApp.Classes;
using DiamonApp.DataBase;
using DiamondApp.Resourses;
using Draft_Diamond_BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiamonApp.forms.differentFunctionsForms
{
    public partial class CreatingShipmentForm : Form
    {
        private DataGridView? dgvWarehouse;
        private string UserLogin;

        private string _verifiedInn = "";
        private string _verifiedCustomerName = "";
        private string _selectedRegion = "Москва";

        // ─── Хранилище данных каждой строки корзины ───────────────────────────
        // Ключ: уникальный Id записи из ProductsOnShipments (int, из БД)
        // Значение: все доп. данные строки — регион, погода, контейнер, страховка
        private class RowData
        {
            public string Region { get; set; } = "Москва";
            public string Weather { get; set; } = "—";
            public string Container { get; set; } = "—";
            public string Insurance { get; set; } = "—";
        }
        private Dictionary<Guid, RowData> _rows = new();

        // Кэш погоды по региону
        private Dictionary<string, string> _weatherCache = new();

        private static readonly Dictionary<string, (double lat, double lon)> RegionCoords = new()
        {
            ["Москва"] = (55.7558, 37.6176),
            ["Санкт-Петербург"] = (59.9343, 30.3351),
            ["Новосибирск"] = (54.9924, 82.9086),
        };

        public CreatingShipmentForm(string userLogin)
        {
            InitializeComponent();
            UserLogin = userLogin;
            labelLogin.Text = Resources.LoginInMenu + userLogin;
            CreateDataGridView();

            if (comboBoxRegion.Items.Count == 0)
                comboBoxRegion.Items.AddRange(new object[] { "Москва", "Санкт-Петербург", "Новосибирск" });
            comboBoxRegion.SelectedIndex = 0;

            LoadProducts();
            comboBoxName.Click += comboBoxName_SelectedIndexChanged;
            comboBoxUniteOfMeasure.Click += comboBoxUniteOfMeasure_SelectedIndexChanged;
            comboBoxRegion.SelectedIndexChanged += ComboBoxRegion_SelectedIndexChanged;
            insuranceToolStripMenuItem.Click += InsuranceToolStripMenuItem_Click;

            Logger.UserAction(UserLogin, "Открыта форма создания отгрузки");
        }

        private void CreateDataGridView()
        {
            dgvWarehouse = new DataGridView
            {
                Location = new System.Drawing.Point(600, 74),
                Size = new System.Drawing.Size(980, 440),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = System.Drawing.Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                RowHeadersVisible = false,
                AllowUserToAddRows = false,
                ReadOnly = true,
                Font = new System.Drawing.Font("Segoe UI", 10F),
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                ScrollBars = System.Windows.Forms.ScrollBars.Both,
                ColumnHeadersHeight = 32,
                ColumnHeadersHeightSizeMode =
                    System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing,
            };
            dgvWarehouse.ColumnHeadersDefaultCellStyle.Font =
                new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            Controls.Add(dgvWarehouse);
        }

        private void ComboBoxRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxRegion.SelectedIndex >= 0)
                _selectedRegion = comboBoxRegion.Text;
        }

        /// <summary>
        /// Загружает таблицу. Для каждой строки берёт данные из _rows по Id записи.
        /// Если погода загружена — обновляет погоду и контейнер, сохраняя регион строки.
        /// </summary>
        public void LoadProducts()
        {
            using (var db = new AllDB())
            {
                var shipments = db.ProductsOnShipments.ToList();
                var list = new List<object>();

                foreach (var p in shipments)
                {
                    // Берём или создаём данные строки по Id из БД
                    if (!_rows.ContainsKey(p.Id))
                        _rows[p.Id] = new RowData { Region = _selectedRegion };

                    var row = _rows[p.Id];

                    // Если погода загружена для региона этой строки — обновляем
                    if (_weatherCache.TryGetValue(row.Region, out var cachedWeather))
                    {
                        row.Weather = cachedWeather;
                        var t = ParseTemperature(cachedWeather);
                        row.Container = t.HasValue ? (t.Value < 0 ? "Да" : "Нет") : "—";
                    }

                    list.Add(new
                    {
                        Название = p.Name,
                        Количество = p.Count,
                        Кому = p.CustomerName,
                        ИНН_контрагента = _verifiedInn,
                        Куда = p.CustomerPlace,
                        Регион = row.Region,
                        Кто = p.LoginStorekeeper,
                        Страховка = row.Insurance,
                        Погода_в_регионе = row.Weather,
                        Контейнер = row.Container,
                    });
                }

                dgvWarehouse.DataSource = list;
                foreach (DataGridViewColumn col in dgvWarehouse.Columns)
                    col.HeaderText = col.HeaderText.Replace("_", " ");
            }
        }

        private void comboBoxName_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxName.Items.Clear();
            using (var db = new AllDB())
                foreach (var card in db.Products)
                    comboBoxName.Items.Add(card.Name);
        }

        private void comboBoxUniteOfMeasure_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxUniteOfMeasure.Items.Clear();
            using (var db = new AllDB())
            {
                var units = db.UniteOfMeasures.FirstOrDefault(p => p.Id == 1);
                if (units != null)
                    foreach (var u in units.UnitesOfMeasure)
                        comboBoxUniteOfMeasure.Items.Add(u);
            }
        }

        private void buttonAddToBusket_Click(object sender, EventArgs e)
        {
            using (var db = new AllDB())
            {
                if (comboBoxName.SelectedItem == null)
                { MessageBox.Show(Resources.EnterProductName); return; }

                if (comboBoxUniteOfMeasure.SelectedItem == null ||
                    comboBoxUniteOfMeasure.Text !=
                        db.Products.FirstOrDefault(p => p.Name == comboBoxName.Text)?.UniteOfMeasure)
                { MessageBox.Show(Resources.ChoseUniteOfMeasure); return; }

                var product = db.Products.FirstOrDefault(p => p.Name == comboBoxName.Text);
                if (!int.TryParse(numCount.Text, out int qty) || qty <= 0 || qty > product?.Rest)
                { MessageBox.Show(Resources.NumberCount); return; }

                if (string.IsNullOrWhiteSpace(_verifiedCustomerName))
                { MessageBox.Show("Сначала проверьте контрагента по API (кнопка «Проверить»)."); return; }

                if (string.IsNullOrWhiteSpace(comboBoxCustomerPlace.Text))
                { MessageBox.Show(Resources.EnterAddressDelivery); return; }

                var entry = new ProductsOnShipmentClass(
                    comboBoxName.Text,
                    (int)numCount.Value,
                    numSumProduct.Value,
                    _verifiedCustomerName,
                    comboBoxCustomerPlace.Text,
                    UserLogin
                );
                db.ProductsOnShipments.Add(entry);
                db.SaveChanges();  // после SaveChanges entry.Id заполнен

                // Создаём данные строки сразу с выбранным регионом и текущей погодой
                string weather = _weatherCache.TryGetValue(_selectedRegion, out var w) ? w : "—";
                var t = ParseTemperature(weather);
                _rows[entry.Id] = new RowData
                {
                    Region = _selectedRegion,
                    Weather = weather,
                    Container = t.HasValue ? (t.Value < 0 ? "Да" : "Нет") : "—",
                    Insurance = "—",
                };

                Logger.UserAction(UserLogin, $"'{comboBoxName.Text}' добавлен, регион: {_selectedRegion}");
                LoadProducts();
            }
        }

        private void buttonVerify_Click(object sender, EventArgs e)
        {
            new ShipmentCheckForm(UserLogin, this).ShowDialog();
        }

        public void SetCustomerFromApi(string customerName, string inn)
        {
            _verifiedCustomerName = customerName;
            _verifiedInn = inn;
            comboBoxCustomerName.Text = customerName;
        }

        private void InsuranceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new InsuranceForm(UserLogin, this).ShowDialog();
        }

        /// <summary>
        /// Устанавливает страховку для конкретной строки по Id записи в БД.
        /// Вызывается из InsuranceForm.
        /// </summary>
        public void SetInsurance(Guid shipmentId, string insuranceName)
        {
            if (_rows.ContainsKey(shipmentId))
            {
                _rows[shipmentId].Insurance = insuranceName;
                Logger.UserAction(UserLogin, $"Страховка '{insuranceName}' → запись Id={shipmentId}");
                LoadProducts();
            }
        }

        /// <summary>
        /// Возвращает список строк корзины для InsuranceForm:
        /// Id → отображаемое название
        /// </summary>
        public List<(Guid Id, string Display)> GetShipmentsForInsurance()
        {
            var result = new List<(Guid, string)>();
            using (var db = new AllDB())
            {
                foreach (var p in db.ProductsOnShipments.ToList())
                    result.Add((p.Id, $"{p.Name}  (кол-во: {p.Count}, регион: {(_rows.ContainsKey(p.Id) ? _rows[p.Id].Region : "—")})"));
            }
            return result;
        }

        private async void weatherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            weatherToolStripMenuItem.Enabled = false;
            weatherToolStripMenuItem.Text = "Загрузка...";
            try
            {
                foreach (var region in RegionCoords)
                {
                    string w = await FetchWeatherAsync(region.Value.lat, region.Value.lon);
                    _weatherCache[region.Key] = w;
                    Logger.UserAction(UserLogin, $"Погода {region.Key}: {w}");
                }
                MessageBox.Show("Погода загружена.", "Погода", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки погоды:\n{ex.Message}");
            }
            finally
            {
                weatherToolStripMenuItem.Enabled = true;
                weatherToolStripMenuItem.Text = "Загрузка погоды";
            }
        }

        private static async Task<string> FetchWeatherAsync(double lat, double lon)
        {
            using var client = new HttpClient();
            client.Timeout = TimeSpan.FromSeconds(10);
            string url = $"https://api.open-meteo.com/v1/forecast" +
                         $"?latitude={lat.ToString(System.Globalization.CultureInfo.InvariantCulture)}" +
                         $"&longitude={lon.ToString(System.Globalization.CultureInfo.InvariantCulture)}" +
                         $"&current=temperature_2m,wind_speed_10m,relative_humidity_2m&timezone=auto";
            string json = await client.GetStringAsync(url);
            using var doc = JsonDocument.Parse(json);
            var cur = doc.RootElement.GetProperty("current");
            double temp = cur.GetProperty("temperature_2m").GetDouble();
            double wind = cur.GetProperty("wind_speed_10m").GetDouble();
            int humidity = cur.GetProperty("relative_humidity_2m").GetInt32();
            return $"{temp:F0}°C, ветер {wind:F0} м/с, влажность {humidity}%";
        }

        private static double? ParseTemperature(string text)
        {
            if (string.IsNullOrWhiteSpace(text) || text == "—") return null;
            try
            {
                int i = text.IndexOf('°');
                if (i <= 0) return null;
                if (double.TryParse(text[..i].Trim(),
                    System.Globalization.NumberStyles.Any,
                    System.Globalization.CultureInfo.InvariantCulture, out double t))
                    return t;
            }
            catch { }
            return null;
        }

        private void buttonShipment_Click(object sender, EventArgs e)
        {
            using (var db = new AllDB())
            {
                if (!db.ProductsOnShipments.Any())
                { MessageBox.Show(Resources.BusketIsEmpty); return; }
            }
            new ShipmentConfirmForm(UserLogin, this).ShowDialog();
        }

        public void ConfirmShipment()
        {
            using (var db = new AllDB())
            {
                decimal sumShipment = 0;
                var productsNames = new StringBuilder();
                int shippedCount = 0;

                foreach (var product in db.ProductsOnShipments.ToList())
                {
                    var existing = db.Products.FirstOrDefault(p => p.Name == product.Name);
                    if (existing != null)
                    {
                        existing.Rest -= product.Count;
                        productsNames.Append($"{existing.Name};");
                        sumShipment += existing.PurchasePrice + numSumProduct.Value;
                        shippedCount++;
                    }
                    db.SaveChanges();
                }

                var history = new HistoryShipment(
                    productsNames.ToString(), "",
                    DateTime.Today, (int)numCount.Value,
                    sumShipment, 0,
                    _verifiedCustomerName, comboBoxCustomerPlace.Text, UserLogin
                );
                db.HistoryShipment.Add(history);

                foreach (var p in db.ProductsOnShipments.ToList())
                    db.ProductsOnShipments.Remove(p);
                db.SaveChanges();

                _rows.Clear();
                Logger.UserAction(UserLogin, $"Отгружено: {shippedCount}, сумма: {sumShipment}");
                MessageBox.Show(Resources.Success);
                new WarehouseStorekeeper(UserLogin).Show();
                Close();
            }
        }

        private void BackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new WarehouseStorekeeper(UserLogin).Show();
            Hide();
        }

        private void сменитьАккаунтToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Authorization().Show();
            Hide();
        }
    }
}