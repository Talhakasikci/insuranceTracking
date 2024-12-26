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
    public class insurance_policiesController : Controller
    {
        private Model1 db = new Model1();

        // GET: insurance_policies
        public ActionResult Index()
        {
            var insurance_policies = db.insurance_policies.Include(i => i.customers).Include(i => i.insurance_companies).Include(i => i.vehicles);
            return View(insurance_policies.ToList());
        }

        // GET: insurance_policies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            insurance_policies insurance_policies = db.insurance_policies.Find(id);
            if (insurance_policies == null)
            {
                return HttpNotFound();
            }
            return View(insurance_policies);
        }

        // GET: insurance_policies/Create
        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(db.customers, "CustomerID", "FirstName");
            ViewBag.InsuranceCompanyID = new SelectList(db.insurance_companies, "CompanyID", "CompanyName");
            ViewBag.VehicleID = new SelectList(db.vehicles, "VehicleID", "Brand");
            return View();
        }

        // POST: insurance_policies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PolicyID,PolicyNumber,StartDate,EndDate,CoverageType,VehicleID,CustomerID,InsuranceCompanyID")] insurance_policies insurance_policies)
        {
            if (ModelState.IsValid)
            {
                db.insurance_policies.Add(insurance_policies);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerID = new SelectList(db.customers, "CustomerID", "FirstName", insurance_policies.CustomerID);
            ViewBag.InsuranceCompanyID = new SelectList(db.insurance_companies, "CompanyID", "CompanyName", insurance_policies.InsuranceCompanyID);
            ViewBag.VehicleID = new SelectList(db.vehicles, "VehicleID", "Brand", insurance_policies.VehicleID);
            return View(insurance_policies);
        }

        // GET: insurance_policies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            insurance_policies insurance_policies = db.insurance_policies.Find(id);
            if (insurance_policies == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = new SelectList(db.customers, "CustomerID", "FirstName", insurance_policies.CustomerID);
            ViewBag.InsuranceCompanyID = new SelectList(db.insurance_companies, "CompanyID", "CompanyName", insurance_policies.InsuranceCompanyID);
            ViewBag.VehicleID = new SelectList(db.vehicles, "VehicleID", "Brand", insurance_policies.VehicleID);
            return View(insurance_policies);
        }

        // POST: insurance_policies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PolicyID,PolicyNumber,StartDate,EndDate,CoverageType,VehicleID,CustomerID,InsuranceCompanyID")] insurance_policies insurance_policies)
        {
            if (ModelState.IsValid)
            {
                db.Entry(insurance_policies).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerID = new SelectList(db.customers, "CustomerID", "FirstName", insurance_policies.CustomerID);
            ViewBag.InsuranceCompanyID = new SelectList(db.insurance_companies, "CompanyID", "CompanyName", insurance_policies.InsuranceCompanyID);
            ViewBag.VehicleID = new SelectList(db.vehicles, "VehicleID", "Brand", insurance_policies.VehicleID);
            return View(insurance_policies);
        }

        // GET: insurance_policies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            insurance_policies insurance_policies = db.insurance_policies.Find(id);
            if (insurance_policies == null)
            {
                return HttpNotFound();
            }
            return View(insurance_policies);
        }

        // POST: insurance_policies/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            insurance_policies insurance_policies = db.insurance_policies.Find(id);
            db.insurance_policies.Remove(insurance_policies);
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
