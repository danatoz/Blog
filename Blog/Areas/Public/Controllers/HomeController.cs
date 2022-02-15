using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Blog.Areas.Admin.Models;

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
            try
            {

            }
            catch (Exception ex)
            {
                _logger.LogError("Error: ", ex);
            }
            return View();
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
        public async Task<IActionResult> Single()
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
