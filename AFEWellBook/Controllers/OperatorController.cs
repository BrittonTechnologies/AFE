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
       //     GetCategories();
           

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



        public JsonResult GetPendingServiceRequests()
        {
            List<ServiceRequest> serviceRequests = new List<ServiceRequest>();

            using (var db = new AFEWellBookDB())
            {
               var sreq =
                    from sr in db.ServiceRequests
                    join q in db.Quotes on sr.ServiceRequestID equals q.ServiceRequestID
                    where q.StatusID == 2 //&& sr.OperatorID == THIS OPERATOR
                    select sr;
                    
               foreach(var s in sreq)
               {
                    serviceRequests.Add(s);

               }
                


            }


            return Json(serviceRequests, JsonRequestBehavior.AllowGet);
        }


        public ActionResult AcceptQuote(int serviceRequestID, int quoteID)
        {

            using (var db = new AFEWellBookDB())
            {
                db.ServiceRequests.Where(s => s.ServiceRequestID == serviceRequestID).FirstOrDefault().AcceptedVendorID = db.Quotes.Where(q => q.QuoteID == quoteID).FirstOrDefault().VendorID;


                db.ServiceRequests.Where(s => s.ServiceRequestID == serviceRequestID).FirstOrDefault().StatusID = 3;

                db.Quotes.Where(q => q.QuoteID == quoteID).FirstOrDefault().StatusID = 4;




                db.Update(db.ServiceRequests);

            }


            return View();

        }



        public JsonResult GetCategories()
        {
            Dictionary<int, string> categories = new Dictionary<int, string>();

            using (var db = new AFEWellBookDB())
            {
                

                foreach( var x in db.Categories )
                {
                    categories.Add(x.CategoryID, x.NameX);
                }

                
            }


            return Json(categories, JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetSubCategories(int categoryID)
        {
            using (var db = new AFEWellBookDB())
            {
                var subCategories = 9;
                //get em where categoryID = categoryID

                return Json(subCategories, JsonRequestBehavior.AllowGet);
            }

        }





        public ActionResult OpDashboard_Vendors()
        {


            return View();
        }


    }
}