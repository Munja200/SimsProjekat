using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model
{
    public class Renovation
    {
        public Renovation(Room room, Appointment appointment, RenovationType renovationType)
        {
            Room = room;
            Appointment = appointment;
            RenovationType = renovationType;
        }
        public Room Room { get; set; }
        public RenovationType RenovationType { get; set; }
        public Appointment Appointment { get; set; }
        public bool ShouldSerializeRoom()
        {
            if (this.Room != null)
                this.Room.Serialize = false;
            return true;
        }

        public bool ShouldSerializeAppointment()
        {
            if (this.Appointment != null)
                this.Appointment.Serialize = false;
            return true;
        }
    }
}
