using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TrungTamNgoaiNgu.BUS;

namespace TrungTamNgoaiNgu.GUI.GUITS
{
    public partial class GUITS : Form
    {
        private List<ThiSinh> dsTS = new List<ThiSinh>();
        int currentIndex;
        public GUITS()
        {
            InitializeComponent();
            CapNhatDanhSachTS();
            DatTenDauDanhSach();
            currentIndex = -1;
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (currentIndex <0)
                MessageBox.Show("Vui lòng chọn thí sinh cần xóa", "Lỗi", MessageBoxButtons.OK);
            else
            {
                Bus_ThiSinh bus = new Bus_ThiSinh();
                var res = bus.XoaTS(dsTS[currentIndex].Id);
                if (res)
                {
                    MessageBox.Show("Đã xóa thành công", "Xóa thành công", MessageBoxButtons.OK);
                    dsTS.RemoveAt(currentIndex);
                    dataGridViewTS.DataSource = null;
                    dataGridViewTS.DataSource = dsTS;
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Gui_ThemTS themTS = new Gui_ThemTS();
            themTS.ShowDialog();
            CapNhatDanhSachTS();
        }

        private void dataGridViewTS_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == 0) return;

            if (dataGridViewTS.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                currentIndex = e.RowIndex;
            }
        }
    }
}
