﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{   [Authorize]
    public class DestinationsController : Controller
    {
        private Context db = new Context();

        // GET: Destinations
        public ActionResult Index(String searchBy, String request)
        {
            var dest = db.Destinacii;


            if (request == null || request == "")
            {


                return View(dest.ToList());
            }
            else
            {
                if (searchBy == "Name")
                {


                    return View(dest.Where(item => item.Name.StartsWith(request)).ToList());

                }

                else
                {
                    return View(dest.Where(item => item.Country.StartsWith(request)).ToList());
                }

                
            }
        }

        // GET: Destinations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Destination destination = db.Destinacii.Find(id);
            if (destination == null)
            {
                return HttpNotFound();
            }
            return View(destination);
        }

        [Authorize(Roles ="Administrator")]
        // GET: Destinations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Destinations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Country,Description,ImageUrl")] Destination destination)
        {
            if (ModelState.IsValid)
            {
                db.Destinacii.Add(destination);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(destination);
        }
        [Authorize(Roles = "Administrator")]

        // GET: Destinations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Destination destination = db.Destinacii.Find(id);
            if (destination == null)
            {
                return HttpNotFound();
            }
            return View(destination);
        }

        // POST: Destinations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Country,Description,ImageUrl")] Destination destination)
        {
            if (ModelState.IsValid)
            {
                db.Entry(destination).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(destination);
        }
        [Authorize(Roles = "Administrator")]

        // GET: Destinations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Destination destination = db.Destinacii.Find(id);
            if (destination == null)
            {
                return HttpNotFound();
            }
            return View(destination);
        }
       

        // POST: Destinations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Destination destination = db.Destinacii.Find(id);
            db.Destinacii.Remove(destination);
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
