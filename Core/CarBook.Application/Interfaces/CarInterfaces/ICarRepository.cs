using CarBook.Domain.Entities;

namespace CarBook.Application.Interfaces.CarInterfaces
{
    public interface ICarRepository
    {
        Task<List<Car>> GetCarsListWithBrand();
    }
}
