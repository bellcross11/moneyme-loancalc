using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoanCalculator.Application.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoanCalculator(string link)
        {
            ViewBag.link = link;

            return View();
        }

        public ActionResult Quote(string link)
        {
            ViewBag.link = link;

            return View();
        }

        public ActionResult Success()
        {
            return View();
        }
    }
}