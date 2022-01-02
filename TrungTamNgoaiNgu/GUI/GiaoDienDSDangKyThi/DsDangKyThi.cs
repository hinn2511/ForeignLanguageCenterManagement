using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrungTamNgoaiNgu.BUS;
using TrungTamNgoaiNgu.DTO;

namespace TrungTamNgoaiNgu.GUI.GiaoDienDSDangKyThi
{
    public partial class DsDangKyThi : Form
    {
        Bus_KhoaThi busKhoaThi = new Bus_KhoaThi();
        List<Dto_KhoaThi> dsKhoaThi = new List<Dto_KhoaThi>();
        Bus_DSDangKyThi bus = new Bus_DSDangKyThi();
        List<Dto_DSDangKyThi> dsDkThi = new List<Dto_DSDangKyThi>();
        public DsDangKyThi()
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
            dataGridView.Columns["id_khoathi"].Visible = false;
            dataGridView.Columns["id_thisinh"].Visible = false;
            dataGridView.Columns["cmnd"].HeaderText = "CMND";
            dataGridView.Columns["hoten"].HeaderText = "Họ tên thí sinh";
            dataGridView.Columns["ngaydk"].HeaderText = "Ngày đăng ký";
            dataGridView.Columns["trinhdo"].HeaderText = "Trình độ";

        }
        private void LayDanhSachDkThi (int idKhoaThi)
        {
            dsDkThi = bus.LayDsDangKy(idKhoaThi);
            dataGridView.DataSource = dsDkThi;
            DatTenDanhSach();
        }

        private void cbx_Khoathi_DropDownClosed(object sender, EventArgs e)
        {
            if (cbx_Khoathi.SelectedIndex > -1)
                LayDanhSachDkThi(dsKhoaThi[cbx_Khoathi.SelectedIndex].Id);
        }
    }
}
