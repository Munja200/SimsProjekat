using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model;
using Hospital.Service;
using Model;

namespace Hospital.Controller
{
    public class PrescriptionController
    {
        private readonly PrescriptionService _service;

        public PrescriptionController(PrescriptionService prescriptionService)
        {
            _service = prescriptionService;
        }

        public List<Prescription> GetAll()
        {
            return _service.GetAll();
        }

        public bool CreatePrescription(int id, int frequency,  int interval, DateTime startTime, int duration, Drug drug)
        {
            return _service.CreatePrescription(id, frequency, interval, startTime, duration, drug);
        }

        public bool DeletePrescription(int id)
        {
            return _service.DeletePrescription(id);
        }

        public Prescription GetPrescriptionById(int id)
        {
            return _service.GetPrescriptionById(id);
        }

        public bool EditPrescription(int id, int frequency, int interval, DateTime startTime, int duration, Drug drug)
        {
            return _service.EditPrescription(id, frequency, interval, startTime, duration, drug);
        }
    }
}
