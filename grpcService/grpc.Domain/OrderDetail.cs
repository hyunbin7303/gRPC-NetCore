

namespace grpc.Domain
{
    public class OrderDetail
    {
        public string orderId { get; set; }
        public int productId { get; set; }
        public string productName { get; set; }
        public int quantity { get; set; }
        public Price unitCost { get; set; }
    }
}
