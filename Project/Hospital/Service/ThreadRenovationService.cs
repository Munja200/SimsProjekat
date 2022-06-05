using Hospital.Model;
using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hospital.Service
{
    public class ThreadRenovationService
    {
        private Thread myThread;
        public RoomService roomService;
        public RoomEquipmentService roomEquipmentService;
        public RenovationService renovationService;
        private List<Renovation> renovations;
        public ThreadRenovationService(RoomEquipmentService roomEquipmentService, RoomService roomService, RenovationService renovationService)
        {
            this.roomService = roomService;
            this.roomEquipmentService = roomEquipmentService;
            this.renovationService = renovationService;
            renovations = new List<Renovation>();
            myThread = new Thread(CheckDate);
            myThread.IsBackground = true;
            myThread.Start();
        }
        public void CheckDate()
        {
            while (true)
            {
                renovations = renovationService.GetAll();
                bool flag = false;
                if (renovations != null)
                {
                    flag = CheckListRenovation(renovations);
                }
                if (!flag)
                { 
                    Thread.Sleep(30 * 1000);
                }
            }
        }

        //Ovo je rekao da treba refaktorisati
        public bool CheckListRenovation(List<Renovation> renovations) {
            bool flag = false;
            foreach (Renovation newRenovation in renovations)
            {
                if ((newRenovation.Appointment != null && newRenovation.Appointment.Room != null) || (newRenovation.RenovationType == RenovationType.Merger && newRenovation.Room != null))
                {
                    ChangeRoomAvailability(newRenovation);

                    if (DateTime.Compare(newRenovation.Appointment.EndTime.Date, DateTime.Today) == 0)
                    {
                        CompleteRenovation(newRenovation);
                        flag = true;
                        renovationService.Delete(newRenovation);
                        break;
                    }
                }
            }

            return flag;
        }

        public void MoveAllRoomEquipment(Renovation newRenovation)
        {
            foreach (RoomEquipment roomEquipment in roomEquipmentService.GetByRoomId(newRenovation.Room.Id))
            {
                roomEquipmentService.MoveEquipment(new EquipmentTransfer(newRenovation.Room, newRenovation.Appointment.Room, roomEquipment.Equipment, roomEquipment.Quantity, DateTime.Today, 0));
            }
            roomService.DeleteRoom(newRenovation.Room.Id);
        }

        public void CompleteRenovation(Renovation newRenovation)
        {
            if (newRenovation.RenovationType == RenovationType.Merger)
            {
                MoveAllRoomEquipment(newRenovation);
            }
            else if (newRenovation.RenovationType == RenovationType.Sharing)
            {
                roomService.CreateRoom(newRenovation.Appointment.Room.Floor, newRenovation.Appointment.Room.Name + " 1", 0, true, newRenovation.Appointment.Room.RoomType);
            }

            roomService.EditRoomAvailability(newRenovation.Appointment.Room, true);
        }

        public void ChangeRoomAvailability(Renovation newRenovation) {
            if (DateTime.Compare(newRenovation.Appointment.StartTime.Date, DateTime.Today) == 0)
            {
                roomService.EditRoomAvailability(newRenovation.Appointment.Room, false);
            }
        }
    }
}
