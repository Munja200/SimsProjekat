using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model
{
    public class ComboItem<T>
    {
        public string Name { get; set; }
        public T Value { get; set; }
    }
}
