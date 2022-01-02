using System.Collections.Generic;
using System;
using System.Windows.Forms;
using TrungTamNgoaiNgu.BUS;
using TrungTamNgoaiNgu.DTO;

namespace TrungTamNgoaiNgu.GUI
{
    public partial class Gui_DKThi : Form
    {
        Bus_KhoaThi busKhoaThi = new Bus_KhoaThi();
        List<Dto_KhoaThi> dsKhoaThi = new List<Dto_KhoaThi>();
        List<ThiSinh> dsThiSinh = new List<ThiSinh>();
        string tenTs;
        int id_Ts;

        public Gui_DKThi()
        {
            InitializeComponent();
            LayDanhSachKhoaThi();
        }

        public Gui_DKThi(string name,int id)
        {
            InitializeComponent();
            id_Ts = id;
            tenTs = name;
            txtHoTen.Text = name;
            LayDanhSachKhoaThi();
        }

        private void LayDanhSachKhoaThi()
        {
            dsKhoaThi = busKhoaThi.LayDanhSachKhoaThi();
            foreach (var item in dsKhoaThi)
            {
                cbxKhoaThi.Items.Add(item.TenKhoaThi);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Bus_PhieuDangKy bus = new Bus_PhieuDangKy();
            Dto_PhieuDangKy pDkMoi = new Dto_PhieuDangKy();
            pDkMoi.Id_ThiSinh = id_Ts;
            pDkMoi.Id_KhoaThi = dsKhoaThi[cbxKhoaThi.SelectedIndex].Id;
            pDkMoi.TrinhDo = cbxTrinhDo.SelectedItem.ToString();
            pDkMoi.NgayDangKy = txtNgaydDk.Value;
            if (bus.DKDuThi(pDkMoi))
            {
                MessageBox.Show("Đã đăng ký thành công", "Thành công", MessageBoxButtons.OK);
            }
            else
                MessageBox.Show("Đã có lỗi xảy ra", "Thất bại", MessageBoxButtons.OK);
            Close();
        }

    }
}
