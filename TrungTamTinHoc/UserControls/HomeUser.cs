using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrungTamTinHoc.Models;

namespace TrungTamTinHoc.UserControls
{
    public partial class HomeUser : UserControl
    {
        CompanyDB db = new CompanyDB();
        public string mahs = null;
        public HomeUser()
        {
            InitializeComponent();
        }

        public HomeUser(string id)
        {
            mahs = id;
            InitializeComponent();
        }

        private void HomeUser_Load(object sender, EventArgs e)
        {
            Student st = db.GetStudents().Where(row => row.StudentID.TrimEnd() == mahs.TrimEnd()).FirstOrDefault();
            txtId.Text = st.StudentID;
            txtFirstName.Text = st.FirstName;
            txtLastName.Text = st.LastName;
            txtEmail.Text = st.Email;
            txtPhone.Text = st.Phone;
            dt_Birthday.Value = st.Birthday;
        }
    }
}
