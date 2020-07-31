using System;
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
    public class AssetsController : Controller
    {
        private Session1Entities db = new Session1Entities();

        public AssetsController()
        {
            db.Configuration.LazyLoadingEnabled = false;
        }

        // POST: Assets
        [HttpPost]
        public ActionResult Index()
        {
            var assets = db.Assets;
            return Json(assets.ToList());
        }

        // GET: Assets/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asset asset = db.Assets.Find(id);
            if (asset == null)
            {
                return HttpNotFound();
            }
            return View(asset);
        }

        // POST: Assets/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "ID,AssetSN,AssetName,DepartmentLocationID,EmployeeID,AssetGroupID,Description,WarrantyDate")] Asset asset)
        {
            if (ModelState.IsValid)
            {
                db.Assets.Add(asset);
                db.SaveChanges();
                return Json("Asset created successfully!");
            }

            return Json("Asset creation was unsuccessful! Please check your entries again!");
        }

        // POST: Assets/GetCustomViews
        [HttpPost]
        public ActionResult GetCustomViews()
        {
            var getCustomView = (from x in db.Assets
                                 join y in db.DepartmentLocations on x.DepartmentLocationID equals y.ID
                                 join z in db.Departments on y.DepartmentID equals z.ID
                                 join a in db.AssetGroups on x.AssetGroupID equals a.ID
                                 select new
                                 {
                                     AssetID = x.ID,
                                     AssetSN = x.AssetSN,
                                     AssetName = x.AssetName,
                                     AssetGroup = a.Name,
                                     Warranty = x.WarrantyDate,
                                     Department = z.Name
                                 });
            return Json(getCustomView.ToList());
        }


        // POST: Assets/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "ID,AssetSN,AssetName,DepartmentLocationID,EmployeeID,AssetGroupID,Description,WarrantyDate")] Asset asset)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asset).State = EntityState.Modified;
                db.SaveChanges();
                return Json("Asset edited successfully!");
            }
            return Json("Asset modification was unsuccessful!");
        }


        // POST: Assets/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {
            Asset asset = db.Assets.Find(id);
            db.Assets.Remove(asset);
            db.SaveChanges();
            return Json("Asset deleted successfully!");
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
