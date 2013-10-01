﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TicketRewardSystem.Models;

namespace TicketRewardSystem.Areas.Administration.Controllers
{
    public class RulesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Administration/Rules/
        public ActionResult Index()
        {
            return View(db.Rules.ToList());
        }

        // GET: /Administration/Rules/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AchievementRule rule = db.Rules.Find(id);
            if (rule == null)
            {
                return HttpNotFound();
            }
            return View(rule);
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
        public ActionResult Create(AchievementRule rule)
        {
            if (ModelState.IsValid)
            {
                db.Rules.Add(rule);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rule);
        }

        // GET: /Administration/Rules/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AchievementRule rule = db.Rules.Find(id);
            if (rule == null)
            {
                return HttpNotFound();
            }
            return View(rule);
        }

        // POST: /Administration/Rules/Edit/5
		// To protect from over posting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		// 
		// Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AchievementRule rule)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rule).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rule);
        }

        // GET: /Administration/Rules/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AchievementRule rule = db.Rules.Find(id);
            if (rule == null)
            {
                return HttpNotFound();
            }
            return View(rule);
        }

        // POST: /Administration/Rules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AchievementRule rule = db.Rules.Find(id);
            db.Rules.Remove(rule);
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
