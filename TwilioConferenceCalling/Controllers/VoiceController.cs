using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Twilio.TwiML;
using Twilio.TwiML.Voice;

namespace TwilioConferenceCalling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoiceController : ControllerBase
    {
        private readonly ILogger _logger;

        public VoiceController(ILogger<VoiceController> logger) => _logger = logger;

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            var voiceResponse = new VoiceResponse();
            var dial = new Dial();

            var conference = new Conference
            {
                Name = "room123",
                EndConferenceOnExit = true
            };


            var conferenceCallback = "https://corey.ngrok.io/api/voice/callback";
            conference.StatusCallback = new Uri(conferenceCallback);
            conference.StatusCallbackEvent = new List<Conference.EventEnum>
                {
                    Conference.EventEnum.Start,
                    Conference.EventEnum.End,
                    Conference.EventEnum.Join,
                    Conference.EventEnum.Leave
                };

            dial.Append(conference);
            voiceResponse.Append(dial);

            return new ContentResult { Content = voiceResponse.ToString(), ContentType = "application/xml", StatusCode = 200 };
        }

        [HttpPost("callback")]
        public IActionResult HandleCallback()
        {
            _logger.LogInformation("The callback was hit");
            return NoContent();
        }   
    }
}