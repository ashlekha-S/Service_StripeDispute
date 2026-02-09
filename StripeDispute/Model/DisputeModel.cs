using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StripeDispute.Model
{
    public class DisputeModel
    {
        public string DisputeId { get; set; }
        public string ChargeId { get; set; }
        public string Status { get; set; }
        public string PaymentIntentId { get; set; }
        public DateTime DisputeDate { get; set; }
        public string Reason { get; set; }
        public decimal Amount { get; set; }
        public decimal DisputeFee { get; set; }
        public DateTime ResponseDate { get; set; }
    }
}
