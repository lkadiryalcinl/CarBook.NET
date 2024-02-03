namespace CarBook.Domain.Entities
{
    public class CarFeature : IEntity
    {
        public int CarID { get; set; }
        public Car Car { get; set; }
        public int FeatureID { get; set; }
        public Feature Feature { get; set; }
        public bool Available { get; set; }
    }
}
