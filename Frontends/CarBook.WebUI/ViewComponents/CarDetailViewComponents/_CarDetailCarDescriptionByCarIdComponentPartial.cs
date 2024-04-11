using CarBook.Dto.CarDescriptionDtos;
using CarBook.WebUI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.CarDetailViewComponents
{
	public class _CarDetailCarDescriptionByCarIdComponentPartial : ViewComponent
	{
		private readonly HttpClientServiceViewComponent _httpClientViewComponent;

		public _CarDetailCarDescriptionByCarIdComponentPartial(HttpClientServiceViewComponent httpClientViewComponent)
		{
			_httpClientViewComponent = httpClientViewComponent;
		}

		public async Task<IViewComponentResult> InvokeAsync(int id)
		{
			ViewBag.CarId = id;
			return await _httpClientViewComponent.InvokeAsync<ResultCarDescriptionByCarIdDto>($"CarDescriptions/{id}");
		}
	}
}
