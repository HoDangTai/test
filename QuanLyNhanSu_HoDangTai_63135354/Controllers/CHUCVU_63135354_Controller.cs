using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLyNhanSu_HoDangTai_63135354.Models;

namespace QuanLyNhanSu_HoDangTai_63135354.Controllers
{
    public class CHUCVU_63135354_Controller : Controller
    {
        private QuanlynhansuChampaIslandEntities db = new QuanlynhansuChampaIslandEntities();

        // GET: CHUCVU_63135354_
        public ActionResult Index()
        {
            return View(db.CHUCVUs.ToList());
        }

        // GET: CHUCVU_63135354_/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHUCVU cHUCVU = db.CHUCVUs.Find(id);
            if (cHUCVU == null)
            {
                return HttpNotFound();
            }
            return View(cHUCVU);
        }

        // GET: CHUCVU_63135354_/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CHUCVU_63135354_/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MACV,TENCV")] CHUCVU cHUCVU)
        {
            if (ModelState.IsValid)
            {
                db.CHUCVUs.Add(cHUCVU);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cHUCVU);
        }

        // GET: CHUCVU_63135354_/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHUCVU cHUCVU = db.CHUCVUs.Find(id);
            if (cHUCVU == null)
            {
                return HttpNotFound();
            }
            return View(cHUCVU);
        }

        // POST: CHUCVU_63135354_/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MACV,TENCV")] CHUCVU cHUCVU)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cHUCVU).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cHUCVU);
        }

        // GET: CHUCVU_63135354_/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHUCVU cHUCVU = db.CHUCVUs.Find(id);
            if (cHUCVU == null)
            {
                return HttpNotFound();
            }
            return View(cHUCVU);
        }

        // POST: CHUCVU_63135354_/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CHUCVU cHUCVU = db.CHUCVUs.Find(id);
            db.CHUCVUs.Remove(cHUCVU);
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
