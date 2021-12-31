using System;
using System.Windows.Forms;
using TrungTamNgoaiNgu.BUS;
using TrungTamNgoaiNgu.DTO;

namespace TrungTamNgoaiNgu.GUI.GiaoDienDSThiSinh
{
    public partial class Gui_LapDanhSachThiSinh : Form
    {

        Dto_KhoaThi khoaThi;

        public Gui_LapDanhSachThiSinh(Dto_KhoaThi kt)
        {
            InitializeComponent();
            khoaThi = kt;
        }


        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnLapDS_Click(object sender, EventArgs e)
        {
            
            Close();

        }

    }
}
