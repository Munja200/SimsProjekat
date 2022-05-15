using System;
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

        public bool CreateExamination(int id, Appointment appointment, Report report, Prescription prescription, Instructions instructions)
        {
            return examinationRepository.CreateExamination(id, appointment, report, prescription, instructions);
        }

        public bool EditExamination(int id, Appointment appointment, Report report, Prescription prescription, Instructions instructions)
        {
            return examinationRepository.EditExamination(id, appointment, report, prescription, instructions);
        }
     
        public Repository.ExaminationRepository examinationRepository;
    }
}
