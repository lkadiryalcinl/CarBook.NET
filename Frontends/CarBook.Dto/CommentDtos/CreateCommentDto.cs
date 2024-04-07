namespace CarBook.Dto.CommentDtos
{
    public class CreateCommentDto
    {
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public int BlogID { get; set; }
        public string? Mail { get; set; }
    }
}
