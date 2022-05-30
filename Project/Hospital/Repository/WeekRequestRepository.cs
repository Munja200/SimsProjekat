﻿using System;
using System.Collections.Generic;
using Hospital.Model;
using Model;

namespace Hospital.Repository
{
    public class WeekRequestRepository
    {
        public List<WeekRequest> weekRequests;
        public FileHandler.WeekRequestFileHandler weekRequestFileHandler;

        public WeekRequestRepository()
        {
            weekRequestFileHandler = new FileHandler.WeekRequestFileHandler();
            weekRequests = new List<WeekRequest>();
        }
        public bool CreateWeekRequest(int id, Specialist specialist, DateTime startTime, DateTime endTime, string description, State state, bool emergency)
        {
            weekRequests.Add(new WeekRequest(GenerateId(), specialist, startTime, endTime, description, state, emergency));
            weekRequestFileHandler.Write(weekRequests);
            return true;
        }

        public int GenerateId()
        {
            int id = 0;

            foreach (WeekRequest weekRequest in weekRequests)
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
            foreach (WeekRequest weekRequest in weekRequests)
            {
                if (weekRequest.Id.Equals(id))
                {
                    weekRequests.Remove(weekRequest);
                    weekRequestFileHandler.Write(weekRequests);
                    return true;
                }
            }
            return false;
        }

        public bool EditWeekRequest(int id, Specialist specialist, DateTime startTime, DateTime endTime, string description, State state, bool emergency)
        {

            foreach (WeekRequest weekRequest in weekRequests)
            {
                if (weekRequest.Id.Equals(id))
                {
                    weekRequest.Id = id;
                    weekRequest.Specialist = specialist;
                    weekRequest.StartTime = startTime;
                    weekRequest.EndTime = endTime;
                    weekRequest.Description = description;
                    weekRequest.State = state;
                    weekRequest.Emergency = emergency;

                    weekRequestFileHandler.Write(weekRequests);

                    return true;
                }
            }

            return false;
        }

        public List<WeekRequest> GetAll()
        {
            if (weekRequestFileHandler.Read() == null)
                return weekRequests;

            weekRequests = weekRequestFileHandler.Read();

            return weekRequests;
        }

        public WeekRequest GetWeekRequestById(int id)
        {
            foreach (WeekRequest weekRequest in weekRequests)
            {
                if (weekRequest.Id.Equals(id))
                    return weekRequest;
            }
            return null;
        }


    }
}
