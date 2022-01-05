using System.Collections.Generic;
using System;
using System.Windows.Forms;
using TrungTamNgoaiNgu.BUS;
using TrungTamNgoaiNgu.DTO;

namespace TrungTamNgoaiNgu.GUI
{
    public partial class Gui_ThemTS : Form
    {
        Bus_KhoaThi busKhoaThi = new Bus_KhoaThi();
        List<Dto_KhoaThi> dsKhoaThi = new List<Dto_KhoaThi>();
        Dto_ThiSinh ts = new Dto_ThiSinh();
        Bus_ThiSinh bus_ts = new Bus_ThiSinh();
        Dto_PhieuDangKy pdk = new Dto_PhieuDangKy();
        Bus_PhieuDangKy bus_pdk = new Bus_PhieuDangKy();
        Dto_ThiSinh_PhieuDangKy dto = new Dto_ThiSinh_PhieuDangKy();
        DateTime now = DateTime.Now;

        public Gui_ThemTS()
        {
            InitializeComponent();
            dtpNgayDangKy.Text = now.ToShortDateString().ToString();
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

        private bool ThemTS()
        {
           
            ts.HoTen = txtHoTen.Text;
            ts.GioiTinh = cbxGioiTinh.SelectedItem.ToString();
            ts.NgaySinh = NgaySinh.Value;
            ts.NoiSinh = txtNoiSinh.Text;
            ts.CMND = txtCmnd.Text;
            ts.NgayCap = NgayCap.Value;
            ts.NoiCap = txtNoiCap.Text;
            ts.SDT = txtSdt.Text;
            ts.Email = txtEmail.Text;
            if (bus_ts.ThemTS(ts)) return true;
            return false;
        }

        private bool ThemThongTinDangKy()
        {
            int id = bus_ts.LayThiSinhVuaThem();
            pdk.Id_ThiSinh = bus_ts.LayThiSinhVuaThem();
            pdk.Id_KhoaThi = dsKhoaThi[cbxKhoaThi.SelectedIndex].Id;
            pdk.TrinhDo = cbxTrinhDo.SelectedItem.ToString();
            pdk.NgayDangKy = now;
            if (bus_pdk.DKDuThi(pdk)) return true;
            return false;
        }

        private bool ktdulieunhapvao()
        {
            if (
                !String.IsNullOrEmpty(txtHoTen.Text) &&
                !String.IsNullOrEmpty(txtCmnd.Text) &&
                !String.IsNullOrEmpty(txtEmail.Text) &&
                !String.IsNullOrEmpty(txtNoiSinh.Text) &&
                !String.IsNullOrEmpty(txtNoiCap.Text) &&
                !String.IsNullOrEmpty(txtSdt.Text) &&
                (cbxGioiTinh.SelectedIndex != -1) &&
                (cbxKhoaThi.SelectedIndex != -1) &&
                (cbxTrinhDo.SelectedIndex != -1)
                ) 
              return true;
            return false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (ktdulieunhapvao())
            {
                dto.HoTen = txtHoTen.Text;
                dto.GioiTinh = cbxGioiTinh.SelectedItem.ToString();
                dto.NgaySinh = NgaySinh.Value;
                dto.NoiSinh = txtNoiSinh.Text;
                dto.CMND = txtCmnd.Text;
                dto.NgayCap = NgayCap.Value;
                dto.NoiCap = txtNoiCap.Text;
                dto.SDT = txtSdt.Text;
                dto.Email = txtEmail.Text;
                dto.Id_KhoaThi = dsKhoaThi[cbxKhoaThi.SelectedIndex].Id;
                dto.TrinhDo = cbxTrinhDo.SelectedItem.ToString();
                dto.NgayDangKy = now;

                if (bus_ts.ThemTS(dto))
                {
                    if (bus_pdk.DKDuThi(dto))
                        MessageBox.Show("Đã đăng ký thành công", "Thành công", MessageBoxButtons.OK);
                    else MessageBox.Show("Đã có lỗi xảy ra ", "Thất bại", MessageBoxButtons.OK);
                }
                else MessageBox.Show("Đã có lỗi xảy ra", "Thất bại", MessageBoxButtons.OK);
            }
            else MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK);
        }


    }
}
