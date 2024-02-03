namespace CarBook.Application.Features.Mediator.Results.AboutResults
{
    public class GetAboutByIdQueryResult
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
