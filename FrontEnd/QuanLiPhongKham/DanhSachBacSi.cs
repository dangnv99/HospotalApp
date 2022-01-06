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

    public partial class DanhSachBacSi : Form
    {
        public DanhSachBacSi()
        {
            InitializeComponent();
        }
        responServicve service_;
        responUserRole getrole;
       
        #region Ham gọi api

        public void call(UserCreat data_, string ServiceId)
        {
            try
            {
                var json = JsonConvert.SerializeObject(data_, Formatting.Indented);
                File.WriteAllText("utf8.json", json, Encoding.UTF8);
                File.WriteAllText("default.json", json, Encoding.Default);
                var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
                var url = "http://localhost/data/api/User/Creat-User";
                var client = new HttpClient();
                var response = client.PostAsync(url, data).Result;

                var result = response.Content.ReadAsStringAsync().Result;
                if (result != null)
                {
                    resultReq rs = new resultReq();
                    rs = JsonConvert.DeserializeObject<resultReq>(result);
                    if (rs.msg.Contains("thành công"))
                    {
                        RequestUserRole role = new RequestUserRole();
                        role.roleId = "2c188ad9-34aa-43d8-b9e3-442b23aecee9";
                        role.userId = rs.data;
                        var json_ = JsonConvert.SerializeObject(role, Formatting.Indented);
                        File.WriteAllText("utf8.json", json_, Encoding.UTF8);
                        File.WriteAllText("default.json", json_, Encoding.Default);
                        var data1 = new System.Net.Http.StringContent(json_, Encoding.UTF8, "application/json");
                        var url1 = "http://localhost/data/api/User/User-Role";
                        var client1 = new HttpClient();
                        var response1 = client1.PostAsync(url1, data1).Result;


                        string url2 = "http://localhost/data/api/User/add-service-to-doctor";
                        WebClient wc = new WebClient();
                        wc.QueryString.Add("DoctorId", rs.data);
                        wc.QueryString.Add("ServiceId", ServiceId);
                        var data2 = wc.UploadValues(url2, "POST", wc.QueryString);
                        var responseString = UnicodeEncoding.UTF8.GetString(data2);
                        var client_ = response1.Content.ReadAsStringAsync().Result;
                        DevExpress.XtraEditors.XtraMessageBox.Show("Thêm dịch vụ thành công", "Thông báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.None);
                    }
                    else
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("Thêm dịch vụ thất bại", "Thông báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.None);
                    }
                }
            }

            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }

        public void callupate(UserCreat data_, string ServiceId)
        {
            try
            {
                var json = JsonConvert.SerializeObject(data_, Formatting.Indented);
                File.WriteAllText("utf8.json", json, Encoding.UTF8);
                File.WriteAllText("default.json", json, Encoding.Default);
                var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
                var url = "http://localhost/data/api/User/Update-User";
                var client = new HttpClient();
                var response = client.PostAsync(url, data).Result;

                var result = response.Content.ReadAsStringAsync().Result;
                if (result != null)
                {
                    resultReq rs = new resultReq();
                    rs = JsonConvert.DeserializeObject<resultReq>(result);
                    if (rs.msg.Contains("thành công"))
                    {
                        string url2 = "http://localhost/data/api/User/add-service-to-doctor";
                        WebClient wc = new WebClient();
                        wc.QueryString.Add("DoctorId", rs.data);
                        wc.QueryString.Add("ServiceId", ServiceId);

                        var data2 = wc.UploadValues(url2, "POST", wc.QueryString);
                        var responseString = UnicodeEncoding.UTF8.GetString(data2);
                        DevExpress.XtraEditors.XtraMessageBox.Show("Thêm dịch vụ thành công", "Thông báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.None);
                    }
                    else
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("Thêm dịch vụ thất bại", "Thông báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.None);
                    }
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }

        public void Getdata()
        {
            try
            {
                getrole = new responUserRole();
                getrole.code = "doctor";
                var json = JsonConvert.SerializeObject(getrole, Formatting.Indented);
                File.WriteAllText("utf8.json", json, Encoding.UTF8);
                File.WriteAllText("default.json", json, Encoding.Default);
                var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
                var url = "http://localhost/data/api/User/get-list-user-by-role";
                var client = new HttpClient();
                var response = client.PostAsync(url, data).Result;
                string result = response.Content.ReadAsStringAsync().Result;
                responUserRole getrole_ = new responUserRole();
                getrole_ = Inventec.WCF.JsonConvert.JsonConvert.Deserialize<responUserRole>(result);
                gcdanhsachbacsi.DataSource = getrole_.data;

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
                service_ = new responServicve();
                service_ = Inventec.WCF.JsonConvert.JsonConvert.Deserialize<responServicve>(responseString);
                List<ColumnInfo> columnInfos = new List<ColumnInfo>();
                columnInfos.Add(new ColumnInfo("name", "", 100, 1));
                ControlEditorADO controlEditorADO = new ControlEditorADO("name", "id", columnInfos, false, 100);
                ControlEditorLoader.Load(cboDichVuKham, service_.data, controlEditorADO);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }
        # endregion

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                UserCreat data_ = new UserCreat();
                data_.name = txtHoTen.Text;
                data_.sex = txtGioiTinh.Text;
                data_.phone = txtSoDT.Text;
                data_.address = txtDiaChi.Text;
                data_.username = txtTaiKhoan.Text;
                data_.password = txtMK.Text;
                data_.yearOfBirth = txtNamSinh.Text;
                call(data_, cboDichVuKham.EditValue.ToString());
                Getdata();
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }

        private void DanhSachBacSi_Load(object sender, EventArgs e)
        {
            try
            {
                Getdata();
                LoadService();
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);                
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                var data = (getUserlist)gVDanhSachBacSi.GetFocusedRow();
                UserCreat data_ = new UserCreat();
                data_.id = data.id;
                data_.name = txtHoTen.Text;
                data_.sex = txtGioiTinh.Text;
                data_.phone = txtSoDT.Text;
                data_.address = txtDiaChi.Text;
                data_.username = txtTaiKhoan.Text;
                data_.password = txtMK.Text;
                data_.yearOfBirth = txtNamSinh.Text;
                callupate(data_, cboDichVuKham.EditValue.ToString());
                Getdata();

            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                var data = (getUserlist)gVDanhSachBacSi.GetFocusedRow();
                if (data != null)
                {
                    string url = "http://localhost/data/api/User/Delete-User";
                    WebClient wc = new WebClient();
                    wc.QueryString.Add("id", data.id);
                    var datawc = wc.UploadValues(url, "POST", wc.QueryString);
                    var responseString = UnicodeEncoding.UTF8.GetString(datawc);
                    Getdata();
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }

        private void gVDanhSachBacSi_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {         
            try
            {
                var data = (getUserlist)gVDanhSachBacSi.GetFocusedRow();
                if (data != null)
                {

                    txtHoTen.Text = data.name  ;
                    txtGioiTinh.Text = data.sex ;
                    txtSoDT.Text = data.phone;
                    txtDiaChi.Text = data.address;
                    //txtTaiKhoan.Text = data.username ;
                    //data.password = txtMK.Text;
                    txtNamSinh.Text = data.yearOfBirth;
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);                
            }  
        }

        private void txtHoTen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtGioiTinh.Focus();
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void txtGioiTinh_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtNamSinh.Focus();
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void txtNamSinh_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtDiaChi.Focus();
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void txtDiaChi_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtSoDT.Focus();
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void txtSoDT_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtTaiKhoan.Focus();
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void txtTaiKhoan_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtMK.Focus();
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void txtMK_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cboDichVuKham.Focus();
                    cboDichVuKham.ShowPopup();
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Warn(ex);
            }
        }
    }
}
