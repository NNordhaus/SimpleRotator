﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleRotator.Controllers
{
    public class AdController : Controller
    {
        public ActionResult GetAd(string zone)
        {
            return Content("you requested zone '" + zone + "'");
        }
    }
}