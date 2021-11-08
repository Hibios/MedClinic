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

namespace Clinic.Pages
{
    /// <summary>
    /// Логика взаимодействия для Registry.xaml
    /// </summary>
    public partial class Registry : Page
    {
        public Registry()
        {
            InitializeComponent();

            var U = Code.AppUser.appUser;

            textPolis.Content = $"Полис №{U.PolicyId}, {U.Policy.Birthday.ToShortDateString()} г.р.";
            textPolyclinic.Content = $"Ваша поликлиника: {U.MedCard.Polyclinic.Name}";
            textAddress.Content = $"Адрес: {U.MedCard.Polyclinic.Address}";
        }

        private void btnSignOut_Click(object sender, RoutedEventArgs e)
        {
            Code.AppUser.appUser = null;
            NavigationService.Navigate(new SignInPatient());
        }

        private void btnGetStaffHelp_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SelectRolePage());
        }
    }
}
