using CarBook.Dto.BlogDtos;
using CarBook.WebUI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailMainComponentPartial : ViewComponent
    {
        private readonly HttpClientServiceViewComponent _component;

        public _BlogDetailMainComponentPartial(HttpClientServiceViewComponent component)
        {
            _component = component;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id,int CommentsCount)
        {

            var values =  await _component.InvokeAsyncVal<GetBlogById>($"Blogs/{id}");
            values.CommentsCount = CommentsCount;
            return View(values);
        }
    }
}
