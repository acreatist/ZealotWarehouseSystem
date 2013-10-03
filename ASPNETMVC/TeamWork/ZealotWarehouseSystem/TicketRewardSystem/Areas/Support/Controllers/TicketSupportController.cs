using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicketRewardSystem.Areas.Administration.ViewModels;
using TicketRewardSystem.Repository;

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
	}
}