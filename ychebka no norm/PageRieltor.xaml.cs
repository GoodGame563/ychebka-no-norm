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
    /// Логика взаимодействия для PageRieltor.xaml
    /// </summary>
    public partial class PageRieltor : Page
    {
        RealtorsStoreContext db;
        public PageRieltor()
        {
            InitializeComponent();

            db = new RealtorsStoreContext();
            db.Realtors.Load();
            RieltorGrid.ItemsSource = db.Realtors.Local.ToBindingList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            db.SaveChanges();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Realtor realtor = new() {LastName = patronymic.Text, FirstName = name.Text, MiddleName = surname.Text, Comission = int.Parse(phone.Text)};
            db.Realtors.Add(realtor);
        }
    }
}
