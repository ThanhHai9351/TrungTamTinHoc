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
using TrungTamTinHoc.Forms;

namespace TrungTamTinHoc.UserControls
{
    public partial class ClassUser : UserControl
    {
        CompanyDB db = new CompanyDB();
        public string mahs = null;
        public ClassUser()
        {
            InitializeComponent();
        }

        public ClassUser(string id)
        {
            mahs = id;
            InitializeComponent();
        }

        private void ClassUser_Load(object sender, EventArgs e)
        {
            List<ManagerClass> managerClasses = db.GetManagerClasses().Where(row => row.StudentID.TrimEnd() == mahs.TrimEnd()).ToList();
            lv_Class.Items.Clear();
            foreach(var item in managerClasses)
            {
                ListViewItem item1 = new ListViewItem(db.GetStudentName(item.StudentID.TrimEnd()));
                item1.SubItems.Add(db.getClassroomName(item.ClassroomID.TrimEnd()));
                item1.SubItems.Add(db.getTeacherName(item.TeacherID.TrimEnd()));
                lv_Class.Items.Add(item1);
            }    
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            List<ManagerClass> managerClasses = db.GetManagerClasses().Where(row => row.StudentID.TrimEnd() == mahs.TrimEnd()).ToList();
            lv_Class.Items.Clear();
            foreach (var item in managerClasses)
            {
                ListViewItem item1 = new ListViewItem(db.GetStudentName(item.StudentID.TrimEnd()));
                item1.SubItems.Add(db.getClassroomName(item.ClassroomID.TrimEnd()));
                item1.SubItems.Add(db.getTeacherName(item.TeacherID.TrimEnd()));
                lv_Class.Items.Add(item1);
            }
            txtStudent.Text = "";
            txtTeacher.Text = "";
            txtClass.Text = "";

        }

        private void lv_Class_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lv_Class.SelectedItems.Count > 0)
            {
                txtStudent.Text = lv_Class.SelectedItems[0].SubItems[0].Text;
                txtClass.Text = lv_Class.SelectedItems[0].SubItems[1].Text;
                txtTeacher.Text = lv_Class.SelectedItems[0].SubItems[2].Text;
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            DangKyHocPhan frm = new DangKyHocPhan(mahs);
            frm.ShowDialog();
        }
    }
}
