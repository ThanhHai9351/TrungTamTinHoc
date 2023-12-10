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
    public partial class Report : UserControl
    {
        public Report()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        CompanyDB db = new CompanyDB();
        SqlConnection connection = null;
        public string getNameStudent(string ma)
        {
            CompanyDB db = new CompanyDB();
            List<Student> students = db.GetStudents();
            foreach(var item in students)
            {
                if(item.StudentID == ma)
                {
                    return item.FirstName + " " + item.LastName;
                }    
            }
            return "0";
        }

         public string getNameClassroom(string ma)
        {
            CompanyDB db = new CompanyDB();
            List<Classrooms> classrooms = db.GetClassrooms();
            foreach(var item in classrooms)
            {
                if(item.ClassromID == ma)
                {
                    return item.ClassromName;
                }    
            }
            return "0";
        }

        private void listView1_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.DeepSkyBlue, e.Bounds); // Đặt màu nền cho header
            TextRenderer.DrawText(e.Graphics, e.Header.Text, e.Font, e.Bounds, Color.Black); // Vẽ văn bản
        }

        private void listView1_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

      

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Report_Load(object sender, EventArgs e)
        {
            CompanyDB db = new CompanyDB();
            List<Payments> payments = db.GetPayments();
            if(connection == null)
            {
                connection = new SqlConnection(db.strcon);
            }    
            if(connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "select * from PAYMENTS";
            command.Connection = connection;

            SqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                ListViewItem item = new ListViewItem(reader.GetString(0));
                item.SubItems.Add(getNameStudent(reader.GetString(1)));
                item.SubItems.Add(getNameClassroom(reader.GetString(2)));
                item.SubItems.Add(reader.GetInt32(3) + "");
                item.SubItems.Add(reader.GetString(4));
                lv_report.Items.Add(item);
            }
            reader.Close();

            int sum = 0;
            foreach(var item in payments)
            {
                sum += item.AmountOfMoney;
            }

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            CompanyDB db = new CompanyDB();
            List<Payments> payments = db.GetPayments();
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
            command.CommandText = "select * from PAYMENTS";
            command.Connection = connection;

            lv_report.Items.Clear();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ListViewItem item = new ListViewItem(reader.GetString(0));
                item.SubItems.Add(getNameStudent(reader.GetString(1)));
                item.SubItems.Add(getNameClassroom(reader.GetString(2)));
                item.SubItems.Add(reader.GetInt32(3) + "");
                item.SubItems.Add(reader.GetString(4));
                lv_report.Items.Add(item);
            }
            reader.Close();
            txtSearch.Text = "";
            txtMa.Text = "";
            txtStudent.Text = "";
            txtClass.Text = "";
            txtMoney.Text = "";
            txtActive.Text = "";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(txtSearch.Text == "")
            {
                MessageBox.Show("Cần nhập từ cần tìm kiếm!");
            }
            else
            {
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
                command.CommandText = "select * from PAYMENTS WHERE PaymentsID LIKE '%" + txtSearch.Text.TrimEnd()+"%'";
                command.Connection = connection;

                lv_report.Items.Clear();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ListViewItem item = new ListViewItem(reader.GetString(0));
                    item.SubItems.Add(getNameStudent(reader.GetString(1)));
                    item.SubItems.Add(getNameClassroom(reader.GetString(2)));
                    item.SubItems.Add(reader.GetInt32(3) + "");
                    item.SubItems.Add(reader.GetString(4));
                    lv_report.Items.Add(item);
                }
                reader.Close();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void lv_report_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lv_report.SelectedItems.Count > 0)
            {
                txtMa.Text = lv_report.SelectedItems[0].SubItems[0].Text;
                txtStudent.Text = lv_report.SelectedItems[0].SubItems[1].Text;
                txtClass.Text = lv_report.SelectedItems[0].SubItems[2].Text;
                txtMoney.Text = lv_report.SelectedItems[0].SubItems[3].Text;
                txtActive.Text = lv_report.SelectedItems[0].SubItems[4].Text;
            }
        }
    }
}
