using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Hospital.Model
{
    public class Prescription
    {
        public int Id { get; set; }
        public int Frequency { get; set; }
        public int Interval { get; set; }
        public DateTime StartTime { get; set; }
        public int Duration { get; set; }
        public Drug Drug { get; set; }

        public Prescription(int id, int frequency, int interval, DateTime startTime, int duration, Drug drug)
        {
            Id = id;
            Frequency = frequency;
            Interval = interval;
            StartTime = startTime;
            Duration = duration;
            Drug = drug;
        }

        public override string ToString()
        {
            return Drug.Name + " " + Frequency + "x dnevno, na " + Interval + "h od " + StartTime + ", " + Duration + " dana";
        }
    }
}
