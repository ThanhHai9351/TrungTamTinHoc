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
    public partial class ThongTinChiTiet : Form
    {
        string mahs = "";
        public ThongTinChiTiet()
        {
            InitializeComponent();
        }
        SqlConnection connection = null;
        public ThongTinChiTiet(string ma)
        {
            mahs = ma;
            InitializeComponent();
        }

        public string getClassName(string ma)
        {
            CompanyDB db = new CompanyDB();
            List<Classrooms> classrooms = db.GetClassrooms();
            foreach(var item in classrooms)
            {
                if (item.ClassromID == ma)
                    return item.ClassromName;
            }
            return "0";
        }

        private void ThongTinChiTiet_Load(object sender, EventArgs e)
        {
            CompanyDB db = new CompanyDB();
            List<Student> students = db.GetStudents();
            List<ManagerClass> managerClasses = db.GetManagerClasses();
            List<string> mamon = new List<string>();
            List<string> tenmon = new List<string>();
            foreach(var item in students)
            {
                if(item.StudentID == mahs)
                {
                    txtId.Text = item.StudentID;
                    txtFirstName.Text = item.FirstName;
                    txtLastName.Text = item.LastName;
                    txtEmail.Text = item.Email;
                    txtPhone.Text = item.Phone;
                    dt_Birthday.Value = item.Birthday;
                }    
            }    
            foreach(var item in managerClasses)
            {
                if(item.StudentID == mahs)
                {
                    mamon.Add(item.ClassroomID);
                }    
            }
            
            foreach(var item in mamon)
            {
                tenmon.Add(getClassName(item));
            }    
            foreach(var item in tenmon)
            {
                cbo_Lop.Items.Add(item);
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
            command.CommandText = "select sum(AmountOfMoney) from PAYMENTS where StudentID = @ma";
            command.Connection = connection;

            command.Parameters.Add("@ma", SqlDbType.Char).Value = mahs;
            SqlDataReader reader = command.ExecuteReader();
            if(reader.Read())
            {
                txtTongTien.Text = reader.GetInt32(0) + "";
            }
            reader.Close();
        }
    }
}
