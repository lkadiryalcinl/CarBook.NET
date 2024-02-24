using CarBook.Application.Interfaces.StatisticInterfaces;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Persistence.Repositories.StatisticRepositories
{
    public class StatisticRepository : IStatisticsRepository
    {
        private readonly CarBookContext _context;

        public StatisticRepository(CarBookContext context)
        {
            _context = context;
        }
        public async Task<int> GetCarCount()
        {
            var value = await _context.Cars.CountAsync();
            return value;
        }

        public async Task<int> GetAuthorCount()
        {
            var value = await _context.Authors.CountAsync();
            return value;
        }

        public async Task<int> GetBlogCount()
        {
            var value = await _context.Blogs.CountAsync();
            return value;
        }

        public async Task<int> GetBrandCount()
        {
            var value = await _context.Brands.CountAsync();
            return value;
        }

        public async Task<int> GetLocationCount()
        {
            var value = await _context.Locations.CountAsync();
            return value;
        }

        public async Task<decimal> GetAvgRentPrice(string by)
        {
            int id = await _context.Pricings.Where(x => x.Name == by).Select(y => y.ID).FirstOrDefaultAsync();
            var value = await _context.CarPricings.Where(w => w.PricingID == id).AverageAsync(x => x.Amount);
            return value;
        }

        public async Task<decimal> GetAvgRentPriceForDaily()
        {
            return await GetAvgRentPrice("Günlük");
        }

        public async Task<decimal> GetAvgRentPriceForWeekly()
        {
            return await GetAvgRentPrice("Haftalık");
        }

        public async Task<decimal> GetAvgRentPriceForHourly()
        {
            return await GetAvgRentPrice("Saatlik");
        }

        public async Task<int> GetCarCountByKmSmallerThen1000()
        {
            var value = await _context.Cars.Where(x => x.Kilometer < 1000 ).CountAsync();
            return value;
        }

        public async Task<int> GetCarCountByTranmissionIsAuto()
        {
            var value = await _context.Cars.Where(x => x.Transmission == "Otomatik").CountAsync();
            return value;
        }

        public async Task<int> GetCarCountByFuelElectric()
        {
            var value = await _context.Cars.Where(x => x.Fuel == "Elektrik").CountAsync();
            return value;
        }

        public async Task<int> GetCarCountByFuelGasolineOrDiesel()
        {
            var value = await _context.Cars.Where(x => x.Fuel == "Dizel" || x.Fuel == "Benzin").CountAsync();
            return value;
        }

        public Task<string> GetBlogTitleByMaxBlogComment()
        {
            throw new NotImplementedException();
        }


        public Task<string> GetBrandNameByMaxCar()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetCarBrandAndModelByRentPriceDailyMax()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetCarBrandAndModelByRentPriceDailyMin()
        {
            throw new NotImplementedException();
        }

    }
}
