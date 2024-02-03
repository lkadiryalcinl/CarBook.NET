using CarBook.Application.Features.Mediator.Queries.BannerQueries;
using CarBook.Application.Features.Mediator.Results.BannerResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.BannerHandlers
{
    public class GetBannerQueryHandler : IRequestHandler<GetBannerQuery,List<GetBannerQueryResult>>
    {
        private readonly IRepository<Banner> _repository;

        public GetBannerQueryHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetBannerQueryResult>> Handle(GetBannerQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();

            return values.Select(x => new GetBannerQueryResult
            {
                Description = x.Description,
                ID = x.ID,
                Title = x.Title,
                VideoDescription = x.VideoDescription,
                VideoUrl = x.VideoUrl
            }).ToList();
        }
    }
}
