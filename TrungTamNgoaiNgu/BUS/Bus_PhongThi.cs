using System;
using System.Collections.Generic;
using TrungTamNgoaiNgu.DAL;
using TrungTamNgoaiNgu.DTO;

namespace TrungTamNgoaiNgu.BUS
{
    public class Bus_PhongThi
    {
        Dal_PhongThi dal_phongthi = new Dal_PhongThi();

        Dal_KhoaThi dal_khoaThi = new Dal_KhoaThi();

        public List<Dto_KhoaThi> LayDanhSachKhoaThi()
        {
            return dal_khoaThi.DanhSachKhoaThi();
        }

        public List<Dto_PhongThi> LayDanhSachPhongThi(int khoaThiId)
        {
            return dal_phongthi.DanhSachPhongThiTheoKhoa(khoaThiId);
        }

        public List<Dto_PhongThi> TimKiemPhongThi(List<Dto_PhongThi> dsPhongThi, string key)
        {
            List <Dto_PhongThi> ketqua = new List<Dto_PhongThi> ();
            foreach (var item in dsPhongThi)
            {
                if(item.TenPhongThi.Contains(key))
                {
                    ketqua.Add(item);
                }
            }
            return ketqua;
        }

        public string TaoTenPhongThi(int khoaThiId, string trinhDo)
        {
            int sl = dal_phongthi.SoLuongPhongThiTheoKhoa(khoaThiId) + 1;
            string temp;
            if (sl < 10)
                temp = "0" + sl.ToString();
            else
                temp = sl.ToString();
            return trinhDo + "P" + temp;
        }

        public string ThemPhongThi(Dto_PhongThi dto)
        {
            if (string.IsNullOrEmpty(dto.TenPhongThi) || string.IsNullOrEmpty(dto.TrinhDo) || string.IsNullOrEmpty(dto.CaThi))
                return "nullerror";
            if (dal_phongthi.ThemPhongThi(convertToEntity(dto)))
                return "success";
            return "failed";
        }

        public string XoaPhongThi(Dto_PhongThi dto)
        {
            if (dal_phongthi.XoaPhongThi(dto.Id))
                return "success";
            return "failed";
        }

        public PhongThi convertToEntity(Dto_PhongThi dto)
        {
            PhongThi pt = new PhongThi();
            pt.Id = dto.Id;
            pt.TenPhongThi = dto.TenPhongThi; 
            pt.CaThi = dto.CaThi;   
            pt.ID_KhoaThi = dto.ID_KhoaThi;
            pt.TrinhDo = dto.TrinhDo;
            return pt;
        }
    }
}
