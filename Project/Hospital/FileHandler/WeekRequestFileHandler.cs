using System.Collections.Generic;
using Hospital.Model;

namespace Hospital.FileHandler
{
    public class WeekRequestFileHandler
    {
        private readonly string path = @"../../Resources/WeekRequest.txt";

        public List<WeekRequest> Read()
        {

            string serializedRequests = System.IO.File.ReadAllText(path);
            List<WeekRequest> requests = Newtonsoft.Json.JsonConvert.DeserializeObject<List<WeekRequest>>(serializedRequests);
            return requests;
        }

        public void Write(List<WeekRequest> requests)
        {
            string serializedRequests = Newtonsoft.Json.JsonConvert.SerializeObject(requests);
            System.IO.File.WriteAllText(path, serializedRequests);

        }
    }
}
