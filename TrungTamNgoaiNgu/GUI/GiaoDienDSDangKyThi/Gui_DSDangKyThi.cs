using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TrungTamNgoaiNgu.BUS;
using TrungTamNgoaiNgu.DTO;

namespace TrungTamNgoaiNgu.GUI.GiaoDienDSDangKyThi
{
    public partial class Gui_DSDangKyThi : Form
    {

        Bus_KhoaThi busKhoaThi = new Bus_KhoaThi();
        List<Dto_KhoaThi> dsKhoaThi = new List<Dto_KhoaThi>();
        Bus_DSDangKyThi bus = new Bus_DSDangKyThi();
        List<Dto_DSDangKyThi> dsDkThi = new List<Dto_DSDangKyThi>();
        public Gui_DSDangKyThi()
        {
            InitializeComponent();
            LayDanhSachKhoaThi();
        }

        private void LayDanhSachKhoaThi()
        {
            dsKhoaThi = busKhoaThi.LayDanhSachKhoaThi();
            foreach (var item in dsKhoaThi)
            {
                cbx_Khoathi.Items.Add(item.TenKhoaThi);
            }
        }
        private void DatTenDanhSach()
        {
            dsDangKyThiGridView.Columns["id_khoathi"].Visible = false;
            dsDangKyThiGridView.Columns["id_thisinh"].Visible = false;
            dsDangKyThiGridView.Columns["cmnd"].HeaderText = "CMND";
            dsDangKyThiGridView.Columns["hoten"].HeaderText = "Họ tên thí sinh";
            dsDangKyThiGridView.Columns["ngaydk"].HeaderText = "Ngày đăng ký";
            dsDangKyThiGridView.Columns["trinhdo"].HeaderText = "Trình độ";

        }
        private void LayDanhSachDkThi(int idKhoaThi)
        {
            dsDkThi = bus.LayDsDangKy(idKhoaThi);
            dsDangKyThiGridView.DataSource = dsDkThi;
            DatTenDanhSach();
        }

        private void cbx_Khoathi_DropDownClosed(object sender, EventArgs e)
        {
             if (cbx_Khoathi.SelectedIndex > -1)
                LayDanhSachDkThi(dsKhoaThi[cbx_Khoathi.SelectedIndex].Id);
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            List<Dto_DSDangKyThi> listTimKiem = new List<Dto_DSDangKyThi>();
            foreach (var item in dsDkThi)
            {
                if ((item.hoten.Contains(txtTimKiem.Text)) || (item.cmnd.Contains(txtTimKiem.Text)) || (item.trinhdo.Contains(txtTimKiem.Text)))
                    listTimKiem.Add(item);

            }
            dsDangKyThiGridView.DataSource = listTimKiem;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
