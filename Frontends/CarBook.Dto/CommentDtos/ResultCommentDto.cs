namespace CarBook.Dto.CommentDtos
{
    public class ResultCommentDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Content { get; set; }
        public string imageUrl { get; set; }
        public int BlogID { get; set; }
    }
}
