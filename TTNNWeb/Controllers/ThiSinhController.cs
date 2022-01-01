using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrungTamNgoaiNgu.BUS;

namespace TTNNWeb.Controllers
{
    public class ThiSinhController : Controller
    {
        // GET: ThiSinh
        Bus_ThiSinh bus = new Bus_ThiSinh();
        public ActionResult Index(string key)
        {
            var dsTS = bus.LayDanhSachThiSinh();
            if (!string.IsNullOrEmpty(key))
            {
                dsTS = bus.TimKiemTS(dsTS, key);
            }
            return View(dsTS);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(TrungTamNgoaiNgu.DTO.Dto_ThiSinh thisinh)
        {
            if ((string.IsNullOrEmpty(thisinh.HoTen)) || string.IsNullOrEmpty(thisinh.NoiSinh) || string.IsNullOrEmpty(thisinh.CMND) || string.IsNullOrEmpty(thisinh.NoiCap) || string.IsNullOrEmpty(thisinh.GioiTinh) || string.IsNullOrEmpty(thisinh.SDT) || string.IsNullOrEmpty(thisinh.SDT))
            {
                ViewBag.Error = "Vui lòng điền đầy đủ thông tin";
                ViewBag.loaiTourList = new SelectList(bus.LayDanhSachThiSinh());
                return View(thisinh);
            }
            else
            {
                bus.ThemTS(thisinh);
                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(int id)
        {
            var chitiet = bus.LayThongTinTS(id);
            return View(bus.convertToDto(chitiet));
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection formCollection)
        {
            bus.XoaTS(id);
            return RedirectToAction("Index");

        }
    }
}