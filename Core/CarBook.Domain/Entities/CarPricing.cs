namespace CarBook.Domain.Entities
{
    public class CarPricing : IEntity
    {
        public int CarID { get; set; }
        public Car Car { get; set; }
        public int PricingID { get; set; }
        public Pricing Pricing { get; set; }
        public decimal Amount { get; set; }
    }
}
