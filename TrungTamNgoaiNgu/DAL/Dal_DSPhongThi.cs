using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrungTamNgoaiNgu.DTO;

namespace TrungTamNgoaiNgu.DAL
{
    public class Dal_DSPhongThi
    {
        QLTTNNDataContext context = new QLTTNNDataContext();

        public List<Dto_DSPhongThi> DanhSachThiSinhTheoPhong(int phongThiId)
        {
            var dsThi = context.DanhSachPhongThis.Where(t => t.Id_PhongThi == phongThiId).Select(t => new Dto_DSPhongThi
            {
                Id = t.Id,
                TenThiSinh = t.ThiSinh.HoTen,
                Id_PhongThi = t.Id_PhongThi,    
                Id_ThiSinh= t.Id_ThiSinh,
                SBD = t.SBD,
                DiemDoc = (double)t.DiemDoc,
                DiemNghe = (double)t.DiemNghe,  
                DiemNoi = (double)t.DiemNoi,
                DiemViet = (double)t.DiemViet,
            }).ToList();
            return dsThi;
        }

        public List<Dto_DSPhongThi> DanhSachThiSinhTheoKhoaVaPhong(int khoaThiId, int phongThiId)
        {
            var dsThi = context.DanhSachPhongThis.Where(t => t.Id_PhongThi == phongThiId && t.PhongThi.KhoaThi.Id == khoaThiId).Select(t => new Dto_DSPhongThi
            {
                Id = t.Id,
                TenThiSinh = t.ThiSinh.HoTen,
                Id_PhongThi = t.Id_PhongThi,
                Id_ThiSinh = t.Id_ThiSinh,
                SBD = t.SBD,
                DiemDoc = (double)t.DiemDoc,
                DiemNghe = (double)t.DiemNghe,
                DiemNoi = (double)t.DiemNoi,
                DiemViet = (double)t.DiemViet,
            }).ToList();
            return dsThi;
        }

        public List<Dto_KetQuaThi> KetQuaTheoSDT(string sdt)
        {
            var dsThi = context.DanhSachPhongThis.Where(t => t.ThiSinh.SDT == sdt).Select(t => new Dto_KetQuaThi
            {
                TenKhoaThi = t.PhongThi.KhoaThi.TenKhoaThi,
                TenPhongThi = t.PhongThi.TenPhongThi,
                TenThiSinh = t.ThiSinh.HoTen,
                SBD = t.SBD,
                DiemDoc = (double)t.DiemDoc,
                DiemNghe = (double)t.DiemNghe,
                DiemNoi = (double)t.DiemNoi,
                DiemViet = (double)t.DiemViet,
            }).ToList();
            return dsThi.Any() ? dsThi : null;
        }

        public Dto_KetQuaThiWeb KetQuaTheoPhongVaMaThiSinh(int phongThiId, int thiSinhId)
        {
            var ketQua = context.DanhSachPhongThis.Where(t => t.Id_PhongThi == phongThiId && t.Id_ThiSinh == thiSinhId).Select(t => new Dto_KetQuaThiWeb
            {
                TenKhoaThi = t.PhongThi.KhoaThi.TenKhoaThi,
                TenPhongThi = t.PhongThi.TenPhongThi,
                Id_PhongThi = t.Id_PhongThi,
                TenThiSinh = t.ThiSinh.HoTen,
                SBD = t.SBD,
                TrinhDo = t.PhongThi.TrinhDo,
                DiemDoc = (double)t.DiemDoc,
                DiemNghe = (double)t.DiemNghe,
                DiemNoi = (double)t.DiemNoi,
                DiemViet = (double)t.DiemViet,
            }).FirstOrDefault();
            return ketQua;
        }

        public List<Dto_KetQuaThi> KetQuaTheoTen(string ten)
        {
            var dsThi = context.DanhSachPhongThis.Where(t => t.ThiSinh.HoTen == ten).Select(t => new Dto_KetQuaThi
            {
                TenKhoaThi = t.PhongThi.KhoaThi.TenKhoaThi,
                TenPhongThi = t.PhongThi.TenPhongThi,
                TenThiSinh = t.ThiSinh.HoTen,
                SBD = t.SBD,
                DiemDoc = (double)t.DiemDoc,
                DiemNghe = (double)t.DiemNghe,
                DiemNoi = (double)t.DiemNoi,
                DiemViet = (double)t.DiemViet,
            }).ToList();
            return dsThi.Any() ? dsThi : null;
        }

        public int SoLuongThiSinhTheoKhoa(int khoaThiId)
        {
            int sl = context.DanhSachPhongThis.Where(t => t.PhongThi.ID_KhoaThi == khoaThiId).Count();
            return sl;
        }

        public List<Dto_DSPhongThi> DanhSachThiSinhThiTheoTrinhDo(int khoaThiId, string trinhDo)
        {
            var dsThi = context.DanhSachPhongThis.Where(t => t.PhongThi.ID_KhoaThi == khoaThiId && t.PhongThi.TrinhDo == trinhDo).Select(t => new Dto_DSPhongThi
            {
                Id = t.Id,
                TenThiSinh = t.ThiSinh.HoTen,
                Id_PhongThi = t.Id_PhongThi,
                Id_ThiSinh = t.Id_ThiSinh,
                SBD = t.SBD,
                DiemDoc = (double)t.DiemDoc,
                DiemNghe = (double)t.DiemNghe,
                DiemNoi = (double)t.DiemNoi,
                DiemViet = (double)t.DiemViet,
            }).ToList();
            return dsThi;
        }

        public bool ThemDachSachThi(DanhSachPhongThi ds)
        {

            context.DanhSachPhongThis.InsertOnSubmit(ds);
            try
            {
                context.SubmitChanges();
                return true;
            }
            catch (SqlException)
            {
                return false;
            }
        }

        public bool CapNhatDanhSachThi(DanhSachPhongThi ds)
        {
            var dsUpdate = context.DanhSachPhongThis.FirstOrDefault(t => t.Id == ds.Id);

            if (dsUpdate != null)
            {
                dsUpdate.DiemDoc = ds.DiemDoc;
                dsUpdate.DiemViet = ds.DiemViet;
                dsUpdate.DiemNghe = ds.DiemNghe;
                dsUpdate.DiemNoi = ds.DiemNoi;
                dsUpdate.Id_PhongThi = ds.Id_PhongThi;
                dsUpdate.Id_ThiSinh = ds.Id_ThiSinh;
                dsUpdate.SBD = ds.SBD;
            }
            try
            { 
                context.SubmitChanges();
                return true;
            }
            catch (SqlException)
            {
                return false;
            }
        }
    }
}
