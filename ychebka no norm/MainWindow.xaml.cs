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
using ychebka_no_norm;

namespace ychebka
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenClient(object sender, RoutedEventArgs e)
        {
            Main.Content = new PageClient();
            wind.Title = "Окно клиент";
        }

        private void OpenRieltor(object sender, RoutedEventArgs e)
        {
            Main.Content = new PageRieltor();
            wind.Title = "Окно риэлтора";
        }

        private void OpenEstate(object sender, RoutedEventArgs e)
        {
            Main.Content = new PageEstate();
            wind.Title = "Окно недвижемости";
        }

        private void OpenDeal(object sender, RoutedEventArgs e)
        {
            Main.Content = new PageDeal();
            wind.Title = "Окно сделки";
        }

        private void OpenSuggestion(object sender, RoutedEventArgs e)
        {
            Main.Content = new PageSuggestion();
            wind.Title = "Окно Предложений";
        }

        private void OpenNeed(object sender, RoutedEventArgs e)
        {
            Main.Content = new PageNeed();
            wind.Title = "Окно потребностей";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new PageAdress();
            wind.Title = "Окно адресов";
        }
    }
}
