using CarBook.Dto.BlogDtos;
using CarBook.WebUI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailAuthorInfoComponentPartial : ViewComponent
    {
        private readonly HttpClientServiceViewComponent _component;

        public _BlogDetailAuthorInfoComponentPartial(HttpClientServiceViewComponent component)
        {
            _component = component;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var dummy = await _component.InvokeAsync<GetBlogByAuthorIdDto>($"Blogs/GetBlogByAuthorId/{id}");
            return dummy;
        }
    }
}
