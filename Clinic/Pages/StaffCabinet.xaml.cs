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
    /// Логика взаимодействия для StaffCabinet.xaml
    /// </summary>
    public partial class StaffCabinet : Page
    {
        public StaffCabinet()
        {
            InitializeComponent();

            var U = Code.StaffUser.staffUser;

            textProfile.Content = $"{U.Login} | {U.StaffType.Name}";
        }

        private void btnSignOut_Click(object sender, RoutedEventArgs e)
        {
            Code.AppUser.appUser = null;
            NavigationService.Navigate(new SignInStaff());
        }
    }
}
