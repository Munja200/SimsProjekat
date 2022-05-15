using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.FileHandler
{
    public class RenovationFileHandler
    {
        public readonly string path = @"../../Resources/Renovation.txt";

        public List<Renovation> Read()
        {
            string serializedRooms = System.IO.File.ReadAllText(path);
            List<Renovation> renovations = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Renovation>>(serializedRooms);
            return renovations;
        }
        public void Write(List<Renovation> renovations)
        {
            string serializedRooms = Newtonsoft.Json.JsonConvert.SerializeObject(renovations);
            System.IO.File.WriteAllText(path, serializedRooms);
        }
    }
}

