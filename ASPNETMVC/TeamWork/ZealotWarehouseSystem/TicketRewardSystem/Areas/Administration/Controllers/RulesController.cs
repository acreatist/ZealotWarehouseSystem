using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TicketRewardSystem.Models;
using TicketRewardSystem.Repository;

namespace TicketRewardSystem.Areas.Administration.Controllers
{
    public class RulesController : AdminBaseController
    {
        private UowData db = new UowData();

        // GET: /Administration/Rules/
        public ActionResult Index()
        {
            return View(db.Rules.All().ToList());
        }

        // GET: /Administration/Rules/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AchievementRule achievementrule = db.Rules.GetById((int)id);
            if (achievementrule == null)
            {
                return HttpNotFound();
            }
            return View(achievementrule);
        }

        // GET: /Administration/Rules/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Administration/Rules/Create
		// To protect from over posting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		// 
		// Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AchievementRule achievementrule)
        {
            if (ModelState.IsValid)
            {
                db.Rules.Add(achievementrule);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(achievementrule);
        }

        // GET: /Administration/Rules/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AchievementRule achievementrule = db.Rules.GetById((int)id);
            if (achievementrule == null)
            {
                return HttpNotFound();
            }
            return View(achievementrule);
        }

        // POST: /Administration/Rules/Edit/5
		// To protect from over posting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		// 
		// Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AchievementRule achievementrule)
        {
            if (ModelState.IsValid)
            {
                db.Rules.Update(achievementrule);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(achievementrule);
        }

        // GET: /Administration/Rules/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AchievementRule achievementrule = db.Rules.GetById((int)id);
            if (achievementrule == null)
            {
                return HttpNotFound();
            }
            return View(achievementrule);
        }

        // POST: /Administration/Rules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AchievementRule achievementrule = db.Rules.GetById((int)id);
            db.Rules.Delete(achievementrule);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
