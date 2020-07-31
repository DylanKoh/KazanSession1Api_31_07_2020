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
    public class DepartmentsController : Controller
    {
        private Session1Entities db = new Session1Entities();

        public DepartmentsController()
        {
            db.Configuration.LazyLoadingEnabled = false;
        }

        // POST: Departments
        [HttpPost]
        public ActionResult Index()
        {
            return Json(db.Departments.ToList());
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
