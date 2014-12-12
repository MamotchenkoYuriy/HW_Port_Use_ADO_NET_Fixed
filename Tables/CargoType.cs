using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tables
{
    public class CargoType : BaseEntity
    {
        public string TypeName { get; set; }

        public CargoType() { }

        public CargoType(int Id, string TypeName)
        {
            this.Id = Id;
            this.TypeName = TypeName;
        }
        public override string ToString()
        {
            return String.Format("Id --> {1}{0} TypeName --> {2}{0}", Environment.NewLine, Id, TypeName);
        }
    }
}
