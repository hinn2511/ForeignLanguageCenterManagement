using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

        public int SoLuongThiSinhTheoKhoa(int khoaThiId, string trinhDo)
        {
            int sl = context.DanhSachPhongThis.Where(t => t.PhongThi.ID_KhoaThi == khoaThiId && t.PhongThi.TrinhDo == trinhDo).Count();
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

    }
}
