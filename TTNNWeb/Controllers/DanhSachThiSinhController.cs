using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrungTamNgoaiNgu.BUS;
using TrungTamNgoaiNgu.DTO;

namespace TTNNWeb.Controllers
{
    public class DanhSachThiSinhController : Controller
    {
        Bus_DSPhongThi bus_dsPhongThi = new Bus_DSPhongThi();

        public ActionResult Index()
        {
            var dsKhoaThi = bus_dsPhongThi.LayDanhSachKhoaThi();
            ViewBag.dsKhoaThi = new SelectList(dsKhoaThi, "Id", "TenKhoaThi");
            ViewBag.dsPhongThi = new SelectList(bus_dsPhongThi.LayDanhSachPhongThi(dsKhoaThi[0].Id), "Id", "TenPhongThi"); ;
            return View();
        }
        public ActionResult LayDanhSachPhongThi(int? khoaThiId)
        {

            List<Dto_PhongThi> dsPhongThi = bus_dsPhongThi.LayDanhSachPhongThi((int)khoaThiId);

            return Json(dsPhongThi, JsonRequestBehavior.AllowGet);
        }

        public ActionResult LayDanhSachThiSinh(int? khoaThiId, int? phongThiId)
        {
            List<Dto_DSPhongThi> dsThiSinhTheoPhong = bus_dsPhongThi.DanhSachThiSinhTheoKhoaVaPhong((int)khoaThiId, (int)phongThiId);

            return Json(dsThiSinhTheoPhong, JsonRequestBehavior.AllowGet);
        }

        public ActionResult HienBangDanhSach(int? khoaThiId, int? phongThiId)
        {
            List<Dto_DSPhongThi> dsThiSinhTheoPhong = bus_dsPhongThi.DanhSachThiSinhTheoKhoaVaPhong((int)khoaThiId, (int)phongThiId);

            return PartialView(dsThiSinhTheoPhong);
        }
    }
}