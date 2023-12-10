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
using TrungTamTinHoc.Forms;

namespace TrungTamTinHoc.UserControls
{
    public partial class EditDeleteLop : UserControl
    {
        public EditDeleteLop()
        {
            InitializeComponent();
        }
        SqlConnection connection = null;
        private void EditDeleteLop_Load(object sender, EventArgs e)
        {
            CompanyDB db = new CompanyDB();
            List<Teacher> teachers = db.GetTeachers();
            List<Classrooms> classrooms = db.GetClassrooms();
            foreach (var item in teachers)
            {
                string name = item.FirstName + " " + item.LastName;
                cbo_Select.Items.Add(name);
                cbo_teacher.Items.Add(name);
            }
            foreach (var item in classrooms)
            {
                ListViewItem i = new ListViewItem(item.ClassromID);
                i.SubItems.Add(item.ClassromName);
                i.SubItems.Add(item.Capacity + "");
                i.SubItems.Add(db.getTeacherName(item.TeacherID));
                i.SubItems.Add(item.AmountOfMoney + "");
                lv_Class.Items.Add(i);
            }
            cbo_teacher.SelectedIndex = 0;
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
            command.CommandText = "Update Classrooms set ClassroomName = @ten, Capacity = @ss, AmountOfMoney = @money where ClassroomId = @ma";
            command.Connection = connection;

            command.Parameters.Add("@ma", SqlDbType.Char).Value = txtId.Text.TrimEnd();
            command.Parameters.Add("@ten", SqlDbType.NVarChar).Value = txtName.Text.TrimEnd();
            command.Parameters.Add("@ss", SqlDbType.Int).Value = int.Parse(txtSiSo.Text);
            command.Parameters.Add("@money", SqlDbType.Int).Value = int.Parse(txtMoney.Text);

            int ret = command.ExecuteNonQuery();
            if (ret > 0)
            {
                MessageBox.Show("Bạn đã sửa thành công!");
           
            }
            else
            {
                MessageBox.Show("Bạn đã sửa thất bại!");
            }
        }

