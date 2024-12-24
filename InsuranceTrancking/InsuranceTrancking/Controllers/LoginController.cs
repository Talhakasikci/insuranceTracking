using InsuranceTrancking.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace InsuranceTrancking.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        private Model1 db = new Model1();
      public ActionResult Loginpage()
        {
           
            
            return View();
        }

        [HttpPost]
        public ActionResult Loginpage(string Email, string Password)
        {
            var admin = db.adminPanels.SingleOrDefault(u => u.mail== Email && u.adminpassword == Password);
           
            if (admin == null)
            {
              
                ModelState.AddModelError("", "Geçersiz kullanıcı adı veya şifre.");
                TempData["AlertMessage"] = "there is no customer with this email and password";
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");


                
                //TempData["AlertMessage"] = "you are not admin";
                return View();
            }


            
        }
    }
}
