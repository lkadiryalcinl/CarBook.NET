using CarBook.Dto.CarPricingDtos;
using CarBook.WebUI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Controllers
{
    public class CarPricingController : Controller
    {
        private readonly HttpClientServiceAction _httpClientService;

        public CarPricingController(HttpClientServiceAction httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public async Task<IActionResult> Index()
        {

            ViewBag.v1 = "Paketler";
            ViewBag.v2 = "Araç Fiyat Paketlerimiz";
            var values = await _httpClientService.InvokeAsync<List<ResultCarPricingListWithModelDto>>("CarPricings/GetCarPricingWithTimePeriodList");

            if (values.Count > 0)
            {
                return View(values);
            }

            return View();
        }
    }
}
