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
        private List<EquipmentTransfer> equipmentTs;
        public ThreadEquipmentService(RoomEquipmentRepository roomEquipmentRepository, EquipmentTransferRepository equipmentTransferRepository){
            this.equipmentTransferRepository = equipmentTransferRepository;
            this.roomEquipmentRepository = roomEquipmentRepository;
            equipmentTs = new List<EquipmentTransfer>();
            myThread = new Thread(CheckDate);
            myThread.IsBackground = true;
            myThread.Start();
        }

        public void CheckDate() {
            while (true)
            {
                equipmentTs = equipmentTransferRepository.GetAll();
                bool flag = false;
                if (equipmentTs != null) {
                    foreach (EquipmentTransfer et in equipmentTs)
                    {
                        if (DateTime.Compare(et.SheduledDate.Date, DateTime.Today) == 0) {
                            roomEquipmentRepository.MoveEquipment(et);
                            flag = true;
                            equipmentTransferRepository.Delete(et.Id);
                            break;
                        }
                    }
                }
                if (!flag) {
                    //Thread.Sleep(3600 * 1000);
                    Thread.Sleep(30 * 1000);
                }
            }
        }
    }
}
