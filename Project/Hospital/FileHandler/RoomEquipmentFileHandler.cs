using Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace FileHandler
{
    public class ShouldSerializeContract : DefaultContractResolver
    {
        public new static readonly ShouldSerializeContract Instance = new ShouldSerializeContract();

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);
            if (property.DeclaringType == typeof(int) && property.PropertyName == "Floor")
            {
                property.ShouldSerialize =
                    instance =>
                    {
                        return true;
                    };
            }

            if (property.DeclaringType == typeof(RoomType) && property.PropertyName == "RoomType")
            {
                property.ShouldSerialize =
                    instance =>
                    {
                        return true;
                    };
            }

            if (property.DeclaringType == typeof(String) && property.PropertyName == "Name")
            {
                property.ShouldSerialize =
                    instance =>
                    {
                        return false;
                    };
            }

            if (property.DeclaringType == typeof(bool) && property.PropertyName == "Availability")
            {
                property.ShouldSerialize =
                    instance =>
                    {
                        return false;
                    };
            }

            return property;
        }
    }
    public class ShouldSerializeContractR : DefaultContractResolver
    {
          public new static readonly ShouldSerializeContractR Instance = new ShouldSerializeContractR();

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);
            if (property.DeclaringType == typeof(Room) && property.PropertyName == "Room")
            {
                property.ShouldSerialize =
                    instance =>
                    {
                        return true;
                    };
            }
            return property;
        }
    }

    public class RoomEquipmentFileHandler
   {
      public void Write(List<RoomEquipment> roomEquipments)
      {
            string serializedRoomEquipment = Newtonsoft.Json.JsonConvert.SerializeObject(roomEquipments, new JsonSerializerSettings
            {ContractResolver = new ShouldSerializeContractR()});
            System.IO.File.WriteAllText(path, serializedRoomEquipment);
        }

        public List<RoomEquipment> Read()
      {
            string serializedRoomsEquimpent = System.IO.File.ReadAllText(path);
            List<RoomEquipment> roomsEquimpent = Newtonsoft.Json.JsonConvert.DeserializeObject<List<RoomEquipment>>(serializedRoomsEquimpent);
            return roomsEquimpent;
        }

        public readonly String path = @"../../Resources/RoomEquipment.txt";

    }
}