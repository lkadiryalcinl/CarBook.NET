using CarBook.Dto.CategoryDtos;
using CarBook.WebUI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CategoryBook.WebUI.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminCategory")]
    [Authorize(Roles = "ADMIN")]
    public class AdminCategoryController : Controller
    {

        private readonly HttpClientServiceAction _httpClientServiceAction;

        public AdminCategoryController(HttpClientServiceAction httpClientServiceAction)
        {
            _httpClientServiceAction = httpClientServiceAction;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var values = await _httpClientServiceAction.InvokeAsync<List<ResultCategoryDto>>("Categories");
            return View(values);
        }

        [HttpGet]
        [Route("CreateCategory")]
        public async Task<IActionResult> CreateCategory()
        {
            return View();
        }

        [HttpPost]
        [Route("CreateCategory")]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            var isSucceded = await _httpClientServiceAction.CreateAsync<CreateCategoryDto>("Categories", createCategoryDto);
            return isSucceded ? RedirectToAction("Index", "AdminCategory", new { area = "Admin" }) : View();
        }

        [Route("RemoveCategory/{id}")]
        public async Task<IActionResult> RemoveCategory(int id)
        {
            var isSucceded = await _httpClientServiceAction.RemoveAsync($"Categories/{id}");
            return isSucceded ? RedirectToAction("Index", "AdminCategory", new { area = "Admin" }) : View();
        }

        [HttpGet]
        [Route("UpdateCategory/{id}")]
        public async Task<IActionResult> UpdateCategory(int id)
        {
            var values = await _httpClientServiceAction.InvokeAsync<UpdateCategoryDto>($"Categories/{id}");
            if (values != null)
                return View(values);
            return View();
        }

        [HttpPost]
        [Route("UpdateCategory/{id}")]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var isSucceded = await _httpClientServiceAction.UpdateAsync<UpdateCategoryDto>("Categories", updateCategoryDto);
            return isSucceded ? RedirectToAction("Index", "AdminCategory", new { area = "Admin" }) : View();
        }
    }
}
