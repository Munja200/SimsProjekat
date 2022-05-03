using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model;

namespace Hospital.FileHandler
{
    public class ReportFileHandler
    {

        private readonly string path = @"../../Resources/Report.txt";

        public List<Report> Read()
        {

            string serializedReports = System.IO.File.ReadAllText(path);
            List<Report> reports = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Report>>(serializedReports);
            return reports;
        }

        public void Write(List<Report> reports)
        {
            string serializedReports = Newtonsoft.Json.JsonConvert.SerializeObject(reports);
            System.IO.File.WriteAllText(path, serializedReports);

        }
    }
}
