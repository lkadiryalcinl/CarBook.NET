﻿using CarBook.Dto.CommentDtos;
using CarBook.WebUI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CommentBook.WebUI.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminComment")]
    public class AdminCommentController : Controller
    {

        private readonly HttpClientServiceAction _httpClientServiceAction;

        public AdminCommentController(HttpClientServiceAction httpClientServiceAction)
        {
            _httpClientServiceAction = httpClientServiceAction;
        }

        [Route("Index/{id}")]
        public async Task<IActionResult> Index(int id)
        {
            ViewBag.v = id;
            var values = await _httpClientServiceAction.InvokeAsync<List<ResultCommentByBlogIdDto>>($"Comments/GetCommentListByBlogId/{id}");
            return View(values);
        }


        [Route("RemoveComment/{id}")]
        public async Task<IActionResult> RemoveComment(int id)
        {
            var isSucceded = await _httpClientServiceAction.RemoveAsync($"Comments/{id}");
            return isSucceded ? RedirectToAction("Index", "AdminComment", new { area = "Admin" }) : View();
        }

        [Route("GetCommentsByCommentId/{id}")]
        public async Task<IActionResult> GetCommentsByCommentId(int id)
        {
            var values = await _httpClientServiceAction.InvokeAsync<List<ResultCommentByBlogIdDto>>("Comments/GetAllCommentsWithAuthor");
            return View(values);
        }

    }
}
