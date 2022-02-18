using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Blog.Areas.Admin.Models;
using Blog.Common.Enum;
using Blog.DAL.DbModels;
using Microsoft.AspNetCore.Authorization;

namespace Blog.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public async Task<IActionResult> Index()
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
        [HttpGet]
        public async Task<IActionResult> Update(int? id)
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
        [HttpPost]
        public async Task<IActionResult> Update(Post model)
        {
            try
            {
                using (var context = new ApplicationContext())
                {

                    var viewMode = context.Posts.Add(model);
                    context.SaveChanges();
                }
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
