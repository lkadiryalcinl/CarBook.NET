using CarBook.Application.Features.Mediator.Queries.CarPricingQueries;
using CarBook.Application.Features.Mediator.Results.CarPricingResults;
using CarBook.Application.Interfaces.CarPricingInterfaces;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CarPricingHandlers
{
    public class GetCarPricingWithTimePeriodQueryHandler : IRequestHandler<GetCarPricingWithTimePeriodQuery, List<GetCarPricingWithTimePeriodQueryResult>>
    {
        private readonly ICarPricingRepository _repository;
        public GetCarPricingWithTimePeriodQueryHandler(ICarPricingRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<GetCarPricingWithTimePeriodQueryResult>> Handle(GetCarPricingWithTimePeriodQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetCarPricingsWithTimePeriod();
            return values.Select(x => new GetCarPricingWithTimePeriodQueryResult
            {
                ID = x.ID,
                Brand = x.Brand,
                Model = x.Model,
                CoverImageUrl = x.CoverImageUrl,
                HourlyAmount = x.Amounts[0],
                DailyAmount = x.Amounts[1],
                WeeklyAmount = x.Amounts[2]
            }).ToList();
        }
    }
}
