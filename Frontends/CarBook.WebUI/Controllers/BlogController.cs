using CarBook.Dto.BlogDtos;
using CarBook.Dto.CarDtos;
using CarBook.Dto.CommentDtos;
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
            var val = await _httpClientService.InvokeAsync<ResultCommentCountByBlogIdDto>($"Comments/GetCommentsCountByBlogIdQuery/{id}");
            ViewBag.CommentsCount = val.CommentCount;

            var values = await _httpClientService.InvokeAsync<GetBlogById>($"Blogs/{id}");
            return View(values);
        }

        [HttpGet]
        public async Task<PartialViewResult> AddComment(int id)
        {
            ViewBag.blogId = id;
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(CreateCommentDto createCommentDto)
        {
            createCommentDto.CreatedDate = DateTime.Now;
            createCommentDto.ImageUrl = "";
            var isSucceded = await _httpClientService.CreateAsync<CreateCommentDto>("Comments", createCommentDto);
            return isSucceded ? RedirectToAction("BlogDetail", "Blog", new { id = createCommentDto.BlogID }) : View();
        }
    }
}
