using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using TicketRewardSystem.Areas.Administration.ViewModels;
using TicketRewardSystem.Repository;
using TicketRewardSystem.Models;

namespace TicketRewardSystem.Areas.Support.Controllers
{
    public class TicketSupportController : Controller
    {
        protected IUowData Data { set; get; }
        public TicketSupportController()
        {
            this.Data = new UowData();
        }

        //
        // GET: /Support/TicketSupport/
        public ActionResult Index()
        {
            return View();
        }

        //public JsonResult ReadMyTickets([DataSourceRequest]DataSourceRequest request)
        //{
        //    var tickets = this.Data.Tickets.All().Select(TicketAdminViewModel.FromTicket);

        //    DataSourceResult result = tickets.ToDataSourceResult(request);
        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}

        public ActionResult GetTicket([DataSourceRequest]DataSourceRequest request, int id)
        {
            
            var username = this.User.Identity.GetUserName();
            var userId = this.User.Identity.GetUserId();

            var currentSupportUser = this.Data.Users.All().FirstOrDefault(x => x.Id == userId);

            var ticket = Data.Tickets.All().FirstOrDefault(x => x.TicketId == id);
            ticket.AssignedTo = currentSupportUser;
            ticket.Status = StatusEnum.InProgress;
            Data.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult ReadAllTickets([DataSourceRequest]DataSourceRequest request, string a)
        {
            var tickets = Data.Tickets.All().Select(TicketAdminViewModel.FromTicket);
            var result = tickets.ToDataSourceResult(request);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult ReadAllTickets([DataSourceRequest]DataSourceRequest request)
        {
            var tickets = Data.Tickets.All().Select(TicketAdminViewModel.FromTicket);
            var result = tickets.ToDataSourceResult(request);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ResolveTicket(int id)
        {
            var ticket = this.Data.Tickets.GetById(id);
            var officer = ticket.AssignedTo;

            if (officer == null)
            {
                return Content("Unassigned tickets cannot be resolved.");
            }

            ticket.Status = StatusEnum.Resolved;
            ticket.ResolvedOn = DateTime.Now;
            this.Data.Tickets.Update(ticket);
            this.Data.SaveChanges();

            List<Achievement> unlocked = ResolveRulesAndAchievements(officer);
            if (unlocked.Count != 0)
            {
                ViewBag.UnlockedAchievements = unlocked;
            }

            // TODO: Change redirection
            return View("Index");
        }

        private List<Achievement> ResolveRulesAndAchievements(ApplicationUser officer)
        {
            var allTickets = this.Data.Tickets.All().Where(t => t.AssignedTo.Id == officer.Id && t.Status == StatusEnum.Resolved).ToList();
            var allRules = this.Data.Rules.All().Where(r => r.TicketsCount <= allTickets.Count).ToList();
            var completedAchievements = officer.Achievements.ToList();
            List<Achievement> newAchievements = new List<Achievement>();

            foreach (var rule in allRules)
            {
                if (completedAchievements.Contains(rule.Achievement))
                {
                    continue;
                }

                if (rule.Priority != PriorityEnum.Default)
                {
                    var ticketCountWithPriority = allTickets.Where(t => t.Priority == rule.Priority).Count();
                    if (rule.TicketsCount > ticketCountWithPriority)
                    {
                        continue;
                    }
                }
                completedAchievements.Add(rule.Achievement);
                newAchievements.Add(rule.Achievement);
            }

            foreach (var ach in newAchievements)
            {
                officer.Achievements.Add(ach);
            }
            this.Data.SaveChanges();

            return newAchievements;
        }

	}
}