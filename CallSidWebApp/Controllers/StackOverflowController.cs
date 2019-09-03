using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twilio;

namespace CallSidWebApp.Controllers
{
    public class StackOverflowController : Controller
    {
        // GET: StackOverflow
        public ActionResult Index(string callSid)
        {
            string id = callSid;
            return View();
        }
    }
}