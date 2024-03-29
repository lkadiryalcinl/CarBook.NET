﻿namespace CarBook.Application.Features.Mediator.Results.BannerResults
{
    public class GetBannerByIdQueryResult
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string VideoDescription { get; set; }
        public string VideoUrl { get; set; }
        public string ImageUrl { get; set; }
    }
}
