using CarBook.Dto.BlogDtos;
using CarBook.WebUI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.BlogViewComponents
{
    public class _GetLast3BlogsWithAuthorListComponentPartial : ViewComponent
    {
        private readonly HttpClientServiceViewComponent _httpClientServiceViewComponent;

        public _GetLast3BlogsWithAuthorListComponentPartial(HttpClientServiceViewComponent 
            httpClientServiceViewComponent)
        {
            _httpClientServiceViewComponent = httpClientServiceViewComponent;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await _httpClientServiceViewComponent.
                InvokeAsync<List<ResultLast3BlogsWithAuthorDto>>("Blogs/GetLast3BlogsWithAuthor");
        }
    }
}
