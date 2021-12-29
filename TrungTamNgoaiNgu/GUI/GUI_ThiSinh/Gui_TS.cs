using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TrungTamNgoaiNgu.BUS;

namespace TrungTamNgoaiNgu.GUI.GUITS
{
    public partial class GUITS : Form
    {
        private List<ThiSinh> dsTS = new List<ThiSinh>();
        public GUITS()
        {
            InitializeComponent();
            CapNhatDanhSachTS();
            DatTenDauDanhSach();
        }
        private void DatTenDauDanhSach()
        {
            dataGridViewTS.Columns["Id"].HeaderText = "Mã Thí Sinh";
            dataGridViewTS.Columns["HoTen"].HeaderText = "Họ tên";
            dataGridViewTS.Columns["GioiTinh"].HeaderText = "Giới tính";
            dataGridViewTS.Columns["NgaySinh"].HeaderText = "Ngày Sinh";
            dataGridViewTS.Columns["NoiSinh"].HeaderText = "Nơi sinh";
            dataGridViewTS.Columns["CMND"].HeaderText = "CMND";
            dataGridViewTS.Columns["NgayCap"].HeaderText = "Ngày cấp";
            dataGridViewTS.Columns["NoiCap"].HeaderText = "Nơi cấp";
            dataGridViewTS.Columns["SDT"].HeaderText = "SDT";
            dataGridViewTS.Columns["Email"].HeaderText = "Email";
        }

        private void CapNhatDanhSachTS()
        {
            Bus_ThiSinh bus = new Bus_ThiSinh();
            dsTS = bus.LayDanhSachTS();
            dataGridViewTS.DataSource = dsTS;
        }

        private void btnChiTiet_Click(object sender, EventArgs e)
        {

        }
    }
}
