using CarBook.Application.Interfaces.CarDescriptionInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Persistence.Repositories.CarDescriptionRepositories
{
	public class CarDescriptionRepository : ICarDescriptionRepository
	{
		private readonly CarBookContext _context;

		public CarDescriptionRepository(CarBookContext context)
		{
			_context = context;
		}

		public async Task<CarDescription> GetCarDescription(int carId)
		{
			var values = await _context.CarDescriptions.Where(x => x.CarID == carId).FirstOrDefaultAsync();
			return values;
		}
	}
}
