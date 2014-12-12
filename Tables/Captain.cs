using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tables
{
    public class Captain : BaseEntity
    {
        public string FirstName {get; set;}
        public string LastName {get; set;}

        public Captain() { }
        public Captain(int Id, string FirstName, string LastName)
        {
            this.Id = Id;
            this.LastName = LastName;
            this.FirstName = FirstName;
        }

        public override string ToString()
        {
            return String.Format("Id --> {1}{0} FirstName --> {2}{0}LastName --> {3}{0}", Environment.NewLine, Id, FirstName, LastName);
        }
    }
}
