using System;
using System.Collections.Generic;
using Hospital.Model;
using Model;

namespace Hospital.Repository
{
    public class WeekRequestRepository
    {
        public List<WeekRequest> requests;
        public FileHandler.WeekRequestFileHandler weekRequestFileHandler;

        public WeekRequestRepository()
        {
            weekRequestFileHandler = new FileHandler.WeekRequestFileHandler();
            requests = new List<WeekRequest>();
        }
        public bool CreateWeekRequest(int id, Specialist specialist, DateTime startTime, DateTime endTime, string description, State state, bool emergency)
        {
            requests.Add(new WeekRequest(GenerateId(), specialist, startTime, endTime, description, state, emergency));
            weekRequestFileHandler.Write(requests);
            return true;
        }

        public int GenerateId()
        {
            int id = 0;

            foreach (WeekRequest weekRequest in requests)
            {
                if (weekRequest.Id > id)
                {
                    id = weekRequest.Id;
                }
            }

            return id + 1;
        }

        public bool DeleteWeekRequest(int id)
        {
            foreach (WeekRequest weekRequest in requests)
            {
                if (weekRequest.Id.Equals(id))
                {
                    requests.Remove(weekRequest);
                    weekRequestFileHandler.Write(requests);
                    return true;
                }
            }
            return false;
        }

        public bool EditWeekRequest(int id, Specialist specialist, DateTime startTime, DateTime endTime, string description, State state, bool emergency)
        {

            foreach (WeekRequest wr in requests)
            {
                if (wr.Id.Equals(id))
                {
                    wr.Id = id;
                    wr.Specialist = specialist;
                    wr.StartTime = startTime;
                    wr.EndTime = endTime;
                    wr.Description = description;
                    wr.State = state;
                    wr.Emergency = emergency;

                    weekRequestFileHandler.Write(requests);

                    return true;
                }
            }

            return false;
        }

        public List<WeekRequest> GetAll()
        {
            if (weekRequestFileHandler.Read() == null)
                return requests;

            requests = weekRequestFileHandler.Read();

            return requests;
        }

        public WeekRequest GetWeekRequestById(int id)
        {
            foreach (WeekRequest wr in requests)
            {
                if (wr.Id.Equals(id))
                    return wr;
            }
            return null;
        }


    }
}
