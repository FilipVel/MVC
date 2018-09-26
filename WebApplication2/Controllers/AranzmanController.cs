using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{   [Authorize]
    public class AranzmanController : Controller
    {
        private Context db = new Context();

        // GET: Aranzman
        public ActionResult Index(String searchBy, String request)
        {
            var aranzmani = db.Aranzmani.Include(a => a.Destination);
            

            if (request == null|| request=="")
            {
                

                return View(aranzmani.ToList());
            }
            else { 
                 if (searchBy == "Type")
                {

                   
                    return View(aranzmani.Where(item=>item.Type==request).ToList());

                }

                 if (searchBy == "Number of nights")
                {
                    return View(db.Aranzmani.Include(a => a.Destination).Where(item => item.brNok.ToString()==request || request == "").ToList() );

                }

                else
                {
                    var requestInt = Convert.ToInt32(request);
                    return View(aranzmani.Where(item => item.Cena <= requestInt || request == "").ToList());


                }
            }
        }

        // GET: Aranzman/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aranzman aranzman = db.Aranzmani.Find(id);
            if (aranzman == null)
            {
                return HttpNotFound();
            }
            return View(aranzman);
        }
        [Authorize(Roles = "Administrator")]

        // GET: Aranzman/Create
        public ActionResult Create()
        {
            ViewBag.DestinationId = new SelectList(db.Destinacii, "Id", "Name");
            return View();
        }

        // POST: Aranzman/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Cena,brNok,Opis,Type,DestinationId")] Aranzman aranzman)
        {
            if (ModelState.IsValid)
            {
                db.Aranzmani.Add(aranzman);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DestinationId = new SelectList(db.Destinacii, "Id", "Name", aranzman.DestinationId);
            return View(aranzman);
        }
        [Authorize(Roles = "Administrator")]

        // GET: Aranzman/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aranzman aranzman = db.Aranzmani.Find(id);
            if (aranzman == null)
            {
                return HttpNotFound();
            }
            ViewBag.DestinationId = new SelectList(db.Destinacii, "Id", "Name", aranzman.DestinationId);
            return View(aranzman);
        }

        // POST: Aranzman/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Cena,brNok,Opis,Type,DestinationId")] Aranzman aranzman)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aranzman).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DestinationId = new SelectList(db.Destinacii, "Id", "Name", aranzman.DestinationId);
            return View(aranzman);
        }
        [Authorize(Roles = "Administrator")]

        // GET: Aranzman/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aranzman aranzman = db.Aranzmani.Find(id);
            if (aranzman == null)
            {
                return HttpNotFound();
            }
            return View(aranzman);
        }

        // POST: Aranzman/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Aranzman aranzman = db.Aranzmani.Find(id);
            db.Aranzmani.Remove(aranzman);
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
