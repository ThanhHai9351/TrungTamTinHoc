using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TrungTamTinHoc.Models;

namespace TrungTamTinHoc.UserControls
{
    public partial class LichHoc : UserControl
    {
        public LichHoc()
        {
            InitializeComponent();
        }
        SqlConnection connection = null;
        private void LichHoc_Load(object sender, EventArgs e)
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
            lv_LichHoc.Items.Clear();
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

        private void lv_Class_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lv_Class.SelectedItems.Count > 0)
            {
                string ma = lv_Class.SelectedItems[0].SubItems[0].Text;
                CompanyDB db = new CompanyDB();
                List<Schedule> schedules = db.GetSchedules().Where(row => row.ClassroomID == ma).ToList();
                lv_LichHoc.Items.Clear();
                foreach (var item in schedules)
                {
                    if (item.Ca == 1)
                    {
                        ListViewItem i = new ListViewItem(item.StartDate.ToString("dd-MM-yyyy"));
                        i.SubItems.Add("X");
                        i.SubItems.Add("");
                        i.SubItems.Add("");
                        i.SubItems.Add("");
                        lv_LichHoc.Items.Add(i);
                    }
                    else if (item.Ca == 2)
                    {
                        ListViewItem i = new ListViewItem(item.StartDate.ToString("dd-MM-yyyy"));
                        i.SubItems.Add("");
                        i.SubItems.Add("X");
                        i.SubItems.Add("");
                        i.SubItems.Add("");
                        lv_LichHoc.Items.Add(i);
                    }
                    else if (item.Ca == 3)
                    {
                        ListViewItem i = new ListViewItem(item.StartDate.ToString("dd-MM-yyyy"));
                        i.SubItems.Add("");
                        i.SubItems.Add("");
                        i.SubItems.Add("X");
                        i.SubItems.Add("");
                        lv_LichHoc.Items.Add(i);
                    }
                    else
                    {
                        ListViewItem i = new ListViewItem(item.StartDate.ToString("dd-MM-yyyy"));
                        i.SubItems.Add("");
                        i.SubItems.Add("");
                        i.SubItems.Add("");
                        i.SubItems.Add("X");
                        lv_LichHoc.Items.Add(i);
                    }
                }
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

        private void lv_LichHoc_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.Aqua, e.Bounds); // Đặt màu nền cho header
            TextRenderer.DrawText(e.Graphics, e.Header.Text, e.Font, e.Bounds, Color.Black); // Vẽ văn bản
        }

        private void lv_LichHoc_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
