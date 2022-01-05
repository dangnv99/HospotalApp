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
    public partial class FrmDangNhap : Form
    {
        public FrmDangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            //DanhSachBacSi fr = new DanhSachBacSi();
            //fr.ShowDialog();

            //FormTiepDon fs = new FormTiepDon();
            //fs.ShowDialog();

            //DanhSachBenhNhan fr = new DanhSachBenhNhan();
            //fr.ShowDialog();

            FrmMenu fr = new FrmMenu();
            fr.ShowDialog();
            this.Hide();
            
            this.Close();
        }

        private void FrmDangNhap_Load(object sender, EventArgs e)
        {

        }
    }
}
