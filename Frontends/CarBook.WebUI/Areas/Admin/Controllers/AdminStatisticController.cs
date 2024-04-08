using CarBook.Dto.StatisticsDtos;
using CarBook.WebUI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminStatistic")]
    [Authorize(Roles = "ADMIN")]
    public class AdminStatisticsController : Controller
    {
        private readonly HttpClientServiceAction _httpClientServiceAction;
        public AdminStatisticsController(HttpClientServiceAction httpClientFactory)
        {
            _httpClientServiceAction = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            Random random = new();

            #region İstatistik1
            var CarCountRandom = random.Next(0, 101);
            var CarCountValues = await _httpClientServiceAction.InvokeAsync<ResultStatisticsDto>("Statistics/GetCarCount");
            ViewBag.CarCount = CarCountValues.CarCount;
            ViewBag.CarCountRandom = CarCountRandom;
            #endregion
            
            #region İstatistik2
            var LocationCountRandom = random.Next(0, 101);
            var LocationCountValues = await _httpClientServiceAction.InvokeAsync<ResultStatisticsDto>("Statistics/GetLocationCount");
            ViewBag.LocationCount = LocationCountValues.LocationCount;
            ViewBag.LocationCountRandom = LocationCountRandom;
            #endregion
            
            #region İstatistik3
            var AuthorCountRandom = random.Next(0, 101);
            var AuthorCountValues = await _httpClientServiceAction.InvokeAsync<ResultStatisticsDto>("Statistics/GetAuthorCount");
            ViewBag.AuthorCount = AuthorCountValues.AuthorCount;
            ViewBag.AuthorCountRandom = AuthorCountRandom;
            #endregion
            
            #region İstatistik4
            var BlogCountRandom = random.Next(0, 101);
            var BlogCountValues = await _httpClientServiceAction.InvokeAsync<ResultStatisticsDto>("Statistics/GetBlogCount");
            ViewBag.BlogCount = BlogCountValues.BlogCount;
            ViewBag.BlogCountRandom = BlogCountRandom;
            #endregion
            
            #region İstatistik5
            var BrandCountRandom = random.Next(0, 101);
            var BrandCountValues = await _httpClientServiceAction.InvokeAsync<ResultStatisticsDto>("Statistics/GetBrandCount");
            ViewBag.BrandCount = BrandCountValues.BrandCount;
            ViewBag.BrandCountRandom = BrandCountRandom;
            #endregion
            
            #region İstatistik6
            var AvgRentPriceForHourlyRandom = random.Next(0, 101);
            var AvgRentPriceForHourlyValues = await _httpClientServiceAction.InvokeAsync<ResultStatisticsDto>("Statistics/GetAvgRentPriceForHourly");
            ViewBag.AvgRentPriceForHourly = AvgRentPriceForHourlyValues.AvgRentPriceForHourly;
            ViewBag.AvgRentPriceForHourlyRandom = AvgRentPriceForHourlyRandom;
            #endregion
            
            #region İstatistik7
            var AvgRentPriceForDailyRandom = random.Next(0, 101);
            var AvgRentPriceForDailyValues = await _httpClientServiceAction.InvokeAsync<ResultStatisticsDto>("Statistics/GetAvgRentPriceForDaily");
            ViewBag.AvgRentPriceForDaily = AvgRentPriceForDailyValues.AvgRentPriceForDaily;
            ViewBag.AvgRentPriceForDailyRandom = AvgRentPriceForDailyRandom;
            #endregion
            
            #region İstatistik8
            var AvgRentPriceForWeeklyRandom = random.Next(0, 101);
            var AvgRentPriceForWeeklyValues = await _httpClientServiceAction.InvokeAsync<ResultStatisticsDto>("Statistics/GetAvgRentPriceForWeekly");
            ViewBag.AvgRentPriceForWeekly = AvgRentPriceForWeeklyValues.AvgRentPriceForWeekly;
            ViewBag.AvgRentPriceForWeeklyRandom = AvgRentPriceForWeeklyRandom;
            #endregion
            
            #region İstatistik9
            var CarCountByTranmissionIsAutoRandom = random.Next(0, 101);
            var CarCountByTranmissionIsAutoValues = await _httpClientServiceAction.InvokeAsync<ResultStatisticsDto>("Statistics/GetCarCountByTranmissionIsAuto");
            ViewBag.CarCountByTranmissionIsAuto = CarCountByTranmissionIsAutoValues.CarCountByTransmissionIsAuto;
            ViewBag.CarCountByTranmissionIsAutoRandom = CarCountByTranmissionIsAutoRandom;
            #endregion

            #region İstatistik10
            var BrandNameByMaxCarRandom = random.Next(0, 101);
            var BrandNameByMaxCarValues = await _httpClientServiceAction.InvokeAsync<ResultStatisticsDto>("Statistics/GetBrandNameByMaxCar");
            ViewBag.BrandNameByMaxCar = BrandNameByMaxCarValues.BrandNameByMaxCar;
            ViewBag.BrandNameByMaxCarRandom = BrandNameByMaxCarRandom;
            #endregion

            #region İstatistik11
            var BlogTitleByMaxBlogCommentRandom = random.Next(0, 101);
            var BlogTitleByMaxBlogCommentValues = await _httpClientServiceAction.InvokeAsync<ResultStatisticsDto>("Statistics/GetBlogTitleByMaxBlogComment");
            ViewBag.BlogTitleByMaxBlogComment = BlogTitleByMaxBlogCommentValues.BlogTitleByMaxBlogComment;
            ViewBag.BlogTitleByMaxBlogCommentRandom = BlogTitleByMaxBlogCommentRandom;
            #endregion

            #region İstatistik12
            var CarCountByKmSmallerThen10000Random = random.Next(0, 101);
            var CarCountByKmSmallerThen10000Values = await _httpClientServiceAction.InvokeAsync<ResultStatisticsDto>("Statistics/GetCarCountByKmSmallerThen10000");
            ViewBag.CarCountByKmSmallerThen10000 = CarCountByKmSmallerThen10000Values.CarCountByKmSmallerThen10000;
            ViewBag.CarCountByKmSmallerThen10000Random = CarCountByKmSmallerThen10000Random;
            #endregion
            
            #region İstatistik13
            var CarCountByFuelGasolineOrDieselRandom = random.Next(0, 101);
            var CarCountByFuelGasolineOrDieselValues = await _httpClientServiceAction.InvokeAsync<ResultStatisticsDto>("Statistics/GetCarCountByFuelGasolineOrDiesel");
            ViewBag.CarCountByFuelGasolineOrDiesel = CarCountByFuelGasolineOrDieselValues.CarCountByFuelGasolineOrDiesel;
            ViewBag.CarCountByFuelGasolineOrDieselRandom = CarCountByFuelGasolineOrDieselRandom;
            #endregion
            
            #region İstatistik14
            var CarCountByFuelElectricRandom = random.Next(0, 101);
            var CarCountByFuelElectricValues = await _httpClientServiceAction.InvokeAsync<ResultStatisticsDto>("Statistics/GetCarCountByFuelElectric");
            ViewBag.CarCountByFuelElectric = CarCountByFuelElectricValues.CarCountByFuelElectric;
            ViewBag.CarCountByFuelElectricRandom = CarCountByFuelElectricRandom;
            #endregion

            #region İstatistik15
            var CarBrandAndModelByRentPriceDailyMaxRandom = random.Next(0, 101);
            var CarBrandAndModelByRentPriceDailyMaxValues = await _httpClientServiceAction.InvokeAsync<ResultStatisticsDto>("Statistics/GetCarBrandAndModelByRentPriceDailyMax");
            ViewBag.CarBrandAndModelByRentPriceDailyMax = CarBrandAndModelByRentPriceDailyMaxValues.CarBrandAndModelByRentPriceDailyMax;
            ViewBag.CarBrandAndModelByRentPriceDailyMaxRandom = CarBrandAndModelByRentPriceDailyMaxRandom;
            #endregion

            #region İstatistik16
            var CarBrandAndModelByRentPriceDailyMinRandom = random.Next(0, 101);
            var CarBrandAndModelByRentPriceDailyMinValues = await _httpClientServiceAction.InvokeAsync<ResultStatisticsDto>("Statistics/GetCarBrandAndModelByRentPriceDailyMin");
            ViewBag.CarBrandAndModelByRentPriceDailyMin = CarBrandAndModelByRentPriceDailyMinValues.CarBrandAndModelByRentPriceDailyMin;
            ViewBag.CarBrandAndModelByRentPriceDailyMinRandom = CarBrandAndModelByRentPriceDailyMinRandom;
            #endregion

            return View();
        }
    }
}
//10 11