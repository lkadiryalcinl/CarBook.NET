using CarBook.Dto.CarFeatureDto;
using CarBook.WebUI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.CarDetailViewComponents
{
    public class _CarDetailCarFeatureByCarIdComponentPartial : ViewComponent
	{
        private readonly HttpClientServiceViewComponent _httpClientViewComponent;

        public _CarDetailCarFeatureByCarIdComponentPartial(HttpClientServiceViewComponent httpClientViewComponent)
        {
            _httpClientViewComponent = httpClientViewComponent;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            ViewBag.CarId = id;
            return await _httpClientViewComponent.InvokeAsync<List<ResultAdminCarFeatureByCarIdDto>>($"CarFeatures/{id}");
        }
    }
}
