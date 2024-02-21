using CarBook.Dto.ServiceDtos;
using CarBook.WebUI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ServiceBook.WebUI.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminService")]
    public class AdminServiceController : Controller
    {

        private readonly HttpClientServiceAction _httpClientServiceAction;

        public AdminServiceController(HttpClientServiceAction httpClientServiceAction)
        {
            _httpClientServiceAction = httpClientServiceAction;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var values = await _httpClientServiceAction.InvokeAsync<List<ResultServiceDto>>("Services");
            return View(values);
        }


        [HttpGet]
        [Route("CreateService")]
        public async Task<IActionResult> CreateService()
        {
            return View();
        }

        [HttpPost]
        [Route("CreateService")]

        public async Task<IActionResult> CreateService(CreateServiceDto createServiceDto)
        {
            var isSucceded = await _httpClientServiceAction.CreateAsync<CreateServiceDto>("Services", createServiceDto);
            return isSucceded ? RedirectToAction("Index", "AdminService", new { area = "Admin" }) : View();
        }

        [Route("RemoveService/{id}")]
        public async Task<IActionResult> RemoveService(int id)
        {
            var isSucceded = await _httpClientServiceAction.RemoveAsync($"Services/{id}");
            return isSucceded ? RedirectToAction("Index", "AdminService", new { area = "Admin" }) : View();
        }

        [HttpGet]
        [Route("UpdateService/{id}")]
        public async Task<IActionResult> UpdateService(int id)
        {
            var values = await _httpClientServiceAction.InvokeAsync<UpdateServiceDto>($"Services/{id}");
            if (values != null)
                return View(values);
            return View();
        }

        [HttpPost]
        [Route("UpdateService/{id}")]
        public async Task<IActionResult> UpdateService(UpdateServiceDto updateServiceDto)
        {
            var isSucceded = await _httpClientServiceAction.UpdateAsync<UpdateServiceDto>("Services", updateServiceDto);
            return isSucceded ? RedirectToAction("Index", "AdminService", new { area = "Admin" }) : View();
        }
    }
}
