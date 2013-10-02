using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicketRewardSystem.Models;
using TicketRewardSystem.Repository;
using TicketRewardSystem.ViewModels;

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

        public JsonResult TicketsRead([DataSourceRequest]DataSourceRequest request)
        {
            var db = new UowData();

            var tickets = db.Tickets.All();

            DataSourceResult result = tickets.ToDataSourceResult(request, ticket => new TicketViewModel
            {
                TicketId = ticket.TicketId,
                Title = ticket.Title,
                Description = ticket.Description,
                PostedOn = ticket.PostedOn,
                PostedBy = ticket.PostedBy.UserName
            });

            var jsonified = Json(result, JsonRequestBehavior.AllowGet);

            return jsonified;
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