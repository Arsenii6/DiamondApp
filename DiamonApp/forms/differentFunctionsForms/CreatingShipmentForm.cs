using DiamonApp.Forms.DifferentFunctionsForms;
using System.Globalization;
using Newtonsoft.Json.Linq;
namespace DiamonApp.forms.differentFunctionsForms
{
    public partial class CreatingShipmentForm : Form
    {
        private DataGridView? dgvWarehouse;
        private string UserLogin;
        private string _verifiedInn = "";
        private string _verifiedCustomerName = "";
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
            {
                comboBoxRegion.Items.AddRange(new object[] { "Москва", "Санкт-Петербург", "Новосибирск" });
            }
            comboBoxRegion.SelectedIndex = 0;

            LoadProducts();

            Logger.UserAction(UserLogin, "Открыта форма создания отгрузки");
        }
        private void CreateDataGridView()
        {
            dgvWarehouse = new DataGridView
            {
                Location = new Point(620, 104),
                Size = new Size(980, 440),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                RowHeadersVisible = false,
                AllowUserToAddRows = false,
                ReadOnly = true,
                Font = new Font("Segoe UI", 10F),
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                ScrollBars = ScrollBars.Both,
                ColumnHeadersHeight = 32,
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing,
            };
            dgvWarehouse.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            Controls.Add(dgvWarehouse);
        }
        public void LoadProducts()
        {
            using var db = new AllDB();
            var shipments = db.ProductsOnShipments.ToList();
            var list = new List<object>();

            foreach (var p in shipments)
            {
                string weather = _weatherCache.TryGetValue(p.Region, out var w) ? w : "—";
                var t = ParseTemperature(weather);
                string container = t.HasValue ? (t.Value < 0 ? "Да" : "Нет") : "—";

                list.Add(new
                {
                    Название = p.Name,
                    Количество = p.Count,
                    Кому = p.CustomerName,
                    ИНН_контрагента = _verifiedInn,
                    Куда = p.CustomerPlace,
                    Регион = p.Region,
                    Кто = p.LoginStorekeeper,
                    Страховка = p.Insurance,
                    Погода_в_регионе = weather,
                    Контейнер = container,
                });
            }
            if (dgvWarehouse != null)
            {
                dgvWarehouse.DataSource = list;
                foreach (DataGridViewColumn col in dgvWarehouse.Columns)
                    col.HeaderText = col.HeaderText.Replace("_", " ");
            }
        }
        private void comboBoxName_SelectedIndexChanged(object? sender, EventArgs e)
        {
            comboBoxName.Items.Clear();
            using var db = new AllDB();
            foreach (var card in db.Products)
                comboBoxName.Items.Add(card.Name);
        }
        private void comboBoxUniteOfMeasure_SelectedIndexChanged(object? sender, EventArgs e)
        {
            comboBoxUniteOfMeasure.Items.Clear();
            using var db = new AllDB();
            var units = db.UniteOfMeasures.FirstOrDefault(p => p.Id == 1);
            if (units != null)
            {
                foreach (var u in units.UnitesOfMeasure)
                    comboBoxUniteOfMeasure.Items.Add(u);
            }
        }
        private void buttonAddToBusket_Click(object? sender, EventArgs e)
        {
            using var db = new AllDB();

            if (comboBoxName.SelectedItem == null)
            {
                MessageBox.Show(Resources.EnterProductName);
                return;
            }
            if (comboBoxUniteOfMeasure.SelectedItem == null ||
                comboBoxUniteOfMeasure.Text != db.Products.FirstOrDefault(p => p.Name == comboBoxName.Text)?.UniteOfMeasure)
            {
                MessageBox.Show(Resources.ChoseUniteOfMeasure);
                return;
            }
            var product = db.Products.FirstOrDefault(p => p.Name == comboBoxName.Text);
            if (!int.TryParse(numCount.Text, out int qty) || qty <= 0 || qty > product?.Rest)
            {
                MessageBox.Show(Resources.NumberCount);
                return;
            }
            if (string.IsNullOrWhiteSpace(_verifiedCustomerName))
            {
                MessageBox.Show("Сначала проверьте контрагента по API (кнопка «Проверить»).");
                return;
            }
            if (string.IsNullOrWhiteSpace(comboBoxCustomerPlace.Text))
            {
                MessageBox.Show(Resources.EnterAddressDelivery);
                return;
            }

            var entry = new ProductsOnShipmentClass(
                comboBoxName.Text,
                (int)numCount.Value,
                numSumProduct.Value,
                _verifiedCustomerName,
                comboBoxCustomerPlace.Text,
                UserLogin
            );
            entry.Region = comboBoxRegion.Text;
            entry.Insurance = "—";

            db.ProductsOnShipments.Add(entry);
            db.SaveChanges();

            Logger.UserAction(UserLogin, $"'{comboBoxName.Text}' добавлен, регион: {entry.Region}");
            LoadProducts();
        }
        private void buttonVerify_Click(object? sender, EventArgs e)
        {
            var checkForm = new ShipmentCheckForm(UserLogin, this);
            checkForm.ShowDialog();
        }
        public void SetCustomerFromApi(string customerName, string inn)
        {
            _verifiedCustomerName = customerName;
            _verifiedInn = inn;
            comboBoxCustomerName.Text = customerName;
        }
        private void InsuranceToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            var insuranceForm = new InsuranceForm(UserLogin, this);
            insuranceForm.ShowDialog();
        }
        public void SetInsurance(Guid shipmentId, string insuranceName)
        {
            using var db = new AllDB();
            var shipment = db.ProductsOnShipments.FirstOrDefault(p => p.Id == shipmentId);
            if (shipment != null)
            {
                shipment.Insurance = insuranceName;
                db.SaveChanges();
                Logger.UserAction(UserLogin, $"Страховка '{insuranceName}' → запись Id={shipmentId}");
                LoadProducts();
            }
        }
        public List<(Guid Id, string Display)> GetShipmentsForInsurance()
        {
            var result = new List<(Guid, string)>();
            using var db = new AllDB();
            foreach (var p in db.ProductsOnShipments.ToList())
            {
                result.Add((p.Id, $"{p.Name} (кол-во: {p.Count}, регион: {p.Region})"));
            }
            return result;
        }
        private async void weatherToolStripMenuItem_Click(object? sender, EventArgs e)
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
                MessageBox.Show("Погода загружена для всех регионов.", "Погода", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки погоды:\n{ex.Message}");
                Logger.UserAction(UserLogin, $"Ошибка загрузки погоды: {ex.Message}");
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
                         $"?latitude={lat.ToString(CultureInfo.InvariantCulture)}" +
                         $"&longitude={lon.ToString(CultureInfo.InvariantCulture)}" +
                         $"&current=temperature_2m,wind_speed_10m,relative_humidity_2m&timezone=auto";

            string json = await client.GetStringAsync(url);
            var obj = JObject.Parse(json);
            var current = obj["current"];

            double temp = current?["temperature_2m"]?.Value<double>() ?? 0;
            double wind = current?["wind_speed_10m"]?.Value<double>() ?? 0;
            int humidity = current?["relative_humidity_2m"]?.Value<int>() ?? 0;

            return $"{temp:F0}°C, ветер {wind:F0} м/с, влажность {humidity}%";
        }
        private static double? ParseTemperature(string text)
        {
            if (string.IsNullOrWhiteSpace(text) || text == "—") return null;
            try
            {
                int i = text.IndexOf('°');
                if (i <= 0) return null;
                if (double.TryParse(text[..i].Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out double t))
                    return t;
            }
            catch { }
            return null;
        }
        private void buttonShipment_Click(object? sender, EventArgs e)
        {
            using var db = new AllDB();
            if (!db.ProductsOnShipments.Any())
            {
                MessageBox.Show(Resources.BusketIsEmpty);
                return;
            }
            var confirmForm = new ShipmentConfirmForm(UserLogin, this);
            confirmForm.ShowDialog();
        }
        public void ConfirmShipment()
        {
            using var db = new AllDB();
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

            Logger.UserAction(UserLogin, $"Отгружено: {shippedCount}, сумма: {sumShipment}");
            MessageBox.Show(Resources.Success);

            var storekeeperForm = new WarehouseStorekeeper(UserLogin);
            storekeeperForm.Show();
            Close();
        }
        private void BackToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            var storekeeperForm = new WarehouseStorekeeper(UserLogin);
            storekeeperForm.Show();
            Hide();
        }
        private void сменитьАккаунтToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            var authForm = new Authorization();
            authForm.Show();
            Hide();
        }
    }
}