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

namespace TrungTamTinHoc.UserControls
{
    public partial class CongNoUser : UserControl
    {
        SqlConnection connection = null;
        CompanyDB db = new CompanyDB();
        public string mahs = null;
        public CongNoUser()
        {
            InitializeComponent();
        }

        public CongNoUser(string id)
        {
            mahs = id;
            InitializeComponent();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtMa.Text = "";
            txtStudent.Text = "";
            txtClass.Text = "";
            txtMoney.Text = "";
            txtActive.Text = "";
            List<Payments> p = db.GetPayments().Where(row => row.StudentID.TrimEnd() == mahs.TrimEnd()).ToList();
            lv_report.Items.Clear();
            foreach(var item in p)
            {
                ListViewItem item1 = new ListViewItem(item.PaymentsID);
                item1.SubItems.Add(db.GetStudentName(item.StudentID.TrimEnd()));
                item1.SubItems.Add(db.getClassroomName(item.ClassromID.TrimEnd()));
                item1.SubItems.Add(item.AmountOfMoney + "");
                item1.SubItems.Add(item.Active);
                lv_report.Items.Add(item1);
            }    
        }

        private void CongNoUser_Load(object sender, EventArgs e)
        {
            List<Payments> p = db.GetPayments().Where(row => row.StudentID.TrimEnd() == mahs.TrimEnd()).ToList();
            lv_report.Items.Clear();
            foreach (var item in p)
            {
                ListViewItem item1 = new ListViewItem(item.PaymentsID);
                item1.SubItems.Add(db.GetStudentName(item.StudentID.TrimEnd()));
                item1.SubItems.Add(db.getClassroomName(item.ClassromID.TrimEnd()));
                item1.SubItems.Add(item.AmountOfMoney + "");
                item1.SubItems.Add(item.Active);
                lv_report.Items.Add(item1);
            }
        }

        private void lv_report_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lv_report.SelectedItems.Count > 0)
            {
                txtMa.Text = lv_report.SelectedItems[0].SubItems[0].Text;
                txtStudent.Text = lv_report.SelectedItems[0].SubItems[1].Text;
                txtClass.Text = lv_report.SelectedItems[0].SubItems[2].Text;
                txtMoney.Text = lv_report.SelectedItems[0].SubItems[3].Text;
                txtActive.Text = lv_report.SelectedItems[0].SubItems[4].Text;
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
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update PAYMENTS set Active = 'Yes', MoneyDate= @date where PaymentsID = @ma";
            cmd.Connection = connection;

            cmd.Parameters.Add("@date", SqlDbType.DateTime).Value = DateTime.Now;
            cmd.Parameters.Add("@ma", SqlDbType.Char).Value = txtMa.Text.TrimEnd();

            int ret = cmd.ExecuteNonQuery();
            if (ret > 0)
            {
                MessageBox.Show("Thanh toán thành công!");
            }
            else
            {
                MessageBox.Show("Error!!!!", "Message", MessageBoxButtons.RetryCancel);
            }
        }
    }
}
