using CarBook.Dto.PricingDto;
using CarBook.WebUI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PricingBook.WebUI.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminPricing")]
    public class AdminPricingController : Controller
    {
        private readonly HttpClientServiceAction _httpClientServiceAction;

        public AdminPricingController(HttpClientServiceAction httpClientServiceAction)
        {
            _httpClientServiceAction = httpClientServiceAction;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var values = await _httpClientServiceAction.InvokeAsync<List<ResultPricingDto>>("Pricings");
            return View(values);
        }

        [HttpGet]
        [Route("CreatePricing")]
        public async Task<IActionResult> CreatePricing()
        {
            return View();
        }

        [Route("CreatePricing")]
        [HttpPost]
        public async Task<IActionResult> CreatePricing(CreatePricingDto createPricingDto)
        {
            var isSucceded = await _httpClientServiceAction.CreateAsync<CreatePricingDto>("Pricings", createPricingDto);
            return isSucceded ? RedirectToAction("Index", "AdminPricing", new { area = "Admin" }) : View();
        }

        [Route("RemovePricing/{id}")]
        public async Task<IActionResult> RemovePricing(int id)
        {
            var isSucceded = await _httpClientServiceAction.RemoveAsync($"Pricings/{id}");
            return isSucceded ? RedirectToAction("Index", "AdminPricing", new { area = "Admin" }) : View();
        }


        [HttpGet]
        [Route("UpdatePricing/{id}")]
        public async Task<IActionResult> UpdatePricing(int id)
        {
            var Pricingvalues = await _httpClientServiceAction.InvokeAsync<List<ResultPricingDto>>("Pricings");
            List<SelectListItem> result = (from x in Pricingvalues
                                           select new SelectListItem
                                           {
                                               Text = x.Name,
                                               Value = x.ID.ToString()
                                           }).ToList();
            ViewBag.PricingValues = result;

            var values = await _httpClientServiceAction.InvokeAsync<UpdatePricingDto>($"Pricings/{id}");
            if (values != null)
                return View(values);
            return View();
        }

        [HttpPost]
        [Route("UpdatePricing/{id}")]
        public async Task<IActionResult> UpdatePricing(UpdatePricingDto updatePricingDto)
        {
            var isSucceded = await _httpClientServiceAction.UpdateAsync<UpdatePricingDto>("Pricings", updatePricingDto);
            return isSucceded ? RedirectToAction("Index", "AdminPricing", new { area = "Admin" }) : View();
        }
    }
}
