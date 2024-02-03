namespace CarBook.Domain.Entities
{
    public class Service : IEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string IconUrl { get; set; }
    }
}
