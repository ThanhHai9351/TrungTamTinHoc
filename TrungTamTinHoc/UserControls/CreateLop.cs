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
    public partial class CreateLop : UserControl
    {
        public CreateLop()
        {
            InitializeComponent();
        }
        SqlConnection connection = null;
        private void CreateLop_Load(object sender, EventArgs e)
        {
            CompanyDB db = new CompanyDB();
            List<Teacher> teachers = db.GetTeachers();
            List<Classrooms> classrooms = db.GetClassrooms();
            foreach(var item in teachers)
            {
                string name = item.FirstName + " " + item.LastName;
                cbo_Select.Items.Add(name);
                cbo_teacher.Items.Add(name);
            }    
            foreach(var item in classrooms)
            {
                ListViewItem i = new ListViewItem(item.ClassromID);
                i.SubItems.Add(item.ClassromName);
                i.SubItems.Add(item.Capacity + "");
                i.SubItems.Add(db.getTeacherName(item.TeacherID));
                i.SubItems.Add(item.AmountOfMoney+ "");
                lv_Class.Items.Add(i);
            }
            cbo_teacher.SelectedIndex = 0;
        }

        private void lv_Student_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        private void btnCreate_Click(object sender, EventArgs e)
        {
            CompanyDB db = new CompanyDB();
            List<Teacher> teachers = db.GetTeachers();
            string magv = "";
            foreach(var item in teachers)
            {
                string name = item.FirstName + " " + item.LastName;
                if(name == cbo_teacher.Text)
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
            command.CommandText = "Insert into Classrooms values (@ma,@ten,@ss,@teacherid,@money)";
            command.Connection = connection;

            command.Parameters.Add("@ma", SqlDbType.Char).Value = txtId.Text.TrimEnd();
            command.Parameters.Add("@ten", SqlDbType.NVarChar).Value = txtName.Text.TrimEnd();
            command.Parameters.Add("@ss", SqlDbType.Int).Value = int.Parse(txtSiSo.Text);
            command.Parameters.Add("@teacherid", SqlDbType.Char).Value = magv;
            command.Parameters.Add("@money", SqlDbType.Int).Value = int.Parse(txtMoney.Text);

            int ret = command.ExecuteNonQuery();
            if (ret > 0)
            {
                MessageBox.Show("Bạn đã thêm thành công!");
                txtId.Text = "";
                txtName.Text = "";
                txtSiSo.Text = "";
                txtMoney.Text = "";
                txtSiSo.Enabled = false;
                txtMoney.Enabled = false;
            }
            else
            {
                MessageBox.Show("Bạn đã thêm thất bại!");
            }

        }

        private void cbo_Select_SelectedIndexChanged(object sender, EventArgs e)
        {
            CompanyDB db = new CompanyDB();
            List<Teacher> teachers = db.GetTeachers();
            List<Classrooms> classrooms = db.GetClassrooms();
            string magv = "";
            foreach(var item in teachers)
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
                i.SubItems.Add(reader.GetInt32(2)+"");
                i.SubItems.Add(db.getTeacherName(reader.GetString(3)));
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
                item.SubItems.Add(db.getTeacherName(reader.GetString(3)));
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
            txtSiSo.Enabled = false;
            txtMoney.Enabled = false;
            CompanyDB db = new CompanyDB();
            List<Classrooms> classrooms = db.GetClassrooms();
            lv_Class.Items.Clear();
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
        public bool checkID(string str)
        {
            CompanyDB db = new CompanyDB();
            List<Classrooms> classrooms = db.GetClassrooms();
            foreach (var item in classrooms)
            {
                if (item.ClassromID.TrimEnd() == str)
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
                txtSiSo.Enabled = true;
                txtMoney.Enabled = true;
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
