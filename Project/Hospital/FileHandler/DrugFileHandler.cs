using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model;

namespace Hospital.FileHandler
{
    public class DrugFileHandler
    {

        private readonly string path = @"../../Resources/Drug.txt";

        public List<Drug> Read()
        {

            string serializedDrugs = System.IO.File.ReadAllText(path);
            List<Drug> drugs = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Drug>>(serializedDrugs);
            return drugs;
        }

        public void Write(List<Drug> drugs)
        {
            string serializedDrugs = Newtonsoft.Json.JsonConvert.SerializeObject(drugs);
            System.IO.File.WriteAllText(path, serializedDrugs);

        }
    }
}
