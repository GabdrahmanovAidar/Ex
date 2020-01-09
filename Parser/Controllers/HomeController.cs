using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Parser.DataBase;
using Parser.Logic;
using Parser.Models;
using Parser.ViewModel;

namespace Parser.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDBContent _db;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, AppDBContent db)
        {
            _db = db;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(UrlVM urlvm)
        {
            var list = new List<string>();
            string url = urlvm.UrlBody.Url;
            int depth = urlvm.depth;
            var listLinks = GetLinks.GetAllLinks(url, depth, list);
            ViewBag.list = listLinks;
            return View();
        }

        public IActionResult Save(List<UrlBody> list)
        {
            foreach (var el in list)
            {
                _db.UrlBodies.Add(el);
            }
            _db.SaveChanges();
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
