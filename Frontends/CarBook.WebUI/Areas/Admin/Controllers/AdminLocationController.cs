using CarBook.Dto.LocationDtos;
using CarBook.WebUI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LocationBook.WebUI.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminLocation")]
    [Authorize(Roles = "ADMIN")]
    public class AdminLocationController : Controller
    {

        private readonly HttpClientServiceAction _httpClientServiceAction;

        public AdminLocationController(HttpClientServiceAction httpClientServiceAction)
        {
            _httpClientServiceAction = httpClientServiceAction;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var values = await _httpClientServiceAction.InvokeAsync<List<ResultLocationDto>>("Locations");
            return View(values);
        }


        [HttpGet]
        [Route("CreateLocation")]
        public async Task<IActionResult> CreateLocation()
        {
            return View();
        }

        [HttpPost]
        [Route("CreateLocation")]

        public async Task<IActionResult> CreateLocation(CreateLocationDto createLocationDto)
        {
            var isSucceded = await _httpClientServiceAction.CreateAsync<CreateLocationDto>("Locations", createLocationDto);
            return isSucceded ? RedirectToAction("Index", "AdminLocation", new { area = "Admin" }) : View();
        }

        [Route("RemoveLocation/{id}")]
        public async Task<IActionResult> RemoveLocation(int id)
        {
            var isSucceded = await _httpClientServiceAction.RemoveAsync($"Locations/{id}");
            return isSucceded ? RedirectToAction("Index", "AdminLocation", new { area = "Admin" }) : View();
        }

        [HttpGet]
        [Route("UpdateLocation/{id}")]
        public async Task<IActionResult> UpdateLocation(int id)
        {
            var values = await _httpClientServiceAction.InvokeAsync<UpdateLocationDto>($"Locations/{id}");
            if (values != null)
                return View(values);
            return View();
        }

        [HttpPost]
        [Route("UpdateLocation/{id}")]
        public async Task<IActionResult> UpdateLocation(UpdateLocationDto updateLocationDto)
        {
            var isSucceded = await _httpClientServiceAction.UpdateAsync<UpdateLocationDto>("Locations", updateLocationDto);
            return isSucceded ? RedirectToAction("Index", "AdminLocation", new { area = "Admin" }) : View();
        }
    }
}
