using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InsuranceTrancking.Models;

namespace InsuranceTrancking.Controllers
{
    public class accident_reportsController : Controller
    {
        private Model1 db = new Model1();

        // GET: accident_reports
        public ActionResult Index()
        {
            var accident_reports = db.accident_reports.Include(a => a.insurance_policies).Include(a => a.repair_shops).Include(a => a.vehicles);
            return View(accident_reports.ToList());
        }

        // GET: accident_reports/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            accident_reports accident_reports = db.accident_reports.Find(id);
            if (accident_reports == null)
            {
                return HttpNotFound();
            }
            return View(accident_reports);
        }

        // GET: accident_reports/Create
        public ActionResult Create()
        {
            ViewBag.PolicyID = new SelectList(db.insurance_policies, "PolicyID", "PolicyNumber");
            ViewBag.RepairShopID = new SelectList(db.repair_shops, "ShopID", "ShopName");
            ViewBag.VehicleID = new SelectList(db.vehicles, "VehicleID", "Brand");
            return View();
        }

        // POST: accident_reports/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReportID,Location,VehicleID,PolicyID,RepairShopID")] accident_reports accident_reports)
        {
            if (ModelState.IsValid)
            {
                db.accident_reports.Add(accident_reports);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PolicyID = new SelectList(db.insurance_policies, "PolicyID", "PolicyNumber", accident_reports.PolicyID);
            ViewBag.RepairShopID = new SelectList(db.repair_shops, "ShopID", "ShopName", accident_reports.RepairShopID);
            ViewBag.VehicleID = new SelectList(db.vehicles, "VehicleID", "Brand", accident_reports.VehicleID);
            return View(accident_reports);
        }

        // GET: accident_reports/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            accident_reports accident_reports = db.accident_reports.Find(id);
            if (accident_reports == null)
            {
                return HttpNotFound();
            }
            ViewBag.PolicyID = new SelectList(db.insurance_policies, "PolicyID", "PolicyNumber", accident_reports.PolicyID);
            ViewBag.RepairShopID = new SelectList(db.repair_shops, "ShopID", "ShopName", accident_reports.RepairShopID);
            ViewBag.VehicleID = new SelectList(db.vehicles, "VehicleID", "Brand", accident_reports.VehicleID);
            return View(accident_reports);
        }

        // POST: accident_reports/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReportID,Location,VehicleID,PolicyID,RepairShopID")] accident_reports accident_reports)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accident_reports).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PolicyID = new SelectList(db.insurance_policies, "PolicyID", "PolicyNumber", accident_reports.PolicyID);
            ViewBag.RepairShopID = new SelectList(db.repair_shops, "ShopID", "ShopName", accident_reports.RepairShopID);
            ViewBag.VehicleID = new SelectList(db.vehicles, "VehicleID", "Brand", accident_reports.VehicleID);
            return View(accident_reports);
        }

        // GET: accident_reports/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            accident_reports accident_reports = db.accident_reports.Find(id);
            if (accident_reports == null)
            {
                return HttpNotFound();
            }
            return View(accident_reports);
        }

        // POST: accident_reports/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            accident_reports accident_reports = db.accident_reports.Find(id);
            db.accident_reports.Remove(accident_reports);
            db.SaveChanges();
            return RedirectToAction("Index");
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
