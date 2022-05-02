﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model;
using Hospital.Repository;
using Model;

namespace Hospital.Service
{
    public class ExaminationService
    {
        public ExaminationService(ExaminationRepository examinationRepository)
        {
            this.examinationRepository = examinationRepository;
        }

        public List<Examination> GetAll()
        {
            return examinationRepository.GetAll();
        }

        public bool CreateExamination(int id, Appointment appointment, Report report, Prescription prescription)
        {
            return examinationRepository.CreateExamination(id, appointment, report, prescription);
        }

        public bool EditExamination(int id, Appointment appointment, Report report, Prescription prescription)
        {
            return examinationRepository.EditExamination(id, appointment, report, prescription);
        }
     
        public Repository.ExaminationRepository examinationRepository;
    }
}
