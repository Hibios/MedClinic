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
    /// Логика взаимодействия для Confirmation.xaml
    /// </summary>
    public partial class Confirmation : Page
    {
        MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;

        public Confirmation()
        {
            InitializeComponent();

            textDateTime.Content = $"Дата и время приёма: { Record.day.dayLabel } {string.Format("{0:00}:{1:00}", Record.time.Hours, Record.time.Minutes)}";
            textDoctor.Content = $"Врач: { string.Format("{0} {1} {2} | {3} | Кабинет {4}", Record.doctor.User.Policy.LastName, Record.doctor.User.Policy.FirstName, Record.doctor.User.Policy.Patronimic, Record.doctor.StaffType.Name, Record.doctor.Cabinet)}";
            textClinic.Content = $"Медицинское учреждение: { Record.clinic.Name }";
            textAddress.Content = $"Адрес: { Record.clinic.Address }";
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SelectStaffTime());
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            Record.Save();
            mainWindow.showAlert($"Вы записались на приём!");
            Record.CleanRecord();
            NavigationService.Navigate(new Registry());
        }
    }
}
