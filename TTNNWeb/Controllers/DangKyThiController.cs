using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Dynamic;
using TrungTamNgoaiNgu.BUS;

namespace TTNNWeb.Controllers
{
    
    public class DangKyThiController : Controller
    {
        // GET: DangKyThi
        Bus_ThiSinh busThisinh = new Bus_ThiSinh();
        Bus_KhoaThi buskhoathi = new Bus_KhoaThi();
        Bus_PhieuDangKy busPdk = new Bus_PhieuDangKy();
        DateTime now = DateTime.Now;
        int idTS;
        public ActionResult Index()
        {
            ViewBag.ListKhoaThi = new SelectList(buskhoathi.LayDanhSachKhoaThi(), "Id", "TenKhoaThi");
            return View();
        }

        [HttpPost]
        public ActionResult Index( TrungTamNgoaiNgu.DTO.Dto_ThiSinh_PhieuDangKy thisinh)
        {
            if ((string.IsNullOrEmpty(thisinh.HoTen)) || string.IsNullOrEmpty(thisinh.NoiSinh) || string.IsNullOrEmpty(thisinh.CMND) || string.IsNullOrEmpty(thisinh.NoiCap) || string.IsNullOrEmpty(thisinh.GioiTinh) || string.IsNullOrEmpty(thisinh.SDT))
            {
                ViewBag.Error = "Vui lòng điền đầy đủ thông tin";
                ViewBag.ListKhoaThi = new SelectList(buskhoathi.LayDanhSachKhoaThi(), "Id", "TenKhoaThi");
                return View(thisinh);
            }
            else
            {
                if (busThisinh.ThemTS(thisinh))
                {
                   thisinh.NgayDangKy = now;
                   busPdk.DKDuThi(thisinh);
                }
                return View("DangKyThanhCong");
            }
        }

    }
}