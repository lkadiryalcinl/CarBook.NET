﻿using CarBook.Dto.CarPricingDtos;
using CarBook.WebUI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Controllers
{
    public class CarController : Controller
    {
        private readonly HttpClientServiceAction _httpClientService;

        public CarController(HttpClientServiceAction httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.v1 ="Arabalar";
            ViewBag.v2 ="Arabalarımız";
            var values = await _httpClientService.InvokeAsync<List<ResultCarPricingWithCarDailyDto>>("CarPricings/GetCarPricingWithCarDaily");

            if(values.Count > 0)
            {
                return View(values);
            }

            return View();
        }
    }
}
