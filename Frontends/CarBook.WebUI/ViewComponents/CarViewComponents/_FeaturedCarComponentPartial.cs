using CarBook.Dto.CarDtos;
using CarBook.WebUI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.CarViewComponents
{
    public class _FeaturedCarComponentPartial : ViewComponent
    {
        private readonly HttpClientServiceViewComponent _httpClientServiceViewComponent;

        public _FeaturedCarComponentPartial(HttpClientServiceViewComponent httpClientServiceViewComponent)
        {
            _httpClientServiceViewComponent = httpClientServiceViewComponent;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await _httpClientServiceViewComponent.InvokeAsync<List<ResultLast5CarsWithBrandDto>>("Cars/GetLast5CarsWithBrand");
        }
    }
}
