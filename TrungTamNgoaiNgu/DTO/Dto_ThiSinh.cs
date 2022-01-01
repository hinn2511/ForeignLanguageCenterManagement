using System;

namespace TrungTamNgoaiNgu.DTO
{
    public class Dto_ThiSinh
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
    }
}
