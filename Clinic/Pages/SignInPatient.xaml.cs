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
using Clinic.Code;

namespace Clinic.Pages
{
    /// <summary>
    /// Логика взаимодействия для SignInPatient.xaml
    /// </summary>
    public partial class SignInPatient : Page
    {

        MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;

        public SignInPatient()
        {
            InitializeComponent();
        }

        private void btnChangeRole_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SignInStaff());
        }

        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            var qwery = Connection.ClinicDB.User.Where(i => i.PolicyId == textPolis.Text && i.Policy.Birthday == textDate.DisplayDate).ToList();
            if (qwery.Count > 0)
            {
                // Запоминаем текущего пользователя приложения
                AppUser.appUser = qwery.FirstOrDefault();
                NavigationService.Navigate(new Registry());
            }
            else
            {
                mainWindow.showAlert($"Пользователь не найден!");
            }
        }
    }
}
