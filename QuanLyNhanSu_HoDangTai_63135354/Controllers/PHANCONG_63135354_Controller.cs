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
    public class PHANCONG_63135354_Controller : Controller
    {
        private QuanlynhansuChampaIslandEntities db = new QuanlynhansuChampaIslandEntities();

        // GET: PHANCONG_63135354_
        public ActionResult Index()
        {
            var pHANCONGs = db.PHANCONGs.Include(p => p.CALAMVIEC).Include(p => p.NHANVIEN);
            return View(pHANCONGs.ToList());
        }

        // GET: PHANCONG_63135354_/Details/5
        public ActionResult Details(string id, string id1, string id2)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHANCONG pHANCONG = db.PHANCONGs.Find(id,id1,id2);
            if (pHANCONG == null)
            {
                return HttpNotFound();
            }
            return View(pHANCONG);
        }

        string LayMaPC()
        {
            var maMax = db.PHANCONGs.ToList().Select(n => n.MAPC).Max();
            int maNV = int.Parse(maMax.Substring(2)) + 1;
            string NV = String.Concat("00", maNV.ToString());
            return "PC" + NV.Substring(maNV.ToString().Length - 1);
        }
        // GET: PHANCONG_63135354_/Create
        public ActionResult Create()
        {
            ViewBag.maPC = LayMaPC();
            ViewBag.MACA = new SelectList(db.CALAMVIECs, "MACA", "MACA");
            ViewBag.MANV = new SelectList(db.NHANVIENs, "MANV", "MANV");
            return View();
        }

        // POST: PHANCONG_63135354_/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MAPC,MACA,MANV")] PHANCONG pHANCONG)
        {
            if (ModelState.IsValid)
            {
                pHANCONG.MAPC = LayMaPC();
                db.PHANCONGs.Add(pHANCONG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MACA = new SelectList(db.CALAMVIECs, "MACA", "MACA", pHANCONG.MACA);
            ViewBag.MANV = new SelectList(db.NHANVIENs, "MANV", "MANV", pHANCONG.MANV);
            return View(pHANCONG);
        }

        // GET: PHANCONG_63135354_/Edit/5
        public ActionResult Edit(string id,string id1,string id2)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHANCONG pHANCONG = db.PHANCONGs.Find(id,id1,id2);
            if (pHANCONG == null)
            {
                return HttpNotFound();
            }
            ViewBag.MACA = new SelectList(db.CALAMVIECs, "MACA", "MACA", pHANCONG.MACA);
            ViewBag.MANV = new SelectList(db.NHANVIENs, "MANV", "MANV", pHANCONG.MANV);
            return View(pHANCONG);
        }

        // POST: PHANCONG_63135354_/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MAPC,MACA,MANV")] PHANCONG pHANCONG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pHANCONG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           /* ViewBag.MACA = new SelectList(db.CALAMVIECs, "MACA", "MACA", pHANCONG.MACA);
            ViewBag.MANV = new SelectList(db.NHANVIENs, "MANV", "MANV", pHANCONG.MANV);*/
            return View(pHANCONG);
        }

        // GET: PHANCONG_63135354_/Delete/5
        public ActionResult Delete(string id,string id1,string id2)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHANCONG pHANCONG = db.PHANCONGs.Find(id,id1,id2);
            if (pHANCONG == null)
            {
                return HttpNotFound();
            }
            return View(pHANCONG);
        }

        // POST: PHANCONG_63135354_/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id, string id1, string id2)
        {
            PHANCONG pHANCONG = db.PHANCONGs.Find(id, id1, id2);

            db.PHANCONGs.Remove(pHANCONG);
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
