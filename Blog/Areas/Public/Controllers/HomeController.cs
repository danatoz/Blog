using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Blog.Areas.Admin.Models;
using Blog.Areas.Admin.ViewModel;
using Blog.DAL.DbModels;
using Microsoft.EntityFrameworkCore;

namespace Blog.Areas.Public.Controllers
{
    [Area("Public")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> GetPosts(int page = 1)
        {
            var viewModel = new IndexViewModel();
            try
            {
                var pageSize = 4;
                using (var db = new ApplicationContext())
                {
                    IQueryable<Post> source = db.Posts.Where(p => p.Publicated == true);
                    var count = await source.CountAsync();
                    var items = await source.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
                    var pageViewModel = new PageViewModel(count, page, pageSize);
                    viewModel = new IndexViewModel()
                    {
                        PageViewModel = pageViewModel,
                        Posts = items,
                    };
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Error: ", ex);
            }
            return Json(new { posts = viewModel.Posts, page = viewModel.PageViewModel });
        }

        [Route("Work")]
        public async Task<IActionResult> Work()
        {
            try
            {

            }
            catch (Exception ex)
            {
                _logger.LogError("Error: ", ex);
            }
            return View();
        }

        [Route("Single")]
        public async Task<IActionResult> Single(int? id)
        {
            if (id == null) return BadRequest();
            var viewModel = new Post();
            try
            {
                using (var db = new ApplicationContext())
                {
                    viewModel = db.Posts.Find(id.Value);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Error: ", ex);
            }
            return View(viewModel);
        }

        [Route("About")]
        public async Task<IActionResult> About()
        {
            try
            {

            }
            catch (Exception ex)
            {
                _logger.LogError("Error: ", ex);
            }
            return View();
        }

        [Route("Contact")]
        public async Task<IActionResult> Contact()
        {
            try
            {

            }
            catch (Exception ex)
            {
                _logger.LogError("Error: ", ex);
            }
            return View();
        }

        [Route("Privacy")]
        public IActionResult Privacy()
        {
            try
            {

            }
            catch (Exception ex)
            {
                _logger.LogError("Error: ", ex);
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
