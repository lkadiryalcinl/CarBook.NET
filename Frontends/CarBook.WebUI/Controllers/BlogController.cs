using CarBook.Dto.BlogDtos;
using CarBook.Dto.CarPricingDtos;
using CarBook.WebUI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Controllers
{
    public class BlogController : Controller
    {
        private readonly HttpClientServiceAction _httpClientService;

        public BlogController(HttpClientServiceAction httpClientServiceAction)
        {
            _httpClientService = httpClientServiceAction;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Blog";
            ViewBag.v2 = "Yazarlarımızın Blogları";

            var values = await _httpClientService.InvokeAsync<List<ResultAllBlogsWithAuthorDto>>("Blogs/GetAllBlogsWithAuthor");

            if (values.Count > 0)
            {
                return View(values);
            }

            return View();
        }

        public async Task<IActionResult> BlogDetail(int id)
        {
            ViewBag.v1 = "Blog";
            ViewBag.v2 = "Blog Detayı ve Yorumlar";

            ViewBag.blogId = id;

            var values = await _httpClientService.InvokeAsync<GetBlogById>($"Blogs/{id}");
            return View(values);
        }
    }
}
