using CarBook.Dto.ReviewDtos;
using CarBook.WebUI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.CarDetailViewComponents
{
    public class _CarDetailCommentsByCarIdComponentPartial : ViewComponent
	{
		private readonly HttpClientServiceViewComponent _httpClientViewComponent;

		public _CarDetailCommentsByCarIdComponentPartial(HttpClientServiceViewComponent httpClientViewComponent)
		{
			_httpClientViewComponent = httpClientViewComponent;
		}

		public async Task<IViewComponentResult> InvokeAsync(int id)
		{
			ViewBag.carid = id;
			return await _httpClientViewComponent.InvokeAsync<List<ResultReviewByCarIdDto>>($"Reviews?id={id}");
		}
	}
}
