using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrungTamNgoaiNgu.DTO
{
    public class Dto_PhieuDangKy
    {
        public int Id_ThiSinh { get; set; }
        public int Id_KhoaThi { get; set; }
        public string TrinhDo { get; set; }
        public DateTime NgayDangKy { get; set; }
    }
}
