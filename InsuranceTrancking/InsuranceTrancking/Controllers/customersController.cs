using InsuranceTrancking.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace InsuranceTrancking.Controllers
{
    public class customersController : Controller
    {
        private Model1 db = new Model1();

        // GET: customers
        public ActionResult Index()
        {
            return View(db.customers.ToList());
        }

        // GET: customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            customers customers = db.customers.Find(id);
            if (customers == null)
            {
                return HttpNotFound();
            }
            return View(customers);
        }

        // GET: customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]

        public ActionResult Create([Bind(Include = "CustomerID,FirstName,LastName,PhoneNumber,Email,Address,IsAdmin")] customers customers)
        {
            if (ModelState.IsValid)
            {
                db.customers.Add(customers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customers);
        }
        //public ActionResult CreateWithVehicle()
        //{
        //    return RedirectToAction("Index");
        //}
        [HttpPost]
        public ActionResult CreateWithVehicle(customers customer, vehicles vehicles, insurance_policies insurance_Policies)
        {
            if (ModelState.IsValid)
            {
                // Step 1: Add the customer to the database. CustomerID will be auto-generated.
                db.customers.Add(customer);
                db.SaveChanges();  // This will insert the customer and generate a CustomerID

                // Step 2: Ensure vehicles are assigned to this customer
                //foreach (var vehicle in vehicles)
                //{
                //    vehicle.CustomerID = customer.CustomerID;  // Link vehicle to the newly created customer
                //    db.vehicles.Add(vehicle);
                //}
                vehicles.CustomerID = customer.CustomerID;
                db.vehicles.Add(vehicles);
                db.SaveChanges();

                insurance_Policies.CustomerID = customer.CustomerID;
                insurance_Policies.VehicleID = vehicles.VehicleID;
                db.insurance_policies.Add(insurance_Policies);
                db.SaveChanges();


                // Step 3: Save the vehicles
              //  db.SaveChanges();

                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Please fill in all required fields.");


            return View(customer);  // If model is invalid, return the view
        }



        // GET: customers/Edit/5

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            customers customers = db.customers.Find(id);
            if (customers == null)
            {
                return HttpNotFound();
            }
            return View(customers);
        }

        // POST: customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]

        public ActionResult Edit([Bind(Include = "CustomerID,FirstName,LastName,PhoneNumber,Email,Address,IsAdmin")] customers customers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customers);
        }

        // GET: customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            customers customers = db.customers.Find(id);
            if (customers == null)
            {
                return HttpNotFound();
            }
            return View(customers);
        }

        // POST: customers/Delete/5
        [HttpPost, ActionName("Delete")]
        // [ValidateAntiForgeryToken]

        // [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    // Find the customer
                    customers customer = db.customers.Find(id);
                    if (customer == null)
                    {
                        return HttpNotFound();
                    }

                    // Delete related accident reports
                    var vehicles = db.vehicles.Where(v => v.CustomerID == id).ToList();
                    foreach (var vehicle in vehicles)
                    {
                        var accidentReports = db.accident_reports.Where(ar => ar.VehicleID == vehicle.VehicleID).ToList();
                        db.accident_reports.RemoveRange(accidentReports);
                    }

                    // Delete related payments for policies
                    var policies = db.insurance_policies.Where(p => p.CustomerID == id).ToList();
                    foreach (var policy in policies)
                    {
                        var payments = db.payments.Where(pay => pay.PolicyID == policy.PolicyID).ToList();
                        db.payments.RemoveRange(payments);
                    }

                    // Delete related insurance policies
                    db.insurance_policies.RemoveRange(policies);

                    // Delete related vehicles
                    db.vehicles.RemoveRange(vehicles);

                    // Delete related driving license
                    var license = db.driving_license.FirstOrDefault(dl => dl.CustomerID == id);
                    if (license != null)
                    {
                        db.driving_license.Remove(license);
                    }

                    // Delete the customer
                    db.customers.Remove(customer);

                    // Save changes and commit transaction
                    db.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    // Rollback transaction if an error occurs
                    transaction.Rollback();
                    throw;
                }
            }

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
