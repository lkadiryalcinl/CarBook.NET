using CarBook.WebUI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.RentACarFilterComponents
{
    public class _RentACarFilterComponentPartial : ViewComponent
    {
        private readonly HttpClientServiceViewComponent _httpClientServiceViewComponent;

        public _RentACarFilterComponentPartial(HttpClientServiceViewComponent httpClientServiceViewComponent)
        {
            _httpClientServiceViewComponent = httpClientServiceViewComponent;
        }

        public IViewComponentResult Invoke(string v)
        {
            return View();
        }
    }
}
