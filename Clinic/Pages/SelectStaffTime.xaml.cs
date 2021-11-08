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

using Clinic.AppData;
using Clinic.Model;
using Clinic.Code;

namespace Clinic.Pages
{
    /// <summary>
    /// Логика взаимодействия для SelectStaffTime.xaml
    /// </summary>
    public partial class SelectStaffTime : Page
    {
        public SelectStaffTime()
        {
            InitializeComponent();

            timeBox.ItemContainerStyle = (Style)Application.Current.FindResource("CustomListBoxItem");

            timeBox.ItemsSource = Record.day.availableTime;

        }

        private void timeBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Record.time = (TimeSpan)timeBox.SelectedItem;
            NavigationService.Navigate(new Confirmation());
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SelectStaffDay());
        }
    }
}
