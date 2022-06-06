using Model;
using Repository;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hospital.Service
{
    class ThreadEquipmentService
    {
        private Thread myThread;
        public EquipmentTransferRepository equipmentTransferRepository;
        public RoomEquipmentRepository roomEquipmentRepository;
        private List<EquipmentTransfer> equipmentTransfers;
        
        public ThreadEquipmentService(RoomEquipmentRepository roomEquipmentRepository, EquipmentTransferRepository equipmentTransferRepository){
            this.equipmentTransferRepository = equipmentTransferRepository;
            this.roomEquipmentRepository = roomEquipmentRepository;
            equipmentTransfers = new List<EquipmentTransfer>();
            myThread = new Thread(CheckDate);
            myThread.IsBackground = true;
            myThread.Start();
        }

        public void CheckDate() {
            while (true)
            {
                equipmentTransfers = equipmentTransferRepository.GetAll();
                bool flag = FindFirstEquipmentTransferForTodayDate();
           
                if (!flag) 
                    Thread.Sleep(30 * 1000);
            }
        }

        private bool FindFirstEquipmentTransferForTodayDate() {
            if (equipmentTransfers != null)
            {
                foreach (EquipmentTransfer equipmentTransfer in equipmentTransfers)
                {
                    if (DateTime.Compare(equipmentTransfer.SheduledDate.Date, DateTime.Today) == 0)
                    {
                        roomEquipmentRepository.MoveEquipment(equipmentTransfer);
                        equipmentTransferRepository.Delete(equipmentTransfer.Id);
                        return true;
                    }
                }
            }
            return false;
        }

    }
}
