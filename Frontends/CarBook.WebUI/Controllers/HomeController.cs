using CarBook.Dto.LocationDtos;
using CarBook.WebUI.Models;
using CarBook.WebUI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace CarBook.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClientServiceAction _httpClientServiceAction;

        public HomeController(HttpClientServiceAction httpClientServiceAction)
        {
            _httpClientServiceAction = httpClientServiceAction;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Araçlar Listesi";
            ViewBag.v2 = "Araçlarınızı Buradan Kiralayın";
            var values = await _httpClientServiceAction.InvokeAsync<List<ResultLocationDto>>("Locations");
            List<SelectListItem> resultVal = (from x in values
                                              select new SelectListItem
                                              {
                                                  Text = x.Name,
                                                  Value = x.ID.ToString()
                                              }).ToList();
            ViewBag.v = resultVal;
            return View();
        }

        [HttpPost]
        public IActionResult Index(string book_pick_date, string book_off_date, string time_pick, string time_off, string ID)
        {
            TempData["bookpickdate"] = book_pick_date;
            TempData["bookoffdate"] = book_off_date;
            TempData["timepick"] = time_pick;
            TempData["timeoff"] = time_off;
            TempData["ID"] = ID;
            return RedirectToAction("Index", "RentACarList");
        }
    }
}
