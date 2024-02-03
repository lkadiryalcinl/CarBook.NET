using CarBook.Application.Features.Mediator.Results.CarResults;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.CarHandlers
{
    public class GetCarWithBrandQueryHandler
    {
        private readonly ICarRepository _repository;

        public GetCarWithBrandQueryHandler(ICarRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCarWithBrandQueryResult>> Handle()
        {
            var values = await _repository.GetCarsListWithBrand();
            return values.Select(x => new GetCarWithBrandQueryResult
            {
                ID = x.ID,
                BrandID = x.BrandID,
                BrandName = x.Brand.Name,
                BigImageUrl = x.BigImageUrl,
                CoverImageUrl = x.CoverImageUrl,
                Fuel = x.Fuel,
                Kilometer = x.Kilometer,
                Luggage = x.Luggage,
                Model = x.Model,
                Seat = x.Seat,
                Transmission = x.Transmission
            }).ToList();
        }
    }
}
