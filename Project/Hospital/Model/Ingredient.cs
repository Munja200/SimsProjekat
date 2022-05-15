using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model
{
    public class Ingredient
    {
        public Ingredient(string name)
        {
            this.Name = name;
        }
        public string Name { get; set; }
    }
}
