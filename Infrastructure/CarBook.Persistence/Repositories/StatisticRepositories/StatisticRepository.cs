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
            var value = await _context.Cars.Where(x => x.Kilometer < 10000).CountAsync();
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

        public async Task<string> GetBlogTitleByMaxBlogComment()
        {
            var values = await _context.Comments.GroupBy(x => x.BlogID).
                Select(y => new
                {
                    BlogId = y.Key,
                    Count = y.Count(),
                }).OrderByDescending(y => y.Count).Take(1).FirstOrDefaultAsync();
            var BlogTitle = await _context.Blogs.Where(x => x.ID == values.BlogId).Select(y => y.Title).FirstOrDefaultAsync();
            return BlogTitle;
        }


        public async Task<string> GetBrandNameByMaxCar()
        {
            var values = await _context.Cars.GroupBy(x => x.BrandID).
                Select(y => new
                {
                    BrandId = y.Key,
                    Count = y.Count()
                }).OrderByDescending(y => y.Count).Take(1).FirstOrDefaultAsync();
            var brandName = await _context.Brands.Where(x => x.ID == values.BrandId).Select(y => y.Name).FirstOrDefaultAsync();
            return brandName;
        }

        public async Task<string> GetCarBrandAndModelByRentPriceDailyMax()
        {
            int pricingID = await _context.
                Pricings.
                Where(x => x.Name == "Günlük").
                Select(y => y.ID).
                FirstOrDefaultAsync();
            decimal amount = await _context.
                CarPricings.
                Where(x => x.PricingID == pricingID).
                MaxAsync(x => x.Amount);
            int carID = await _context.
                CarPricings.
                Where(x => x.Amount == amount).
                Select(y => y.CarID).
                FirstOrDefaultAsync();
            string brandName = await _context.
                Cars.
                Where(x => x.ID == carID).
                Include(y => y.Brand).
                Select(z => z.Brand.Name + " " + z.Model).
                FirstOrDefaultAsync();
            return brandName; ;
        }

        public async Task<string> GetCarBrandAndModelByRentPriceDailyMin()
        {
            int pricingID = await _context.
                Pricings.
                Where(x => x.Name == "Günlük").
                Select(y => y.ID).
                FirstOrDefaultAsync();
            decimal amount = await _context.
                CarPricings.
                Where(x => x.PricingID == pricingID).
                MinAsync(y => y.Amount);
            int carID = await _context.
                CarPricings.
                Where(x => x.Amount == amount).
                Select(y => y.CarID).
                FirstOrDefaultAsync();
            string brandName = await _context.
                Cars.
                Where(x => x.ID == carID).
                Include(y => y.Brand).
                Select(z => z.Brand.Name + " " + z.Model).
                FirstOrDefaultAsync();
            return brandName;
        }
    }
}
