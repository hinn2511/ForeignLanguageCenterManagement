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
        Dal_PhieuDangKy dal = new Dal_PhieuDangKy();
        Bus_ThiSinh busTS = new Bus_ThiSinh();
        public bool DKDuThi (Dto_PhieuDangKy pdk)
        {
            
            if (dal.ThemTSDangKyThi(convertToEntity(pdk))) return true;
            return false;
        }
// sử dụng dto thisinh2
        public bool DKDuThi(Dto_ThiSinh_PhieuDangKy TS2)
        {
            Dto_PhieuDangKy pdk = new Dto_PhieuDangKy();
            pdk.Id_ThiSinh = busTS.LayThiSinhVuaThem();
            pdk.Id_KhoaThi = TS2.Id_KhoaThi;
            pdk.TrinhDo = TS2.TrinhDo;
            pdk.NgayDangKy = TS2.NgayDangKy;
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

        public List<Dto_PhieuDangKy> LayDanhSachPhieuDk()
        {
            return dal.LayDanhSachDangKy();
        } 

    }
}
