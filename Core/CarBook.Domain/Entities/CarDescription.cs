

namespace CarBook.Domain.Entities
{
    public class CarDescription : IEntity
    {
        public int CarID { get; set; }
        public Car Car { get; set; }
        public string Description { get; set; }
    }
}
