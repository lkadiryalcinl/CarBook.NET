using CarBook.Dto.BlogDtos;
using CarBook.Dto.TagCloudDtos;
using CarBook.WebUI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailTagCloudComponentPartial : ViewComponent
    {
        private readonly HttpClientServiceViewComponent _component;

        public _BlogDetailTagCloudComponentPartial(HttpClientServiceViewComponent component)
        {
            _component = component;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            return await _component.InvokeAsync<List<GetTagCloudByBlogIdDto>>($"TagClouds/GetTagCloudByBlogId/{id}");
        }
    }
}
