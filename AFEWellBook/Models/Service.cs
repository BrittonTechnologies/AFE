using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataModel;


namespace AFEWellBook.Models
{



    public class ServiceRequestModel
    {
        public Category ServiceCategory { get; set; }
        public SubCategory ServiceSubCategory { get; set; }
        public string Comments { get; set; }
        public DateTime DueDate { get; set; }
        public List<string> VendorList;

        public enum ServiceStatus
        {
            OPEN = 1,
            BIDS_PENDING = 2,
            IN_PROGRESS = 3,
            COMPLETE = 4,
            CANCELLED = 5
        }




    }

}