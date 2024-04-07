using CarBook.Domain.Entities;

namespace CarBook.Application.Features.Mediator.Results.CommentResults
{
    public class GetCommentsByBlogIdQueryResult
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Content { get; set; }
        public string imageUrl { get; set; }
        public int BlogID { get; set; }
        public string? Mail { get; set; }
    }
}
