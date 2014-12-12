using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tables
{
    public class Port : BaseEntity
    {
        public string Name { get; set; }
        public int CityId { get; set; }

        public Port(int Id, string Name, int CityId)
        {
            this.Id = Id;
            this.CityId = CityId;
            this.Name = Name;
        }

        public Port()
        {
        }

        public override string ToString()
        {
            return String.Format("Id --> {1}{0}Name --> {2}{0} CityId --> {3}{0}", Environment.NewLine, Id, Name, CityId);
        }
    }
}
