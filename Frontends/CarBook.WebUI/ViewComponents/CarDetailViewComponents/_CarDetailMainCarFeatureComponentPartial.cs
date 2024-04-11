using CarBook.Dto.CarDtos;
using CarBook.WebUI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.CarDetailViewComponents
{
	public class _CarDetailMainCarFeatureComponentPartial : ViewComponent
	{
		private readonly HttpClientServiceViewComponent _httpClientViewComponent;

		public _CarDetailMainCarFeatureComponentPartial(HttpClientServiceViewComponent httpClientViewComponent)
		{
			_httpClientViewComponent = httpClientViewComponent;
		}

		public async Task<IViewComponentResult> InvokeAsync(int id)
		{
			ViewBag.CarId = id;
			return await _httpClientViewComponent.InvokeAsync<ResultCarWithBrandsDto>($"Cars/{id}");
		}
	}
}
