
namespace TrungTamTinHoc.Forms
{
    partial class frmHomeAdmin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHomeAdmin));
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnReporting = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSupport = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.panelClass = new System.Windows.Forms.Panel();
            this.btnLichHoc = new System.Windows.Forms.Button();
            this.btnThongTinLop = new System.Windows.Forms.Button();
            this.btnEditDeleteLop = new System.Windows.Forms.Button();
            this.btnAddLop = new System.Windows.Forms.Button();
            this.btnLop = new System.Windows.Forms.Button();
            this.panelTeacher = new System.Windows.Forms.Panel();
            this.btnEditDeleteGV = new System.Windows.Forms.Button();
            this.btnThemGV = new System.Windows.Forms.Button();
            this.btnGV = new System.Windows.Forms.Button();
            this.panelStudent = new System.Windows.Forms.Panel();
            this.btnEditDeleteHS = new System.Windows.Forms.Button();
            this.btnAddHS = new System.Windows.Forms.Button();
            this.btnHocSinh = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelMenu.SuspendLayout();
            this.panelClass.SuspendLayout();
            this.panelTeacher.SuspendLayout();
            this.panelStudent.SuspendLayout();
            this.panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.AutoScroll = true;
            this.panelMenu.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panelMenu.Controls.Add(this.btnReporting);
            this.panelMenu.Controls.Add(this.btnExit);
            this.panelMenu.Controls.Add(this.btnSupport);
            this.panelMenu.Controls.Add(this.btnReport);
            this.panelMenu.Controls.Add(this.panelClass);
            this.panelMenu.Controls.Add(this.btnLop);
            this.panelMenu.Controls.Add(this.panelTeacher);
            this.panelMenu.Controls.Add(this.btnGV);
            this.panelMenu.Controls.Add(this.panelStudent);
            this.panelMenu.Controls.Add(this.btnHocSinh);
            this.panelMenu.Controls.Add(this.btnHome);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(197, 620);
            this.panelMenu.TabIndex = 0;
            this.panelMenu.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMenu_Paint);
            // 
            // btnReporting
            // 
            this.btnReporting.BackColor = System.Drawing.Color.SteelBlue;
            this.btnReporting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReporting.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReporting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReporting.ForeColor = System.Drawing.Color.Azure;
            this.btnReporting.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReporting.ImageKey = "reporting.png";
            this.btnReporting.ImageList = this.imageList1;
            this.btnReporting.Location = new System.Drawing.Point(0, 750);
            this.btnReporting.Name = "btnReporting";
            this.btnReporting.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnReporting.Size = new System.Drawing.Size(176, 45);
            this.btnReporting.TabIndex = 11;
            this.btnReporting.Text = "Báo Cáo";
            this.btnReporting.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReporting.UseVisualStyleBackColor = false;
            this.btnReporting.Click += new System.EventHandler(this.btnReporting_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "home.png");
            this.imageList1.Images.SetKeyName(1, "graduated.png");
            this.imageList1.Images.SetKeyName(2, "add.png");
            this.imageList1.Images.SetKeyName(3, "editdelete.png");
            this.imageList1.Images.SetKeyName(4, "teacher.png");
            this.imageList1.Images.SetKeyName(5, "Class.png");
            this.imageList1.Images.SetKeyName(6, "help-desk.png");
            this.imageList1.Images.SetKeyName(7, "logout.png");
            this.imageList1.Images.SetKeyName(8, "report.png");
            this.imageList1.Images.SetKeyName(9, "personal-information.png");
            this.imageList1.Images.SetKeyName(10, "training.png");
            this.imageList1.Images.SetKeyName(11, "timetable.png");
            this.imageList1.Images.SetKeyName(12, "management.png");
            this.imageList1.Images.SetKeyName(13, "reporting.png");
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.SteelBlue;
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.ForeColor = System.Drawing.Color.Azure;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.ImageKey = "logout.png";
            this.btnExit.ImageList = this.imageList1;
            this.btnExit.Location = new System.Drawing.Point(0, 795);
            this.btnExit.Name = "btnExit";
            this.btnExit.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnExit.Size = new System.Drawing.Size(176, 45);
            this.btnExit.TabIndex = 10;
            this.btnExit.Text = "Đăng Xuất";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSupport
            // 
            this.btnSupport.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSupport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSupport.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSupport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSupport.ForeColor = System.Drawing.Color.Azure;
            this.btnSupport.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSupport.ImageKey = "help-desk.png";
            this.btnSupport.ImageList = this.imageList1;
            this.btnSupport.Location = new System.Drawing.Point(0, 705);
            this.btnSupport.Name = "btnSupport";
            this.btnSupport.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnSupport.Size = new System.Drawing.Size(176, 45);
            this.btnSupport.TabIndex = 9;
            this.btnSupport.Text = "Hỗ Trợ";
            this.btnSupport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSupport.UseVisualStyleBackColor = false;
            this.btnSupport.Click += new System.EventHandler(this.btnSupport_Click);
            // 
            // btnReport
            // 
            this.btnReport.BackColor = System.Drawing.Color.SteelBlue;
            this.btnReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReport.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReport.ForeColor = System.Drawing.Color.Azure;
            this.btnReport.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReport.ImageKey = "report.png";
            this.btnReport.ImageList = this.imageList1;
            this.btnReport.Location = new System.Drawing.Point(0, 660);
            this.btnReport.Name = "btnReport";
            this.btnReport.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnReport.Size = new System.Drawing.Size(176, 45);
            this.btnReport.TabIndex = 8;
            this.btnReport.Text = "Doanh Thu";
            this.btnReport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReport.UseVisualStyleBackColor = false;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // panelClass
            // 
            this.panelClass.Controls.Add(this.btnLichHoc);
            this.panelClass.Controls.Add(this.btnThongTinLop);
            this.panelClass.Controls.Add(this.btnEditDeleteLop);
            this.panelClass.Controls.Add(this.btnAddLop);
            this.panelClass.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelClass.Location = new System.Drawing.Point(0, 481);
            this.panelClass.Name = "panelClass";
            this.panelClass.Size = new System.Drawing.Size(176, 179);
            this.panelClass.TabIndex = 7;
            // 
            // btnLichHoc
            // 
            this.btnLichHoc.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnLichHoc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLichHoc.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLichHoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLichHoc.Font = new System.Drawing.Font("Leelawadee UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLichHoc.ForeColor = System.Drawing.Color.Azure;
            this.btnLichHoc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLichHoc.ImageKey = "timetable.png";
            this.btnLichHoc.ImageList = this.imageList1;
            this.btnLichHoc.Location = new System.Drawing.Point(0, 135);
            this.btnLichHoc.Name = "btnLichHoc";
            this.btnLichHoc.Size = new System.Drawing.Size(176, 45);
            this.btnLichHoc.TabIndex = 4;
            this.btnLichHoc.Text = "Lịch Học";
            this.btnLichHoc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLichHoc.UseVisualStyleBackColor = false;
            this.btnLichHoc.Click += new System.EventHandler(this.btnLichHoc_Click);
            // 
            // btnThongTinLop
            // 
            this.btnThongTinLop.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnThongTinLop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThongTinLop.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnThongTinLop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThongTinLop.Font = new System.Drawing.Font("Leelawadee UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThongTinLop.ForeColor = System.Drawing.Color.Azure;
            this.btnThongTinLop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThongTinLop.ImageKey = "personal-information.png";
            this.btnThongTinLop.ImageList = this.imageList1;
            this.btnThongTinLop.Location = new System.Drawing.Point(0, 90);
            this.btnThongTinLop.Name = "btnThongTinLop";
            this.btnThongTinLop.Size = new System.Drawing.Size(176, 45);
            this.btnThongTinLop.TabIndex = 3;
            this.btnThongTinLop.Text = "Quản Lý Lớp";
            this.btnThongTinLop.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThongTinLop.UseVisualStyleBackColor = false;
            this.btnThongTinLop.Click += new System.EventHandler(this.btnThongTinLop_Click);
            // 
            // btnEditDeleteLop
            // 
            this.btnEditDeleteLop.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnEditDeleteLop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditDeleteLop.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEditDeleteLop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditDeleteLop.Font = new System.Drawing.Font("Leelawadee UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditDeleteLop.ForeColor = System.Drawing.Color.Azure;
            this.btnEditDeleteLop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditDeleteLop.ImageKey = "editdelete.png";
            this.btnEditDeleteLop.ImageList = this.imageList1;
            this.btnEditDeleteLop.Location = new System.Drawing.Point(0, 45);
            this.btnEditDeleteLop.Name = "btnEditDeleteLop";
            this.btnEditDeleteLop.Size = new System.Drawing.Size(176, 45);
            this.btnEditDeleteLop.TabIndex = 1;
            this.btnEditDeleteLop.Text = "Sửa,Xóa Lớp";
            this.btnEditDeleteLop.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditDeleteLop.UseVisualStyleBackColor = false;
            this.btnEditDeleteLop.Click += new System.EventHandler(this.btnEditDeleteLop_Click);
            // 
            // btnAddLop
            // 
            this.btnAddLop.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAddLop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddLop.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAddLop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddLop.Font = new System.Drawing.Font("Leelawadee UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddLop.ForeColor = System.Drawing.Color.Azure;
            this.btnAddLop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddLop.ImageIndex = 2;
            this.btnAddLop.ImageList = this.imageList1;
            this.btnAddLop.Location = new System.Drawing.Point(0, 0);
            this.btnAddLop.Name = "btnAddLop";
            this.btnAddLop.Size = new System.Drawing.Size(176, 45);
            this.btnAddLop.TabIndex = 0;
            this.btnAddLop.Text = "Thêm Lớp";
            this.btnAddLop.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddLop.UseVisualStyleBackColor = false;
            this.btnAddLop.Click += new System.EventHandler(this.btnAddLop_Click);
            // 
            // btnLop
            // 
            this.btnLop.BackColor = System.Drawing.Color.SteelBlue;
            this.btnLop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLop.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLop.Font = new System.Drawing.Font("Leelawadee UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLop.ForeColor = System.Drawing.Color.Azure;
            this.btnLop.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLop.ImageKey = "Class.png";
            this.btnLop.ImageList = this.imageList1;
            this.btnLop.Location = new System.Drawing.Point(0, 436);
            this.btnLop.Name = "btnLop";
            this.btnLop.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnLop.Size = new System.Drawing.Size(176, 45);
            this.btnLop.TabIndex = 6;
            this.btnLop.Text = "Lớp Học";
            this.btnLop.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLop.UseVisualStyleBackColor = false;
            this.btnLop.Click += new System.EventHandler(this.btnLop_Click);
            // 
            // panelTeacher
            // 
            this.panelTeacher.Controls.Add(this.btnEditDeleteGV);
            this.panelTeacher.Controls.Add(this.btnThemGV);
            this.panelTeacher.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTeacher.Location = new System.Drawing.Point(0, 340);
            this.panelTeacher.Name = "panelTeacher";
            this.panelTeacher.Size = new System.Drawing.Size(176, 96);
            this.panelTeacher.TabIndex = 5;
            // 
            // btnEditDeleteGV
            // 
            this.btnEditDeleteGV.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnEditDeleteGV.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditDeleteGV.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEditDeleteGV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditDeleteGV.Font = new System.Drawing.Font("Leelawadee UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditDeleteGV.ForeColor = System.Drawing.Color.Azure;
            this.btnEditDeleteGV.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditDeleteGV.ImageKey = "editdelete.png";
            this.btnEditDeleteGV.ImageList = this.imageList1;
            this.btnEditDeleteGV.Location = new System.Drawing.Point(0, 45);
            this.btnEditDeleteGV.Name = "btnEditDeleteGV";
            this.btnEditDeleteGV.Size = new System.Drawing.Size(176, 50);
            this.btnEditDeleteGV.TabIndex = 1;
            this.btnEditDeleteGV.Text = "Sửa,Xóa Giáo Viên";
            this.btnEditDeleteGV.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditDeleteGV.UseVisualStyleBackColor = false;
            this.btnEditDeleteGV.Click += new System.EventHandler(this.btnEditDeleteGV_Click);
            // 
            // btnThemGV
            // 
            this.btnThemGV.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnThemGV.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemGV.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnThemGV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemGV.Font = new System.Drawing.Font("Leelawadee UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemGV.ForeColor = System.Drawing.Color.Azure;
            this.btnThemGV.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThemGV.ImageKey = "add.png";
            this.btnThemGV.ImageList = this.imageList1;
            this.btnThemGV.Location = new System.Drawing.Point(0, 0);
            this.btnThemGV.Name = "btnThemGV";
            this.btnThemGV.Size = new System.Drawing.Size(176, 45);
            this.btnThemGV.TabIndex = 0;
            this.btnThemGV.Text = "Thêm Giáo Viên";
            this.btnThemGV.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThemGV.UseVisualStyleBackColor = false;
            this.btnThemGV.Click += new System.EventHandler(this.btnThemGV_Click);
            // 
            // btnGV
            // 
            this.btnGV.BackColor = System.Drawing.Color.SteelBlue;
            this.btnGV.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGV.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnGV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGV.Font = new System.Drawing.Font("Leelawadee UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGV.ForeColor = System.Drawing.Color.Azure;
            this.btnGV.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGV.ImageKey = "teacher.png";
            this.btnGV.ImageList = this.imageList1;
            this.btnGV.Location = new System.Drawing.Point(0, 295);
            this.btnGV.Name = "btnGV";
            this.btnGV.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnGV.Size = new System.Drawing.Size(176, 45);
            this.btnGV.TabIndex = 4;
            this.btnGV.Text = "Giáo Viên";
            this.btnGV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGV.UseVisualStyleBackColor = false;
            this.btnGV.Click += new System.EventHandler(this.btnGV_Click);
            // 
            // panelStudent
            // 
            this.panelStudent.Controls.Add(this.btnEditDeleteHS);
            this.panelStudent.Controls.Add(this.btnAddHS);
            this.panelStudent.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelStudent.Location = new System.Drawing.Point(0, 202);
            this.panelStudent.Name = "panelStudent";
            this.panelStudent.Size = new System.Drawing.Size(176, 93);
            this.panelStudent.TabIndex = 3;
            // 
            // btnEditDeleteHS
            // 
            this.btnEditDeleteHS.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnEditDeleteHS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditDeleteHS.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEditDeleteHS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditDeleteHS.Font = new System.Drawing.Font("Leelawadee UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditDeleteHS.ForeColor = System.Drawing.Color.Azure;
            this.btnEditDeleteHS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditDeleteHS.ImageIndex = 3;
            this.btnEditDeleteHS.ImageList = this.imageList1;
            this.btnEditDeleteHS.Location = new System.Drawing.Point(0, 45);
            this.btnEditDeleteHS.Name = "btnEditDeleteHS";
            this.btnEditDeleteHS.Size = new System.Drawing.Size(176, 50);
            this.btnEditDeleteHS.TabIndex = 1;
            this.btnEditDeleteHS.Text = "Sửa,Xóa Học Sinh";
            this.btnEditDeleteHS.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditDeleteHS.UseVisualStyleBackColor = false;
            this.btnEditDeleteHS.Click += new System.EventHandler(this.btnEditDeleteHS_Click);
            // 
            // btnAddHS
            // 
            this.btnAddHS.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAddHS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddHS.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAddHS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddHS.Font = new System.Drawing.Font("Leelawadee UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddHS.ForeColor = System.Drawing.Color.Azure;
            this.btnAddHS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddHS.ImageIndex = 2;
            this.btnAddHS.ImageList = this.imageList1;
            this.btnAddHS.Location = new System.Drawing.Point(0, 0);
            this.btnAddHS.Name = "btnAddHS";
            this.btnAddHS.Size = new System.Drawing.Size(176, 45);
            this.btnAddHS.TabIndex = 0;
            this.btnAddHS.Text = "Thêm Học Sinh";
            this.btnAddHS.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddHS.UseVisualStyleBackColor = false;
            this.btnAddHS.Click += new System.EventHandler(this.btnAddHS_Click);
            // 
            // btnHocSinh
            // 
            this.btnHocSinh.BackColor = System.Drawing.Color.SteelBlue;
            this.btnHocSinh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHocSinh.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHocSinh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHocSinh.Font = new System.Drawing.Font("Leelawadee UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHocSinh.ForeColor = System.Drawing.Color.Azure;
            this.btnHocSinh.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHocSinh.ImageIndex = 1;
            this.btnHocSinh.ImageList = this.imageList1;
            this.btnHocSinh.Location = new System.Drawing.Point(0, 157);
            this.btnHocSinh.Name = "btnHocSinh";
            this.btnHocSinh.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnHocSinh.Size = new System.Drawing.Size(176, 45);
            this.btnHocSinh.TabIndex = 2;
            this.btnHocSinh.Text = "Học Sinh";
            this.btnHocSinh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHocSinh.UseVisualStyleBackColor = false;
            this.btnHocSinh.Click += new System.EventHandler(this.btnHocSinh_Click);
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.SteelBlue;
            this.btnHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHome.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Font = new System.Drawing.Font("Leelawadee UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHome.ForeColor = System.Drawing.Color.Azure;
            this.btnHome.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHome.ImageIndex = 0;
            this.btnHome.ImageList = this.imageList1;
            this.btnHome.Location = new System.Drawing.Point(0, 112);
            this.btnHome.Name = "btnHome";
            this.btnHome.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnHome.Size = new System.Drawing.Size(176, 45);
            this.btnHome.TabIndex = 1;
            this.btnHome.Text = "Trang Chủ";
            this.btnHome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHome.UseVisualStyleBackColor = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.Controls.Add(this.label1);
            this.panelLogo.Controls.Add(this.pictureBox1);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(176, 112);
            this.panelLogo.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Leelawadee UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(42, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Hello: Admin";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(176, 78);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panelMain
            // 
            this.panelMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMain.AutoScroll = true;
            this.panelMain.Location = new System.Drawing.Point(199, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(924, 620);
            this.panelMain.TabIndex = 1;
            // 
            // frmHomeAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1123, 620);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmHomeAdmin";
            this.Text = "Admin";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmHomeAdmin_FormClosing);
            this.Load += new System.EventHandler(this.frmHomeAdmin_Load);
            this.panelMenu.ResumeLayout(false);
            this.panelClass.ResumeLayout(false);
            this.panelTeacher.ResumeLayout(false);
            this.panelStudent.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            this.panelLogo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelStudent;
        private System.Windows.Forms.Button btnEditDeleteHS;
        private System.Windows.Forms.Button btnAddHS;
        private System.Windows.Forms.Button btnHocSinh;
        private System.Windows.Forms.Button btnHome;
        public System.Windows.Forms.Button btnGV;
        public System.Windows.Forms.Button btnExit;
        public System.Windows.Forms.Button btnSupport;
        public System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Panel panelClass;
        private System.Windows.Forms.Button btnEditDeleteLop;
        private System.Windows.Forms.Button btnAddLop;
        public System.Windows.Forms.Button btnLop;
        private System.Windows.Forms.Panel panelTeacher;
        private System.Windows.Forms.Button btnEditDeleteGV;
        private System.Windows.Forms.Button btnThemGV;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Button btnLichHoc;
        private System.Windows.Forms.Button btnThongTinLop;
        public System.Windows.Forms.Button btnReporting;
    }
}