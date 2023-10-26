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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            CompanyDB db = new CompanyDB();
            int sum = 0;
            List<Payments> payments = db.GetPayments().Where(row => row.MoneyDate.ToString("ddMMyyyy") == dateTimePicker1.Value.ToString("ddMMyyyy")).ToList();
            lv_report.Items.Clear();
            foreach(var item in payments)
            {
                sum += item.AmountOfMoney;
                ListViewItem i = new ListViewItem(item.PaymentsID);
                i.SubItems.Add(getNameStudent(item.StudentID));
                i.SubItems.Add(getNameClassroom(item.ClassromID));
                i.SubItems.Add(item.AmountOfMoney + "");
                i.SubItems.Add(item.Active);
                i.SubItems.Add(item.MoneyDate + "");
                lv_report.Items.Add(i);
            }

            txtDoanhThu.Text = sum + "";
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
            command.CommandText = "select * from PAYMENTS where MoneyDate is not null";
            command.Connection = connection;

            SqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                ListViewItem item = new ListViewItem(reader.GetString(0));
                item.SubItems.Add(getNameStudent(reader.GetString(1)));
                item.SubItems.Add(getNameClassroom(reader.GetString(2)));
                item.SubItems.Add(reader.GetInt32(3) + "");
                item.SubItems.Add(reader.GetString(4));
                item.SubItems.Add(reader.GetDateTime(5) + ""); 
                lv_report.Items.Add(item);
            }
            reader.Close();

            int sum = 0;
            foreach(var item in payments)
            {
                sum += item.AmountOfMoney;
            }

            txtDoanhThu.Text = sum + ""; 
        }
    }
}
