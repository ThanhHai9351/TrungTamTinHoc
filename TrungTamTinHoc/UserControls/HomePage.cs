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
    public partial class HomePage : UserControl
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

       

        private void HomePage_Load(object sender, EventArgs e)
        {
            List<Tuple<string, int>> data = new List<Tuple<string, int>>
{
    new Tuple<string, int>("14", 14),
    new Tuple<string, int>("15", 34),
    new Tuple<string, int>("16", 60),
    new Tuple<string, int>("17",66),
    new Tuple<string, int>("18", 130),
    new Tuple<string, int>("19", 116),
    new Tuple<string, int>("20", 70),
    new Tuple<string, int>("21", 49),
};
            data.Sort((a, b) => a.Item1.CompareTo(b.Item1));
            foreach (var item in data)
            {
                chart1.Series[0].Points.AddXY(item.Item1, item.Item2);
            }
            chart1.Series[0].IsValueShownAsLabel = false;
           


        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
