﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model;
using Hospital.Service;
using Model;

namespace Hospital.Controller
{
    public class WeekRequestController
    {
        private readonly WeekRequestService _service;

        public WeekRequestController(WeekRequestService service)
        {
            _service = service;
        }

        public List<WeekRequest> GetAll()
        {
            return _service.GetAll();
        }

        public bool CreateWeekRequest(int id, Specialist specialist, DateTime startTime, DateTime endTime, string description, State state, bool emergency)
        {
            return _service.CreateWeekRequest(id, specialist, startTime, endTime, description, state, emergency);
        }

        public bool DeleteWeekRequest(int id)
        {
            return _service.DeleteWeekRequest(id);
        }

        public WeekRequest GetWeekRequestById(int id)
        {
            return _service.GetWeekRequestById(id);
        }

        public bool EditWeekRequest(int id, Specialist specialist, DateTime startTime, DateTime endTime, string description, State state, bool emergency)
        {
            return _service.EditWeekRequest(id, specialist, startTime, endTime, description, state, emergency);
        }

    }
}
