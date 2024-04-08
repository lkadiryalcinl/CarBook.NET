using CarBook.Dto.FooterAddressDtos;
using CarBook.WebUI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FooterAddressBook.WebUI.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminFooterAddress")]
    [Authorize(Roles = "ADMIN")]
    public class AdminFooterAddressController : Controller
    {

        private readonly HttpClientServiceAction _httpClientServiceAction;

        public AdminFooterAddressController(HttpClientServiceAction httpClientServiceAction)
        {
            _httpClientServiceAction = httpClientServiceAction;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var values = await _httpClientServiceAction.InvokeAsync<List<ResultFooterAddressDto>>("FooterAddresses");
            return View(values);
        }

        [HttpGet]
        [Route("UpdateFooterAddress/{id}")]
        public async Task<IActionResult> UpdateFooterAddress(int id)
        {
            var values = await _httpClientServiceAction.InvokeAsync<UpdateFooterAddressDto>($"FooterAddresses/{id}");
            if (values != null)
                return View(values);
            return View();
        }

        [HttpPost]
        [Route("UpdateFooterAddress/{id}")]
        public async Task<IActionResult> UpdateFooterAddress(UpdateFooterAddressDto updateFooterAddressDto)
        {
            var isSucceded = await _httpClientServiceAction.UpdateAsync<UpdateFooterAddressDto>("FooterAddresses", updateFooterAddressDto);
            return isSucceded ? RedirectToAction("Index", "AdminFooterAddress", new { area = "Admin" }) : View();
        }
    }
}
