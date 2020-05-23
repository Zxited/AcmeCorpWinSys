using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ACWS_WebApp.Models;
using ACWS_Data.Models;
using ACWS_Services.ServiceInterfaces;

namespace ACWS_WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IParticipantService _participantService;

        public HomeController(
            ILogger<HomeController> logger,
            IParticipantService participantService)
        {
            _logger = logger;
            _participantService = participantService;
        }

        public Participant GetParticipant(string serialNumber, string email)
        {
            return new Participant();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Check()
        {
            return View();
        }

        public IActionResult Redeem()
        {
            return View();
        }

        [Route("/login")]
        public IActionResult Login()
        {
            return Redirect("Identity/Account/Login");
        }

        public IActionResult Tos()
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
