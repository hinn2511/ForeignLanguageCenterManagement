using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrungTamNgoaiNgu.DTO;

namespace TrungTamNgoaiNgu.DAL
{

    public class Dal_ThongKe
    {
        QLTTNNDataContext context = new QLTTNNDataContext();

        public List<Dto_ThongKe> ThongKeTheoTrinhDo(string trinhDo)
        {
            var tk = context.KhoaThis.Select(kt => new Dto_ThongKe
            {
                TenKhoaThi = kt.TenKhoaThi,
                SoLuongPhongThi = context.PhongThis.Where(pt => pt.ID_KhoaThi == kt.Id && pt.TrinhDo.Equals(trinhDo)).Count(),
                SoLuongThiSinh = context.PhieuDangKies.Where(pdk => pdk.Id_KhoaThi == kt.Id &&pdk.TrinhDo.Equals(trinhDo)).Count()
            }).ToList();
            return tk;
        }
    }
}
