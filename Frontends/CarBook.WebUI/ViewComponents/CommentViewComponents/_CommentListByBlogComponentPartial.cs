using CarBook.Dto.CommentDtos;
using CarBook.Dto.TagCloudDtos;
using CarBook.WebUI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.CommentViewComponents
{
    public class _CommentListByBlogComponentPartial : ViewComponent
    {
        private readonly HttpClientServiceViewComponent _component;

        public _CommentListByBlogComponentPartial(HttpClientServiceViewComponent component)
        {
            _component = component;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            return await _component.InvokeAsync<List<ResultCommentByBlogIdDto>>($"Comments/GetCommentListByBlogId/{id}");
        }
    }
}
