using CarBook.Dto.RentACarDtos;
using CarBook.WebUI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Controllers
{
    [AllowAnonymous]
    public class RentACarListController : Controller
    {
        private readonly HttpClientServiceAction _httpClientServiceAction;

        public RentACarListController(HttpClientServiceAction httpClientServiceAction)
        {
            _httpClientServiceAction = httpClientServiceAction;
        }

        public async Task<IActionResult> Index(int id)
        {
            ViewBag.v1 = "Kiralık Araçlar";
            ViewBag.v2 = "Araç kiralamak için hemen bir araç seçin";

            var locationID = TempData["ID"];
            id = int.Parse(locationID.ToString());

            var values = await _httpClientServiceAction.InvokeAsync<List<FilterRentACarDto>>($"RentACars?locationID={id}&available=true");
            if (values != null)
                return View(values);
            return View();
        }
    }
}
