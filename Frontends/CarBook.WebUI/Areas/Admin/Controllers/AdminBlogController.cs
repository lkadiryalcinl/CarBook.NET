using CarBook.Dto.BlogDtos;
using CarBook.WebUI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlogBook.WebUI.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminBlog")]
    public class AdminBlogController : Controller
    {

        private readonly HttpClientServiceAction _httpClientServiceAction;

        public AdminBlogController(HttpClientServiceAction httpClientServiceAction)
        {
            _httpClientServiceAction = httpClientServiceAction;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var values = await _httpClientServiceAction.InvokeAsync<List<ResultAllBlogsWithAuthorDto>>("Blogs/GetAllBlogsWithAuthor");
            return View(values);
        }

        
        [Route("RemoveBlog/{id}")]
        public async Task<IActionResult> RemoveBlog(int id)
        {
            var isSucceded = await _httpClientServiceAction.RemoveAsync($"Blogs/{id}");
            return isSucceded ? RedirectToAction("Index", "AdminBlog", new { area = "Admin" }) : View();
        }

        [Route("GetCommentsByBlogId/{id}")]
        public async Task<IActionResult> GetCommentsByBlogId(int id)
        {
            var values = await _httpClientServiceAction.InvokeAsync<List<ResultAllBlogsWithAuthorDto>>("Blogs/GetAllBlogsWithAuthor");
            return View(values);
        }

    }
}
