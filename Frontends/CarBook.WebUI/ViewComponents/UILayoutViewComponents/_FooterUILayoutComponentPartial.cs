using CarBook.Dto.FooterAddressDtos;
using CarBook.WebUI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.FooterAddressComponents
{
    public class _FooterUILayoutComponentPartial : ViewComponent
    {
        private readonly HttpClientService _httpClientService;

        public _FooterUILayoutComponentPartial(HttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await _httpClientService.InvokeAsync<ResultFooterAddressDto>("FooterAddresses/1");
        }
    }
}
