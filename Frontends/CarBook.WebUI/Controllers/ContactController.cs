using CarBook.Dto.ContactDtos;
using CarBook.WebUI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly HttpClientServiceAction _httpClientService;

        public ContactController(HttpClientServiceAction httpClientService)
        {
            _httpClientService = httpClientService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateContactDto createContactDto)
        {
            createContactDto.SendDate = DateTime.Now;
            var isSucceded = await _httpClientService.CreateAsync<CreateContactDto>("Contacts",createContactDto);
            return isSucceded ? RedirectToAction("Index","Default") : View();
        }
    }
}
