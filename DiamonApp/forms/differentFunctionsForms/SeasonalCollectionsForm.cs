using DiamonApp.Classes;
using DiamonApp.DataBase;
using Draft_Diamond_BD;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Draft_Diamond_BD
{
    public partial class SeasonalCollectionsForm : Form
    {
        private readonly string _userLogin;
        public SeasonalCollectionsForm(string userLogin)
        {
            InitializeComponent();
            _userLogin = userLogin;
            Logger.UserAction(_userLogin, "Открыта форма сезонных коллекций");
        }
        private void comboBoxTypeProduct_Click(object sender, EventArgs e)
        {
            comboBoxTypeProduct.Items.Clear();
            using var db = new AllDB();
            var first = db.Categories.FirstOrDefault(p => p.Id == 1);
            if (first == null) return;
            foreach (var category in first.NamesOfCategory)
                comboBoxTypeProduct.Items.Add(category);
        }
        private async void buttonSave_Click(object sender, EventArgs e)
        {
            Logger.UserAction(_userLogin, "Сохранение настроек сезона");

            if (comboBoxTypeProduct.SelectedItem is null)
            {
                MessageBox.Show(Resources.EnterTheCategory);
                return;
            }
            if (comboBoxSeasonDuration.SelectedItem is null)
            {
                MessageBox.Show(Resources.EnterSeason);
                return;
            }
            await using var db = new AllDB();
            int.TryParse(comboBoxSeasonDuration.Text, out int month);
            int discountBeforeEnd = (int)numDiscountBeforeEnd.Value;
            double discount = (double)numDiscount.Value;
            var today = DateTime.Today.AddMonths(month);
            int productCount = 0;
            var products = db.Products.Where(p => p.Category == comboBoxTypeProduct.Text).ToList();
            foreach (var product in products)
            {
                product.EndDateOfTheDay = today;
                product.UntilTheEndOfTheSeason = month * 4;
                product.DiscountBeforeEnd = discountBeforeEnd;
                product.Discount = discount;
                product.FinalyPrice = product.PurchasePrice - (product.PurchasePrice * (decimal)discount) / 100;
                productCount++;
            }
            await db.SaveChangesAsync();
            Logger.UserAction(_userLogin, $"Обновлено {productCount} товаров в категории '{comboBoxTypeProduct.Text}', сезон до {today:d}");
            MessageBox.Show(Resources.Success);
        }
        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logger.UserAction(_userLogin, "Возврат на форму администратора");
            new WarehouseAdmin(_userLogin).Show();
            Hide();
        }
    }
}