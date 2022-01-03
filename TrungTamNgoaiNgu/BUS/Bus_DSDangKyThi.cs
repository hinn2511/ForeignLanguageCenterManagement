using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrungTamNgoaiNgu.DAL;
using TrungTamNgoaiNgu.DTO;
namespace TrungTamNgoaiNgu.BUS
{
    public class Bus_DSDangKyThi
    {
        Dal_DSDangKyThi dal = new Dal_DSDangKyThi();
        public List<Dto_DSDangKyThi> LayDsDangKy(int idKhoaThi)
        {
            return dal.LayDsDangKyThi(idKhoaThi);
        }
    }
}
