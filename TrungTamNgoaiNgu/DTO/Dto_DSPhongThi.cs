using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrungTamNgoaiNgu.DTO
{
    public class Dto_DSPhongThi
    {
        public int Id { get; set; }
        public int Id_ThiSinh { get; set; }
        public int Id_PhongThi { get; set; }
        public string TenThiSinh { get; set; }
        public string SBD { get; set; }
        public double DiemNghe { get; set; }
        public double DiemNoi { get; set; }
        public double DiemDoc { get; set; }
        public double DiemViet { get; set; }

    }
}
