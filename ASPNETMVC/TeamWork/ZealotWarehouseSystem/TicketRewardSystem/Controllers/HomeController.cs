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
        private UowData db;

        public HomeController()
        {
            this.db = db = new UowData();
        }

        public ActionResult Index()
        {
            this.db = new UowData();

            var tickets = db.Tickets.All().Select(TicketViewModel.FromTicket);

            return View(tickets);
        }

        [HttpPost]
        public ActionResult ReadTickets([DataSourceRequest]DataSourceRequest request)
        {
            var tickets = db.Tickets.All().Select(TicketViewModel.FromTicket);
            var result = tickets.ToDataSourceResult(request);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Details(int id)
        {
            var ticket = this.db.Tickets.GetById(id);
            var ticketView = new TicketViewModel
            {
                TicketId = ticket.TicketId,
                Title = ticket.Title,
                Description = ticket.Description,
                PostedOn = ticket.PostedOn,
                PostedBy = ticket.PostedBy.UserName
            };

            return View(ticketView);
        }
    }
}