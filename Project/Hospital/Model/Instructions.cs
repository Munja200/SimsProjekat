using System;
using Model;

namespace Hospital.Model
{
    public class Instructions
    {
        public Purpose Purpose { get; set; }
        public DateTime StartTime { get; set; }
        public bool Emergency { get; set; }
        public Specialist Specialist { get; set; }

        public Instructions(Purpose purpose, DateTime startTime, bool emergency, Specialist specialist)
        {
            Purpose = purpose;
            StartTime = startTime;
            Emergency = emergency;
            Specialist = specialist;
        }

        public Instructions()
        {
        }
    }
}
