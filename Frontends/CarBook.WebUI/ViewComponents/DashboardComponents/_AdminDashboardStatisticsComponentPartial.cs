using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using CarBook.Dto.StatisticsDtos;
using CarBook.WebUI.Services;

namespace CarBook.WebUI.ViewComponents.DashboardComponents
{
    public class _AdminDashboardStatisticsComponentPartial : ViewComponent
    {
        private readonly HttpClientServiceAction _httpClientServiceAction;
        public _AdminDashboardStatisticsComponentPartial(HttpClientServiceAction httpClientFactory)
        {
            _httpClientServiceAction = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
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
            var BrandCountRandom = random.Next(0, 101);
            var BrandCountValues = await _httpClientServiceAction.InvokeAsync<ResultStatisticsDto>("Statistics/GetBrandCount");
            ViewBag.BrandCount = BrandCountValues.BrandCount;
            ViewBag.BrandCountRandom = BrandCountRandom;
            #endregion

            #region İstatistik4
            var AvgRentPriceForDailyRandom = random.Next(0, 101);
            var AvgRentPriceForDailyValues = await _httpClientServiceAction.InvokeAsync<ResultStatisticsDto>("Statistics/GetAvgRentPriceForDaily");
            ViewBag.AvgRentPriceForDaily = AvgRentPriceForDailyValues.AvgRentPriceForDaily;
            ViewBag.AvgRentPriceForDailyRandom = AvgRentPriceForDailyRandom;
            #endregion

            return View();
        }
    }
}
