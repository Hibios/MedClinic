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
    /// Логика взаимодействия для SelectPolyclinic.xaml
    /// </summary>
    public partial class SelectPolyclinic : Page
    {

        public SelectPolyclinic()
        {
            InitializeComponent();
            clinicBox.ItemContainerStyle = (Style)Application.Current.FindResource("CustomListBoxItem");



            List<Polyclinic> availableClinics = new List<Polyclinic>();

            // Список для всех уникальных клиник, в которых есть нужные врачи
            foreach (Staff staff in Connection.ClinicDB.Staff.Where(i => i.StaffType.Id == Record.role.Id).ToList())
            {
                if (!availableClinics.Contains(staff.Polyclinic)) { availableClinics.Add(staff.Polyclinic); }
            }

            clinicBox.ItemsSource = availableClinics;
        }

        private void clinicBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Record.clinic = (Polyclinic)clinicBox.SelectedItem;
            NavigationService.Navigate(new SelectStaff());
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Record.doctor = new Staff();
            NavigationService.Navigate(new SelectRolePage());
        }
    }
}
