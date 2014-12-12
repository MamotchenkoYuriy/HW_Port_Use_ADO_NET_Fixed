using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tables
{
    public class Ship : BaseEntity
    {
        public string Number { get; set; }
        public int Capacity { get; set; }
        public DateTime CreateDate { get; set; }
        public int MaxDistance { get; set; }
        public int TeamCount { get; set; }
        public int PortId { get; set; }
        public int CaptainId { get; set; }
        public Ship(int Id, string Number, int Capacity, DateTime CreateDate, int MaxDistance, int TeamCount, int PortId, int CaptainId)
        {
            this.Id = Id;
            this.Number = Number;
            this.Capacity = Capacity;
            this.CreateDate = CreateDate;
            this.MaxDistance = MaxDistance;
            this.TeamCount = TeamCount;
            this.PortId = PortId;
            this.CaptainId = CaptainId;
        }

        public Ship()
        {
            // TODO: Complete member initialization
        }

        public override string ToString()
        {
            return String.Format("", Environment.NewLine, Id, Number, Capacity, CreateDate, MaxDistance, TeamCount, PortId, CaptainId);
        }
    }
}
