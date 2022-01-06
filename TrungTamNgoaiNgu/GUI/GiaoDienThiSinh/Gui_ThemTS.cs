using System.Collections.Generic;
using System;
using System.Windows.Forms;
using TrungTamNgoaiNgu.BUS;
using TrungTamNgoaiNgu.DTO;
using System.Text.RegularExpressions;

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
            dtpNgayDangKy.Enabled = false;
           
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
        public static bool IsPhoneNumber(string number)
        {
            return Regex.Match(number, @"^([0-9]{10})$").Success;
        }

        public static bool IsIdCard(string number)
        {
            return Regex.Match(number, @"^([0-9]{9,12})$").Success;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (ktdulieunhapvao())
            {
                if (IsPhoneNumber(txtSdt.Text))
                {
                    if (IsIdCard(txtCmnd.Text))
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
                    else MessageBox.Show("CMND/CCCD là dãy gồm 9 - 12 số", "Thông báo", MessageBoxButtons.OK);
                }
                else MessageBox.Show("Số điện thoại phải là dãy có 10 số", "Thông báo", MessageBoxButtons.OK);
            }
            else MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK);
        }


    }
}
