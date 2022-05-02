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
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public int Duration { get; set; }
        public Examination Examination { get; set; }
        public Drug Drug { get; set; }

        public Prescription(int id, int frequency, string description, DateTime startTime, int duration, Examination examination, Drug drug)
        {
            Id = id;
            Frequency = frequency;
            Description = description;
            StartTime = startTime;
            Duration = duration;
            Examination = examination;
            Drug = drug;
        }
    }
}
