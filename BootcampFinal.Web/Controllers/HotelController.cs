using BootcampFinal.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BootcampFinal.Web.Controllers
{
    public class HotelController : Controller
    {
        private readonly ITourvisioApiService _tourvisioApiService;

        public HotelController(ITourvisioApiService tourvisioApiService)
        {
            _tourvisioApiService = tourvisioApiService;
        }

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Search()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Search")]
        public IActionResult Search(string query)
        {
            string token = _tourvisioApiService.GetAccessToken();
            var tempDataHotels = _tourvisioApiService.GetHotels(query, token);

            return View("Index", tempDataHotels);
        }
    }
}
