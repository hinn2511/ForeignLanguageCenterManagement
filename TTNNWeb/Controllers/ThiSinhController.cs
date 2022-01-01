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
        public ActionResult Index()
        {
            var dsTS = bus.LayDanhSachThiSinh();
            return View(dsTS);
        }
    }
}