namespace CarBook.Domain.Entities
{
    public class Comment : IEntity
    {
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Content { get; set; }
        public string imageUrl { get; set; }
        public int BlogID { get; set; }
        public Blog Blog { get; set; }
        public string? Mail { get; set; }
    }
}
