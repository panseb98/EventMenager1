using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models.Events.Dto
{
    public class GetReceipt
    {
        public List<ReceiptItemDTO> ReceiptItems { get; set; }
        public int ReceiptId { get; set; }
    }
}
