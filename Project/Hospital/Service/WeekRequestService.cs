﻿using System;
using System.Collections.Generic;
using Hospital.Model;
using Hospital.Repository;
using Model;

namespace Hospital.Service
{
    public class WeekRequestService
    {
        public Repository.WeekRequestRepository weekRequestRepository;

        public WeekRequestService(WeekRequestRepository weekRequestRepository)
        {
            this.weekRequestRepository = weekRequestRepository;
        }

        public List<WeekRequest> GetAll()
        {
            return weekRequestRepository.GetAll();
        }

        public List<WeekRequest> GetBySpecialistsCitizenId(int specialistCitizenId)
        {
            return weekRequestRepository.GetBySpecialistsCitizenId(specialistCitizenId);
        }

        public bool CreateWeekRequest(int id, Specialist specialist, DateTime startTime, DateTime endTime, string description, State state,
            String comment, bool emergency)
        {
            return weekRequestRepository.CreateWeekRequest(id, specialist, startTime, endTime, description, state, comment, emergency);
        }

        public bool DeleteWeekRequest(int id)
        {
            return weekRequestRepository.DeleteWeekRequest(id);
        }

        public WeekRequest GetWeekRequestById(int id)
        {
            return weekRequestRepository.GetWeekRequestById(id);
        }

        public bool EditWeekRequest(int id, Specialist specialist, DateTime startTime, DateTime endTime, string description, State state, 
            String comment, bool emergency)
        {
            return weekRequestRepository.EditWeekRequest(id, specialist, startTime, endTime, description, state, comment, emergency);
        }

    }
}
