using CarBook.Dto.LocationDtos;
using CarBook.Dto.ReservationDtos;
using CarBook.WebUI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarBook.WebUI.Controllers
{
    public class ReservationController : Controller
    {
        private readonly HttpClientServiceAction _httpClientServiceAction;

        public ReservationController(HttpClientServiceAction httpClientServiceAction)
        {
            _httpClientServiceAction = httpClientServiceAction;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            ViewBag.v1 = "Araç Kiralama";
            ViewBag.v2 = "Araç Rezervasyon Formu";
            ViewBag.v3 = id;
            var values = await _httpClientServiceAction.InvokeAsync<List<ResultLocationDto>>("Locations");
            List<SelectListItem> values2 = (from x in values
                                            select new SelectListItem
                                            {
                                                Text = x.Name,
                                                Value = x.ID.ToString()
                                            }).ToList();
            ViewBag.v = values2;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateReservationDto createReservationtDto)
        {
            var isSucceded = await _httpClientServiceAction.CreateAsync<CreateReservationDto>("Reservations", createReservationtDto);
            return isSucceded ? RedirectToAction("Index", "Home") : View();
        }
    }
}
