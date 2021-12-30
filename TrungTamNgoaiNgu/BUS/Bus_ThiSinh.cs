using System.Collections.Generic;
using System.Linq;
using TrungTamNgoaiNgu.DAL;

namespace TrungTamNgoaiNgu.BUS
{
    public class Bus_ThiSinh
    {
        Dal_ThiSinh dal = new Dal_ThiSinh();

        public List<ThiSinh> LayDanhSachTS()
        {
            return dal.LayDanhSachThiSinh();
        }

        public bool ThemTS(ThiSinh TS)
        {
            return dal.ThemTs(TS);
        }

        public bool XoaTS(int id)
        {
            return dal.XoaTs(id);
        }

        public List<ThiSinh> TimKiemTS(List<ThiSinh> dsTs, string key)
        {
            var res = dsTs.Where(t => t.HoTen.Contains(key)).ToList();
            return res;
        }

        public ThiSinh LayThongTinTS(int id)
        {
            return dal.LayThongTinTS(id);
        }
    }
}
