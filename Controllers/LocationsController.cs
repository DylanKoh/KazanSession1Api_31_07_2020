﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KazanSession1Api_31_07_2020;

namespace KazanSession1Api_31_07_2020.Controllers
{
    public class LocationsController : Controller
    {
        private Session1Entities db = new Session1Entities();

        public LocationsController()
        {
            db.Configuration.LazyLoadingEnabled = false;
        }

        // POST: Locations
        [HttpPost]
        public ActionResult Index()
        {
            return Json(db.Locations.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
