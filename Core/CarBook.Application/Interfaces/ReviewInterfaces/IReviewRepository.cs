using CarBook.Domain.Entities;

namespace CarBook.Application.Interfaces.ReviewInterfaces
{
    public interface IReviewRepository
    {
        public Task<List<Review>> GetReviewsByCarId(int carId);
    }
}
