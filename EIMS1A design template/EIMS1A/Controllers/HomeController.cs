using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EIMS1A.Models;
using EIMS1A.Controllers;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using EIMS1A.Admindb;




namespace EIMS1A.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        Dbservice admindb = new Dbservice();

             [HttpGet]  
        public ActionResult Index()
        {
            return View();
        }


     
        [HttpPost]
        public ActionResult Index(Login t1)
        {
            if (ModelState.IsValid)
            {

                if (t1.CHECKUSER(t1.username, t1.password))
                {
                    return RedirectToAction("view", "Home");
                    //return View("EmpInfo", t1);
                }
                else
                {
                    ViewBag.Message = "INVALID USERNAME AND PASSWORD";
                    return View("Index");
                }

            }
            return View(t1);
           
        }
        [HttpGet]
        public ActionResult view()
        {
            return View();
        }

        [HttpGet]
        public ActionResult EmpInfo()
        {
            return View();
        }
       [HttpPost]
        public ActionResult Empinfo_post()
        {
            EmpInfo empinfo = new EmpInfo();
          //  empinfo.emp_id = admindb.GetEmployeeInfoByEmpid(empinfo.emp_id);
            admindb.GetEmployeeInfoByEmpid(empinfo);
            return View(empinfo);
       }
       [HttpGet]
       public ActionResult EmpEdit(int BId)
       {

           EmpInfo b = new EmpInfo();
           b.emp_id = BId;
           // b.sear
           admindb.GetEmployeeInfoByEmpid(b);
           string all = null;
           if (b.emp_id != 0)
           {
               all = b.emp_name + "," + b.emp_name + "," + b.pay_commission + "," + b.date_of_next_increment + "," + b.designation + "," + b.dept_name + "," + b.category + "," + b.date_of_birth + "," + b.date_of_joining + "," + b.date_of_next_increment + "," + b.division + "," + b.pay_commission + "," + b.status_to_date + "," + b.personal_pay_allowance;
           }
           return Json(all, JsonRequestBehavior.AllowGet);

       }

    }
}
