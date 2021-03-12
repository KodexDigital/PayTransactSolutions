using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PayTransact.Models.Models
{
    public class Transaction : BaseModel
    {
        public string CustomerId { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public virtual ApplicationUser Customer { get; set; }
        public Guid ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; }
        public double InvestedAmount { get; set; }
        public DateTime DateOfPayment { get; set; }
        public string TransactionNumber { get; set; }

        public Transaction()
        {
            TransactionNumber = string.Concat(Guid.NewGuid().ToString("N"), DateOfPayment.ToShortDateString());
        }
    }
}
