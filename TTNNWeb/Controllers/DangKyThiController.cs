using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Dynamic;
using TrungTamNgoaiNgu.BUS;
using System.Text.RegularExpressions;

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

         public static bool IsPhoneNumber(string number)
        {
            return Regex.Match(number, @"^([0-9]{10})$").Success;
        }

        public static bool IsIdCard(string number)
        {
            return Regex.Match(number, @"^([0-9]{9,12})$").Success;
        }
        public ActionResult Index()
        {
            ViewBag.ListKhoaThi = new SelectList(buskhoathi.LayDanhSachKhoaThiChuaLapDanhSach(), "Id", "TenKhoaThi");
            return View();
        }

        [HttpPost]
        public ActionResult Index( TrungTamNgoaiNgu.DTO.Dto_ThiSinh_PhieuDangKy thisinh)
        {
            ViewBag.ListKhoaThi = new SelectList(buskhoathi.LayDanhSachKhoaThiChuaLapDanhSach(), "Id", "TenKhoaThi");
            if ((string.IsNullOrEmpty(thisinh.HoTen)) || string.IsNullOrEmpty(thisinh.NoiSinh) || string.IsNullOrEmpty(thisinh.CMND) || string.IsNullOrEmpty(thisinh.NoiCap) || string.IsNullOrEmpty(thisinh.GioiTinh) || string.IsNullOrEmpty(thisinh.SDT))
            {
                ViewBag.Error = "Vui lòng điền đầy đủ thông tin";
                return View(thisinh);
            }
            else if (!IsPhoneNumber(thisinh.SDT))
            {
                ViewBag.Error = "Số điện thoại là dãy có 10 chữ số";
                return View(thisinh);
            }
            else if (!IsIdCard(thisinh.CMND))
            {
                ViewBag.Error = "CMND/CCCD là dãy số có 9-12 số";
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