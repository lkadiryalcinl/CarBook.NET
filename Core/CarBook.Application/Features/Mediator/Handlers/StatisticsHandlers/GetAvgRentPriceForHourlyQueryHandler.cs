using CarBook.Application.Features.Mediator.Queries.StatisticsQueries;
using CarBook.Application.Features.Mediator.Results.StatisticsResults;
using CarBook.Application.Interfaces.StatisticInterfaces;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.StatisticsHandlers
{
    public class GetAvgRentPriceForHourlyQueryHandler : IRequestHandler<GetAvgRentPriceForHourlyQuery, GetAvgRentPriceForHourlyQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetAvgRentPriceForHourlyQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAvgRentPriceForHourlyQueryResult> Handle(GetAvgRentPriceForHourlyQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetAvgRentPriceForHourly();
            return new GetAvgRentPriceForHourlyQueryResult
            {
                AvgRentPriceForHourly = value
            };
        }
    }
}
