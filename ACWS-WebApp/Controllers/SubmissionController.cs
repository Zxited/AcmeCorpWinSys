using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ACWS_Data;
using ACWS_Services.ServiceInterfaces;

namespace ACWS_WebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubmissionController : ControllerBase
    {
        private readonly ILogger<SubmissionController> _logger;
        private readonly IParticipantService _participantService;

        public SubmissionController(
            ILogger<SubmissionController> logger,
            IParticipantService participantService
        )
        {
            _logger = logger;
            _participantService = participantService;
        }

        [HttpPost]
        public async Task<IActionResult> MakeSubmission()
        {
            return Ok();
        }
    }
}
