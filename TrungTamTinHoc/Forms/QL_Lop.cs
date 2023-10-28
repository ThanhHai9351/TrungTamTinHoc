using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using TrungTamTinHoc.Models;

namespace TrungTamTinHoc.Forms
{
    public partial class QL_Lop : Form
    {
        public string ClassID = "";
     
        public QL_Lop(string malop)
        {
            ClassID = malop;
            InitializeComponent();
        }

        SqlConnection connection = null;
        private void QL_Lop_Load(object sender, EventArgs e)
        {
            CompanyDB db = new CompanyDB();
            this.Text = db.getClassroomName(ClassID);
            List<Models.ManagerClass> managerClasses = db.GetManagerClasses();
            List<string> mahs = new List<string>();
            foreach (var item in managerClasses)
            {
                if (ClassID == item.ClassroomID)
                {
                    mahs.Add(item.StudentID);
                }
            }
            if (connection == null)
            {
                connection = new SqlConnection(db.strcon);
            }
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            lv_Student.Items.Clear();
            foreach (var i in mahs)
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "Select * from Student Where StudentID = @ma";
                command.Connection = connection;

                command.Parameters.Add("@ma", SqlDbType.Char).Value = i;

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    ListViewItem item = new ListViewItem(reader.GetString(0));
                    item.SubItems.Add(reader.GetString(1));
                    item.SubItems.Add(reader.GetString(2));
                    item.SubItems.Add(db.getTeacherName(reader.GetString(3)));
                    item.SubItems.Add(reader.GetString(4));
                    item.SubItems.Add(reader.GetDateTime(5).ToString());
                    lv_Student.Items.Add(item);
                }
                reader.Close();
            }
        }

        private void lv_Student_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.DeepSkyBlue, e.Bounds); // Đặt màu nền cho header
            TextRenderer.DrawText(e.Graphics, e.Header.Text, e.Font, e.Bounds, Color.Black); // Vẽ văn bản
        }

        private void lv_Student_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            CompanyDB db = new CompanyDB();
            this.Text = db.getClassroomName(ClassID);
            List<Models.ManagerClass> managerClasses = db.GetManagerClasses();
            List<string> mahs = new List<string>();
            foreach (var item in managerClasses)
            {
                if (ClassID == item.ClassroomID)
                {
                    mahs.Add(item.StudentID);
                }
            }
            if (connection == null)
            {
                connection = new SqlConnection(db.strcon);
            }
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            lv_Student.Items.Clear();
            foreach (var i in mahs)
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "Select * from Student Where StudentID = @ma";
                command.Connection = connection;

                command.Parameters.Add("@ma", SqlDbType.Char).Value = i;

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    ListViewItem item = new ListViewItem(reader.GetString(0));
                    item.SubItems.Add(reader.GetString(1));
                    item.SubItems.Add(reader.GetString(2));
                    item.SubItems.Add(db.getTeacherName(reader.GetString(3)));
                    item.SubItems.Add(reader.GetString(4));
                    item.SubItems.Add(reader.GetDateTime(5).ToString());
                    lv_Student.Items.Add(item);
                }
                reader.Close();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lv_Student_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lv_Student.SelectedItems.Count>0)
            {
                txtId.Text = lv_Student.SelectedItems[0].SubItems[0].Text;
                txtFirstName.Text = lv_Student.SelectedItems[0].SubItems[1].Text;
                txtLastName.Text = lv_Student.SelectedItems[0].SubItems[2].Text;
            }
        }

        private void txtId_Leave(object sender, EventArgs e)
        {
            CompanyDB db = new CompanyDB();
            Student student = db.GetStudents().Where(row => row.StudentID.TrimEnd() == txtId.Text).FirstOrDefault();
            if(student == null)
            {
                MessageBox.Show("Không có học sinh này!");
            }
            else
            {
                txtFirstName.Text = student.FirstName;
                txtLastName.Text = student.LastName;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn muốn xóa " + txtFirstName.Text.TrimEnd() + " " + txtLastName.Text.TrimEnd(), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CompanyDB db = new CompanyDB();
                if (connection == null)
                {
                    connection = new SqlConnection(db.strcon);
                }
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "Delete MANNAGERCLASS where StudentID = @ma";
                command.Connection = connection;

                command.Parameters.Add("@ma", SqlDbType.Char).Value = txtId.Text.TrimEnd();

                int ret = command.ExecuteNonQuery();
                if (ret > 0)
                {
                    MessageBox.Show("Xóa thành công!");
                    txtId.Text = "";
                    txtFirstName.Text = "";
                    txtLastName.Text = "";
                }
                else
                {
                    MessageBox.Show("Xóa thất bại!");
                }
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            CompanyDB db = new CompanyDB();
            ManagerClass manager = db.GetManagerClasses().Where(row => row.ClassroomID == ClassID).FirstOrDefault();
            if (connection == null)
            {
                connection = new SqlConnection(db.strcon);
            }
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "Insert into MANAGERCLASS values (@mahs,@malop,@magv)";
            command.Connection = connection;

            command.Parameters.Add("@mahs", SqlDbType.Char).Value = txtId.Text.TrimEnd();
            command.Parameters.Add("@malop", SqlDbType.Char).Value = ClassID.TrimEnd();
            command.Parameters.Add("@magv", SqlDbType.Char).Value = manager.TeacherID.TrimEnd() ;

            int ret = command.ExecuteNonQuery();
            if (ret > 0)
            {
                MessageBox.Show("Thêm thành công!");
                txtId.Text = "";
                txtFirstName.Text = "";
                txtLastName.Text = "";
            }
            else
            {
                MessageBox.Show("Thêm thất bại!");
            }
        }
    }
}
