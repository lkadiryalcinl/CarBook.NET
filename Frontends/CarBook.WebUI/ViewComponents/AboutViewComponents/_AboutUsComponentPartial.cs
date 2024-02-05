using CarBook.Dto.AboutDtos;
using CarBook.WebUI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.AboutViewComponents
{
    public class _AboutUsComponentPartial : ViewComponent
    {
        private readonly HttpClientService _httpClientService;

        public _AboutUsComponentPartial(HttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
           return await _httpClientService.InvokeAsync<ResultAboutDto>("Abouts/1");
        }
    }
}