        private void lv_Class_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.DeepSkyBlue, e.Bounds); // Đặt màu nền cho header
            TextRenderer.DrawText(e.Graphics, e.Header.Text, e.Font, e.Bounds, Color.Black); // Vẽ văn bản
        }

        private void lv_Class_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void lv_Class_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lv_Class.SelectedItems.Count>0)
            {
                txtId.Text = lv_Class.SelectedItems[0].SubItems[0].Text;
                txtName.Text = lv_Class.SelectedItems[0].SubItems[1].Text;
                txtSiSo.Text = lv_Class.SelectedItems[0].SubItems[2].Text;
                cbo_teacher.Text = lv_Class.SelectedItems[0].SubItems[3].Text;
                txtMoney.Text = lv_Class.SelectedItems[0].SubItems[4].Text;
            }
        }

        private void cbo_Select_SelectedIndexChanged(object sender, EventArgs e)
        {
            CompanyDB db = new CompanyDB();
            List<Teacher> teachers = db.GetTeachers();
            List<Classrooms> classrooms = db.GetClassrooms();
            string magv = "";
            foreach (var item in teachers)
            {
                string name = item.FirstName + " " + item.LastName;
                if (name == cbo_Select.Text)
                {
                    magv = item.TeacherID;
                }
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
            command.CommandText = "Select * from Classrooms where TeacherID = @ma";
            command.Connection = connection;

            command.Parameters.Add("@ma", SqlDbType.Char).Value = magv;

            lv_Class.Items.Clear();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ListViewItem i = new ListViewItem(reader.GetString(0));
                i.SubItems.Add(reader.GetString(1));
                i.SubItems.Add(reader.GetInt32(2) + "");
                i.SubItems.Add(db.getTeacherName(reader.GetString(3)));
                i.SubItems.Add(reader.GetInt32(4) + "");
                lv_Class.Items.Add(i);
            }
            reader.Close();
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
            command.CommandText = "SELECT * FROM dbo.SearchClassrooms(@search)";
            command.Connection = connection;
            command.Parameters.Add("@search", SqlDbType.NVarChar).Value = txtSearch.Text.TrimEnd();
            lv_Class.Items.Clear();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ListViewItem item = new ListViewItem(reader.GetString(0));
                item.SubItems.Add(reader.GetString(1));
                item.SubItems.Add(reader.GetInt32(2) + "");
                item.SubItems.Add(db.getTeacherName(reader.GetString(3)));
                item.SubItems.Add(reader.GetInt32(4) + "");
                lv_Class.Items.Add(item);
            }
            reader.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            cbo_Select.Text = "Giáo Viên";
            txtId.Text = "";
            txtName.Text = "";
            txtSiSo.Text = "";
            txtMoney.Text = "";
            CompanyDB db = new CompanyDB();
            List<Classrooms> classrooms = db.GetClassrooms();
            lv_Class.Items.Clear();
            foreach (var item in classrooms)
            {
                ListViewItem i = new ListViewItem(item.ClassromID);
                i.SubItems.Add(item.ClassromName);
                i.SubItems.Add(item.Capacity + "");
                i.SubItems.Add(db.getTeacherName(item.TeacherID));
                i.SubItems.Add(item.AmountOfMoney + "");
                lv_Class.Items.Add(i);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn muốn xóa " + txtName.Text, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
                command.CommandText = "Delete Classrooms where ClassroomID = @ma";
                command.Connection = connection;

                command.Parameters.Add("@ma", SqlDbType.Char).Value = txtId.Text.TrimEnd();

                int ret = command.ExecuteNonQuery();
                if (ret > 0)
                {
                    MessageBox.Show("Xóa thành công!");
                    txtId.Text = "";
                    txtName.Text = "";
                    txtSiSo.Text = "";
                    txtMoney.Text = "";
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
            Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A1", "E1");

            head.MergeCells = true;

            head.Value2 = title;

            head.Font.Bold = true;

            head.Font.Name = "Times New Roman";

            head.Font.Size = "20";

            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            // Tạo tiêu đề cột 

            Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A3", "A3");

            cl1.Value2 = "ClassroomID";

            cl1.ColumnWidth = 12;

            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B3", "B3");

            cl2.Value2 = "ClassroomName";

            cl2.ColumnWidth = 25.0;

            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C3", "C3");

            cl3.Value2 = "Capacity";
            cl3.ColumnWidth = 12.0;

            Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D3", "D3");

            cl4.Value2 = "Teacher";

            cl4.ColumnWidth = 30.0;

            Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E3", "E3");

            cl5.Value2 = "AmountOfMoney";

            cl5.ColumnWidth = 20.5;


            Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("A3", "E3");

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

            DataColumn c1 = new DataColumn("ClassroomID");
            DataColumn c2 = new DataColumn("ClassroomName");
            DataColumn c3 = new DataColumn("Capacity");
            DataColumn c4 = new DataColumn("Teacher");
            DataColumn c5 = new DataColumn("AmountOfMoney");

            datatable.Columns.Add(c1);
            datatable.Columns.Add(c2);
            datatable.Columns.Add(c3);
            datatable.Columns.Add(c4);
            datatable.Columns.Add(c5);

            for (int i = 0; i < lv_Class.Items.Count; i++)
            {
                DataRow dtorw = datatable.NewRow();
                for (int j = 0; j < 5; j++)
                {
                    dtorw[j] = lv_Class.Items[i].SubItems[j].Text;
                }
                datatable.Rows.Add(dtorw);
            }

            ExportFile(datatable, "Danh sach", "DANH SÁCH LỚP");
        }

        private void mởLịchHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(lv_Class.SelectedItems.Count > 0)
            {
                CreateLichHoc frm = new CreateLichHoc(lv_Class.SelectedItems[0].SubItems[0].Text.TrimEnd());
                frm.ShowDialog();
            }    
        }
    }
}
