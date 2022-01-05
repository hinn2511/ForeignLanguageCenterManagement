using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrungTamNgoaiNgu.DTO;

namespace TTNNWeb.Models
{
    public class DanhSachThi
    {
        public int Id_KhoaThi { get; set; }
        public int Id_PhongThi { get; set; }
        public List<Dto_DSPhongThi> dsPhongThi { get; set; }
    }
}