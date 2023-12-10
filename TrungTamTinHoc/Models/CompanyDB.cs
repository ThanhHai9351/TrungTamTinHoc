using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace TrungTamTinHoc.Models
{
    public class CompanyDB
    {
        SqlConnection connection = null;
        public string strcon = "SERVER = THANHHAI; DATABASE = TrungTamTinHoc; Integrated Security = true";
        public List<Student> GetStudents()
        {
            List<Student> lstst = new List<Student>();
            if(connection == null)
            {
                connection = new SqlConnection(strcon);
            }
            if(connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "Select * from Student";
            command.Connection = connection;

            SqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                Student st = new Student();
                st.StudentID = reader.GetString(0);
                st.FirstName = reader.GetString(1);
                st.LastName = reader.GetString(2);
                st.Email = reader.GetString(3);
                st.Phone = reader.GetString(4);
                st.Birthday = reader.GetDateTime(5);
                lstst.Add(st);
            }
            reader.Close();
            return lstst;
        }

        public string GetStudentName (string id)
        {
            List<Student> st = GetStudents();
            foreach(var item in st)
            {
                if (item.StudentID.TrimEnd() == id.TrimEnd())
                    return item.FirstName +" "+item.LastName;
            }
            return "";
        }

        public List<Teacher> GetTeachers()
        {
            List<Teacher> lsttc = new List<Teacher>();
            if (connection == null)
            {
                connection = new SqlConnection(strcon);
            }
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "Select * from Teacher";
            command.Connection = connection;

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Teacher st = new Teacher();
                st.TeacherID = reader.GetString(0);
                st.FirstName = reader.GetString(1);
                st.LastName = reader.GetString(2);
                st.Email = reader.GetString(3);
                st.Phone = reader.GetString(4);
                st.Birthday = reader.GetDateTime(5);
                lsttc.Add(st);
            }
            reader.Close();
            return lsttc;
        }

        public List<Classrooms> GetClassrooms()
        {
            List<Classrooms> lstclss = new List<Classrooms>();
            if (connection == null)
            {
                connection = new SqlConnection(strcon);
            }
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "Select * from Classrooms";
            command.Connection = connection;

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Classrooms st = new Classrooms();
                st.ClassromID = reader.GetString(0);
                st.ClassromName = reader.GetString(1);
                st.Capacity = reader.GetInt32(2);
                st.TeacherID = reader.GetString(3);
                st.AmountOfMoney = reader.GetInt32(4);
                lstclss.Add(st);
            }
            reader.Close();
            return lstclss;
        }

        public List<Payments> GetPayments()
        {
            List<Payments> lst = new List<Payments>();
            if (connection == null)
            {
                connection = new SqlConnection(strcon);
            }
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "select * from PAYMENTS";
            command.Connection = connection;

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Payments st = new Payments();
                st.PaymentsID = reader.GetString(0);
                st.StudentID = reader.GetString(1);
                st.ClassromID = reader.GetString(2);
                st.AmountOfMoney = reader.GetInt32(3);
                st.Active = reader.GetString(4);
                lst.Add(st);
            }
            reader.Close();
            return lst;
        }

        public List<Schedule> GetSchedules()
        {
            List<Schedule> lst = new List<Schedule>();
            if (connection == null)
            {
                connection = new SqlConnection(strcon);
            }
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "Select * from SCHEDULE";
            command.Connection = connection;

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Schedule st = new Schedule();
                st.ScheduleID = reader.GetString(0);
                st.StartDate = reader.GetDateTime(1);
                st.EndDate = reader.GetDateTime(2);
                st.ClassroomID = reader.GetString(3);
                st.Ca = reader.GetInt32(4);
                lst.Add(st);
            }
            reader.Close();
            return lst;
        }

        public List<ManagerClass> GetManagerClasses()
        {
            List<ManagerClass> lst = new List<ManagerClass>();
            if (connection == null)
            {
                connection = new SqlConnection(strcon);
            }
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "Select * from MANAGERCLASS";
            command.Connection = connection;

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ManagerClass st = new ManagerClass();
                st.StudentID = reader.GetString(0);
                st.ClassroomID = reader.GetString(1);
                st.TeacherID = reader.GetString(2);
                lst.Add(st);
            }
            reader.Close();
            return lst;
        }

        public List<Account> GetAccounts()
        {
            List<Account> lst = new List<Account>();
            if (connection == null)
            {
                connection = new SqlConnection(strcon);
            }
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "Select * from ACCOUNT";
            command.Connection = connection;

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Account st = new Account();
                st.StudentID = reader.GetString(0);
                st.Pass = reader.GetString(1);
                lst.Add(st);
            }
            reader.Close();
            return lst;
        }

        public bool checkAccountIsvalid(string user,string pass)
        {
            List<Account> accounts = GetAccounts();
            foreach(var item in accounts)
            {
                if(item.StudentID.TrimEnd()==user.TrimEnd()&&item.Pass.TrimEnd()==pass.TrimEnd())
                {
                    return true;
                }    
            }
            return false;
        }    

        public string getTeacherName(string ma)
        {
            List<Teacher> teachers = GetTeachers();
            foreach(var item in teachers)
            {
                if (item.TeacherID.TrimEnd() == ma.TrimEnd())
                    return item.FirstName + " " + item.LastName;
            }
            return null;
        }

        public string getClassroomName(string ma)
        {
            List<Classrooms> classrooms = GetClassrooms();
            foreach (var item in classrooms)
            {
                if (item.ClassromID.TrimEnd() == ma.TrimEnd())
                    return item.ClassromName;
            }
            return null;
        }

        public string getClassroomID(string name)
        {
            List<Classrooms> classrooms = GetClassrooms();
            foreach (var item in classrooms)
            {
                if (item.ClassromName.TrimEnd() == name.TrimEnd())
                    return item.ClassromID;
            }
            return null;
        }

        public bool checkIDPayments(string id)
        {
            List<Payments> p = GetPayments();
            foreach(var item in p)
            {
                if (item.PaymentsID.TrimEnd() == id.TrimEnd())
                    return true;
            }
            return false;
        }

        public string GetTeacherID(string name)
        {
            List<Teacher> t = GetTeachers();
            foreach(var item in t)
            {
                if((item.FirstName.TrimEnd()+" "+item.LastName.TrimEnd())==name.TrimEnd())
                {
                    return item.TeacherID;
                }    
            }
            return "";
        }
    }
}
