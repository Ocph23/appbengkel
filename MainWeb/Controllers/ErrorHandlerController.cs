using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MainWeb.Controllers
{
    public class ErrorHandlerController : Controller
    {
        // GET: ErrorHandler
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult ErrorInfo()
        {
            return View();
        }



        public ActionResult NotFound()
        {
            return View();
        }

        // GET: ErrorHandler/Details/5

    }
}
