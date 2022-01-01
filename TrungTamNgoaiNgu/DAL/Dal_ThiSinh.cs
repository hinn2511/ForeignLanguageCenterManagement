using System;
using System.Collections.Generic;
using System.Linq;
using TrungTamNgoaiNgu.DTO;

namespace TrungTamNgoaiNgu.DAL
{
    internal class Dal_ThiSinh
    {
        QLTTNNDataContext context = new QLTTNNDataContext();

        public List<Dto_ThiSinh> LayDanhSachThiSinh()
        {
            List<Dto_ThiSinh> TS = context.ThiSinhs.Select(ts => new Dto_ThiSinh
            {
                Id = ts.Id,
                HoTen = ts.HoTen,
                GioiTinh = ts.GioiTinh,
                NgaySinh = ts.NgaySinh,
                NoiSinh = ts.NoiSinh,
                CMND = ts.CMND,
                NgayCap = ts.NgayCap,
                NoiCap = ts.NoiCap,
                SDT = ts.SDT,
                Email = ts.Email,
            }).ToList();
            return TS;
        }

        public bool ThemTs(ThiSinh thiSinh)
        {
            context.ThiSinhs.InsertOnSubmit(thiSinh);
            try
            {
                context.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool XoaTs(int TsId)
        {
            var DeleteTS = context.ThiSinhs.FirstOrDefault(ts => ts.Id == TsId);

            if (DeleteTS != null)
            {
                context.ThiSinhs.DeleteOnSubmit(DeleteTS);

                try
                {
                    context.SubmitChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return false;
        }

        public ThiSinh LayThongTinTS(int id)
        {
            var ts = context.ThiSinhs.FirstOrDefault(t => t.Id == id);
            return ts;
        }
    }
}
