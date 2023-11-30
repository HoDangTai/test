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
    public class NHANVIEN_63135354_Controller : Controller
    {
        private QuanlynhansuChampaIslandEntities db = new QuanlynhansuChampaIslandEntities();

        // GET: NHANVIEN_63135354_
        public ActionResult Index()
        {
            var nHANVIENs = db.NHANVIENs.Include(n => n.CHUCVU);
            return View(nHANVIENs.ToList());
        }

        // GET: NHANVIEN_63135354_/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHANVIEN nHANVIEN = db.NHANVIENs.Find(id);
            ViewBag.Gendar = nHANVIEN.GIOITINH;
            ViewBag.FullName = nHANVIEN.HONV + nHANVIEN.TENLOT + nHANVIEN.TENNV;
            if (nHANVIEN == null)
            {
                return HttpNotFound();
            }
            return View(nHANVIEN);
        }
    
        // GET: NHANVIEN_63135354_/Create
        string LayMaNV()
        {
            var maMax = db.NHANVIENs.ToList().Select(n => n.MANV).Max();
            int maNV = int.Parse(maMax.Substring(2)) + 1;
            string NV = String.Concat("00", maNV.ToString());
            return "NV" + NV.Substring(maNV.ToString().Length - 1);
        }
        [HttpGet]
        public ActionResult TimKiem_63135354(string maNV = "", string hoTen = "", string gioiTinh = "", string diaChi = "", string maCV = "",string SDT="",string CCCD="")
        {
            if (gioiTinh != "1" && gioiTinh != "0")
                gioiTinh = null;
            ViewBag.maNV = maNV;
            ViewBag.hoTen = hoTen;
            ViewBag.gioiTinh = gioiTinh;
           
            ViewBag.diaChi = diaChi;
            ViewBag.maCV = new SelectList(db.CHUCVUs, "MACV", "TENCV");            
            ViewBag.SDT = SDT;
            var nhanViens = db.NHANVIENs.SqlQuery("NhanVien_TimKiemNC'" + maNV + "',N'" + hoTen + "','" + gioiTinh + "','" + SDT + "','" + CCCD + "',N'" + diaChi + "','" + maCV + "'");
            if (nhanViens.Count() == 0)
                ViewBag.TB = "Không có thông tin tìm kiếm.";
            return View(nhanViens.ToList());
        }
        public ActionResult InDanhSachNhanVien_63135354()
        {
            var nhanViens = db.NHANVIENs.Include(n => n.CHUCVU).OrderBy(n => n.MACV);
            return PartialView(nhanViens.ToList());
        }
        public ActionResult Create()
        {
            ViewBag.MACV = new SelectList(db.CHUCVUs, "MACV", "TENCV");
            ViewBag.maNV = LayMaNV();

            return View();
        }

        // POST: NHANVIEN_63135354_/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MANV,MACV,HONV,TENLOT,TENNV,NGAYSINH,DIACHI,GIOITINH,SDT,EMAIL,NGAYVAOLAM,CCCD,ANHNV")] NHANVIEN nHANVIEN)
        {
            var imgNV = Request.Files["Avatar"];
            string postedFileName = System.IO.Path.GetFileName(imgNV.FileName);
            var path = Server.MapPath("/Images/" + postedFileName);
            imgNV.SaveAs(path);

            if (ModelState.IsValid)
            {
                nHANVIEN.MANV = LayMaNV();
                nHANVIEN.ANHNV = postedFileName;

                db.NHANVIENs.Add(nHANVIEN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MACV = new SelectList(db.CHUCVUs, "MACV", "TENCV", nHANVIEN.MACV);
            return View(nHANVIEN);
        }

        // GET: NHANVIEN_63135354_/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHANVIEN nHANVIEN = db.NHANVIENs.Find(id);
            if (nHANVIEN == null)
            {
                return HttpNotFound();
            }
            ViewBag.MACV = new SelectList(db.CHUCVUs, "MACV", "TENCV", nHANVIEN.MACV);
            return View(nHANVIEN);
        }

        // POST: NHANVIEN_63135354_/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MANV,MACV,HONV,TENLOT,TENNV,NGAYSINH,DIACHI,GIOITINH,SDT,EMAIL,NGAYVAOLAM,CCCD,ANHNV")] NHANVIEN nHANVIEN)
        {
            var imgNV = Request.Files["Avatar"];
            try
            {
                //Lấy thông tin từ input type=file có tên Avatar
                string postedFileName = System.IO.Path.GetFileName(imgNV.FileName);
                //Lưu hình đại diện về Server
                var path = Server.MapPath("~/Images/" + postedFileName);
                imgNV.SaveAs(path);

            }
            catch
            { }
            if (ModelState.IsValid)
            {

                db.Entry(nHANVIEN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MACV = new SelectList(db.CHUCVUs, "MACV", "TENCV", nHANVIEN.MACV);
            return View(nHANVIEN);
        }

        // GET: NHANVIEN_63135354_/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHANVIEN nHANVIEN = db.NHANVIENs.Find(id);
            if (nHANVIEN == null)
            {
                return HttpNotFound();
            }
            return View(nHANVIEN);
        }

        // POST: NHANVIEN_63135354_/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NHANVIEN nHANVIEN = db.NHANVIENs.Find(id);
            db.NHANVIENs.Remove(nHANVIEN);
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
