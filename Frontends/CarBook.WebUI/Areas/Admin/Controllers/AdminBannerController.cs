using CarBook.Dto.BannerDtos;
using CarBook.WebUI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BannerBook.WebUI.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminBanner")]
    [Authorize(Roles = "ADMIN")]
    public class AdminBannerController : Controller
    {

        private readonly HttpClientServiceAction _httpClientServiceAction;

        public AdminBannerController(HttpClientServiceAction httpClientServiceAction)
        {
            _httpClientServiceAction = httpClientServiceAction;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var values = await _httpClientServiceAction.InvokeAsync<List<ResultBannerDto>>("Banners");
            return View(values);
        }

        [HttpGet]
        [Route("UpdateBanner/{id}")]
        public async Task<IActionResult> UpdateBanner(int id)
        {
            var values = await _httpClientServiceAction.InvokeAsync<UpdateBannerDto>($"Banners/{id}");
            if (values != null)
                return View(values);
            return View();
        }

        [HttpPost]
        [Route("UpdateBanner/{id}")]
        public async Task<IActionResult> UpdateBanner(UpdateBannerDto updateBannerDto)
        {
            var isSucceded = await _httpClientServiceAction.UpdateAsync<UpdateBannerDto>("Banners", updateBannerDto);
            return isSucceded ? RedirectToAction("Index", "AdminBanner", new { area = "Admin" }) : View();
        }
    }
}
