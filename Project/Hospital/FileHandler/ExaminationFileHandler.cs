using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model;
using Model;

namespace Hospital.FileHandler
{
    public class ExaminationFileHandler
    {

        private readonly string path = @"../../Resources/Examination.txt";

        public List<Examination> Read()
        {

            string serializedExaminations = System.IO.File.ReadAllText(path);
            List<Examination> examinations = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Examination>>(serializedExaminations);
            return examinations;
        }

        public void Write(List<Examination> examinations)
        {
            foreach (Examination examination in examinations)
            {
                if (examination.Appointment != null)
                    examination.Appointment.serialize = true;
                examination.serialize = true;
            }

            string serializedExaminations = Newtonsoft.Json.JsonConvert.SerializeObject(examinations);
            System.IO.File.WriteAllText(path, serializedExaminations);

        }
    }
}
