using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using CarBook.Dto.BlogDtos;
using CarBook.WebUI.Services;

namespace CarBook.WebUI.ViewComponents.DashboardComponents
{
    public class _AdminDashboardBlogListComponentPartial : ViewComponent
    {
        private readonly HttpClientServiceViewComponent _viewComponent;

        public _AdminDashboardBlogListComponentPartial(HttpClientServiceViewComponent viewComponent)
        {
            _viewComponent = viewComponent;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await _viewComponent.InvokeAsync<List<ResultAllBlogsWithAuthorDto>>("Blogs/GetAllBlogsWithAuthor");
        }
    }
}
