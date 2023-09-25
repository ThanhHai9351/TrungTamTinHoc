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

namespace TrungTamTinHoc
{
    public partial class Trangchu : Form
    {
        public Trangchu()
        {
            InitializeComponent();
        }

        private void Trangchu_Load(object sender, EventArgs e)
        {
            Home home = new Home();
            addUserControl(home);
        }

        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(userControl);
            userControl.BringToFront();
        }

        
        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            if(btnTrangChu.BackColor== Color.LightSalmon)
            {
                btnTrangChu.BackColor = Color.LightCoral;
                btnQLHV.BackColor = Color.LightSalmon;
                btnQLKhoaHoc.BackColor = Color.LightSalmon;
                btnQLGiaoVien.BackColor = Color.LightSalmon;
                btnLichHoc.BackColor = Color.LightSalmon;
                btnSupport.BackColor = Color.LightSalmon;
            }
            Home home = new Home();
            addUserControl(home);
        }

        private void btnQLHV_Click(object sender, EventArgs e)
        {
            if (btnQLHV.BackColor == Color.LightSalmon)
            {
                btnQLHV.BackColor = Color.LightCoral;
                btnTrangChu.BackColor = Color.LightSalmon;
                btnQLGiaoVien.BackColor  = Color.LightSalmon; 
                btnQLKhoaHoc.BackColor  = Color.LightSalmon;
                btnLichHoc.BackColor  = Color.LightSalmon;
                btnSupport.BackColor  = Color.LightSalmon;
            }
          
            QLHocVien qlhv = new QLHocVien();
            addUserControl(qlhv);
        }

        private void btnQLGiaoVien_Click(object sender, EventArgs e)
        {
            if (btnQLGiaoVien.BackColor == Color.LightSalmon)
            {
                btnQLHV.BackColor = Color.LightSalmon;
                btnTrangChu.BackColor = Color.LightSalmon;
                btnQLGiaoVien.BackColor = Color.LightCoral;
                btnQLKhoaHoc.BackColor = Color.LightSalmon;
                btnLichHoc.BackColor = Color.LightSalmon;
                btnSupport.BackColor = Color.LightSalmon;
            }

            QLGV gv = new QLGV();
            addUserControl(gv);
        }

        private void btnQLKhoaHoc_Click(object sender, EventArgs e)
        {
            if (btnQLKhoaHoc.BackColor == Color.LightSalmon)
            {
                btnQLHV.BackColor = Color.LightSalmon;
                btnTrangChu.BackColor = Color.LightSalmon;
                btnQLGiaoVien.BackColor = Color.LightSalmon;
                btnQLKhoaHoc.BackColor = Color.LightCoral;
                btnLichHoc.BackColor = Color.LightSalmon;
                btnSupport.BackColor = Color.LightSalmon;

                QLKH kh = new QLKH();
                addUserControl(kh);
            }
        }

        private void btnLichHoc_Click(object sender, EventArgs e)
        {
            if (btnLichHoc.BackColor == Color.LightSalmon)
            {
                btnQLHV.BackColor = Color.LightSalmon;
                btnTrangChu.BackColor = Color.LightSalmon;
                btnQLGiaoVien.BackColor = Color.LightSalmon;
                btnQLKhoaHoc.BackColor = Color.LightSalmon;
                btnLichHoc.BackColor = Color.LightCoral;
                btnSupport.BackColor = Color.LightSalmon;
            }

            LichHoc lh = new LichHoc();
            addUserControl(lh);
        }

        private void btnSupport_Click(object sender, EventArgs e)
        {
            if (btnSupport.BackColor == Color.LightSalmon)
            {
                btnQLHV.BackColor = Color.LightSalmon;
                btnTrangChu.BackColor = Color.LightSalmon;
                btnQLGiaoVien.BackColor = Color.LightSalmon;
                btnQLKhoaHoc.BackColor = Color.LightSalmon;
                btnLichHoc.BackColor = Color.LightSalmon;
                btnSupport.BackColor = Color.LightCoral;
            }
            Support sp = new Support();
            addUserControl(sp);
        }

        private void panelContainer_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
