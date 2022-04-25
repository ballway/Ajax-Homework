using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using prjMSIT133Web_Core_.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace prjMSIT133Web_Core_.Controllers
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

        public IActionResult FirstAjax()
        {
            return View();
        }

        public IActionResult AAA()
        {
            return View();
        }

        public IActionResult HW_GetTable()
        {
            return View();
        }

        public IActionResult HW_Login()
        {
            return View();
        }
        public IActionResult AjaxPost()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AjaxPost(User user)
        {
            ViewBag.name = user.name;
            return View();
        }

        public IActionResult AjaxFormData()
        {
            return View();
        }

        public IActionResult Address()
        {
            return View();
        }

        public IActionResult Address_completed()
        {
            return View();
        }
        public IActionResult Address_promise()
        {
            return View();
        }
        public IActionResult AjaxFormData_Fetch()
        {
            return View();
        }
        
        public IActionResult Promise()
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
