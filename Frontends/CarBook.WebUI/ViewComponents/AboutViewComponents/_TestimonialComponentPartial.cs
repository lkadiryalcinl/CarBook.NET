using CarBook.Dto.TestimonialDtos;
using CarBook.WebUI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.AboutViewComponents
{
    public class _TestimonialComponentPartial : ViewComponent
    {
        private readonly HttpClientServiceViewComponent _httpClientService;

        public _TestimonialComponentPartial(HttpClientServiceViewComponent httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await _httpClientService.InvokeAsync<List<ResultTestimonialDto>>("Testimonials");
        }
    }
}
