namespace CarBook.Domain.Entities
{
    public class Brand : IEntity
    {
        public string Name { get; set; }
        public List<Car> Cars { get; set; }
    }
}
