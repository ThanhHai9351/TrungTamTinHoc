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
    public partial class Reporting : UserControl
    {
        CompanyDB db = new CompanyDB();
        public Reporting()
        {
            InitializeComponent();
        }

        private void Reporting_Load(object sender, EventArgs e)
        {
            cbo_Select.Items.Add("Học Sinh");
            cbo_Select.Items.Add("Giáo Viên");
            cbo_Select.Items.Add("Lớp");
            cbo_Select.Items.Add("Doanh Thu");
        }

        private void cbo_Select_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbo_Select.Text.TrimEnd()=="Học Sinh")
            {
                rptHocSinh rpt = new rptHocSinh();
                rpt.SetDataSource(db.GetStudents());
                crystalReportViewer1.ReportSource = rpt;
            }    
            if(cbo_Select.Text.TrimEnd()=="Giáo Viên")
            {
                rptGiaoVien rpt = new rptGiaoVien();
                rpt.SetDataSource(db.GetTeachers());
                crystalReportViewer1.ReportSource = rpt;
            }
            if (cbo_Select.Text.TrimEnd() == "Lớp")
            {
                rptLop rpt = new rptLop();
                rpt.SetDataSource(db.GetClassrooms());
                crystalReportViewer1.ReportSource = rpt;
            }
            if (cbo_Select.Text.TrimEnd() == "Doanh Thu")
            {
                rptDanhThu rpt = new rptDanhThu();
                rpt.SetDataSource(db.GetPayments());
                crystalReportViewer1.ReportSource = rpt;
            }
        }
    }
}
