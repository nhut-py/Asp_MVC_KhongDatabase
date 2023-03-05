using shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace shop.Controllers
{
    public class DonHangController : Controller
    {
        // GET: DonHang
        public ActionResult Index()
        {
            return View(dsDonHang.danhsachDonHang);
        }
        public ActionResult create()
        {
            return View(new donHang());
        }
        [HttpPost]
        public ActionResult create(donHang dh)
        {
            dsDonHang.danhsachDonHang.Add(dh);
            return RedirectToAction("index");
        }
        public ActionResult edit(int id_DonHang)
        {
            var ds = dsDonHang.danhsachDonHang.SingleOrDefault(m => m.ID == id_DonHang);
            return View(ds);
        }
        [HttpPost]
        public ActionResult edit(donHang dh)
        {
            var dsdt = dsDonHang.danhsachDonHang.SingleOrDefault(m => m.ID == dh.ID);
            dsdt.TenKhachHang = dh.TenKhachHang;
            dsdt.DiaChiGiaoHang = dh.DiaChiGiaoHang;
            dsdt.SoDienThoai = dh.SoDienThoai;
            dsdt.NgayDatHang = dh.NgayDatHang;
            return RedirectToAction("index");
        }
        public ActionResult delete(int id_DonHang)
        {
            var ds = dsDonHang.danhsachDonHang.SingleOrDefault(m => m.ID == id_DonHang);
            dsDonHang.danhsachDonHang.Remove(ds);
            return RedirectToAction("index");
        }
        public ActionResult chi_tiet(int id_DonHang)
        {
            var ds = dsDonHang.danhsachDonHang.SingleOrDefault(m => m.ID == id_DonHang);
            return View(ds);
        }
        public ActionResult them_chi_tiet(int id_DonHang)
        {
            ViewBag.id_DonHang = id_DonHang;
            return View(new dienThoai());
        }
        [HttpPost]
        public ActionResult them_chi_tiet(dienThoai dt, HttpPostedFileBase fileAnh)
        {
            var ds = dsDonHang.danhsachDonHang.SingleOrDefault(m => m.ID == dt.id);

            if (fileAnh != null)
            {
                string rootFolder = Server.MapPath("/Data/");
                string pathAnh = rootFolder + "/" + fileAnh.FileName;
                fileAnh.SaveAs(pathAnh);
                dt.urlImage = "/Data/" + fileAnh.FileName;
            }
            else
            {
                dt.urlImage = "null";
            }
            ds.DienThoaiDatMua.Add(dt);
            return RedirectToAction("chi_tiet", new {id_DonHang = dt.id});
        }
    }
}