using System;
using System.Collections.Generic;
using System.Windows.Controls;
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

        public bool serialize { get; set; }
        public bool ShouldSerializeserialize()
        {
            this.serialize = true;
            return false;
        }
        public bool ShouldSerializeStartTime() { return serialize; }
        public bool ShouldSerializeEndTime() { return serialize; }
        public bool ShouldSerializeDuration() { return serialize; }
        public bool ShouldSerializeScheduled() { return serialize; }
        public bool ShouldSerializeAppointmetntType() { return serialize; }

        public bool ShouldSerializeRoom()
        {
            if (this.Room != null)
                this.Room.serialize = false;
            return serialize;
        }

        public bool ShouldSerializeDoctor()
        {
            return serialize;
        }
        public bool ShouldSerializePatientAccount()
        {
            return serialize;
        }


        [JsonIgnore]
        public System.Collections.Generic.List<Operation> operation;

        public Appointment(int id, DateTime startTime, DateTime endTime, int duration, bool scheduled, AppointmentType appointmetntType, Doctor doctor, Room room, PatientAccount patientAccount)
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