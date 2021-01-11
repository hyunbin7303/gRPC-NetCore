using System;
using System.Collections.Generic;
using System.Text;

namespace grpc.Domain
{
    public class Payment
    {
        public string paymentId { get; set; }
        public DateTime? paidDate { get; set; }
        public Price totalPrice { get; set; }
        public string Details { get; set; }
    }
}
