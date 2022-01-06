using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrungTamNgoaiNgu.BUS;

namespace TTNNWeb.Controllers
{
    public class GiayChungNhanController : Controller
    {
        Bus_DSPhongThi bus_DSPhongThi = new Bus_DSPhongThi();
        public ActionResult Index(int? khoaThiId, string sbd)
        {
            ViewBag.dsKhoaThi = bus_DSPhongThi.LayDanhSachKhoaThi();

            if (khoaThiId  > -1 && !string.IsNullOrEmpty(sbd))
            {
                if (bus_DSPhongThi.TonTaiSBD((int)khoaThiId, sbd))
                {
                    var ketqua = bus_DSPhongThi.LayGiayChungNhan((int)khoaThiId, sbd);
                    ViewBag.thoiGian = "TP.HCM, ngày " + DateTime.Now.Day.ToString() + " tháng " + DateTime.Now.Month.ToString() + " năm " + DateTime.Now.Year.ToString();
                    return View("../ThiSinh/Certificate", ketqua);
                }
                else
                    ViewBag.Error = "Không tìm thấy thông tin thí sinh";
               
            }    
            if(Request.Url.AbsoluteUri.ToString().ToLower().Contains("sbd") && string.IsNullOrEmpty(sbd))
                ViewBag.Error = "Vui lòng nhập số báo danh của thí sinh";
            return View();
        }
    }
}