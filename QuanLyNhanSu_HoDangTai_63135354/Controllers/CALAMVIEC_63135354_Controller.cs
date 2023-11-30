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
    public class CALAMVIEC_63135354_Controller : Controller
    {
        private QuanlynhansuChampaIslandEntities db = new QuanlynhansuChampaIslandEntities();

        // GET: CALAMVIEC_63135354_
        public ActionResult Index()
        {
            return View(db.CALAMVIECs.ToList());
        }

        // GET: CALAMVIEC_63135354_/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CALAMVIEC cALAMVIEC = db.CALAMVIECs.Find(id);
            if (cALAMVIEC == null)
            {
                return HttpNotFound();
            }
            return View(cALAMVIEC);
        }

        // GET: CALAMVIEC_63135354_/Create
        string LayMaCa()
        {
            var maMax = db.CALAMVIECs.ToList().Select(n => n.MACA).Max();
            int maNV = int.Parse(maMax.Substring(2)) + 1;
            string NV = String.Concat("0", maNV.ToString());
            return "CA" + NV.Substring(maNV.ToString().Length - 1);
        }

        [HttpGet]
        public ActionResult TimKiem_63135354(string maCA = "", string moTa = "", string ngayLamViec = "")
        {
            ViewBag.maCA = maCA;
            ViewBag.ngayLamViec = ngayLamViec;

            var cALAMVIECs = db.CALAMVIECs.SqlQuery("CaLamViec_TimKiemNC'" + maCA + "',N'" + moTa + "','" + ngayLamViec + "'");
            if (cALAMVIECs.Count() == 0)
                ViewBag.TB = "Không có thông tin tìm kiếm.";
            return View(cALAMVIECs.ToList());
        }

        public ActionResult InDanhSachCaLamViec_63135354()
        {
            var cALAMVIECs = db.CALAMVIECs.OrderBy(n => n.MACA).ToList();

            return PartialView(cALAMVIECs.ToList());
        }
        public ActionResult Create()
        {
            ViewBag.maCa = LayMaCa();
            return View();
        }

        // POST: CALAMVIEC_63135354_/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MACA,MOTACALAMVIEC,TGBATDAU,TGKETTHUC,NGAYLAMVIEC,SLNHANVIEN")] CALAMVIEC cALAMVIEC)
        {
            if (ModelState.IsValid)
            {
                cALAMVIEC.MACA = LayMaCa();

                db.CALAMVIECs.Add(cALAMVIEC);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cALAMVIEC);
        }

        // GET: CALAMVIEC_63135354_/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CALAMVIEC cALAMVIEC = db.CALAMVIECs.Find(id);
            if (cALAMVIEC == null)
            {
                return HttpNotFound();
            }
            return View(cALAMVIEC);
        }

        // POST: CALAMVIEC_63135354_/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MACA,MOTACALAMVIEC,TGBATDAU,TGKETTHUC,NGAYLAMVIEC,SLNHANVIEN")] CALAMVIEC cALAMVIEC)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cALAMVIEC).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cALAMVIEC);
        }

        // GET: CALAMVIEC_63135354_/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CALAMVIEC cALAMVIEC = db.CALAMVIECs.Find(id);
            if (cALAMVIEC == null)
            {
                return HttpNotFound();
            }
            return View(cALAMVIEC);
        }

        // POST: CALAMVIEC_63135354_/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CALAMVIEC cALAMVIEC = db.CALAMVIECs.Find(id);
            db.CALAMVIECs.Remove(cALAMVIEC);
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
