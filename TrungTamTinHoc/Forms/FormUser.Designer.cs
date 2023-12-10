
namespace TrungTamTinHoc.Forms
{
    partial class FormUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormUser));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lbNameNhanVien = new System.Windows.Forms.Label();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnCongNo = new System.Windows.Forms.Button();
            this.btnLop = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelMenu.SuspendLayout();
            this.SuspendLayout();
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
            // 
            // lbNameNhanVien
            // 
            this.lbNameNhanVien.AutoSize = true;
            this.lbNameNhanVien.Font = new System.Drawing.Font("Leelawadee UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNameNhanVien.ForeColor = System.Drawing.Color.White;
            this.lbNameNhanVien.Location = new System.Drawing.Point(42, 85);
            this.lbNameNhanVien.Name = "lbNameNhanVien";
            this.lbNameNhanVien.Size = new System.Drawing.Size(97, 19);
            this.lbNameNhanVien.TabIndex = 1;
            this.lbNameNhanVien.Text = "Hello: Admin";
            // 
            // panelLogo
            // 
            this.panelLogo.Controls.Add(this.lbNameNhanVien);
            this.panelLogo.Controls.Add(this.pictureBox1);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(197, 112);
            this.panelLogo.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(197, 78);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panelMenu
            // 
            this.panelMenu.AutoScroll = true;
            this.panelMenu.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panelMenu.Controls.Add(this.btnExit);
            this.panelMenu.Controls.Add(this.btnCongNo);
            this.panelMenu.Controls.Add(this.btnLop);
            this.panelMenu.Controls.Add(this.btnHome);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(197, 620);
            this.panelMenu.TabIndex = 2;
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
            this.btnExit.Location = new System.Drawing.Point(0, 575);
            this.btnExit.Name = "btnExit";
            this.btnExit.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnExit.Size = new System.Drawing.Size(197, 45);
            this.btnExit.TabIndex = 11;
            this.btnExit.Text = "Đăng Xuất";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnCongNo
            // 
            this.btnCongNo.BackColor = System.Drawing.Color.SteelBlue;
            this.btnCongNo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCongNo.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCongNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCongNo.Font = new System.Drawing.Font("Leelawadee UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCongNo.ForeColor = System.Drawing.Color.Azure;
            this.btnCongNo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCongNo.ImageKey = "Class.png";
            this.btnCongNo.ImageList = this.imageList1;
            this.btnCongNo.Location = new System.Drawing.Point(0, 202);
            this.btnCongNo.Name = "btnCongNo";
            this.btnCongNo.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnCongNo.Size = new System.Drawing.Size(197, 45);
            this.btnCongNo.TabIndex = 8;
            this.btnCongNo.Text = "Công nợ:";
            this.btnCongNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCongNo.UseVisualStyleBackColor = false;
            this.btnCongNo.Click += new System.EventHandler(this.btnCongNo_Click);
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
            this.btnLop.Location = new System.Drawing.Point(0, 157);
            this.btnLop.Name = "btnLop";
            this.btnLop.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnLop.Size = new System.Drawing.Size(197, 45);
            this.btnLop.TabIndex = 7;
            this.btnLop.Text = "Lớp Học";
            this.btnLop.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLop.UseVisualStyleBackColor = false;
            this.btnLop.Click += new System.EventHandler(this.btnLop_Click);
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
            this.btnHome.Size = new System.Drawing.Size(197, 45);
            this.btnHome.TabIndex = 2;
            this.btnHome.Text = "Trang Chủ";
            this.btnHome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHome.UseVisualStyleBackColor = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
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
            this.panelMain.TabIndex = 3;
            this.panelMain.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMain_Paint);
            // 
            // FormUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1123, 620);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.panelMain);
            this.Name = "FormUser";
            this.Text = "FormUser";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormUser_FormClosing);
            this.Load += new System.EventHandler(this.FormUser_Load);
            this.panelLogo.ResumeLayout(false);
            this.panelLogo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label lbNameNhanVien;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Button btnHome;
        public System.Windows.Forms.Button btnLop;
        public System.Windows.Forms.Button btnCongNo;
        public System.Windows.Forms.Button btnExit;
    }
}