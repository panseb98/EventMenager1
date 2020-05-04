using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models.Events.ViewModels
{
    public class ReceiptItemVM
    {
        public int Id { get; set; }
        public string ProdName { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
        public int ParticipantId { get; set; }
    }
}
