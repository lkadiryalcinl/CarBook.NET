using CarBook.Dto.SocialMedia;
using CarBook.WebUI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SocialMediaBook.WebUI.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminSocialMedia")]
    [Authorize(Roles = "ADMIN")]
    public class AdminSocialMediaController : Controller
    {

        private readonly HttpClientServiceAction _httpClientSocialMediaAction;

        public AdminSocialMediaController(HttpClientServiceAction httpClientSocialMediaAction)
        {
            _httpClientSocialMediaAction = httpClientSocialMediaAction;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var values = await _httpClientSocialMediaAction.InvokeAsync<List<ResultSocialMediaDto>>("SocialMedias");
            return View(values);
        }


        [HttpGet]
        [Route("CreateSocialMedia")]
        public async Task<IActionResult> CreateSocialMedia()
        {
            return View();
        }

        [HttpPost]
        [Route("CreateSocialMedia")]

        public async Task<IActionResult> CreateSocialMedia(CreateSocialMediaDto createSocialMediaDto)
        {
            var isSucceded = await _httpClientSocialMediaAction.CreateAsync<CreateSocialMediaDto>("SocialMedias", createSocialMediaDto);
            return isSucceded ? RedirectToAction("Index", "AdminSocialMedia", new { area = "Admin" }) : View();
        }

        [Route("RemoveSocialMedia/{id}")]
        public async Task<IActionResult> RemoveSocialMedia(int id)
        {
            var isSucceded = await _httpClientSocialMediaAction.RemoveAsync($"SocialMedias/{id}");
            return isSucceded ? RedirectToAction("Index", "AdminSocialMedia", new { area = "Admin" }) : View();
        }

        [HttpGet]
        [Route("UpdateSocialMedia/{id}")]
        public async Task<IActionResult> UpdateSocialMedia(int id)
        {
            var values = await _httpClientSocialMediaAction.InvokeAsync<UpdateSocialMediaDto>($"SocialMedias/{id}");
            if (values != null)
                return View(values);
            return View();
        }

        [HttpPost]
        [Route("UpdateSocialMedia/{id}")]
        public async Task<IActionResult> UpdateSocialMedia(UpdateSocialMediaDto updateSocialMediaDto)
        {
            var isSucceded = await _httpClientSocialMediaAction.UpdateAsync<UpdateSocialMediaDto>("SocialMedias", updateSocialMediaDto);
            return isSucceded ? RedirectToAction("Index", "AdminSocialMedia", new { area = "Admin" }) : View();
        }
    }
}
