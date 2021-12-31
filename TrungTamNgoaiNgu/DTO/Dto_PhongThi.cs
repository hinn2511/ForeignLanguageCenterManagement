using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrungTamNgoaiNgu.DTO
{
    public class Dto_PhongThi
    {
        public int Id { get; set; }
        public int ID_KhoaThi { get; set; }
        public string TenPhongThi { get; set; }
        public string TrinhDo { get; set; }
        public string CaThi { get; set; }
    }
}
