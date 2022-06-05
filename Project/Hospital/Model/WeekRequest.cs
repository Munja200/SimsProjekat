using System;
using Model;

namespace Hospital.Model
{
    public class WeekRequest
    {
        public int Id { get; set; }
        public Specialist Specialist { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Description { get; set; }
        public State State { get; set; }
        public String StatusComment { get; set; }
        public bool Emergency { get; set; }

        public WeekRequest(int id, Specialist specialist, DateTime startTime, DateTime endTime, string description, State state,
            string statusComment, bool emergency)
        {
            Id = id;
            Specialist = specialist;
            StartTime = startTime;
            EndTime = endTime;
            Description = description;
            State = state;
            StatusComment = statusComment;
            Emergency = emergency;
        }

        public WeekRequest()
        {
        }
    }
}
