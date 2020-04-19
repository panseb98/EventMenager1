using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models.Authorization;

namespace WebAPI.Models.Events
{
    public class ReceiptItem
    {
        [Column("RECEIPT_PROD_ID")]
        public int Id { get; set; }
        [Column("RECEIPT_PROD_NAME")]
        public string ProductName { get; set; }
        [Column("RECEIPT_PROD_AMOUNT")]
        public int Amount { get; set; }
        [Column("RECEIPT_PROD_PRICE")]
        public double Price { get; set; }
        [Column("RECEIPT_PROD_REC_ID")]
        public int ReceiptId { get; set; }
        public Participant Participant { get; set; }
    }
}
