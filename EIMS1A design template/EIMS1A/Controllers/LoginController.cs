using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using EIMS1A.Models;

namespace EIMS1A.Controllers
{
    public class LoginController : Controller
    {

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login t1)
        {
            if (ModelState.IsValid)
            {

                if (t1.CHECKUSER(t1.username, t1.password))
                {
                    return View("Index", t1);
                }
                else
                {
                    ViewBag.Message = "INVALID USERNAME AND PASSWORD";
                    return View("Login");
                }

            }

            return View(t1);
        }
        [HttpPost]
        public ActionResult Index(Login t1)
        {
            if (ModelState.IsValid)
            {

                if (t1.CHECKUSER(t1.username, t1.password))
                {
                    return View("Index", t1);
                }
                else
                {
                    ViewBag.Message = "INVALID USERNAME AND PASSWORD";
                   
                }
               
            }
            return View(t1);
        }
        
    }
}
   