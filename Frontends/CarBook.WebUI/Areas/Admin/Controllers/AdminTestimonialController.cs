using CarBook.Dto.TestimonialDtos;
using CarBook.WebUI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TestimonialBook.WebUI.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminTestimonial")]
    [Authorize(Roles = "ADMIN")]
    public class AdminTestimonialController : Controller
    {

        private readonly HttpClientServiceAction _httpClientServiceAction;

        public AdminTestimonialController(HttpClientServiceAction httpClientServiceAction)
        {
            _httpClientServiceAction = httpClientServiceAction;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var values = await _httpClientServiceAction.InvokeAsync<List<ResultTestimonialDto>>("Testimonials");
            return View(values);
        }


        [HttpGet]
        [Route("CreateTestimonial")]
        public async Task<IActionResult> CreateTestimonial()
        {
            return View();
        }

        [HttpPost]
        [Route("CreateTestimonial")]

        public async Task<IActionResult> CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            var isSucceded = await _httpClientServiceAction.CreateAsync<CreateTestimonialDto>("Testimonials", createTestimonialDto);
            return isSucceded ? RedirectToAction("Index", "AdminTestimonial", new { area = "Admin" }) : View();
        }

        [Route("RemoveTestimonial/{id}")]
        public async Task<IActionResult> RemoveTestimonial(int id)
        {
            var isSucceded = await _httpClientServiceAction.RemoveAsync($"Testimonials/{id}");
            return isSucceded ? RedirectToAction("Index", "AdminTestimonial", new { area = "Admin" }) : View();
        }

        [HttpGet]
        [Route("UpdateTestimonial/{id}")]
        public async Task<IActionResult> UpdateTestimonial(int id)
        {
            var values = await _httpClientServiceAction.InvokeAsync<UpdateTestimonialDto>($"Testimonials/{id}");
            if (values != null)
                return View(values);
            return View();
        }

        [HttpPost]
        [Route("UpdateTestimonial/{id}")]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            var isSucceded = await _httpClientServiceAction.UpdateAsync<UpdateTestimonialDto>("Testimonials", updateTestimonialDto);
            return isSucceded ? RedirectToAction("Index", "AdminTestimonial", new { area = "Admin" }) : View();
        }
    }
}
