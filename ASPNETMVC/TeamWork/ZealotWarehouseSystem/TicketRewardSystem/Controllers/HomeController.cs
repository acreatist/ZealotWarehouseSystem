using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicketRewardSystem.Models;
using TicketRewardSystem.Repository;

namespace TicketRewardSystem.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var db = new UowData();

            var tickets = db.Tickets.All();

            return View(tickets);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}