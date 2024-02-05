using CarBook.Dto.FooterAddressDtos;
using CarBook.WebUI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.FooterAddressComponents
{
    public class _FooterAddressComponentPartial : ViewComponent
    {
        private readonly HttpClientService _httpClientService;

        public _FooterAddressComponentPartial(HttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await _httpClientService.InvokeAsync<ResultFooterAddressDto>("FooterAddresses/1");
        }
    }
}
