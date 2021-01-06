using System;
namespace grpc.Domain
{
    public class Product
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string brand { get; set; }
        public Price price { get; set; }
    }
    public class Price
    {
        private float amount;
        private string currency;
        // Do you guys remember how to make it simple?
        public Price(float amount, string currency)
        {
            if(amount < 0 )
            {
                throw new ArgumentException("Amount value can't be lower than 0.");
            }
            this.amount = amount;
            this.currency = currency;
        }
        public float getAmount() { return amount; }
        public string getCurrency() { return currency; }
        public override string ToString()
        {
            return amount + " " + currency; 
        }

    }
}
