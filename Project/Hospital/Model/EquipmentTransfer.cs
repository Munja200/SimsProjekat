using System;

namespace Model
{
   public class EquipmentTransfer
   {
      public EquipmentTransfer(Room senderRoom, Room recipientRoom, Equipment equipment, int quantity, DateTime scheduledDate, int id) 
      {
            Quantity = quantity;
            SheduledDate = scheduledDate;
            Id = id;
            Equipment = equipment;
            SenderRoom = senderRoom;
            RecipientRoom = recipientRoom;
      }
      public int Quantity { get; set; }
      public DateTime SheduledDate { get; set; }
      public int Id { get; set; }
      
      public Equipment Equipment { get; set; }
      public Room SenderRoom { get; set; }
      public Room RecipientRoom { get; set; }

        public bool ShouldSerializeSenderRoom()
        {
            this.SenderRoom.serialize = false;
            return true;
        }

        public bool ShouldSerializeEquipment()
        {
            this.Equipment.serialize = false;
            return true;
        }

        public bool ShouldSerializeRecipientRoom()
        {
            this.RecipientRoom.serialize = false;
            return true;
        }

    }
}