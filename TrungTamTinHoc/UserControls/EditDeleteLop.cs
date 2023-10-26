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
    public partial class EditDeleteLop : UserControl
    {
        public EditDeleteLop()
        {
            InitializeComponent();
        }
        SqlConnection connection = null;
        private void EditDeleteLop_Load(object sender, EventArgs e)
        {
            CompanyDB db = new CompanyDB();
            List<Teacher> teachers = db.GetTeachers();
            List<Classrooms> classrooms = db.GetClassrooms();
            foreach (var item in teachers)
            {
                string name = item.FirstName + " " + item.LastName;
                cbo_Select.Items.Add(name);
                cbo_teacher.Items.Add(name);
            }
            foreach (var item in classrooms)
            {
                ListViewItem i = new ListViewItem(item.ClassromID);
                i.SubItems.Add(item.ClassromName);
                i.SubItems.Add(item.Capacity + "");
                i.SubItems.Add(item.TeacherID);
                i.SubItems.Add(item.AmountOfMoney + "");
                lv_Class.Items.Add(i);
            }
            cbo_teacher.SelectedIndex = 0;
        }

        private void btnEdit_Click(object sender, EventArgs e)
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
            command.CommandText = "Update Classrooms set ClassroomName = @ten, Capacity = @ss, AmountOfMoney = @money where ClassroomId = @ma";
            command.Connection = connection;

            command.Parameters.Add("@ma", SqlDbType.Char).Value = txtId.Text.TrimEnd();
            command.Parameters.Add("@ten", SqlDbType.NVarChar).Value = txtName.Text.TrimEnd();
            command.Parameters.Add("@ss", SqlDbType.Int).Value = int.Parse(txtSiSo.Text);
            command.Parameters.Add("@money", SqlDbType.Int).Value = int.Parse(txtMoney.Text);

            int ret = command.ExecuteNonQuery();
            if (ret > 0)
            {
                MessageBox.Show("Bạn đã sửa thành công!");
           
            }
            else
            {
                MessageBox.Show("Bạn đã sửa thất bại!");
            }
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

        private void lv_Class_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lv_Class.SelectedItems.Count>0)
            {
                txtId.Text = lv_Class.SelectedItems[0].SubItems[0].Text;
                txtName.Text = lv_Class.SelectedItems[0].SubItems[1].Text;
                txtSiSo.Text = lv_Class.SelectedItems[0].SubItems[2].Text;
                cbo_teacher.Text = lv_Class.SelectedItems[0].SubItems[3].Text;
                txtMoney.Text = lv_Class.SelectedItems[0].SubItems[4].Text;
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
                i.SubItems.Add(reader.GetString(3));
                i.SubItems.Add(reader.GetInt32(4) + "");
                lv_Class.Items.Add(i);
            }
            reader.Close();
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
                item.SubItems.Add(reader.GetString(3));
                item.SubItems.Add(reader.GetInt32(4) + "");
                lv_Class.Items.Add(item);
            }
            reader.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            cbo_Select.Text = "Giáo Viên";
            txtId.Text = "";
            txtName.Text = "";
            txtSiSo.Text = "";
            txtMoney.Text = "";
            CompanyDB db = new CompanyDB();
            List<Classrooms> classrooms = db.GetClassrooms();
            lv_Class.Items.Clear();
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn muốn xóa " + txtName.Text, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
                command.CommandText = "Delete Classrooms where ClassroomID = @ma";
                command.Connection = connection;

                command.Parameters.Add("@ma", SqlDbType.Char).Value = txtId.Text.TrimEnd();

                int ret = command.ExecuteNonQuery();
                if (ret > 0)
                {
                    MessageBox.Show("Xóa thành công!");
                    txtId.Text = "";
                    txtName.Text = "";
                    txtSiSo.Text = "";
                    txtMoney.Text = "";
                }
                else
                {
                    MessageBox.Show("Xóa thất bại!");
                }
            }
            }
    }
}
