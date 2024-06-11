using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ychebka_no_norm.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace ychebka
{
    /// <summary>
    /// Логика взаимодействия для PageDeal.xaml
    /// </summary>
    public partial class PageDeal : Page
    {
        RealtorsStoreContext db;
        public PageDeal()
        {
            InitializeComponent();
            db = new RealtorsStoreContext();
            db.Deals.Load();
            DealGrid.ItemsSource = db.Deals.Local.ToBindingList();
            db.Needs.Load();
            var a = db.Needs.Local.ToBindingList();
            List<String> ids = new();
            for (int i = 0; i < a.Count; i++)
            {
                ids.Add($"{a[i].Id} {db.Clients.Find(a[i].Client)?.FirstName} {db.Clients.Find(a[i].Client)?.MiddleName} {db.Clients.Find(a[i].Client)?.LastName} {a[i].EstateType}");
            }
            needComboBox.ItemsSource = ids;
            db.Suggestions.Load();
            var b = db.Suggestions.Local.ToBindingList();
            List<String> ids1 = new();
            for (int i = 0; i < b.Count; i++)
            {
                ids1.Add($"{b[i].Id} {db.Realtors.Find(b[i].Realtor)?.FirstName} {db.Realtors.Find(b[i].Realtor)?.MiddleName} {db.Realtors.Find(b[i].Realtor)?.LastName} {b[i].Price}");
            }
            suggestionComboBox.ItemsSource = ids1;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            db.SaveChanges();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if( suggestionComboBox.SelectedIndex == -1 || needComboBox.SelectedIndex == -1)
            { return; }
            Deal deal = new Deal() { Need = int.Parse(needComboBox.SelectedItem.ToString().Split(" ")[0]), Suggestion = int.Parse(suggestionComboBox.SelectedItem.ToString().Split(" ")[0]) };
            db.Deals.Add(deal);

        }
    }
}
