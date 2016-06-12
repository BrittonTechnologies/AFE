using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        
        
    }
}