using System;
using Newtonsoft.Json;

namespace Model
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Duration { get; set; }
        public bool Scheduled { get; set; }
        public AppointmentType AppointmetntType { get; set; }


        public Doctor Doctor { get; set; }
        public Room Room { get; set; }
        public PatientAccount PatientAccount { get; set; }

        public Appointment(int id, DateTime startTime, DateTime endTime, int duration, bool scheduled, AppointmentType appointmetntType,
            Doctor doctor, Room room, PatientAccount patientAccount)
        {
            Id = id;
            StartTime = startTime;
            EndTime = endTime;
            Duration = duration;
            Scheduled = scheduled;
            AppointmetntType = appointmetntType;
            Doctor = doctor;
            Room = room;
            PatientAccount = patientAccount;

        }

        public bool Serialize { get; set; }
        public bool ShouldSerializeSerialize()
        {
            this.Serialize = true;
            return false;
        }
        public bool ShouldSerializeStartTime() { return Serialize; }
        public bool ShouldSerializeEndTime() { return Serialize; }
        public bool ShouldSerializeDuration() { return Serialize; }
        public bool ShouldSerializeScheduled() { return Serialize; }
        public bool ShouldSerializeAppointmetntType() { return Serialize; }

        public bool ShouldSerializeRoom()
        {
            if (this.Room != null)
                this.Room.Serialize = false;
            return Serialize;
        }

        public bool ShouldSerializeDoctor()
        {
            return Serialize;
        }
        public bool ShouldSerializePatientAccount()
        {
            if (this.PatientAccount != null)
                this.PatientAccount.serialize = false;
            return Serialize;
        }


        [JsonIgnore]
        public System.Collections.Generic.List<Operation> operation;

        [JsonIgnore]
        public System.Collections.Generic.List<Operation> Operation
        {
            get
            {
                if (operation == null)
                    operation = new System.Collections.Generic.List<Operation>();
                return operation;
            }
            set
            {
                RemoveAllOperation();
                if (value != null)
                {
                    foreach (Operation oOperation in value)
                        AddOperation(oOperation);
                }
            }
        }


        public void AddOperation(Operation newOperation)
        {
            if (newOperation == null)
                return;
            if (this.operation == null)
                this.operation = new System.Collections.Generic.List<Operation>();
            if (!this.operation.Contains(newOperation))
            {
                this.operation.Add(newOperation);
                newOperation.Appointment = this;
            }
        }


        public void RemoveOperation(Operation oldOperation)
        {
            if (oldOperation == null)
                return;
            if (this.operation != null)
                if (this.operation.Contains(oldOperation))
                {
                    this.operation.Remove(oldOperation);
                    oldOperation.Appointment = null;
                }
        }


        public void RemoveAllOperation()
        {
            if (operation != null)
            {
                System.Collections.ArrayList tmpOperation = new System.Collections.ArrayList();
                foreach (Operation oldOperation in operation)
                    tmpOperation.Add(oldOperation);
                operation.Clear();
                foreach (Operation oldOperation in tmpOperation)
                    oldOperation.Appointment = null;
                tmpOperation.Clear();
            }
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Appointment);
        }

        public bool Equals(Appointment other)
        {
            return other != null &&
                   Id == other.Id;
        }
    }
}