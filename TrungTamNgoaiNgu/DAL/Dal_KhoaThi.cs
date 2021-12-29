using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrungTamNgoaiNgu.DTO;

namespace TrungTamNgoaiNgu.DAL
{
    public class Dal_KhoaThi
    {
        QLTTNNDataContext context = new QLTTNNDataContext();

        public List<Dto_KhoaThi> DanhSachKhoaThi()
        {
            var dsKhoaThi = context.KhoaThis.Select(kt => new Dto_KhoaThi
            {
                Id = kt.Id,
                TenKhoaThi = kt.TenKhoaThi,
                NgayThi = kt.NgayThi,
            }).ToList();
            return dsKhoaThi;
        }

        public KhoaThi ChiTietKhoaThi(int id)
        {
            var khoaThi = context.KhoaThis.FirstOrDefault(kt => kt.Id == id);
            return khoaThi;
        }


        public bool ThemKhoaThi(KhoaThi khoaThi)
        {

            context.KhoaThis.InsertOnSubmit(khoaThi);
            try
            {
                context.SubmitChanges();
                return true;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.InnerException);
                return false;
            }
        }


    }
}
