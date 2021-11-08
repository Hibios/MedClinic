using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinic.Model;
using Clinic.Pages;

using Clinic.AppData;

namespace Clinic.Code
{
    public class Record
    {
        public static VisitHistory record = new VisitHistory();
        public static StaffType role = new StaffType();
        public static Polyclinic clinic = new Polyclinic();
        public static Staff doctor = new Staff();
        public static Day day = new Day();
        public static TimeSpan time = new TimeSpan();

        public static void CleanRecord()
        {
            record = new VisitHistory();
            role = new StaffType();
            clinic = new Polyclinic();
            doctor = new Staff();
            day = new Day();
            time = new TimeSpan();
        }

        public static string generateTicket() 
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 4)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static void Save()
        {
            VisitHistory newVisit = new VisitHistory
            {
                Id = Connection.ClinicDB.VisitHistory.ToList().Count() + 1,
                VisitTime = day.day.Date + time,
                StaffId = doctor.Id,
                UserId = AppUser.appUser.Id,
                Attendance = false,
                VisitCode = generateTicket()
            };
            Connection.ClinicDB.VisitHistory.Add(newVisit);
            Connection.ClinicDB.SaveChanges();
        }
    }
}
