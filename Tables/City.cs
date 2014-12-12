using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tables
{
    public class City : BaseEntity
    {
        public string Name { get; set; }

        public City(int Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }
        public City() { }
        public override string ToString()
        {
            return String.Format("Id --> {1}{0} Name -->{2}{0}", Environment.NewLine, Id, Name);
        }
    }
}
