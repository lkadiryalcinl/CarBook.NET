namespace CarBook.Domain.Entities
{
    public class Pricing : IEntity
    {
        public string Name { get; set; }
        public List<CarPricing> CarPricings { get; set; }
    }
}
