using CarBook.Dto.CarPricingDtos;
using CarBook.WebUI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Controllers
{
    [AllowAnonymous]
    public class CarController : Controller
    {
        private readonly HttpClientServiceAction _httpClientService;

        public CarController(HttpClientServiceAction httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.v1 ="Arabalar";
            ViewBag.v2 ="Arabalarımız";
            var values = await _httpClientService.InvokeAsync<List<ResultCarPricingWithCarDailyDto>>("CarPricings/GetCarPricingWithCarDaily");

            if(values.Count > 0)
            {
                return View(values);
            }

            return View();
        }

        public async Task<IActionResult> CarDetail(int id)
        {
            ViewBag.CarId = id;
			ViewBag.v1 = "Araç Detayları";
            ViewBag.v2 = "Araçların Teknik Aksesuar Ve Özellikleri";
            return View();
        }
    }
}
