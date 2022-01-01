using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using TrungTamNgoaiNgu.BUS;
using TrungTamNgoaiNgu.DTO;
using static TrungTamNgoaiNgu.GUI.Helper;

namespace TrungTamNgoaiNgu.GUI.GiaoDienNhapDiem
{
    public partial class Gui_NhapDiem : Form
    {
        List<Dto_PhongThi> dsPhongThi = new List<Dto_PhongThi>();
        List<Dto_KhoaThi> dsKhoaThi = new List<Dto_KhoaThi>();
        List<Dto_DSPhongThi> dsThi = new List<Dto_DSPhongThi>();

        Bus_DSPhongThi bus = new Bus_DSPhongThi();

        public Gui_NhapDiem()
        {
            InitializeComponent();
            LayDanhSachKhoaThi();
            diemGridView.ReadOnly = true;
            DisableButton();
            
        }

        private void DisableButton()
        {
            btnHoanTat.Enabled = false;
            btnHuy.Enabled = false;
            btnNhapDiem.Enabled = false;
            cbxKhoaThi.Enabled = true;
            cbxPhongThi.Enabled = true;
            diemGridView.ReadOnly = true;
        }

        private void EnableButton()
        {
            btnHoanTat.Enabled = true;
            btnHuy.Enabled = true;
            btnNhapDiem.Enabled = true;
            cbxKhoaThi.Enabled = false;
            cbxPhongThi.Enabled = false;
            diemGridView.ReadOnly = false;
        }

        private void LayDanhSachKhoaThi()
        {
            dsKhoaThi = bus.LayDanhSachKhoaThi();
            
            foreach (var item in dsKhoaThi)
            {
                cbxKhoaThi.Items.Add(item.TenKhoaThi);
            }
        }

        private void LayDanhSachPhongThi(int khoaThiId)
        {
            dsPhongThi = bus.LayDanhSachPhongThi(khoaThiId);
            cbxPhongThi.Items.Clear();
            if (dsPhongThi != null)
            {
                foreach (var item in dsPhongThi)
                {
                    cbxPhongThi.Items.Add(item.TenPhongThi);
                }
            }
        }
        private void LayDanhSachThiSinh(int phongThiId)
        {
            dsThi = bus.DanhSachThiSinhTheoPhong(phongThiId);
            diemGridView.DataSource = dsThi;
            DatTenDanhSach();

        }

        private void DatTenDanhSach()
        {
            diemGridView.Columns["Id"].Visible = false;
            diemGridView.Columns["Id_ThiSinh"].Visible = false;
            diemGridView.Columns["Id_PhongThi"].Visible = false;
            diemGridView.Columns["DiemNghe"].HeaderText = "Điểm nghe";
            diemGridView.Columns["DiemDoc"].HeaderText = "Điểm đọc";
            diemGridView.Columns["DiemNoi"].HeaderText = "Điểm nói";
            diemGridView.Columns["DiemViet"].HeaderText = "Điểm viết";
            diemGridView.Columns["TenThiSinh"].HeaderText = "Tên thí sinh";
            diemGridView.Columns["SBD"].HeaderText = "Số báo danh";
            diemGridView.Columns["SoThuTu"].HeaderText = "Số thứ tự";
            diemGridView.Columns["SoThuTu"].ReadOnly = true;
            diemGridView.Columns["TenThiSinh"].ReadOnly = true;
            diemGridView.Columns["SBD"].ReadOnly = true;
        }


        private void cbxKhoaThi_DropDownClosed(object sender, System.EventArgs e)
        {
            if (cbxKhoaThi.SelectedIndex < 0)
                return;
            LayDanhSachPhongThi(dsKhoaThi[cbxKhoaThi.SelectedIndex].Id);
        }

        private void cbxPhongThi_DropDownClosed(object sender, System.EventArgs e)
        {
            if (cbxKhoaThi.SelectedIndex < 0)
                return;
            if (cbxPhongThi.SelectedIndex < 0)
                return;
            if(dsPhongThi != null)
            {
                LayDanhSachThiSinh(dsPhongThi[cbxKhoaThi.SelectedIndex].Id);
                btnNhapDiem.Enabled = true;
            }
        }
        private void btnNhapDiem_Click(object sender, System.EventArgs e)
        {
            
            EnableButton();
            btnNhapDiem.Enabled = false;
            diemGridView.Columns["SoThuTu"].ReadOnly = true;
            diemGridView.Columns["TenThiSinh"].ReadOnly = true;
            diemGridView.Columns["SBD"].ReadOnly = true;

        }

        private void btnHoanTat_Click(object sender, System.EventArgs e)
        {
            if(bus.CapNhatDiem(dsThi) == "success")
                ShowMessage("Đã cập nhập điểm thành công", "Thành công");
            else
                ShowMessage("Cập nhật điểm thất bại", "Lỗi");
            DisableButton();
            btnNhapDiem.Enabled = true;
            LayDanhSachThiSinh(dsPhongThi[cbxPhongThi.SelectedIndex].Id);
        }

        private void btnHuy_Click(object sender, System.EventArgs e)
        {
            if(ShowConfirmDialog("Bạn có chắc chắn muốn hủy? Mọi dữ liệu đã nhập sẽ bị mất", "Xác nhận"))
            {
                DisableButton();
                btnNhapDiem.Enabled = true;
                LayDanhSachThiSinh(dsPhongThi[cbxPhongThi.SelectedIndex].Id);
            }    
        }

        private void cbxKhoaThi_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            diemGridView.DataSource = null;
            LayDanhSachPhongThi(dsKhoaThi[cbxKhoaThi.SelectedIndex].Id);
            if (dsPhongThi == null)
                DisableButton();
        }

        private void cbxPhongThi_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            LayDanhSachThiSinh(dsPhongThi[cbxPhongThi.SelectedIndex].Id);
        }

        private void diemGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 1 || e.ColumnIndex == 4 || e.ColumnIndex == 5)
                return;
            DataGridViewTextBoxCell cell = diemGridView[e.ColumnIndex, e.RowIndex] as DataGridViewTextBoxCell;
            if (cell != null)
            {
                string temp = e.FormattedValue.ToString();
                if (temp.Contains(","))
                {
                    ShowMessage("Điểm không đúng định dạng. Ví dụ: 7.4, 8.0 ,...", "Lỗi");
                    e.Cancel = true;
                    return;
                }
                float diem;
                if (!float.TryParse(temp, out diem))
                {
                    ShowMessage("Điểm không đúng định dạng. Ví dụ: 7.4, 8.0 ,...", "Lỗi");
                    e.Cancel = true;
                    return;
                }
                diem = float.Parse(temp);
                if (diem < 0)
                {
                    ShowMessage("Điểm không thể nhỏ hơn 0", "Lỗi");
                    e.Cancel = true;
                    return;
                }
                if (diem > 10)
                {
                    ShowMessage("Điểm không thể lớn hơn 10", "Lỗi");
                    e.Cancel = true;
                    return;
                }
            }
            else
            {
                ShowMessage("Điểm không thể bỏ trống", "Lỗi");
                e.Cancel = true;
                return;
            }
        }
    }
}
