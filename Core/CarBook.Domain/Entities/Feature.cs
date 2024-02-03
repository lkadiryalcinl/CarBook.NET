namespace CarBook.Domain.Entities
{
    public class Feature : IEntity
    {
        public string Name { get; set; }
        public List<CarFeature> CarFeatures { get; set; }
    }
}
