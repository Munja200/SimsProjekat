using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model;
using Model;

namespace Model
{
    public class Examination
    {
        public int Id { get; set; }
        public Appointment Appointment { get; set; }

        // public Prescription Prescription { get; set; }
        public Report Report { get; set; }

        public Examination(int id, Appointment appointment, Report report)
        {
            Id = id;
            Appointment = appointment;
            Report = report;
        }
    }
}
