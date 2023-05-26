using CRM.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using CRM.Data;
using CRM.Data.Interfaces;

namespace CRM.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IDiary diaryDataApi = new DiaryApiStore();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //var a =  await diaryDataApi.AllNotes();
            return View();
        }

        public IActionResult Service()
        {
            return View();
        }

        public IActionResult Project()
        {
            return View();
        }

        public IActionResult Blog()
        {
            return View();
        }

        public IActionResult Contact()
        {
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