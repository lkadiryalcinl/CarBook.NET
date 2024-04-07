namespace CarBook.Dto.BlogDtos
{
    public class GetBlogById
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CommentsCount { get; set; }
    }
}
