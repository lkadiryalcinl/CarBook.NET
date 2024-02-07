using CarBook.Dto.CarDtos;
using CarBook.WebUI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Controllers
{
    public class CarController : Controller
    {
        private readonly HttpClientServiceAction _httpClientService;

        public CarController(HttpClientServiceAction httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _httpClientService.InvokeAsync<List<ResultCarWithBrandsDto>>("Cars/GetCarsListWithBrand");

            if(values.Count > 0)
            {
                return View(values);
            }

            return View();
        }
    }
}
