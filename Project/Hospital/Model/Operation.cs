using System;

namespace Model
{
   public class Operation
   {
        public int id { get; set; }
        public int duration;

        public OperationType operationType { get; set; }
        public Specialist specialist { get; set; }
        public Room room { get; set; }

        public Appointment appointment { get; set; }

        public Operation(int idd, int durationn, OperationType operationTypee, Specialist specialistt, Room roomm, Appointment appointmentt)
        { 
            id = idd;
            duration = durationn;
            operationType = operationTypee;
            specialist = specialistt;
            room = roomm;
            appointment = appointmentt;

        }

        public Appointment Appointment
        {
            get
            {
                return Appointment;
            }
            set
            {
                if (this.appointment == null || !this.appointment.Equals(value))
                {
                    if (this.appointment != null)
                    {
                        Appointment oldAppointment = this.appointment;
                        this.appointment = null;
                        oldAppointment.RemoveOperation(this);
                    }
                    if (value != null)
                    {
                        this.appointment = value;
                        this.appointment.AddOperation(this);
                    }
                }
            }
        }

    }

}