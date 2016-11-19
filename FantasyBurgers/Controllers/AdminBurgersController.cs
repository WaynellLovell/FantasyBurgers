﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FantasyBurgers.Models;

namespace FantasyBurgers.Controllers
{
    public class AdminBurgersController : Controller
    {
        private FantasyBurgersContext db = new FantasyBurgersContext();

        // GET: AdminBurgers
        public ActionResult Index()
        {
            return View(db.Burgers.ToList());
        }

        // GET: AdminBurgers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Burger burger = db.Burgers.Find(id);
            if (burger == null)
            {
                return HttpNotFound();
            }
            return View(burger);
        }

        // GET: AdminBurgers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminBurgers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BurgerId,BurgerName,BurgerShortDescription,BurgerLongDescription,BurgerPrice,BurgerImage")] Burger burger)
        {
            if (ModelState.IsValid)
            {
                db.Burgers.Add(burger);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(burger);
        }

        // GET: AdminBurgers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Burger burger = db.Burgers.Find(id);
            if (burger == null)
            {
                return HttpNotFound();
            }
            return View(burger);
        }

        // POST: AdminBurgers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BurgerId,BurgerName,BurgerShortDescription,BurgerLongDescription,BurgerPrice,BurgerImage")] Burger burger)
        {
            if (ModelState.IsValid)
            {
                db.Entry(burger).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(burger);
        }

        // GET: AdminBurgers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Burger burger = db.Burgers.Find(id);
            if (burger == null)
            {
                return HttpNotFound();
            }
            return View(burger);
        }

        // POST: AdminBurgers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Burger burger = db.Burgers.Find(id);
            db.Burgers.Remove(burger);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
