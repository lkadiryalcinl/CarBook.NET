namespace CarBook.Domain.Entities
{
    public class TagCloud : IEntity
    {
        public string Title { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
