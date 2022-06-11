using BootcampFinal.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BootcampFinal.Application.Interfaces;

namespace BootcampFinal.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITourvisioApiService _tourvisioApiService;

        public HomeController(ILogger<HomeController> logger, ITourvisioApiService tourvisioApiService)
        {
            _logger = logger;
            _tourvisioApiService = tourvisioApiService;
        }

        public IActionResult Index()
        {

            string token = _tourvisioApiService.GetAccessToken();
            ViewBag.Message = token;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
