using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrungTamTinHoc.UserControls;

namespace TrungTamTinHoc.Forms
{
    public partial class frmHomeAdmin : Form
    {
        public frmHomeAdmin()
        {
            InitializeComponent();
        }

        public void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void panelMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmHomeAdmin_Load(object sender, EventArgs e)
        {
            hideSubMenu();
            HomePage frm = new HomePage();
            addUserControl(frm);
        }

        private void customizeDesing()
        {
            panelStudent.Visible = false;
            panelClass.Visible = false;
            panelTeacher.Visible = false;
        }

        private void hideSubMenu()
        {
            if (panelStudent.Visible == true)
            {
                panelStudent.Visible = false;
            }
            if (panelClass.Visible == true)
            {
                panelClass.Visible = false;
            }
            if (panelTeacher.Visible == true)
            {
                panelTeacher.Visible = false;
            }
        }

        private void showSubMenu(Panel subMenu)
        {
            if(subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }

        private void btnHocSinh_Click(object sender, EventArgs e)
        {
            showSubMenu(panelStudent);
        }

        private void btnGV_Click(object sender, EventArgs e)
        {
            showSubMenu(panelTeacher);
        }

        private void btnLop_Click(object sender, EventArgs e)
        {
            showSubMenu(panelClass);
        }

        private void panelContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmHomeAdmin_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddHS_Click(object sender, EventArgs e)
        {
            CreateHocSinh frm = new CreateHocSinh();
            addUserControl(frm);
        }

        private void btnEditDeleteHS_Click(object sender, EventArgs e)
        {
            EditDeleteHocSinh frm = new EditDeleteHocSinh();
            addUserControl(frm);
        }

        private void btnThemGV_Click(object sender, EventArgs e)
        {
            CreateGV frm = new CreateGV();
            addUserControl(frm);
        }

        private void btnEditDeleteGV_Click(object sender, EventArgs e)
        {
            EditDeleteGV frm = new EditDeleteGV();
            addUserControl(frm);
        }

        private void btnAddLop_Click(object sender, EventArgs e)
        {
            CreateLop frm = new CreateLop();
            addUserControl(frm);
        }

        private void btnEditDeleteLop_Click(object sender, EventArgs e)
        {
            EditDeleteLop frm = new EditDeleteLop();
            addUserControl(frm);
        }

        private void btnThongTinLop_Click(object sender, EventArgs e)
        {
            ThongTinLop frm = new ThongTinLop();
            addUserControl(frm);
        }

        private void btnLichHoc_Click(object sender, EventArgs e)
        {
            LichHoc frm = new LichHoc();
            addUserControl(frm);
        }

        private void btnSupport_Click(object sender, EventArgs e)
        {
            Support frm = new Support();
            addUserControl(frm);
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            Report frm = new Report();
            addUserControl(frm);
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            HomePage frm = new HomePage();
            addUserControl(frm);
        }

        private void btnQLLop_Click(object sender, EventArgs e)
        {

        }
    }
}
