using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
    /// Логика взаимодействия для PageClient.xaml
    /// </summary>
    public partial class PageClient : Page
    {
        RealtorsStoreContext db;
        public PageClient()
        {
            InitializeComponent();

            db = new RealtorsStoreContext();
            db.Clients.Load();
            ClientGrid.ItemsSource = db.Clients.Local.ToBindingList();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            db.SaveChanges();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Client client = new() {LastName = patronymic?.Text, Email = email?.Text, FirstName = name?.Text, MiddleName = surname?.Text, Phone = phone?.Text };
            db.Clients.Add(client);
        }

    }
}
