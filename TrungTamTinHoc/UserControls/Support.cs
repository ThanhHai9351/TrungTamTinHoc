using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrungTamTinHoc.UserControls
{
    public partial class Support : UserControl
    {
        public Support()
        {
            InitializeComponent();
        }

        private void btnPhanHoi_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cảm ơn bạn đã phản hồi!");
            txtHoTro.Text = "";
        }
    }
}
