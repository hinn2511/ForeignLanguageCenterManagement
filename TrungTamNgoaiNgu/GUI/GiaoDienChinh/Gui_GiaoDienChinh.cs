using FontAwesome.Sharp;
using System;
using System.Drawing;
using System.Windows.Forms;
using TrungTamNgoaiNgu.GUI.GiaoDienDSThiSinh;
using TrungTamNgoaiNgu.GUI.GiaoDienKhoaThi;
using TrungTamNgoaiNgu.GUI.GiaoDienNhapDiem;
using TrungTamNgoaiNgu.GUI.GiaoDienPhongThi;
using TrungTamNgoaiNgu.GUI.GiaoDienThiSinh;
using TrungTamNgoaiNgu.GUI.GiaoDienDSDangKyThi;

namespace TrungTamNgoaiNgu.GUI.GiaoDienChinh
{
    public partial class Gui_GiaoDienChinh : Form
    {
        public IconButton currentBtn;
        public Panel leftBorderBtn;
        public Form currentChildForm;
        public Gui_GiaoDienChinh()
        {
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 70);
            panelMenu.Controls.Add(leftBorderBtn);
            Reset();
            OpenChildForm(new Gui_KhoaThi());
            lblTitleChildForm.Text = "KHÓA THI";

        }

        private void ActivateButton(object senderBtn)
        {
            if (senderBtn != null)
            {
                DisableButton();
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.DarkGray;
                currentBtn.ForeColor = Color.White;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = Color.White;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                leftBorderBtn.BackColor = Color.White;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
                //               iconCurrentChildForm.IconChar = currentBtn.IconChar;
            }
        }

        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.Transparent;
                currentBtn.ForeColor = Color.Black;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.White;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        private void Reset()
        {
            DisableButton();
            leftBorderBtn.Visible = false;
            //OpenChildForm(new Gui_TrangChu());
            //           iconCurrentChildForm.IconChar = IconChar.Home;
            lblTitleChildForm.Text = "TRANG CHỦ";
        }
        private void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelForm.Controls.Add(childForm);
            panelForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void btnNhapDiem_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new Gui_NhapDiem());
            lblTitleChildForm.Text = "NHẬP ĐIỂM";
        }

        private void btnThiSinh_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new GUITS());
            lblTitleChildForm.Text = "THÍ SINH";

        }

        private void btnKhoaThi_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new Gui_KhoaThi());
            lblTitleChildForm.Text = "KHÓA THI";
        }

        private void btnPhongThi_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new Gui_PhongThi());
            lblTitleChildForm.Text = "PHÒNG THI";
        }

        //private void btnTraCuu_Click(object sender, EventArgs e)
        {
            //ActivateButton(sender);
            //OpenChildForm(new Gui_DSKetQua());
            //lblTitleChildForm.Text = "TRA CỨU KẾT QUẢ";
        //}



        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
            
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            //OpenChildForm(new Gui_ThongKe());
            lblTitleChildForm.Text = "THỐNG KÊ";
        }

        private void btnDsTheoKhoa_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new DsDangKyThi());
            lblTitleChildForm.Text = "Danh sách đăng ký thi";
        }
    }
}
