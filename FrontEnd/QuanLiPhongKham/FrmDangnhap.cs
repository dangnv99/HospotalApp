using Inventec.Common.Adapter;
using Inventec.Common.Controls.EditorLoader;
using Inventec.Core;
using Newtonsoft.Json;
using QuanLiPhongKham.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading;
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


        #region
        responUserRole getrole_;
        public void Getdata()
        {
            try
            {
                responUserRole getrole = new responUserRole();
                getrole.code = "doctor";
                var json = JsonConvert.SerializeObject(getrole, Formatting.Indented);
                File.WriteAllText("utf8.json", json, Encoding.UTF8);
                File.WriteAllText("default.json", json, Encoding.Default);
                var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
                var url = "http://localhost/data/api/User/get-list-user-by-role";
                var client = new HttpClient();
                var response = client.PostAsync(url, data).Result;
                string result = response.Content.ReadAsStringAsync().Result;
                getrole_ = new responUserRole();
                getrole_ = Inventec.WCF.JsonConvert.JsonConvert.Deserialize<responUserRole>(result);


            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }
        #endregion


        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            //DanhSachBacSi fr = new DanhSachBacSi();
            //fr.ShowDialog();

            //FormTiepDon fs = new FormTiepDon();
            //fs.ShowDialog();

            //DanhSachBenhNhan fr = new DanhSachBenhNhan();
            //fr.ShowDialog();
            if (!string.IsNullOrEmpty(txtTaiKhoan.Text) && !string.IsNullOrEmpty(txtMatKhau.Text))
            {
                var check = getrole_.data.Where(o => o.userName == txtTaiKhoan.Text).Where(o => o.passWord == txtMatKhau.Text);
                if (check != null && check.Count() > 0)
                {
                    FrmMenu fr = new FrmMenu();
                    fr.ShowDialog();
                    this.Hide();
                    this.Close();
                }
                else
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Tài khoản hoặc mật khẩu không chính xác", "Thông báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                }

            }
            else
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Chưa điền mật khẩu hoặc tài khoản", "Thông báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        private void FrmDangNhap_Load(object sender, EventArgs e)
        {
            Getdata();
        }

        private void txtTaiKhoan_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtMatKhau.Focus();
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void txtMatKhau_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnDangNhap.Focus();
                    btnDangNhap_Click(null , null);
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Warn(ex);
            }
        }
    }
}
