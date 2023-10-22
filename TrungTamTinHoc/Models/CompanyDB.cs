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
        string strcon = "SERVER = THANHHAI; DATABASE = TrungTamTinHoc; Integrated Security = true";
        public List<Student> getStudents()
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
    }
}
