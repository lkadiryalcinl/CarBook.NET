using CarBook.Dto.AboutDtos;
using CarBook.Dto.StatisticsDtos;
using CarBook.WebUI.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CarBook.WebUI.ViewComponents.AboutViewComponents
{
    public class _AboutUsComponentPartial : ViewComponent
    {
        private readonly HttpClientServiceViewComponent _httpClientService;

        public _AboutUsComponentPartial(HttpClientServiceViewComponent httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await _httpClientService.InvokeAsync<ResultAboutDto>("Abouts/1");
        }
    }
}
