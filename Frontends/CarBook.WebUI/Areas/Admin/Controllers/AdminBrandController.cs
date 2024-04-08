using CarBook.Dto.BrandDtos;
using CarBook.WebUI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BrandBook.WebUI.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminBrand")]
    [Authorize(Roles = "ADMIN")]
    public class AdminBrandController : Controller
    {

        private readonly HttpClientServiceAction _httpClientServiceAction;

        public AdminBrandController(HttpClientServiceAction httpClientServiceAction)
        {
            _httpClientServiceAction = httpClientServiceAction;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var values = await _httpClientServiceAction.InvokeAsync<List<ResultBrandDto>>("Brands");
            return View(values);
        }

        [HttpGet]
        [Route("CreateBrand")]
        public async Task<IActionResult> CreateBrand()
        {
            return View();
        }

        [HttpPost]
        [Route("CreateBrand")]
        public async Task<IActionResult> CreateBrand(CreateBrandDto createBrandDto)
        {
            var isSucceded = await _httpClientServiceAction.CreateAsync<CreateBrandDto>("Brands", createBrandDto);
            return isSucceded ? RedirectToAction("Index","AdminBrand",new {area = "Admin"}) : View();
        }

        [Route("RemoveBrand/{id}")]
        public async Task<IActionResult> RemoveBrand(int id)
        {
            var isSucceded = await _httpClientServiceAction.RemoveAsync($"Brands/{id}");
            return isSucceded ? RedirectToAction("Index", "AdminBrand", new { area = "Admin" }) : View();
        }

        [HttpGet]
        [Route("UpdateBrand/{id}")]
        public async Task<IActionResult> UpdateBrand(int id)
        {
            var values = await _httpClientServiceAction.InvokeAsync<UpdateBrandDto>($"Brands/{id}");
            if (values != null)
                return View(values);
            return View();
        }

        [HttpPost]
        [Route("UpdateBrand/{id}")]
        public async Task<IActionResult> UpdateBrand(UpdateBrandDto updateBrandDto)
        {
            var isSucceded = await _httpClientServiceAction.UpdateAsync<UpdateBrandDto>("Brands", updateBrandDto);
            return isSucceded ? RedirectToAction("Index", "AdminBrand", new { area = "Admin" }) : View();
        }
    }
}
