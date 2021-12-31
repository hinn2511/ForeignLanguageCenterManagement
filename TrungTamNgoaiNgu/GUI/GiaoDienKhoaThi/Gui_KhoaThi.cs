using System.Collections.Generic;
using System.Windows.Forms;
using TrungTamNgoaiNgu.BUS;
using TrungTamNgoaiNgu.DTO;
using static TrungTamNgoaiNgu.GUI.Helper;

namespace TrungTamNgoaiNgu.GUI.GiaoDienKhoaThi
{
    public partial class Gui_KhoaThi : Form
    {
        List<Dto_KhoaThi> dsKhoaThi = new List<Dto_KhoaThi>();
        Bus_KhoaThi bus = new Bus_KhoaThi();
        int currentIndex;

        public Gui_KhoaThi()
        {
            InitializeComponent();
            LayDanhSachKhoaThi();
            DatTenDanhSach();
        }

        private void LayDanhSachKhoaThi()
        {
            dsKhoaThi = bus.LayDanhSachKhoaThi();
            khoaThiGridView.DataSource = dsKhoaThi;
            DatTenDanhSach();
        }

        private void DatTenDanhSach()
        {
            khoaThiGridView.Columns["Id"].HeaderText = "Mã khoá thi";
            khoaThiGridView.Columns["TenKhoaThi"].HeaderText = "Tên khóa thi";
            khoaThiGridView.Columns["NgayThi"].HeaderText = "Ngày thi";
            khoaThiGridView.Columns["NgayThi"].DefaultCellStyle.Format = "dd/MM/yyyy";
        }

        private void btnThem_Click(object sender, System.EventArgs e)
        {
            Gui_ThemKhoaThi themKhoaThi = new Gui_ThemKhoaThi();
            themKhoaThi.ShowDialog();
            LayDanhSachKhoaThi();
        }

        private void btnXoa_Click(object sender, System.EventArgs e)
        {
            if (currentIndex < 0)
            {
                ShowMessage("Vui lòng chọn khóa thi cần xóa", "Lỗi");
                return;
            }
            switch (bus.XoaKhoaThi(dsKhoaThi[currentIndex]))
            {
                case "timeerror":
                    ShowMessage("Không thể xóa khóa thi đã kết thúc", "Lỗi");
                    break;
                case "success":
                    ShowMessage("Xóa khóa thi thành công", "Thành công");
                    break;
                default:
                    ShowMessage("Xóa khóa thi thất bại", "Thất bại");
                    break;
            }
            LayDanhSachKhoaThi();
        }

        private void khoaThiGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (khoaThiGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                currentIndex = e.RowIndex;
            }
        }

        private void btnTimKiem_Click(object sender, System.EventArgs e)
        {
            var result = bus.TimKiemKhoaThi(dsKhoaThi, txtTimKiem.Text);
            khoaThiGridView.DataSource = result;
            DatTenDanhSach();
        }

        private void btnLamMoi_Click(object sender, System.EventArgs e)
        {
            DatTenDanhSach();
            khoaThiGridView.DataSource = dsKhoaThi;
        }

    }
}
