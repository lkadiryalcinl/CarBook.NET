namespace CarBook.Application.Interfaces.StatisticInterfaces
{
    public interface IStatisticsRepository
    {
        Task<int> GetCarCount();
        Task<int> GetLocationCount();
        Task<int> GetAuthorCount();
        Task<int> GetBlogCount();
        Task<int> GetBrandCount();
        Task<decimal> GetAvgRentPriceForDaily();
        Task<decimal> GetAvgRentPriceForWeekly();
        Task<decimal> GetAvgRentPriceForHourly();
        Task<decimal> GetAvgRentPrice(string by);
        Task<string> GetBrandNameByMaxCar();
        Task<string> GetBlogTitleByMaxBlogComment();
        Task<int> GetCarCountByTranmissionIsAuto();
        Task<int> GetCarCountByKmSmallerThen1000();
        Task<int> GetCarCountByFuelGasolineOrDiesel();
        Task<int> GetCarCountByFuelElectric();
        Task<string> GetCarBrandAndModelByRentPriceDailyMax();
        Task<string> GetCarBrandAndModelByRentPriceDailyMin();
    }
}
