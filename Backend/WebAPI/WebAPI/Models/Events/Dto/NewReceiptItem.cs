using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models.Events.Dto
{
    public class NewReceiptItem
    {
        public string ProductName { get; set; }
        public int Amount { get; set; }
        public double Price  { get; set; }
        public int ReceiptId { get; set; }
        public int UserId { get; set; }
    }
}
