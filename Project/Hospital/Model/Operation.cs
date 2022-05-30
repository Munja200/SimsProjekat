namespace Model
{
    public class Operation
    {
        public int Id { get; set; }
        public int Duration { get; set; }
        public OperationType OperationType { get; set; }
        public Specialist Specialist { get; set; }
        public Room Room { get; set; }

        public Appointment Appointmentt { get; set; }

        public Operation(int idd, int durationn, OperationType operationTypee, Specialist specialistt, Room roomm, Appointment appointmentt)
        {
            Id = idd;
            Duration = durationn;
            OperationType = operationTypee;
            Specialist = specialistt;
            Room = roomm;
            Appointmentt = appointmentt;

        }

        public Operation()
        {

        }

        public Appointment Appointment
        {
            get
            {
                return Appointmentt;
            }
            set
            {
                if (this.Appointmentt == null || !this.Appointmentt.Equals(value))
                {
                    if (this.Appointmentt != null)
                    {
                        Appointment oldAppointment = this.Appointmentt;
                        this.Appointmentt = null;
                        oldAppointment.RemoveOperation(this);
                    }
                    if (value != null)
                    {
                        this.Appointmentt = value;
                        this.Appointmentt.AddOperation(this);
                    }
                }
            }
        }

    }

}