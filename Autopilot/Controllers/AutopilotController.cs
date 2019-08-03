using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Autopilot.Models;
using Newtonsoft.Json.Linq;

namespace Autopilot.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutopilotController : ControllerBase
    {
        private readonly ILogger _logger;

        public AutopilotController(ILogger<AutopilotController> logger)
        {
            _logger = logger;
        }

        [HttpPost("hello_world")]
        public IActionResult Post()
        {
            /* EXAMPLE 1: String Result
            var data = @"{""actions"":[{""say"":""This is your new Task""}]}";*/

            /* EXAMPLE 2: Anonymous Types
            var data = new
            {
                actions = new[] 
                {
                    new { say = "This is Your New Task" }
                }
            };*/

            // EXAMPLE 3: Strongly Typed
            var data = new Models.Action(new Say("This is your new Task from JSON.Net"));

            var json = JObject.FromObject(data);

            return new JsonResult(json);
        }

    }
}
