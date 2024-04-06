using CarBook.Application.Features.Mediator.Queries.CarPricingQueries;
using CarBook.Application.Features.Mediator.Results.CarPricingResults;
using CarBook.Application.Interfaces.CarPricingInterfaces;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CarHandlers
{
    public class GetCarPricingWithCarDailyQueryHandler : IRequestHandler<GetCarPricingWithCarDailyQuery, List<GetCarPricingWithCarDailyQueryResult>>
    {
        private readonly ICarPricingRepository _repository;

        public GetCarPricingWithCarDailyQueryHandler(ICarPricingRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCarPricingWithCarDailyQueryResult>> Handle(GetCarPricingWithCarDailyQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetCarsWithPricingsDaily();
            return values.Select(x => new GetCarPricingWithCarDailyQueryResult
            {
                ID = x.Car.ID,
                Model = x.Car.Model,
                CoverImageUrl = x.Car.CoverImageUrl,
                BrandName = x.Car.Brand.Name,
                PricingName = x.Pricing.Name,
                PricingAmount = x.Amount,
            }).ToList();
        }
    }
}
