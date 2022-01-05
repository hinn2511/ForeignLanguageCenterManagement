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
    public class TraCuuController : Controller
    {
        Bus_DSPhongThi bus = new Bus_DSPhongThi();

        public ActionResult Index(string boLoc, string tuKhoa)
        {
           
            if (!string.IsNullOrEmpty(boLoc) && !string.IsNullOrEmpty(tuKhoa))
            {
                var dsKetQua = bus.TimKiemThiSinh(boLoc, tuKhoa);
                if (dsKetQua != null)
                {
                    ViewBag.timKiem = "Kết quả tìm kiếm cho ''" + tuKhoa + "''";
                    return View(dsKetQua);
                }
                else
                    ViewBag.Error = "Không tìm thấy thí sinh dự thi.";
            }
            if (string.IsNullOrEmpty(tuKhoa))
                ViewBag.Error = "Vui lòng nhập từ khóa cần tìm kiếm.";
            return View();
           
        }
    }
}