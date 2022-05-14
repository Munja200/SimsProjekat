using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model;
using Model;

namespace Hospital.Repository
{
    public class ExaminationRepository
    {
        public List<Examination> examinations;
        public FileHandler.ExaminationFileHandler examinationFileHandler;

        public ExaminationRepository()
        {
            examinationFileHandler = new FileHandler.ExaminationFileHandler();
            examinations = new List<Examination>();
        }

        public List<Examination> GetAll()
        {

            if (examinationFileHandler.Read() == null)
                return examinations;

            examinations = examinationFileHandler.Read();

            return examinations;
        }

        public bool CreateExamination(int id, Appointment appointment, Report report, Prescription prescription, Instructions instructions)
        {
            examinations.Add(new Examination(GenerateId(), appointment, report, prescription, instructions));
            examinationFileHandler.Write(examinations);
            return true;
        }

        public int GenerateId()
        {
            int id = 0;

            foreach (Examination examination in examinations)
            {
                if (examination.Id > id)
                {
                    id = examination.Id;
                }
            }

            return id + 1;
        }

        public bool EditExamination(int id, Appointment appointment, Report report, Prescription prescription, Instructions instructions)
        {

            foreach (Examination examination in examinations)
            {
                if (examination.Id.Equals(id))
                {
                    examination.Id = id;
                    examination.Appointment = appointment;
                    examination.Report = report;
                    examination.Prescription = prescription;
                    examination.Instructions = instructions;
                    examinationFileHandler.Write(examinations);

                    return true;
                }
            }

            return false;
        }

    }
}
