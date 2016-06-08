using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Data.Odbc;
using Npgsql;
using System.Data;
using LinqToDB;
using DataModel;

namespace AFEWellBook.Controllers
{
    public class LoginController : Controller
    {


        
        // GET: Login
        public ActionResult Index(string loginType)
        {

            ViewBag.loginType = loginType;

            return View();
        }

        public ActionResult Validate(string Username, string Password)
        {
            using (var db = new AFEWellBookDB())
            {
                if (db.Users.Any(p => p.UserName == Username && p.UserPassword == Password))
                {

                    var x = 9;

                }

            }


                 

           

            return View();
        }



    }
}