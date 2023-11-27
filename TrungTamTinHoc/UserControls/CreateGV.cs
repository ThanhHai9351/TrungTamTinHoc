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

namespace TrungTamTinHoc.UserControls
{
    public partial class CreateGV : UserControl
    {
        public CreateGV()
        {
            InitializeComponent();
        }


        SqlConnection connection = null;
        private void CreateGV_Load(object sender, EventArgs e)
        {
            txtEmail.Enabled = false;
            txtPhone.Enabled = false;
            txtEmail.Enabled = false;
            dt_Birthday.Enabled = false;
            CompanyDB db = new CompanyDB();
            List<Teacher> teachers = db.GetTeachers();
            foreach (var item in teachers)
            {
                ListViewItem i = new ListViewItem(item.TeacherID);
                i.SubItems.Add(item.FirstName);
                i.SubItems.Add(item.LastName);
                i.SubItems.Add(item.Email);
                i.SubItems.Add(item.Phone);
                i.SubItems.Add(item.Birthday.ToString());
                lv_Student.Items.Add(i);
            }
            List<Classrooms> classrooms = db.GetClassrooms();
            foreach (var item in classrooms)
            {
                cbo_Select.Items.Add(item.ClassromName);
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

        private void cbo_Select_SelectedIndexChanged(object sender, EventArgs e)
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
            List<Models.ManagerClass> managerClasses = db.GetManagerClasses();
            List<Teacher> teachers = db.GetTeachers();
            List<Classrooms> classrooms = db.GetClassrooms();
            string malop = "";
            List<string> magv = new List<string>();
            foreach (var item in classrooms)
            {
                if (item.ClassromName.TrimEnd() == cbo_Select.Text.TrimEnd())
                {
                    malop = item.ClassromID;
                }
            }
            foreach (var item in managerClasses)
            {
                if (item.ClassroomID == malop)
                {
                    if(magv.Contains(item.TeacherID))
                    {
                        continue;
                    }
                    else
                    {
                        magv.Add(item.TeacherID);

                    }
                }
            }
            lv_Student.Items.Clear();
            foreach (string i in magv)
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "Select * from Teacher where TeacherID = @ma";
                command.Connection = connection;

                command.Parameters.Add("@ma", SqlDbType.Char).Value = i.TrimEnd();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    ListViewItem item = new ListViewItem(reader.GetString(0));
                    item.SubItems.Add(reader.GetString(1));
                    item.SubItems.Add(reader.GetString(2));
                    item.SubItems.Add(reader.GetString(3));
                    item.SubItems.Add(reader.GetString(4));
                    item.SubItems.Add(reader.GetDateTime(5).ToString());
                    lv_Student.Items.Add(item);
                }
                reader.Close();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            cbo_Select.Items.Clear();
            lv_Student.Items.Clear();
            txtSearch.Text = "";
            txtId.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
            txtEmail.Enabled = false;
            txtPhone.Enabled = false;
            txtEmail.Enabled = false;
            dt_Birthday.Enabled = false;
            CompanyDB db = new CompanyDB();
            List<Teacher> teachers = db.GetTeachers();
            foreach (var item in teachers)
            {
                ListViewItem i = new ListViewItem(item.TeacherID);
                i.SubItems.Add(item.FirstName);
                i.SubItems.Add(item.LastName);
                i.SubItems.Add(item.Email);
                i.SubItems.Add(item.Phone);
                i.SubItems.Add(item.Birthday.ToString());
                lv_Student.Items.Add(i);
            }
            List<Classrooms> classrooms = db.GetClassrooms();
            foreach (var item in classrooms)
            {
                cbo_Select.Items.Add(item.ClassromName);
            }
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
            command.CommandText = "SELECT * FROM dbo.SearchTeachers(@search)";
            command.Connection = connection;
            command.Parameters.Add("@search", SqlDbType.NVarChar).Value = txtSearch.Text.TrimEnd();
            lv_Student.Items.Clear();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ListViewItem item = new ListViewItem(reader.GetString(0));
                item.SubItems.Add(reader.GetString(1));
                item.SubItems.Add(reader.GetString(2));
                item.SubItems.Add(reader.GetString(3));
                item.SubItems.Add(reader.GetString(4));
                item.SubItems.Add(reader.GetDateTime(5).ToString());
                lv_Student.Items.Add(item);
            }
            reader.Close();
        }

        private void btnCreate_Click(object sender, EventArgs e)
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
            command.CommandText = "insert into Teacher values (@ma,@first,@last,@email,@phone,@sn)";
            command.Connection = connection;

            command.Parameters.Add("@ma", SqlDbType.Char).Value = txtId.Text.TrimEnd();
            command.Parameters.Add("@first", SqlDbType.NVarChar).Value = txtFirstName.Text.TrimEnd();
            command.Parameters.Add("@last", SqlDbType.NVarChar).Value = txtLastName.Text.TrimEnd();
            command.Parameters.Add("@email", SqlDbType.Char).Value = txtEmail.Text.TrimEnd();
            command.Parameters.Add("@phone", SqlDbType.Char).Value = txtPhone.Text.TrimEnd();
            command.Parameters.Add("@sn", SqlDbType.DateTime).Value = dt_Birthday.Value;


            int ret = command.ExecuteNonQuery();
            if (ret > 0)
            {
                MessageBox.Show("Bạn đã thêm thành công!");
                txtId.Text = "";
                txtFirstName.Text = "";
                txtLastName.Text = "";
                txtEmail.Text = "";
                txtPhone.Text = "";
                txtEmail.Enabled = false;
                txtPhone.Enabled = false;
                txtEmail.Enabled = false;
                dt_Birthday.Enabled = false;
            }
            else
            {
                MessageBox.Show("Bạn đã thêm thất bại!");
            }
        }

        public bool checkID(string str)
        {
            CompanyDB db = new CompanyDB();
            List<Teacher> teachers = db.GetTeachers();
            foreach (var item in teachers)
            {
                if (item.TeacherID.TrimEnd() == str)
                    return false;
            }
            return true;
        }

        private void txtId_Leave(object sender, EventArgs e)
        {
            if (txtId.Text == "")
            {
                this.errorProvider1.SetError(txtId, "ID không được trống");
            }
            else if (!checkID(txtId.Text.TrimEnd()))
            {
                this.errorProvider1.SetError(txtId, "ID này đã tồn tại!");
            }
            else
            {
                this.errorProvider1.Clear();
                txtEmail.Enabled = true;
                txtPhone.Enabled = true;
                dt_Birthday.Enabled = true;
            }
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
