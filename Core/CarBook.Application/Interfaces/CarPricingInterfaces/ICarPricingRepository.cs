using CarBook.Domain.Entities;

namespace CarBook.Application.Interfaces.CarPricingInterfaces
{
    public interface ICarPricingRepository : IRepository<CarPricing>
    {
        Task<List<CarPricing>> GetCarsWithPricings();
        Task<List<CarPricing>> GetCarsWithPricingsDaily();
    }
}
