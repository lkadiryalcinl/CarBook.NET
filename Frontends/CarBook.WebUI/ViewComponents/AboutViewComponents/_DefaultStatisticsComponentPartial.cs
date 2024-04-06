using CarBook.Dto.StatisticsDtos;
using CarBook.WebUI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.AboutViewComponents
{
    public class _DefaultStatisticsComponentPartial : ViewComponent
    {
        
        private readonly HttpClientServiceAction _httpClientServiceAction;

        public _DefaultStatisticsComponentPartial(HttpClientServiceAction httpClientServiceAction)
        {
            _httpClientServiceAction = httpClientServiceAction;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            #region İstatistik1
            var CarCountValues = await _httpClientServiceAction.InvokeAsync<ResultStatisticsDto>("Statistics/GetCarCount");
            ViewBag.CarCount = CarCountValues.CarCount;
            #endregion

            #region İstatistik2
            var LocationCountValues = await _httpClientServiceAction.InvokeAsync<ResultStatisticsDto>("Statistics/GetLocationCount");
            ViewBag.LocationCount = LocationCountValues.LocationCount;
            #endregion

            #region İstatistik3
            var BrandCountValues = await _httpClientServiceAction.InvokeAsync<ResultStatisticsDto>("Statistics/GetBrandCount");
            ViewBag.BrandCount = BrandCountValues.BrandCount;
            #endregion

            #region İstatistik4
            var CarCountByFuelElectricValues = await _httpClientServiceAction.InvokeAsync<ResultStatisticsDto>("Statistics/GetCarCountByFuelElectric");
            ViewBag.CarCountByFuelElectric = CarCountByFuelElectricValues.CarCountByFuelElectric;
            #endregion

            return View();
        }
    }
}
