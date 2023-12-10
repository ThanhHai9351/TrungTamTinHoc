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
using System.Data.SqlClient;

namespace TrungTamTinHoc.Forms
{
    public partial class DangKyHocPhan : Form
    {
        SqlConnection connection = null;
        public string mahs = null;
        CompanyDB db = new CompanyDB();
        public DangKyHocPhan()
        {
            InitializeComponent();
        }

        public DangKyHocPhan(string id)
        {
            mahs = id;
            InitializeComponent();
        }

        private void DangKyHocPhan_Load(object sender, EventArgs e)
        {
            List<Classrooms> clss = db.GetClassrooms();
            foreach(var item in clss)
            {
                cboClass.Items.Add(item.ClassromName);
            }    
        }

        private void cboClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            Classrooms clss = db.GetClassrooms().Where(row => row.ClassromName.TrimEnd() == cboClass.Text.TrimEnd()).FirstOrDefault();
            txtTeacher.Text = db.getTeacherName(clss.TeacherID);
            txtMoney.Text = clss.AmountOfMoney + "";
        }

        private void txtId_Leave(object sender, EventArgs e)
        {
            if(db.checkIDPayments(txtId.Text.TrimEnd()))
            {
                MessageBox.Show("Mã này đã tồn tại!");
            }    
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            int state = 0;
            if(connection == null)
            {
                connection = new SqlConnection(db.strcon);
            }
            if(connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into MANAGERCLASS values(@mahs,@malop,@magv)";
            cmd.Connection = connection;

            cmd.Parameters.Add("@mahs", SqlDbType.Char).Value = mahs.TrimEnd();
            cmd.Parameters.Add("@malop", SqlDbType.Char).Value = db.getClassroomID(cboClass.Text.TrimEnd());
            cmd.Parameters.Add("@magv", SqlDbType.Char).Value = db.GetTeacherID(txtTeacher.Text.TrimEnd());

            int ret = cmd.ExecuteNonQuery();
            if(ret>0)
            {
                state = 1;
            }
            else
            {
                MessageBox.Show("Error!!!!", "Message", MessageBoxButtons.RetryCancel);
            } 
            if(state == 1)
            {
                SqlCommand cmd1 = new SqlCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "insert into PAYMENTS (PaymentsID,StudentID,ClassroomId,AmountOfMoney,Active) values(@id,@mahs,@malop,@money,'No')";
                cmd1.Connection = connection;

                cmd1.Parameters.Add("@id", SqlDbType.Char).Value = txtId.Text.TrimEnd();
                cmd1.Parameters.Add("@mahs", SqlDbType.Char).Value = mahs.TrimEnd();
                cmd1.Parameters.Add("@malop", SqlDbType.Char).Value = db.getClassroomID(cboClass.Text.TrimEnd());
                cmd1.Parameters.Add("@money", SqlDbType.Int).Value = int.Parse(txtMoney.Text);

                int ret1 = cmd1.ExecuteNonQuery();
                if (ret1 > 0)
                {
                    MessageBox.Show("Đăng ký thành công!");
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Error!!!!", "Message", MessageBoxButtons.RetryCancel);
                }
            }    
        }
    }
}
