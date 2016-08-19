using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using LinqToDB;
using DataModel;
using AFEWellBook.Models;

namespace AFEWellBook.Controllers
{
    public class OperatorController : Controller
    {
        // GET: Operator
        public ActionResult Index()
        {
            // GetJobs();
            //get stuff to fill current job table


           //Load Categories
           //Load SubCategories

           

            return View();
        }
        
        
   


        public ActionResult SubmitServiceRequest(string DateDue, string VendorType, string Details)
        {

            ServiceRequest x = new ServiceRequest();

            List<int> y = new List<int>();

            y.Add(1);
            y.Add(2);


            using (var db = new AFEWellBookDB())
            {
                x.OperatorID = 1;
                x.DateDue = Convert.ToDateTime(DateDue);
                x.DatePosted = DateTime.Now;
                x.StatusID = (int)ServiceRequestModel.ServiceStatus.OPEN;
                x.VendorIDList = y;
                x.Details = Details;
              
                db.Insert(x, "ServiceRequest", "AFEWellBook");
           
            }
           
           
           
           
            return Json(x, JsonRequestBehavior.AllowGet);
        }


        public ActionResult OpDashboard_Vendors()
        {


            return View();
        }


    }
}