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
    /// Логика взаимодействия для SelectStaffDay.xaml
    /// </summary>
    public partial class SelectStaffDay : Page
    {
        public SelectStaffDay()
        {
            InitializeComponent();

            dateBox.ItemContainerStyle = (Style)Application.Current.FindResource("CustomListBoxItem");

            CurrentWeek week1 = new CurrentWeek();

            dateBox.ItemsSource = week1.daysWeek;

            // Выбираем все записи пациентов к конкретному врачу
            List<DateTime> visits = new List<DateTime>();
            foreach (VisitHistory visit in Connection.ClinicDB.VisitHistory.Where(i => i.StaffId == Record.doctor.Id).AsEnumerable()) { visits.Add(visit.VisitTime); }


        }

        private void dateBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Record.day = (Day)dateBox.SelectedItem;
            NavigationService.Navigate(new SelectStaffTime());
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Record.time = new TimeSpan();
            NavigationService.Navigate(new SelectStaff());
        }
    }


    // Работает как список дней
    public class CurrentWeek
    {
        public static List<DateTime> week = genWeek();
        public List<Day> daysWeek = fillDays(week);


        public static List<DateTime> genWeek()
        {
            DateTime currentDay = DateTime.Now;
            List<DateTime> currentWeek = new List<DateTime>();
            for (int d = 1; d <= 7; ++d)
            {
                currentWeek.Add(currentDay);
                currentDay = currentDay.AddDays(1);
            }
            return currentWeek;
        }

        public static List<Day> fillDays(List<DateTime> new_week)
        {
            List<Day> days = new List<Day>();
            List<int> activeDays = new List<int>();
            foreach (ScheduleList sch in Connection.ClinicDB.ScheduleList.Where(i => i.idStaffSchedule == Record.doctor.idScheduleList).ToList())
            {
                activeDays.Add((int)sch.WorkList.WorkDay.Id);
            }
            foreach (DateTime day in new_week)
            {
                Day newDay = new Day();

                if (activeDays.Contains((int)day.DayOfWeek))
                    newDay.SetVisits(day, availableVisits(day));
                newDay.SetDay(day);
                days.Add(newDay);
            }

            return days;
        }

        public static List<TimeSpan> availableVisits(DateTime day)
        {
            // Список времён, на которые уже кто-то записан
            List<TimeSpan> existsVisits = new List<TimeSpan>();
            foreach (VisitHistory visit in Connection.ClinicDB.VisitHistory.Where(i => i.StaffId == Record.doctor.Id && i.VisitTime.Day == day.Day).AsEnumerable()) { existsVisits.Add(visit.VisitTime.TimeOfDay); }

            List<WorkList> activeDays = new List<WorkList>();
            foreach (ScheduleList sch in Connection.ClinicDB.ScheduleList.Where(i => i.idStaffSchedule == Record.doctor.idScheduleList).ToList())
                activeDays.Add(sch.WorkList);
            // Расписание врача в нужный день
            WorkList staffSchedule = activeDays.Where(i => i.idWorkDay == (int)day.DayOfWeek).FirstOrDefault();

            // Время приёма врача на весь день
            List<TimeSpan> allTime = new List<TimeSpan>();

            TimeSpan startTime = (TimeSpan)staffSchedule.idWorkStartTme;
            TimeSpan endTime = (TimeSpan)staffSchedule.idWorkEndTime;

            while (startTime < endTime)
            {
                allTime.Add(startTime);
                startTime += TimeSpan.FromMinutes(Convert.ToInt32(staffSchedule.ReceptionTime));
            }
            // Возвращаем только свободное время
            return allTime.Except(existsVisits).ToList();
        }
    }

    public class Day
    {
        public DateTime day = new DateTime();
        public string dayLabel { get; set; }
        public string info { get; set; }

        public List<TimeSpan> availableTime = new List<TimeSpan>();

        public void SetVisits(DateTime newDay, List<TimeSpan> visits) 
        {
            availableTime = visits;
            info = $"{availableTime[0].Hours}:{availableTime[0].Minutes}-{availableTime[availableTime.Count-1].Hours}:{availableTime[availableTime.Count - 1].Minutes} ТАЛОНОВ {availableTime.Count}";
        }

        public void SetDay(DateTime newDay)
        {
            day = newDay;
            dayLabel = $"{Connection.ClinicDB.WorkDay.Where(i => i.Id == (int)day.DayOfWeek).FirstOrDefault().Name} {day.Day}.{day.Month}";
            if (info is null)
            {
                info = "НЕТ ПРИЁМА";
            }
        }
    }
}
