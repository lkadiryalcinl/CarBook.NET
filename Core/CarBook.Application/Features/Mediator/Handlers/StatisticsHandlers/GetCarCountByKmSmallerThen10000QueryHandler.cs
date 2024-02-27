using CarBook.Application.Features.Mediator.Queries.StatisticsQueries;
using CarBook.Application.Features.Mediator.Results.StatisticsResults;
using CarBook.Application.Interfaces.StatisticInterfaces;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.StatisticsHandlers
{
    public class GetCarCountByKmSmallerThen10000QueryHandler : IRequestHandler<GetCarCountByKmSmallerThen10000Query, GetCarCountByKmSmallerThen10000QueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetCarCountByKmSmallerThen10000QueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCarCountByKmSmallerThen10000QueryResult> Handle(GetCarCountByKmSmallerThen10000Query request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetCarCountByKmSmallerThen1000();
            return new GetCarCountByKmSmallerThen10000QueryResult
            {
                CarCountByKmSmallerThen10000 = value
            };
        }
    }
}
