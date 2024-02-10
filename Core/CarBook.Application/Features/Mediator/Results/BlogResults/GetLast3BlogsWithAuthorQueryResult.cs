namespace CarBook.Application.Features.Mediator.Results.BlogResults
{
    public class GetLast3BlogsWithAuthorQueryResult
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public string CoverImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CategoryId { get; set; }
        public string AuthorName { get; set; }
    }
}
