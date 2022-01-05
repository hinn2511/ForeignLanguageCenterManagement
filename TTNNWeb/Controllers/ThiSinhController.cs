using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrungTamNgoaiNgu.BUS;

namespace TTNNWeb.Controllers
{
    public class ThiSinhController : Controller
    {
        // GET: ThiSinh
        Bus_ThiSinh bus_thiSinh = new Bus_ThiSinh();

        Bus_DSPhongThi bus_DSPhongThi = new Bus_DSPhongThi();
        public ActionResult Index(string key)
        {
            var dsTS = bus_thiSinh.LayDanhSachThiSinh();
            if (!string.IsNullOrEmpty(key))
            {
                dsTS = bus_thiSinh.TimKiemTS(dsTS, key);
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
                ViewBag.loaiTourList = new SelectList(bus_thiSinh.LayDanhSachThiSinh());
                return View(thisinh);
            }
            else
            {
                bus_thiSinh.ThemTS(thisinh);
                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(int id)
        {
            var chitiet = bus_thiSinh.LayThongTinTS(id);
            return View(bus_thiSinh.convertToDto(chitiet));
        }

        public ActionResult Detail(int id)
        {
            var chitiet = bus_thiSinh.LayThongTinTS(id);
            return View(bus_thiSinh.convertToDto(chitiet));
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection formCollection)
        {
            bus_thiSinh.XoaTS(id);
            return RedirectToAction("Index");

        }

        public ActionResult Result(int phongThiId, int thiSinhId)
        {
            var ketqua = bus_DSPhongThi.KetQuaThiSinhTheoPhongVaMaThiSinh(phongThiId, thiSinhId);
            return View(ketqua);
        }

        public ActionResult Certificate(int phongThiId, int thiSinhId)
        {
            var cn = bus_DSPhongThi.LayGiayChungNhan(phongThiId, thiSinhId);
            cn.DiemThi = (cn.DiemNghe + cn.DiemNoi + cn.DiemDoc + cn.DiemViet) / 10;
            ViewBag.thoiGian = "TP.HCM, ngày " + DateTime.Now.Day.ToString() + " tháng " + DateTime.Now.Month.ToString() + " năm " + DateTime.Now.Year.ToString();
            return View(cn);
        }
    }
}