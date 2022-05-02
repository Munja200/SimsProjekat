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
    public class PrescriptionService
    {
        public PrescriptionService(PrescriptionRepository prescriptionRepository)
        {
            this.prescriptionRepository = prescriptionRepository;
        }

        public List<Prescription> GetAll()
        {
            return prescriptionRepository.GetAll();
        }

        public bool CreatePrescription(int id, int frequency, string description, DateTime startTime, int duration, Examination examination, Drug drug)
        {
            return prescriptionRepository.CreatePrescription(id, frequency, description, startTime, duration, examination, drug);
        }

        public bool DeletePrescription(int id)
        {
            return prescriptionRepository.DeletePrescription(id);
        }

        public Prescription GetPrescriptionById(int id)
        {
            return prescriptionRepository.GetPrescriptionById(id);
        }

        public bool EditPrescription(int id, int frequency, string description, DateTime startTime, int duration, Examination examination, Drug drug)
        {
            return prescriptionRepository.EditPrescription(id, frequency, description, startTime, duration, examination, drug);
        }

        public Repository.PrescriptionRepository prescriptionRepository;

    }
}
