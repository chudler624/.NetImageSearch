using ImageSearch.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ImageSearch.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult Privacy()
        {
            
            return View();
        }

        public IActionResult ImageResults(string searchTerm)
        {
            var imageSearchApi= new ImageSearchApi();
            var images = imageSearchApi.GetImage(searchTerm);

            return View(images);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}