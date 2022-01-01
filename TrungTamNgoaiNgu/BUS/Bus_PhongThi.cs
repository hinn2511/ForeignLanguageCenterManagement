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

        Dal_DSPhongThi dal_dsphongthi = new Dal_DSPhongThi();

        Dal_PhieuDangKy dal_phieudk = new Dal_PhieuDangKy();

        public bool CoTheTaoDanhSachThi(int khoaThiId)
        {
            int soLuongThiSinhA2 = dal_phieudk.LaySoLuongDangKy(khoaThiId, "A2");
            int soLuongThiSinhB1 = dal_phieudk.LaySoLuongDangKy(khoaThiId, "B1");
            int soPhongA2 = dal_phongthi.SoLuongPhongThiTheoKhoaVaTrinhDo(khoaThiId, "A2");
            int soPhongB1 = dal_phongthi.SoLuongPhongThiTheoKhoaVaTrinhDo(khoaThiId, "B1");
            if (soLuongThiSinhA2 > soPhongA2 * 35 || soLuongThiSinhB1 > soPhongB1 * 35)
                return false;
            return true;
        }

        public bool DaTaoDanhSachThi(int khoaThiId)
        {
            if(dal_dsphongthi.SoLuongThiSinhTheoKhoa(khoaThiId) > 0)
                return true;
            return false;
        }

        public void TaoDanhSachThi(int khoaThiId)
        {
            List<Dto_PhieuDangKy> DSDKA2 = dal_phieudk.LayDanhSachDangKy(khoaThiId, "A2");
            List<Dto_PhieuDangKy> DSDKB1 = dal_phieudk.LayDanhSachDangKy(khoaThiId, "B1");
            List<Dto_PhongThi> DSPTA2 = dal_phongthi.DanhSachPhongThiTheoKhoaVaTrinhDo(khoaThiId, "A2");
            List<Dto_PhongThi> DSPTB1 = dal_phongthi.DanhSachPhongThiTheoKhoaVaTrinhDo(khoaThiId, "B1");
            int num = 1;
            foreach (var item in DSDKA2)
            {
                Dto_DSPhongThi pt = new Dto_DSPhongThi();
                pt.Id_ThiSinh = item.Id_ThiSinh;
                pt.Id_PhongThi = DSPTA2[(num / 36)].Id;
                if (num < 10)
                    pt.SBD = "A200" + num.ToString();
                else
                    pt.SBD = "A20" + num.ToString();
                pt.DiemDoc = 0;
                pt.DiemNghe = 0;
                pt.DiemViet = 0;
                pt.DiemNoi = 0;
                num++;
                dal_dsphongthi.ThemDachSachThi(convertToEntity(pt));
            }
            num = 1;
            foreach (var item in DSDKB1)
            {
                Dto_DSPhongThi pt = new Dto_DSPhongThi();
                pt.Id_ThiSinh = item.Id_ThiSinh;
                pt.Id_PhongThi = DSPTB1[(num / 36)].Id;
                if (num < 10)
                    pt.SBD = "B100" + num.ToString();
                else
                    pt.SBD = "B10" + num.ToString();
                pt.DiemDoc = 0;
                pt.DiemNghe = 0;
                pt.DiemViet = 0;
                pt.DiemNoi = 0;
                num++;
                dal_dsphongthi.ThemDachSachThi(convertToEntity(pt));
            }
        }


        public DanhSachPhongThi convertToEntity(Dto_DSPhongThi dto)
        {
            DanhSachPhongThi dspt = new DanhSachPhongThi();
            dspt.Id = dto.Id;
            dspt.SBD = dto.SBD;
            dspt.Id_ThiSinh = dto.Id_ThiSinh;
            dspt.Id_PhongThi = dto.Id_PhongThi;
            dspt.DiemNghe = dto.DiemNghe;
            dspt.DiemNoi = dto.DiemNoi;
            dspt.DiemDoc = dto.DiemDoc;
            dspt.DiemViet = dto.DiemViet;
            return dspt;
        }


    

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
