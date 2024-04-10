using Microsoft.AspNetCore.Mvc;
using CarBook.Dto.CarPricingDtos;
using CarBook.WebUI.Services;

namespace CarBook.WebUI.ViewComponents.DashboardComponents
{
    public class _AdminDashboardCarPricingListComponentPartial : ViewComponent
    {
        private readonly HttpClientServiceViewComponent _viewComponent;

        public _AdminDashboardCarPricingListComponentPartial(HttpClientServiceViewComponent viewComponent)
        {
            _viewComponent = viewComponent;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.v1 = "Paketler";
            ViewBag.v2 = "Araç Fiyat Paketleri";
            return await _viewComponent.InvokeAsync<List<ResultCarPricingListWithModelDto>>("CarPricings/GetCarPricingWithTimePeriodList");
        }
    }
}
