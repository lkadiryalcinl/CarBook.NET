using CarBook.Dto.AdminCarDtos;
using CarBook.Dto.BrandDtos;
using CarBook.Dto.CarDtos;
using CarBook.WebUI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarBook.WebUI.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminCar")]
    public class AdminCarController : Controller
    {
        private readonly HttpClientServiceAction _httpClientServiceAction;

        public AdminCarController(HttpClientServiceAction httpClientServiceAction)
        {
            _httpClientServiceAction = httpClientServiceAction;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var values =  await _httpClientServiceAction.InvokeAsync<List<ResultAdminCarWithBrandDto>>("Cars/GetCarsListWithBrand");
            return View(values);
        }

        [HttpGet]
        [Route("CreateCar")]
        public async Task<IActionResult> CreateCar()
        {
            var values = await _httpClientServiceAction.InvokeAsync<List<ResultBrandDto>>("Brands");
            List<SelectListItem> brandValues = (from x in values
                                                select new SelectListItem
                                                {
                                                    Text = x.Name,
                                                    Value = x.ID.ToString()
                                                }).ToList();
            ViewBag.BrandValues = brandValues;
            return View();
        }

        [Route("CreateCar")]
        [HttpPost]
        public async Task<IActionResult> CreateCar(CreateCarDto createCarDto)
        {
            var isSucceded = await _httpClientServiceAction.CreateAsync<CreateCarDto>("Cars",createCarDto);
            return isSucceded ? RedirectToAction("Index", "AdminCar", new { area = "Admin" }) : View();
        }

        [Route("RemoveCar/{id}")]
        public async Task<IActionResult> RemoveCar(int id)
        {
            var isSucceded = await _httpClientServiceAction.RemoveAsync($"Cars/{id}");
            return isSucceded ? RedirectToAction("Index", "AdminCar", new { area = "Admin" }) : View();
        }


        [HttpGet]
        [Route("UpdateCar/{id}")]
        public async Task<IActionResult> UpdateCar(int id)
        {
            var brandvalues = await _httpClientServiceAction.InvokeAsync<List<ResultBrandDto>>("Brands");
            List<SelectListItem> result = (from x in brandvalues
                                                select new SelectListItem
                                                {
                                                    Text = x.Name,
                                                    Value = x.ID.ToString()
                                                }).ToList();
            ViewBag.BrandValues = result;

            var values = await _httpClientServiceAction.InvokeAsync<UpdateCarDto>($"Cars/{id}");
            if(values != null)
                return View(values);
            return View();
        }

        [HttpPost]
        [Route("UpdateCar/{id}")]
        public async Task<IActionResult> UpdateCar(UpdateCarDto updateCarDto)
        {
            var isSucceded = await _httpClientServiceAction.UpdateAsync<UpdateCarDto>("Cars", updateCarDto);
            return isSucceded ? RedirectToAction("Index","AdminCar",new {area = "Admin"}) : View();
        }
    }
}
