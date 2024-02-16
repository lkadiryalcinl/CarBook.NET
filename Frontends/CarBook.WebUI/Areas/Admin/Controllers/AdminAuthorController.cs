using CarBook.Dto.AuthorDtos;
using CarBook.WebUI.Services;
using Microsoft.AspNetCore.Mvc;

namespace AuthorBook.WebUI.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminAuthor")]
    public class AdminAuthorController : Controller
    {

        private readonly HttpClientServiceAction _httpClientServiceAction;

        public AdminAuthorController(HttpClientServiceAction httpClientServiceAction)
        {
            _httpClientServiceAction = httpClientServiceAction;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var values = await _httpClientServiceAction.InvokeAsync<List<ResultAuthorDto>>("Authors");
            return View(values);
        }


        [HttpGet]
        [Route("CreateAuthor")]
        public async Task<IActionResult> CreateAuthor()
        {
            return View();
        }

        [HttpPost]
        [Route("CreateAuthor")]

        public async Task<IActionResult> CreateAuthor(CreateAuthorDto createAuthorDto)
        {
            var isSucceded = await _httpClientServiceAction.CreateAsync<CreateAuthorDto>("Authors", createAuthorDto);
            return isSucceded ? RedirectToAction("Index", "AdminAuthor", new { area = "Admin" }) : View();
        }

        [Route("RemoveAuthor/{id}")]
        public async Task<IActionResult> RemoveAuthor(int id)
        {
            var isSucceded = await _httpClientServiceAction.RemoveAsync($"Authors/{id}");
            return isSucceded ? RedirectToAction("Index", "AdminAuthor", new { area = "Admin" }) : View();
        }

        [HttpGet]
        [Route("UpdateAuthor/{id}")]
        public async Task<IActionResult> UpdateAuthor(int id)
        {
            var values = await _httpClientServiceAction.InvokeAsync<UpdateAuthorDto>($"Authors/{id}");
            if (values != null)
                return View(values);
            return View();
        }

        [HttpPost]
        [Route("UpdateAuthor/{id}")]
        public async Task<IActionResult> UpdateAuthor(UpdateAuthorDto updateAuthorDto)
        {
            var isSucceded = await _httpClientServiceAction.UpdateAsync<UpdateAuthorDto>("Authors", updateAuthorDto);
            return isSucceded ? RedirectToAction("Index", "AdminAuthor", new { area = "Admin" }) : View();
        }
    }
}
