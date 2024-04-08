using CarBook.Dto.FeatureDtos;
using CarBook.WebUI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FeatureBook.WebUI.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminFeature")]
    [Authorize(Roles = "ADMIN")]
    public class AdminFeatureController : Controller
    {

        private readonly HttpClientServiceAction _httpClientServiceAction;

        public AdminFeatureController(HttpClientServiceAction httpClientServiceAction)
        {
            _httpClientServiceAction = httpClientServiceAction;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var values = await _httpClientServiceAction.InvokeAsync<List<ResultFeatureDto>>("Features");
            return View(values);
        }


        [HttpGet]
        [Route("CreateFeature")]
        public async Task<IActionResult> CreateFeature()
        {
            return View();
        }

        [HttpPost]
        [Route("CreateFeature")]

        public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeatureDto)
        {
            var isSucceded = await _httpClientServiceAction.CreateAsync<CreateFeatureDto>("Features", createFeatureDto);
            return isSucceded ? RedirectToAction("Index", "AdminFeature", new { area = "Admin" }) : View();
        }

        [Route("RemoveFeature/{id}")]
        public async Task<IActionResult> RemoveFeature(int id)
        {
            var isSucceded = await _httpClientServiceAction.RemoveAsync($"Features/{id}");
            return isSucceded ? RedirectToAction("Index", "AdminFeature", new { area = "Admin" }) : View();
        }

        [HttpGet]
        [Route("UpdateFeature/{id}")]
        public async Task<IActionResult> UpdateFeature(int id)
        {
            var values = await _httpClientServiceAction.InvokeAsync<UpdateFeatureDto>($"Features/{id}");
            if (values != null)
                return View(values);
            return View();
        }

        [HttpPost]
        [Route("UpdateFeature/{id}")]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            var isSucceded = await _httpClientServiceAction.UpdateAsync<UpdateFeatureDto>("Features", updateFeatureDto);
            return isSucceded ? RedirectToAction("Index", "AdminFeature", new { area = "Admin" }) : View();
        }
    }
}
