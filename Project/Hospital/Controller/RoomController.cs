using Hospital.Util;
using Hospital.View;
using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Controller
{

   public class RoomController
   {

        public Service.RoomService roomService;

        public RoomController(RoomService roomService)
        {
            this.roomService = roomService;
        }

        public Room GetById(int id)
        {
            return roomService.GetById(id);
        }

        public ref MTObservableCollection<Room> GetAll()
        {
            return ref roomService.GetAll();
        }
        public List<Room> GetAllByFloor(int floor)
        {
            return roomService.GetAllByFloor(floor);
        }

        public bool DeleteRoom(int id)
        {
            return roomService.DeleteRoom(id);
        }
      
        public bool EditRoom(Room room)
        {
            return roomService.EditRoom(room);
        }
      
        public bool CreateRoom(Room room)
        {           
            return roomService.CreateRoom(room);
        }
   }
}