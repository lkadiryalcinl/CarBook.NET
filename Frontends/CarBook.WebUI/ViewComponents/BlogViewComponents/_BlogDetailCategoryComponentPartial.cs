using CarBook.Dto.CategoryDtos;
using CarBook.WebUI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailCategoryComponentPartial : ViewComponent
    {
        private readonly HttpClientServiceViewComponent _httpClientServiceViewComponent;

        public _BlogDetailCategoryComponentPartial(HttpClientServiceViewComponent httpClientServiceViewComponent)
        {
            _httpClientServiceViewComponent = httpClientServiceViewComponent;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await _httpClientServiceViewComponent.
                InvokeAsync<List<ResultCategoryDto>>("Categories");
        }
    }
}
