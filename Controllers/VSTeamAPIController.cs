using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TutorialVSTSAPI1.Controllers
{
    public class VSTeamAPIController : Controller
    {
        // GET: BasicAuth
        [HttpGet]
        public ActionResult BasicAuth()
        {
            return View();
        }
    }
}