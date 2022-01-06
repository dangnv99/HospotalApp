using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiPhongKham
{
    public partial class PayOnline : Form
    {
        string sotien;
        PictureBox image;
        public PayOnline(string sotien_ , PictureBox image_)
        {
            this.sotien = sotien_;
            this.image = image_;
            InitializeComponent();
        }

        private void PayOnline_Load(object sender, EventArgs e)
        {
            txtTT.Text = sotien + " VNĐ";
            pbTT.Image = image.Image;
        }

        private void pbTT_Click(object sender, EventArgs e)
        {

        }
    }
}
