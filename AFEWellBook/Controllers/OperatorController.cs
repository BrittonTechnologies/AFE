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


           
           

            return View();
        }
        
        
        public ActionResult GetJobs()
		{
     		List<JobModel> jobList = new List<JobModel>();

           



            /*return (from r in results 
			 select new jobList  {
			     
			     go to DB and fill the job model

			 }).ToList()
			  	*/


            return Json(jobList, JsonRequestBehavior.AllowGet);
        }


        public ActionResult WriteJob(string DateDue, string VendorType, string Details)
        {

            Job x = new Job();

           
            

            using (var db = new AFEWellBookDB())
            {
                x.JobStatusID = 1;
                x.OperatorID = 1;
                x.DateDue = Convert.ToDateTime(DateDue);
                x.DatePosted = DateTime.Now;
                x.VendorTypeID = db.VendorTypes.Where(p => p.NameX == VendorType).Select(v => v.VendorTypeID).FirstOrDefault();
                x.Details = Details;
              
                db.Insert(x, "Job", "AFEWellBook");

            }


        

            return Json(x, JsonRequestBehavior.AllowGet);
        }


        public ActionResult OpDashboard_Vendors()
        {


            return View();
        }


    }
}