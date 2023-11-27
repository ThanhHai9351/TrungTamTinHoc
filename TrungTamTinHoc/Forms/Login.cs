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
using TrungTamTinHoc.Forms;

namespace TrungTamTinHoc
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult exit;
            exit = MessageBox.Show("Bạn có chắc muốn thoát!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(exit == DialogResult.No)
            {
                e.Cancel = true;
            }    
        }

        public bool isAccountStudent(string tk, string mk)
        {
            CompanyDB db = new CompanyDB();
            List<Account> accounts = db.GetAccounts();
            foreach (var item in accounts)
            {
                if (item.StudentID.TrimEnd() == tk.TrimEnd() && item.Pass.TrimEnd() == mk.TrimEnd())
                {
                    return true; 
                }
            }
            return false;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            int status = 0;
            CompanyDB db = new CompanyDB();
            if(cb_isHS.Checked)
            {
                List<Account> accounts = db.GetAccounts();
                foreach(var item in accounts)
                {
                    if(isAccountStudent(txtUser.Text.TrimEnd(),txtPass.Text.TrimEnd()))
                    {
                        status = 1;
                    }
                }
                if (status == 0)
                {
                    FormUser frm = new FormUser();
                    frm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu!");
                }
            }
            else
            {
                if (txtUser.Text.TrimEnd() == "admin" && txtPass.Text.TrimEnd() == "123")
                {
                    frmHomeAdmin frm = new frmHomeAdmin();
                    frm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu!");
                }
            }  
        }

        private void txtUser_Leave(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (txtUser.Text == "")
            {
                this.errorProvider1.SetError(ctr, "Bạn không được để trống trường này!");
            }
            else
            {
                this.errorProvider1.Clear();
            }
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (txtPass.Text == "")
            {
                this.errorProvider1.SetError(ctr, "Bạn không được để trống trường này!");
            }
            else
            {
                this.errorProvider1.Clear();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
