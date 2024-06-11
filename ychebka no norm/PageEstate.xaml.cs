using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Operation.Overlay;
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
    /// Логика взаимодействия для PageEstate.xaml
    /// </summary>
    public partial class PageEstate : Page
    {
        RealtorsStoreContext db;
        public PageEstate()
        {
            InitializeComponent();
            db = new RealtorsStoreContext();
            var a = db.Districts.ToList();
            List<String> ids1 = new();
            for (int i = 0; i < a.Count; i++)
            {
                ids1.Add($"{a[i].Name}");
            }
            districtComboBox.ItemsSource = ids1;


            db.Estates.Load();
            EstateGrid.ItemsSource = db.Estates.Local.ToBindingList();

            db.Addresses.Load();
            var c = db.Addresses.Local.ToBindingList();
            List<String> ids2 = new();
            for (int i = 0; i < c.Count; i++)
            {
                ids2.Add($"{c[i].Id} {(c[i].City)} {c[i].Street} {c[i].House} {c[i].Number}");
            }
            adressComboBox.ItemsSource = ids2;



        }

        private void EstateLand(object sender, RoutedEventArgs e)
        {
            rooms.Text = "";
            floar.Text = "";

            rooms.Visibility = Visibility.Collapsed;
            floar.Visibility = Visibility.Collapsed;
        }

        private void ApartmentCheck(object sender, RoutedEventArgs e)
        {
            rooms.Text = "";
            floar.Text = "";
            rooms.Visibility = Visibility.Visible;
            
            floar.Visibility = Visibility.Visible;
            floar.Tag = "Этаж";
        }

        private void HouseCheck(object sender, RoutedEventArgs e)
        {
            rooms.Text = "";
            floar.Text = "";
            rooms.Visibility = Visibility.Visible;
            floar.Visibility = Visibility.Visible;
            floar.Tag = "Количество этажей";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            db.SaveChanges();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Estate estate = new() { Address = int.Parse(adressComboBox.SelectedItem.ToString().Split(" ")[0]),  District = districtComboBox.SelectedItem.ToString()};
            db.Estates.Add(estate);
            db.SaveChanges();
            db.Estates.Load();
            var g = db.Estates.Local.ToBindingList();
            int max = -1;
            foreach(var i in g) { 
                if (i.Id>max)
                {
                    max = i.Id;
                }

            }
            EstateGrid.ItemsSource = g;
            if (apatmentCheck.IsChecked == true)
            {
                EstateApartment estateApartment = new() { Floor = floar.Text == "" ? null :int.Parse(floar.Text), RoomsCount = rooms.Text == "" ? null : int.Parse(rooms.Text), Square = square.Text == "" ? null : double.Parse(square.Text), Id=max};
                db.EstateApartments.Add(estateApartment);
                db.SaveChanges();
            }
            if(houseCheck.IsChecked==true)
            {
                EstateHouse estateApartment = new() { FloorsCount = floar.Text == "" ? null : int.Parse(floar.Text), RoomsCount = rooms.Text == "" ? null : int.Parse(rooms.Text), Square = square.Text == "" ? null : double.Parse(square.Text), Id = max };
                db.EstateHouses.Add(estateApartment);
                db.SaveChanges();
            }
            if(estateCheck.IsChecked == true)
            {
                EstateLand estateApartment = new() { Square = square.Text == "" ? null : double.Parse(square.Text), Id = max };
                db.EstateLands.Add(estateApartment);
                db.SaveChanges();
            }
        }
    }
}
