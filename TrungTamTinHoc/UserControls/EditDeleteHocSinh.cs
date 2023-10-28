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
using System.IO;

namespace TrungTamTinHoc.UserControls
{
    public partial class EditDeleteHocSinh : UserControl
    {
        public EditDeleteHocSinh()
        {
            InitializeComponent();
        }

        SqlConnection connection = null;
        private void EditDeleteHocSinh_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;
            CompanyDB db = new CompanyDB();
            cbo_Option.Items.Add("Giáo Viên");
            cbo_Option.Items.Add("Lớp");
            List<Student> students = db.GetStudents();
            foreach (var item in students)
            {
                ListViewItem i = new ListViewItem(item.StudentID);
                i.SubItems.Add(item.FirstName);
                i.SubItems.Add(item.LastName);
                i.SubItems.Add(item.Email);
                i.SubItems.Add(item.Phone);
                i.SubItems.Add(item.Birthday.ToString());
                lv_Student.Items.Add(i);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            CompanyDB db = new CompanyDB();
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
            command.CommandText = "Update Student set FirstName = @first, LastName = @last, Email = @email, Phone = @phone,Birthday = @sn where StudentID = @ma";
            command.Connection = connection;

            command.Parameters.Add("@ma", SqlDbType.Char).Value = txtId.Text.TrimEnd();
            command.Parameters.Add("@first", SqlDbType.NVarChar).Value = txtFirstName.Text.TrimEnd();
            command.Parameters.Add("@last", SqlDbType.NVarChar).Value = txtLastName.Text.TrimEnd();
            command.Parameters.Add("@email", SqlDbType.VarChar).Value = txtEmail.Text.TrimEnd();
            command.Parameters.Add("@phone", SqlDbType.VarChar).Value = txtPhone.Text.TrimEnd();
            command.Parameters.Add("@sn", SqlDbType.DateTime).Value = dt_Birthday.Value;


            int ret = command.ExecuteNonQuery();
            if(ret > 0)
            {
                MessageBox.Show("Sửa thành công!");
            }
            else
            {
                MessageBox.Show("Sửa thất bại!");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            cbo_Option.Text = "Option";
            cbo_Select.Text = "";
            cbo_Select.Enabled = false;
            txtSearch.Text = "";
            lv_Student.Items.Clear();
            CompanyDB db = new CompanyDB();
            List<Student> students = db.GetStudents();
            foreach (var item in students)
            {
                ListViewItem i = new ListViewItem(item.StudentID);
                i.SubItems.Add(item.FirstName);
                i.SubItems.Add(item.LastName);
                i.SubItems.Add(item.Email);
                i.SubItems.Add(item.Phone);
                i.SubItems.Add(item.Birthday.ToString());
                lv_Student.Items.Add(i);
            }
            txtId.Text = "";
            txtEmail.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtPhone.Text = "";
            
        }

        private void cbo_Select_SelectedIndexChanged(object sender, EventArgs e)
        {
            CompanyDB db = new CompanyDB();
            if (connection == null)
            {
                connection = new SqlConnection(db.strcon);
            }
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            List<Models.ManagerClass> managerClasses = db.GetManagerClasses();
            List<Teacher> teachers = db.GetTeachers();
            List<Classrooms> classrooms = db.GetClassrooms();
            string magv = "";
            string malop = "";
            List<string> mahs = new List<string>();
            List<string> malops = new List<string>();
            foreach (var item in classrooms)
            {
                if (item.ClassromName == cbo_Select.Text)
                {
                    malop = item.ClassromID;
                }
            }
            foreach (var item in teachers)
            {
                string name = item.FirstName + " " + item.LastName;
                if (name == cbo_Select.Text)
                {
                    magv = item.TeacherID;
                }
            }
            foreach (var item in managerClasses)
            {
                if (magv == item.TeacherID)
                {
                    mahs.Add(item.StudentID);
                }
                if (malop == item.ClassroomID)
                {
                    malops.Add(item.StudentID);
                }
            }

            if (cbo_Option.SelectedIndex == 0)
            {
                lv_Student.Items.Clear();
                foreach (string i in mahs)
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.Text;
                    command.CommandText = "Select * from Student where StudentID = @ma";
                    command.Connection = connection;

                    command.Parameters.Add("@ma", SqlDbType.Char).Value = i.TrimEnd();

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader.GetString(0));
                        item.SubItems.Add(reader.GetString(1));
                        item.SubItems.Add(reader.GetString(2));
                        item.SubItems.Add(reader.GetString(3));
                        item.SubItems.Add(reader.GetString(4));
                        item.SubItems.Add(reader.GetDateTime(5).ToString());
                        lv_Student.Items.Add(item);
                    }
                    reader.Close();
                }
            }
            else
            {
                lv_Student.Items.Clear();
                foreach (string i in malops)
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.Text;
                    command.CommandText = "Select * from Student where StudentID = @ma";
                    command.Connection = connection;

                    command.Parameters.Add("@ma", SqlDbType.Char).Value = i.TrimEnd();

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader.GetString(0));
                        item.SubItems.Add(reader.GetString(1));
                        item.SubItems.Add(reader.GetString(2));
                        item.SubItems.Add(reader.GetString(3));
                        item.SubItems.Add(reader.GetString(4));
                        item.SubItems.Add(reader.GetDateTime(5).ToString());
                        lv_Student.Items.Add(item);
                    }
                    reader.Close();
                }
            }
        }

        private void cbo_Option_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbo_Select.Enabled = true;
            CompanyDB db = new CompanyDB();
            List<Classrooms> classrooms = db.GetClassrooms();
            List<Teacher> teachers = db.GetTeachers();
            cbo_Select.Items.Clear();
            if (cbo_Option.SelectedIndex == 0)
            {
                cbo_Select.Text = "Giáo Viên";
                foreach (var item in teachers)
                {
                    string name = item.FirstName + " " + item.LastName;
                    cbo_Select.Items.Add(name);
                }
            }
            else
            {
                cbo_Select.Text = "Lớp";
                foreach (var item in classrooms)
                {
                    cbo_Select.Items.Add(item.ClassromName);
                }
            }
        }

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            cbo_Option.Text = "Option";
            cbo_Select.Text = "";
            cbo_Select.Enabled = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            CompanyDB db = new CompanyDB();
            List<Student> lstst = new List<Student>();
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
            command.CommandText = "SELECT * FROM dbo.SearchStudents(@search)";
            command.Connection = connection;
            command.Parameters.Add("@search", SqlDbType.Char).Value = txtSearch.Text.TrimEnd();
            lv_Student.Items.Clear();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ListViewItem item = new ListViewItem(reader.GetString(0));
                item.SubItems.Add(reader.GetString(1));
                item.SubItems.Add(reader.GetString(2));
                item.SubItems.Add(reader.GetString(3));
                item.SubItems.Add(reader.GetString(4));
                item.SubItems.Add(reader.GetDateTime(5).ToString());
                lv_Student.Items.Add(item);
            }
            reader.Close();
        }

        private void lv_Student_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.DeepSkyBlue, e.Bounds); // Đặt màu nền cho header
            TextRenderer.DrawText(e.Graphics, e.Header.Text, e.Font, e.Bounds, Color.Black); // Vẽ văn bản
        }

        private void lv_Student_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void lv_Student_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lv_Student.SelectedItems.Count > 0)
            {
                txtId.Text = lv_Student.SelectedItems[0].SubItems[0].Text;
                txtFirstName.Text = lv_Student.SelectedItems[0].SubItems[1].Text;
                txtLastName.Text = lv_Student.SelectedItems[0].SubItems[2].Text;
                txtEmail.Text = lv_Student.SelectedItems[0].SubItems[3].Text;
                txtPhone.Text = lv_Student.SelectedItems[0].SubItems[4].Text;
                dt_Birthday.Value = DateTime.Parse(lv_Student.SelectedItems[0].SubItems[5].Text);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn chắc chắn muốn xóa "+txtFirstName.Text.TrimEnd()+" " + txtLastName.Text.TrimEnd(),"Thông báo", MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                CompanyDB db = new CompanyDB();
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
                command.CommandText = "Delete Student where StudentID = @ma";
                command.Connection = connection;

                command.Parameters.Add("@ma", SqlDbType.Char).Value = txtId.Text.TrimEnd();

                int ret = command.ExecuteNonQuery();
                if (ret > 0)
                {
                    MessageBox.Show("Xóa thành công!");
                    txtId.Text = "";
                    txtEmail.Text = "";
                    txtFirstName.Text = "";
                    txtLastName.Text = "";
                    txtPhone.Text = "";
                }
                else
                {
                    MessageBox.Show("Xóa thất bại!");
                }
            }    
        }
        public void ExportFile(DataTable dataTable, string sheetName, string title)
        {
            //Tạo các đối tượng Excel

            Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();

            Microsoft.Office.Interop.Excel.Workbooks oBooks;

            Microsoft.Office.Interop.Excel.Sheets oSheets;

            Microsoft.Office.Interop.Excel.Workbook oBook;

            Microsoft.Office.Interop.Excel.Worksheet oSheet;

            //Tạo mới một Excel WorkBook 

            oExcel.Visible = true;

            oExcel.DisplayAlerts = false;

            oExcel.Application.SheetsInNewWorkbook = 1;

            oBooks = oExcel.Workbooks;

            oBook = (Microsoft.Office.Interop.Excel.Workbook)(oExcel.Workbooks.Add(Type.Missing));

            oSheets = oBook.Worksheets;

            oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(1);

            oSheet.Name = sheetName;

            // Tạo phần Tiêu đề
            Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A1", "F1");

            head.MergeCells = true;

            head.Value2 = title;

            head.Font.Bold = true;

            head.Font.Name = "Times New Roman";

            head.Font.Size = "20";

            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            // Tạo tiêu đề cột 

            Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A3", "A3");

            cl1.Value2 = "StudentID";

            cl1.ColumnWidth = 12;

            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B3", "B3");

            cl2.Value2 = "First Name";

            cl2.ColumnWidth = 25.0;

            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C3", "C3");

            cl3.Value2 = "Last Name";
            cl3.ColumnWidth = 12.0;

            Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D3", "D3");

            cl4.Value2 = "Email";

            cl4.ColumnWidth = 30.0;

            Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E3", "E3");

            cl5.Value2 = "Phone";

            cl5.ColumnWidth = 20.5;

            Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("F3", "F3");

            cl6.Value2 = "Birthday";

            cl6.ColumnWidth = 18.5;

          

            Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("A3", "F3");

            rowHead.Font.Bold = true;

            // Kẻ viền

            rowHead.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

            // Thiết lập màu nền

            rowHead.Interior.ColorIndex = 6;

            rowHead.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            // Tạo mảng theo datatable

            object[,] arr = new object[dataTable.Rows.Count, dataTable.Columns.Count];

            //Chuyển dữ liệu từ DataTable vào mảng đối tượng

            for (int row = 0; row < dataTable.Rows.Count; row++)
            {
                DataRow dataRow = dataTable.Rows[row];

                for (int col = 0; col < dataTable.Columns.Count; col++)
                {
                    arr[row, col] = dataRow[col];
                }
            }

            //Thiết lập vùng điền dữ liệu

            int rowStart = 4;

            int columnStart = 1;

            int rowEnd = rowStart + dataTable.Rows.Count - 2;

            int columnEnd = dataTable.Columns.Count;

            // Ô bắt đầu điền dữ liệu

            Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart];

            // Ô kết thúc điền dữ liệu

            Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];

            // Lấy về vùng điền dữ liệu

            Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c1, c2);

            //Điền dữ liệu vào vùng đã thiết lập

            range.Value2 = arr;

            // Kẻ viền

            range.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

            // Căn giữa cột mã nhân viên

            //Microsoft.Office.Interop.Excel.Range c3 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnStart];

            //Microsoft.Office.Interop.Excel.Range c4 = oSheet.get_Range(c1, c3);

            //Căn giữa cả bảng 
            oSheet.get_Range(c1, c2).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
        }
        private void btnSaveExcel_Click(object sender, EventArgs e)
        {
            DataTable datatable = new DataTable();

            DataColumn c1 = new DataColumn("StudentID");
            DataColumn c2 = new DataColumn("FirstName");
            DataColumn c3 = new DataColumn("LastName");
            DataColumn c4 = new DataColumn("Email");
            DataColumn c5 = new DataColumn("Phone");
            DataColumn c6 = new DataColumn("Birthday");

            datatable.Columns.Add(c1);
            datatable.Columns.Add(c2);
            datatable.Columns.Add(c3);
            datatable.Columns.Add(c4);
            datatable.Columns.Add(c5);
            datatable.Columns.Add(c6);

            for(int i=0;i<lv_Student.Items.Count;i++)
            {
                DataRow dtorw = datatable.NewRow();
                for(int j=0;j<6;j++)
                {
                    dtorw[j] = lv_Student.Items[i].SubItems[j].Text;
                }
                datatable.Rows.Add(dtorw);
            }

            ExportFile(datatable, "Danh sach", "DANH SÁCH HỌC VIÊN");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dt_Birthday_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMa_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
