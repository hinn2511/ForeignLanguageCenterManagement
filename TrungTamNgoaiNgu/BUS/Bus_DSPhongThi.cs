using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrungTamNgoaiNgu.DAL;
using TrungTamNgoaiNgu.DTO;

namespace TrungTamNgoaiNgu.BUS
{
    public class Bus_DSPhongThi
    {
        Dal_PhongThi dal_phongthi = new Dal_PhongThi();

        Dal_DSPhongThi dal_dsphongthi = new Dal_DSPhongThi();

        Dal_KhoaThi dal_khoaThi = new Dal_KhoaThi();

        public List<Dto_KhoaThi> LayDanhSachKhoaThi()
        {
            return dal_khoaThi.DanhSachKhoaThi();
        }

        public List<Dto_PhongThi> LayDanhSachPhongThi(int khoaThiId)
        {
            var dsPhongThi = dal_phongthi.DanhSachPhongThiTheoKhoa(khoaThiId);
            return dsPhongThi.Any() ? dsPhongThi : null;
        }

        public List<Dto_DSPhongThi> DanhSachThiSinhTheoPhong(int phongThiId)
        {
            var dsThi = dal_dsphongthi.DanhSachThiSinhTheoPhong(phongThiId);
            int stt = 1;
            foreach (var item in dsThi)
            {
                item.SoThuTu = stt++;
            }
            return dsThi;
        }

        public List<Dto_DSKetQuaThi> LayKetQua(string type, string key)
        {
            switch (type)
            {
                case "sdt":
                    var kqsdt = dal_dsphongthi.KetQuaTheoSDT(key);
                    return kqsdt.Any() ? kqsdt : null;
                default:
                    var kgten = dal_dsphongthi.KetQuaTheoTen(key);
                    return kgten.Any() ? kgten : null;
            }
        }

        public List<Dto_DSKetQuaThi> TimKiemThiSinh(string type, string key)
        {
            switch (type)
            {
                case "sdt":
                    return dal_dsphongthi.KetQuaTheoSDT(key);
                default:
                    return dal_dsphongthi.KetQuaTheoTen(key);
            }
        }

        public string CapNhatDiem(List<Dto_DSPhongThi> dsdiem)
        {
            foreach (var item in dsdiem)
            {
                if (dal_dsphongthi.CapNhatDanhSachThi(convertToEntity(item)))
                    continue;
                else
                    return "failed";
            }
            return "success";
        }

        public DanhSachPhongThi convertToEntity(Dto_DSPhongThi dto)
        {
            DanhSachPhongThi dspt = new DanhSachPhongThi();
            dspt.Id = dto.Id;
            dspt.SBD = dto.SBD;
            dspt.Id_ThiSinh = dto.Id_ThiSinh;
            dspt.Id_PhongThi = dto.Id_PhongThi;
            dspt.DiemNghe = dto.DiemNghe;
            dspt.DiemNoi = dto.DiemNoi;
            dspt.DiemDoc = dto.DiemDoc;
            dspt.DiemViet = dto.DiemViet;
            return dspt;
        }
    }
}
