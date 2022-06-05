using Hospital.Model;

namespace Model
{
    public class Examination
    {
        public int Id { get; set; }
        public Appointment Appointment { get; set; }

        public Prescription Prescription { get; set; }
        public Report Report { get; set; }

        public Instructions Instructions { get; set; }

        public Examination(int id, Appointment appointment, Report report, Prescription prescription, Instructions instructions)
        {
            Id = id;
            Appointment = appointment;
            Report = report;
            Prescription = prescription;
            Instructions = instructions;
        }

        public bool serialize { get; set; }
        public bool ShouldSerializeserialize()
        {
            this.serialize = true;
            return false;
        }

        public bool ShouldSerializeAppointment()
        {
            if (this.Appointment != null)
                this.Appointment.serialize = false;
            return serialize;
        }
        public bool ShouldSerializePrescription()
        {
            return serialize;
        }
        public bool ShouldSerializeReport()
        {
            return serialize;
        }
        public bool ShouldSerializeInst5ructions()
        {
            return serialize;
        }

    }
}
