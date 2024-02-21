using CarBook.Dto.ContactDtos;
using CarBook.WebUI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContactBook.WebUI.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminContact")]
    public class AdminContactController : Controller
    {

        private readonly HttpClientServiceAction _httpClientServiceAction;

        public AdminContactController(HttpClientServiceAction httpClientServiceAction)
        {
            _httpClientServiceAction = httpClientServiceAction;
        }

        [Route("Index")]
        public async Task<IActionResult> Index(int id)
        {
            ViewBag.v = id;
            var values = await _httpClientServiceAction.InvokeAsync<List<ResultContactDto>>("Contacts");
            return View(values);
        }


        [Route("RemoveContact/{id}")]
        public async Task<IActionResult> RemoveContact(int id)
        {
            var isSucceded = await _httpClientServiceAction.RemoveAsync($"Contacts/{id}");
            return isSucceded ? RedirectToAction("Index", "AdminContact", new { area = "Admin" }) : View();
        }

    }
}
