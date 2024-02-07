namespace CarBook.Domain.Entities
{
    public class Category : IEntity
    {
        public string Name { get; set; }
        public List<Blog> Blogs { get; set; }
    }
}
