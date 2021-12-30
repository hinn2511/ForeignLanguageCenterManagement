using System;
using System.Windows.Forms;
using TrungTamNgoaiNgu.BUS;
using TrungTamNgoaiNgu.DTO;

namespace TrungTamNgoaiNgu.GUI
{
    public partial class Gui_ThemTS : Form
    {


        public Gui_ThemTS()
        {
            InitializeComponent();
        }


        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Dto_ThiSinh ts = new Dto_ThiSinh();
            Bus_ThiSinh bus = new Bus_ThiSinh();
            ts.HoTen = txtHoTen.Text;
            ts.GioiTinh = cbxGioiTinh.SelectedItem.ToString();
            ts.NgaySinh = NgaySinh.Value;
            ts.NoiSinh = txtNoiSinh.Text;
            ts.CMND = txtCmnd.Text;
            ts.NgayCap = NgayCap.Value;
            ts.NoiCap = txtNoiCap.Text;         
            ts.SDT = txtSdt.Text;
            ts.Email = txtEmail.Text;
            if (bus.ThemTS(ts))
            {
                MessageBox.Show("Đã thí sinh thành công", "Thành công", MessageBoxButtons.OK);
            }
            else
                MessageBox.Show("Đã có lỗi xảy ra", "Thất bại", MessageBoxButtons.OK);
            Close();

        }
    }
}
