using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrungTamNgoaiNgu.DTO;
using TrungTamNgoaiNgu.DAL;

namespace TrungTamNgoaiNgu.BUS
{
    public class Bus_PhieuDangKy
    {
        public bool DKDuThi (Dto_PhieuDangKy pdk)
        {
            Dal_PhieuDangKy dal = new Dal_PhieuDangKy();
            if (dal.ThemTSDangKyThi(convertToEntity(pdk))) return true;
            return false;
        }
         public PhieuDangKy convertToEntity(Dto_PhieuDangKy dto)
        {
            PhieuDangKy pt = new PhieuDangKy();
            pt.Id_ThiSinh = dto.Id_ThiSinh;
            pt.Id_KhoaThi = dto.Id_KhoaThi;
            pt.TrinhDo  = dto.TrinhDo;
            pt.NgayDangKy = dto.NgayDangKy;
            return pt;
        }

    }
}
