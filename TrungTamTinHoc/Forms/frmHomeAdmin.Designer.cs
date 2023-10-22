
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHomeAdmin));
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnHocSinh = new System.Windows.Forms.Button();
            this.panelStudent = new System.Windows.Forms.Panel();
            this.btnAddHS = new System.Windows.Forms.Button();
            this.btnEditDeleteHS = new System.Windows.Forms.Button();
            this.btnGV = new System.Windows.Forms.Button();
            this.panelTeacher = new System.Windows.Forms.Panel();
            this.btnEditDeleteGV = new System.Windows.Forms.Button();
            this.btnThemGV = new System.Windows.Forms.Button();
            this.btnLop = new System.Windows.Forms.Button();
            this.panelClass = new System.Windows.Forms.Panel();
            this.btnEditDeleteLop = new System.Windows.Forms.Button();
            this.btnAddLop = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnSupport = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.panelMenu.SuspendLayout();
            this.panelStudent.SuspendLayout();
            this.panelTeacher.SuspendLayout();
            this.panelClass.SuspendLayout();
            this.panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.AutoScroll = true;
            this.panelMenu.BackColor = System.Drawing.Color.DeepSkyBlue;
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
            this.panelMenu.Size = new System.Drawing.Size(197, 660);
            this.panelMenu.TabIndex = 0;
            this.panelMenu.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMenu_Paint);
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.SteelBlue;
            this.btnHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHome.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.ForeColor = System.Drawing.Color.Azure;
            this.btnHome.Location = new System.Drawing.Point(0, 106);
            this.btnHome.Name = "btnHome";
            this.btnHome.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnHome.Size = new System.Drawing.Size(176, 45);
            this.btnHome.TabIndex = 1;
            this.btnHome.Text = "Trang Chủ";
            this.btnHome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHome.UseVisualStyleBackColor = false;
            // 
            // btnHocSinh
            // 
            this.btnHocSinh.BackColor = System.Drawing.Color.SteelBlue;
            this.btnHocSinh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHocSinh.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHocSinh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHocSinh.ForeColor = System.Drawing.Color.Azure;
            this.btnHocSinh.Location = new System.Drawing.Point(0, 151);
            this.btnHocSinh.Name = "btnHocSinh";
            this.btnHocSinh.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnHocSinh.Size = new System.Drawing.Size(176, 45);
            this.btnHocSinh.TabIndex = 2;
            this.btnHocSinh.Text = "Học Sinh";
            this.btnHocSinh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHocSinh.UseVisualStyleBackColor = false;
            this.btnHocSinh.Click += new System.EventHandler(this.btnHocSinh_Click);
            // 
            // panelStudent
            // 
            this.panelStudent.Controls.Add(this.btnEditDeleteHS);
            this.panelStudent.Controls.Add(this.btnAddHS);
            this.panelStudent.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelStudent.Location = new System.Drawing.Point(0, 196);
            this.panelStudent.Name = "panelStudent";
            this.panelStudent.Size = new System.Drawing.Size(176, 93);
            this.panelStudent.TabIndex = 3;
            // 
            // btnAddHS
            // 
            this.btnAddHS.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAddHS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddHS.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAddHS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddHS.ForeColor = System.Drawing.Color.Azure;
            this.btnAddHS.Location = new System.Drawing.Point(0, 0);
            this.btnAddHS.Name = "btnAddHS";
            this.btnAddHS.Padding = new System.Windows.Forms.Padding(50, 0, 0, 0);
            this.btnAddHS.Size = new System.Drawing.Size(176, 45);
            this.btnAddHS.TabIndex = 0;
            this.btnAddHS.Text = "Thêm Học Sinh";
            this.btnAddHS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddHS.UseVisualStyleBackColor = false;
            // 
            // btnEditDeleteHS
            // 
            this.btnEditDeleteHS.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnEditDeleteHS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditDeleteHS.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEditDeleteHS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditDeleteHS.ForeColor = System.Drawing.Color.Azure;
            this.btnEditDeleteHS.Location = new System.Drawing.Point(0, 45);
            this.btnEditDeleteHS.Name = "btnEditDeleteHS";
            this.btnEditDeleteHS.Padding = new System.Windows.Forms.Padding(50, 0, 0, 0);
            this.btnEditDeleteHS.Size = new System.Drawing.Size(176, 50);
            this.btnEditDeleteHS.TabIndex = 1;
            this.btnEditDeleteHS.Text = "Sửa,Xóa Học Sinh";
            this.btnEditDeleteHS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditDeleteHS.UseVisualStyleBackColor = false;
            // 
            // btnGV
            // 
            this.btnGV.BackColor = System.Drawing.Color.SteelBlue;
            this.btnGV.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGV.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnGV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGV.ForeColor = System.Drawing.Color.Azure;
            this.btnGV.Location = new System.Drawing.Point(0, 289);
            this.btnGV.Name = "btnGV";
            this.btnGV.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnGV.Size = new System.Drawing.Size(176, 45);
            this.btnGV.TabIndex = 4;
            this.btnGV.Text = "Giáo Viên";
            this.btnGV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGV.UseVisualStyleBackColor = false;
            this.btnGV.Click += new System.EventHandler(this.btnGV_Click);
            // 
            // panelTeacher
            // 
            this.panelTeacher.Controls.Add(this.btnEditDeleteGV);
            this.panelTeacher.Controls.Add(this.btnThemGV);
            this.panelTeacher.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTeacher.Location = new System.Drawing.Point(0, 334);
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
            this.btnEditDeleteGV.ForeColor = System.Drawing.Color.Azure;
            this.btnEditDeleteGV.Location = new System.Drawing.Point(0, 45);
            this.btnEditDeleteGV.Name = "btnEditDeleteGV";
            this.btnEditDeleteGV.Padding = new System.Windows.Forms.Padding(50, 0, 0, 0);
            this.btnEditDeleteGV.Size = new System.Drawing.Size(176, 50);
            this.btnEditDeleteGV.TabIndex = 1;
            this.btnEditDeleteGV.Text = "Sửa,Xóa Giáo Viên";
            this.btnEditDeleteGV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditDeleteGV.UseVisualStyleBackColor = false;
            // 
            // btnThemGV
            // 
            this.btnThemGV.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnThemGV.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemGV.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnThemGV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemGV.ForeColor = System.Drawing.Color.Azure;
            this.btnThemGV.Location = new System.Drawing.Point(0, 0);
            this.btnThemGV.Name = "btnThemGV";
            this.btnThemGV.Padding = new System.Windows.Forms.Padding(50, 0, 0, 0);
            this.btnThemGV.Size = new System.Drawing.Size(176, 45);
            this.btnThemGV.TabIndex = 0;
            this.btnThemGV.Text = "Thêm Giáo Viên";
            this.btnThemGV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThemGV.UseVisualStyleBackColor = false;
            // 
            // btnLop
            // 
            this.btnLop.BackColor = System.Drawing.Color.SteelBlue;
            this.btnLop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLop.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLop.ForeColor = System.Drawing.Color.Azure;
            this.btnLop.Location = new System.Drawing.Point(0, 430);
            this.btnLop.Name = "btnLop";
            this.btnLop.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnLop.Size = new System.Drawing.Size(176, 45);
            this.btnLop.TabIndex = 6;
            this.btnLop.Text = "Lớp Học";
            this.btnLop.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLop.UseVisualStyleBackColor = false;
            this.btnLop.Click += new System.EventHandler(this.btnLop_Click);
            // 
            // panelClass
            // 
            this.panelClass.Controls.Add(this.btnEditDeleteLop);
            this.panelClass.Controls.Add(this.btnAddLop);
            this.panelClass.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelClass.Location = new System.Drawing.Point(0, 475);
            this.panelClass.Name = "panelClass";
            this.panelClass.Size = new System.Drawing.Size(176, 95);
            this.panelClass.TabIndex = 7;
            // 
            // btnEditDeleteLop
            // 
            this.btnEditDeleteLop.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnEditDeleteLop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditDeleteLop.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEditDeleteLop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditDeleteLop.ForeColor = System.Drawing.Color.Azure;
            this.btnEditDeleteLop.Location = new System.Drawing.Point(0, 45);
            this.btnEditDeleteLop.Name = "btnEditDeleteLop";
            this.btnEditDeleteLop.Padding = new System.Windows.Forms.Padding(50, 0, 0, 0);
            this.btnEditDeleteLop.Size = new System.Drawing.Size(176, 50);
            this.btnEditDeleteLop.TabIndex = 1;
            this.btnEditDeleteLop.Text = "Sửa,Xóa Lớp";
            this.btnEditDeleteLop.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditDeleteLop.UseVisualStyleBackColor = false;
            // 
            // btnAddLop
            // 
            this.btnAddLop.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAddLop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddLop.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAddLop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddLop.ForeColor = System.Drawing.Color.Azure;
            this.btnAddLop.Location = new System.Drawing.Point(0, 0);
            this.btnAddLop.Name = "btnAddLop";
            this.btnAddLop.Padding = new System.Windows.Forms.Padding(50, 0, 0, 0);
            this.btnAddLop.Size = new System.Drawing.Size(176, 45);
            this.btnAddLop.TabIndex = 0;
            this.btnAddLop.Text = "Thêm Lớp";
            this.btnAddLop.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddLop.UseVisualStyleBackColor = false;
            // 
            // btnReport
            // 
            this.btnReport.BackColor = System.Drawing.Color.SteelBlue;
            this.btnReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReport.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReport.ForeColor = System.Drawing.Color.Azure;
            this.btnReport.Location = new System.Drawing.Point(0, 570);
            this.btnReport.Name = "btnReport";
            this.btnReport.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnReport.Size = new System.Drawing.Size(176, 45);
            this.btnReport.TabIndex = 8;
            this.btnReport.Text = "Báo Cáo";
            this.btnReport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReport.UseVisualStyleBackColor = false;
            // 
            // btnSupport
            // 
            this.btnSupport.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSupport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSupport.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSupport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSupport.ForeColor = System.Drawing.Color.Azure;
            this.btnSupport.Location = new System.Drawing.Point(0, 615);
            this.btnSupport.Name = "btnSupport";
            this.btnSupport.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnSupport.Size = new System.Drawing.Size(176, 45);
            this.btnSupport.TabIndex = 9;
            this.btnSupport.Text = "Hỗ Trợ";
            this.btnSupport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSupport.UseVisualStyleBackColor = false;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Crimson;
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.ForeColor = System.Drawing.Color.Azure;
            this.btnExit.Location = new System.Drawing.Point(0, 660);
            this.btnExit.Name = "btnExit";
            this.btnExit.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnExit.Size = new System.Drawing.Size(176, 45);
            this.btnExit.TabIndex = 10;
            this.btnExit.Text = "Đăng Xuất";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.Controls.Add(this.pictureBox1);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(176, 106);
            this.panelLogo.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(176, 106);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panelContainer
            // 
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelContainer.Location = new System.Drawing.Point(182, 0);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(820, 660);
            this.panelContainer.TabIndex = 2;
            this.panelContainer.Paint += new System.Windows.Forms.PaintEventHandler(this.panelContainer_Paint);
            // 
            // frmHomeAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 660);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.panelMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmHomeAdmin";
            this.Text = "frmHomeAdmin";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmHomeAdmin_FormClosing);
            this.Load += new System.EventHandler(this.frmHomeAdmin_Load);
            this.panelMenu.ResumeLayout(false);
            this.panelStudent.ResumeLayout(false);
            this.panelTeacher.ResumeLayout(false);
            this.panelClass.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
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
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panelContainer;
    }
}