using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ACWS_Data;
using ACWS_Data.Models;
using ACWS_Services.ServiceInterfaces;

namespace ACWS_WebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubmissionController : ControllerBase
    {
        private readonly ILogger<SubmissionController> _logger;
        private readonly IParticipantService _participantService;
        private readonly IPrizePoolService _prizePoolService;
        private readonly ISerialNumberService _serialNumberService;

        public SubmissionController(
            ILogger<SubmissionController> logger,
            IParticipantService participantService,
            IPrizePoolService prizePoolService,
            ISerialNumberService serialNumberService
        )
        {
            _logger = logger;
            _participantService = participantService;
            _prizePoolService = prizePoolService;
            _serialNumberService = serialNumberService;
        }

        public IActionResult Index()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> MakeSubmission([Bind("SerialKey,FirstName,LastName,Email,DateOfBirth,ToSPP")]SubmissionModel submission)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (await _serialNumberService.SerialNumberUnused(submission.SerialKey))
                    {
                        Participant participant = await _participantService.CreateParticipant(submission.FirstName, submission.LastName, submission.Email, submission.DateOfBirth, submission.ToSPP);
                        SerialNumber serialNumber = await _serialNumberService.SubmitSerialNumber(submission.SerialKey, participant.ParticipantID);
                        return Ok();
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return NotFound();
        }

        [HttpPost("getentries")]
        public async Task<IActionResult> GetEntries([Bind("PrizePoolID,ParticipantID")]EntriesRequestModel entriesRequest)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int.TryParse(entriesRequest.PrizePoolID, out int PrID);
                    int.TryParse(entriesRequest.ParticipantID, out int PaID);

                    PrizePool prizePool = await _prizePoolService.GetPrizePoolByID(PrID);
                    Participant participant = await _participantService.GetParticipantByID(PaID);

                    return Ok(await _prizePoolService.GetParticipantEntriesInPool(prizePool.PrizePoolID, participant.ParticipantID));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return NotFound();
        }

        [HttpPost("useentry")]
        public async Task<IActionResult> UseEntry([Bind("PrizePoolID,ParticipantID")]EntriesRequestModel entriesRequest)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int.TryParse(entriesRequest.PrizePoolID, out int PrID);
                    int.TryParse(entriesRequest.ParticipantID, out int PaID);

                    PrizePool prizePool = await _prizePoolService.GetPrizePoolByID(PrID);
                    Participant participant = await _participantService.GetParticipantByID(PaID);

                    await _participantService.UseEntry(prizePool.PrizePoolID, participant.ParticipantID);

                    return Ok();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return NotFound();
        }

        [HttpPost("entriesleft")]
        public async Task<IActionResult> GetEntriesLeft([Bind("ParticipantID")]EntriesRequestModel entriesRequest)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int.TryParse(entriesRequest.ParticipantID, out int PaID);
                    Participant participant = await _participantService.GetParticipantByID(PaID);

                    return Ok(await _participantService.GetEntriesLeft(participant.ParticipantID));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return NotFound();
        }
    }
}
