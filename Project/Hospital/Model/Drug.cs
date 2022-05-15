using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model
{
    public class Drug
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Using { get; set; }
        public bool IsNotValid { get; set; }
        public string ReasonForInvalidity { get; set; }

        public Drug(int id, string name, string @using, bool isValid, string reasonForInvalidity)
        {
            Id = id;
            Name = name;
            Using = @using;
            IsNotValid = isValid;
            ReasonForInvalidity = reasonForInvalidity;
        }

    }
}
