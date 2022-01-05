using System.Collections.Generic;
using System.Windows.Forms;
using TrungTamNgoaiNgu.BUS;
using TrungTamNgoaiNgu.DTO;
using static TrungTamNgoaiNgu.GUI.Helper;

namespace TrungTamNgoaiNgu.GUI.GiaoDienDSThiSinh
{
    public partial class Gui_DSKetQua : Form
    {
        List<Dto_KetQuaThi> dsKetQua;
        Bus_DSPhongThi bus = new Bus_DSPhongThi();
        public Gui_DSKetQua()
        {
            InitializeComponent();
            cbxBoLoc.Items.Add("Tên thí sinh");
            cbxBoLoc.Items.Add("Số điện thoại");
        }

        private void DatTenDanhSach()
        {
            ketQuaGridView.Columns["TenKhoaThi"].HeaderText = "Tên khóa thi";
            ketQuaGridView.Columns["TenPhongThi"].HeaderText = "Tên phòng thi";
            ketQuaGridView.Columns["DiemNghe"].HeaderText = "Điểm nghe";
            ketQuaGridView.Columns["DiemDoc"].HeaderText = "Điểm đọc";
            ketQuaGridView.Columns["DiemNoi"].HeaderText = "Điểm nói";
            ketQuaGridView.Columns["DiemViet"].HeaderText = "Điểm viết";
            ketQuaGridView.Columns["TenThiSinh"].HeaderText = "Tên thí sinh";
            ketQuaGridView.Columns["SBD"].HeaderText = "Số báo danh";
        }

        private void btnTimKiem_Click(object sender, System.EventArgs e)
        {
            if (cbxBoLoc.SelectedIndex < 0)
            {
                ShowMessage("Vui lòng chọn bộ lọc.", "Lỗi");
                return;
            }
            if (string.IsNullOrEmpty(txtTimKiem.Text))
            {
                ShowMessage("Vui lòng nhập từ khóa cần tìm kiếm", "Lỗi");
                return;
            }
            if (cbxBoLoc.SelectedIndex == 0)
            {
                
                dsKetQua = bus.LayKetQua("ten", txtTimKiem.Text);
                
            }
            else
            {
                dsKetQua = bus.LayKetQua("sdt", txtTimKiem.Text);
            }
            if (dsKetQua != null)
            {
                ketQuaGridView.DataSource = dsKetQua;
                ketQuaGridView.ReadOnly = true;
                DatTenDanhSach();
            }
            else
                ShowMessage("Không tìm thấy thí sinh.", "Lỗi");
        }
    }
}
