﻿using CarBook.Application.Interfaces.CarPricingInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Persistence.Repositories.CarPricingRepositories
{
    public class CarPricingRepository : Repository<CarPricing>,ICarPricingRepository
    {
        public CarPricingRepository(CarBookContext context) : base(context)
        {
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
