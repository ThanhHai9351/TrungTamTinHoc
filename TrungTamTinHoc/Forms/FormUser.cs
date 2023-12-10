using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrungTamTinHoc.Models;
using TrungTamTinHoc.UserControls;

namespace TrungTamTinHoc.Forms
{
    public partial class FormUser : Form
    {
        public string mahs = null;
        public FormUser()
        {
            InitializeComponent();
        }

        public FormUser(string id)
        {
            mahs = id;
            InitializeComponent();
        }
        CompanyDB db = new CompanyDB();
        public void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void FormUser_Load(object sender, EventArgs e)
        {
            lbNameNhanVien.Text = db.GetStudentName(mahs);
            HomeUser frm = new HomeUser(mahs);
            addUserControl(frm);
        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormUser_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult exit;
            exit = MessageBox.Show("Bạn có chắc muốn thoát!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (exit == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                Login frm = new Login();
                frm.Show();
                this.Hide();
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            lbNameNhanVien.Text = db.GetStudentName(mahs);
            HomeUser frm = new HomeUser(mahs);
            addUserControl(frm);
        }

        private void btnLop_Click(object sender, EventArgs e)
        {
            ClassUser frm = new ClassUser(mahs);
            addUserControl(frm);
        }

        private void btnCongNo_Click(object sender, EventArgs e)
        {
            CongNoUser frm = new CongNoUser(mahs);
            addUserControl(frm);
        }
    }
}
