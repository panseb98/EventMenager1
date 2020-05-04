using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models.Events.Dto
{
    public class NewReceiptItem
    {
        public int Id { get; set; }
        public string PositionName { get; set; }
        public int Count { get; set; }
        public double Value  { get; set; }
        public int Participant { get; set; }
    }
}
