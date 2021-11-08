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
    public partial class SelectRolePage : Page
    {

        public SelectRolePage()
        {
            InitializeComponent();

            roleBox.ItemContainerStyle = (Style)Application.Current.FindResource("CustomListBoxItem");

            List<StaffType> items = new List<StaffType>();
            foreach (StaffType staffType in Connection.ClinicDB.StaffType.AsEnumerable()) { items.Add(staffType); }
            roleBox.ItemsSource = items;
        }

        private void btnBackToReg_Click(object sender, RoutedEventArgs e)
        {
            Record.CleanRecord();
            NavigationService.Navigate(new Registry());
        }

        private void roleBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Record.role = (StaffType)roleBox.SelectedItem;
            NavigationService.Navigate(new SelectPolyclinic());
        }
    }
}
