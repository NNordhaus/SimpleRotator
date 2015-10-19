using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

using SimpleRotator.Models;

namespace SimpleRotator.Controllers
{
    public class DevController : Controller
    {
        public ActionResult Index()
        {
            //var zones = new List<Zone>();
            //zones.Add(new Zone() { Name = "Leader"});
            //zones.Add(new Zone() { Name = "Tower" });
            //zones.Add(new Zone() { Name = "Box" });
            //zones.Add(new Zone() { Name = "Footer" });

            //var path = HttpContext.ApplicationInstance.Server.MapPath("~/App_Data/Zones.json");

            //System.IO.File.WriteAllText(path, JsonConvert.SerializeObject(zones));

            return Content("OK");
        }
    }
}