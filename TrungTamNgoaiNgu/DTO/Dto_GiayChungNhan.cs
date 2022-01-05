using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrungTamNgoaiNgu.DTO
{
    public class Dto_GiayChungNhan
    {
        public string TrinhDo { get; set; }
        public string TenThiSinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public DateTime NgayThi { get; set; }
        public double DiemNghe { get; set; }
        public double DiemNoi { get; set; }
        public double DiemDoc { get; set; }
        public double DiemViet { get; set; }
        public double DiemThi { get; set; }

    }
}
