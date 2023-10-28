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
using TrungTamTinHoc.Forms;

namespace TrungTamTinHoc.UserControls
{
    public partial class ThongTinLop : UserControl
    {
        public ThongTinLop()
        {
            InitializeComponent();
        }
        SqlConnection connection = null;
        private void lv_Class_SelectedIndexChanged(object sender, EventArgs e)
        {
            CompanyDB db = new CompanyDB();
            List<Student> students = db.GetStudents();
            List<ManagerClass> managerClasses = db.GetManagerClasses();
            string malop = "";
            List<string> masv = new List<string>();
            if(lv_Class.SelectedItems.Count>0)
            {
                malop = lv_Class.SelectedItems[0].SubItems[0].Text;
            }    
            foreach(var item in managerClasses)
            {
                if(malop == item.ClassroomID)
                {
                    masv.Add(item.StudentID);
                }    
            }    
            if(connection == null)
            {
                connection = new SqlConnection(db.strcon);
            }    
            if(connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            lv_Student.Items.Clear();
           foreach(var i in masv)
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "Select * from Student Where StudentID = @ma";
                command.Connection = connection;

                command.Parameters.Add("@ma", SqlDbType.Char).Value = i;

                SqlDataReader reader = command.ExecuteReader();
                if(reader.Read())
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
            QL_Lop frm = new QL_Lop(malop);
            frm.ShowDialog();
        }

        private void lv_Class_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.DeepSkyBlue, e.Bounds); // Đặt màu nền cho header
            TextRenderer.DrawText(e.Graphics, e.Header.Text, e.Font, e.Bounds, Color.Black); // Vẽ văn bản
        }

        private void lv_Class_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
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
            command.CommandText = "SELECT * FROM dbo.SearchClassrooms(@search)";
            command.Connection = connection;
            command.Parameters.Add("@search", SqlDbType.NVarChar).Value = txtSearch.Text.TrimEnd();
            lv_Class.Items.Clear();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ListViewItem item = new ListViewItem(reader.GetString(0));
                item.SubItems.Add(reader.GetString(1));
                item.SubItems.Add(reader.GetInt32(2) + "");
                item.SubItems.Add(db.getTeacherName(reader.GetString(3)));
                item.SubItems.Add(reader.GetInt32(4) + "");
                lv_Class.Items.Add(item);
            }
            reader.Close();
        }

        private void lv_Student_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.Aqua, e.Bounds); // Đặt màu nền cho header
            TextRenderer.DrawText(e.Graphics, e.Header.Text, e.Font, e.Bounds, Color.Black); // Vẽ văn bản
        }

        private void lv_Student_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ThongTinLop_Load(object sender, EventArgs e)
        {
            CompanyDB db = new CompanyDB();
            List<Teacher> teachers = db.GetTeachers();
            List<Classrooms> classrooms = db.GetClassrooms();
            foreach (var item in teachers)
            {
                string name = item.FirstName + " " + item.LastName;
                cbo_Select.Items.Add(name);
            }
            foreach (var item in classrooms)
            {
                ListViewItem i = new ListViewItem(item.ClassromID);
                i.SubItems.Add(item.ClassromName);
                i.SubItems.Add(item.Capacity + "");
                i.SubItems.Add(db.getTeacherName(item.TeacherID));
                i.SubItems.Add(item.AmountOfMoney + "");
                lv_Class.Items.Add(i);
            }
        }

        private void cbo_Select_SelectedIndexChanged(object sender, EventArgs e)
        {
            CompanyDB db = new CompanyDB();
            List<Teacher> teachers = db.GetTeachers();
            List<Classrooms> classrooms = db.GetClassrooms();
            string magv = "";
            foreach (var item in teachers)
            {
                string name = item.FirstName + " " + item.LastName;
                if (name == cbo_Select.Text)
                {
                    magv = item.TeacherID;
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
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "Select * from Classrooms where TeacherID = @ma";
            command.Connection = connection;

            command.Parameters.Add("@ma", SqlDbType.Char).Value = magv;

            lv_Class.Items.Clear();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ListViewItem i = new ListViewItem(reader.GetString(0));
                i.SubItems.Add(reader.GetString(1));
                i.SubItems.Add(reader.GetInt32(2) + "");
                i.SubItems.Add(db.getTeacherName(reader.GetString(3)));
                i.SubItems.Add(reader.GetInt32(4) + "");
                lv_Class.Items.Add(i);
            }
            reader.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            cbo_Select.Text = "Giáo Viên";
            lv_Student.Items.Clear();
            CompanyDB db = new CompanyDB();
            lv_Class.Items.Clear();
            List<Classrooms> classrooms = db.GetClassrooms();
            foreach (var item in classrooms)
            {
                ListViewItem i = new ListViewItem(item.ClassromID);
                i.SubItems.Add(item.ClassromName);
                i.SubItems.Add(item.Capacity + "");
                i.SubItems.Add(item.TeacherID);
                i.SubItems.Add(item.AmountOfMoney + "");
                lv_Class.Items.Add(i);
            }
        }

        private void lv_Student_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lv_Student.SelectedItems.Count>0)
            {
                ThongTinChiTiet frm = new ThongTinChiTiet(lv_Student.SelectedItems[0].SubItems[0].Text);
                frm.ShowDialog();
            }    
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
