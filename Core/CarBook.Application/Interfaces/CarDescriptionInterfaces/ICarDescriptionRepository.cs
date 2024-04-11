using CarBook.Domain.Entities;

namespace CarBook.Application.Interfaces.CarDescriptionInterfaces
{
    public interface ICarDescriptionRepository
    {
        Task<CarDescription> GetCarDescription(int carId);
    }
}
