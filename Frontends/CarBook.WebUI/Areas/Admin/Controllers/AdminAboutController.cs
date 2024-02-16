using CarBook.Dto.AboutDtos;
using CarBook.WebUI.Services;
using Microsoft.AspNetCore.Mvc;

namespace AboutBook.WebUI.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminAbout")]
    public class AdminAboutController : Controller
    {

        private readonly HttpClientServiceAction _httpClientServiceAction;

        public AdminAboutController(HttpClientServiceAction httpClientServiceAction)
        {
            _httpClientServiceAction = httpClientServiceAction;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var values = await _httpClientServiceAction.InvokeAsync<List<ResultAboutDto>>("Abouts");
            return View(values);
        }


        [HttpGet]
        [Route("UpdateAbout/{id}")]
        public async Task<IActionResult> UpdateAbout(int id)
        {
            var values = await _httpClientServiceAction.InvokeAsync<UpdateAboutDto>($"Abouts/{id}");
            if (values != null)
                return View(values);
            return View();
        }

        [HttpPost]
        [Route("UpdateAbout/{id}")]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            var isSucceded = await _httpClientServiceAction.UpdateAsync<UpdateAboutDto>("Abouts", updateAboutDto);
            return isSucceded ? RedirectToAction("Index", "AdminAbout", new { area = "Admin" }) : View();
        }
    }
}
