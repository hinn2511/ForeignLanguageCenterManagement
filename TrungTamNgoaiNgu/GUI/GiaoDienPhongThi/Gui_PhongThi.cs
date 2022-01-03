using System.Collections.Generic;
using System.Windows.Forms;
using TrungTamNgoaiNgu.BUS;
using TrungTamNgoaiNgu.DTO;
using TrungTamNgoaiNgu.GUI.GiaoDienDSThiSinh;
using static TrungTamNgoaiNgu.GUI.Helper;

namespace TrungTamNgoaiNgu.GUI.GiaoDienPhongThi
{
    public partial class Gui_PhongThi : Form
    {
        List<Dto_PhongThi> dsPhongThi = new List<Dto_PhongThi>();
        List<Dto_KhoaThi> dsKhoaThi = new List<Dto_KhoaThi>();
        Bus_PhongThi bus = new Bus_PhongThi();
        int currentIndex;

        public Gui_PhongThi()
        {
            InitializeComponent();
            LayDanhSachKhoaThi();
        }

        private void LayDanhSachKhoaThi()
        {
            dsKhoaThi = bus.LayDanhSachKhoaThi();
            foreach(var item in dsKhoaThi)
            {
                cbxKhoaThi.Items.Add(item.TenKhoaThi);
            }    
        }

        private void LayDanhSachPhongThi(int khoaThiId)
        {
            dsPhongThi = bus.LayDanhSachPhongThi(khoaThiId);
            if(dsPhongThi != null)
            {
                phongThiGridView.DataSource = dsPhongThi;
                DatTenDanhSach();
            }
        }

        private void DatTenDanhSach()
        {
            phongThiGridView.Columns["Id"].HeaderText = "Mã phòng thi";
            phongThiGridView.Columns["TenPhongThi"].HeaderText = "Tên phòng thi";
            phongThiGridView.Columns["TrinhDo"].HeaderText = "Trình độ";
            phongThiGridView.Columns["CaThi"].HeaderText = "Ca thi";
            phongThiGridView.Columns["ID_KhoaThi"].Visible = false;
        }

        private void btnThem_Click(object sender, System.EventArgs e)
        {
            if (!ChonKhoaThi())
                return;
            if (bus.DaTaoDanhSachThi(dsKhoaThi[cbxKhoaThi.SelectedIndex].Id))
            {
                ShowMessage("Khóa thi này đã tạo danh sách thi. Không thể tạo thêm phòng thi.", "Lỗi");
                return;
            }
            Gui_ThemPhongThi themPhongThi = new Gui_ThemPhongThi(dsKhoaThi[cbxKhoaThi.SelectedIndex]);
            themPhongThi.ShowDialog();
            LayDanhSachPhongThi(dsKhoaThi[cbxKhoaThi.SelectedIndex].Id);
        }

        private void btnXoa_Click(object sender, System.EventArgs e)
        {
            if (!ChonKhoaThi())
                return;
            if (bus.DaTaoDanhSachThi(dsKhoaThi[cbxKhoaThi.SelectedIndex].Id))
            {
                ShowMessage("Khóa thi này đã tạo danh sách thi. Không thể xóa phòng thi.", "Lỗi");
                return;
            }
            if (currentIndex < 0)
            {
                ShowMessage("Vui lòng chọn phòng thi cần xóa", "Lỗi");
                return;
            }
            if (dsPhongThi == null)
            {
                return;
            }
            switch (bus.XoaPhongThi(dsPhongThi[currentIndex]))
            {
                case "timeerror":
                    ShowMessage("Không thể xóa phòng thi đã kết thúc", "Lỗi");
                    break;
                case "success":
                    ShowMessage("Xóa phòng thi thành công", "Thành công");
                    break;
                default:
                    ShowMessage("Xóa phòng thi thất bại", "Thất bại");
                    break;
            }
            LayDanhSachPhongThi(dsKhoaThi[cbxKhoaThi.SelectedIndex].Id);
        }

        private void khoaThiGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!ChonKhoaThi())
                return;
            if (e.RowIndex < 0)
                return;

            if (phongThiGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                currentIndex = e.RowIndex;
            }
        }

        private void btnTimKiem_Click(object sender, System.EventArgs e)
        {
            if (!ChonKhoaThi())
                return;
            if (dsPhongThi == null)
                return;
            var result = bus.TimKiemPhongThi(dsPhongThi, txtTimKiem.Text);
            phongThiGridView.DataSource = result;
            DatTenDanhSach();
        }

        private void btnLamMoi_Click(object sender, System.EventArgs e)
        {
            if (!ChonKhoaThi())
                return;
            DatTenDanhSach();
            phongThiGridView.DataSource = dsPhongThi;
        }

        private void cbxKhoaThi_DropDownClosed(object sender, System.EventArgs e)
        {
            if (cbxKhoaThi.SelectedIndex > -1)
                LayDanhSachPhongThi(dsKhoaThi[cbxKhoaThi.SelectedIndex].Id);
        }

        private bool ChonKhoaThi()
        {
            if (cbxKhoaThi.SelectedIndex < 0)
            {
                ShowMessage("Vui lòng chọn khóa thi", "Lỗi");
                return false;
            }
            return true;
        }

        private void btnDanhSach_Click(object sender, System.EventArgs e)
        {
            if (!ChonKhoaThi())
                return;
            if (dsPhongThi == null)
            {
                return;
            }
            if (currentIndex < 0)
            {
                ShowMessage("Vui lòng chọn phòng thi cần xem danh sách", "Lỗi");
                return;
            }
            Gui_DSThiSinh dsThiSinhThi = new Gui_DSThiSinh(dsPhongThi[currentIndex]);
            dsThiSinhThi.ShowDialog();
        }

        private void btnLapDS_Click(object sender, System.EventArgs e)
        {
            if (!ChonKhoaThi())
                return;
            if (bus.SoLuongThiSinhDangKy(dsKhoaThi[cbxKhoaThi.SelectedIndex].Id) == 0)
            {
                ShowMessage("Khóa thi chưa có thí sinh đăng ký.", "Lỗi");
                return;
            }
            if (bus.DaTaoDanhSachThi(dsKhoaThi[cbxKhoaThi.SelectedIndex].Id))
            {
                ShowMessage("Khóa thi này đã tạo danh sách thi.", "Lỗi");
                return;
            }
            if (!bus.CoTheTaoDanhSachThi(dsKhoaThi[cbxKhoaThi.SelectedIndex].Id))
            {
                ShowMessage("Số lượng phòng thi không đủ. Vui lòng tạo thêm", "Lỗi");
                return;
            }
            if(ShowConfirmDialog("Bạn có chắc muốn lập danh sách thi? Danh sách phòng thi sau khi sắp xếp sẽ không thể thay đổi.", "Xác nhận"))
            {
                bus.TaoDanhSachThi(dsKhoaThi[cbxKhoaThi.SelectedIndex].Id);
                ShowMessage("Đã xếp lịch thi thành công", "Thành công");
            }
        }

        private void cbxKhoaThi_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            phongThiGridView.DataSource = null;
            if (cbxKhoaThi.SelectedIndex > -1)
                LayDanhSachPhongThi(dsKhoaThi[cbxKhoaThi.SelectedIndex].Id);
        }
    }
}
