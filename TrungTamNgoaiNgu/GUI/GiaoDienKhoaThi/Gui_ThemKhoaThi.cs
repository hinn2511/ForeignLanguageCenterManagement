using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TrungTamNgoaiNgu.BUS;
using TrungTamNgoaiNgu.DTO;
using static TrungTamNgoaiNgu.GUI.Helper;

namespace TrungTamNgoaiNgu.GUI.GiaoDienKhoaThi
{
    public partial class Gui_ThemKhoaThi : Form
    {
        Bus_KhoaThi bus = new Bus_KhoaThi();

        public Gui_ThemKhoaThi()
        {
            InitializeComponent();
            dtNgayThi.Format = DateTimePickerFormat.Custom;
            dtNgayThi.CustomFormat = "dd/MM/yyyy";
            dtNgayThi.MinDate = DateTime.Now;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Dto_KhoaThi khoaThiMoi = new Dto_KhoaThi();
            khoaThiMoi.TenKhoaThi = txtTenKhoaThi.Text;
            khoaThiMoi.NgayThi = dtNgayThi.Value;
            switch (bus.ThemKhoaThi(khoaThiMoi))
            {
                case "nullerror":
                    ShowMessage("Vui lòng điền đầy đủ thông tin", "Lỗi");
                    break;
                case "dateerror":
                    ShowMessage("Ngày thi không hợp lệ", "Lỗi");
                    break;
                case "success":
                    ShowMessage("Thêm khóa thi thành công", "Thành công");
                    break;
                default:
                    ShowMessage("Thêm khóa thi thất bại", "Thất bại");
                    break;
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

    }
}
