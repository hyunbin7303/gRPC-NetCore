using System;
using System.Collections.Generic;
using System.Text;

namespace grpc.Domain
{
    public class Cart
    {
        public string cartId { get; set; }
        public int productId { get; set; }
        public int quantity { get; set; }
        public string Description { get;set;}
        public DateTime? dateAdded { get; set; }
    }
}
