using CarBook.Dto.CarFeatureDto;
using CarBook.Dto.FeatureDtos;
using CarBook.WebUI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminCarFeatureDetail")]
    [Authorize(Roles = "ADMIN")]
    public class AdminCarFeatureDetailController : Controller
    {
        private readonly HttpClientServiceAction _httpClientServiceAction;
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminCarFeatureDetailController(HttpClientServiceAction httpClientServiceAction, 
            IHttpClientFactory httpClientFactory)
        {
            _httpClientServiceAction = httpClientServiceAction;
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        [Route("Index/{id}")]
        public async Task<IActionResult> Index(int id)
        {
            var values = await _httpClientServiceAction.InvokeAsync<List<ResultAdminCarFeatureByCarIdDto>>($"CarFeatures/{id}");
            return View(values);
        }

        [HttpPost]
        [Route("Index/{id}")]
        public async Task<IActionResult> Index(List<ResultAdminCarFeatureByCarIdDto> resultCarFeatureByCarIdDto)
        {

            foreach (var item in resultCarFeatureByCarIdDto)
            {
                if (item.Available)
                    await _httpClientServiceAction.InvokeAsync<List<ResultAdminCarFeatureByCarIdDto>>($"CarFeatures/CarFeatureChangeAvailableToTrue/{item.ID}");
                else
                   await _httpClientServiceAction.InvokeAsync<List<ResultAdminCarFeatureByCarIdDto>>($"CarFeatures/CarFeatureChangeAvailableToFalse/{item.ID}");
            }
            return RedirectToAction("Index", "AdminCar");
        }

        [Route("CreateFeatureByCarId")]
        [HttpGet]
        public async Task<IActionResult> CreateFeatureByCarId()
        {
            var values = await _httpClientServiceAction.InvokeAsync<List<ResultFeatureDto>>("Features");
            return View(values);
        }
    }
}
