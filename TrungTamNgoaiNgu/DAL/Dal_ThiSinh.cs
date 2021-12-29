using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrungTamNgoaiNgu.DAL
{
    internal class Dal_ThiSinh
    {
        QLTTNNDataContext context = new QLTTNNDataContext();

        public List<ThiSinh> LayDanhSachThiSinh()
        {
            List<ThiSinh> TS = context.ThiSinhs.Select(ts => ts).ToList();
            return TS;
        }
    }
}
