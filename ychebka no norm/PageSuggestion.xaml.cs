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

namespace ychebka
{
    /// <summary>
    /// Логика взаимодействия для PageSuggestion.xaml
    /// </summary>
    public partial class PageSuggestion : Page
    {
        RealtorsStoreContext db;
        public PageSuggestion()
        {
            InitializeComponent();
            db = new RealtorsStoreContext();
            db.Suggestions.Load();
            SuggestionGrid.ItemsSource = db.Suggestions.Local.ToBindingList();
            db.Clients.Load();
            var a = db.Clients.Local.ToBindingList();
            List<String> ids = new();
            for (int i = 0; i < a.Count; i++)
            {
                ids.Add($"{a[i].Id} {(a[i].FirstName)} {a[i].MiddleName} {a[i].LastName}");
            }
            clientComboBox.ItemsSource = ids;
            db.Realtors.Load();
            var b = db.Realtors.Local.ToBindingList();
            List<String> ids1 = new();
            for (int i = 0; i < b.Count; i++)
            {
                ids1.Add($"{b[i].Id} {(b[i].FirstName)} {b[i].MiddleName} {b[i].LastName}");
            }
            rieltorComboBox.ItemsSource = ids1;
            db.Estates.Load();
            var c = db.Estates.Local.ToBindingList();
            List<String> ids2 = new();
            for (int i = 0; i < c.Count; i++)
            {
                ids2.Add($"{c[i].Id} {(c[i].Address)} {c[i].District}");
            }
            estateComboBox.ItemsSource = ids2;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            db.SaveChanges();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (estateComboBox.SelectedIndex == -1 || rieltorComboBox.SelectedIndex == -1 || clientComboBox.SelectedIndex == -1)
            {
                return;
            }
            Suggestion suggestion = new() { 
                Client = int.Parse(clientComboBox.SelectedItem.ToString().Split(" ")[0]),
                Realtor = int.Parse(rieltorComboBox.SelectedItem.ToString().Split(" ")[0]),
                Estate = int.Parse(estateComboBox.SelectedItem.ToString().Split(" ")[0]),
                Price = decimal.Parse(price.Text)

            };
            db.Suggestions.Add(suggestion);
        }
    }
}
