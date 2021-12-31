using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using TrungTamNgoaiNgu.DTO;

namespace TrungTamNgoaiNgu.DAL
{
    public class Dal_PhongThi
    {
        QLTTNNDataContext context = new QLTTNNDataContext();

        public List<Dto_PhongThi> DanhSachPhongThiTheoKhoa(int khoaThiId)
        {
            var dsPhongThi = context.PhongThis.Where(pt => pt.ID_KhoaThi == khoaThiId).Select(pt => new Dto_PhongThi
            {
                Id = pt.Id,
                TenPhongThi = pt.TenPhongThi,
                CaThi = pt.CaThi,
                TrinhDo = pt.TrinhDo,
                ID_KhoaThi = pt.ID_KhoaThi,
            }).ToList();
            return dsPhongThi;
        }

        public int SoLuongPhongThiTheoKhoa(int khoaThiId)
        {
            var sl = context.PhongThis.Where(pt => pt.ID_KhoaThi == khoaThiId).Count();
            return sl;
        }

        public PhongThi ChiTietPhongThi(int id)
        {
            var PhongThi = context.PhongThis.FirstOrDefault(pt => pt.Id == id);
            return PhongThi;
        }

        public bool ThemPhongThi(PhongThi PhongThi)
        {

            context.PhongThis.InsertOnSubmit(PhongThi);
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

        public bool XoaPhongThi(int id)
        {
            var pt = context.PhongThis.FirstOrDefault(t => t.Id == id);

            if (pt != null)
            {
                context.PhongThis.DeleteOnSubmit(pt);

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
            return false;

        }

    }
}
