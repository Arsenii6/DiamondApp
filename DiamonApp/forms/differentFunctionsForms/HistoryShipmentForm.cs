using DiamonApp.Classes;
using DiamonApp.DataBase;
using DiamonApp.Enums;
using Draft_Diamond_BD;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DiamonApp.forms.differentFunctionsForms
{
    public partial class HistoryShipmentForm : Form
    {
        private DataGridView dgvWarehouse;
        private string userLogin;

        public HistoryShipmentForm(string login)
        {
            InitializeComponent();
            userLogin = login;
            labelLogin.Text = Resources.LoginInMenu + userLogin;
            CreateDataGridView();
            LoadProducts();
            comboBoxFiter.Click += (s, a) => LoadStorekeepersInFilter();

            Logger.UserAction(userLogin, "Открыта форма истории отгрузок");
        }

        private void CreateDataGridView()
        {
            dgvWarehouse = new DataGridView
            {
                Location = new Point(10, 200),
                Size = new Size(1000, 250),
                Margin = new Padding(10, 10, 10, 10),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = System.Drawing.Color.DarkGray,
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top,
            };
            Controls.Add(dgvWarehouse);
        }

        public void LoadProducts()
        {
            Logger.UserAction(userLogin, "Загрузка истории отгрузок");
            using var db = new AllDB();
            var products = db.HistoryShipment.Select(p => new
            {
                p.DateShipment,
                p.ProductsName,
                p.UniteOfMeasure,
                p.Count,
                p.SumShipment,
                p.Profit,
                p.CustomerName,
                p.CustomerPlace,
                p.LoginStorekeeper,
                p.Id,
            }).ToList();
            dgvWarehouse.DataSource = products;
            SetupColumns();
        }

        private void LoadStorekeepersInFilter()
        {
            Logger.UserAction(userLogin, "Загрузка списка кладовщиков для фильтрации");
            var startDate = date1.Value;
            var endDate = date2.Value;
            comboBoxFiter.Items.Clear();

            using var db = new AllDB();
            foreach (var empl in db.Employess.ToList())
            {
                if (empl.Job == JobsEnumcs.Storekeeper)
                    comboBoxFiter.Items.Add(empl.Login);
            }

            comboBoxFiter.SelectedIndexChanged += (s, e) =>
            {
                Logger.UserAction(userLogin, $"Фильтрация по кладовщику: {comboBoxFiter.SelectedItem}");
                using var db = new AllDB();
                var selectedLogin = comboBoxFiter.SelectedItem.ToString();
                var shipments = db.HistoryShipment
                    .Where(p => p.LoginStorekeeper == selectedLogin &&
                               (p.DateShipment.Date >= startDate && p.DateShipment.Date <= endDate))
                    .Select(p => new
                    {
                        p.DateShipment,
                        p.ProductsName,
                        p.UniteOfMeasure,
                        p.Count,
                        p.SumShipment,
                        p.Profit,
                        p.CustomerName,
                        p.CustomerPlace,
                        p.LoginStorekeeper,
                        p.Id,
                    }).ToList();
                dgvWarehouse.DataSource = shipments;
                SetupColumns();
            };
        }

        private void SetupColumns()
        {
            if (dgvWarehouse.Columns["DateShipment"] != null)
                dgvWarehouse.Columns["DateShipment"].HeaderText = "Дата";
            if (dgvWarehouse.Columns["ProductsName"] != null)
                dgvWarehouse.Columns["ProductsName"].HeaderText = "Имя";
            if (dgvWarehouse.Columns["UniteOfMeasure"] != null)
                dgvWarehouse.Columns["UniteOfMeasure"].HeaderText = "Единица измерения";
            if (dgvWarehouse.Columns["Count"] != null)
                dgvWarehouse.Columns["Count"].HeaderText = "Количество";
            if (dgvWarehouse.Columns["SumShipment"] != null)
                dgvWarehouse.Columns["SumShipment"].HeaderText = "Сумма отгрузки";
            if (dgvWarehouse.Columns["Profit"] != null)
                dgvWarehouse.Columns["Profit"].HeaderText = "Прибыль";
            if (dgvWarehouse.Columns["CustomerName"] != null)
                dgvWarehouse.Columns["CustomerName"].HeaderText = "Кому";
            if (dgvWarehouse.Columns["CustomerPlace"] != null)
                dgvWarehouse.Columns["CustomerPlace"].HeaderText = "Куда";
            if (dgvWarehouse.Columns["LoginStorekeeper"] != null)
                dgvWarehouse.Columns["LoginStorekeeper"].HeaderText = "Кто создал";
            if (dgvWarehouse.Columns["Id"] != null)
                dgvWarehouse.Columns["Id"].HeaderText = "ID отгрузки";
        }

        private void buttonListWaredhouse_Click(object sender, EventArgs e)
        {
            Logger.UserAction(userLogin, "Переход на форму складского администратора из истории отгрузок");
            var newWarehouseAdmine = new WarehouseAdmin(userLogin);
            newWarehouseAdmine.Show();
            Close();
        }

        private void buttonShow_Click(object sender, EventArgs e)
        {
            Logger.UserAction(userLogin, $"Показать отгрузки за период: {date1.Value:d} - {date2.Value:d}");

            if (date1.Value.Date > date2.Value.Date)
            {
                Logger.UserAction(userLogin, "Ошибка: дата начала позже даты окончания");
                MessageBox.Show(Resources.Data1AndData2);
                return;
            }

            using var db = new AllDB();
            var startDate = date1.Value;
            var endDate = date2.Value;
            var listShip1 = db.HistoryShipment
                .Where(p => p.DateShipment.Date >= startDate && p.DateShipment.Date <= endDate)
                .Select(p => new
                {
                    p.DateShipment,
                    p.ProductsName,
                    p.UniteOfMeasure,
                    p.Count,
                    p.SumShipment,
                    p.Profit,
                    p.CustomerName,
                    p.CustomerPlace,
                    p.LoginStorekeeper,
                    p.Id,
                }).ToList();
            dgvWarehouse.DataSource = listShip1;
            SetupColumns();

            Logger.UserAction(userLogin, $"Найдено отгрузок: {listShip1.Count}");
        }

        private void buttonExportTheReport_Click(object sender, EventArgs e)
        {
            Logger.UserAction(userLogin, "Экспорт отчёта в CSV");

            if (dgvWarehouse.DataSource == null)
            {
                Logger.UserAction(userLogin, "Ошибка: нет данных для экспорта");
                MessageBox.Show(Resources.NoDataForExport);
                return;
            }

            var exportList = new List<object>();
            if (dgvWarehouse.DataSource is IEnumerable enumerable)
            {
                foreach (var item in enumerable)
                    exportList.Add(item);
            }

            if (exportList.Count == 0)
            {
                Logger.UserAction(userLogin, "Ошибка: невозможно прочитать отгрузки для экспорта");
                MessageBox.Show(Resources.NotReadingShipments);
                return;
            }

            var saveFile = new SaveFileDialog
            {
                Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = true,
                FileName = $"Отгрузки_{DateTime.Now:M}.csv"
            };

            if (saveFile.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                var properties = exportList[0].GetType().GetProperties();
                var headers = properties.Select(p =>
                {
                    var col = dgvWarehouse.Columns[p.Name];
                    return EscapeCsv(col != null ? col.HeaderText : p.Name);
                });

                var sb = new StringBuilder();
                sb.AppendLine(string.Join(";", headers));

                foreach (var item in exportList)
                {
                    var values = properties.Select(p => EscapeCsv(p.GetValue(item)?.ToString() ?? ""));
                    sb.AppendLine(string.Join(";", values));
                }

                File.WriteAllText(saveFile.FileName, sb.ToString(), Encoding.UTF8);

                Logger.UserAction(userLogin, $"Экспортировано {exportList.Count} записей в файл: {saveFile.FileName}");
                MessageBox.Show(Resources.Success);
            }
            catch (Exception ex)
            {
                Logger.UserAction(userLogin, $"Ошибка при экспорте: {ex.Message}");
                MessageBox.Show($"{Resources.ErrorExport} {ex.Message}");
            }
        }

        private static string EscapeCsv(string value)
        {
            if (value.Contains(';') || value.Contains('"') || value.Contains('\n'))
                return $"\"{value.Replace("\"", "\"\"")}\"";
            return value;
        }
    }
}