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
using System.Data.SqlClient;

namespace TrungTamTinHoc.Forms
{
    public partial class CreateLichHoc : Form
    {
        string MaLop = null;
        CompanyDB db = new CompanyDB();
        SqlConnection connection = null;

        public CreateLichHoc()
        {
            InitializeComponent();
        }

        public CreateLichHoc(string id)
        {
            MaLop = id;
            InitializeComponent();
        }

        private void CreateLichHoc_Load(object sender, EventArgs e)
        {
            this.Text = db.getClassroomName(MaLop.TrimEnd());
            lbLop.Text = db.getClassroomName(MaLop.TrimEnd());
            List<Schedule> schedules = db.GetSchedules();
            schedules = schedules.Where(row => row.ClassroomID.TrimEnd() == MaLop.TrimEnd()).ToList();
            lvLichHoc.Items.Clear();
            foreach(var item in schedules)
            {
                ListViewItem item1 = new ListViewItem(item.ScheduleID);
                item1.SubItems.Add(item.StartDate.ToString());
                item1.SubItems.Add(item.EndDate.ToString());
                item1.SubItems.Add(db.getClassroomName(item.ClassroomID));
                item1.SubItems.Add(item.Ca.ToString());
                lvLichHoc.Items.Add(item1);
            }
            cboCa.Items.Add('1');
            cboCa.Items.Add('2');
            cboCa.Items.Add('3');
            cboCa.Items.Add('4');
        }

        private void lvLichHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtMa.Enabled = false;
            if(lvLichHoc.SelectedItems.Count > 0)
            {
                txtMa.Text = lvLichHoc.SelectedItems[0].SubItems[0].Text;
                dtStart.Value = DateTime.Parse(lvLichHoc.SelectedItems[0].SubItems[1].Text.TrimEnd());
                dtEnd.Value = DateTime.Parse(lvLichHoc.SelectedItems[0].SubItems[2].Text.TrimEnd());
                cboCa.Text = lvLichHoc.SelectedItems[0].SubItems[4].Text;
            }    
        }

        private void btnDelete_Click(object sender, EventArgs e)
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
            command.CommandText = "Delete SCHEDULE where ScheduleID = @ma";
            command.Connection = connection;

            command.Parameters.Add("@ma", SqlDbType.Char).Value = txtMa.Text.TrimEnd();

            int ret = command.ExecuteNonQuery();
            if(ret > 0)
            {
                MessageBox.Show("Xóa thành công");
                txtMa.Text = "";
                txtMa.Enabled = true;
                cboCa.Text = "";
            }
            else
            {
                MessageBox.Show("Xóa thất bại");
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
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
            command.CommandText = "Insert into SCHEDULE values (@ma,@start,@end,@lop,@ca)";
            command.Connection = connection;

            command.Parameters.Add("@ma", SqlDbType.Char).Value = txtMa.Text.TrimEnd();
            command.Parameters.Add("@start", SqlDbType.DateTime).Value = dtStart.Value;
            command.Parameters.Add("@end", SqlDbType.DateTime).Value = dtEnd.Value;
            command.Parameters.Add("@lop", SqlDbType.Char).Value = MaLop.TrimEnd();
            command.Parameters.Add("@ca", SqlDbType.Int).Value = int.Parse(cboCa.Text.TrimEnd());


            int ret = command.ExecuteNonQuery();
            if (ret > 0)
            {
                MessageBox.Show("Thêm lịch thành công");
                txtMa.Text = "";
                txtMa.Enabled = true;
                cboCa.Text = "";
            }
            else
            {
                MessageBox.Show("Thêm lịch thất bại");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            List<Schedule> schedules = db.GetSchedules();
            schedules = schedules.Where(row => row.ClassroomID.TrimEnd() == MaLop.TrimEnd()).ToList();
            lvLichHoc.Items.Clear();
            foreach (var item in schedules)
            {
                ListViewItem item1 = new ListViewItem(item.ScheduleID);
                item1.SubItems.Add(item.StartDate.ToString());
                item1.SubItems.Add(item.EndDate.ToString());
                item1.SubItems.Add(db.getClassroomName(item.ClassroomID));
                item1.SubItems.Add(item.Ca.ToString());
                lvLichHoc.Items.Add(item1);
            }
            txtMa.Enabled = true;
            txtMa.Text = "";
            txtMa.Enabled = true;
            cboCa.Text = "";
        }

        public bool checkIsScheduleID(string ma)
        {
            List<Schedule> schedules = db.GetSchedules();
            foreach(var item in schedules)
            {
                if(item.ScheduleID.TrimEnd()==ma.TrimEnd())
                {
                    return false;
                }    
            }
            return true;
        }

        private void txtMa_Leave(object sender, EventArgs e)
        {
            if(!checkIsScheduleID(txtMa.Text.TrimEnd()))
            {
                MessageBox.Show("Trùng mã!");
            }    
        }
    }
}
