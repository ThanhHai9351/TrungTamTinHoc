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
    public partial class EditDeleteGV : UserControl
    {
        public EditDeleteGV()
        {
            InitializeComponent();
        }

        SqlConnection connection = null;
        private void EditDeleteGV_Load(object sender, EventArgs e)
        {
            CompanyDB db = new CompanyDB();
            List<Teacher> teachers = db.GetTeachers();
            foreach (var item in teachers)
            {
                ListViewItem i = new ListViewItem(item.TeacherID);
                i.SubItems.Add(item.FirstName);
                i.SubItems.Add(item.LastName);
                i.SubItems.Add(item.Email);
                i.SubItems.Add(item.Phone);
                i.SubItems.Add(item.Birthday.ToString());
                lv_Student.Items.Add(i);
            }
            List<Classrooms> classrooms = db.GetClassrooms();
            foreach (var item in classrooms)
            {
                cbo_Select.Items.Add(item.ClassromName);
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
            command.CommandText = "Update Teacher set FirstName = @first, LastName = @last, Email = @email, Phone = @phone,Birthday = @sn where TeacherID = @ma";
            command.Connection = connection;

            command.Parameters.Add("@ma", SqlDbType.Char).Value = txtId.Text.TrimEnd();
            command.Parameters.Add("@first", SqlDbType.NVarChar).Value = txtFirstName.Text.TrimEnd();
            command.Parameters.Add("@last", SqlDbType.NVarChar).Value = txtLastName.Text.TrimEnd();
            command.Parameters.Add("@email", SqlDbType.VarChar).Value = txtEmail.Text.TrimEnd();
            command.Parameters.Add("@phone", SqlDbType.VarChar).Value = txtPhone.Text.TrimEnd();
            command.Parameters.Add("@sn", SqlDbType.DateTime).Value = dt_Birthday.Value;


            int ret = command.ExecuteNonQuery();
            if (ret > 0)
            {
                MessageBox.Show("Sửa thành công!");
            }
            else
            {
                MessageBox.Show("Sửa thất bại!");
            }
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            cbo_Select.Items.Clear();
            lv_Student.Items.Clear();
            txtSearch.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            dt_Birthday.Text = "";
            txtId.Text = "";
            txtLastName.Text = "";
            txtFirstName.Text = "";
            CompanyDB db = new CompanyDB();
            List<Teacher> teachers = db.GetTeachers();
            foreach (var item in teachers)
            {
                ListViewItem i = new ListViewItem(item.TeacherID);
                i.SubItems.Add(item.FirstName);
                i.SubItems.Add(item.LastName);
                i.SubItems.Add(item.Email);
                i.SubItems.Add(item.Phone);
                i.SubItems.Add(item.Birthday.ToString());
                lv_Student.Items.Add(i);
            }
            List<Classrooms> classrooms = db.GetClassrooms();
            foreach (var item in classrooms)
            {
                cbo_Select.Items.Add(item.ClassromName);
            }
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
            string malop = "";
            List<string> magv = new List<string>();
            foreach (var item in classrooms)
            {
                if (item.ClassromName.TrimEnd() == cbo_Select.Text.TrimEnd())
                {
                    malop = item.ClassromID;
                }
            }
            foreach (var item in managerClasses)
            {
                if (item.ClassroomID == malop)
                {
                    if (magv.Contains(item.TeacherID))
                    {
                        continue;
                    }
                    else
                    {
                        magv.Add(item.TeacherID);

                    }
                }
            }
            lv_Student.Items.Clear();
            foreach (string i in magv)
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "Select * from Teacher where TeacherID = @ma";
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

        private void btnSearch_Click(object sender, EventArgs e)
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
            command.CommandText = "SELECT * FROM dbo.SearchTeachers(@search)";
            command.Connection = connection;
            command.Parameters.Add("@search", SqlDbType.NVarChar).Value = txtSearch.Text.TrimEnd();
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

        private void lv_Student_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lv_Student.SelectedItems.Count > 0)
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
            if (MessageBox.Show("Bạn chắc chắn muốn xóa " + txtFirstName.Text.TrimEnd() + " " + txtLastName.Text.TrimEnd(), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
                command.CommandText = "Delete Teacher where TeacherID = @ma";
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
            cl1.Value2 = "TeacherID";
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

            for (int i = 0; i < lv_Student.Items.Count; i++)
            {
                DataRow dtorw = datatable.NewRow();
                for (int j = 0; j < 6; j++)
                {
                    dtorw[j] = lv_Student.Items[i].SubItems[j].Text;
                }
                datatable.Rows.Add(dtorw);
            }

            ExportFile(datatable, "Danh sach", "DANH SÁCH GIẢNG VIÊN");
        }
    }
}
