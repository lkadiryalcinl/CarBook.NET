using CarBook.Dto.BannerDtos;
using CarBook.WebUI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.BannerComponents
{
    public class _BannerComponentPartial : ViewComponent
    {
        private readonly HttpClientServiceViewComponent _httpClientServiceViewComponent;

        public _BannerComponentPartial(HttpClientServiceViewComponent httpClientServiceViewComponent)
        {
            _httpClientServiceViewComponent = httpClientServiceViewComponent;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await _httpClientServiceViewComponent.InvokeAsync<ResultBannerDto>("Banners/1");
        }
    }
}
