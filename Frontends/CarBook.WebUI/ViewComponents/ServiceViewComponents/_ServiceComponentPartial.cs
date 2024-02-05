using CarBook.Dto.ServiceDtos;
using CarBook.WebUI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.ServiceViewComponents
{
    public class _ServiceComponentPartial : ViewComponent
    {
        private readonly HttpClientService _httpClientService;

        public _ServiceComponentPartial(HttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await _httpClientService.InvokeAsync<List<ResultServiceDto>>("Services");
        }
    }
}
