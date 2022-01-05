using Inventec.WCF.JsonConvert;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiPhongKham
{
    public partial class FrmDanhSachDichVu : Form
    {
        public FrmDanhSachDichVu()
        {
            InitializeComponent();
        }
        #region -Hàm sử lí họi api
        Socket Socket;
        public bool Received;
        public void requestPOST(string name, string pricre)
        {

            try
            {
                string url = "http://localhost/data/api/Service/Creat-Service"; // Just a sample url
                WebClient wc = new WebClient();
                wc.QueryString.Add("name", name);
                wc.QueryString.Add("price", pricre);
                var data = wc.UploadValues(url, "POST", wc.QueryString);
                var responseString = UnicodeEncoding.UTF8.GetString(data);
                if (responseString.Contains("thành công"))
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Thêm dịch vụ thành công", "Thông báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.None);
                    LoadService();
                }
                else
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Thêm dịch vụ thất bại", "Thông báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.None);
                }

            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }
        public void LoadService()
        {

            try
            {
                //HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create("http://localhost/data/api/Service/get-list-Service");
                ASCIIEncoding encoder = new ASCIIEncoding();
                byte[] data = encoder.GetBytes(""); // a json object, or xml, whatever...
                HttpWebRequest request = WebRequest.Create("http://localhost/data/api/Service/get-list-Service") as HttpWebRequest;
                request.Method = "POST";
                request.ContentType = "application/json";
                request.ContentLength = data.Length;
                request.Expect = "application/json";
                request.GetRequestStream().Write(data, 0, data.Length);
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                responServicve service = new responServicve();
                service = JsonConvert.Deserialize<responServicve>(responseString);
                grcDanhSachDichVu.BeginUpdate();
                grcDanhSachDichVu.DataSource = service.data; //.Where(o => o.name != null)
                grcDanhSachDichVu.EndUpdate();
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }

        }
        #endregion
        private void FrmDanhSachDichVu_Load(object sender, EventArgs e)
        {
            try
            {
                LoadService();
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string data = "http://localhost/data/api/Service/Creat-Service?name=Khám tai&price=100000";
            try
            {
                if (!string.IsNullOrEmpty(txtprice.Text) && !string.IsNullOrEmpty(txtName.Text))
                {
                    requestPOST(txtName.Text, txtprice.Text);
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }

        private void txtSua_Click(object sender, EventArgs e)
        {
            var data = (transInfo)grvDanhSachDichVu.GetFocusedRow();
            if (data != null)
            {
                string url = "http://localhost/data/api/Service/Update-Service"; 
                WebClient wc = new WebClient();
                wc.QueryString.Add("id", data.id);
                wc.QueryString.Add("name", txtName.Text);
                wc.QueryString.Add("price", txtprice.Text);
                var data_ = wc.UploadValues(url, "POST", wc.QueryString);
                var responseString = UnicodeEncoding.UTF8.GetString(data_);
                LoadService();
            }
        }

        private void grvDanhSachDichVu_Click(object sender, EventArgs e)
        {
            try
            {
                var data = (transInfo)grvDanhSachDichVu.GetFocusedRow();
                if (data != null)
                {
                    txtName.Text = data.name;
                    txtprice.Text = data.price.ToString();
                }

            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }

        private void grvDanhSachDichVu_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {


                if (e.KeyCode == Keys.Enter)
                {
                    var data = (transInfo)grvDanhSachDichVu.GetFocusedRow();
                    if (data != null)
                    {
                        txtName.Text = data.name;
                        txtprice.Text = data.price.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void txtXoa_Click(object sender, EventArgs e)
        {

            try
            {
                var data = (transInfo)grvDanhSachDichVu.GetFocusedRow();
                if (data != null)
                {
                    string url = "http://localhost/data/api/Service/Delete-Role"; 
                    WebClient wc = new WebClient();
                    wc.QueryString.Add("id", data.id);
                    //wc.QueryString.Add("name", txtName.Text);
                    //wc.QueryString.Add("price", txtprice.Text);
                    var data_ = wc.UploadValues(url, "POST", wc.QueryString);
                    var responseString = UnicodeEncoding.UTF8.GetString(data_);
                    LoadService();
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }

        }

    }
}
