using System;
using System.Collections.Generic;
using TrungTamNgoaiNgu.DAL;
using TrungTamNgoaiNgu.DTO;

namespace TrungTamNgoaiNgu.BUS
{
    public class Bus_KhoaThi
    {
        Dal_KhoaThi dal = new Dal_KhoaThi();

        Dal_DSPhongThi dal_dsphongthi = new Dal_DSPhongThi();

        public List<Dto_KhoaThi> LayDanhSachKhoaThi()
        {
            var dsKhoaThi = dal.DanhSachKhoaThi();
            return dsKhoaThi;
        }

        public bool DaTaoDanhSachThi(int khoaThiId)
        {
            if (dal_dsphongthi.SoLuongThiSinhTheoKhoa(khoaThiId) > 0)
                return true;
            return false;
        }

        public List<Dto_KhoaThi> LayDanhSachKhoaThiChuaLapDanhSach()
        {
            var dsKhoaThi = dal.DanhSachKhoaThi();
            List<Dto_KhoaThi> dsMoi = new List<Dto_KhoaThi>();
            foreach (var item in dsKhoaThi)
            {
                if(!DaTaoDanhSachThi(item.Id))
                    dsMoi.Add(item);
            }    
            return dsMoi;
        }

        public List<Dto_KhoaThi> TimKiemKhoaThi(List<Dto_KhoaThi> dsKhoaThi, string key)
        {
            List <Dto_KhoaThi> ketqua = new List<Dto_KhoaThi> ();
            foreach (var item in dsKhoaThi)
            {
                if(item.TenKhoaThi.Contains(key))
                {
                    ketqua.Add(item);
                }
            }
            return ketqua;
        }

        public string ThemKhoaThi(Dto_KhoaThi dto)
        {
            DateTime now = DateTime.Now;
            if (dal.DaTaoKhoaThi(dto.NgayThi))
                return "duplicateerror";
            if(dto.NgayThi < now)
                return "dateerror";
            if (string.IsNullOrEmpty(dto.TenKhoaThi))
                return "nullerror";
            if (dal.ThemKhoaThi(convertToEntity(dto)))
                return "success";
            return "failed";
        }

        public string XoaKhoaThi(Dto_KhoaThi dto)
        {
            DateTime now = DateTime.Now;
            if (dto.NgayThi < now)
                return "timeerror";
            if (dal.XoaKhoaThi(dto.Id))
                return "success";
            return "failed";
        }

        public KhoaThi convertToEntity(Dto_KhoaThi dto)
        {
            KhoaThi kt = new KhoaThi();
            kt.Id = dto.Id;
            kt.NgayThi = dto.NgayThi;
            kt.TenKhoaThi = dto.TenKhoaThi; 
            return kt;
        }
    }
}
