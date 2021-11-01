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
    /// Логика взаимодействия для SignInStaff.xaml
    /// </summary>
    public partial class SignInStaff : Page
    {
        MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;

        public SignInStaff()
        {
            InitializeComponent();
        }

        private void btnChangeRole_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SignInPatient());
        }

        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            var checkUser = Connection.ClinicDB.Staff.Where(i => i.Login == textLogin.Text).ToList();
            if (checkUser.Count > 0)
            {
                var checkPassword = Connection.ClinicDB.Staff.Where(i => i.Login == textLogin.Text && i.PasswordHash == textPassword.Password).ToList();
                if (checkPassword.Count > 0)
                {
                    StaffUser.staffUser = checkPassword.FirstOrDefault();
                    NavigationService.Navigate(new StaffCabinet());
                }
                else
                {
                    mainWindow.showAlert($"Пароли не совпадают!");
                }
            }
            else
            {
                mainWindow.showAlert($"Пользователь не найден!");
            }
        }
    }
}
