using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tables
{
    public class Trip : BaseEntity
    {
        public int ShipId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int PortFromId { get; set; }
        public int PortToId { get; set; }

        public Trip(int Id, int ShipId, DateTime StartDate, DateTime EndDate, int PortFromId, int PortToId)
        {
            this.Id = Id;
            this.ShipId = ShipId;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
            this.PortFromId = PortFromId;
            this.PortToId = PortToId;
        }

        public Trip()
        {
            // TODO: Complete member initialization
        }

        public override string ToString()
        {
            return String.Format("Id --> {1}{0}CaptainId -->{2}{0}ShipId --> {3}{0}StartDate --> {4}{0}EndDate --> {5}{0}PortFromId --> {6}{0}PortToId --> {7}{0}", Environment.NewLine, Id, ShipId, StartDate, EndDate, PortFromId, PortToId);
        }
    }
}
