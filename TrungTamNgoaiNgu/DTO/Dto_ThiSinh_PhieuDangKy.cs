using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrungTamNgoaiNgu.DTO
{
    public class Dto_ThiSinh_PhieuDangKy
    {
        public int Id { get; set; }
        public string HoTen { get; set; }
        public string GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }

        public string NoiSinh { get; set; }

        public string CMND { get; set; }

        public DateTime NgayCap { get; set; }

        public string NoiCap { get; set; }

        public string SDT { get; set; }

        public string Email { get; set; }

        public int Id_KhoaThi { get; set; }
        public string TrinhDo { get; set; }
        public DateTime NgayDangKy { get; set; }
    }
}
