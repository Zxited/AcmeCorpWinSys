using System.Web;
using System.Net;
using System.Data.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
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

        public async Task<IActionResult> GetParticipant(CheckModel checkModel)
        {
            try
            {
                Participant participant = await _participantService.ParticipantAuthentication(checkModel.Email, checkModel.SerialNumber);
                if (!Request.Cookies.ContainsKey("ParticipantID"))
                {
                    Response.Cookies.Append("ParticipantID", participant.ParticipantID.ToString());
                    Response.Cookies.Append("FirstName", participant.FirstName.ToString());
                    Response.Cookies.Append("LastName", participant.LastName.ToString());
                    Response.Cookies.Append("Email", participant.Email.ToString());
                    Response.Cookies.Append("DateOfBirth", participant.DateOfBirth.ToString("yyyy-MM-dd"));
                }
                
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return View(nameof(Check));
            }

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
