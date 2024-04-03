using CarBook.Application.Interfaces.CarPricingInterfaces;
using CarBook.Application.ViewModel;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Persistence.Repositories.CarPricingRepositories
{
    public class CarPricingRepository : Repository<CarPricing>, ICarPricingRepository
    {
        public CarPricingRepository(CarBookContext context) : base(context)
        {
        }

        public List<CarPricingViewModel> GetCarPricingsWithTimePeriod()
        {
            List<CarPricingViewModel> values = new();
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "Select * From (Select Model,Name,CoverImageUrl,PricingID,Amount From CarPricings Inner Join Cars On Cars.ID=CarPricings.CarId Inner Join Brands On Brands.ID=Cars.BrandID) As SourceTable Pivot (Sum(Amount) For PricingID In ([1],[2],[3])) as PivotTable;";
                command.CommandType = System.Data.CommandType.Text;
                _context.Database.OpenConnection();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CarPricingViewModel carPricingViewModel = new()
                        {
                            Brand = reader["Name"].ToString(),
                            Model = reader["Model"].ToString(),
                            CoverImageUrl = reader["CoverImageUrl"].ToString(),
                            Amounts = new List<decimal>
                            {
                                Convert.ToDecimal(reader["1"]),
                                Convert.ToDecimal(reader["2"]),
                                Convert.ToDecimal(reader["3"])
                            }
                        };
                        values.Add(carPricingViewModel);
                    }
                }
                _context.Database.CloseConnection();
                return values;
            }
        }

        public async Task<List<CarPricing>> GetCarsWithPricings()
        {
            var values = await _context.CarPricings.Include(x => x.Car).ThenInclude(y => y.Brand).Include(x => x.Pricing).ToListAsync();
            return values;
        }

        public async Task<List<CarPricing>> GetCarsWithPricingsDaily()
        {
            var values = await _context.CarPricings.Include(x => x.Car).ThenInclude(y => y.Brand).Include(x => x.Pricing).Where(z => z.PricingID == 2).ToListAsync();
            return values;
        }
    }
}
