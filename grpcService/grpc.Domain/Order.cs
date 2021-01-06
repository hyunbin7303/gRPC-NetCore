using System;
using System.Collections.Generic;
using System.Text;

namespace grpc.Domain
{
    public class Order
    {
        public int Id { get; set; }
        public string orderUserId { get; set; }
        public float orderAmount { get; set; }
        public string addressLine1 { get; set; }
        public string addressLine2 { get; set; }
        public string postalCode { get; set; }

    }
}
