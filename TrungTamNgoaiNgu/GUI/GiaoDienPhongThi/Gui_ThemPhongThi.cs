using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TrungTamNgoaiNgu.BUS;
using TrungTamNgoaiNgu.DTO;
using static TrungTamNgoaiNgu.GUI.Helper;

namespace TrungTamNgoaiNgu.GUI.GiaoDienPhongThi
{
    public partial class Gui_ThemPhongThi : Form
    {
        Bus_PhongThi bus = new Bus_PhongThi();
        Dto_KhoaThi khoaThi;
        Dto_PhongThi PhongThiMoi = new Dto_PhongThi();
        string tenPhongThi;
        public Gui_ThemPhongThi(Dto_KhoaThi kt)
        {
            InitializeComponent();
            khoaThi = kt;
            txtKhoaThi.Text = kt.TenKhoaThi;
            cbxTrinhDo.Items.Add("A2");
            cbxTrinhDo.Items.Add("B1");
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            
            PhongThiMoi.CaThi = txtCaThi.Text;
            PhongThiMoi.TenPhongThi = tenPhongThi;
            PhongThiMoi.ID_KhoaThi = khoaThi.Id;

            switch (bus.ThemPhongThi(PhongThiMoi))
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
            Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void cbxTrinhDo_DropDownClosed(object sender, EventArgs e)
        {
            PhongThiMoi.TrinhDo = cbxTrinhDo.SelectedItem.ToString();
            tenPhongThi = bus.TaoTenPhongThi(khoaThi.Id, PhongThiMoi.TrinhDo);
            txtTenPhongThi.Text = tenPhongThi;
        }
    }
}
