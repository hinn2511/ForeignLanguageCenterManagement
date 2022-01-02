using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrungTamNgoaiNgu.DTO
{
    public class Dto_DSDangKyThi
    {
        public int id_khoathi { get; set; }
        public int id_thisinh { get; set;}

        public string cmnd { get; set; }

        public string hoten { get; set; }

        public DateTime ngaydk { get; set; }

        public string trinhdo { get; set; }

    }
}
