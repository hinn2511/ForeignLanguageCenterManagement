using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrungTamNgoaiNgu.DAL;
using TrungTamNgoaiNgu.DTO;

namespace TrungTamNgoaiNgu.BUS
{
    public class Bus_ThongKe
    {
        Dal_ThongKe dal_ThongKe = new Dal_ThongKe();
        public List<Dto_ThongKe> LayDanhSachThongKe(string trinhDo)
        {
            return dal_ThongKe.ThongKeTheoTrinhDo(trinhDo);
        }
    }
}
