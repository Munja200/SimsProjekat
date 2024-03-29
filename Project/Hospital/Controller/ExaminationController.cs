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
    public class ExaminationController
    {
        private readonly ExaminationService _service;
        public ExaminationController(ExaminationService examinationService)
        {
            _service = examinationService;
        }

        public List<Examination> GetAll()
        {
            return _service.GetAll();
        }

        public bool EditExamination(int id, Appointment appointment, Report report, Prescription prescription, Instructions instructions)
        {
            return _service.EditExamination(id, appointment, report, prescription, instructions);
        }


    }
}
