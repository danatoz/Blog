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
            var viewModel = new Post();
            try
            {
                if (id != null)
                {
                    using (var db = new ApplicationContext())
                    {
                        viewModel = db.Posts.FindAsync(id).Result;

                        return View(viewModel);
                    }

                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Error: ", ex);
            }
            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Post model)
        {
            try
            {
                using (var db = new ApplicationContext())
                {
                    model.PublicateDate = DateTime.Now;
                    
                    if (model.Id != 0)
                    {
                        db.Posts.Update(model);
                    }
                    else
                    {
                        db.Posts.Add(model);
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Error: ", ex);
            }

            return RedirectToAction("Posts", "Home", new { Area = "Admin" });
        }

        [HttpGet]
        public async Task<IActionResult> Posts()
        {
            try
            {
                using (var db = new ApplicationContext())
                {
                    var viewModel = db.Posts.Where(p => p.Id > 0).ToList();

                    return View(viewModel);
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
