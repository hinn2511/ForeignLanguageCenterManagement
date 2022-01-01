using System.Collections.Generic;
using System.Windows.Forms;
using TrungTamNgoaiNgu.BUS;
using TrungTamNgoaiNgu.DTO;

namespace TrungTamNgoaiNgu.GUI.GiaoDienDSThiSinh
{
    public partial class Gui_DSThiSinh : Form
    {
        Dto_PhongThi phongThi;
        List<Dto_DSPhongThi> dsthi;
        Bus_DSPhongThi bus = new Bus_DSPhongThi();  

        public Gui_DSThiSinh(Dto_PhongThi pt)
        {
            InitializeComponent();
            phongThi = pt;
            lblTenPhongThi.Text = pt.TenPhongThi;
            LayDanhSachThiSinhThi(phongThi.Id);
        }

        private void LayDanhSachThiSinhThi(int phongThiId)
        {
            dsthi = bus.DanhSachThiSinhTheoPhong(phongThiId);
            dsptGridView.DataSource = dsthi;
            DatTenDanhSach();
        }

        private void DatTenDanhSach()
        {
            dsptGridView.Columns["Id"].Visible = false;
            dsptGridView.Columns["Id_ThiSinh"].Visible = false;
            dsptGridView.Columns["Id_PhongThi"].Visible = false;
            dsptGridView.Columns["DiemNghe"].Visible = false;
            dsptGridView.Columns["DiemDoc"].Visible = false;
            dsptGridView.Columns["DiemNoi"].Visible = false;
            dsptGridView.Columns["DiemViet"].Visible = false;
            dsptGridView.Columns["TenThiSinh"].HeaderText = "Tên thí sinh";
            dsptGridView.Columns["SBD"].HeaderText = "Số báo danh";
            dsptGridView.Columns["SoThuTu"].HeaderText = "Số thứ tự";
        }
    }
}
