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
    public class DashboardController : Controller
    {
        private readonly ILogger<DashboardController> _logger;
        private readonly IPrizePoolService _prizePoolService;

        public DashboardController(
            ILogger<DashboardController> logger,
            IPrizePoolService prizePoolService)
        {
            _logger = logger;
            _prizePoolService = prizePoolService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _prizePoolService.GetAllPrizePoolWithParticipants());
        }
    }
}