using CarBook.Dto.TestimonialDtos;
using CarBook.WebUI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.AboutViewComponents
{
    public class _TestimonialComponentPartial : ViewComponent
    {
        private readonly HttpClientService _httpClientService;

        public _TestimonialComponentPartial(HttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await _httpClientService.InvokeAsync<List<ResultTestimonialDto>>("Testimonials");
        }
    }
}
