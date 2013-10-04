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
            return View();
        }
        
        public ActionResult Tickets()
        {
            var tickets = db.Tickets.All().Select(TicketViewModel.FromTicket);

            return View(tickets);
        }

        public ActionResult ReadAllTickets([DataSourceRequest]DataSourceRequest request, string a)
        {
            var tickets = db.Tickets.All().Select(TicketViewModel.FromTicket);
            var result = tickets.ToDataSourceResult(request);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Details(int id)
        {
            var ticket = this.db.Tickets.GetById(id);
            var ticketDescription = HttpUtility.HtmlDecode(ticket.Description);
            var ticketView = new TicketViewModel
            {
                TicketId = ticket.TicketId,
                Title = ticket.Title,
                Description = ticketDescription,
                PostedOn = ticket.PostedOn,
                PostedBy = ticket.PostedBy.UserName
            };

            return View(ticketView);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                var currUser = db.Users.All().FirstOrDefault(u => u.UserName == User.Identity.Name);

                ticket.PostedOn = DateTime.Now;
                ticket.Status = StatusEnum.Open;
                ticket.PostedBy = currUser;
                ticket.Description = HttpUtility.HtmlDecode(ticket.Description);
                
                db.Tickets.Add(ticket);
                db.SaveChanges();
                return RedirectToAction("Tickets");
            }

            return View(ticket);
        }
    }
}