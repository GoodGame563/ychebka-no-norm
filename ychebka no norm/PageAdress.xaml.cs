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

namespace ychebka_no_norm
{
    /// <summary>
    /// Логика взаимодействия для PageAdress.xaml
    /// </summary>
    public partial class PageAdress : Page
    {
        RealtorsStoreContext db;
        public PageAdress()
        {
            InitializeComponent();

            db = new RealtorsStoreContext();
            db.Addresses.Load();
            AdressGrid.ItemsSource = db.Addresses.Local.ToBindingList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            db.SaveChanges();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Address address = new() {City = city.Text, Street = street.Text, House = house.Text, Number = number.Text};
            db.Addresses.Add(address);
        }
    }
}
