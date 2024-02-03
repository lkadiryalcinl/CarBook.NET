namespace CarBook.Domain.Entities
{
    public class About : IEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
