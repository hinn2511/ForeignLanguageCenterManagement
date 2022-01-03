using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrungTamNgoaiNgu.DTO;

namespace TrungTamNgoaiNgu.DAL
{
    public class Dal_DSDangKyThi
    {
        QLTTNNDataContext context = new QLTTNNDataContext();

        public List<Dto_DSDangKyThi> LayDsDangKyThi(int idKhoaThi)
        {
            List<Dto_DSDangKyThi> ds = context.PhieuDangKies.Where(p => p.Id_KhoaThi == idKhoaThi).Select(p => new Dto_DSDangKyThi
            {
                id_khoathi = p.Id_KhoaThi,
                id_thisinh = p.Id_ThiSinh,
                hoten = p.ThiSinh.HoTen,
                cmnd = p.ThiSinh.CMND,
                ngaydk = p.NgayDangKy,
                trinhdo = p.TrinhDo                
            }).ToList();
                return ds;
        }
    }
}
