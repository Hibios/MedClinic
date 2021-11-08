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
    /// Логика взаимодействия для SelectStaff.xaml
    /// </summary>
    public partial class SelectStaff : Page
    {
        public SelectStaff()
        {
            InitializeComponent();
            staffBox.ItemContainerStyle = (Style)Application.Current.FindResource("CustomListBoxItem");


            List<Staff> availableStaff = new List<Staff>();

            // Список врачей подходящих по предыдущим критериям
            availableStaff = Connection.ClinicDB.Staff.Where(i => i.StaffType.Id == Record.role.Id && i.Polyclinic.Id == Record.clinic.Id).ToList();
            staffBox.ItemsSource = availableStaff;
        }

        private void staffBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Record.doctor = (Staff)staffBox.SelectedItem;
            NavigationService.Navigate(new SelectStaffDay());
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Record.day = new Day();
            NavigationService.Navigate(new SelectPolyclinic());
        }
    }
}
