using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrungTamNgoaiNgu.DTO;

namespace TrungTamNgoaiNgu.DAL
{
    public class Dal_PhieuDangKy
    {
        QLTTNNDataContext context = new QLTTNNDataContext();
        public List<Dto_PhieuDangKy> LayDanhSachDangKy(int khoaThiId, string trinhDo) {
            var dsDangKy = context.PhieuDangKies.Where(dk => dk.Id_KhoaThi == khoaThiId && dk.TrinhDo == trinhDo).Select(dk => new Dto_PhieuDangKy
            {
                Id_KhoaThi = khoaThiId,
                TrinhDo = trinhDo,
                Id_ThiSinh = dk.Id_ThiSinh,
                NgayDangKy = dk.NgayDangKy
            }).ToList();
            return dsDangKy;
        }

        public int LaySoLuongDangKy(int khoaThiId, string trinhDo)
        {
            var sl = context.PhieuDangKies.Where(dk => dk.Id_KhoaThi == khoaThiId && dk.TrinhDo == trinhDo).Count();
            return sl;
        }

        public bool ThemTSDangKyThi (PhieuDangKy phieuDangKy)
        {
            context.PhieuDangKies.InsertOnSubmit(phieuDangKy);
            try
            {
                context.SubmitChanges();
                return true;
            }
            catch { return false; }
        }
    }
}
