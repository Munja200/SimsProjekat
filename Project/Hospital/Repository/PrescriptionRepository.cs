using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model;
using Model;

namespace Hospital.Repository
{
    public class PrescriptionRepository
    {

        public List<Prescription> prescriptions;

        public PrescriptionRepository()
        {
            prescriptionFileHandler = new FileHandler.PrescriptionFileHandler();
            prescriptions = new List<Prescription>();
        }

        public bool CreatePrescription(int id, int frequency, int interval, DateTime startTime, int duration, Drug drug)
        {
            prescriptions.Add(new Prescription(id, frequency, interval, startTime, duration, drug));
            prescriptionFileHandler.Write(prescriptions);
            return true;
        }

        public bool DeletePrescription(int id)
        {
            foreach (Prescription prescription in prescriptions)
            {
                if (prescription.Id.Equals(id))
                {
                    prescriptions.Remove(prescription);
                    prescriptionFileHandler.Write(prescriptions);
                    return true;
                }
            }
            return false;
        }

        public bool EditPrescription(int id, int frequency, int interval, DateTime startTime, int duration, Drug drug)
        {

            foreach(Prescription prescription in prescriptions)
            {
                if (prescription.Id.Equals(id))
                {
                    prescription.Id = id;
                    prescription.Frequency = frequency;
                    prescription.Interval = interval;
                    prescription.StartTime = startTime;
                    prescription.Duration = duration;
                    prescription.Drug = drug;

                    prescriptionFileHandler.Write(prescriptions);

                    return true;
                }
            }

            return false;
        }

        public List<Prescription> GetAll()
        {

            if (prescriptionFileHandler.Read() == null)
                return prescriptions;

            prescriptions = prescriptionFileHandler.Read();

            return prescriptions;
        }

        public Prescription GetPrescriptionById(int id)
        {
            foreach (Prescription prescription in prescriptions)
            {
                if (prescription.Id.Equals(id))
                    return prescription;
            }
            return null;
        }

        public FileHandler.PrescriptionFileHandler prescriptionFileHandler;

    }
}
