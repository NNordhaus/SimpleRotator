using SimpleRotator.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleRotator.Controllers
{
    public class PreviewController : Controller
    {
        public ActionResult Index()
        {
            return View(Factory.GetRepo().Zones);
        }
    }
}
