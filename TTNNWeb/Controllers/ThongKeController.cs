using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrungTamNgoaiNgu.BUS;

namespace TTNNWeb.Controllers
{
    public class ThongKeController : Controller
    {
        Bus_ThongKe bus_ThongKe = new Bus_ThongKe();
        public ActionResult Index(string trinhDo)
        {
            if (!string.IsNullOrEmpty(trinhDo))
            {
                var thongke = bus_ThongKe.LayDanhSachThongKe(trinhDo);
                ViewBag.trinhDo = "Kết quả thống kê theo trình độ ''" + trinhDo + "''";
                return View(thongke);
            }
            return View();
        }
    }
}