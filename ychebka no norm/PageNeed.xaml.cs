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
    /// Логика взаимодействия для PageNeed.xaml
    /// </summary>
    public partial class PageNeed : Page
    {
        RealtorsStoreContext db;
        public PageNeed()
        {
            InitializeComponent();

            db = new RealtorsStoreContext();
            db.Needs.Load();
            NeedGrid.ItemsSource = db.Needs.Local.ToBindingList();
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
        }
        public class AllInfo
        {
            public string FioClient { get; set; }
            public string FioRialtor { get; set; }
            public string Addres { get; set; }
        }
        private void NeedGrid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            AllGrid.Items.Clear();
            var dataGrid = sender as DataGrid;
            if (dataGrid != null)
            {
                var index = dataGrid.CurrentItem as Need;

                var client = db.Clients.Find(index?.Client);
                var rialtoe = db.Realtors.Find(index?.Realtor);
                var addres = db.Addresses.Find(index?.Address);

                AllInfo allInfo = new AllInfo()
                {
                    FioClient = $"{client?.FirstName} {client?.MiddleName} {client?.LastName}",
                    FioRialtor =$"{rialtoe?.FirstName} {rialtoe?.MiddleName} {rialtoe?.LastName}",
                    Addres = $"{addres?.City} {addres?.Street} {addres?.House} {addres?.Number}"

                };
                AllGrid.Items.Add(allInfo);
            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            db.SaveChanges();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
