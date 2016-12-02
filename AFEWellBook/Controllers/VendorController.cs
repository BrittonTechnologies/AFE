using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LinqToDB;
using DataModel;
using AFEWellBook.Models;

namespace AFEWellBook.Controllers
{
    public class VendorController : Controller
    {
        // GET: Vendor
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetServiceRequests(int vendorID)
        {
            List<ServiceRequest> serviceRequests = new List<ServiceRequest>();

            using (var db = new AFEWellBookDB())
            {
                var v = db.Vendors;

                var x = db.ServiceRequests.Where(s => s.VendorIDList.Contains(vendorID));

                foreach(var serveReq in x)
                {
                    serviceRequests.Add(serveReq);

                }

                
            }

            return Json(serviceRequests, JsonRequestBehavior.AllowGet);
        }

        public ActionResult PlaceQuote(int serviceRequestID, string quoteAmt)
        {
            Quote x = new Quote();


            using (var db = new AFEWellBookDB())
            {
                x.QuoteAmount = Convert.ToDouble(quoteAmt);
                x.ServiceRequestID = serviceRequestID;
                x.StatusID = 2;
                x.DateSubmitted = DateTime.Now;

                //TODO: WRITE TO DOCUMENT TABLE
                //x.DocumentID

                //x.VendorID =   THIS VENDOR

                db.Insert(x, "ServiceRequest", "AFEWellBook");

            }






            return View();
        }









    }
}