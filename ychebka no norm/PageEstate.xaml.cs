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

namespace ychebka
{
    /// <summary>
    /// Логика взаимодействия для PageEstate.xaml
    /// </summary>
    public partial class PageEstate : Page
    {
        public PageEstate()
        {
            InitializeComponent();
        }

        private void EstateLand(object sender, RoutedEventArgs e)
        {
            
            rooms.Visibility = Visibility.Collapsed;
            floar.Visibility = Visibility.Collapsed;
        }

        private void ApartmentCheck(object sender, RoutedEventArgs e)
        {
            rooms.Visibility = Visibility.Visible;
            floar.Visibility = Visibility.Visible;
            floar.Tag = "Этаж";
        }

        private void HouseCheck(object sender, RoutedEventArgs e)
        {
            rooms.Visibility = Visibility.Visible;
            floar.Visibility = Visibility.Visible;
            floar.Tag = "Количество этажей";
        }
    }
}
