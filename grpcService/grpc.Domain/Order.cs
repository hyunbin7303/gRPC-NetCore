using System;
using System.Collections.Generic;
using System.Text;

namespace grpc.Domain
{
    public class Order
    {
        public string Id { get; set; }
        public string orderCustomerId { get; set; }
        public float orderAmount { get; set; }
        public string addressLine1 { get; set; }
        public string addressLine2 { get; set; }
        public string postalCode { get; set; }
        public DateTime? dateCreated { get; set; }
        public DateTime? dateShipped { get; set; }
        public string shippingId { get; set; }
        public OrderStatus orderStatus { get; set; }
        public override string ToString()
        {
            return $"{Id},{orderCustomerId}, order Status : {orderStatus}";
        }
    }
}
